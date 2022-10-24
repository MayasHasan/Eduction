using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.FluentApIConfig
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.Property(c => c.Title)
                   .IsRequired()
                   .HasMaxLength(20);
           
            builder.Property(c => c.Description)
                   .IsRequired()
                   .HasMaxLength(2500);
            builder.Property(c=>c.FullPrice)
                      .IsRequired()
                      .HasMaxLength(20);

        }
    }
}

