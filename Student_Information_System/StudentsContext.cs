using Microsoft.EntityFrameworkCore;
using Savarankiskas_darbas_Nr._3.Database.Configuration;
using Student_Information_System.Data.Database.Entities;

namespace Student_Information_System
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() : base() { }
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }      //is esmes kiekviena si eilute reiskia nauja lentele
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=Student_Information_System;Trusted_Connection=True;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new LectureConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentNumber);
                entity.Property(s => s.StudentNumber).ValueGeneratedNever();
                entity.Property(s => s.FirstName).IsRequired(true);
                entity.Property(s => s.LastName).IsRequired(true);
                entity.Property(s => s.StudentEmail).IsRequired(true);
                entity.Property(s => s.DepartmentCode).IsRequired(true);
                entity.HasOne(s => s.Department)
                    .WithMany(d => d.Students)
                    .HasForeignKey(s => s.DepartmentCode);

                entity.HasData(
                    new Student("12345678", "John", "Smith", "john.smith@example.com", "CS1234"),
                    new Student("87654321", "Alice", "Johnson", "alice.johnson@example.com", "MTH567")
                );
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.HasKey(l => l.LectureId);
                entity.Property(l => l.LectureId).ValueGeneratedOnAdd();
                entity.HasIndex(l => l.LectureName).IsUnique();
                entity.Property(l => l.LectureName).IsRequired(true);

                entity.HasData(
                    new Lecture(1, "Algorithms", new TimeOnly(10, 00), new TimeOnly(11, 30), null),
                    new Lecture(2, "Calculus", new TimeOnly(12, 00), new TimeOnly(13, 30), null),
                    new Lecture(3, "DataStructures", new TimeOnly(14, 00), new TimeOnly(15, 30), null)
                );

                entity.HasMany(l => l.Departments)
                    .WithMany(d => d.Lectures)
                    .UsingEntity<Dictionary<string, object>>(
                        "DepartmentLecture",
                        j => j.HasOne<Department>().WithMany().HasForeignKey("DepartmentCode"),
                        j => j.HasOne<Lecture>().WithMany().HasForeignKey("LectureId"))
                    .HasData(
                        new { DepartmentCode = "CS1234", LectureId = 1 },
                        new { DepartmentCode = "CS1234", LectureId = 3 },
                        new { DepartmentCode = "MTH567", LectureId = 2 });
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.DepartmentCode);
                entity.Property(d => d.DepartmentCode).ValueGeneratedNever();
                entity.Property(d => d.DepartmentName).IsRequired(true);
                entity.HasMany(d => d.Lectures)
                    .WithMany(l => l.Departments)
                    .UsingEntity<Dictionary<string, object>>(
                        "DepartmentLecture",
                        j => j.HasOne<Lecture>().WithMany().HasForeignKey("LectureId"),
                        j => j.HasOne<Department>().WithMany().HasForeignKey("DepartmentCode"));

                entity.HasData(
                    new Department("CS1234", "ComputerScience"),
                    new Department("MTH567", "Mathematics")
                );
            });
        }
    }
}
