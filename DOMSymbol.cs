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
    
    public partial class DOMSymbol
    {
        public int DOM_Symbols_ID { get; set; }
        public int Symbol_ID { get; set; }
        public string DOM_Symbol { get; set; }
        public int DOM_Source_ID { get; set; }
        public int DevidedBy { get; set; }
        public int MultipliedBy { get; set; }
    
        public virtual DOMSource DOMSource { get; set; }
        public virtual Symbol Symbol { get; set; }
    }
}
