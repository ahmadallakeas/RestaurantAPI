using Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        protected RepositoryBase(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? _dbContext.Set<T>().AsNoTracking() : _dbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? _dbContext.Set<T>().Where(expression).AsNoTracking() : _dbContext.Set<T>().Where(expression);
        }

    }
}
