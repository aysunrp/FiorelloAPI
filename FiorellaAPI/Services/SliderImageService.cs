using AutoMapper;
using FiorellaAPI.Data;
using FiorellaAPI.Helpers.DTOs.SliderImage;
using FiorellaAPI.Models;
using FiorellaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorellaAPI.Services
{
    public class SliderImageService : ISliderImageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public SliderImageService(AppDbContext context,
                                  IMapper mapper,
                                  IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task CreateAsync(SliderImageCreateDto sliderImage)
        {
            var fileName = await _fileService.UploadAsync(sliderImage.Image, "images");
            var entity = _mapper.Map<SliderImage>(sliderImage);
            entity.Image = fileName;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var sliderImage = await _context.SliderImages.FirstOrDefaultAsync(x => x.Id == Id);
            if (sliderImage == null) throw new Exception("Slider Image not found");
            _context.SliderImages. Remove(sliderImage);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderImageDto>> GetAllAsync()
        {
            var sliderImages = await _context.SliderImages.ToListAsync();
            return _mapper.Map<IEnumerable<SliderImageDto>>(sliderImages);
        }
        public async Task<SliderImageDto> GetByIdAsync(int Id)
        {
            var sliderImage = await _context.SliderImages.FirstOrDefaultAsync(x => x.Id == Id);
            return _mapper.Map<SliderImageDto>(sliderImage);
        }

        public async Task UpdateAsync(int Id, SliderImageEditDto sliderImage)
        {
            var entity = await _context.SliderImages.FirstOrDefaultAsync(x => x.Id == Id);

            if (entity == null) throw new Exception("Slider image not found");

            if (sliderImage.Image != null)
            {  
                var fileName = await _fileService.UploadAsync(sliderImage.Image, "images");
                entity.Image = fileName;
            }
            await _context.SaveChangesAsync();
        }
    }
}
