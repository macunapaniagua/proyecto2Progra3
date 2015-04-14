using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace MovieWorld.Util
{
    public class Email
    {
        private String emisor;
        private MailMessage mensaje;
        private SmtpClient clienteSMPT;
        private NetworkCredential credenciales;

        /// <summary>
        /// Metodo constructor
        /// </summary>
        public Email(String pCorreoEmisor, String pPassword)
        {
            emisor = pCorreoEmisor;
            mensaje = new MailMessage();
            clienteSMPT = new SmtpClient("smtp.gmail.com", 587);
            credenciales = new NetworkCredential(pCorreoEmisor, pPassword);
        }

        /// <summary>
        /// Envia un mensaje a la lista de direcciones ingresada
        /// </summary>
        /// <param name="pDestinatario">Lista de direcciones</param>
        /// <param name="pSubject">Subject del correo</param>
        /// <param name="pMensaje">Mensaje a enviar</param>
        public void EnviarMensaje(List<String> pDestinatario, String pSubject, String pMensaje)
        {
            // Configuracion del Host SMTP
            clienteSMPT.EnableSsl = true;
            clienteSMPT.UseDefaultCredentials = false;
            clienteSMPT.Credentials = credenciales;

            // Convertir String a direccion de correo
            MailAddress sender = new MailAddress(emisor, "Ministerio de Deportes");
            mensaje.From = sender;
            // Agrega los destinatarios
            foreach (String destino in pDestinatario)
            {
                MailAddress correoDestino = new MailAddress(destino);
                mensaje.To.Add(correoDestino);
            }

            // Configura el mensaje que se envia                                                            
            mensaje.Subject = pSubject;
            mensaje.Body = pMensaje;

            // Se envia el correo
            clienteSMPT.Send(mensaje);
        }
    }
}
