using FiorellaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FiorellaAPI.Areas.Client.Controllers
{
    [Route("api/client/[controller]/[action]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sliders = await _sliderService.GetAllAsync();
            return Ok(sliders);
        }
    }
}
