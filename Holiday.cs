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
    
    public partial class Holiday
    {
        public int Holiday_ID { get; set; }
        public string Description { get; set; }
        public string HolidayDate { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan Endtime { get; set; }
        public int HolidayType { get; set; }
        public int Segment_ID { get; set; }
        public bool Enabled { get; set; }
    
        public virtual Segment Segment { get; set; }
    }
}
