using System.Security.Claims;
using backend.Model;
using BackEnd.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tuutoriplatvorm.Model;

namespace tuutoriplatvorm.Controllers
{
    [Authorize(Roles = "Admin,Student")]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly DataContext _context;
        public StudentsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            return Ok(_context.StudentList);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailById(int? id)
        {
            var student = _context.StudentList?.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            var dbStudent = _context.StudentList?.Find(student.Id);
            if (dbStudent == null)
            {
                _context.Add(student);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDetailById), new { Id = student.Id }, student);
            }
            else
            {
                return Conflict();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody] Student student)
        {
            if (id != student.Id || !_context.StudentList!.Any(s => s.Id == id))
            {
                return NotFound();
            }
            _context.Update(student);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Roles = "Student")]
        [HttpPost("tutors/{tutorId}/rates")]
        public IActionResult CalculateRating(int? tutorId, [FromBody] TutorRating? tutorRate)
        {
            int? rate = tutorRate?.Rate;
            if (rate == null || rate > 5 || rate < 1)
            {
                return BadRequest("Rate mustbe an integer between [1, 5]");
            }
            var tutor = _context.TutorList?.FirstOrDefault(s => s.Id == tutorId);
            if (tutor == null)
            {
                return NotFound("Tutor doesn't exist");
            }

            string studentUsername = User.FindFirstValue(ClaimTypes.Name)!;

            var student = _context.StudentList!
                .Include(s => s.StudentRateTutors)
                .First(s => studentUsername.Equals(s.Username));

            var studentRateTutor = student.StudentRateTutors.FirstOrDefault(srt => srt.TutorId == tutorId);

            tutor.AverageRate = tutor.AverageRate == null ? 0 : tutor.AverageRate;
            tutor.RateCount = tutor.RateCount == null ? 0 : tutor.RateCount;

            if (studentRateTutor == null)
            {
                // add new rate to StudentRateTutor
                studentRateTutor = new StudentRateTutor
                {
                    StudentId = (int)student.Id!,
                    TutorId = (int)tutorId!,
                    Rate = (int)rate
                };
                student.StudentRateTutors.Add(studentRateTutor);

                // calculate new average rate for tutor
                decimal newAverageRate = (decimal)((tutor.AverageRate * tutor.RateCount + rate) / (tutor.RateCount + 1));
                tutor.AverageRate = Math.Round(newAverageRate, 1);
                tutor.RateCount += 1;
            }
            else
            {
                int previousRate = studentRateTutor.Rate;
                // update rate in StudentRateTutor
                studentRateTutor.Rate = (int)rate!;

                // calculate new tutor average based on updated rate
                decimal newAverageRate = (decimal)((tutor.AverageRate * tutor.RateCount + rate - previousRate) / (tutor.RateCount));
                tutor.AverageRate = Math.Round(newAverageRate, 1);
            }

            _context.Update(student);
            _context.Update(tutor);
            _context.SaveChanges();

            return Ok();
        }

        [Authorize(Roles = "Student")]
        [HttpGet("tutors/rates")]
        public IActionResult GetStudentRates()
        {
            string studentUsername = User.FindFirstValue(ClaimTypes.Name)!;

            var student = _context.StudentList!
                .Include(s => s.StudentRateTutors)
                .First(s => studentUsername.Equals(s.Username));
            
            return Ok(student.StudentRateTutors.ToList());
        }

    }
}