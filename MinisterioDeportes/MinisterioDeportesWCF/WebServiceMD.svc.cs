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

        public string AgregarPlan(PlanDTO pPlan)
        {
            String respuesta = null;
            try
            {
                plan nuevoPlan = new plan()
                {
                    nombre = pPlan.nombre,
                    detalles = pPlan.detalles
                };

                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                modeloMinisterio.plan.Add(nuevoPlan);
                modeloMinisterio.SaveChanges();
            }
            catch (Exception e)
            {
                respuesta = e.Message;
            }
            return respuesta;
        }

        public string EliminarPlan(PlanDTO pPlan)
        {
            String respuesta = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                plan planEliminar = modeloMinisterio.plan.SingleOrDefault(x => x.id == pPlan.id);
                if (planEliminar == null)
                {
                    respuesta = "No se ha encontrado el elemento que desea eliminar en la base de datos";
                }
                else
                {
                    modeloMinisterio.plan.Remove(planEliminar);
                    modeloMinisterio.SaveChanges();
                }
            }
            catch (Exception e)
            {
                respuesta = e.Message;
            }
            return respuesta;
        }

        public string EditarPlan(PlanDTO pPlan)
        {
            String respuesta = null;
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                plan planEditar = modeloMinisterio.plan.SingleOrDefault(x => x.id == pPlan.id);
                if (planEditar == null)
                {
                    respuesta = "No se ha encontrado el elemento que desea editar en la base de datos";
                }
                else
                {
                    planEditar.nombre = pPlan.nombre;
                    planEditar.detalles = pPlan.detalles;
                    modeloMinisterio.SaveChanges();
                }
            }
            catch (Exception e)
            {
                respuesta = e.Message;
            }
            return respuesta;
        }

        public List<PlanDTO> ObtenerPlanes(String filtro = null)
        {
            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
            List<PlanDTO> listaPlanes = new List<PlanDTO>();
            if (filtro == null || filtro == "")
            {
                List<plan> lista = modeloMinisterio.plan.Where(p => true).ToList();
                foreach (plan planActual in lista)
                {
                    listaPlanes.Add(new PlanDTO(planActual));
                }
            }
            else
            {
                List<plan> lista = modeloMinisterio.plan.Where(p => p.nombre.ToLower().Contains(filtro)).ToList();
                foreach (plan planActual in lista)
                {
                    listaPlanes.Add(new PlanDTO(planActual));
                }
            }
            return listaPlanes;
        }

        #endregion

        #region PlanRutina

        /// <summary>
        /// Obtiene la lista de los planes existentes (id y nombre unicamente)
        /// </summary>
        /// <returns></returns>
        public AsociacionesDTO ObtenerListaPlanes()
        {
            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();            
            List<int> idPlanes = new List<int>();
            List<String> nombrePlanes = new List<string>();
            List<plan> planes = modeloMinisterio.plan.Where(p => true).ToList();
            foreach (plan planActual in planes)
            {
                idPlanes.Add(planActual.id);
                nombrePlanes.Add(planActual.nombre);
            }
            AsociacionesDTO resultadoBusqueda = new AsociacionesDTO(idPlanes, nombrePlanes);
            return resultadoBusqueda;
        }

        /// <summary>
        /// Obtiene todas las rutinas asociadas al plan indicado
        /// </summary>
        /// <param name="pIdPlan"></param>
        /// <returns></returns>
        public AsociacionesDTO ObtenerListaRutinasPlan(int pIdPlan)
        {
            List<int> idRutinasAsociadas = new List<int>();
            List<int> idRutinasNoAsociadas = new List<int>();
            List<String> nombreRutinasAsociadas = new List<string>();
            List<String> nombreRutinasNoAsociadas = new List<string>();

            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
            
            // Obtiene todas las rutinas asociadas y no asociadas al plan con el id solicitado
            List<rutina> rutinasAsociadas = modeloMinisterio.rutina.Where(r => r.plan.FirstOrDefault(p => p.id == pIdPlan) != null).ToList();
            List<rutina> rutinasNoAsociadas = modeloMinisterio.rutina.Where(r => r.plan.FirstOrDefault(p => p.id == pIdPlan) == null).ToList();

            foreach (rutina rutinaAsociada in rutinasAsociadas)
            {
                idRutinasAsociadas.Add(rutinaAsociada.id);
                nombreRutinasAsociadas.Add(rutinaAsociada.nombre);
            }

            foreach (rutina rutinaNoAsociada in rutinasNoAsociadas)
            {
                idRutinasNoAsociadas.Add(rutinaNoAsociada.id);
                nombreRutinasNoAsociadas.Add(rutinaNoAsociada.nombre);
            }

            AsociacionesDTO resultadoBusqueda = new AsociacionesDTO(idRutinasAsociadas, 
                                                                    nombreRutinasAsociadas, 
                                                                    idRutinasNoAsociadas, 
                                                                    nombreRutinasNoAsociadas);
            return resultadoBusqueda;
        }

        /// <summary>
        /// Agrega una rutina a un plan
        /// </summary>
        /// <param name="pIdUsuario"></param>
        /// <param name="pIdDeporte"></param>
        /// <returns></returns>
        public bool agregarRutinaAPlan(int pIdPlan, int pIdRutina)
        {
            try
            {
                MinisterioDeportesEntityDataModel model = new MinisterioDeportesEntityDataModel();
                plan planSelected = model.plan.FirstOrDefault(p => p.id == pIdPlan);
                if (planSelected == null)
                {
                    return false;
                }
                else
                {
                    rutina rutinaSelected = model.rutina.FirstOrDefault(r => r.id == pIdRutina);
                    if (rutinaSelected == null)
                    {
                        return false;
                    }
                    else
                    {
                        planSelected.rutina.Add(rutinaSelected);
                        model.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Remueve una rutina de un plan
        /// </summary>
        /// <param name="pIdPlan"></param>
        /// <param name="pIdRutina"></param>
        /// <returns></returns>
        public bool removerRutinaDePlan(int pIdPlan, int pIdRutina)
        {
            try
            {
                MinisterioDeportesEntityDataModel model = new MinisterioDeportesEntityDataModel();
                plan planSelected = model.plan.FirstOrDefault(p => p.id == pIdPlan);
                if (planSelected == null)
                {
                    return false;
                }
                else
                {
                    rutina rutinaSelected = model.rutina.FirstOrDefault(r => r.id == pIdRutina);
                    if (rutinaSelected == null)
                    {
                        return false;
                    }
                    else
                    {
                        planSelected.rutina.Remove(rutinaSelected);
                        model.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region Deportes de Usuario

        /// <summary>
        /// Obtiene la lista de los deportes asociados y no asociados para un determinado usuario
        /// </summary>
        /// <param name="pIdUsuario"></param>
        /// <returns></returns>
        public AsociacionesDTO ObtenerListaDeportesPorUsuario(String pIdUsuario)
        {
            List<int> idDeportesAsociados = new List<int>();
            List<int> idDeportesNoAsociados = new List<int>();
            List<String> nombreDeportesAsociados = new List<string>();
            List<String> nombreDeportesNoAsociados = new List<string>();

            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
            // Obtiene todos los deportes asociadas y no asociadas al usuario con el id solicitado
            List<deporte> deportesAsociados = modeloMinisterio.deporte.Where(d => d.persona_deporte.FirstOrDefault(pd => pd.persona.Equals(pIdUsuario)) != null).ToList();
            List<deporte> deportesNoAsociados = modeloMinisterio.deporte.Where(d => d.persona_deporte.FirstOrDefault(pd => pd.persona.Equals(pIdUsuario)) == null).ToList();

            foreach (deporte deporteAsociado in deportesAsociados)
            {
                idDeportesAsociados.Add(deporteAsociado.id);
                nombreDeportesAsociados.Add(deporteAsociado.descripcion);
            }

            foreach (deporte deporteNoAsociado in deportesNoAsociados)
            {
                idDeportesNoAsociados.Add(deporteNoAsociado.id);
                nombreDeportesNoAsociados.Add(deporteNoAsociado.descripcion);
            }

            AsociacionesDTO resultadoBusqueda = new AsociacionesDTO(idDeportesAsociados,
                                                                    nombreDeportesAsociados,
                                                                    idDeportesNoAsociados,
                                                                    nombreDeportesNoAsociados);
            return resultadoBusqueda;
        }

        /// <summary>
        /// Agrega un deporte a un usuario
        /// </summary>
        /// <param name="pIdPlan"></param>
        /// <param name="pIdRutina"></param>
        /// <returns></returns>
        public bool agregarDeprteAUsuario(String pIdUsuario, int pIdDeporte)
        {
            try
            {
                MinisterioDeportesEntityDataModel model = new MinisterioDeportesEntityDataModel();
                persona personaSeleccionada = model.persona.FirstOrDefault(p => p.cedula.Equals(pIdUsuario));
                if (personaSeleccionada == null)
                {
                    return false;
                }
                else
                {
                    deporte deporteSeleccionado = model.deporte.FirstOrDefault(d => d.id == pIdDeporte);
                    if (deporteSeleccionado == null)
                    {
                        return false;
                    }
                    else
                    {
                        persona_deporte nuevaRelacion = new persona_deporte(){
                            deporte = pIdDeporte,
                            persona = pIdUsuario,
                            id_plan = null                            
                        };

                        personaSeleccionada.persona_deporte.Add(nuevaRelacion);
                        model.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Remueve un deportes de un un usuario
        /// </summary>
        /// <param name="pIdUsuario"></param>
        /// <param name="pIdDeporte"></param>
        /// <returns></returns>
        public bool removerDeporteDeUsuario(String pIdUsuario, int pIdDeporte)
        {
            try
            {
                MinisterioDeportesEntityDataModel model = new MinisterioDeportesEntityDataModel();
                persona_deporte personaDeporteSeleccionado = model.persona_deporte.FirstOrDefault(pd => pd.persona.Equals(pIdUsuario) && pIdDeporte == pd.deporte);
                if (personaDeporteSeleccionado == null)
                {
                    return false;
                }
                else
                {
                    model.persona_deporte.Remove(personaDeporteSeleccionado);
                    model.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region plan de deporte
        public AsociacionesDTO ObtenerListaPlanesPorDeporte(int id)
        {
            List<int> idPlanAsociado = new List<int>();
            List<int> idPlanesNoAsociados = new List<int>();
            List<String> nombrePlanAsociado = new List<string>();
            List<String> nombrePlanesNoAsociados = new List<string>();
            

            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
            List<plan> PlanAsociado  = modeloMinisterio.plan.Where(d => d.persona_deporte.FirstOrDefault(pd => pd.deporte.Equals(id)) != null).ToList();
            List<plan> PlanesNoAsocidos = modeloMinisterio.plan.Where(d => d.persona_deporte.FirstOrDefault(pd => pd.deporte.Equals(id)) == null).ToList();
            foreach (plan plan in PlanAsociado)
            {
                idPlanAsociado.Add(plan.id);
                nombrePlanAsociado.Add(plan.nombre);
            }

            foreach (plan plan in PlanesNoAsocidos)
            {
                idPlanesNoAsociados.Add(plan.id);
                nombrePlanesNoAsociados.Add(plan.nombre);
            }

            return new AsociacionesDTO(idPlanAsociado, nombrePlanAsociado, idPlanesNoAsociados, nombrePlanesNoAsociados);
        }
        public bool AgregarPlanADeporteUsuario(string id_usuario, int id_deporte, int id_plan)
        {
            
            try
            {
                MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
                persona_deporte personaDeporteEditar = modeloMinisterio.persona_deporte.SingleOrDefault(x => x.deporte == id_deporte && x.persona== id_usuario);
                if (personaDeporteEditar == null)
                {
                    return false;
                }
                else
                {
                    personaDeporteEditar.persona = id_usuario;
                    personaDeporteEditar.deporte = id_deporte;
                    personaDeporteEditar.id_plan = id_plan;
                    modeloMinisterio.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool RemovePlanADeporteUsuario(string id_usuario, int id_deporte)
        {
            try
            {
                MinisterioDeportesEntityDataModel model = new MinisterioDeportesEntityDataModel();
                persona_deporte personaDeporteSeleccionado = model.persona_deporte.FirstOrDefault(pd => pd.persona.Equals(id_usuario) && pd.deporte.Equals(id_deporte));
                if (personaDeporteSeleccionado == null)
                {
                    return false;
                }
                else
                {
                    personaDeporteSeleccionado.id_plan = null;
                    model.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion

        #region estadisticas

        public int ObtenerCantidadPersonasPorDeporte(int id_deporte)
        {
            MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesEntityDataModel();
            List<persona> cantidadPersonas = modeloMinisterio.persona.Where(d => d.persona_deporte.FirstOrDefault(pd => pd.deporte.Equals(id_deporte)) != null).ToList();

            return cantidadPersonas.Count;

        }

        #endregion
    }
}
