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
    public class TeacherController : ControllerBase
    {
            private IUnitOfWork _uow;
            private ILogger<TeacherController> _logger;
            private IMapper _mapper;

            public TeacherController(IUnitOfWork uow, ILogger<TeacherController> logger, IMapper mapper)
            {
                _uow = uow;
                _logger = logger;
                _mapper = mapper;
            }
            [HttpGet]
            public async Task<IActionResult> GetTeachers([FromQuery] PagingDetails paging, string sortOrder, string searchString)
            {

                if (!String.IsNullOrEmpty(searchString))
                {

                    var teachers = await _uow.Teachers.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));

                    switch (sortOrder)
                    {
                        case "FirstName_desc":
                        teachers = await _uow.Teachers.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString),
                                                          y => y.OrderByDescending(x => x.FirstName));
                            break;
                        case "FirstName_asc":
                        teachers = await _uow.Teachers.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString),
                                                      y => y.OrderBy(x => x.FirstName));
                            break;
                        case "Salary_desc":
                        teachers = await _uow.Teachers.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString),
                                                     y => y.OrderByDescending(x => x.Salary));
                            break;
                        case "Salary_asc":
                        teachers = await _uow.Teachers.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString),
                                                     y => y.OrderBy(x => x.Salary));
                            break;

                        default:
                        teachers = await _uow.Teachers.GetAllAsync(paging, x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString));

                            break;
                    }
                    Utility.Result(teachers, Response);
                    return Ok(_mapper.Map<IList<TeacherGetDto>>(teachers));

                }
                var result = await _uow.Teachers.GetAllAsync(paging);
                Utility.Result(result, Response);
                return Ok(_mapper.Map<IList<TeacherGetDto>>(result));

            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetTeacherById(int id)
            {

                var TeacherItem = await _uow.Teachers.GetAsync(x => x.Id == id, new List<string>() { "Teacher" });
                if (TeacherItem != null)
                {
                    return Ok(_mapper.Map<TeacherGetDto>(TeacherItem));

                }
                _logger.LogError("Something Went Wrong Try Later.");
                return NotFound();


            }

            [HttpPost]
            public async Task<IActionResult> CreateTeacher(TeacherAddDto  teacherAddDto)
            {
                var TeacherItem = _mapper.Map<Teacher>(teacherAddDto);
                await _uow.Teachers.AddAsync(TeacherItem);
                await _uow.Save();
                return Ok("Success");

            }
        [HttpPost("AddMultiTeacher")]
        public async Task<IActionResult> CreateTeachers(IEnumerable<TeacherAddDto> teacherAddDto)
        {
            var TeacherItems = _mapper.Map<IList<Teacher>>(teacherAddDto);

            await _uow.Teachers.AddRangeASync(TeacherItems);
            await _uow.Save();
            return Ok("Success");

        }
        [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTeacher(int id, TeacherUpdateDto teacherUpdateDto)
            {
                var TeacherItem = await _uow.Teachers.GetAsync(x => x.Id == id);
                if (TeacherItem == null)
                {
                    return NotFound("it's not found in the database");
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
