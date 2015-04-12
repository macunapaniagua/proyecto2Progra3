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
        public PersonaDTO(persona persona)
    {
        this.Nombre = persona.nombre;
        this.cedula = persona.cedula;
        this.apellido1 = persona.apellido;
        this.password= persona.password;
        this.esAdmi = persona.is_admin;
        this.apellido2 = persona.apellido2;
        this.correo = persona.email;
    }

    [DataMember]
    public  string correo { get; set; }
    [DataMember]
    public string Nombre { get; set; }
    [DataMember]
    public int cedula { get; set; }
    [DataMember]
    public string apellido1 { get; set; }
    [DataMember]
    public string password { get; set; }
    [DataMember]
    public bool esAdmi { get; set; }
    [DataMember]
    public string apellido2 { get; set; }
    }
}