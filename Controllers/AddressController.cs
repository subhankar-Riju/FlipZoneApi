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
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _address;

        public AddressController(IAddressRepository address)
        {
            _address = address;
        }

        [HttpGet("/GetAddress/{email}")]
        public async Task<IActionResult> GetAddressAsync([FromRoute]string email)
        {
            var result = await _address.GetAddressAsync(email);
            return Ok(result);
        }

        [HttpPost("PostAddress")]
        public async Task<IActionResult> PostAddressAsync([FromBody]AddressModel addr)
        {
            await _address.PostAddressAsync(addr);
            return Ok("done");
        }

        [HttpPut("PutAddress")]
        public async Task<IActionResult> PutAddressAsync([FromBody]AddressModel adr)
        {
            await _address.PutAddressAsync(adr);
            return Ok();
        }
    }
}
