using Microsoft.AspNetCore.Mvc;

namespace Wreck_RoadContext.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
