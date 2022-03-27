using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Data
{
    public class Laptop
    {
        [Key]
        public string p_id { set; get; }
        public string brand { get; set; }
        public string model { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public double rating { get; set; }
    }
}
