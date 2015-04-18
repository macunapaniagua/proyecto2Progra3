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
        # region Login

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
                var md5 = modeloMinisterio.Database.SqlQuery<string>("select convert(varchar(32),HashBytes('MD5', '" +
                usuario.password + "'),2)").First();
                persona persona = modeloMinisterio.persona.FirstOrDefault(x => x.cedula.Equals(usuario.cedula) && x.password.Equals(md5));
                if (persona != null)
                {
                    personaExiste = new PersonaDTO(persona);
                }
            }
            catch (Exception e) { }
            return personaExiste;
        }

        #endregion

        #region Deporte

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

        /// <summary>
        /// Delete a Sport from webservice
        /// </summary>
        /// <param name="pDeporte"></param>
        /// <returns></returns>
        public String EliminarDeporte(DeporteDTO pDeporte)
        {
            String respuesta = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                deporte deporteEliminar = modeloMinisterio.deporte.SingleOrDefault(x => x.id == pDeporte.Id);
                if (deporteEliminar == null)
                {
                    respuesta = "No se ha encontrado el elemento que desea eliminar en la base de datos";
                }
                else
                {
                    modeloMinisterio.deporte.Remove(deporteEliminar);
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
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                deporte deporteEditar = modeloMinisterio.deporte.SingleOrDefault(x => x.id == pDeporte.Id);
                if (deporteEditar == null)
                {
                    respuesta = "No se ha encontrado el elemento que desea editar en la base de datos";
                }
                else
                {
                    deporteEditar.descripcion = pDeporte.Descripcion;
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
            List<DeporteDTO> listaDeportes = new List<DeporteDTO>();

            if (filtro == null || filtro.Equals(""))
            {
                List<deporte> lista = modeloMinisterio.deporte.Where(p => true).ToList();
                foreach (deporte deporteActual in lista)
                {
                    listaDeportes.Add(new DeporteDTO(deporteActual));
                }

            }
            else
            {
                List<deporte> lista = modeloMinisterio.deporte.Where(p => p.descripcion.ToLower().Contains(filtro)).ToList();
                foreach (deporte deporteActual in lista)
                {
                    listaDeportes.Add(new DeporteDTO(deporteActual));
                }
            }
            return listaDeportes;
        }

        #endregion

        #region Rutina

        /// <summary>
        /// Agrega una nueva rutina a la base de datos
        /// </summary>
        /// <param name="pRutina"></param>
        /// <returns></returns>
        public String AgregarRutina(RutinaDTO pRutina)
        {
            String respuesta = null;
            try
            {
                rutina nuevaRutina = new rutina();
                nuevaRutina.id = pRutina.id;
                nuevaRutina.nombre = pRutina.nombre;
                nuevaRutina.detalles = pRutina.detalles;

                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                modeloMinisterio.rutina.Add(nuevaRutina);
                modeloMinisterio.SaveChanges();
            }
            catch (Exception e)
            {
                respuesta = e.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Actualiza una rutina en el sistema
        /// </summary>
        /// <param name="pRutina"></param>
        /// <returns></returns>
        public String ActualizarRutina(RutinaDTO pRutina)
        {
            String respuesta = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                rutina rutinaEditar = modeloMinisterio.rutina.SingleOrDefault(x => x.id == pRutina.id);
                if (rutinaEditar == null)
                {
                    respuesta = "No se ha encontrado el elemento que desea editar en la base de datos";
                }
                else
                {
                    rutinaEditar.nombre = pRutina.nombre;
                    rutinaEditar.detalles = pRutina.detalles;
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
        /// Obtiene una lista de tareas segun el filtro indicado
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public List<RutinaDTO> ObtenerRutinas(string filtro = null)
        {
            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
            List<RutinaDTO> listaRutinas = new List<RutinaDTO>();
            if (filtro == null || filtro == "")
            {
                List<rutina> lista = modeloMinisterio.rutina.Where(p => true).ToList();
                foreach (rutina rutinaActual in lista)
                {
                    listaRutinas.Add(new RutinaDTO(rutinaActual));
                }
            }
            else
            {
                List<rutina> lista = modeloMinisterio.rutina.Where(p => p.nombre.ToLower().Contains(filtro)).ToList();
                foreach (rutina rutinaActual in lista)
                {
                    listaRutinas.Add(new RutinaDTO(rutinaActual));
                }
            }
            return listaRutinas;
        }

        /// <summary>
        /// Elimina una rutina de la base de datos
        /// </summary>
        /// <param name="pRutina"></param>
        /// <returns></returns>
        public String EliminarRutina(RutinaDTO pRutina)
        {
            String respuesta = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                rutina rutinaEliminar = modeloMinisterio.rutina.SingleOrDefault(x => x.id == pRutina.id);
                if (rutinaEliminar == null)
                {
                    respuesta = "No se ha encontrado el elemento que desea eliminar en la base de datos";
                }
                else
                {
                    modeloMinisterio.rutina.Remove(rutinaEliminar);
                    modeloMinisterio.SaveChanges();
                }
            }
            catch (Exception e)
            {

                respuesta = e.Message;
            }
            return respuesta;
        }

        #endregion

        #region Participante

        /// <summary>
        /// Agrega una nueva persona a la base de datos
        /// </summary>
        /// <param name="pPersona"></param>
        /// <returns></returns>
        public String AgregarPersona(PersonaDTO pPersona)
        {
            String respuesta = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                persona usuarioExiste = modeloMinisterio.persona.FirstOrDefault(x => x.cedula.ToLower().Equals(pPersona.cedula));
                if (usuarioExiste != null)
                {
                    respuesta = "El usuario ya existe en el sistema";
                }
                else
                {
                    // Convierte el password a insertar en MD5
                    String passwordMD5 = modeloMinisterio.Database.SqlQuery<String>("select convert(" +
                                         "varchar(32),HashBytes('MD5', '" + pPersona.password + "'),2)").First();

                    persona nuevaPersona = new persona()
                    {
                        nombre = pPersona.nombre,
                        apellido = pPersona.apellido1,
                        apellido2 = pPersona.apellido2,
                        cedula = pPersona.cedula,
                        password = passwordMD5.ToString(),
                        is_admin = pPersona.isAdmin,
                        email = pPersona.email
                    };

                    modeloMinisterio.persona.Add(nuevaPersona);
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
        /// Elimina una participante de la base de datos
        /// </summary>
        /// <param name="pPersona"></param>
        /// <returns></returns>
        public string EliminarPersona(PersonaDTO pPersona)
        {
            String respuesta = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                persona personaEliminar = modeloMinisterio.persona.SingleOrDefault(x => x.cedula.ToLower().Equals(pPersona.cedula));
                if (personaEliminar == null)
                {
                    respuesta = "No se ha encontrado el elemento que desea eliminar en la base de datos";
                }
                else
                {
                    modeloMinisterio.persona.Remove(personaEliminar);
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
        /// Actualiza la informacion de un usuario
        /// </summary>
        /// <param name="pPersona"></param>
        /// <returns></returns>
        public string ActualizarPersona(PersonaDTO pPersona)
        {
            String respuesta = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                persona usuarioExiste = modeloMinisterio.persona.FirstOrDefault(x => x.cedula.ToLower().Equals(pPersona.cedula));
                if (usuarioExiste == null)
                {
                    respuesta = "No se ha encontrado el elemento que desea editar en la base de datos";
                }
                else
                {
                    // Convierte el password a insertar en MD5
                    //String passwordMD5 = modeloMinisterio.Database.SqlQuery<string>("select convert(" +
                    //                     "varchar(32),HashBytes('MD5', '" + pPersona.password + "'),2)").First();

                    usuarioExiste.nombre = pPersona.nombre;
                    usuarioExiste.apellido = pPersona.apellido1;
                    usuarioExiste.apellido2 = pPersona.apellido2;
                    usuarioExiste.cedula = pPersona.cedula;
                    //                  usuarioExiste.password = pPersona.password;
                    usuarioExiste.is_admin = pPersona.isAdmin;
                    usuarioExiste.email = pPersona.email;

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
        /// Obtienela lista de todos los usuarios en el sistema
        /// </summary>
        /// <param name="pFiltro"></param>
        /// <returns></returns>
        public List<PersonaDTO> ObtenerParticipantes(String pFiltro = null)
        {
            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
            List<PersonaDTO> listaPersonas = new List<PersonaDTO>();
            if (pFiltro == null || pFiltro == "")
            {
                List<persona> lista = modeloMinisterio.persona.Where(p => true).ToList();
                foreach (persona personaActual in lista)
                {
                    listaPersonas.Add(new PersonaDTO(personaActual));
                }
            }
            else
            {
                List<persona> lista = modeloMinisterio.persona.Where(p => p.nombre.ToLower().Contains(pFiltro)).ToList();
                foreach (persona personaActual in lista)
                {
                    listaPersonas.Add(new PersonaDTO(personaActual));
                }
            }
            return listaPersonas;
        }

        #endregion




        #region planRutina

        public string AgregarPlanRutina(PlanDTO planRutina)
        {
            throw new NotImplementedException();
        }

        public string EliminarPlanRutina(PlanDTO planRutina)
        {
            throw new NotImplementedException();
        }

        public string EditarPlanRutina(PlanDTO planRutina)
        {
            throw new NotImplementedException();
        }

        public List<PlanDTO> ObtenerPlanes(String filtro = null)
        {
            return new List<PlanDTO>();
        }





        //////public String AgregarPlanRutina(plan planRutina)
        //////{
        //////    RespuestaError respuesta = new RespuestaError();
        //////    try
        //////    {
        //////        MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
        //////        modeloMinisterio.plan.Add(planRutina);
        //////        modeloMinisterio.SaveChanges();
        //////        respuesta.MensajeError = null;
        //////    }
        //////    catch (Exception e)
        //////    {
        //////        respuesta.MensajeError = e.ToString();
        //////        respuesta.HayError = false;
        //////    }
        //////    return respuesta.MensajeError;
        //////}
        //////public String EliminarPlanRutina(plan planRutina)
        //////{
        //////    RespuestaError respuesta = new RespuestaError();
        //////    try
        //////    {
        //////        MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
        //////        modeloMinisterio.plan.Remove(planRutina);
        //////        modeloMinisterio.SaveChanges();
        //////        respuesta.MensajeError = null;
        //////    }
        //////    catch (Exception e)
        //////    {

        //////        respuesta.MensajeError = e.Message;
        //////    }
        //////    return respuesta.MensajeError;
        //////}
        //////public String EditarPlanRutina(plan planRutina)
        //////{
        //////    return this.AgregarPlanRutina(planRutina);
        //////}


        ////////public List<plan> ObtenerPlanes(string filtro = null)
        ////////{
        ////////    MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
        ////////    List<plan> lista;

        ////////    if (filtro == null)
        ////////    {
        ////////        lista = modeloMinisterio.plan.Select(p => p).ToList();
        ////////    }
        ////////    else
        ////////    {

        ////////        lista = modeloMinisterio.plan.Where(p => p.nombre.ToLower().Contains(filtro)).ToList();
        ////////    }
        ////////    return lista;
        ////////}

        #endregion

    }
}
