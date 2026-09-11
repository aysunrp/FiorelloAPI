using FiorellaAPI.Helpers.DTOs.Slider;

namespace FiorellaAPI.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreateAsync(SliderCreateDto slider);
        Task DeleteAsync(int Id);
        Task UpdateAsync(int Id, SliderEditDto slider);
        Task<IEnumerable<SliderDto>> GetAllAsync();
        Task<SliderDto> GetByIdAsync(int Id);
    }
}
