using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopHere.Models
{
    using System.Collections.Generic;

    public class OrderDTO
    {
        public class Detail
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
           // public decimal Price { get; set; }
            public int? Quantity { get; set; }
        }
        public IEnumerable<Detail> Details { get; set; }
    }
}