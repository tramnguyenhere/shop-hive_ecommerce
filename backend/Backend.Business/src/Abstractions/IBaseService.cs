using Backend.Domain.src.Shared;

namespace Backend.Business.src.Abstractions
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions);
        Task<TReadDto> GetOneById(string id);
        Task<TReadDto> UpdateOneById(string id, TUpdateDto updatedEntity);
        Task<bool> DeleteOneById(string id);
        Task<TReadDto> CreateOne(TCreateDto entity);
    }
}
