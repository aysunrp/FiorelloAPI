using AutoMapper;
using FiorellaAPI.Helpers.DTOs.Category;
using FiorellaAPI.Helpers.DTOs.Product;
using FiorellaAPI.Helpers.DTOs.Slider;
using FiorellaAPI.Helpers.DTOs.SliderImage;
using FiorellaAPI.Models;

namespace FiorellaAPI.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Slider, SliderDto>();
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<SliderEditDto, Slider>();

            CreateMap<SliderImage, SliderImageDto>();
            CreateMap<SliderImageCreateDto, SliderImage>();
            CreateMap<SliderImageEditDto, SliderImage>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryEditDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductEditDto, Product>();
        }
    }
}
