using Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.FluentApIConfig
{
    public class StudentConfiguration
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            

       



            builder.Property(s => s.FirstName)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(s => s.LastName)
                  .IsRequired()
                  .HasMaxLength(20);
         
        }
    }
}
