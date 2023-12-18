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
                        .HasForeignKey(e => e.TutorId)
                        .IsRequired();

            builder.Entity<StudentRateTutor>()
            .ToTable("StudentRateTutor")
            .HasKey(key => new { key.StudentId, key.TutorId });

            var tutor1 = new Tutor
            {
                Id = 1,
                Name = "Tevi Faster_1",
                Town = Town.Tallinn,
                University = University.TallinnUniversity,
                Speciality = Speciality.CyberSecurity,
                Mail = "mailKevin@gmail.com",
                Subjects = new List<Subject> { Subject.Maths, Subject.PE },
                HourlyPrice = 10,
                AverageRate = 3,
                RateCount = 1,
                PhotoUrlId = "101"

            };

            builder.Entity<Tutor>().HasData(

                tutor1,

                new Tutor
                {
                    Id = 2,
                    Name = "Tavel Risto_2",
                    Town = Town.KohtlaJarve,
                    University = University.UniversityOfTartu,
                    Speciality = Speciality.Science,
                    Mail = "mailTaveln@gmail.com",
                    Subjects = new List<Subject> { Subject.Maths },
                    AverageRate = 4,
                    RateCount = 1,
                    PhotoUrlId = "102"
                }
            );

            builder.Entity<Schedule>().HasData(
                new Schedule
                {
                    Id = 1,
                    TutorId = 1,
                    StudentId=1,
                    //Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.Maths },
                    HourlyPrice = 11,
                    // HourlyPrice = tutor1.HourlyPrice,
                    StartTime = DateTime.UtcNow.AddDays(1),
                    EndTime = DateTime.UtcNow.AddDays(1).AddHours(1),

                },

                new Schedule
                {
                    Id = 2,
                    TutorId = 2,
                    StudentId=2,
             //     Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.Economics },
                    HourlyPrice = 12,
                    StartTime = DateTime.UtcNow.AddDays(1),
                    EndTime = DateTime.UtcNow.AddDays(1).AddHours(1),

                },

                new Schedule
                {
                    Id = 3,
                    TutorId = 1,
                    StudentId=2,
                  //  Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.PE },
                    HourlyPrice = 13,
                    StartTime = DateTime.UtcNow.AddDays(1),
                    EndTime = DateTime.UtcNow.AddDays(1).AddHours(1),

                },

                    new Schedule
                {
                    Id = 4,
                    TutorId = 1,
                    StudentId=null,
                  //  Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.PE },
                    HourlyPrice = 14,
                    StartTime = DateTime.UtcNow.AddDays(1),
                    EndTime = DateTime.UtcNow.AddDays(1).AddHours(1),

                },

                    new Schedule
                {
                    Id = 5,
                    TutorId = 1,
                    StudentId=null,
                  //  Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.Economics },
                    HourlyPrice = 15,
                    StartTime = DateTime.UtcNow.AddDays(1),
                    EndTime = DateTime.UtcNow.AddDays(1).AddHours(1),

                }
            );

            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    StName = "Siim Kaitse_1",
                    StTown = StTown.Tallinn,
                    StUniversity = StUniversity.TallinnUniversity,
                    StSpeciality = StSpeciality.CyberSecurity,
                    StMail = "mail1@gmail.com",
                    StSubject = StSubject.Maths,
                },
                new Student
                {
                    Id = 2,
                    StName = "Sander Ott_2",
                    StTown = StTown.Narva,
                    StUniversity = StUniversity.TartuHigherArtSchool,
                    StSpeciality = StSpeciality.Psycho,
                    StMail = "mail2@gmail.com",
                    StSubject = StSubject.Economics,
                }
            );

            builder.Entity<StudentRateTutor>().HasData(
            new StudentRateTutor() { TutorId = 1, StudentId = 1, Rate = 3 },
            new StudentRateTutor() { TutorId = 2, StudentId = 1, Rate = 4 }
            );

        }
    }
}