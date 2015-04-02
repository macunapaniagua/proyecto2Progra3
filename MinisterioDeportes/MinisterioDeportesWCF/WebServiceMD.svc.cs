using MinisterioDeportesAccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MinisterioDeportesWCF
{

    public class WebServiceMD : IWebServiceMD
    {

        #region deporte

        public bool AgregarDeporte(deporte deporte)
        {
            throw new NotImplementedException();
        }

        public void EliminarDeporte(deporte deporte)
        {
            throw new NotImplementedException();
        }

        public void EditarDeporte(deporte deporte)
        {
            throw new Exception("hola mario!!! ");
        }
        public void ObtenerDeporte()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region persona
        public bool AgregarPersona(persona persona)
        {
            throw new NotImplementedException();
        }

        public void EliminarPersona(persona persona)
        {
            throw new NotImplementedException();
        }

        public void EditarPersona(persona persona)
        {
            throw new NotImplementedException();
        }
        public void ObtenerPersona()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region rutina 
        public void AgregarRutina()
        {
            throw new NotImplementedException();
        }

        public void EliminarRutina()
        {
            throw new NotImplementedException();
        }

        public void EditarRutina()
        {
            throw new NotImplementedException();
        }

        public void ObtenerRutina()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region planRutina
        public void AgregarPlanRutina()
        {
            throw new NotImplementedException();
        }

        public void EliminarPlanRutina()
        {
            throw new NotImplementedException();
        }

        public void EditarPlanRutina()
        {
            throw new NotImplementedException();
        }
        public void ObtenerPlanRutina()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region usuario
        public void AgregarUsuario()
        {
            throw new NotImplementedException();
        }

        public void EliminarUsuario()
        {
            throw new NotImplementedException();
        }

        public void EditarUsuario()
        {
            throw new NotImplementedException();
        }
        public void ValidarUsuario()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
