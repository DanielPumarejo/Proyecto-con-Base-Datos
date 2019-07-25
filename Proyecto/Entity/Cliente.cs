using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
   public class Cliente: Persona
    {
  

        public Cliente()
        {

        }
        

        public Cliente(string identificacion, string nombre, string apellido,string direccion, string correo, string telefono)
        {
            Identificacion = identificacion;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
        }
    }
}
