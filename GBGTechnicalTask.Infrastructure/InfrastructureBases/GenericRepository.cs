using GBGTechnicalTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace GBGTechnicalTask.Infrastructure.InfrastructureBases
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }
        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await SaveChangesAsync();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await SaveChangesAsync();
        }
        public virtual async Task<IList<T>> GetTableAsTracking()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public virtual async Task<IList<T>> GetTableAsNoTracking()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
