using FlipZoneApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public interface IMobileRepository
    {
        Task<Object> GetAllMobiles(CursorParams cursorParams, MobileSearchFilterModel sfill);
        Task<IEnumerable<MobileModel>> SearchMobileAsync(string search, CursorParams cursorParams);
    }
}
