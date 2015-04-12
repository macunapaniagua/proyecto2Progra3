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
                this.descripcion = rutina.descripcion;
                this.nombre = rutina.nombre;
                this.id = Convert.ToInt16(rutina.id);

            }

            [DataMember]
            public string descripcion { get; set; }
            [DataMember]
            public string nombre { get; set; }
            [DataMember]
            public Int16 id { get; set; }

       
    }
}