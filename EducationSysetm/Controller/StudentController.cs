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
        public async Task<IActionResult> GetStudents([FromQuery] PagingDetails paging, string sortOrder, string searchString)
        {

            if (!String.IsNullOrEmpty(searchString))
            {

                var students = await _uow.Students.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));

                switch (sortOrder)
                {
                    case "FirstName_desc":
                        students = await _uow.Students.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString),
                                                      y => y.OrderByDescending(x => x.FirstName));
                        break;
                    case "FirstName_asc":
                        students = await _uow.Students.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString),
                                                  y => y.OrderBy(x => x.FirstName));
                        break;
                    case "LastName_desc":
                        students = await _uow.Students.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString),
                                                 y => y.OrderByDescending(x => x.LastName));
                        break;
                    case "LastName_asc":
                        students = await _uow.Students.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString),
                                                 y => y.OrderBy(x => x.LastName));
                        break;

                    default:
                        students = await _uow.Students.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));

                        break;
                }
                Utility.Result(students, Response);
                return Ok(_mapper.Map<IList<StudentGetDto>>(students));

            }
            var result = await _uow.Students.GetAllAsync(paging);
            Utility.Result(result, Response);
            return Ok(_mapper.Map<IList<StudentGetDto>>(result));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {

            var studentItem = await _uow.Students.GetAsync(x => x.Id == id, new List<string>() { "Teacher" });
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
