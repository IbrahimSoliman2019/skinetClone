using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _store;

        public GenericRepo(StoreContext store)
        {
            _store = store;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _store.Set<T>().FindAsync(id);
        }



        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _store.Set<T>().ToListAsync();

        }
        public async Task<T> GetBySpec(ISpecification<T> spec)
        {
          return   await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllBySpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        
        public async Task<int> CountAsync(ISpecification<T> spec)
        {
           return await ApplySpecification(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_store.Set<T>().AsQueryable(), spec);
        }

    }
}