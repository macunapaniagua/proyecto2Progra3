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
    
    public partial class usuario
    {
        public int usuario1 { get; set; }
        public string contrasenia { get; set; }
        public bool es_admi { get; set; }
    
        public virtual persona persona { get; set; }
    }
}