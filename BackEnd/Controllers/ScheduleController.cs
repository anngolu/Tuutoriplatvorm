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
            //Schedule koos objektide Tutors ja Students väljadega
            //return Ok(_context.ScheduleList!.Include(s => s.Tutor).ToList());

            
           var result=_context.ScheduleList!.Include(s => s.Tutor).Include(s => s.Student).ToList();

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


//        [HttpGet("StudentSchedule")]

        [HttpGet("StudentSchedule/{id}")]
        public IActionResult GetStudentSchedule(int? id)
        {
   
            var innerJoin=_context.StudentList.Join(
                        _context.ScheduleList,
                        student=>student.Id,
                        schedule=>schedule.StudentId,
                    (student, schedule)=> new
                    {
                        schedule.Id,
                        schedule.TutorId,
                        schedule.Tutor.Name,
                        schedule.Tutor.Speciality,
                        schedule.HourlyPrice,
                        schedule.IsPaid,
                        schedule.Subjects,
                        schedule.StudentId,
                        schedule.StartTime,
                        schedule.EndTime,
                        student.StName
                    });

                     if (id == null)

                    {
                      return Ok(innerJoin);
                    }       

            return Ok(innerJoin.Where(innerJoin => innerJoin.StudentId.Equals(id)));
          //return Ok(innerJoin);

       }



        [HttpPut("registerStudent/{studentId}/{scheduleId}")]
        public IActionResult UpdateStudentIdInStudentCourses(int studentId, int scheduleId)
        {
            // Retrieve the StudentCourses entity by its ID
         
            var studentCourses = _context.ScheduleList!.FirstOrDefault(x => x.Id == scheduleId);

            if (studentCourses != null)
            {
                // Update the StudentId property
                studentCourses.StudentId = studentId;

                // Save the changes to the database
                return Ok(_context.SaveChanges());
            }   return Ok();
        }
    }

}