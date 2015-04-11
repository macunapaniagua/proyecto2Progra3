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
        public void AgregarDeporte(deporte deporte)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio  = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.deporte.Add(deporte);
            modeloMinisterio.SaveChanges();        
        }

        public void EliminarDeporte(deporte deporte)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.deporte.Remove(deporte);
            modeloMinisterio.SaveChanges();
        }

        public void EditarDeporte(deporte deporte)
        {
            
        }

        public void ObtenerDeporte()
        {
            
        }
        #endregion

        #region persona
        public void AgregarPersona(persona persona)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.persona.Add(persona);
            modeloMinisterio.SaveChanges();

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

        #endregion

        #region rutina 
        public void AgregarRutina(rutina rutina)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.rutina.Add(rutina);
            modeloMinisterio.SaveChanges();
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
        public void AgregarPlanRutina(plan planRutina)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.plan.Add(planRutina);
            modeloMinisterio.SaveChanges();
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

        #region usuario
        public void AgregarUsuario(persona usuario)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                persona usuarioExiste = modeloMinisterio.persona.FirstOrDefault(x => x.cedula == usuario.cedula);
                if (usuarioExiste != null)
                {
                    respuesta.MensajeError = "El usuario ya existe";
                    return;
                }
                modeloMinisterio.persona.Add(usuario);
                modeloMinisterio.SaveChanges();
            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.ToString();               
            }
            
            
        }

        public void EliminarUsuario(persona usuario)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.persona.Remove(usuario);
            modeloMinisterio.SaveChanges();
        }

        public void EditarUsuario(persona usuario)
        {
           
        }
        public persona ValidarUsuario(persona usuario)
        {
            RespuestaError respuesta = new RespuestaError();
            persona personaExiste=null;
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                var md5 = modeloMinisterio.Database.SqlQuery<string>("select convert(varchar(32),HashBytes('MD5','@password'),2)",
                     new object[] { usuario.password }).First();
                personaExiste = modeloMinisterio.persona.FirstOrDefault(x => x.cedula == usuario.cedula && x.password == md5);
                

                //if (usuarioExiste != null)
                //{
                //    //respuesta.MensajeError = "El usuario y la contrasenia no coinciden";
                //    listaRespuesta.Add(false);
                //    listaRespuesta.Add(false);

                //    respuesta.HayError = true;
                //}
                //else
                //{
                //    listaRespuesta.Add(true);
                //    listaRespuesta.Add(usuario.es_admi);
                //}              
                

            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.ToString();
                respuesta.HayError = false;
            }
            return personaExiste;
        }
        #endregion

    }
}
