using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MinisterioDeportesAccesoADatos;

namespace MinisterioDeportesWCF
{
    [ServiceContract]
    public interface IWebServiceMD
    {
        [OperationContract]
        String AgregarDeporte(deporte deporte);
        [OperationContract]
        String EliminarDeporte(deporte deporte);
        [OperationContract]
        String EditarDeporte(deporte deporte);
        [OperationContract]
        //creo que deberia ser list y no void
        List<deporte> ObtenerDeporte(String filtro);
        [OperationContract]
        //creo que deberia ser list y no void
        persona ValidarUsuario(persona usuario);

        [OperationContract]
        String AgregarPersona(persona persona);
        [OperationContract]
        void EliminarPersona(persona persona);
        [OperationContract]
        void EditarPersona(persona persona);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerPersona();

        [OperationContract]
        Boolean AgregarRutina(rutina rutina);
        [OperationContract]
        void EliminarRutina(rutina rutina);
        [OperationContract]
        void EditarRutina(rutina rutina);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerRutina();

        [OperationContract]
        Boolean AgregarPlanRutina(plan planRutina);
        [OperationContract]
        void EliminarPlanRutina(plan planRutina);
        [OperationContract]
        void EditarPlanRutina(plan planRutina);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerPlanRutina();
      
        
    }


}
