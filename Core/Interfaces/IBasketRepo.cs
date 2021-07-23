using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketRepo
    {
         Task<CustomerBasket> GetBasketAsync(string BasketId);
         Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket);
         Task<bool> DeleteBasketAsync(string BasketId);
    }
}