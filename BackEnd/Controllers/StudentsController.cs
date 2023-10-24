using Microsoft.AspNetCore.Mvc;
using tuutoriplatvorm.Model;

namespace tuutoriplatvorm.Controllers
{
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
        public IActionResult Create([FromBody] Students student)
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
        public IActionResult Update(int? id, [FromBody] Students student)
        {
            if (id != student.Id || !_context.StudentList!.Any(s => s.Id == id))
            {
                return NotFound();
            }
            _context.Update(student);
            _context.SaveChanges();

            return NoContent();
        }

    }
}