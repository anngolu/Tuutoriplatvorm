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
        public IActionResult GetStudent(
            [FromQuery] Town? town,
            [FromQuery] University? university,
            [FromQuery] Speciality? speciality,
            [FromQuery] Subject? subject){
                return Ok(_context.StudentList?.Where(s => 
                !town.HasValue || s.Town == town.Value &&
                !university.HasValue! || s.University == university!.Value &&
                !speciality.HasValue || s.Speciality == speciality!.Value &&
                !subject.HasValue || s.Subject == subject!.Value));
            }
    }
}