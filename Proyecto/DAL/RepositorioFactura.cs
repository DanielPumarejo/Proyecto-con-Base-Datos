using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;

namespace DAL
{
    public class RepositorioFactura
    {
        private SqlConnection Conexion;
        private SqlDataReader Reader;
        IList<Factura> facturas = new List<Factura>();

        public RepositorioFactura()
        {
            Conexion = new BaseDatos().cnn;
        }

        public bool GuardarFactura(Factura factura)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Insert Into Factura(Identificacion,Nombre,Apellido,Cantidad,Total)Values" +
                    "(@Identificacion,@NombreEmpleado,@Apellido,@Cantidad,@Total)";
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = factura.Identificacion;
                Comando.Parameters.Add("@NombreEmpleado", SqlDbType.VarChar).Value = factura.Nombre;
                Comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = factura.Apellido;
                Comando.Parameters.Add("@Cantidad", SqlDbType.VarChar).Value = factura.Cantidad;
                Comando.Parameters.Add("@Total", SqlDbType.VarChar).Value = factura.Total;
                
                Conexion.Open();
                if (Comando.ExecuteNonQuery() > 0)
                {
                    Conexion.Close();
                    return true;
                }
                Conexion.Close();
                return false;
            }
        }

        public Factura Map(SqlDataReader reader)
        {
            Factura factura = new Factura();
            factura.Identificacion = (string)reader["Identificacion"];
            factura.Nombre = (string)reader["Nombre"];
            factura.Apellido = (string)reader["Apellido"];
            factura.Cantidad = (int)reader["Cantidad"];
            factura.Total = (decimal)reader["Total"];
            
            return factura;
        }
    }
}
