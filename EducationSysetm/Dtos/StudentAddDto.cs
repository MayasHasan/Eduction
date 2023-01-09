﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Dtos
{
    public class StudentAddDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Level { get; set; }
        public string Address { get; set; }
        public DateTime? JoinedDate { get; set; }
    }
}
