using MinisterioDeportesAccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MinisterioDeportesWCF.Entidades
{
    [DataContract]
    public class DeporteDTO
    {
        public DeporteDTO(deporte deporte)
    {
        this.descripcion = deporte.descripcion;
        this.id = Convert.ToInt16(deporte.ID);
    }
   
    [DataMember]
    public string descripcion { get; set; }
    [DataMember]
    public Int16 id { get; set; }
    
    }
}