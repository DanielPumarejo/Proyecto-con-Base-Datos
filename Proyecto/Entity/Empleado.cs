using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Empleado:Persona
    {

        public decimal Sueldo { get; set; }
        public string Contrasena { get; set; }

        public Empleado()
        {
        }
        public Empleado(string identificacion, string nombre, string apellido,string direccion, string telefono,string correo, decimal sueldo, string contrasena)
        {
            Nombre = nombre;
            Apellido = apellido;
            Identificacion = identificacion;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            Sueldo = sueldo;
            Contrasena = contrasena;
        }

    }
}
