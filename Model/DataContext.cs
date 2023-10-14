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
                        Town=1,
                        University=2,
                        Speciality=2,
                        Mail="mail@gmail.com",
                        Subject=4,
                    }
                );
         }
    }
}