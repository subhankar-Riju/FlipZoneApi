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
    public class BuyController : ControllerBase
    {
        private readonly IBuyRepository _buyRepository;

        public BuyController(IBuyRepository buyRepository)
        {
            _buyRepository = buyRepository;
        }

        [HttpPost("/BuyMobile/{email}")]
        public async Task<IActionResult> BuyMobile([FromRoute]string email,[FromBody]MobileModel mobileModel)
        {
             var rec = await _buyRepository.BuyMobile(mobileModel, email);
            //string h = DateTime.Now.ToString("g");
            return Ok(rec);
        }
        [HttpPost("/deleteCartItem/{email}")]
        public async Task<IActionResult> deleteFromCart([FromRoute] string email)
        {
          var result= await  _buyRepository.BuyCart(email);

            return Ok(result);

        }

        [HttpPost("/BuyFromCart/{email}")]
        public async Task<IActionResult> BuyFromCart([FromRoute]string email)
        {
            var result = await _buyRepository.BuyCart(email);
            return Ok(result);
        }

        [HttpGet("/History/{email}/{count}/{cursor}")]
        public async Task<IActionResult> BuyHistory([FromRoute]string email,[FromRoute]CursorParams @params)
        {
            var result = await _buyRepository.BuyHistoryAsync(email,@params);
            return Ok(result);
        }


    }
}
