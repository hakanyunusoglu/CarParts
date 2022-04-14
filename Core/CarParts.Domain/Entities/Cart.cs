using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid userID { get; set; }
        public List<CartItem> CartItemList { get; set; }
    }
}
