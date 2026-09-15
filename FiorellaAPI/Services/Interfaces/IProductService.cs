using FiorellaAPI.Helpers.DTOs.Product;

namespace FiorellaAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(ProductCreateDto product);
        Task DeleteAsync(int Id);
        Task UpdateAsync(int Id, ProductEditDto product);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int Id);
    }
}
