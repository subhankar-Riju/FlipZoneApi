using FlipZoneApi.Data;
using FlipZoneApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public class CartRepository:ICartRepository
    {
        private readonly FlipzoneDbContext _context;

        public CartRepository(FlipzoneDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddtoCart(CartModel cartModel)
        {
            var check = await _context.Carts
                .Where(x => x.email == cartModel.email && x.p_id == cartModel.p_id)
                .FirstOrDefaultAsync();
            if (check != null)
            {
                return -1;
            }
            var c = new Cart()
            {
                email = cartModel.email,
                p_id = cartModel.p_id,
                brand = cartModel.brand,
                price = cartModel.price,
                rating = cartModel.rating,
                model = cartModel.model,
                quantity = 1
            };
           await  _context.Carts.AddAsync(c);
            await _context.SaveChangesAsync();

            return 1;
        }

        public async Task<object> GetCartItems(string email,CursorParams @params)
        {
            var record = await _context.Carts
                .Where(x => x.email.Contains(email))
                .ToListAsync();
            var count = record.Sum(x => (x.price*x.quantity));
            record=record
                .OrderByDescending(x => x.price)
                .Skip(@params.count*@params.cursor)
                .Take(@params.count)
                .ToList();

            var rec = record.Select(x=>new CartModel()
            {
                email=x.email,
                p_id=x.p_id,
                price=x.price,
                model=x.model,
                brand=x.brand,
                rating=x.rating,
                quantity=x.quantity

            });

            return new {
                totalPrice = count,
                record = rec

            };
        }

        public  IEnumerable<CartAccountMobileModel> GetQuantity(string email)
        {

            IEnumerable<CartAccountMobileModel> list = from cols in _context.Mobiles
                       from c in _context.Carts
                       from a in _context.Customers
                       where a.email==email && cols.model == c.model && a.email == c.email
                       select new CartAccountMobileModel
                       {
                           p_id=cols.p_id,
                           email=c.email,
                           c_qant=c.quantity,
                           m_qant=cols.quantity

                       };


            return list; 
            
            
        }

        public async Task<int> IncrementQuantity(CartModel cartModel)
        {

            var record = await _context.Carts
                .Where(x => x.email == cartModel.email)
                .Where(x => x.p_id == cartModel.p_id)
                .FirstOrDefaultAsync();
            var mob = await _context.Mobiles
                .Where(m => m.p_id == cartModel.p_id)
                .FirstOrDefaultAsync();

            if (record != null && mob!=null && mob.quantity> record.quantity-1)
            {
                record.quantity = ++cartModel.quantity;
                await _context.SaveChangesAsync();
                return 1;
            }

            return -1;


        }

        public async Task<int> DecrementQuantity(CartModel cartModel)
        {

            var record = await _context.Carts
                .Where(x => x.email == cartModel.email)
                .Where(x => x.p_id == cartModel.p_id)
                .FirstOrDefaultAsync();

            if (record != null)
            {
                if (record.quantity > 0)
                {
                    record.quantity = --cartModel.quantity;
                }
                
                await _context.SaveChangesAsync();
                return 1;
            }

            return -1;


        }





    }
    }

