using FiorellaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorellaAPI.Areas.Client.Controllers
{
    [Route("api/client/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var product = await _productService.GetByIdAsync(Id);
            return Ok(product);
        }
    }
}
