using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Model
{
    public class BuyModel
    {
        
        //[Column(Order=1)]
        public string email { set; get; }
        
        //[Column(Order =2)]
        public string p_id { set; get; }
        public string brand { get; set; }
        public string model { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public double rating { get; set; }
    }
}
