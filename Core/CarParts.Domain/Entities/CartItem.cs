using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Product Product { get; set; }
        public Guid ProductID { get; set; }
        public Cart Cart { get; set; }
        public Guid CartID { get; set; }
        public int Quantity { get; set; }
    }
}
