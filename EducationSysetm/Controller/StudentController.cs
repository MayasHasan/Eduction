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
    public class StudentController : ControllerBase
    {
        private IUnitOfWork _uow;
        private ILogger<CourseController> _logger;
        private IMapper _mapper;

        public StudentController(IUnitOfWork uow, ILogger<CourseController> logger, IMapper mapper)
        {
            _uow = uow;
            _logger = logger;
            _mapper = mapper;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetStudents([FromQuery] PagingDetails paging, string sortOrder, string searchString, string level, DateTime? joinedDateFrom, DateTime? joinedDateTo)
        {
            var students = await _uow.Students.FindAllAsync(paging);
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));
            }
           
            if (!String.IsNullOrEmpty(level))
            {
                students = students.Where(x => x.Level == level);
            }
            if (joinedDateFrom.HasValue && !joinedDateTo.HasValue)
            {
                students = students.Where(x => x.JoinedDate == joinedDateFrom);
            }

            if (joinedDateFrom.HasValue && joinedDateTo.HasValue)
            {
                students = students.Where(x => x.JoinedDate >= joinedDateFrom && x.JoinedDate <= joinedDateTo);
            }
            switch (sortOrder)
            {
                case "FirstName_desc":

                    students = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.Level).ThenByDescending(x => x.JoinedDate);
                    break;
                case "FirstName_asc":
                    students = students.OrderBy(x => x.FirstName).ThenByDescending(x => x.Level).ThenByDescending(x => x.JoinedDate);
                    break;
           
                case "JoinedDate_asc":
                    students = students.OrderBy(x => x.JoinedDate).ThenBy(x => x.FirstName).ThenByDescending(x => x.Level);
                    break;

                default:
                    students = students.OrderByDescending(x => x.JoinedDate).ThenBy(x => x.FirstName).ThenByDescending(x => x.Level);
                    break;
            }

            var result = PagedList<Student>.ToPagedList(students, paging.PageNumber, paging.PageSize);
            Utility.Result(result, Response);
            return Ok(_mapper.Map<IList<StudentGetDto>>(result));

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id )
        {

            var studentItem = await _uow.Students.GetAsync(x => x.Id == id, new List<string>() { "Courses"});
            if (studentItem != null)
            {
               
                return Ok(_mapper.Map<StudentGetDto>(studentItem));

            }
        


            _logger.LogError("Something Went Wrong Try Later.");
            return NotFound();


        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentAddDto studentAddDto)
        {
            var studentItem = _mapper.Map<Student>(studentAddDto);
            await _uow.Students.AddAsync(studentItem);
            await _uow.Save();
            return Ok("Success");

        }
        [HttpPost("AddMultiSession")]
        public async Task<IActionResult> CreateStudents(IEnumerable<StudentAddDto> studentAddDto)
        {
            var studentItems = _mapper.Map<IList<Student>>(studentAddDto);

            await _uow.Students.AddRangeASync(studentItems);
            await _uow.Save();
            return Ok("Success");

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateDto  studentUpdateDto)
        {
            var studentItem = await _uow.Students.GetAsync(x => x.Id == id);
            if (studentItem == null)
            {
                return NotFound("it's not found in the database");
            }
            _mapper.Map(studentUpdateDto, studentItem);
            _uow.Students.Update(studentItem);
            await _uow.Save();
            return Ok("Success");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var studentItem = await _uow.Students.GetByIdAsync(id);
            if (studentItem == null)
            {
                return NotFound("it's not found in the database");
            }
            await _uow.Students.Delete(id);
            await _uow.Save();
            _logger.LogInformation("someone deleted a Course");
            return NoContent();

        }

        [HttpGet("count")]
        public async Task<IActionResult> GetStudnetCount()
        {

            var studentCount = await _uow.Students.CountAsync();
            return Ok(studentCount);
        }
    }
}
