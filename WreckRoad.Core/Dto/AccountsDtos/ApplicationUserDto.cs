using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WreckRoad.Core.Dto.AccountsDtos
{
    public class ApplicationUserDto
    {
        public int City {  get; set; }
        public string USerName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid? AssociatedPlayerProfile {  get; set; }
    }
}
