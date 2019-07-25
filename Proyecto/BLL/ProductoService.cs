using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class ProductoService
    {
        RepositorioProducto DALProductos;
        IList<Producto> productos;// var de retorno
        SqlConnection conexion;
        Producto prod = new Producto();
        public ProductoService()
        {
            //conexion = new SqlConnection(@"Data Source=DESKTOP-A4JNRAN\SQLEXPRESS;Initial Catalog=PruebaLuis;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //Data Source = DESKTOP - A4JNRAN\SQLEXPRESS; Initial Catalog = PruebaLuis; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = Fals
            DALProductos = new RepositorioProducto();
        }
        public string GuardarProducto(Producto productos)
        {
            try
            {
                //conexion.Open();
                if (DALProductos.GuardarProducto(productos))
                {
                    //conexion.Close();
                    return "Se registro el Producto ";
                }
                else
                {
                    return "Error de Base de Datos: El dato que intenta ingresar es invalido";
                }
            }
            catch (FormatException ex)
            {
                conexion.Close();
                return "Error de Base de Datos: El dato que intenta ingresar no es valido" + ex.ToString();
            }
            catch (Exception e)
            {
                conexion.Close();
                return "Error de Base de Datos: " + e.Message.ToString();
                
            }
        }

        public IList<Producto> Consultar()
        {
            //conexion.Open();
            productos = DALProductos.Consultar();
            //conexion.Close();
            return productos;
        }
        public Producto Buscar(string cod)
        {         
            prod = DALProductos.Buscar(cod);   
            return prod;
        }
        public IList<Producto> Consultarxid(string cod)
        {           
           productos = DALProductos.Consultarxcod(cod);           
            return productos;
        }
        public string ActualizarProducto(Producto producto)
        {
            try
            {
                DALProductos.ActualizarProducto(producto);
                return "Producto actualizado  " + producto.NombreProducto;
            }
            catch (Exception e)
            {
                //conexion.Close();
                return "Error de Base de Datos: " + e.Message.ToString();
            }
        }
    }
}
