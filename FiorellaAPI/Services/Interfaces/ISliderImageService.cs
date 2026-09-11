using FiorellaAPI.Helpers.DTOs.SliderImage;

namespace FiorellaAPI.Services.Interfaces
{
    public interface ISliderImageService
    {
        Task CreateAsync(SliderImageCreateDto sliderImage);

        Task DeleteAsync(int Id);

        Task UpdateAsync(int Id, SliderImageEditDto sliderImage);

        Task<IEnumerable<SliderImageDto>> GetAllAsync();

        Task<SliderImageDto> GetByIdAsync(int Id);
    }
}
