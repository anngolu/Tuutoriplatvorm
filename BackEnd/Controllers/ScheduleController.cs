using backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tuutoriplatvorm.Model;

namespace tuutoriplatvorm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly DataContext _context;
        public ScheduleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllSchedule()
        {

            return Ok(_context.ScheduleList!.Include(s => s.Tutor).ToList());

        }

        [HttpGet("tutors/{id}")]
        public IActionResult GetTutorSchedule(int tutorId)
        {
            var tutor = _context.TutorList!.Find(tutorId);
            if (tutor == null)
            {
                return NotFound();
            }

            return Ok(_context.ScheduleList!.Where(lesson => lesson.TutorId.Equals(tutorId)));

        }

        [HttpGet("{id}")]
        public IActionResult GetScheduleById(int id)
        {
            var schedule = _context.ScheduleList!.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(_context.ScheduleList!.Where(lesson => lesson.Id.Equals(id)));

        }

        [HttpPost]
        public IActionResult CreateTutorSchedule([FromBody] ScheduleForm scheduleForm)
        {
            var tutor = _context.TutorList!.Find(scheduleForm.TutorId);
            if (tutor == null)
            {
                return NotFound();
            }

            var schedule = new Schedule
            {
                TutorId = scheduleForm.TutorId,
                Name = scheduleForm.Name,
                Subjects = scheduleForm.Subjects,
                HourlyPrice = scheduleForm.HourlyPrice,
                StartTime = scheduleForm.StartTime,
                EndTime = scheduleForm.EndTime,
            };
            _context.Add(schedule);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetScheduleById), new { Id = schedule.Id }, schedule);


        }
    }

}