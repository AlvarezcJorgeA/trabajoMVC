//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcTenkiu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MOVIMIENTO
    {
        public long MO_ID { get; set; }
        public Nullable<long> DP_ID { get; set; }
        public string MO_TIPO { get; set; }
        public Nullable<System.DateTime> MO_FECHAHORA { get; set; }
        public Nullable<long> MO_DP_RES { get; set; }
        public Nullable<int> MO_PUNT { get; set; }
    
        public virtual DISPOSITIVO DISPOSITIVO { get; set; }
    }
}