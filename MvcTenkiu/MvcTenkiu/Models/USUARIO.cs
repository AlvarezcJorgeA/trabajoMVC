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
    using System.Web.Security;
    
    public partial class USUARIO : MembershipUser 
    {
        public USUARIO()
        {
            this.AMIGO = new HashSet<AMIGO>();
            this.VEHICULO = new HashSet<VEHICULO>();
        }
    
        public long US_ID { get; set; }
        public string US_NOMBRE { get; set; }
        public string US_APELLIDO { get; set; }
        public string US_TELEFONO { get; set; }
        public string US_CORREO { get; set; }
        public string US_CONTRAS { get; set; }
        public string US_ALIAS { get; set; }
        public Nullable<System.DateTime> US_FCREACION { get; set; }
        public Nullable<System.DateTime> US_ULTLOG { get; set; }
        public byte[] US_AVATAR { get; set; }
        public Nullable<System.DateTime> US_FNAC { get; set; }
        public string US_NACIONAL { get; set; }
        public string US_ESTADO { get; set; }
        public Nullable<bool> US_VISIBLE { get; set; }
    
        public virtual ICollection<AMIGO> AMIGO { get; set; }
        public virtual ICollection<VEHICULO> VEHICULO { get; set; }
    }
}