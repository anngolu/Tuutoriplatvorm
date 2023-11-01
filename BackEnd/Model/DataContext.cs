using Microsoft.EntityFrameworkCore;

namespace tuutoriplatvorm.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Tutors>? TutorList { get; set; }
        public DbSet<Students>? StudentList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Tutors>().HasData(
                new Tutors
                {
                    Id = 1,
                    Name = "Levi Baster",
                    Town = "Tallinn",
                    University = "TartuUniversity",
                    Speciality = "CyberSecurity",
                    Mail = "mail@gmail.com",
                    Subject = "DiscMaths",
                    AverageRate = 5,
                    RateCount = 1
                    //Id = 1,
                    // Name = "Levi Faster",
                    // Town = Town.Tallinn,
                    // University = University.TallinnUniversity,
                    // Speciality = Speciality.CyberSecurity,
                    // Mail = "mail@gmail.com",
                    // Subject = Subject.DiscMaths,
                },


                new Tutors
                {
                    Id = 2,
                    Name = "Kevin Costner",
                    Town = "Tallinn",
                    University = "TallinnUniversity",
                    Speciality = "Law",
                    Mail = "mailKevin@gmail.com",
                    Subject = "Anti-trust legistlation",
                    AverageRate = 5,
                    RateCount = 1
                    //Id = 1,
                    // Name = "Levi Faster",
                    // Town = Town.Tallinn,
                    // University = University.TallinnUniversity,
                    // Speciality = Speciality.CyberSecurity,
                    // Mail = "mailKevin@gmail.com",
                    // Subject = Subject.DiscMaths,
                }
            );
            builder.Entity<Students>().HasData(
                new Students
                {
                     Id = 1,
                    // StName = "Alar Kaitse",
                    // StTown = StTown.Tallinn,
                    // StUniversity = StUniversity.TallinnUniversity,
                    // StSpeciality = StSpeciality.CyberSecurity,
                    // StMail = "mail1@gmail.com",
                    // StSubject = StSubject.Maths,
                    //Id = 1,
                    StName = "Alar Kaitse",
                    StTown = "Tallinn",
                    StUniversity = "TallinnUniversity",
                    StSpeciality = "CyberSecurity",
                    StMail = "mail1@gmail.com",
                    StSubject = "Maths",
                }
            );
        }
    }
}