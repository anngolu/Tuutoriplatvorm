using System.Security.Claims;
using BackEnd.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tuutoriplatvorm.Model;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAccount()
        {
            string username = User.FindFirstValue(ClaimTypes.Name)!;
            if(User.IsInRole(UserRoles.Student))
            {
                return Ok(_context.StudentList!.FirstOrDefault(u => username.Equals(u.Username)));
            }
            if(User.IsInRole(UserRoles.Tutor))
            {
                return Ok(_context.TutorList!.FirstOrDefault(u => username.Equals(u.Username)));
            }
            return NotFound();
        }

    }
}