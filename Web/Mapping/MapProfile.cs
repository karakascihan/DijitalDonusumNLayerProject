using AutoMapper;
using Core.Models;
using Web.DTOs;

namespace Web.Mapping
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
