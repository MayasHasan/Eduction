using Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.FluentApIConfig
{
    public class SessionConfiguration
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {


            builder.Property(s => s.SessionTitle)
                   .IsRequired()
                   .HasMaxLength(20);

        }
    }
}
