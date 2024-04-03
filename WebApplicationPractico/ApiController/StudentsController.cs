using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationPractico.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents() 
        {
            string[] students = new string[] { "Jorge","Pablo","Juan","Mateo"};
            return Ok(students);
        }
    }
}
