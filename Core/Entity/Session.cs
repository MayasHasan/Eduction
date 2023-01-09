using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Session
    {

        public int Id { get; set; }
        public string SessionTitle { get; set; }
        public DateTime? Date { get; set; }
        public Course Course { get; set; }
        public int? CourseId { get; set; }
        public string Description { get; set; }
        public IList<Student> Students { get; set; }
        public IList<File> Files { get; set; } = null;


    }
}
