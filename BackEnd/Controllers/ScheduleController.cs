using System.Security.Claims;
using backend.Model;
using Microsoft.AspNetCore.Authorization;
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
            var result = _context.ScheduleList!.Include(s => s.Tutor).Include(s => s.Student).ToList();

            return Ok(result);

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
                //Name = scheduleForm.Name,
                Subjects = scheduleForm.Subjects,
                HourlyPrice = scheduleForm.HourlyPrice,
                StartTime = scheduleForm.StartTime,
                EndTime = scheduleForm.EndTime,
            };
            _context.Add(schedule);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetScheduleById), new { Id = schedule.Id }, schedule);


        }


        [Authorize]
        [HttpGet("Students/{id}")]
        public IActionResult GetStudentSchedule(int? id)
        {
            var shcedule = _context.ScheduleList!
            .Where(sl => sl.StudentId == id)
            .Include(sl => sl.Student)
            .Include(sl => sl.Tutor);
            return Ok(shcedule);
        }


        [Authorize(Roles = "Student")]
        [HttpPut("{scheduleId}/register")]
        public IActionResult RegisterStudentToSchedule(int scheduleId)
        {
            var schedule = _context.ScheduleList!
            .Where(sl => sl.Id == scheduleId)
            .Include(sl => sl.Student)
            .FirstOrDefault();

            if (schedule == null)
            {
                return NotFound("Schedule not found");
            }

            if (schedule.Student != null)
            {
                return Conflict("Schedule is already booked");
            }

            string studentUsername = User.FindFirstValue(ClaimTypes.Name)!;

            var student = _context.StudentList!
                .First(s => studentUsername.Equals(s.Username));

            schedule.StudentId = student.Id;
            _context.Update(schedule);
            _context.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "Student")]
        [HttpPut("{scheduleId}/unregister")]
        public IActionResult UnregisterStudentToSchedule(int scheduleId)
        {
            var schedule = _context.ScheduleList!
            .Where(sl => sl.Id == scheduleId)
            .Include(sl => sl.Student)
            .FirstOrDefault();

            if (schedule == null)
            {
                return NotFound("Schedule not found");
            }

            if (schedule.StudentId == null)
            {
                return Ok();
            }

            string studentUsername = User.FindFirstValue(ClaimTypes.Name)!;

            var student = _context.StudentList!
                .First(s => studentUsername.Equals(s.Username));

            if (schedule.StudentId != student.Id)
            {
                return Conflict("Schedule is not booked by current student");
            }

            schedule.StudentId = null;
            _context.Update(schedule);
            _context.SaveChanges();
            return Ok();
        }
    }

}