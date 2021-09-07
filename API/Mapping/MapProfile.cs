using API.DTOs;
using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();   // Category nesnesi CategoryDTo ya dönüşebilir.
            CreateMap<CategoryDto, Category>();     // CategoryDTo nesnesi Category ya dönüşebilir.
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();
        }
    }
}
