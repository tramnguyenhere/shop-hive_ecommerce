using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Shared;
using Backend.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.src.RepoImplementations
{
    public class BaseRepo<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DatabaseContext _context;
        public BaseRepo(DatabaseContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
            _context = dbContext;
        }
        public Task<T> CreateOne(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOneById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll(QueryOptions queryOptions)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetOneById(string id)
        {
            return await _dbSet.FindAsync(id);
           
        }

        public Task<T> UpdateOneById(T originalEntity, T updatedEntity)
        {
            throw new NotImplementedException();
        }
    }
}