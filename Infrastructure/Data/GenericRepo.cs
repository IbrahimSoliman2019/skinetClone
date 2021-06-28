using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
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
    }
}