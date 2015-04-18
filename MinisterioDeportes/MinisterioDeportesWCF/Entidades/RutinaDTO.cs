using MinisterioDeportesAccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MinisterioDeportesWCF.Entidades
{
    [DataContract]
    public class RutinaDTO
    {
        public RutinaDTO(rutina rutina)
        {
            this.id = Convert.ToInt16(rutina.id);
            this.nombre = rutina.nombre;
            this.detalles = rutina.detalles;         
        }

        [DataMember(Order = 0)]
        public Int16 id { get; set; }

        [DataMember(Order = 1)]
        public string nombre { get; set; }

        [DataMember(Order = 2)]
        public string detalles { get; set; }
    }
}