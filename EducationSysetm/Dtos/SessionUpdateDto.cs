using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Dtos
{
    public class SessionUpdateDto
    {
        public int Id { get; set; }
        public string SessionNumber { get; set; }
        public DateTime? Date { get; set; }
    }
}
