using AutoMapper;
using FiorellaAPI.Data;
using FiorellaAPI.Helpers.DTOs.Slider;
using FiorellaAPI.Models;
using FiorellaAPI.Services.Interfaces;

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

        public Task DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SliderDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SliderDto> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int Id, SliderEditDto slider)
        {
            throw new NotImplementedException();
        }
    }
}
