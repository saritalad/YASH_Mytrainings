using Microsoft.AspNetCore.Mvc;

namespace MVC_On_AZURE_demo.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

    }
}
