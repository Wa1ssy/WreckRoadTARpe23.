using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WreckRoad.ApplicationServices.Services;
using WreckRoad.Core.Domain;
using WreckRoad.Core.Dto;
using WreckRoad.Core.Serviceinterface;
using WreckRoad.Core.ServiceInterface;
using WreckRoad.Data;
using WreckRoad.Models.Cars;
using static System.Net.Mime.MediaTypeNames;

namespace WreckRoad.Controllers
{
    public class CarsController : Controller
    {
        /*
         CarsController controls all functions for cars including Missions
         */
        private readonly WreckRoadContext _context;
        private readonly ICarsServices _carsservices;
        private readonly IFileServices _fileservices;

        public CarsController(WreckRoadContext context, ICarsServices carsServices, IFileServices fileServices)
        {
            _context = context;
            _carsservices = carsServices;
            _fileservices = fileServices;
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
                    CarType = (Models.Cars.CarType)x.CarType,
                    CarStatus = (Models.Cars.CarStatus)x.CarStatus,
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
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarCreateViewModel vm)
        {
            var dto = new CarDto()
            {
                ID = (Guid)vm.ID,
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
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", vm);
        }
        
        public async Task<IActionResult> Details(Guid id /* guid ref*/)
        {
            var car = await _carsservices.DetailsAsync(id);
            
            if(car == null)
            {
                return NotFound();
            }

            var images = await _context.FilesToDatabase
                .Where(c => c.CarID == id)
                .Select( y => new CarImageViewModel
                {
                    CarID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
                }).ToArrayAsync();

            var vm = new CarDetailsViewModel();
            vm.ID = car.ID;
            vm.CarName = car.CarName;
            vm.CarXP = car.CarXP;
            vm.CarLevel = car.CarLevel;
            vm.CarType = (Models.Cars.CarType)car.CarType;
            vm.CarStatus = (Models.Cars.CarStatus)car.CarStatus;
            vm.TurnName = car.TurnName;
            vm.TurnSpeed = car.TurnSpeed;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carsservices.DetailsAsync(id);
            
            if (car == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToDatabase
                .Where(x => x.CarID == id)
                 .Select(y => new CarImageViewModel
                 {
                     CarID = y.ID,
                     ImageID = y.ID,
                     ImageData = y.ImageData,
                     ImageTitle = y.ImageTitle,
                     Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
                 }).ToArrayAsync();

            var vm = new CarCreateViewModel();
            vm.ID = car.ID;
            vm.CarName = car.CarName;
            vm.CarXP = car.CarXP;
            vm.CarXPNextLevel = car.CarXPNextLevel;
            vm.CarLevel = car.CarLevel;
            vm.CarType = (Models.Cars.CarType)car.CarType;
            vm.CarStatus = (Models.Cars.CarStatus)car.CarStatus;
            vm.TurnName = car.TurnName;
            vm.TurnSpeed = car.TurnSpeed;
            vm.CarCrashed = car.CarCrashed;
            vm.CarWasBuilt = car.CarWasBuilt;
            vm.BuiltAt = car.BuiltAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateViewModel vm)
        {
            var dto = new CarDto()
            {
                ID = (Guid)vm.ID,
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
            var result = await _carsservices.Update(dto);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _carsservices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            };

            var images = await _context.FilesToDatabase
                .Where(x => x.CarID == id)
                .Select( y => new CarImageViewModel
                {
                    CarID = y.ID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64, {0}", Convert.ToBase64String(y.ImageData)),
                }).ToArrayAsync();
            var vm = new CarDeleteViewModel();

            vm.ID = car.ID;
            vm.CarName = car.CarName;
            vm.CarXP = car.CarXP;
            vm.CarXPNextLevel = car.CarXPNextLevel;
            vm.CarLevel = car.CarLevel;
            vm.CarType = (Models.Cars.CarType)car.CarType;
            vm.CarStatus = (Models.Cars.CarStatus)car.CarStatus;
            vm.TurnName = car.TurnName;
            vm.TurnSpeed = car.TurnSpeed;
            vm.BuiltAt = car.BuiltAt;
            vm.UpdatedAt = DateTime.Now;
            vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carToDelete = await _carsservices.Delete(id);

            if (carToDelete == null) 
            {  
                return RedirectToAction("Index");          
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(CarImageViewModel vm)
        {
            var dto = new FilesToDatabaseDto()
            {
                ID = vm.ImageID
            };
            var image = await _fileservices.RemoveImageFromDatabase(dto);
            if (image == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
