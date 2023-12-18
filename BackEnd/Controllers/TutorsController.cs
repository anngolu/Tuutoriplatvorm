using System.Security.Claims;
using backend.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tuutoriplatvorm.Model;

namespace tuutoriplatvorm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorsController : ControllerBase
    {
        private readonly DataContext _context;
        public TutorsController(DataContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin, Tutor, Student")]
        [HttpGet]
        public IActionResult GetTutor()
        {
            return Ok(_context.TutorList);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetailById(int? id)
        {
            var tutor = _context.TutorList?.FirstOrDefault(s => s.Id == id);
            if (tutor == null)
            {
                return NotFound();
            }
            return Ok(tutor);
        }

        [Authorize(Roles = "Tutor")]
        [HttpPost]
        public IActionResult Create([FromBody] Tutor tutor)
        {
            string username = User.FindFirstValue(ClaimTypes.Name)!;
            var dbTutor = _context.TutorList!.FirstOrDefault(s => username.Equals(s.Username));
            if (dbTutor == null)
            {
                tutor.Id = null;
                tutor.Username = username;
                _context.Add(tutor);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDetailById), new { Id = tutor.Id }, tutor);
            }
            else
            {
                return Conflict("Tutor already exists");
            }
        }

        [Authorize(Roles = "Admin, Tutor")]
        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody] Tutor tutors)
        {
            if (id != tutors.Id || !_context.TutorList!.Any(s => s.Id == id))
            {
                return NotFound();
            }
            _context.Update(tutors);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            var tutor = _context.TutorList?.Find(id);
            if (tutor == null)
            {
                return NotFound();
            }

            _context.Remove(tutor);
            _context.SaveChanges();

            return NoContent();
        }

    }
}