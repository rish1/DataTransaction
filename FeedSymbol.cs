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
    
    public partial class FeedSymbol
    {
        public int Feed_Symbol_ID { get; set; }
        public int Symbol_ID { get; set; }
        public string Feed_Symbol { get; set; }
        public int Feed_Source_ID { get; set; }
        public int DevidedBy { get; set; }
        public int MultipliedBy { get; set; }
        public decimal BidTranslationTicks { get; set; }
        public decimal AskTranslationTicks { get; set; }
    
        public virtual FeedSource FeedSource { get; set; }
        public virtual Symbol Symbol { get; set; }
    }
}
