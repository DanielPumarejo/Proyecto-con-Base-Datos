using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Administrador: Persona
    {
        public string Contrasena { get; set; }
        public Administrador()
        {
        }
        public Administrador(string identificacion,string nombre, string apellido,string direccion,string telefono, string correo, string contrasena)
        {
            Nombre = nombre;
            Apellido = apellido;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            Contrasena = contrasena;
        }
    }
}
