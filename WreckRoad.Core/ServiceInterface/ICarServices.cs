﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WreckRoad.Core.Domain;
using WreckRoad.Core.Dto;

namespace WreckRoad.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> DetailsAsync(Guid id);

        Task<Car> Create(CarDto dto);
        Task<Car> Update(CarDto dto);

        Task<Car> Delete(Guid id);
    }
}
