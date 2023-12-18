using System.Text.Json.Serialization;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace tuutoriplatvorm.Model
{
    public class Tutor
    {
        public int? Id { get; set; }
        [JsonIgnore]
        public string? Username { get; set; }
        public required string Name { get; init; }
        public Town? Town { get; init; }
        public University? University { get; init; }
        public Speciality? Speciality { get; init; }
        public string? Mail { get; init; }
        public required List<Subject> Subjects { get; set; }
        public double? HourlyPrice { get; init; }
        public decimal? AverageRate { get; set; }
        public int? RateCount { get; set; }
        public string? PhotoUrlId { get; set; }

        public  int? ScheduleId { get; set; } 

        [JsonIgnore]
        public ICollection<Schedule> Schedules { get; } = new List<Schedule>();
        [JsonIgnore]
        public virtual List<StudentRateTutor> StudentRateTutors { get; set; } = new();

    }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Speciality
    {
        BusinessIt,
        Economics,
        Informatics,
        Science,
        CyberSecurity,
        Psychologist,

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum University
    {
        UniversityOfTartu = 1,
        TallinnTechnicalUniversity = 2,
        TallinnUniversity = 3,
        TallinnCollegeOfHealth = 4,
        TartuHigherArtSchool = 5,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Town
    {
        Tartu = 1,
        Tallinn = 2,
        Narva = 3,
        KohtlaJarve = 4,

    }
}