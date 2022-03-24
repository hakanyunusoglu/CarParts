using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class AppRole
    {
        public int ID { get; set; }
        public string? Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }

        public AppRole()
        {
            AppUsers = new List<AppUser>();
        }
    }
}
