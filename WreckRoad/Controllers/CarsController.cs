using Microsoft.AspNetCore.Mvc;
using WreckRoad.Core.Dto;
using WreckRoad.Core.ServiceInterface;
using WreckRoad.Data;
using WreckRoad.Models.Cars;

namespace WreckRoad.Controllers
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
            return View(resultingInventory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateViewModel vm = new();
            return View("Create", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateViewModel vm)
        {
            var dto = new CarDto()
            {
                CarName = vm.CarName,
                CarXP = 0,
                CarXPNextLevel = 100,
                CarLevel = 0,
                CarType = (Core.Dto.CarType)vm.CarType,
                CarStatus = (Core.Dto.CarStatus)vm.CarStatus,
                TurnName = vm.TurnName,
                TurnSpeed = vm.TurnSpeed,
                CarWasBuilt = vm.CarWasBuilt,
                BuiltAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FilesToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarID = x.CarID,
                }).ToArray()
            };
            var result = await _carsservices.Create(dto);

            if (result != null)
            {
                return View("";
            }
        }
    }
}
