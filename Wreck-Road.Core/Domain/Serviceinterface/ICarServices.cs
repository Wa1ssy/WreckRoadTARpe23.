using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wreck_RoadContext.Core.Domain;

namespace Wreck_Road.Core.Domain.Serviceinterface
{
    public interface ICarsServices
    {
        Task<Car> DetailsAsync(Guid id);
    }
}
