using Microsoft.AspNetCore.Mvc;

namespace Wreck_Road.Controllers
{
    public class CarsController : Controller
    {
        /*
         CarsController controls all functions for cars including Missions
         */
        public IActionResult Index()
        {
            return View();
        }
    }
}
