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
                this.descripcion = plan.descripcion;
                this.detalles = plan.detalles;
                this.id = Convert.ToInt16(plan.ID);
            }

            [DataMember]
            public string descripcion { get; set; }
            [DataMember]
            public string detalles { get; set; }
            [DataMember]
            public Int16 id { get; set; }
    }
}