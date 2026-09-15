using FiorellaAPI.Helpers.DTOs.Category;
using FiorellaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorellaAPI.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto request)
        {
            await _categoryService.CreateAsync(request);
            return Ok();
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

        [HttpPut]
        public async Task<IActionResult> Update(int Id,CategoryEditDto request)
        {
            await _categoryService.UpdateAsync(Id, request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _categoryService.DeleteAsync(Id);
            return Ok();
        }
    }
}
