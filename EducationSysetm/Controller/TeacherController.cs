using AutoMapper;
using Core.Entity;
using Core.IRepository;
using Core.ModelForAuth;
using Core.Paging;
using EducationSysetm.Dtos;
using EducationSysetm.Others;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class TeacherController : ControllerBase
    {
        private IUnitOfWork _uow;
        private ILogger<TeacherController> _logger;
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TeacherController(IUnitOfWork uow, ILogger<TeacherController> logger, IMapper mapper ,UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            _uow = uow;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetTeachers([FromQuery] PagingDetails paging, string sortOrder, string searchString,string level , decimal? salary, DateTime? joinedDateFrom, DateTime? joinedDateTo)
        {
            var teacher = await _uow.Teachers.FindAllAsync(paging);
            if (!String.IsNullOrEmpty(searchString))
            {
                teacher = teacher.Where(x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));
            }
            if (salary != null && salary != 0)
            {
                teacher = teacher.Where(x => x.Salary == salary);
            }
            if (!String.IsNullOrEmpty(level))
            {
                teacher = teacher.Where(x => x.Level == level);
            }
            if (joinedDateFrom.HasValue && !joinedDateTo.HasValue)
            {
                teacher = teacher.Where(x => x.JoinedDate == joinedDateFrom);
            }

            if (joinedDateFrom.HasValue && joinedDateTo.HasValue)
            {
                teacher = teacher.Where(x => x.JoinedDate >= joinedDateFrom && x.JoinedDate <= joinedDateTo);
            }
            switch (sortOrder)
            {
                case "FirstName_desc":

                    teacher = teacher.OrderByDescending(x => x.FirstName).ThenByDescending(x=>x.Level).ThenByDescending(x => x.JoinedDate);
                    break;
                case "FirstName_asc":
                    teacher = teacher.OrderBy(x => x.FirstName).ThenByDescending(x => x.Level).ThenByDescending(x => x.JoinedDate);
                    break;
                case "Salary_desc":
                    teacher = teacher.OrderByDescending(x => x.Salary).ThenByDescending(x => x.Level).ThenByDescending(x => x.JoinedDate);
                    break;
                case "Salary_asc":
                    teacher = teacher.OrderBy(x => x.Salary).ThenByDescending(x => x.Level).ThenByDescending(x => x.JoinedDate);
                    break;

                case "JoinedDate_asc":
                    teacher = teacher.OrderBy(x => x.JoinedDate).ThenBy(x => x.FirstName).ThenByDescending(x => x.Level);
                    break;

                default:
                    teacher = teacher.OrderByDescending(x => x.JoinedDate).ThenBy(x => x.FirstName).ThenByDescending(x => x.Level);
                    break;
            }

            var result = PagedList<Teacher>.ToPagedList(teacher, paging.PageNumber, paging.PageSize);
            Utility.Result(result, Response);
            return Ok(_mapper.Map<IList<TeacherGetDto>>(result));

        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {

            var TeacherItem = await _uow.Teachers.GetAsync(x => x.Id == id, new List<string>() { "Courses" });
            if (TeacherItem != null)
            {
                return Ok(_mapper.Map<TeacherGetDto>(TeacherItem));

            }
            _logger.LogError("Something Went Wrong Try Later.");
            return NotFound();


        }

        [HttpPost("addCourse")]
        public async Task<IActionResult> CreateTeacher(TeacherAddDto teacherAddDto, int? id)
        {
            if (id != null)
            {
                Course course = await _uow.Courses.GetAsync(x => x.Id == id);
                if (course != null)
                {
                    teacherAddDto.Courses = new List<Course>();
                    teacherAddDto.Courses.Add(course);
                    var TeacherItem = _mapper.Map<Teacher>(teacherAddDto);
                  
                    
                    await _uow.Save();
                    return Ok("Success");
                }
                return NotFound("course");
            }
            else
            {
                var TeacherItem = _mapper.Map<Teacher>(teacherAddDto);
                await _uow.Teachers.AddAsync(TeacherItem);
                var newTeacher = await _uow.Teachers.AddAsync(TeacherItem);
                Guid guid = Guid.NewGuid();
                var result = await _userManager.CreateAsync(new ApplicationUser { Id = guid.ToString(),FirstName= newTeacher.FirstName, LastName=newTeacher.LastName, UserName = newTeacher.Email, Email = newTeacher.Email }, teacherAddDto.Password);
                if (result.Succeeded)
                {
                    newTeacher.AppUserId = guid;
                    var user = await _userManager.FindByIdAsync(guid.ToString());
                    await _userManager.AddToRoleAsync(user, "USER");
                }
                else
                {
                    return BadRequest();
                }
                await _uow.Save();
                return Ok("Success");
            }

        }
        [HttpPost("AddMultiTeacher")]
        public async Task<IActionResult> CreateTeachers(IEnumerable<TeacherAddDto> teacherAddDto)
        {
            var TeacherItems = _mapper.Map<IList<Teacher>>(teacherAddDto);

            await _uow.Teachers.AddRangeASync(TeacherItems);
            await _uow.Save();
            return Ok("Success");

        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateTeacher(int id, TeacherUpdateDto teacherUpdateDto, [FromQuery] List<int> ids)
        //{
        //    var TeacherItem = await _uow.Teachers.GetAsync(x => x.Id == id, new List<string>() { "Courses" });
        //    if (TeacherItem == null)
        //    {
        //        return NotFound("it's not found in the database");
        //    }

        //    if (ids != null && ids.Count !=0)
        //    {
        //        teacherUpdateDto.Courses = new List<Course>();

        //        for (int i = 0; i < ids.Count; ++i)
        //        {
        //            Course course = await _uow.Courses.GetAsync(x => x.Id == ids[i]);

        //            teacherUpdateDto.Courses.Add(course);
        //        }
        //    }

        //    _mapper.Map(teacherUpdateDto, TeacherItem);
        //    _uow.Teachers.Update(TeacherItem);
        //    await _uow.Save();
        //    return Ok("Success");

        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeacherUpdateDto teacherUpdateDto, [FromQuery] List<int> ids)
        {
            var TeacherItem = await _uow.Teachers.GetAsync(x => x.Id == id, new List<string>() { "Courses" });
            if (TeacherItem == null)
            {
                return NotFound("it's not found in the database");
            }

                teacherUpdateDto.Courses = new List<Course>();
                for (int i = 0; i < ids.Count; ++i)
                {
                    Course course = await _uow.Courses.GetAsync(x => x.Id == ids[i]);

                    teacherUpdateDto.Courses.Add(course);
                }
     
            _mapper.Map(teacherUpdateDto, TeacherItem);
            _uow.Teachers.Update(TeacherItem);
            await _uow.Save();
            return Ok("Success");

        }









        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var TeacherItem = await _uow.Teachers.GetByIdAsync(id);
            if (TeacherItem == null)
            {
                return NotFound("it's not found in the database");
            }
            await _uow.Teachers.Delete(id);
            await _uow.Save();
            _logger.LogInformation("someone deleted a Course");
            return NoContent();

        }

        [HttpGet("count")]
        public async Task<IActionResult> GetTeacherCount()
        {
            var TeacherCount = await _uow.Teachers.CountAsync();
            return Ok(TeacherCount);
        }
    }
}
