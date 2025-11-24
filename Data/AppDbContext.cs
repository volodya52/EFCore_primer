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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-5RGECJ1;Database=SchoolDBPluhin;User Id=v;Password=123;TrustServerCertificate=True;");
        }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>( )
                .HasOne(s => s.Passport)
                .WithOne(ps => ps.Student)
                .HasForeignKey<Passport>(ps => ps.StudentId);
            modelBuilder.Entity<Group>( )
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);
        }
    }
}
