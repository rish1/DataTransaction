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
    
    public partial class Segment_Permissions
    {
        public int Segment_Permission_ID { get; set; }
        public int User_ID { get; set; }
        public int Segment_ID { get; set; }
        public decimal Exposure { get; set; }
        public int Margin_Type_ID { get; set; }
        public decimal Initial_Margin_X { get; set; }
        public decimal Maintainance_Margin_X { get; set; }
        public string Margin_Remarks { get; set; }
        public int Commission_Type_ID { get; set; }
        public decimal Commission { get; set; }
        public string Commission_Remarks { get; set; }
    
        public virtual Commission_Types Commission_Types { get; set; }
        public virtual Margin_Types Margin_Types { get; set; }
        public virtual Segment Segment { get; set; }
        public virtual User User { get; set; }
    }
}
