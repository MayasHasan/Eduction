using Core.Entity;
using Core.ModelForAuth;
using DataAccessEF.FluentApIConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CourseConfiguration().Configure(modelBuilder.Entity<Course>());
            new SessionConfiguration().Configure(modelBuilder.Entity<Session>());
            new StudentConfiguration().Configure(modelBuilder.Entity<Student>());
            new TeacherConfiguration().Configure(modelBuilder.Entity<Teacher>());
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

        }
    }
}