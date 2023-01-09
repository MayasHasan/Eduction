using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Dtos
{
    public class SessionUpdateDto
    {
        public string SessionTitle { get; set; }
        public string Description { get; set; }
        public int? CourseId { get; set; }

        public DateTime? Date { get; set; }
    }
}
