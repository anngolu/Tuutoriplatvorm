using Microsoft.EntityFrameworkCore;
using backend.Model;

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
            builder.Entity<Tutor>()
                        .Property(tutor => tutor.Subjects)
                        .HasConversion(
                            subjectList => string.Join(',', subjectList.Select(s => (int)s)),
                            subjectsString => subjectsString.Split(
                                ',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(s => (Subject) s).ToList()
                        );
            // builder.Entity<Tutor>().Property(p => p.Id).HasIdentityOptions(startValue: 3);
            // builder.Entity<Student>().Property(p => p.Id).HasIdentityOptions(startValue: 2);
            builder.Entity<Tutor>().HasData(
                 new Tutor
                 {
                     Id = 1,
                     Name = "Levi Faster",
                     Town = Town.Tallinn,
                     University = University.TallinnUniversity,
                     Speciality = Speciality.CyberSecurity,
                     Mail = "mailKevin@gmail.com",
                     Subjects = new List<Subject> { Subject.Maths, Subject.PE },
                     AverageRate = 5,
                     RateCount = 1
                 },

                new Tutor
                {
                    Id = 2,
                    Name = "Tavel Risto",
                    Town = Town.KohtlaJarve,
                    University = University.UniversityOfTartu,
                    Speciality = Speciality.Science,
                    Mail = "mailTaveln@gmail.com",
                    Subjects = new List<Subject> { Subject.Maths },
                    AverageRate = null,
                    RateCount = null
                }
            );
            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    StName = "Alar Kaitse",
                    StTown = StTown.Tallinn,
                    StUniversity = StUniversity.TallinnUniversity,
                    StSpeciality = StSpeciality.CyberSecurity,
                    StMail = "mail1@gmail.com",
                    StSubject = StSubject.Maths,
                }
            );
        }
    }
}