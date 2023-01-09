using Core.ModelForAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Teacher
    {
        public int Id { get; set; }
        public Guid AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Level { get; set; }
        public string Specialization { get; set; }
        public decimal Salary { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime? JoinedDate{ get; set; }
        public IList<Course> Courses { get; set; }
}
}
