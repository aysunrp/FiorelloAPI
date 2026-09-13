using FiorellaAPI.Helpers.DTOs.Slider;
using FiorellaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FiorellaAPI.Areas.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDto request)
        {
            await _sliderService.CreateAsync(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sliders=await _sliderService.GetAllAsync();
            return Ok(sliders);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int Id)
        {
            var slider = await _sliderService.GetByIdAsync(Id);
            return Ok(slider);
            
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _sliderService.DeleteAsync(Id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(int Id,[FromForm] SliderEditDto request)
        {
            await _sliderService.UpdateAsync(Id, request);
            return Ok();
        }
    }
}
