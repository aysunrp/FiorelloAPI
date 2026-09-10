namespace FiorellaAPI.Models
{
    public class SliderImage:BaseEntity
    {
        public string Image { get; set; }
        public int SliderId { get; set; }
        public Slider Slider { get; set; }

    }
}
