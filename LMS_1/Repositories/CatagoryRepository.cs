using AutoMapper;
using LMS_1.Data;
using LMS_1.Dtos;
using LMS_1.Entity;
using LMS_1.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_1.Repositories
{
    public class CatagoryRepository : ICatagoryRepository
    {
        private readonly LMSDbContext _context;
        private readonly IMapper _mapper;
        public CatagoryRepository(LMSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public  async Task AddCategoryAsync(string name)
        {
            var Category = new Catagory
            {
                Name = name
            };

            await _context.Catagories.AddAsync(Category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<categoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.Catagories.ToListAsync();
            return _mapper.Map<IEnumerable<categoryDto>>(categories);
        }
        public async Task<categoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _context.Catagories.FirstOrDefaultAsync(d => d.Id == categoryId);
            return _mapper.Map<categoryDto>(category); 
        }
        public async Task<IEnumerable<BookDto>> GetBooksByCategory(int categoryId)
        {
            var Books = await _context.Books.Where(e => e.catagoryId == categoryId).ToListAsync();
            return _mapper.Map<IEnumerable<BookDto>>(Books);
        }
    }
}
