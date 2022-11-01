using Application.Interfaces.IRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbcontext) : base(dbcontext)
        {
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategories(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c=>c.CategoryName)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.CategoryId == id, trackChanges)
                .Include(m=>m.Meals)
                .SingleOrDefaultAsync();
        }
    }
}
