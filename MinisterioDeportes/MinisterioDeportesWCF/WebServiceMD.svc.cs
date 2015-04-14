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
                respuesta.MensajeError = null;
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
            List<deporte> lista;

            if (filtro==null)
            {
                lista= modeloMinisterio.deporte.Select(p => p).ToList();
            }else
	        {

                lista = modeloMinisterio.deporte.Where(p=>p.descripcion.ToLower().Contains(filtro)).ToList();
	        }
            return lista;
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

        public String EliminarPersona(persona persona)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                modeloMinisterio.persona.Remove(persona);
                modeloMinisterio.SaveChanges();
                respuesta.MensajeError = null;
            }
            catch (Exception e)
            {

                respuesta.MensajeError = e.Message;
            }
            return respuesta.MensajeError;
        }

        public String EditarPersona(persona persona)
        {
            return this.AgregarPersona(persona);
        }

        public List<persona> ObtenerPersona(String filtro =null)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            List<persona> lista;

            if (filtro == null)
            {
                lista = modeloMinisterio.persona.Select(p => p).ToList();
            }
            else
            {
                lista = modeloMinisterio.persona.Where(p => p.cedula.Equals(Convert.ToInt16(filtro))).ToList();
            }
            return lista;
        }

        public PersonaDTO ValidarUsuario(PersonaDTO usuario)
        {
            PersonaDTO personaExiste = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                var md5 = modeloMinisterio.Database.SqlQuery<string>("select convert(varchar(32),HashBytes('MD5','@password'),2)",
                     new object[] { usuario.password }).First();
                persona persona= modeloMinisterio.persona.FirstOrDefault(x => x.cedula == usuario.cedula && x.password == md5);
                if (persona!=null)
                {
                    personaExiste = new PersonaDTO(persona);
                }

            }
            catch (Exception e) { }
            return personaExiste;
        }

        #endregion

        #region rutina 
        public String AgregarRutina(rutina rutina)
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
            return respuesta.MensajeError;
        }

        public String EliminarRutina(rutina rutina)
        { 
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                modeloMinisterio.rutina.Remove(rutina);
                modeloMinisterio.SaveChanges();
                respuesta.MensajeError = null;
            }
            catch (Exception e)
            {

                respuesta.MensajeError = e.Message;
            }
            return respuesta.MensajeError;

        }

        public String EditarRutina(rutina rutina)
        {
           return this.AgregarRutina(rutina);
        }

        public List<rutina> ObtenerRutina(string filtro =null)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            List<rutina> lista;

            if (filtro == null)
            {
                lista = modeloMinisterio.rutina.Select(p => p).ToList();
            }
            else
            {

                lista = modeloMinisterio.rutina.Where(p => p.nombre.ToLower().Contains(filtro)).ToList();
            }
            return lista;
        }
        #endregion

        #region planRutina
        public String AgregarPlanRutina(plan planRutina)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                modeloMinisterio.plan.Add(planRutina);
                modeloMinisterio.SaveChanges();
                respuesta.MensajeError = null;
            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.ToString();
                respuesta.HayError = false;
            }
            return respuesta.MensajeError;
        }
        public String EliminarPlanRutina(plan planRutina)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                modeloMinisterio.plan.Remove(planRutina);
                modeloMinisterio.SaveChanges();
                respuesta.MensajeError = null;
            }
            catch (Exception e)
            {

                respuesta.MensajeError = e.Message;
            }
            return respuesta.MensajeError;
        }
        public String EditarPlanRutina(plan planRutina)
        {
            return  this.AgregarPlanRutina(planRutina);
        }
        public List<plan> ObtenerPlanRutina(string filtro=null)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            List<plan> lista;

            if (filtro == null)
            {
                lista = modeloMinisterio.plan.Select(p => p).ToList();
            }
            else
            {

                lista = modeloMinisterio.plan.Where(p => p.descripcion.ToLower().Contains(filtro)).ToList();
            }
            return lista;
        }
        #endregion
    }
}
