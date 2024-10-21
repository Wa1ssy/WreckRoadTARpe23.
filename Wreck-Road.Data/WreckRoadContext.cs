using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wreck_Road.Core.Domain;
using Wreck_Road.Core.Domain.Serviceinterface;
using Wreck_RoadContext.Core.Domain;

namespace Wreck_RoadContext.Data
{
    public class WreckRoadContext : DbContext
    {
        public WreckRoadContext(DbContextOptions<WreckRoadContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<FileToDatabase> FilesToDatabase { get; set; }
    }
}
