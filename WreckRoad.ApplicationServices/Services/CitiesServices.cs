using System.Runtime.CompilerServices;
using WreckRoad.Core.Domain;
using WreckRoad.Core.Dto;
using WreckRoad.Core.ServiceInterface;
using WreckRoad.Data;
using Microsoft.EntityFrameworkCore;
using WreckRoad.Core.Serviceinterface;

namespace WreckRoad.ApplicationServices.Services
{
    public class CitiesServices : ICitiesServices
    {
        private readonly WreckRoadContext _context;
        private readonly ICitiesServices _citiesServices;
        private readonly IFileServices _fileServices;


        public CitiesServices(WreckRoadContext context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<City> DetailsAsync(Guid id)
        {
            var result = await _context.Cities
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<City> Create(CityDto dto)
        {
            City city = new();
            city.ID = Guid.NewGuid();
            city.Name = dto.Name;
            city.Difficulty = (Core.Domain.Difficulty)dto.Difficulty;
            city.CarLevelRequirement = dto.CarLevelRequirement;
            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> Delete (Guid id)
        {
            var result = await _context.Cities.FirstOrDefaultAsync(x => x.ID == id);
            _context.Cities.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
