using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class OrderDetails : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid SellerListId { get; set; }
        public SellerList SellerList { get; set; }
        public int Amount { get; set; }

        public OrderDetails()
        {
            Order = new Order();
            SellerList = new SellerList();
        }
    }
}
