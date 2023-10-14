using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tuutoriplatvorm.Model;

namespace tuutoriplatvorm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly DataContext _context;
        public StudentsController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudent(){
            return Ok(_context.StudentList);
        }

            
    }
}