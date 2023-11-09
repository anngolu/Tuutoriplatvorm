using System.Text.Json.Serialization;
using backend.Model;
using Microsoft.EntityFrameworkCore;

namespace tuutoriplatvorm.Model
{
    public class Tutor
    {
        public int? Id { get; init; }
        public required string Name { get; init; }
        public Town? Town { get; init; }
        public University? University { get; init; }
        public Speciality? Speciality { get; init; }
        public string? Mail { get; init; }
        public required List<Subject> Subjects { get; set; }
        public double? HourlyPrice { get; init; }
        public decimal? AverageRate { get; set; }
        public int? RateCount { get; set; }


        // public Tutor()
        // {
        //     Subject = new List<Subjects>();
        // }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Subject
    {

        Economics = 1,
        Maths = 2,
        Programming = 3,
        Startup = 4,
        PE = 5,
        DiscMaths = 6,

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