using CarParts.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParts.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Definition { get; set; }
        public string? Image { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public int? Parent { get; set; }
        public List<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
