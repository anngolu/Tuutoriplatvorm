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
        // protected override void TutorsCreating(ModelBuilder builder)
        // {

         //}
    }
}