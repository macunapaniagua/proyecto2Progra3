//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MinisterioDeportesAccesoADatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class persona
    {
        public persona()
        {
            this.deporte = new HashSet<deporte>();
        }
    
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string apellido2 { get; set; }
    
        public virtual usuario usuario { get; set; }
        public virtual ICollection<deporte> deporte { get; set; }
    }
}