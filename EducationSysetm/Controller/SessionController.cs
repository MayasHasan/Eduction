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
    [Route("api/[controller]")]
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
        [HttpGet]
        public async Task<IActionResult> GetSessions([FromQuery] PagingDetails paging, string sortOrder, string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {

                var sessions = await _uow.Sessions.GetAllAsync(paging, x => x.SessionNumber.Contains(searchString) || x.Date.ToString().Contains(searchString));

                switch (sortOrder)
                {
                    case "SessionNumber_desc":
                        sessions = await _uow.Sessions.GetAllAsync(paging, x => x.SessionNumber.Contains(searchString) || x.Date.ToString().Contains(searchString),
                                                      y => y.OrderByDescending(x => x.SessionNumber));
                        break;
                    case "SessionNumber_asc":
                        sessions = await _uow.Sessions.GetAllAsync(paging, x => x.SessionNumber.Contains(searchString) || x.Date.ToString().Contains(searchString),
                                                  y => y.OrderBy(x => x.SessionNumber));
                        break;
                    case "Date_desc":
                        sessions = await _uow.Sessions.GetAllAsync(paging, x => x.SessionNumber.Contains(searchString) || x.Date.ToString().Contains(searchString),
                                                 y => y.OrderByDescending(x => x.Date));
                        break;
                    case "Date_asc":
                        sessions = await _uow.Sessions.GetAllAsync(paging, x => x.SessionNumber.Contains(searchString) || x.Date.ToString().Contains(searchString),
                                                 y => y.OrderBy(x => x.Date));
                        break;

                    default:
                        sessions = await _uow.Sessions.GetAllAsync(paging, x => x.SessionNumber.Contains(searchString) || x.Date.ToString().Contains(searchString));

                        break;
                }
                Utility.Result(sessions, Response);
                return Ok(_mapper.Map<IList<SessionGetDto>>(sessions));

            }
            var result = await _uow.Sessions.GetAllAsync(paging);
            Utility.Result(result, Response);
            return Ok(_mapper.Map<IList<SessionGetDto>>(result));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {

            var sessionItem = await _uow.Sessions.GetAsync(x => x.Id == id, new List<string>() { "Teacher" });
            if (sessionItem != null)
            {
                return Ok(_mapper.Map<SessionGetDto>(sessionItem));

            }
            _logger.LogError("Something Went Wrong Try Later.");
            return NotFound();


        }

        [HttpPost]
        public async Task<IActionResult> CreateSession(SessionAddDto  sessionAddDto )
        {
            var sessionItem = _mapper.Map<Session>(sessionAddDto);
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
      
        [HttpPost("{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteSessionfromCoursess(int id,  [FromQuery] int? courseId)
        {
            var session = await _uow.Sessions.GetAsync(x => x.Id == id);
            if (session == null)
            {
                return NotFound("it's not found in the database");
            }      
            if (courseId != null)
            {
                session.CourseId = null;

            }
            await _uow.Save();
            return Ok("Success");

        }
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

