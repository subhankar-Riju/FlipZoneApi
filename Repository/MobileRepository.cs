using FlipZoneApi.Data;
using FlipZoneApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public class MobileRepository : IMobileRepository
    {
        private readonly FlipzoneDbContext _context;

        public MobileRepository(FlipzoneDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MobileModel>> GetAllMobiles(CursorParams cursorParams)
        {
            var record = await _context.Mobiles
                .ToListAsync();



            record = record
                .OrderByDescending(x => x.price)
                .Skip(cursorParams.count * cursorParams.cursor)
                .Take(cursorParams.count)
                .ToList();

            var rec = record.Select(x => new MobileModel()
            {
                p_id = x.p_id,
                brand = x.brand,
                model = x.model,
                price = x.price,
                quantity = x.quantity,
                rating = x.rating
            });



            return rec;

        }

        public async Task<IEnumerable<MobileModel>> SearchMobileAsync(string search, CursorParams cursorParams)
        {
            var mob = await _context.Mobiles
                .Where(m=>//m.model.Contains(search,StringComparison.OrdinalIgnoreCase)
                (m.brand).ToLower().Contains(search.ToLower())
                ||
                (m.model).ToLower().Contains(search.ToLower()))
                // m.brand.Contains(search))
                .OrderByDescending(m=>m.price)
                .Skip(cursorParams.count * cursorParams.cursor)
                .Take(cursorParams.count)
                .ToListAsync();
               
              
                

            var result = mob.Select(m => new MobileModel()
            {
                model=m.model,
                brand=m.brand,
                p_id=m.p_id,
                price=m.price,
                quantity=m.quantity,
                rating=m.rating
            });

            return result;
        } 

    }
}
