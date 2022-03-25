using CarParts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsParts.Application.Dto
{
    public class CategoryListDto
    {
        public string? Definition { get; set; }
        public string? Image { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public int? Parent { get; set; }
        
    }
}
