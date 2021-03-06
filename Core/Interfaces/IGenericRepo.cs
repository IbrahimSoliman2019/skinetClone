using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepo<T> where T:BaseEntity
    {
         Task<T> GetByIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync();
         Task<T> GetBySpec(ISpecification<T> spec);
         Task<IReadOnlyList<T>> ListAllBySpec(ISpecification<T> spec);
         Task<int> CountAsync(ISpecification<T> spec);


    }
}