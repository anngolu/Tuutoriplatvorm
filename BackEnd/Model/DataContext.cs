using Microsoft.EntityFrameworkCore;

namespace tuutoriplatvorm.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Tutor>? TutorList { get; set; }
        public DbSet<Student>? StudentList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tutor>().Property(p => p.Id).HasIdentityOptions(startValue: 3);
            builder.Entity<Student>().Property(p => p.Id).HasIdentityOptions(startValue: 2);

            builder.Entity<Tutor>().HasData(
                new Tutor
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
                },


                new Tutor
                {
                    Id = 2,
                    Name = "Kevin Costner",
                    Town = "Tallinn",
                    University = "TallinnUniversity",
                    Speciality = "Law",
                    Mail = "mailKevin@gmail.com",
                    Subject = "Anti-trust legistlation",
                    AverageRate = null,
                    RateCount = null
                    //Id = 1,
                    // Name = "Levi Faster",
                    // Town = Town.Tallinn,
                    // University = University.TallinnUniversity,
                    // Speciality = Speciality.CyberSecurity,
                    // Mail = "mailKevin@gmail.com",
                    // Subject = Subject.DiscMaths,
                }
            );
            builder.Entity<Student>().HasData(
                new Student
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