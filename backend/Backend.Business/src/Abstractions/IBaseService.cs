using Backend.Domain.src.Shared;

namespace Backend.Business.src.Abstractions
{
    public interface IBaseService<T, TDto>
    {
        IEnumerable<TDto> GetAll(QueryOptions queryOptions);
        T GetOneById(string id);
        T UpdateOneById(T updatedEntity);
        bool DeleteOneById(string id);
    }
}