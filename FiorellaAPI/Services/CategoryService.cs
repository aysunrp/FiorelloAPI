using AutoMapper;
using FiorellaAPI.Data;
using FiorellaAPI.Helpers.DTOs.Category;
using FiorellaAPI.Models;
using FiorellaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorellaAPI.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateAsync(CategoryCreateDto category)
        {
            await _context.AddAsync(_mapper.Map<Category>(category));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == Id);
            if (category == null) throw new Exception("Category not found");
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetByIdAsync(int Id)
        {
            var category = await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == Id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateAsync(int Id, CategoryEditDto category)
        {
            var entity = await _context.Categories.FirstOrDefaultAsync(x => x.Id == Id);
            if (entity == null) throw new Exception("Category not found");
            _mapper.Map(category, entity);
            await _context.SaveChangesAsync();
        }
    }
}
