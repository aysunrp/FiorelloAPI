namespace FiorellaAPI.Models
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public IEnumerable<SliderImage> SliderImages { get; set; }


    }
}
