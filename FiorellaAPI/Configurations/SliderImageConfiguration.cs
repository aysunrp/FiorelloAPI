using FiorellaAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FiorellaAPI.Configurations
{
    public class SliderImageConfiguration : IEntityTypeConfiguration<SliderImage>
    {
        public void Configure(EntityTypeBuilder<SliderImage> builder)
        {
            builder.Property(x => x.Image)
                .IsRequired()
                .HasMaxLength(300);

            builder.HasOne(x => x.Slider)
                .WithMany(x => x.SliderImages)
                .HasForeignKey(x => x.SliderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
