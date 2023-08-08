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

/*
    create user: name, email, password
    reade 1 user: names, email, password, role
    update user profile: name, email
    update password: password
    read 1 product: title, price, description, images
    create product: title, price, images, inventory
*/