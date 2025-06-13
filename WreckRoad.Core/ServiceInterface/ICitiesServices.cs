using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WreckRoad.Core.Domain;
using WreckRoad.Core.Dto;

namespace WreckRoad.Core.ServiceInterface
{
    public interface ICitiesServices
    {
        Task<City> Create(CityDto dto);
        Task<City> DetailsAsync(Guid id);
        Task<City> Delete(Guid id);
    }
}
