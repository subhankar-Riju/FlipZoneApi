using FlipZoneApi.Data;
using FlipZoneApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public class AddressRepository:IAddressRepository
    {
        private readonly FlipzoneDbContext _context;

        public AddressRepository(FlipzoneDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressModel>> GetAddressAsync(string email)
        {
            var record = await _context.Addresses
                .Where(a => email == a.email)
                .ToListAsync();

            var rec = record.Select(m => new AddressModel()
            {
                email=m.email,
                addr=m.addr,
                city=m.city,
                district=m.district,
                country=m.country,
                mobile=m.mobile,
                pin=m.pin
            });

            return rec;

        }

        public async Task PostAddressAsync(AddressModel m)
        {
            var rec = new Address()
            {
                email = m.email,
                addr = m.addr,
                city = m.city,
                district = m.district,
                country = m.country,
                mobile = m.mobile,
                pin = m.pin
            };

            await _context.Addresses.AddAsync(rec);
            await _context.SaveChangesAsync();


        }

        public async Task PutAddressAsync(AddressModel m)
        {
            var record = await _context.Addresses
                .FirstOrDefaultAsync(x => x.email == m.email);

            if (record != null)
            {
                record.addr = m.addr;
                record.city = m.city;
                record.country = record.country;
                record.email = record.email;
                record.mobile = m.mobile;
                record.district = m.district;
                record.pin = m.pin;

                await _context.SaveChangesAsync();
                   
            }

        }
    }
}
