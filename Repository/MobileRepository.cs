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
            var record = await _context.Mobiles.ToListAsync();
            
            record =record.OrderByDescending(x => x.price).ToList();
            record = record.Skip(cursorParams.count * cursorParams.cursor)
                .Take(cursorParams.count)
                .ToList();
            

            var re = record.Select(x => new MobileModel()
            {
                price=x.price,
                brand=x.brand,
                rating=x.rating,
                model=x.model,
                quantity=x.quantity,
                p_id=x.p_id
            });

            return re;
                
        }
    }
}
