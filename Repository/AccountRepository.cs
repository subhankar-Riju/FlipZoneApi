using FlipZoneApi.Data;
using FlipZoneApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly FlipzoneDbContext _context;

        public AccountRepository(FlipzoneDbContext context)
        {
            _context = context;
        }
        public async Task SignUpAsyn(CustomerModel signUpModel)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(signUpModel.password));
            string _stringuUnicode = Encoding.UTF8.GetString(hashValue);

            //string str = hashValue.ToString();
            var signup = new Customer()
            {
                firstname = signUpModel.firstname,
               lastname=signUpModel.lastname,
                email = signUpModel.email,
                password = Convert.ToBase64String(hashValue)

            };

            await _context.Customers.AddAsync(signup);
            await _context.SaveChangesAsync();




        }

        public async Task<IEnumerable<CustomerModel>> Loginasync(LoginModel login)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(login.password));
            // string _stringuUnicode = Encoding.UTF8.GetString(hashValue);

            var auth = _context.Customers
                .Where(x => x.email == (login.email))
                .Where(x => x.password == (Convert.ToBase64String(hashValue)))
                .ToList();

            var record = auth.Select(x => new CustomerModel
            {
                firstname = x.firstname,
                lastname=x.lastname,
                email = x.email,
                password = x.password
            });

            return record;
        }

        public async Task<bool> check(CustomerModel signUpModel)
        {
            var present =_context.Customers
                .Where(x => x.email == signUpModel.email)
                .ToList();
            if(present == null)
            {
                return false;
            }

            return true;

        }

        
    }
}
