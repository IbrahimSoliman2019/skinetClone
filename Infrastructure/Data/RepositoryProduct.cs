using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly StoreContext _store;
        public RepositoryProduct(StoreContext store)
        {
            _store = store;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _store.Products
                         .Include(p => p.ProductBrand)
                         .Include(p => p.ProductType)
                         .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _store.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _store.Products
                         .Include(p => p.ProductBrand)
                         .Include(p => p.ProductType)
                         .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _store.ProductTypes.ToListAsync();
        }
    }
}