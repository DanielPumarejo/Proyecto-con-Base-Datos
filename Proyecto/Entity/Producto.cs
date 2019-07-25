using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioC { get; set; }
        public decimal PrecioV { get; set; }

        public Producto()
        {

        }

        public Producto(string codigo,string nombreProducto,string descripcion,int cantidad, decimal precioC, decimal precioV)
        {
            Codigo = codigo;
            NombreProducto = nombreProducto;
            Descripcion = descripcion;
            Cantidad = cantidad;
            PrecioC = precioC;
            PrecioV = PrecioV;
        }
    }
}
