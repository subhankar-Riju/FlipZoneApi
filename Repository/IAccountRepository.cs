using FlipZoneApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public interface IAccountRepository
    {
        Task SignUpAsyn(CustomerModel signUpModel);
        Task<IEnumerable<CustomerModel>> Loginasync(LoginModel login);
        Task<bool> check(CustomerModel signUpModel);

    }
}
