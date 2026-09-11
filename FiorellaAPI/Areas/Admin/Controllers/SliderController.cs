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
    }
}
