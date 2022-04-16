using FlipZoneApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressModel>> GetAddressAsync(string email);
        Task PostAddressAsync(AddressModel m);
        Task PutAddressAsync(AddressModel m);
    }
}
