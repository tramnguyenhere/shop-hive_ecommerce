using Backend.Domain.src.Shared;

namespace Backend.Business.src.Abstractions
{
    public interface IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions);
        Task<TReadDto> GetOneById(Guid id);
        Task<TReadDto> UpdateOneById(Guid id, TUpdateDto updatedEntity);
        Task<bool> DeleteOneById(Guid id);
        Task<TReadDto> CreateOne(TCreateDto entity);
    }
}
