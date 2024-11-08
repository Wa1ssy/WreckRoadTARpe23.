using Microsoft.EntityFrameworkCore;
using WreckRoad.Core.Domain;
using WreckRoad.Core.Dto;
using WreckRoad.Core.Serviceinterface;
using WreckRoad.Core.ServiceInterface;
using WreckRoad.Data;



namespace WreckRoad.ApplicationServices.Services
{
    public class CarServices : ICarsServices
    {
        private readonly WreckRoadContext _context;
        private readonly IFileServices _fileServices;

        public CarServices(WreckRoadContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            car.ID = Guid.NewGuid();
            car.CarXP = 0;
            car.CarXPNextLevel = 100;
            car.CarLevel = 0;
            car.CarStatus = Core.Domain.CarStatus.Alive;
            car.CarWasBuilt = DateTime.Now;
            car.CarCrashed = DateTime.Parse("01/01/9999 00:00:00");


            //set by user
           car.CarName = dto.CarName;
            car.CarType = (Core.Domain.CarType)dto.CarType;
            car.TurnName = dto.TurnName;
            car.TurnSpeed = dto.TurnSpeed;

            //set for db
            car.BuiltAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            //files
            if(dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, car);
            }

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> Update (CarDto dto)
        {
            Car car = new();

            car.ID = dto.ID;
            car.CarXP = dto.CarXP;
            car.CarXPNextLevel = dto.CarXPNextLevel;
            car.CarLevel = dto.CarLevel;
            car.CarStatus = (Core.Domain.CarStatus)dto.CarStatus;
            car.CarWasBuilt = dto.CarWasBuilt;
            car.CarCrashed = (DateTime)dto.CarCrashed;


            //set by user
            car.CarName = dto.CarName;
            car.CarType = (Core.Domain.CarType)dto.CarType;
            car.TurnName = dto.TurnName;
            car.TurnSpeed = dto.TurnSpeed;

            //set for db
            car.BuiltAt = dto.BuiltAt;
            car.UpdatedAt = DateTime.Now;

            //files
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, car);
            }
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
