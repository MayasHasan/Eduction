using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSysetm.Dtos
{
    public class AddFileDto
    {
        public IList<IFormFile> FilePath { get; set; }
    }
}
