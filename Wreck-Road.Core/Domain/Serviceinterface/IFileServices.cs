using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wreck_RoadContext.Core.Domain;
using Wreck_RoadContext.Core.Domain.Dto;

namespace Wreck_Road.Core.Domain.Serviceinterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(CarDto dto, Car domain);
    }
}
