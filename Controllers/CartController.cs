using FlipZoneApi.Model;
using FlipZoneApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost("/AddToCart")]
        public async Task<IActionResult> AddTocartasync([FromBody] CartModel cartModel)
        {
            await _cartRepository.AddtoCart(cartModel);
            return Ok();
        }

        [HttpGet("/GetCartItems/{email}/{count}/{cursor}")]
        public async Task<IActionResult> GetCartItems([FromRoute]string email,[FromRoute]CursorParams @params)
        {
           var records= await _cartRepository.GetCartItems(email, @params);

            return Ok(records);
        }

        [HttpPost("/incrementqantity")]
        public async Task<IActionResult> IncrementQuantityasync([FromBody]CartModel cartModel)
        {
            
            
            var re = await _cartRepository.IncrementQuantity(cartModel);
            return Ok(re);
        }


    }
}
