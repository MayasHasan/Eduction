using AutoMapper;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CourseAddDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseGetDto>();
            CreateMap<StudentAddDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentGetDto>();
            CreateMap<SessionAddDto, Session>();
            CreateMap<SessionUpdateDto, Session>();
            CreateMap<Session, SessionGetDto>();
            CreateMap<TeacherAddDto, Teacher>();
            CreateMap<TeacherUpdateDto, Teacher>();
            CreateMap<Teacher, TeacherGetDto>();
            CreateMap<File, AddFileDto>();
            CreateMap<AddFileDto, File>();
        }
    }
}
