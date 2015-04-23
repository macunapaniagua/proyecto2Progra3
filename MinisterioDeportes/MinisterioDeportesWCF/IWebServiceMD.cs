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
        PersonaDTO ValidarLogin(PersonaDTO usuario);


        [OperationContract]
        String AgregarDeporte(DeporteDTO deporte);
        
        [OperationContract]
        String EliminarDeporte(DeporteDTO deporte);
        
        [OperationContract]
        String EditarDeporte(DeporteDTO deporte);

        [OperationContract]
        List<DeporteDTO> ObtenerDeportes(String filtro = null);


        [OperationContract]
        String AgregarRutina(RutinaDTO pRutina);
        
        [OperationContract]
        String ActualizarRutina(RutinaDTO pRutina);

        [OperationContract]
        List<RutinaDTO> ObtenerRutinas(String filtro = null);
        
        [OperationContract]
        String EliminarRutina(RutinaDTO rutina);        


        [OperationContract]
        String AgregarPersona(PersonaDTO persona);

        [OperationContract]
        String EliminarPersona(PersonaDTO persona);
        
        [OperationContract]
        String ActualizarPersona(PersonaDTO persona);
        
        [OperationContract]
        List<PersonaDTO> ObtenerParticipantes(String filtro = null);
              

        [OperationContract]
        String AgregarPlan(PlanDTO planRutina);
        
        [OperationContract]
        String EliminarPlan(PlanDTO planRutina);
        
        [OperationContract]
        String EditarPlan(PlanDTO planRutina);
        
        [OperationContract]
        List<PlanDTO> ObtenerPlanes(String filtro = null);


        [OperationContract]
        AsociacionesDTO ObtenerListaPlanes();

        [OperationContract]
        AsociacionesDTO ObtenerListaRutinasPlan(int pIdDeporte);        

        [OperationContract]
        Boolean agregarRutinaAPlan(int pIdPlan, int pIdRutina);

        [OperationContract]
        Boolean removerRutinaDePlan(int pIdPlan, int pIdRutina);


        [OperationContract]
        AsociacionesDTO ObtenerListaDeportesPorUsuario(String pIdUsuario);

        [OperationContract]
        bool agregarDeprteAUsuario(String pIdUsuario, int pIdDeporte);

        [OperationContract]
        bool removerDeporteDeUsuario(String pIdUsuario, int pIdDeporte);

        [OperationContract]
        AsociacionesDTO ObtenerListaPlanesPorDeporte(int id);

        [OperationContract]
        Boolean AgregarPlanADeporteUsuario(string id_usuario, int id_deporte, int id_plan);

        [OperationContract]
        Boolean RemovePlanADeporteUsuario(string id_usuario, int id_deporte);

        [OperationContract]
        int ObtenerCantidadPersonasPorDeporte(int id_deporte);

    }
}
