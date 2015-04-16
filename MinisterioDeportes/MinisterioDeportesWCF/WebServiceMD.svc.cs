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
        # region login

        /// <summary>
        /// Verifica si un usuario existe en la base de datos
        /// </summary>
        /// <param name="usuario">Usuario con nombre de usuario y contraseña</param>
        /// <returns>Usuario con toda la informacion o null si no existe</returns>
        public PersonaDTO ValidarLogin(PersonaDTO usuario)
        {
            PersonaDTO personaExiste = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                var md5 = modeloMinisterio.Database.SqlQuery<string>("select convert(varchar(32),HashBytes('MD5','@password'),2)",
                     new object[] { usuario.password }).First();
                persona persona = modeloMinisterio.persona.FirstOrDefault(x => x.cedula == usuario.cedula && x.password == md5);
                if (persona != null)
                {
                    personaExiste = new PersonaDTO(persona);
                }
            }
            catch (Exception e) { }
            return personaExiste;
        }
        #endregion

        #region deporte
        /// <summary>
        /// Agrega un deporte a la base de datos
        /// </summary>
        /// <param name="pDeporte"></param>
        /// <returns></returns>
        public String AgregarDeporte(DeporteDTO pDeporte)
        {
            String respuesta;
            try
            {
                deporte nuevoDeporte = new deporte();
                nuevoDeporte.descripcion = pDeporte.Descripcion;

                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                modeloMinisterio.deporte.Add(nuevoDeporte);
                modeloMinisterio.SaveChanges();
                respuesta = null;
            }
            catch (Exception e)
            {
                respuesta = e.Message;
            }
            return respuesta;
        }

        public String EliminarDeporte(DeporteDTO pDeporte)
        {
            String respuesta = null;
            try
            {
                deporte deporteEliminado = new deporte();
                deporteEliminado.ID = pDeporte.Id;
                deporteEliminado.descripcion = pDeporte.Descripcion;

                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                if (modeloMinisterio.deporte.Remove(deporteEliminado) == null)
                {
                    respuesta = "Ha ocurrido un error a la hora de eliminar el deporte seleccionado";
                }
                else
                {
                    modeloMinisterio.SaveChanges();
                }
            }
            catch (Exception e)
            {
                respuesta = e.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Edita un deporte en la base de datos
        /// </summary>
        /// <param name="pDeporte"></param>
        /// <returns></returns>
        public String EditarDeporte(DeporteDTO pDeporte)
        {
            String respuesta = null;
            try
            {
                deporte deporteEditado = new deporte();
                deporteEditado.ID = pDeporte.Id;
                deporteEditado.descripcion = pDeporte.Descripcion;

                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                if (modeloMinisterio.deporte.Add(deporteEditado) == null)
                {
                    respuesta = "Ha ocurrido un error en la actualización del deporte";
                }
                else
                {
                    modeloMinisterio.SaveChanges();
                }
            }
            catch (Exception e)
            {
                respuesta = e.Message;
            }
            return respuesta;
        }
        
        /// <summary>
        /// Obtiene los deportes que cumplen con un filtro
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        /// 
        public List<DeporteDTO> ObtenerDeportes(string filtro = null)
        {
            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
            List<DeporteDTO> listaDeporetes = new List<DeporteDTO>();

            if (filtro == null || filtro.Equals(""))
            {
                List<deporte> lista = modeloMinisterio.deporte.Where(p => true).ToList();
                foreach (deporte deporteActual in lista)
                {
                    listaDeporetes.Add(new DeporteDTO(deporteActual));
                }

            }
            else
            {
                List<deporte> lista = modeloMinisterio.deporte.Where(p => p.descripcion.ToLower().Contains(filtro)).ToList();
                foreach (deporte deporteActual in lista)
                {
                    listaDeporetes.Add(new DeporteDTO(deporteActual));
                }
            }
            return listaDeporetes;
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

        public List<persona> ObtenerPersona(String filtro = null)
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
                respuesta.HayError = true;
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

        public List<rutina> ObtenerRutina(string filtro = null)
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
            return this.AgregarPlanRutina(planRutina);
        }
        public List<plan> ObtenerPlanRutina(string filtro = null)
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
