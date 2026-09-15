using FiorellaAPI.Helpers.DTOs.Product;
using FiorellaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorellaAPI.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto request)
        {
            await _productService.CreateAsync(request);
            return Ok();
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

        [HttpPut]
        public async Task<IActionResult> Update(int Id,[FromForm] ProductEditDto request)
        {
            await _productService.UpdateAsync(Id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _productService.DeleteAsync(Id);
            return Ok();
        }
    }
}
