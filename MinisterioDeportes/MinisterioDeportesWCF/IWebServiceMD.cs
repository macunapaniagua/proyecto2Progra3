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
        bool AgregarDeporte(deporte deporte);
        [OperationContract]
        void EliminarDeporte(deporte deporte);
        [OperationContract]
        void EditarDeporte(deporte deporte);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerDeporte();

        [OperationContract]
        bool AgregarPersona(persona persona);
        [OperationContract]
        void EliminarPersona(persona persona);
        [OperationContract]
        void EditarPersona(persona persona);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerPersona();

        [OperationContract]
        void AgregarRutina(/*rutina rutina*/);
        [OperationContract]
        void EliminarRutina(/*rutina rutina*/);
        [OperationContract]
        void EditarRutina(/*rutina rutina*/);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerRutina();

        [OperationContract]
        void AgregarPlanRutina(/*plan_rutina planRutina*/);
        [OperationContract]
        void EliminarPlanRutina(/*plan_rutina planRutina*/);
        [OperationContract]
        void EditarPlanRutina(/*plan_rutina planRutina*/);
        [OperationContract]
        //creo que deberia ser list y no void
        void ObtenerPlanRutina();

        [OperationContract]
        void AgregarUsuario(/*usuario usuario*/);
        [OperationContract]
        void EliminarUsuario(/*usuario usuario*/);
        [OperationContract]
        void EditarUsuario(/*usuario usuario*/);
        [OperationContract]
        //creo que deberia ser list y no void
        void ValidarUsuario();
    }


}
