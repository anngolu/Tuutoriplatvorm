using System.Text.Json.Serialization;

namespace tuutoriplatvorm.Model
{
    public class Students
    {
        public int Id { get; init; }
        public required string StName { get; init; }
        public required StTown StTown { get; init; }
        public required StUniversity University { get; init; }
        public required StSpeciality Speciality { get; init; }
        public required string StMail { get; init; }
        public required StSubject Subject { get; init; }
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StSubject
    {
        Economics = 1,
        Maths = 2,
        Programming = 3,
        Startup = 4,
        PE = 5,
        DiscMaths = 6,

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StSpeciality
    {
        BusinessIt = 1,
        Economics = 2,
        Informatics = 3,
        Science = 4,
        CyberSecurity = 5,
        Philology = 6,
        Psycho = 7,

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StUniversity
    {
        UniversityOfTartu = 1,
        TallinnTechnicalUniversity = 2,
        TallinnUniversity = 3,
        TallinnCollegeOfHealth = 4,
        TartuHigherArtSchool = 5,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StTown
    {
        Tartu = 1,
        Tallinn = 2,
        Narva = 3,
        KohtlaJarve = 4
    }
}