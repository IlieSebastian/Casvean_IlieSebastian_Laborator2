using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casvean_IlieSebastian_Laborator2.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderData { get; set; }

    }
}
