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
        void AgregarDeporte(deporte deporte);
        [OperationContract]
        void EliminarDeporte(deporte deporte);
        [OperationContract]
        void EditarDeporte(deporte deporte);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerDeporte();

        [OperationContract]
        void AgregarPersona(persona persona);
        [OperationContract]
        void EliminarPersona(persona persona);
        [OperationContract]
        void EditarPersona(persona persona);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerPersona();

        [OperationContract]
        void AgregarRutina(rutina rutina);
        [OperationContract]
        void EliminarRutina(rutina rutina);
        [OperationContract]
        void EditarRutina(rutina rutina);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerRutina();

        [OperationContract]
        void AgregarPlanRutina(plan planRutina);
        [OperationContract]
        void EliminarPlanRutina(plan planRutina);
        [OperationContract]
        void EditarPlanRutina(plan planRutina);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerPlanRutina();

        [OperationContract]
        void AgregarUsuario(persona usuario);
        [OperationContract]
        void EliminarUsuario(persona usuario);
        [OperationContract]
        void EditarUsuario(persona usuario);
        [OperationContract]
        //creo que deberia ser list y no void
        persona ValidarUsuario(persona usuario);
    }


}
