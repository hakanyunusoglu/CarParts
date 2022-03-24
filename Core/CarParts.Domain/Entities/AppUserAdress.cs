using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class AppUserAdress : BaseEntity
    {
        public string? Adress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Long { get; set; }
        public string? Short { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public AppUserAdress()
        {
            AppUser = new AppUser();
        }
    }
}
