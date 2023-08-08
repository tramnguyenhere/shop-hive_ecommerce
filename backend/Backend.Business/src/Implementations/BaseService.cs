using AutoMapper;
using Backend.Business.src.Abstractions;
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
        public bool DeleteOneById(string id)
        {
            var foundItem = _baseRepository.GetOneById(id);
            if(foundItem != null) {
                _baseRepository.DeleteOneById(id);
                return true;
            } return false;
        }

        public async Task<IEnumerable<TReadDto>> GetAll(QueryOptions queryOptions)
        {
            return _mapper.Map<IEnumerable<TReadDto>>(await _baseRepository.GetAll(queryOptions));
        }

        public async Task<TReadDto> GetOneById(string id)
        {
            return _mapper.Map<TReadDto>(await _baseRepository.GetOneById(id));
        }

        public async Task<TReadDto> UpdateOneById(string id, TUpdateDto updatedEntity)
        {
            var foundItem = await _baseRepository.GetOneById(id);
            if(foundItem != null) {
                var toBeUpdatedEntity =_baseRepository.UpdateOneById(foundItem, _mapper.Map<T>(updatedEntity));
                return _mapper.Map<TReadDto>(toBeUpdatedEntity);
            } else {
                throw new Exception("Item not found!");
            }
        }

        Task<bool> IBaseService<T, TReadDto, TCreateDto, TUpdateDto>.DeleteOneById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<TReadDto> CreateOne(TCreateDto entity)
        {
            return _mapper.Map<TReadDto>(entity);
        }
    }
}