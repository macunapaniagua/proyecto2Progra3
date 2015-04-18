using MinisterioDeportesAccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MinisterioDeportesWCF.Entidades
{
    [DataContract]
    public class PersonaDTO
    {
        /// <summary>
        /// Metodo constructor
        /// </summary>
        public PersonaDTO(String pNombre, String pCedula, String pApellido1, String pApellido2, String pPassword, String pEmail, Boolean pIsAdmin)
        {
            nombre = pNombre;
            cedula = pCedula;
            apellido1 = pApellido1;
            apellido2 = pApellido2;
            password = pPassword;
            isAdmin = pIsAdmin;            
            email = pEmail;
        }

        public PersonaDTO(persona persona)
        {
            nombre = persona.nombre;
            cedula = persona.cedula;
            apellido1 = persona.apellido;
            password = persona.password;
            isAdmin = persona.is_admin;
            apellido2 = persona.apellido2;
            email = persona.email;
        }

        [DataMember(Order = 0)]
        public String cedula { get; set; }

        [DataMember(Order = 1)]
        public String nombre { get; set; }

        [DataMember(Order = 2)]
        public String apellido1 { get; set; }

        [DataMember(Order = 3)]
        public String apellido2 { get; set; }

        [DataMember(Order = 4)]
        public String password { get; set; }

        [DataMember(Order = 5)]
        public String email { get; set; }

        [DataMember(Order = 6)]
        public Boolean isAdmin { get; set; }        
    }
}