using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories(bool trackChanges);
        Task<Category> GetCategoryById(int id,bool trackChanges);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
