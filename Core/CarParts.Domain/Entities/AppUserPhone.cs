using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class AppUserPhone : BaseEntity
    {
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int Phone { get; set; }

        public AppUserPhone()
        {
            AppUser = new AppUser();
        }
    }
}
