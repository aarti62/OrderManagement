//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopHere
{
    using System;
    using System.Collections.Generic;
    
    public partial class ORDER_ITEM
    {
        public int ID { get; set; }
        public Nullable<int> PRODUCTID { get; set; }
        public Nullable<int> ORDERID { get; set; }
        public Nullable<int> QUANTITY { get; set; }
    
        public virtual ORDER_DETAILS ORDER_DETAILS { get; set; }
        public virtual PRODUCT PRODUCT { get; set; }
        //public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
