using Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.FluentApIConfig
{
    public class TeacherConfiguration
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(t =>t.FirstName)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(t => t.LastName)
                  .IsRequired()
                  .HasMaxLength(20);
            builder.Property(t => t.Salary)
                .IsRequired()
                .HasMaxLength(20);

         

        }
    }
}
