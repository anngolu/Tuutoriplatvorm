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
                Name = "Tevi Faster",
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
                    Name = "Tavel Risto",
                    Town = Town.KohtlaJarve,
                    University = University.UniversityOfTartu,
                    Speciality = Speciality.Science,
                    Mail = "mailTaveln@gmail.com",
                    Subjects = new List<Subject> { Subject.Maths },
                    HourlyPrice=15,
                    AverageRate = 4,
                    RateCount = 1,
                    PhotoUrlId = "102"
                },

                          new Tutor
                {
                    Id = 3,
                    Name = "Daaniel Tamm",
                    Town = Town.Tartu,
                    University = University.UniversityOfTartu,
                    Speciality = Speciality.Economics,
                    Mail = "mailTaveln@gmail.com",
                    Subjects = new List<Subject> { Subject.Maths, Subject.Programming },
                    HourlyPrice=17,
                    AverageRate = 1,
                    RateCount = 1,
                    PhotoUrlId = "103"
                }
            );

            builder.Entity<Schedule>().HasData(

                //UTC aeg kuu võrra erinev?
                //Täistudnidel - kuvab mintite puhul ainult ühe nulli
                new Schedule
                {
                    Id = 1,
                    TutorId = 1,
                    StudentId=1,
                    //Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.Maths },
                    HourlyPrice = 11,
                    // HourlyPrice = tutor1.HourlyPrice,
                    StartTime = new DateTime(2023, 12, 20, 09, 30, 0, DateTimeKind.Utc), // DateTime.UtcNow.AddDays(1),
                    EndTime = new DateTime(2023, 12, 20, 09, 30, 0, DateTimeKind.Utc).AddHours(1), //DateTime.UtcNow.AddDays(1).AddHours(1),

                },

                new Schedule
                {
                    Id = 2,
                    TutorId = 2,
                    StudentId=2,
             //     Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.Economics },
                    HourlyPrice = 12,
                    StartTime = new DateTime(2024, 02, 10, 10, 30, 0, DateTimeKind.Utc), 
                    EndTime =  new DateTime(2024, 02, 10, 10, 30, 0, DateTimeKind.Utc).AddHours(1),

                },

                new Schedule
                {
                    Id = 3,
                    TutorId = 1,
                    StudentId=2,
                  //  Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.PE },
                    HourlyPrice = 13,
                    StartTime = new DateTime(2023, 12, 20, 15, 00, 0, DateTimeKind.Utc), 
                    EndTime = new DateTime(2023, 12, 20, 15, 00, 0, DateTimeKind.Utc).AddHours(1),

                },

                    new Schedule
                {
                    Id = 4,
                    TutorId = 1,
                    StudentId=null,
                  //  Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.PE },
                    HourlyPrice = 14,
                    StartTime =  new DateTime(2024, 02, 20, 18, 00, 0, DateTimeKind.Utc), 
                    EndTime = new DateTime(2024, 02, 20, 18, 00, 0, DateTimeKind.Utc).AddHours(1),

                },

                    new Schedule
                {
                    Id = 5,
                    TutorId = 1,
                    StudentId=null,
                  //  Name = tutor1.Name,
                    Subjects = new List<Subject> { Subject.Economics },
                    HourlyPrice = 15,
                    StartTime = new DateTime(2024, 02, 05, 11, 00, 0, DateTimeKind.Utc), 
                    EndTime = new DateTime(2024, 02, 05, 11, 00, 0, DateTimeKind.Utc).AddHours(1),

                }
            );

            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    StName = "Siim Kaitse",
                    StTown = StTown.Tallinn,
                    StUniversity = StUniversity.TallinnUniversity,
                    StSpeciality = StSpeciality.CyberSecurity,
                    StMail = "mail1@gmail.com",
                    StSubject = StSubject.Maths,
                },
                new Student
                {
                    Id = 2,
                    StName = "Sander Ott",
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