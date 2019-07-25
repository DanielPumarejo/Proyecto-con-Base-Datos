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
    public class RepositorioAdministrador
    {
        private SqlConnection Conexion;
        private SqlDataReader Reader;
        IList<Administrador> administradores = new List<Administrador>();
        public RepositorioAdministrador()
        {
            Conexion = new BaseDatos().cnn;
        }
        public bool GuardarAdministrador(Administrador administrador)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Insert Into Administrador(Identificacion,Nombre,Apellido,Direccion,Telefono,Correo,contrasena)Values" +
                    "(@Identificacion,@NombreAdministrador,@Apellido,@Direccion,@Telefono,@Correo,@Contrasena)";
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = administrador.Identificacion;
                Comando.Parameters.Add("@NombreAdministrador", SqlDbType.VarChar).Value = administrador.Nombre;
                Comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = administrador.Apellido;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = administrador.Direccion;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = administrador.Telefono;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = administrador.Correo;
                Comando.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = administrador.Contrasena;
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
        public bool ActualizarAdministrador(Administrador admin)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Update Administrador Set Identificacion = @identificacion,Nombre=@nombre,Apellido = @apellido,Correo =@correo ,Direccion=@direccion,Telefono =@telefono Where Identificacion = @identificacion";
                Comando.Parameters.Add("@identificacion", SqlDbType.VarChar).Value = admin.Identificacion;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = admin.Nombre;
                Comando.Parameters.Add("@apellido", SqlDbType.VarChar).Value = admin.Apellido;
                Comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = admin.Correo;
                Comando.Parameters.Add("@direccion", SqlDbType.VarChar).Value = admin.Direccion;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = admin.Telefono;
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

        public Administrador Buscar(string id)
        {
            using (var comando = Conexion.CreateCommand())
            {
                comando.CommandText = "Select * from Administrador Where Identificacion=@identificacion ";
                comando.Parameters.Add("@identificacion", SqlDbType.VarChar).Value = id;
                Conexion.Open();
                Reader = comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    Administrador admin = new Administrador();
                    Reader.Read();
                    admin = Map(Reader);
                    Conexion.Close();
                    return admin;
                }
                else
                {
                    Conexion.Close();
                    return null;
                }
            }
        }
        public Administrador Map(SqlDataReader reader)
        {
            Administrador admin = new Administrador();
            admin.Identificacion = (string)reader["Identificacion"];
            admin.Nombre = (string)reader["Nombre"];
            admin.Apellido = (string)reader["Apellido"];
            admin.Direccion = (string)reader["Direccion"];
            admin.Telefono = (string)reader["Telefono"];
            admin.Correo = (string)reader["Correo"];
            admin.Contrasena = (string)reader["Contrasena"];
            return admin;
        }
        public IList<Administrador> Consultar()
        {
            using (var comando = Conexion.CreateCommand())
            {
                comando.CommandText = "Select * from Administrador ";
                Conexion.Open();
                Reader = comando.ExecuteReader();

                if (Reader.HasRows)
                {
                    administradores.Clear();
                    while (Reader.Read())
                    {
                        Administrador admin = new Administrador();
                        admin = Map(Reader);
                        administradores.Add(admin);
                    }
                    Conexion.Close();
                    return administradores;
                }
                else
                {
                    Conexion.Close();
                    return null;
                }
            }
        }
    }
}
