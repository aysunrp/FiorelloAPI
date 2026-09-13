using FiorellaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiorellaAPI.Areas.Client.Controllers
{
    [Route("api/client/[controller]/[action]")]
    [ApiController]
    public class SliderImageController : ControllerBase
    {
        private readonly ISliderImageService _sliderImageService;
        public SliderImageController(ISliderImageService sliderImageService)
        {
            _sliderImageService = sliderImageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sliderImages = await _sliderImageService.GetAllAsync();
            return Ok(sliderImages);
        }
    }
}
