﻿// <auto-generated />
using System;
using Student_Information_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Student_Information_System.Migrations
{
    [DbContext(typeof(StudentsContext))]
    [Migration("20240922225347_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.Property<string>("DepartmentCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentCode", "LectureId");

                    b.HasIndex("LectureId");

                    b.ToTable("DepartmentLecture");

                    b.HasData(
                        new
                        {
                            DepartmentCode = "CS1234",
                            LectureId = 1
                        },
                        new
                        {
                            DepartmentCode = "CS1234",
                            LectureId = 3
                        },
                        new
                        {
                            DepartmentCode = "MTH567",
                            LectureId = 2
                        });
                });

            modelBuilder.Entity("Student_Information_System.Data.Entities.Department", b =>
                {
                    b.Property<string>("DepartmentCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentCode");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentCode = "CS1234",
                            DepartmentName = "ComputerScience"
                        },
                        new
                        {
                            DepartmentCode = "MTH567",
                            DepartmentName = "Mathematics"
                        });
                });

            modelBuilder.Entity("Student_Information_System.Data.Entities.Lecture", b =>
                {
                    b.Property<int?>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("LectureId"));

                    b.Property<string>("LectureDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LectureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeOnly>("LectureTimeFrom")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("LectureTimeTo")
                        .HasColumnType("time");

                    b.HasKey("LectureId");

                    b.HasIndex("LectureName")
                        .IsUnique();

                    b.ToTable("Lectures");

                    b.HasData(
                        new
                        {
                            LectureId = 1,
                            LectureName = "Algorithms",
                            LectureTimeFrom = new TimeOnly(10, 0, 0),
                            LectureTimeTo = new TimeOnly(11, 30, 0)
                        },
                        new
                        {
                            LectureId = 2,
                            LectureName = "Calculus",
                            LectureTimeFrom = new TimeOnly(12, 0, 0),
                            LectureTimeTo = new TimeOnly(13, 30, 0)
                        },
                        new
                        {
                            LectureId = 3,
                            LectureName = "DataStructures",
                            LectureTimeFrom = new TimeOnly(14, 0, 0),
                            LectureTimeTo = new TimeOnly(15, 30, 0)
                        });
                });

            modelBuilder.Entity("Student_Information_System.Data.Entities.Student", b =>
                {
                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentNumber");

                    b.HasIndex("DepartmentCode");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentNumber = 12345678,
                            DepartmentCode = "CS1234",
                            Email = "john.smith@example.com",
                            FirstName = "John",
                            LastName = "Smith"
                        },
                        new
                        {
                            StudentNumber = 87654321,
                            DepartmentCode = "MTH567",
                            Email = "alice.johnson@example.com",
                            FirstName = "Alice",
                            LastName = "Johnson"
                        });
                });

            modelBuilder.Entity("StudentLecture", b =>
                {
                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.HasKey("StudentNumber", "LectureId");

                    b.HasIndex("LectureId");

                    b.ToTable("StudentLecture");

                    b.HasData(
                        new
                        {
                            StudentNumber = 12345678,
                            LectureId = 1
                        },
                        new
                        {
                            StudentNumber = 12345678,
                            LectureId = 3
                        },
                        new
                        {
                            StudentNumber = 87654321,
                            LectureId = 2
                        });
                });

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.HasOne("Student_Information_System.Data.Entities.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student_Information_System.Data.Entities.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Student_Information_System.Data.Entities.Student", b =>
                {
                    b.HasOne("Student_Information_System.Data.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StudentLecture", b =>
                {
                    b.HasOne("Student_Information_System.Data.Entities.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Student_Information_System.Data.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Student_Information_System.Data.Entities.Department", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
