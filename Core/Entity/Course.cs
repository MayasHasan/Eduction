using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal FullPrice { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Level { get; set; }
        public Teacher Teacher { get; set; }
        public int? TeacherId { get; set; }
        public IList<Student> Students { get; set; }
        public IList<Session> Sessions { get; set; }
        public IList<File> Files { get; set; } = null;


    }

}
