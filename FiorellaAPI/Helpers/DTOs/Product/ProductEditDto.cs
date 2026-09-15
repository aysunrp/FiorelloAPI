namespace FiorellaAPI.Helpers.DTOs.Product
{
    public class ProductEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
        public string CategoryName { get; set; }
    }
}
