using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepo _repo;
        public BasketController(IBasketRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketAsync(string BasketId)
        {
            return await _repo.GetBasketAsync(BasketId);

        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasketAsync(CustomerBasket Basket)
        {
            var updatedBasket = await _repo.UpdateBasketAsync(Basket);
            return Ok(updatedBasket);

        }
        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _repo.DeleteBasketAsync(id);

        }
    }
}