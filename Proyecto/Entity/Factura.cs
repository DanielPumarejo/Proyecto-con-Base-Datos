using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
     public class  Factura
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        
        public Factura()
        {        }
        public Factura(string nombre, string apellido, string identificacion,int cantidad,decimal total)
        {
            Nombre = nombre;
            Apellido = apellido;
            Identificacion = identificacion;
            Cantidad = cantidad;
            Total = total;    
        }
    }
}
