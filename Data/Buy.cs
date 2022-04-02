using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Data
{
    public class Buy
    {
        [Key]
        //[Column(Order=1)]
        public string email { set; get; }
        [Key]
        //[Column(Order =2)]
        public string p_id { set; get; }

        public int quantity { get; set; }

        public string dateTime { set; get; }
    }
}
