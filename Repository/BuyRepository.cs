using FlipZoneApi.Data;
using FlipZoneApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public class BuyRepository:IBuyRepository
    {
        private readonly FlipzoneDbContext _context;

        public BuyRepository(FlipzoneDbContext context)
        {
            _context = context;
        }
        public async Task<int> BuyMobile(MobileModel mobile, string email,bool fromCart=false)
        {
            var record = await _context.Mobiles
                .Where(x => x.p_id == mobile.p_id)
                .FirstOrDefaultAsync();
            var x = 0;
            if ((record.quantity > 1 && fromCart==false) || (record.quantity > mobile.quantity && fromCart==true))
            {
                if (fromCart)
                {
                    record.quantity -= mobile.quantity;
                    x = mobile.quantity;
                }
                else
                {
                    record.quantity -= 1;
                    x = 1;
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                return -1;
            }

            var b = new Buy()
            {
                email = email,
                p_id = mobile.p_id,
                quantity = x,
                dateTime = DateTime.Now.ToString("g")
            };
            await _context.Buys.AddAsync(b);
            await _context.SaveChangesAsync();

            return 1;
        }


        public async Task<string> BuyCart(string email)
        {
            var cartItems = await _context.Carts
                .Where(x => x.email == email)
                .OrderBy(x => x.p_id)
                .ToListAsync();

            foreach(var item in cartItems){
                if (item.p_id.StartsWith("M"))
                {
                    var mob = new MobileModel()
                    {
                        p_id = item.p_id,
                        price = item.price,
                        brand = item.brand,
                        model = item.model,
                        rating = item.rating,
                        quantity = item.quantity

                    };
                    var result =await  BuyMobile(mob, email,true);

                    //return "buyMobile" + result;

                  var del=  DeleteMobileCart(item.p_id, email);
                    //return "deletemobilecart" + del;

                }
                return "hello";
            }

            return "sucess";
        }


        public async Task<int> DeleteMobileCart(string p_id,string email)
        {
            var mobile = await _context.Carts
                .Where(x => x.p_id == p_id && x.email == email)
                .FirstOrDefaultAsync();
            if (mobile != null)
            {
                 _context.Carts.Remove(mobile);
                await _context.SaveChangesAsync();

                return 1;

            }

            return -1;
        }
    }
}
