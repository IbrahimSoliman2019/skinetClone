using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithBrandsandTypesspecification : BaseSpecification<Product>
    {
        public ProductWithBrandsandTypesspecification()
        {
             AddInclude(x=>x.ProductBrand);
             AddInclude(x=>x.ProductType);
        }

        public ProductWithBrandsandTypesspecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductBrand);
             AddInclude(x=>x.ProductType);
        }
    }
}