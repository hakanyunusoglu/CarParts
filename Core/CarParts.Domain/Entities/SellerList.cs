using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class SellerList : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public int Stok { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public SellerList()
        {
            Product = new Product();
            AppUser = new AppUser();
        }
    }
}
