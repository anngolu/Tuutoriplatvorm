using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace tuutoriplatvorm.Model
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Tutors>? TutorList {get;set;}
        public DbSet<Students>? StudentList {get;set;}
         protected override void OnModelCreating(ModelBuilder builder)
         {
                base.OnModelCreating(builder);
                builder.Entity<Tutors>().HasData(
                    new Tutors
                    {
                        Name="Levi Faster",
                        Town= Town.Tallinn,
                        University= University.TallinnUniversity,
                        Speciality= Speciality.CyberSecurity,
                        Mail="mail@gmail.com",
                        Subject= Subject.DiscMaths,
                    },
                    builder.Entity<Students>().HasData(
                        new Students{
                        Name="Alar Kaitse",
                        Town= Town.Tallinn,
                        University= University.TallinnUniversity,
                        Speciality= Speciality.CyberSecurity,
                        Mail="mail1@gmail.com",
                        Subject = Subject.Maths,
                        }

                    )
                );
         }
    }
}