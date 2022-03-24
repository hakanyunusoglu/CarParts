using AutoMapper;
using CarParts.Domain.Entities;
using CarsParts.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsParts.Application.Mapping
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}
