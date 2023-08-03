using AutoMapper;
using Backend.Business.src.Abstractions;
using Backend.Domain.src.Abstractions;
using Backend.Domain.src.Shared;

namespace Backend.Business.src.Implementations
{
    public class BaseService<T, TDto> : IBaseService<T, TDto>
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

        public IEnumerable<TDto> GetAll(QueryOptions queryOptions)
        {
            return _mapper.Map<IEnumerable<TDto>>(_baseRepository.GetAll(queryOptions));
        }

        public TDto GetOneById(string id)
        {
            return _mapper.Map<TDto>(_baseRepository.GetOneById(id));
        }

        public TDto UpdateOneById(string id, TDto updatedEntity)
        {
            var foundItem = _baseRepository.GetOneById(id);
            if(foundItem != null) {
                var toBeUpdatedEntity =_baseRepository.UpdateOneById(foundItem, _mapper.Map<T>(updatedEntity));
                return _mapper.Map<TDto>(toBeUpdatedEntity);
            } else {
                throw new Exception("Item not found!");
            }
        }
    }
}