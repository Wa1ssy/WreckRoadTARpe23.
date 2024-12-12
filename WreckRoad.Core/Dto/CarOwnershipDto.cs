using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckRoad.Core.Dto
{
    public class CarOwnershipDto : CarDto
    {
        public Guid OwnershipID { get; set; }
        public string CarName { get; set; }
        public int CarXP { get; set; }
        public int CarXPNextLevel { get; set; }
        public int CarLevel { get; set; }
        public CarStatus CarStatus { get; set; }
        public int TurnSpeed { get; set; }
        public string TurnName { get; set; }
        public DateTime CarWasBuilt { get; set; }
        public DateTime CarCrashed { get; set; }
        //public string OwnedByPlayerProfile { get; set; } //is string but holds guid

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FilesToDatabaseDto> Image { get; set; } = new List<FilesToDatabaseDto>();

        //db only
        public DateTime OwnershipCreatedAt { get; set; }
        public DateTime OwnershipUpdatedAt { get; set; }
    }
}
