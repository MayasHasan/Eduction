using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Dtos
{
    public class CourseGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal FullPrice { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CourseLevel Level { get; set; }
        public Teacher Teacher { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Session> Sessions { get; set; }

    }
}
