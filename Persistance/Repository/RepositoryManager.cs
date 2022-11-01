using Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly Lazy<CategoryRepository> _categoryRepository;

        public RepositoryManager(ApplicationDbContext context)
        {
            _dbContext = context;
            _categoryRepository= new Lazy<CategoryRepository>(() => new CategoryRepository(context));


        }
        public ICategoryRepository Category => _categoryRepository.Value;
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
