using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.Paging;
using EducationSysetm.Dtos;
using EducationSysetm.Others;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private IUnitOfWork _uow;
        private ILogger<SessionController> _logger;
        private IMapper _mapper;

        public SessionController(IUnitOfWork uow, ILogger<SessionController> logger, IMapper mapper)
        {
            _uow = uow;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {

            var sessionsItem = await _uow.Sessions.GetAsync(x => x.Id == id);
            if (sessionsItem != null)
            {
                return Ok(_mapper.Map<SessionGetDto>(sessionsItem));

            }
            _logger.LogError("Something Went Wrong Try again.");
            return NotFound();


        }
        [HttpGet]
        public async Task<IActionResult> GetSessions([FromQuery] PagingDetails paging, string sortOrder, string searchString, DateTime? sessionDate,int? courseId)
        {
            var sessions = await _uow.Sessions.FindAllAsync(paging);

            if (courseId!=0 && courseId!=null)
            {
                sessions = sessions.Where(x => x.CourseId==courseId);

            }

            if (!String.IsNullOrEmpty(searchString))
            {
                sessions = sessions.Where(x => x.SessionTitle.Contains(searchString));
            }

            if (sessionDate.HasValue)
            {
                sessions = sessions.Where(x => x.Date == sessionDate);
            }

            switch (sortOrder)
            {
                case "SessionTitle_desc":

                    sessions = sessions.OrderByDescending(x => x.SessionTitle).ThenByDescending(x => x.Date);
                    break;
                case "SessionTitle_asc":
                    sessions = sessions.OrderBy(x => x.SessionTitle).ThenByDescending(x => x.Date);
                    break;


                case "SessionDate_desc":
                    sessions = sessions.OrderByDescending(x => x.Date).ThenBy(x => x.SessionTitle);
                    break;

                case "SessionDate_asc":
                    sessions = sessions.OrderBy(x => x.Date).ThenBy(x => x.SessionTitle);
                    break;

                default:
                    sessions = sessions.OrderByDescending(x => x.Date).ThenBy(x => x.SessionTitle);
                    break;
            }

            var result = PagedList<Session>.ToPagedList(sessions, paging.PageNumber, paging.PageSize);
            Utility.Result(result, Response);
            return Ok(_mapper.Map<IList<SessionGetDto>>(result));

        }


        [HttpPost("course/{courseid}")]
        public async Task<IActionResult> CreateSession(SessionAddDto  sessionAddDto , int courseid)
        {
             var sessionItem = _mapper.Map<Session>(sessionAddDto);
            sessionItem.CourseId = courseid;
            await _uow.Sessions.AddAsync(sessionItem);
            await _uow.Save();
            return Ok("Success");

        }
     
        [HttpPost("AddMultiSession")]
        public async Task<IActionResult> CreateSessions(IEnumerable<SessionAddDto> sessionAddDto)
        {
            var sessionItems = _mapper.Map<IList<Session>>(sessionAddDto);

            await _uow.Sessions.AddRangeASync(sessionItems);
            await _uow.Save();
            return Ok("Success");

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(int id, SessionUpdateDto studentUpdateDto)
        {
            var sessionItem = await _uow.Sessions.GetAsync(x => x.Id == id);
            if (sessionItem == null)
            {
                return NotFound("it's not found in the database");
            }
            _mapper.Map(studentUpdateDto, sessionItem);
            _uow.Sessions.Update(sessionItem);
            await _uow.Save();
            return Ok("Success");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(int id)
        {
            var sessionItem = await _uow.Sessions.GetByIdAsync(id);
            if (sessionItem == null)
            {
                return NotFound("it's not found in the database");
            }
            await _uow.Sessions.Delete(id);
            await _uow.Save();
            _logger.LogInformation("someone deleted a Course");
            return NoContent();

        }

        [HttpGet("count")]
        public async Task<IActionResult> GetSessionCount()
        {
            var sessionCount = await _uow.Sessions.CountAsync();
            return Ok(sessionCount);
        }
        [HttpPost("Students/{studentId}")]
        public async Task<IActionResult> AddStudentToSessionAsync([FromQuery] int? id, SessionAddDto sessionDto, int studentId)
        {
            var student = await _uow.Students.GetByIdAsync(studentId);
            if (id == null)
            {
                var session = _mapper.Map<Session>(sessionDto);
                session.Students = new List<Student>();
                session.Students.Add(student);
                await _uow.Sessions.AddAsync(session);
                await _uow.Save();
                return Ok("Success");
            }
            var sessionItem = await _uow.Sessions.GetByIdAsync((int)id);
            if (sessionItem == null)
            {
                return NotFound("it's not found in the database");
            }
            sessionItem.Students = new List<Student>();
            sessionItem.Students.Add(student);
            _mapper.Map(sessionDto, sessionItem);
            _uow.Sessions.Update(sessionItem);
            await _uow.Save();
            return Ok("Success");

        }
      
        //[HttpPost("{sessionid}"), ActionName("Delete")]
        //public async Task<IActionResult> DeleteSessionfromCoursess(int sessionid,  [FromQuery] int? courseId)
        //{
        //    var session = await _uow.Sessions.GetAsync(x => x.Id == sessionid);
        //    if (session == null)
        //    {
        //        return NotFound("it's not found in the database");
        //    }      
        //    if (courseId != null)
        //    {
        //        session.CourseId = null;

        //    }
        //    await _uow.Save();
        //    return Ok("Success");

        //}
        [HttpPost("{id}/Student"), ActionName("Delete")]
        public async Task<IActionResult> DeleteStudentfromSession(int id, [FromQuery] int? studentId)
        {
            var sessionItem = await _uow.Sessions.GetAsync(x => x.Id == id, new List<string> { "Students" });
            if (sessionItem == null)
            {
                return NotFound("it's not found in the database");
            }
            if (studentId != null)
            {
                var sessionStudent = sessionItem.Students.First(x => x.Id == studentId);
                if (sessionStudent == null)
                {
                    return NotFound("it's not found in the database");

                }
                sessionItem.Students.Remove(sessionStudent);
            } 
            await _uow.Save();
            return Ok("Success");

        }
    }
}

