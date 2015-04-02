using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MinisterioDeportesWCF.Entidades
{
    [DataContract]
    public class RespuestaError
    {
        [DataMember]
        public bool HayError { get; set; }

        [DataMember]
        public string MensajeError { get; set; }
    }
}