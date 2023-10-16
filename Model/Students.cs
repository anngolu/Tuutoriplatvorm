using System.Text.Json.Serialization;

namespace tuutoriplatvorm.Model
{
    public class Students 
    {
        
        public required string StName { get; init; }
        public required Town StTown { get; init; }
        public required University University { get; init; }
         public required Speciality Speciality { get; init; }
        public required string StMail { get; init; }
        public required Subject Subject { get; init; }
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Subject{
        Economics=1,
        Maths=2,
        Programming=3,
        Startup=4,
        PE=5,
        DiscMaths=6,

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Speciality{
        BusinessIt=1,
        Economics=2,
        Informatics=3,
        Science=4,
        CyberSecurity=5,
        Philology=6,
        Psycho=7,

    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum University{
        UniversityOfTartu =1,
        TallinnTechnicalUniversity =2,
        TallinnUniversity =3,
        TallinnCollegeOfHealth=4,
        TartuHigherArtSchool=5,
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Town{
        Tartu=1,
        Tallinn=2,
        Narva=3,
        KohtlaJarve=4
    }
 }