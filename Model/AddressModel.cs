﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Model
{
    public class AddressModel
    {
        public string email { set; get; }
        public string addr { set; get; }
        public string city { set; get; }
        public string district { set; get; }
        public long mobile { set; get; }
        public long pin { set; get; }
        public string country { set; get; }
    }
}
