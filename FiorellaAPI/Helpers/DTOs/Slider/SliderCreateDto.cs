namespace FiorellaAPI.Helpers.DTOs.Slider
{
    public class SliderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
