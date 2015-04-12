using MinisterioDeportesAccesoADatos;
using MinisterioDeportesWCF.Entidades;
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
        public String AgregarDeporte(deporte deporte)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                modeloMinisterio.deporte.Add(deporte);
                modeloMinisterio.SaveChanges();
                respuesta.HayError = true;
            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.Message;
                respuesta.HayError = false;

            }
            return respuesta.MensajeError;
            
        }

        public String EliminarDeporte(deporte deporte)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                modeloMinisterio.deporte.Remove(deporte);
                modeloMinisterio.SaveChanges();
                respuesta.MensajeError = null;
            }
            catch (Exception e)
            {
                
                respuesta.MensajeError=e.Message;
            }
            return respuesta.MensajeError;
        }

        public String EditarDeporte(deporte deporte)
        {          
            return this.AgregarDeporte(deporte);
        }
        
        public List<deporte> ObtenerDeporte(String filtro=null)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            
            if (filtro==null)
            {
                return modeloMinisterio.deporte.Select(p => p).ToList();
            }else
	        {

                return modeloMinisterio.deporte.Where(p=>p.descripcion.ToLower().Contains(filtro)).ToList();
	        }
            
        }
        #endregion

        #region persona
        public String AgregarPersona(persona persona)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                persona usuarioExiste = modeloMinisterio.persona.FirstOrDefault(x => x.cedula == persona.cedula);
                if (usuarioExiste != null)
                {
                    return "El usuario ya existe";                   
                }
                modeloMinisterio.persona.Add(persona);
                modeloMinisterio.SaveChanges();
                respuesta.HayError = true;
            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.Message;
                respuesta.HayError = false;
               
            }
            return respuesta.MensajeError;
        }

        public void EliminarPersona(persona persona)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.persona.Remove(persona);
            modeloMinisterio.SaveChanges();
        }

        public void EditarPersona(persona persona)
        {
            
        }

        public void ObtenerPersona()
        {
            
        }

        public persona ValidarUsuario(persona usuario)
        {
            persona personaExiste = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                var md5 = modeloMinisterio.Database.SqlQuery<string>("select convert(varchar(32),HashBytes('MD5','@password'),2)",
                     new object[] { usuario.password }).First();
                personaExiste = modeloMinisterio.persona.FirstOrDefault(x => x.cedula == usuario.cedula && x.password == md5);
            }
            catch (Exception e) { }
            return personaExiste;
        }

        #endregion

        #region rutina 
        public Boolean AgregarRutina(rutina rutina)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                modeloMinisterio.rutina.Add(rutina);
                modeloMinisterio.SaveChanges();
                respuesta.HayError =true;
            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.ToString();
                respuesta.HayError = false;
                
            }
            return respuesta.HayError;
        }

        public void EliminarRutina(rutina rutina)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.rutina.Remove(rutina);
            modeloMinisterio.SaveChanges();
        }

        public void EditarRutina(rutina rutina)
        {
            
        }

        public void ObtenerRutina()
        {
           
        }
        #endregion

        #region planRutina
        public Boolean AgregarPlanRutina(plan planRutina)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                modeloMinisterio.plan.Add(planRutina);
                modeloMinisterio.SaveChanges();
                respuesta.HayError = true;
            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.ToString();
                respuesta.HayError = false;
            }
            return respuesta.HayError;
        }

        public void EliminarPlanRutina(plan planRutina)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.plan.Remove(planRutina);
            modeloMinisterio.SaveChanges();
        }

        public void EditarPlanRutina(plan planRutina)
        {
           
        }
        public void ObtenerPlanRutina()
        {
            
        }
        #endregion

    }
}
