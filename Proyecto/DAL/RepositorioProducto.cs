using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RepositorioProducto
    {
        private SqlConnection Conexion;
        private SqlDataReader Reader;
        IList<Producto> productos = new List<Producto>();
        Producto prod = new Producto();
        public RepositorioProducto()
        {
            Conexion = new BaseDatos().cnn;
        }

        public bool GuardarProducto(Producto producto)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Insert Into Producto(codigo,nombreProducto,descripcion,precioC,precioV,cantidad)Values" +
                    "(@Codigo,@NombreProducto,@Descripcion,@PrecioC,@PrecioV,@Cantidad)";
                Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = producto.Codigo;
                Comando.Parameters.Add("@NombreProducto", SqlDbType.VarChar).Value = producto.NombreProducto;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = producto.Descripcion;
                Comando.Parameters.Add("@PrecioC", SqlDbType.Decimal).Value = producto.PrecioC;
                Comando.Parameters.Add("@PrecioV", SqlDbType.Decimal).Value = producto.PrecioV;
                Comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = producto.Cantidad;
                Conexion.Open();
                if (Comando.ExecuteNonQuery() > 0)
                {
                    Conexion.Close();
                    return true;
                }
                else {
                    Conexion.Close();
                    return false;
                }
                
            }
        }
        public bool ActualizarProducto(Producto producto)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Update Producto Set Codigo = @codigo,nombreProducto=@nombreProducto,descripcion=@descripcion, precioC=@precioC, precioV = @precioV  cantidad=@cantidad Where Codigo = @codigo";
                Comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = producto.Codigo;
                Comando.Parameters.Add("@nombreProducto", SqlDbType.VarChar).Value = producto.NombreProducto;
                Comando.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = producto.Descripcion;
                Comando.Parameters.Add("@PrecioC", SqlDbType.Decimal).Value = producto.PrecioC;
                Comando.Parameters.Add("@PrecioV", SqlDbType.Decimal).Value = producto.PrecioV;
                Comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = producto.Cantidad;
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
        public IList<Producto> Consultar()
        {
            using (var comando = Conexion.CreateCommand())
            {
                comando.CommandText = "Select * from Producto  ";

                Conexion.Open();
                Reader = comando.ExecuteReader();

                if (Reader.HasRows)
                {
                    productos.Clear();
                    while (Reader.Read())
                    {
                        Producto prod = new Producto();
                        prod = Map(Reader);
                        productos.Add(prod);
                    }
                    Conexion.Close();
                    return productos;
                }
                else
                {
                    Conexion.Close();
                    return null;
                }
            }
        }

        public Producto Buscar(string cod)
        {
            using (var comando = Conexion.CreateCommand())
            {
                comando.CommandText = "Select * from Producto Where Codigo=@codigo ";
                comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = cod;
                Conexion.Open();
                Reader = comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    Reader.Read();
                    prod = Map(Reader);
                    Conexion.Close();
                    return prod;
                }
                else
                {
                    Conexion.Close();
                    return null;
                }
            }
        }

        public IList<Producto> Consultarxcod(string cod)
        {
            productos.Clear();
            using (var comando = Conexion.CreateCommand())
            {
                comando.CommandText = "Select * from Producto Where Codigo=@codigo";
                Reader = comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    productos.Clear();
                    while (Reader.Read())
                    {
                        prod = Map(Reader);
                        productos.Add(prod);
                    }
                    return productos;
                }
                else
                { return null; }
            }
        }
        public Producto Map(SqlDataReader reader)
        {
            Producto produ = new Producto();
            produ.Codigo = (string)reader["Codigo"];
            produ.NombreProducto = (string)reader["nombreProducto"];
            produ.Descripcion = (string)reader["descripcion"];
            produ.PrecioC = (decimal)reader["precioC"];
            produ.PrecioV = (decimal)reader["precioV"];
            produ.Cantidad = (int)reader["Cantidad"];
            return produ;
        }
    }
}
