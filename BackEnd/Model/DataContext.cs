using Microsoft.EntityFrameworkCore;
using backend.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace tuutoriplatvorm.Model
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Tutor>? TutorList { get; set; }
        public DbSet<Student>? StudentList { get; set; }
        public DbSet<Schedule>? ScheduleList { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tutor>()
                        .Property(tutor => tutor.Subjects)
                        .HasConversion(
                            subjectList => string.Join(',', subjectList.Select(s => (int)s)),
                            subjectsString => subjectsString.Split(
                                ',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(s => (Subject)s).ToList()
                        );
            builder.Entity<Schedule>()
                        .Property(schedule => schedule.Subjects)
                        .HasConversion(
                            schedulesList => string.Join(',', schedulesList.Select(s => (int)s)),
                            scheduleString => scheduleString.Split(
                                ',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(s => (Subject)s).ToList()
            );

            builder.Entity<Tutor>()
                        .HasMany(e => e.Schedules)
                        .WithOne(e => e.Tutor)
                        .HasForeignKey(e => e.TutorId
                        )
                        .IsRequired();


            var tutor1 = new Tutor
            {
                Id = 1,
                Name = "Levi Faster",
                Town = Town.Tallinn,
                University = University.TallinnUniversity,
                Speciality = Speciality.CyberSecurity,
                Mail = "mailKevin@gmail.com",
                Subjects = new List<Subject> { Subject.Maths, Subject.PE },
                HourlyPrice = 10,
                AverageRate = 5,
                RateCount = 1,
                PhotoUrlId="101"

            };

            builder.Entity<Tutor>().HasData(

                tutor1,

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
                    RateCount = null,
                    PhotoUrlId="102"
                }
            );

            builder.Entity<Schedule>().HasData(
                new Schedule
                {
                    Id = 1,
                    TutorId = 1,
                    Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.Maths },
                    HourlyPrice = tutor1.HourlyPrice,
                    StartTime = DateTime.UtcNow.AddDays(1),
                    EndTime = DateTime.UtcNow.AddDays(1).AddHours(1),

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