using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
        public List<AppUserPhone> Phones { get; set; }
        public List<AppUserAdress> Adresses { get; set; }

        public AppUser()
        {
            Adresses = new List<AppUserAdress>();
            Phones = new List<AppUserPhone>();
            AppRole = new AppRole();
        }
    }
}
