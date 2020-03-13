using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewlleryShopping.Bussiness
{
    public class Jewellery
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public int Price { get; set; }

        public ICollection<Customer> Customers { get; set; }

    }
}
