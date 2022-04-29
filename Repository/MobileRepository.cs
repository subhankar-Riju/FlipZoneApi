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
        public async Task<Object> GetAllMobiles(CursorParams cursorParams,MobileSearchFilterModel sfill)        {

             var record = await _context.Mobiles
                .OrderBy(m=>m.price)
                .ToListAsync();
            if (sfill.searchMobile != null)
            {
                record = record.Where(m => (m.brand).ToLower().Contains((sfill.searchMobile).ToLower())
                ||
                (m.model).ToLower().Contains((sfill.searchMobile).ToLower())
                )
                    .ToList();
            }

            if (sfill.filterRatinglt2 == 1)
            {
                record = record.Where(m => m.rating < 2).ToList();
            }

            if (sfill.filterRating3t4 == 1)
            {
                record = record.Where(m => m.rating >= 3 && m.rating <= 4)
                    .ToList();
            }
            
            if(sfill.filterRatinggt4 == 1)
            {
                record = record.Where(m => m.rating > 4)
                    .ToList();
            }

            if (sfill.filterPricelt30 == 1)
            {
                record = record.Where(m => m.price < 30000).ToList();
            }
            if (sfill.filterPrice60t90 == 1)
            {
                record = record.Where(m => m.price >= 60000 && m.price <= 90000)
                    .ToList();
            }
            if (sfill.filterPrice30t60 == 1)
            {
                record = record.Where(m => m.price >= 30000 && m.price <= 60000)
                    .ToList();
            }
            if (sfill.filterPricegt90 == 1)
            {
                record = record.Where(m => m.price > 90000).ToList();
            }
            //sort by price
            //1-- asending
            //-1 -- desending
            if (sfill.sortByPrice == 1)
            {
                record = record.OrderBy(m => m.price).ToList();
            }
            if (sfill.sortByPrice == -1)
            {
                record = record.OrderByDescending(m => m.price).ToList();
            }

            //sort by rating
            if (sfill.sortByRating == 1)
            {
                record = record.OrderBy(m => m.rating).ToList();
            }
            if (sfill.sortByRating == -1)
            {
                record = record.OrderByDescending(m => m.rating).ToList();
            }





            var Count = record.Count();
            record = record
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



            return new {
                count=Count,
                record = rec

            }
                ;

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
