using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
  public  class ClienteService
    {
        //public Cliente cliente { get; set; }
        RepositorioClientes Clientes;
        IList<Cliente> clientes;
        SqlConnection conexion;
        public ClienteService()
        {
            //conexion = new SqlConnection(@"Data .\SQLEXPRESS;Initial Catalog=PruebaLuis;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //Data Source = DESKTOP - A4JNRAN\SQLEXPRESS; Initial Catalog = PruebaLuis; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = Fals
            Clientes = new RepositorioClientes();
        }
        public string GuardarCliente(Cliente cliente)
        {
            try
            {
                //conexion.Open();
                if (Clientes.GuardarCliente(cliente))
                {
                    //conexion.Close();
                    return "Se registro el Cliente " + cliente.Nombre + cliente.Apellido;
                }
                else
                {
                    return "Error de Base de Datos: El dato que intenta ingresar en el campo de Sueldo no es valido" ;
                }
            }
            catch (FormatException ex)
            {
                
                return "Error de Base de Datos: El dato que intenta ingresar en el campo de Sueldo no es valido" + ex.ToString();
            }
            catch (Exception e)
            {
                
                return "Error de Base de Datos: " + e.Message.ToString();
            }
        }
        public IList<Cliente> Consultar()
        {
            
            clientes = new List<Cliente>();
            clientes = Clientes.Consultar();
            
            return clientes;
        }
        public Cliente Buscar(string id)
        {
            
            Cliente cliente = new Cliente();
            cliente = Clientes.Buscar(id);
            
            return cliente;
        }
        public IList<Cliente> Consultarxid(string id)
        {
            
            clientes = new List<Cliente>();
            clientes = Clientes.Consultarxid(id);
            
            return clientes;
        }
        public string ActualizarCliente(Cliente cliente)
        {
            try
            {
                
                Clientes.ActualizarCliente(cliente);
                
                return "Cliente actualizado  " + cliente.Nombre;
            }
            catch (Exception e)
            {
                return "Error de Base de Datos: " + e.Message.ToString();
            }
        }
    }
}
