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

        public async Task AddtoCart(CartModel cartModel)
        {
            var c= new Cart()
            {
                email=cartModel.email,
                p_id= cartModel.p_id,
                brand= cartModel.brand,
                price= cartModel.price,
                rating= cartModel.rating,
                model= cartModel.model,
                quantity=cartModel.quantity
            };
           await  _context.Carts.AddAsync(c);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartModel>> GetCartItems(string email,CursorParams @params)
        {
            var record = await _context.Carts
                .Where(x=> x.email.Contains(email))
                .OrderByDescending(x => x.price)
                .Skip(@params.count*@params.cursor)
                .Take(@params.count)
                .ToListAsync();

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
            
            return rec;
        }

        public async Task<IEnumerable<Cart>> GetQuantity(string email,string p_id)
        {

            var record = await _context.Carts
                .Where(x => x.email == email)
                .Where(x => x.p_id == p_id)
                .ToListAsync();
                ;
            return record;
        }

        public async Task<int> IncrementQuantity(CartModel cartModel)
        {

            var record = await _context.Carts
                .Where(x => x.email == cartModel.email)
                .Where(x => x.p_id == cartModel.p_id)
                .FirstOrDefaultAsync();

            if (record != null)
            {
                record.quantity = ++cartModel.quantity;
                await _context.SaveChangesAsync();
                return 1;
            }

            return -1;









        }
                
                

               
            
        }
    }

