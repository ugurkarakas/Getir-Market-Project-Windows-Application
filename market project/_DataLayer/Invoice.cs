//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int InvoiceID { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> TotalAmount { get; set; }
        public Nullable<int> MarketSafeID { get; set; }
        public Nullable<int> OrderID { get; set; }
    
        public virtual MarketSafe MarketSafe { get; set; }
        public virtual Order Order { get; set; }
    }
}
