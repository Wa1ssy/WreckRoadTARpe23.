using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wreck_RoadContext.Core.Domain;

namespace Wreck_RoadContext.Data
{
    internal class Wreck_RoadContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
