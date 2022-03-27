using FlipZoneApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public interface IMobileRepository
    {
        Task<IEnumerable<MobileModel>> GetAllMobiles(CursorParams cursorParams);
    }
}
