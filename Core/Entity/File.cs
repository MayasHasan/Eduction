﻿using Core.ModelForAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime InsertOn { get; set; }
        public ApplicationUser User { get; set; }
    }
}
