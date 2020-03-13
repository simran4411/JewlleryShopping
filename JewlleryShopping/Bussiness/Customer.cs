using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewlleryShopping.Bussiness
{
    public class Customer
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Date { get; set; }

        public int CategoryID { get; set; }
        public int JewelleryID { get; set; }

        public Category Category { get; set; }
        public Jewellery Jewellery { get; set; }
    }
}
