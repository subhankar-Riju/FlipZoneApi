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
        private readonly IBuyRepository _buyRepository;

        public CartController(ICartRepository cartRepository,
            IBuyRepository buyRepository)
        {
            _cartRepository = cartRepository;
            _buyRepository = buyRepository;
        }

        [HttpPost("/AddToCart")]
        public async Task<IActionResult> AddTocartasync([FromBody] CartModel cartModel)
        {
            var record=await _cartRepository.AddtoCart(cartModel);
            return Ok(record);
        }

        [HttpGet("/GetCartItems/{email}/{count}/{cursor}")]
        public async Task<IActionResult> GetCartItems([FromRoute]string email,[FromRoute]CursorParams @params)
        {
             var records= await _cartRepository.GetCartItems(email, @params);
           // var records =  _cartRepository.GetQuantity(email);

            return Ok(records);
        }

        [HttpPost("/incrementqantity/{IoD}")]
        public async Task<IActionResult> IncrementQuantityasync([FromBody]CartModel cartModel,[FromRoute]int IoD)
        {
            if (IoD == -1)
            {
                var re = await _cartRepository.DecrementQuantity(cartModel);
                return Ok(re);
            }
            else
            {
                var re = await _cartRepository.IncrementQuantity(cartModel);
                return Ok(re);
            }
            
            
        }

        [HttpDelete("/deleteFromcart/{email}/{p_id}")]

        public async Task<IActionResult> DeletefromCart([FromRoute]string email,[FromRoute]string p_id)
        {
            var result = await _buyRepository.DeleteMobileCart(p_id, email);
            return Ok(result);
        }

        


    }
}
