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
    public class MobileController : ControllerBase
    {
        private readonly IMobileRepository _mobile;

        public MobileController(IMobileRepository mobile)
        {
            _mobile = mobile;
        }
         [HttpGet("GetMobiles/{count}/{cursor}")]
         public async Task<IActionResult> GetAllMobilesasync([FromRoute]CursorParams cursorParams)
        {
            var record = await _mobile.GetAllMobiles(cursorParams);

            return Ok(new
            {
                count=record.Count(),
                data=record,
               

            });

        }
    }
}
