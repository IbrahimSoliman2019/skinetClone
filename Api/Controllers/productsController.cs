using System.Collections.Generic;
using System.Threading.Tasks;
using Api.DTOS;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
        private readonly IMapper mapper;

        public ProductsController(IGenericRepo<Product> Productrepo,IGenericRepo<ProductBrand> ProductBrandRepo
         ,IGenericRepo<ProductType> ProductTyperepo,IMapper mapper)
        {
            productrepo = Productrepo;
            productBrandRepo = ProductBrandRepo;
            productTyperepo = ProductTyperepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts()
        {
            var spec = new ProductWithBrandsandTypesspecification();
            var products = await productrepo.ListAllBySpec(spec);
            return Ok(mapper.Map<IReadOnlyList<Product>,List<ProductToReturnDTO>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductWithBrandsandTypesspecification(id);

            var product = await productrepo.GetBySpec(spec);
            return mapper.Map<Product,ProductToReturnDTO>(product);
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