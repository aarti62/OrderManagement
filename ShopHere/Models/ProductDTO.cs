using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopHere.Models
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string BRAND { get; set; }
        public Nullable<double> WEIGHT { get; set; }
        public Nullable<double> HEIGHT { get; set; }
        public byte[] PRODUCT_IMAGE { get; set; }
        public string BARCODE { get; set; }
    }
}