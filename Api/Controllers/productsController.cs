using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepo<Product> productrepo;
        private readonly IGenericRepo<ProductBrand> productBrandRepo;
        private readonly IGenericRepo<ProductType> productTyperepo;

        public ProductsController(IGenericRepo<Product> Productrepo,IGenericRepo<ProductBrand> ProductBrandRepo
         ,IGenericRepo<ProductType> ProductTyperepo)
        {
            productrepo = Productrepo;
            productBrandRepo = ProductBrandRepo;
            productTyperepo = ProductTyperepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await productrepo.ListAllAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await productrepo.GetByIdAsync(id);
            return Ok(product);
        }
        [HttpGet("brands")]
         public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await productBrandRepo.ListAllAsync();
            return Ok(productBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productBrands = await productTyperepo.ListAllAsync();
            return Ok(productBrands);
        }
    }
}