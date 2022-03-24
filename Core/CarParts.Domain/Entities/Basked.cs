using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class Basked : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Basked()
        {
            Order = new Order();
            AppUser = new AppUser();
        }
    }
}
