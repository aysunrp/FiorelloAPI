using AutoMapper;
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
            CreateMap<SliderEditDto, SliderEditDto>();

            CreateMap<SliderImage, SliderImageDto>();
            CreateMap<SliderImageCreateDto, SliderImage>();
            CreateMap<SliderImageEditDto, SliderImage>();
        }
    }
}
