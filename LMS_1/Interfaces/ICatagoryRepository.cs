using LMS_1.Dtos;
using LMS_1.Entity;
using Microsoft.EntityFrameworkCore;

namespace LMS_1.Interfaces
{
    public interface ICatagoryRepository
    {
        Task<IEnumerable<categoryDto>> GetAllCategoriesAsync();
        Task<categoryDto> GetCategoryByIdAsync(int CategoryId);
        Task AddCategoryAsync(string name);
        Task<IEnumerable<BookDto>> GetBooksByCategory(int CategoryId);

    }
}
