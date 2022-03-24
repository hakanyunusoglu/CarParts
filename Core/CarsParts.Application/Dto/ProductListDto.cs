﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsParts.Application.Dto
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Barkod { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? Image { get; set; }

        public int CategoryId { get; set; }
    }
}
