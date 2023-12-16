using System.Text.Json.Serialization;
using tuutoriplatvorm.Model;

namespace backend.Model
{
    public class StudentRateTutor
    {
        public int TutorId { get; init; }
        public int StudentId { get; init; }
        public int Rate { get; set; }

        [JsonIgnore]
        public Tutor Tutor { get; set; } = null!;
        [JsonIgnore]
        public Student Student { get; set; } = null!;
    }

}