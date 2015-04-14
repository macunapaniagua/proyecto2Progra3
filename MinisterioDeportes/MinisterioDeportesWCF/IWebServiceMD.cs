using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MinisterioDeportesAccesoADatos;
using MinisterioDeportesWCF.Entidades;

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
        PersonaDTO ValidarUsuario(PersonaDTO usuario);

        [OperationContract]
        String AgregarPersona(persona persona);
        [OperationContract]
        String EliminarPersona(persona persona);
        [OperationContract]
        String EditarPersona(persona persona);
        [OperationContract]
        //creo que deberia ser list y no void
        List<persona> ObtenerPersona(String filtro);

        [OperationContract]
        String AgregarRutina(rutina rutina);
        [OperationContract]
        String EliminarRutina(rutina rutina);
        [OperationContract]
        String EditarRutina(rutina rutina);
        [OperationContract]
        //creo que deberia ser list y no void
        List<rutina> ObtenerRutina(String filtro);

        [OperationContract]
        String AgregarPlanRutina(plan planRutina);
        [OperationContract]
        String EliminarPlanRutina(plan planRutina);
        [OperationContract]
        String EditarPlanRutina(plan planRutina);
        [OperationContract]
        //creo que deberia ser list y no void
        List<plan> ObtenerPlanRutina(String filtro);
      
        
    }


}
