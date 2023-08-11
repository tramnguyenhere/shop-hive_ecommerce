using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Shared;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DatabaseContext _context;
        public BaseRepository(DatabaseContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _context = dbContext;
        }
        public virtual async Task<T> CreateOne(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteOneById(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAll(QueryOptions queryOptions)
        {
            return await _dbSet.ToArrayAsync();
        }

        public async Task<T> GetOneById(Guid id)
        {
            return await _dbSet.FindAsync(id);
           
        }

        public async Task<T> UpdateOneById(T originalEntity, T updatedEntity)
        {
            _dbSet.Update(updatedEntity);
            await _context.SaveChangesAsync();
            return updatedEntity;
        }
    }
}