using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubk.Browser.Models
{
    public class Product
    { 
        public string Item_market { set; get; }
        public string Cat_big { set; get; }
        public string Cat_middle { set; get; }
        public string Cat_small { set; get; }
        public string Item_id { set; get; }
        public string Item_nm { set; get; }
        public int Item_price { set; get; }
        public string Item_url { set; get; }
        public DateTime Writeday { set; get; }
    }
}
