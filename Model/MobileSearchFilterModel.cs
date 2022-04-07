using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlipZoneApi.Model
{
    public class MobileSearchFilterModel
    {
        
        public string searchMobile { set; get; }
        //in filter 1--apply
        //-1 -- dont apply
        public int filterRatinggt4 { set; get; }
        public int filterRatinglt2 { set; get; }
        public int filterRating3t4 { set; get; }
        public int filterPricegt90 { set; get; }
        public int filterPricelt30 { set; get; }
        public int filterPrice30t60 { set; get; }
        public int filterPrice60t90 { set; get; }
        //sorting 1-- asending
        //0-- nutral
        //-1--desending
        public int sortByPrice { set; get; }
        public int sortByRating { set; get; }




    }
}
