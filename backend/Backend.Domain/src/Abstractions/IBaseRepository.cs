using Backend.Domain.src.Shared;

namespace Backend.Domain.src.Abstractions
{
    public interface IBaseRepository<T> 
    {
        Task<IEnumerable<T>> GetAll(QueryOptions queryOptions);
        Task<T> GetOneById(string id);
        Task<T> CreateOne(T entity); 
        Task<T> UpdateOneById(T originalEntity, T updatedEntity);
        Task<bool> DeleteOneById(string id);
    }
}