using System.Collections.Generic;
using System.Threading.Tasks;
using Api.DTOS;
using Api.Errors;
using Api.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
   
    public class ProductsController : BaseApiController
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
        public async Task<ActionResult<Pagination<ProductToReturnDTO>>> GetProducts(
            [FromQuery]ProductSpecParams ProductParams)
        {
            var spec = new ProductWithBrandsandTypesspecification(ProductParams);
            var countspec = new ProductWithFiltersForCountSpecification(ProductParams);
            var totalitems = await productrepo.CountAsync(countspec);
            var products = await productrepo.ListAllBySpec(spec);
            var data = mapper.Map<IReadOnlyList<Product>,List<ProductToReturnDTO>>(products);
            return Ok(new Pagination<ProductToReturnDTO>(ProductParams.PageIndex,ProductParams.PageSize,totalitems,data));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductWithBrandsandTypesspecification(id);

            var product = await productrepo.GetBySpec(spec);
            if(product==null) return NotFound(new ApiResponse(404));
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