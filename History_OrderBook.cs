//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataTransaction
{
    using System;
    using System.Collections.Generic;
    
    public partial class History_OrderBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public History_OrderBook()
        {
            this.History_OrderBook1 = new HashSet<History_OrderBook>();
            this.History_Transactions = new HashSet<History_Transactions>();
            this.History_Transactions1 = new HashSet<History_Transactions>();
        }
    
        public int History_Order_ID { get; set; }
        public int User_ID { get; set; }
        public bool Order_Side { get; set; }
        public int Order_Type_ID { get; set; }
        public int Symbol_ID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Order_Status_ID { get; set; }
        public int Original_Order_ID { get; set; }
        public string Comments { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History_OrderBook> History_OrderBook1 { get; set; }
        public virtual History_OrderBook History_OrderBook2 { get; set; }
        public virtual Order_Status Order_Status { get; set; }
        public virtual Order_Types Order_Types { get; set; }
        public virtual Symbol Symbol { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History_Transactions> History_Transactions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History_Transactions> History_Transactions1 { get; set; }
    }
}
