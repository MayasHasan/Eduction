﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Level { get; set; }
        public string Address { get; set; }
        public DateTime? JoinedDate { get; set; }
        public IList<Session> Sessions { get; set; }
        public IList<Course> Courses { get; set; }
    } 
}
