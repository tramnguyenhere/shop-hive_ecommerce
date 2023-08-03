using Backend.Domain.src.Shared;

namespace Backend.Business.src.Abstractions
{
    public interface IBaseService<T, TDto>
    {
        IEnumerable<TDto> GetAll(QueryOptions queryOptions);
        TDto GetOneById(string id);
        TDto UpdateOneById(string id, TDto updatedEntity);
        bool DeleteOneById(string id);
    }
}