using FiorellaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorellaAPI.Areas.Client.Controllers
{
    [Route("api/client/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var category = await _categoryService.GetByIdAsync(Id);
            return Ok(category);
        }
    }
}
