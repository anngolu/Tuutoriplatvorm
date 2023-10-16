using Microsoft.AspNetCore.Mvc;
using tuutoriplatvorm.Model;

namespace tuutoriplatvorm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorsController : ControllerBase
    {
        private readonly DataContext _context;
        public TutorsController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTutor(
            [FromQuery] Town? town,
            [FromQuery] University? university,
            [FromQuery] Speciality? speciality,
            [FromQuery] Subject? subject){
                return Ok(_context.TutorList?.Where(s => 
                !town.HasValue || s.Town == town.Value &&
                !university.HasValue! || s.University == university!.Value &&
                !speciality.HasValue || s.Speciality == speciality!.Value &&
                !subject.HasValue || s.Subject == subject!.Value));
            }

        [HttpGet]
        public IActionResult GetTutor(){
            return Ok(_context.TutorList);
        }
        [HttpGet("{id}")]
        public IActionResult GetDetailById(int? id){
            var tutors = _context.TutorList?.FirstOrDefault(s => s.Id == id);
            if(tutors == null){
                return NotFound();
            }
            return Ok(tutors);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Tutors tutor){
            var dbTutor = _context.TutorList?.Find(tutor.Id);
            if(dbTutor == null){
                _context.Add(tutor);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetDetailById), new {Id = tutor.Id}, tutor);
            }
            else{
                return Conflict();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int? id, [FromBody] Tutors tutors){
            if(id != tutors.Id || !_context.TutorList!.Any(s => s.Id == id)){
                return NotFound();
            }
            _context.Update(tutors);
            _context.SaveChanges();

            return NoContent();
        }
    }
}