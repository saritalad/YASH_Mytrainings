using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_AZure.Models;
// https://saritawebapi-a5a3cqaye8dvbqdz.eastus-01.azurewebsites.net/api/student
namespace WebAPI_AZure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDBContext _context;

        public StudentController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        { 
            var data =_context.Students;
            return Ok(data);
        }

        [HttpPost]
        public  IActionResult Post(Student student) 
            {
             _context.Students.Add(student);   
            _context.SaveChanges();
               return Ok(student);
            }
        [HttpPut]
        public IActionResult Put(int id, Student student)
        {
            var data = _context.Students.FirstOrDefault(c => c.Id == id);
            if (data != null)
            {
                data.Name=student.Name;
                _context.SaveChanges();
            }
            return Ok(data);    
        } 


    }
}
