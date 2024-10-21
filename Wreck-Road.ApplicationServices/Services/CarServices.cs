using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wreck_Road.Core.Domain.Serviceinterface;
using Wreck_RoadContext.Core.Domain;
using Wreck_RoadContext.Data;


namespace Wreck_Road.ApplicationServices.Services
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
