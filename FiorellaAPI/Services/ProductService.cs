using AutoMapper;
using FiorellaAPI.Data;
using FiorellaAPI.Helpers.DTOs.Product;
using FiorellaAPI.Models;
using FiorellaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorellaAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public ProductService(AppDbContext context,
                              IMapper mapper,
                              IFileService fileService)
        { 
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task CreateAsync(ProductCreateDto product)
        {
            var fileName = await _fileService.UploadAsync(product.Image,"images");
            var entity = _mapper.Map<Product>(product);
            entity.Image = fileName;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (product == null)throw new Exception("Product not found");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _context.Products.Include(x => x.Category).ToListAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int Id)
        {
            var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == Id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateAsync(int Id, ProductEditDto product)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            if (entity == null)throw new Exception("Product not found");
            _mapper.Map(product, entity);

            if (product.Image != null)
            {
                var fileName = await _fileService.UploadAsync(product.Image,"images");
                entity.Image = fileName;
            }
            await _context.SaveChangesAsync();
        }
    }
}
