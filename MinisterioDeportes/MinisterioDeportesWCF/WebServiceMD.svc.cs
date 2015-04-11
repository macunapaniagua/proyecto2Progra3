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
        public void AgregarPlanRutina(plan_rutina planRutina)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.plan_rutina.Add(planRutina);
            modeloMinisterio.SaveChanges();
        }

        public void EliminarPlanRutina(plan_rutina planRutina)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.plan_rutina.Remove(planRutina);
            modeloMinisterio.SaveChanges();
        }

        public void EditarPlanRutina(plan_rutina planRutina)
        {
           
        }
        public void ObtenerPlanRutina()
        {
            
        }
        #endregion

        #region usuario
        public void AgregarUsuario(usuario usuario)
        {
            RespuestaError respuesta = new RespuestaError();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                usuario usuarioExiste = modeloMinisterio.usuario.FirstOrDefault(x => x.usuario1 == usuario.usuario1);
                if (usuarioExiste != null)
                {
                    respuesta.MensajeError = "El usuario ya existe";
                    return;
                }
                modeloMinisterio.usuario.Add(usuario);
                modeloMinisterio.SaveChanges();
            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.ToString();               
            }
            
            
        }

        public void EliminarUsuario(usuario usuario)
        {
            MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
            modeloMinisterio.usuario.Remove(usuario);
            modeloMinisterio.SaveChanges();
        }

        public void EditarUsuario(usuario usuario)
        {
           
        }
        public List<bool> ValidarUsuario(usuario usuario)
        {
            RespuestaError respuesta = new RespuestaError();
            List<bool> listaRespuesta=new List<bool>();
            try
            {
                MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel modeloMinisterio = new MinisterioDeportesAccesoADatos.MinisterioDeportesEntityDataModel();
                var md5 = modeloMinisterio.Database.SqlQuery<string>("select convert(varchar(32),HashBytes('MD5','@password'),2)",
                     new object[] { usuario.contrasenia }).First();
                usuario usuarioExiste = modeloMinisterio.usuario.FirstOrDefault(x => x.usuario1 == usuario.usuario1 && x.contrasenia == md5);

                if (usuarioExiste != null)
                {
                    //respuesta.MensajeError = "El usuario y la contrasenia no coinciden";
                    listaRespuesta.Add(false);
                    listaRespuesta.Add(false);

                    respuesta.HayError = true;
                }
                else
                {
                    listaRespuesta.Add(true);
                    listaRespuesta.Add(usuario.es_admi);
                }              
                

            }
            catch (Exception e)
            {
                respuesta.MensajeError = e.ToString();
                respuesta.HayError = false;
            }
            return listaRespuesta ;
        }
        #endregion
      
    }
}
