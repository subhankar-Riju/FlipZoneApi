﻿using FlipZoneApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Repository
{
    public interface IBuyRepository
    {
        Task<int> BuyMobile(MobileModel mobile, string email,bool fromCart=false);
        Task<string> BuyCart(string email);
    }
}
