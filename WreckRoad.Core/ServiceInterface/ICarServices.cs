using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WreckRoad.Core.Domain;

namespace WreckRoad.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> DetailsAsync(Guid id);
    }
}
