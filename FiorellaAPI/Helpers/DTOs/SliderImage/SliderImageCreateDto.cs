namespace FiorellaAPI.Helpers.DTOs.SliderImage
{
    public class SliderImageCreateDto
    {
        public IFormFile Image { get; set; }
        public int SliderId { get; set; }
    }
}
