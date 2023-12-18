using System.ComponentModel.DataAnnotations.Schema;
using tuutoriplatvorm.Model;

namespace backend.Model
{
    public class ScheduleForm 
    {
        public int? Id { get; init; }
        public required int TutorId { get; init; }
        public int? StudentId { get; init; }
        public string? Name { get; init; }
        public required List<Subject> Subjects { get; init; }
        public double? HourlyPrice { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }

    }
}