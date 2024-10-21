using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Wreck_Road.Core.Domain.Serviceinterface;
using Wreck_RoadContext.Data;
using WreckRoad.Models.Cars;

namespace Wreck_Road.Controllers
{
    public class CarsController : Controller
    {
        /*
         CarsController controls all functions for cars including Missions
         */
        private readonly WreckRoadContext _context;
        private readonly ICarsServices _carsservices;

        public CarsController(WreckRoadContext context, ICarsServices carsServices)
        {
            _context = context;
            _carsservices = carsServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var resultingInventory = _context.Cars
                .OrderByDescending(y => y.CarLevel)
                .Select(x => new CarIndexViewModel
                {
                    ID = x.ID,
                    CarName = x.CarName,
                    CarType = (CarType)x.CarType,
                    CarStatus = (CarStatus)x.CarStatus,
                    CarLevel = x.CarLevel,
                    BuiltAt = x.BuiltAt,
                });
            return View();
        }
    }
}
