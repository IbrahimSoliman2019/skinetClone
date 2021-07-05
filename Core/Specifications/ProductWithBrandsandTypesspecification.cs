using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithBrandsandTypesspecification : BaseSpecification<Product>
    {
        public ProductWithBrandsandTypesspecification(ProductSpecParams ProductParams)
        :base(x=>
        (string.IsNullOrEmpty(ProductParams.Search)||x.Name.Contains(ProductParams.Search))&&
        (!ProductParams.BrandId.HasValue||x.ProductBrandId==ProductParams.BrandId)&&(!ProductParams.TypeId.HasValue||x.ProductTypeId==ProductParams.TypeId))
        {
             AddInclude(x=>x.ProductBrand);
             AddInclude(x=>x.ProductType);
             AddOrderBy(x=>x.Name);
             ApplyPaging(ProductParams.PageSize*(ProductParams.PageIndex-1),ProductParams.PageSize);
             switch(ProductParams.sort){
                 case "priceAcs":
                 AddOrderBy(x=>x.Price);
                 break;
                 case "priceDesc":
                 AddOrderByDescinding(x=>x.Price);
                 break;
                 default:
                 AddOrderBy(x=>x.Name);
                 break;

             }
        }

        public ProductWithBrandsandTypesspecification(int id) : base(x=>x.Id==id)
        {
            AddInclude(x=>x.ProductBrand);
             AddInclude(x=>x.ProductType);
        }
    }
}