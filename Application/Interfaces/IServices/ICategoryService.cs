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
        Task<IEnumerable<CategoryDto>> GetAllCategories(bool trackChanges);
        Task<CategoryDto> GetCategoryById(int id, bool trackChanges);
       // void CreateCategory(Category category);
      
    }
}
