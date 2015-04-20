using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MinisterioDeportesWCF.Entidades
{
    [DataContract]
    public class AsociacionesDTO
    {
        public AsociacionesDTO(List<int> pIds, List<String> pNombres)
        {
            ids = pIds;
            nombres = pNombres;
        }

        public AsociacionesDTO(List<int> pIds, List<String> pNombres, List<int> pIdsNoAsociados, List<String> pNombresNoAsociados)
        {
            ids = pIds;
            nombres = pNombres;
            idsNoAsociados = pIdsNoAsociados;
            nombresNoAsociados = pNombresNoAsociados;
        }

        [DataMember]
        public List<int> ids { get; set; }

        [DataMember]
        public List<String> nombres { get; set; }

        [DataMember]
        public List<int> idsNoAsociados { get; set; }

        [DataMember]
        public List<String> nombresNoAsociados { get; set; }
    }
}