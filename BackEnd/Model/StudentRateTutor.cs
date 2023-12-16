using tuutoriplatvorm.Model;

namespace backend.Model
{
    public class StudentRateTutor
    {
        public int TutorId { get; init; }
        public int StudentId { get; init; }
        public int Rate { get; set; }
        public Tutor Tutor { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }

}