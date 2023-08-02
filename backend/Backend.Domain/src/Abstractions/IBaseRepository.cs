using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.src.Shared;

namespace Backend.Domain.src.Abstractions
{
    public interface IBaseRepository<T> // repo should not work with Dto, but original entities
    {
        IEnumerable<T> GetAll(QueryOptions queryOptions);
        T GetOneById(string id);
        T UpdateOneById(T updatedEntity);
        bool DeleteOneById(string id);
    }
}