using AutoMapper;
using FiorellaAPI.Data;
using FiorellaAPI.Helpers.DTOs.Slider;
using FiorellaAPI.Models;
using FiorellaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorellaAPI.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public SliderService(AppDbContext context,
                             IMapper mapper,
                             IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
         
        }
        public async Task CreateAsync(SliderCreateDto model)
        {
            string fileName = await _fileService.UploadAsync(model.Image, "images");
            await _context.AddAsync(_mapper.Map<Slider>(model));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var slider= await _context.Sliders.FirstOrDefaultAsync(x => x.Id == Id);
            if (slider == null) throw new Exception("Slider not found");
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderDto>> GetAllAsync()
        {
          var sliders= await _context.Sliders.Include(x => x.SliderImages).ToListAsync();
          return _mapper.Map<IEnumerable<SliderDto>>(sliders);
        }

        public async Task<SliderDto> GetByIdAsync(int Id)
        {
            var sliders = await _context.Sliders.Include(x => x.SliderImages).
                                                 FirstOrDefaultAsync(x => x.Id == Id);
            return _mapper.Map<SliderDto>(sliders);
        }

        public async Task UpdateAsync(int Id, SliderEditDto slider)
        {
            var sliders = await _context.Sliders.FirstOrDefaultAsync(x => x.Id == Id);

            if (sliders == null) throw new Exception("Slider not found");

            _mapper.Map(slider, sliders);

            if (slider.Image != null)
            {
                string fileName = await _fileService.UploadAsync(slider.Image, "images");
                sliders.Image = fileName;
            }
            await _context.SaveChangesAsync();
        }
    }
    }

