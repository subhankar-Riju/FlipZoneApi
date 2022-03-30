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
        Task AddtoCart(CartModel cart);
        Task<IEnumerable<CartModel>> GetCartItems(string email, CursorParams @params);
        Task<IEnumerable<Cart>> GetQuantity(string email, string p_id);
        Task<int> IncrementQuantity(CartModel cartModel);

    }
}
