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

        [Authorize(Roles = "Admin, Tutor")]
        [HttpPost]
        public IActionResult Create([FromBody] Tutor tutor)
        {
            var dbTutor = _context.TutorList?.Find(tutor.Id);
            if (dbTutor == null)
            {
                tutor.Id = null;
                _context.Add(tutor);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDetailById), new { Id = tutor.Id }, tutor);
            }
            else
            {
                return Conflict();
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

        [Authorize(Roles = "Admin, Tutor, Student")]
        [HttpPut("{id}/rate")]
        public IActionResult CalculateRating(int? id, [FromBody] TutorRating? tutorRate)
        {
            decimal? rate = tutorRate?.Rate;
            var tutor = _context.TutorList?.FirstOrDefault(s => s.Id == id);
            if (tutor == null)
            {
                return NotFound();
            }
            if (rate == null || rate > 5 || rate < 1)
            {
                return BadRequest();
            }
            tutor.AverageRate = tutor.AverageRate == null ? 0 : tutor.AverageRate;
            tutor.RateCount = tutor.RateCount == null ? 0 : tutor.RateCount;
            decimal newAverageRate = (decimal)((tutor.AverageRate * tutor.RateCount + rate) / (tutor.RateCount + 1));
            tutor.AverageRate = Math.Round(newAverageRate, 1);
            tutor.RateCount += 1;
            _context.Update(tutor);
            _context.SaveChanges();

            return Ok(tutor);
        }
        [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteTutor(int id)
        // {
        //     var tutor = await _context.TutorList.FindAsync(id);
        //     if (tutor == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.TutorList.Remove(tutor);
        //     await _context.SaveChangesAsync();

        //     return Ok();
        // }
           [HttpDelete("{id}")]
    public IActionResult Delete(int? id) 
    {
        var exercise = _context.TutorList?.Find(id);
        if (exercise == null)
        {
            return NotFound();
        }

        _context.Remove(exercise);
        _context.SaveChanges();

        return NoContent();
    }

    }
}