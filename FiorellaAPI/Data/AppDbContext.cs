using FiorellaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorellaAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }


    }
}
