using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CoursesStudents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=SchoolDBPluhin;User Id=student_05;Password=student_05;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>( )
                .HasOne(s => s.Passport)
                .WithOne(ps => ps.Student)
                .HasForeignKey<Passport>(ps => ps.StudentId);

            modelBuilder.Entity<Group>( )
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<CourseStudent>()
                 .HasKey(cs => new { cs.StudentId, cs.CourseId });

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs=>cs.Student)
                .WithMany(s=>s.CourseStudents)
                .HasForeignKey(cs=>cs.StudentId);

            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs=>cs.Course)
                .WithMany(c=>c.CourseStudents)
                .HasForeignKey(cs=>cs.CourseId);
                
        }
    }
}
