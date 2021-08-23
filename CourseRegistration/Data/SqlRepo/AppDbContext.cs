using CourseRegistration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRegistration.Data.SqlRepo
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        { }
        public DbSet<Students> Students { get; set; }
        public DbSet<Instructors> Instructors { get; set; }
        public DbSet<Courses> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Students>().HasData(
                new Students { S_Id = 00001, FirstName = "Jim", LastName = "Black", EmailAddress = "jimblack@mail.com", PhoneNumber = "2045553344", C_Id = 001 },
                new Students { S_Id = 00002, FirstName = "Jack", LastName = "White", EmailAddress = "jackwhite@mail.com", PhoneNumber = "2045552244", C_Id = 002 },
                new Students { S_Id = 00003, FirstName = "George", LastName = "Grey", EmailAddress = "georgegrey@mail.com", PhoneNumber = "2045553322", C_Id = 003 },
                new Students { S_Id = 00004, FirstName = "Jill", LastName = "Fusion", EmailAddress = "jillfusion@mail.com", PhoneNumber = "2045554444", C_Id = 001 },
                new Students { S_Id = 00005, FirstName = "Jam", LastName = "blur", EmailAddress = "jamblur@mail.com", PhoneNumber = "2045555544", C_Id = 001 },
                new Students { S_Id = 00006, FirstName = "John", LastName = "Butt", EmailAddress = "johnbutt@mail.com", PhoneNumber = "2045556644", C_Id = 003 },
                new Students { S_Id = 00007, FirstName = "Mary", LastName = "Jo", EmailAddress = "maryjo@mail.com", PhoneNumber = "2045557744", C_Id = 002 }
                );
            modelBuilder.Entity<Instructors>().HasData(
                new Instructors { I_Id = 001, FirstName = "Jack", LastName = "Smith", EmailAddress = "jacksmith@mail.com", C_Id = 001 },
                new Instructors { I_Id = 002, FirstName = "Luck", LastName = "Hairy", EmailAddress = "luckhairy@mail.com", C_Id = 002 },
                new Instructors { I_Id = 003, FirstName = "Darrick", LastName = "Dark", EmailAddress = "darrickdark@mail.com", C_Id = 003 }
                );
            modelBuilder.Entity<Courses>().HasData(
                new Courses { C_Id = 001, Number = 1, Name = "Math", Description = "Math" },
                new Courses { C_Id = 002, Number = 2, Name = "Computers", Description = "Teach Web Development" },
                new Courses { C_Id = 003, Number = 3, Name = "Gym", Description = "Gym" }
                );
        }
    }
}
