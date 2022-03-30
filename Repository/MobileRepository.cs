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
    public class MobileRepository:IMobileRepository
    {
        private readonly FlipzoneDbContext _context;

        public MobileRepository(FlipzoneDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MobileModel>> GetAllMobiles(CursorParams cursorParams)
        {
            var record = await _context.Mobiles
                .OrderByDescending(x => x.price)
                .ToListAsync();
                
                
            
            record = record.Skip(cursorParams.count * cursorParams.cursor)
                .Take(cursorParams.count)
                .ToList();

            var rec = record.Select(x => new MobileModel()
            {
                p_id=x.p_id,
                brand=x.brand,
                model=x.model,
                price=x.price,
                quantity=x.quantity,
                rating=x.rating
            });

            

            return rec;
                
        }
    }
}
