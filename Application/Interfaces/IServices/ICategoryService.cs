using Application.DataTransfer;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(bool trackChanges);
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId, bool trackChanges);
        Task<CategoryDto> CreateCategoryAsync(CategoryForCreationDto categoryForCreation);
        Task DeleteCategoryAsync(int categoryId, bool trackChanges);
        Task UpdateCategoryAsync(int categoryId, CategoryForUpdateDto categoryForUpdate,bool trackChanges);
      
    }
}
