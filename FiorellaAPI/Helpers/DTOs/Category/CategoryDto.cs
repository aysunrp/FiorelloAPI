using FiorellaAPI.Helpers.DTOs.Product;

namespace FiorellaAPI.Helpers.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}

