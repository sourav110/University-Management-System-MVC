using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<AssignCourse> AssignCourses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AllocatedClassroom> AllocatedClassroms { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<EnrollCourse> EnrollCourses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}