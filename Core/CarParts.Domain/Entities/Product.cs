using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public string? Barkod { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; }
        public int? Stok { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Product()
        {
             Category = new Category();
        }
    }
}
