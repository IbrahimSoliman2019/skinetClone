using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
         public ProductWithFiltersForCountSpecification(ProductSpecParams ProductParams)
        :base(x=>(!ProductParams.BrandId.HasValue||x.ProductBrandId==ProductParams.BrandId)&&(!ProductParams.TypeId.HasValue||x.ProductTypeId==ProductParams.TypeId))
        {

        }
        
    }
}