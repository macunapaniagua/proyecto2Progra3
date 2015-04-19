using MinisterioDeportesAccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MinisterioDeportesWCF.Entidades
{
    [DataContract]
    public class PlanDTO
    {
        public PlanDTO(plan plan)
        {
            this.id = Convert.ToInt16(plan.id);
            this.nombre = plan.nombre;
            this.detalles = plan.detalles;
        }

        [DataMember(Order = 0)]
        public Int16 id { get; set; }
        
        [DataMember(Order = 1)]
        public string nombre { get; set; }
        
        [DataMember(Order = 2)]
        public string detalles { get; set; }
    }
}