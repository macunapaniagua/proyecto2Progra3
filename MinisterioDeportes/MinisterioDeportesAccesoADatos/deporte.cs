//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MinisterioDeportesAccesoADatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class deporte
    {
        public deporte()
        {
            this.persona = new HashSet<persona>();
            this.plan = new HashSet<plan>();
        }
    
        public int ID { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<persona> persona { get; set; }
        public virtual ICollection<plan> plan { get; set; }
    }
}
