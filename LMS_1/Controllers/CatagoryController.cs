using LMS_1.Dtos;
using LMS_1.Interfaces;
using LMS_1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private readonly ICatagoryRepository _CatagoryRepository;
        public CatagoryController(ICatagoryRepository catagoryRepository)
        {
            _CatagoryRepository = catagoryRepository;
        }
        [HttpGet("AllCategories")]
        public async Task<IEnumerable<categoryDto>> GetAllCatagories()
        {
            return await _CatagoryRepository.GetAllCategoriesAsync();
        }
        [HttpGet("CategoryById")]
        public async Task<categoryDto> GetCatagory(int Id)
        {
            return await _CatagoryRepository.GetCategoryByIdAsync(Id);
        }
        [HttpPost("NewCategory")]
        public async Task<bool> CreateNewCategoryAsync(string name)
        {
            try
            {
                await _CatagoryRepository.AddCategoryAsync(name);
                return true; 
            }
            catch (Exception)
            {
                
                return false; 
            }
        }
        [HttpGet("BooksByCategory")]
        public async Task<IEnumerable<BookDto>> GetBooksByCategory(int CategoryId)
        {
            return await _CatagoryRepository.GetBooksByCategory(CategoryId);
        }

    }
}
