using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    public class Test1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Ajax call 
        [HttpPost]
        public JsonResult Display( string name )
        {
            var data = " Welcome : " + name ;
            return Json(data);
        }
    }
}
