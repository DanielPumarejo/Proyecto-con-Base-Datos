using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Data;


namespace DAL
{
  public  class RepositorioClientes
    {
        private SqlConnection Conexion;
        private SqlDataReader Reader;
        IList<Cliente> clientes = new List<Cliente>();
        public RepositorioClientes()
        {
                        Conexion = new BaseDatos().cnn;
        }

        public bool GuardarCliente(Cliente cliente)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Insert Into Clientes(identificacion,nombre,apellido,direccion,correo,telefono)Values" +
                    "(@Identificacion,@Nombre,@Apellido,@Direccion,@Correo,@Tel)";
               
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = cliente.Identificacion;
                Comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = cliente.Nombre;
                Comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = cliente.Apellido;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = cliente.Correo;
                Comando.Parameters.Add("@Tel", SqlDbType.VarChar).Value = cliente.Telefono;
                Conexion.Open();
                if (Comando.ExecuteNonQuery()>0)
                {
                    Conexion.Close();
                    return true;
                }

                Conexion.Close();
                return false;
            }
        }

        public IList<Cliente> Consultar()
        {

            using (var comando = Conexion.CreateCommand())
            {

                comando.CommandText = "Select * from Clientes ORDER BY Nombre";
                Reader = comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    clientes.Clear();
                    while (Reader.Read())
                    {
                        Cliente client = new Cliente();
                        client = Map(Reader);
                        clientes.Add(client);
                    }
                    return clientes;
                }
                else
                {
                    return null;
                }
            }
        }
        public Cliente Buscar(string id)
        {
            using (var comando = Conexion.CreateCommand())
            {
                comando.CommandText = "Select * from Clientes Where Identificacion=@id ";
                comando.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                Conexion.Open();
                Reader = comando.ExecuteReader();
                if (Reader.HasRows)
                {                    
                     Cliente clien = new Cliente();
                     Reader.Read();
                     clien = Map(Reader);
                    Conexion.Close();          
                    return clien;
                }
                else
                {
                    Conexion.Close();
                    return null;}
            }
        }
        public IList<Cliente> Consultarxid(string id)
        {

            using (var comando = Conexion.CreateCommand())
            {

                comando.CommandText = "Select * from Clientes Where Identificacion=@id";
                Reader = comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    clientes.Clear();
                    while (Reader.Read())
                    {
                        Cliente clien = new Cliente();
                        clien = Map(Reader);
                        clientes.Add(clien);
                    }
                    return clientes;
                }
                else
                {return null;}
            }
        }
        public Cliente Map(SqlDataReader reader)
        {
            Cliente client = new Cliente();
            client.Identificacion = (string)reader["Identificacion"];
            client.Nombre = (string)reader["Nombre"];
            client.Apellido = (string)reader["Apellido"];
            client.Direccion = (string)reader["Direccion"];
            client.Correo = (string)reader["Correo"];
            client.Telefono = (string)reader["Telefono"];
            
            return client;
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                
                Comando.CommandText = "Update Clientes Set Identificacion = @identificacion,Nombre=@nombre,Apellido = @apellido,Correo =@correo ,Direccion=@direccion,Telefono =@telefono Where Identificacion = @identificacion";
                Comando.Parameters.Add("@identificacion", SqlDbType.VarChar).Value = cliente.Identificacion;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = cliente.Nombre;
                Comando.Parameters.Add("@apellido", SqlDbType.VarChar).Value = cliente.Apellido;
                Comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = cliente.Correo;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = cliente.Telefono;
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

    }
}
