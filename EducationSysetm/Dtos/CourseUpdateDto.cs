using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Dtos
{
    public class CourseUpdateDto
    {
        public string Title { get; set; }
        public decimal FullPrice { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CourseLevel Level { get; set; }

    }
}
