using FiorellaAPI.Helpers.DTOs.Category;

namespace FiorellaAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto category);
        Task DeleteAsync(int Id);
        Task UpdateAsync(int Id, CategoryEditDto category);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int Id);
    }
}
