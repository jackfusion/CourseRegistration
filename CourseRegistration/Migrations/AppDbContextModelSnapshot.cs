﻿// <auto-generated />
using System;
using CourseRegistration.Data.SqlRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseRegistration.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("CourseRegistration.Models.Courses", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("C_Id");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            C_Id = 1,
                            Description = "Math",
                            Name = "Math",
                            Number = 1
                        },
                        new
                        {
                            C_Id = 2,
                            Description = "Teach Web Development",
                            Name = "Computers",
                            Number = 2
                        },
                        new
                        {
                            C_Id = 3,
                            Description = "Gym",
                            Name = "Gym",
                            Number = 3
                        });
                });

            modelBuilder.Entity("CourseRegistration.Models.Instructors", b =>
                {
                    b.Property<int>("I_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("C_Id")
                        .HasColumnType("int");

                    b.Property<int?>("CourseC_Id")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.HasKey("I_Id");

                    b.HasIndex("CourseC_Id");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            I_Id = 1,
                            C_Id = 1,
                            EmailAddress = "jacksmith@mail.com",
                            FirstName = "Jack",
                            LastName = "Smith"
                        },
                        new
                        {
                            I_Id = 2,
                            C_Id = 2,
                            EmailAddress = "luckhairy@mail.com",
                            FirstName = "Luck",
                            LastName = "Hairy"
                        },
                        new
                        {
                            I_Id = 3,
                            C_Id = 3,
                            EmailAddress = "darrickdark@mail.com",
                            FirstName = "Darrick",
                            LastName = "Dark"
                        });
                });

            modelBuilder.Entity("CourseRegistration.Models.Students", b =>
                {
                    b.Property<int>("S_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("C_Id")
                        .HasColumnType("longtext");

                    b.Property<int?>("CourseDtoC_Id")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("S_Id");

                    b.HasIndex("C_Id");

                    b.HasIndex("CourseDtoC_Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            S_Id = 1,
                            C_Id = "1",
                            EmailAddress = "jimblack@mail.com",
                            FirstName = "Jim",
                            LastName = "Black",
                            PhoneNumber = "2045553344"
                        },
                        new
                        {
                            S_Id = 2,
                            C_Id = "2",
                            EmailAddress = "jackwhite@mail.com",
                            FirstName = "Jack",
                            LastName = "White",
                            PhoneNumber = "2045552244"
                        },
                        new
                        {
                            S_Id = 3,
                            C_Id = "3",
                            EmailAddress = "georgegrey@mail.com",
                            FirstName = "George",
                            LastName = "Grey",
                            PhoneNumber = "2045553322"
                        },
                        new
                        {
                            S_Id = 4,
                            C_Id = "1",
                            EmailAddress = "jillfusion@mail.com",
                            FirstName = "Jill",
                            LastName = "Fusion",
                            PhoneNumber = "2045554444"
                        },
                        new
                        {
                            S_Id = 5,
                            C_Id = "1",
                            EmailAddress = "jamblur@mail.com",
                            FirstName = "Jam",
                            LastName = "blur",
                            PhoneNumber = "2045555544"
                        },
                        new
                        {
                            S_Id = 6,
                            C_Id = "3",
                            EmailAddress = "johnbutt@mail.com",
                            FirstName = "John",
                            LastName = "Butt",
                            PhoneNumber = "2045556644"
                        },
                        new
                        {
                            S_Id = 7,
                            C_Id = "2",
                            EmailAddress = "maryjo@mail.com",
                            FirstName = "Mary",
                            LastName = "Jo",
                            PhoneNumber = "2045557744"
                        });
                });

            modelBuilder.Entity("CourseRegistration.ModelsDto.CourseDto", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("C_Id");

                    b.ToTable("CourseDto");
                });

            modelBuilder.Entity("CourseRegistration.Models.Instructors", b =>
                {
                    b.HasOne("CourseRegistration.Models.Courses", "Course")
                        .WithMany()
                        .HasForeignKey("CourseC_Id");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("CourseRegistration.Models.Students", b =>
                {
                    b.HasOne("CourseRegistration.Models.Courses", "Courses")
                        .WithMany()
                        .HasForeignKey("C_Id");

                    b.HasOne("CourseRegistration.ModelsDto.CourseDto", "CourseDto")
                        .WithMany()
                        .HasForeignKey("CourseDtoC_Id");

                    b.Navigation("CourseDto");

                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
