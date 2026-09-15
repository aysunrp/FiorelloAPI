using FiorellaAPI.Helpers.DTOs.SliderImage;
using FiorellaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FiorellaAPI.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class SliderImageController : ControllerBase
    {
        private readonly ISliderImageService _sliderImageService;
        public SliderImageController(ISliderImageService sliderImageService)
        {
            _sliderImageService = sliderImageService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]SliderImageCreateDto request)
        {
            await _sliderImageService.CreateAsync(request);

            return Ok();

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var sliderImages= await _sliderImageService.GetAllAsync();
            return Ok(sliderImages);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var sliderImage = await _sliderImageService.GetByIdAsync(Id);
            return Ok(sliderImage);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _sliderImageService.DeleteAsync(Id);
            return Ok();       
        }
        [HttpPut]
        public async Task<IActionResult> Update(int Id,[FromForm] SliderImageEditDto request)
        {
            await _sliderImageService.UpdateAsync(Id, request);
            return Ok();
        }
    }
}
