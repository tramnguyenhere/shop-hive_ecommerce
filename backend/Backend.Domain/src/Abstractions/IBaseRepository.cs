using Backend.Domain.src.Shared;

namespace Backend.Domain.src.Abstractions
{
    public interface IBaseRepository<T> 
    {
        IEnumerable<T> GetAll(QueryOptions queryOptions);
        T GetOneById(string id);
        T UpdateOneById(T updatedEntity);
        bool DeleteOneById(string id);
    }
}