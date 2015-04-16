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
        /// <summary>
        /// Constructores
        /// </summary>
        /// <param name="pNombreDeporte"></param>
        public DeporteDTO(String pNombreDeporte)
        {
            Descripcion = pNombreDeporte;
        }

        public DeporteDTO(deporte deporte)
        {
            this.Id = Convert.ToInt16(deporte.ID);
            this.Descripcion = deporte.descripcion;            
        }

        [DataMember]
        public Int16 Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }
        
    }
}