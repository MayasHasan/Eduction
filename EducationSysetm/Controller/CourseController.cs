using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.Paging;
using DataAccessEF;
using EducationSysetm.Dtos;
using EducationSysetm.Others;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Controller
{
   

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _appContext;
        private readonly IUnitOfWork _uow;
        private readonly ILogger<CourseController> _logger;
        private readonly IMapper _mapper;
        public CourseController(AppDbContext appContext , IUnitOfWork uow, ILogger<CourseController> logger, IMapper mapper)
        {
            _appContext = appContext;
            _uow = uow;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetCoursesAsync()
        {
            var course = await _uow.Courses.GetAllAsync();
            return Ok(_mapper.Map<IList<CourseGetDto>>(course));
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses([FromQuery] PagingDetails paging, string sortOrder, string title, string level, decimal? price, DateTime? startDate, DateTime? endDate )
        {

            var courses = await _uow.Courses.FindAllAsync(paging);


            if (!String.IsNullOrEmpty(title))
            {
                courses = courses.Where(s => s.Title.Contains(title));
            }

            if (!String.IsNullOrEmpty(level))
            {
                courses = courses.Where(x => x.Level == level);
            }

            if (price != null)
            {
                courses = courses.Where(x => x.FullPrice == price);
            }

            if (startDate.HasValue && !endDate.HasValue)
            {
                courses = courses.Where(x => x.StartDate == startDate);
            }

            if (!startDate.HasValue && endDate.HasValue)
            {
                courses = courses.Where(x => x.EndDate == endDate);
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                courses = courses.Where(x => x.StartDate >= startDate && x.EndDate <= endDate);
            }

            switch (sortOrder)
            {
                case "Title_desc":

                    courses = courses.OrderByDescending(x => x.Title).ThenByDescending(x => x.StartDate);
                    break;
                case "Title_asc":
                    courses = courses.OrderBy(x => x.Title).ThenByDescending(x => x.StartDate);
                    break;
                case "FulPrice_desc":
                    courses = courses.OrderByDescending(x => x.FullPrice).ThenByDescending(x => x.StartDate);
                    break;
                case "FulPrice_asc":
                    courses = courses.OrderBy(x => x.Title).ThenByDescending(x => x.StartDate);
                    break;
                case "Level_desc":
                    courses = courses.OrderByDescending(x => x.Level).ThenByDescending(x => x.StartDate);
                    break;

                case "Level_asc":
                    courses = courses.OrderBy(x => x.Level).ThenByDescending(x => x.StartDate);
                    break;

                case "StartDate_asc":
                    courses = courses.OrderBy(x => x.StartDate).ThenBy(x => x.Title);
                    break;

                default:
                    courses = courses.OrderByDescending(x => x.StartDate).ThenBy(x => x.Title);
                    break;
            }

            var result = PagedList<Course>.ToPagedList(courses, paging.PageNumber, paging.PageSize);
            Utility.Result(result, Response);
            return Ok(_mapper.Map<IList<CourseGetDto>>(result));
        }
        //[HttpGet("pv/{a?}")]
        //[HttpGet("pv/{a?}/{Id?}")]
        //[HttpGet("pv/{a?}/{MasterId?}/{Id?}")]


        //public IActionResult Test(string a, string MasterId, string Id)
        //{
        //    var dict = ControllerContext.ActionDescriptor.;
        //    return Ok(ControllerContext.ActionDescriptor.AttributeRouteInfo.Template);
        //    return Ok(dict);

        //}


        //  [HttpGet]

        ////  [Route("{title?}/{level?}/{price?}")]
        //  public async Task<IActionResult> GetCourses([FromQuery] PagingDetails paging, string sortOrder,  string title,  string level, decimal? price, DateTime? startDate, DateTime? endDate)
        //  {

        //      var courses = await _uow.Courses.FindAllAsync(paging);

        //      switch (sortOrder)
        //      {
        //          case "Title_desc":

        //              courses = courses.OrderByDescending(x => x.Title).ThenByDescending(x => x.StartDate);
        //              break;
        //          case "Title_asc":
        //              courses = courses.OrderBy(x => x.Title).ThenByDescending(x => x.StartDate);
        //              break;
        //          case "FulPrice_desc":
        //              courses = courses.OrderByDescending(x => x.FullPrice).ThenByDescending(x => x.StartDate);
        //              break;
        //          case "FulPrice_asc":
        //              courses = courses.OrderBy(x => x.Title).ThenByDescending(x => x.StartDate);
        //              break;
        //          case "Level_desc":
        //              courses = courses.OrderByDescending(x => x.Level).ThenByDescending(x => x.StartDate);
        //              break;

        //          case "Level_asc":
        //              courses = courses.OrderBy(x => x.Level).ThenByDescending(x => x.StartDate);
        //              break;

        //          case "StartDate_asc":
        //              courses = courses.OrderBy(x => x.StartDate).ThenByDescending(x => x.Title);
        //              break;

        //          default:
        //              courses = courses.OrderByDescending(x => x.StartDate).ThenByDescending(x => x.Title);
        //              break;
        //      }

        //      var result = PagedList<Course>.ToPagedList(courses, paging.PageNumber, paging.PageSize);
        //      Utility.Result(result, Response);
        //      return Ok(_mapper.Map<IList<CourseGetDto>>(result));
        //  }





        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id )
        {

            var courseItem = await _uow.Courses.GetAsync(x => x.Id == id, new List<string>() { "Students" ,"Sessions", "Teacher" });
            if (courseItem != null)
            {
                return Ok(_mapper.Map<CourseGetDto>(courseItem));

            }


            _logger.LogError("Something Went Wrong Try Later.");
            return NotFound();


        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CourseAddDto courseAddDto)
        {
            var courseItem = _mapper.Map<Course>(courseAddDto);
            await _uow.Courses.AddAsync(courseItem);
            await _uow.Save();
            return Ok("Success");

        }
        [HttpPost("AddMultiCourse")]
        public async Task<IActionResult> CreateCourses(IEnumerable<CourseAddDto> courseAddDto)
        {
            var courseItems = _mapper.Map<IList<Course>>(courseAddDto);         
            await _uow.Courses.AddRangeASync(courseItems);
            await _uow.Save();
            return Ok("Success");

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CourseUpdateDto courseUpdateDto)
        {
            var courseItem = await _uow.Courses.GetAsync(x => x.Id == id);
            if (courseItem == null)
            {
                return NotFound("it's not found in the database");
            }
            _mapper.Map(courseUpdateDto, courseItem);
            _uow.Courses.Update(courseItem);
            await _uow.Save();
            return Ok("Success");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var courseItem = await _uow.Courses.GetByIdAsync(id);
            if (courseItem == null)
            {
                return NotFound("it's not found in the database");
            }
            await _uow.Courses.Delete(id);
            await _uow.Save();
            _logger.LogInformation("someone deleted a Course");
            return NoContent();

        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCoursesCount()
        {

            var coursesCount = await _uow.Courses.CountAsync();
            return Ok(coursesCount);
        }

        [HttpPost("Teachers/{Teacherid}")]
        public async Task<IActionResult> AddTeacherToCourseAsync([FromQuery] int? id , CourseAddDto courseDto, int Teacherid)
        {
            var teacher = await _uow.Teachers.GetByIdAsync(Teacherid);
            if (id == null)
            {
                var course = _mapper.Map<Course>(courseDto);
                course.TeacherId = teacher.Id;
                await _uow.Courses.AddAsync(course);
                await _uow.Save();
                return Ok("Success");
            }
            var courseItem = await _uow.Courses.GetByIdAsync((int)id);
            if (courseItem == null)
            {
                return NotFound("it's not found in the database");
            }
            courseItem.TeacherId = teacher.Id;
            _mapper.Map(courseDto, courseItem);
            _uow.Courses.Update(courseItem);
            await _uow.Save();
            return Ok("Success");
       
        }
        
        [HttpPost("Students/{studentId}")]
        public async Task<IActionResult> AddStudentToCourseAsync([FromQuery] int? id , CourseAddDto courseDto, int studentId)
        {
            var student = await _uow.Students.GetByIdAsync(studentId);
            if (id == null) 
                {
                var course = _mapper.Map<Course>(courseDto);
                course.Students = new List<Student>();
                course.Students.Add(student);
                await _uow.Courses.AddAsync(course);
                await _uow.Save();
                return Ok("Success");
            }
            var courseItem =await _uow.Courses.GetByIdAsync((int)id);
            if (courseItem == null)
            {
                return NotFound("it's not found in the database");
            }
            courseItem.Students = new List<Student>();
            courseItem.Students.Add(student);
            _mapper.Map(courseDto, courseItem);
            _uow.Courses.Update(courseItem);
            await _uow.Save();
            return Ok("Success");

        }
        [HttpPost("Sessions/{sessionId}")]
        public async Task<IActionResult> AddSessionToCourseAsync([FromQuery] int? id, CourseAddDto courseDto, int sessionId)
        {
            var session = await _uow.Sessions.GetByIdAsync(sessionId);
            if (id == null)
            {
                var course = _mapper.Map<Course>(courseDto);
                course.Sessions = new List<Session>();
                course.Sessions.Add(session);
                await _uow.Courses.AddAsync(course);
                await _uow.Save();
                return Ok("Success");
            }
            var courseItem = await _uow.Courses.GetByIdAsync((int)id);
            if (courseItem == null)
            {
                return NotFound("it's not found in the database");
            }
            courseItem.Sessions = new List<Session>();
            courseItem.Sessions.Add(session);
            _mapper.Map(courseDto, courseItem);
            _uow.Courses.Update(courseItem);
            await _uow.Save();
            return Ok("Success");

        }


        [HttpPost("{id}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteEntityfromCoursess(int id,[FromQuery] int? studentId ,  [FromQuery] int? teacherId)
        {
              var courseItem = await _uow.Courses.GetAsync(x=>x.Id==id , new List<string>{ "Students" ,"Sessions"});
            if (courseItem == null)
            {
                return NotFound("it's not found in the database");
            }
            if (studentId != null)
            {
                var courseStudent = courseItem.Students.First(x => x.Id == studentId);
                if (courseStudent == null)
                {
                    return NotFound("it's not found in the database");

                }
                courseItem.Students.Remove(courseStudent);
            }
            
            if (teacherId != null)
            {
                courseItem.TeacherId = null;

            }

            await _uow.Save();
            return Ok("Success");


        }
      
    }
}
