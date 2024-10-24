using Microsoft.EntityFrameworkCore;
using WreckRoad.Core.Domain;
using WreckRoad.Core.ServiceInterface;
using WreckRoad.Data;



namespace WreckRoad.ApplicationServices.Services
{
    public class CarServices : ICarsServices
    {
        private readonly WreckRoadContext _context;

        public CarServices(WreckRoadContext context)
        {
            _context = context;
        }

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
    }
}
