using FlipZoneApi.Model;
using FlipZoneApi.Repository;
using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class MobileController : ControllerBase
    {
        private readonly IMobileRepository _mobile;

        public MobileController(IMobileRepository mobile)
        {
            _mobile = mobile;
        }
         [HttpPost("GetMobiles/{count}/{cursor}")]
         public async Task<IActionResult> GetAllMobilesasync([FromRoute]CursorParams cursorParams
             ,[FromBody]MobileSearchFilterModel sfill)
        {
            var record = await _mobile.GetAllMobiles(cursorParams,sfill);

            return Ok(new
            {
                count=record.Count(),
                data=record,
               

            });

        }
            
        [HttpGet("/SearchMobiles/{count}/{cursor}/{search}")]
        public async Task<IActionResult> SearchMobilesAsync([FromRoute]CursorParams cursorParams,[FromRoute]string search)
        {
            var result = await _mobile.SearchMobileAsync(search, cursorParams);
            return Ok(new
            {
                count = result.Count(),
                record = result
            });
        }
    }
}
