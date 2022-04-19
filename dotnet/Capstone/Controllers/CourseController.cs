using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseDao courseDao;

        public CourseController(ICourseDao _courseDao)
        {
            courseDao = _courseDao;
        }
        [HttpPost()]
        public ActionResult<Course> AddCourse(Course course)
        {
            Course returnCourse = courseDao.CreateCourse(course);
            if (returnCourse == null)
            {
                return NotFound();
            }
            else if(returnCourse != null)
            {
                return Created($"course/{returnCourse.CourseId}", returnCourse);
            }
            else
            {
                return StatusCode(500);
            }

        }
    }
}
