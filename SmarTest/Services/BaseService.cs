using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using SmarTest.DataLayer;

namespace SmarTest.Services
{
    public abstract class BaseService<T> where T : class
    {
        protected readonly SmarTestDbContext _dbContext;

        protected BaseService(SmarTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(ObjectId id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        protected IQueryable<T> Query()
        {
            return _dbContext.Set<T>();
        }
    }
}
