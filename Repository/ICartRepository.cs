using FlipZoneApi.Data;
using FlipZoneApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public interface ICartRepository
    {
        Task<int> AddtoCart(CartModel cart);
        Task<object> GetCartItems(string email, CursorParams @params);
        IEnumerable<CartAccountMobileModel> GetQuantity(string email);
        Task<int> IncrementQuantity(CartModel cartModel);
        Task<int> DecrementQuantity(CartModel cartModel);

    }
}
