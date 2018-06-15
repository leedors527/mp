using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubk.Browser.Models
{
    public class Allproduct
    {
        public List<Product> Products = new List<Product>();
        public List<ItemList> Itemlist = new List<ItemList>();
        public string Marketname { set; get; }
    }
}
