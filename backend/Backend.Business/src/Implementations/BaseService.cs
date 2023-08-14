using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Business.src.Shared;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Shared;

namespace Backend.Business.src.Implementations
{
    public class BaseService<T, TReadDto, TCreateDto, TUpdateDto> : IBaseService<T, TReadDto, TCreateDto, TUpdateDto>
    {
        private readonly IBaseRepository<T> _baseRepository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<T> baseRepo, IMapper mapper) {
            _baseRepository = baseRepo;
            _mapper = mapper;
        }
        public async Task<bool> DeleteOneById(Guid id)
        {
            var foundItem = await _baseRepository.GetOneById(id);
            if (foundItem == null)
            {
                await _baseRepository.DeleteOneById(foundItem);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions)
        {
            return _mapper.Map<IEnumerable<TReadDto>>(await _baseRepository.GetAll(queryOptions));
        }

        public async Task<TReadDto> GetOneById(Guid id)
        {
            return _mapper.Map<TReadDto>(await _baseRepository.GetOneById(id));
        }

        public virtual async Task<TReadDto> UpdateOneById(Guid id, TUpdateDto updatedEntity)
        {
            var foundItem = await _baseRepository.GetOneById(id);
            if(foundItem != null) {
                var toBeUpdatedEntity =_baseRepository.UpdateOneById(foundItem, _mapper.Map<T>(updatedEntity));
                return _mapper.Map<TReadDto>(toBeUpdatedEntity);
            } else {
                throw CustomException.NotFoundException();
            }
        }

        public virtual async Task<TReadDto> CreateOne(TCreateDto entity)
        {
            var newEntity = await _baseRepository.CreateOne(_mapper.Map<T>(entity));
            return _mapper.Map<TReadDto>(newEntity);
        }
    }
}