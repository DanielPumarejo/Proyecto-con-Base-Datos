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
    public class RepositorioEmpleado
    {
        private SqlConnection Conexion;
        private SqlDataReader Reader;
        IList<Empleado> empleados = new List<Empleado>();
        public RepositorioEmpleado()
        {
            Conexion = new BaseDatos().cnn;
        }
        public bool GuardarEmpleado(Empleado empleado)
        {
            using (var Comando = Conexion.CreateCommand())
            {
                Comando.CommandText = "Insert Into Empleado(Identificacion,Nombre,Apellido,Direccion,Telefono,Correo,Sueldo,contrasena)Values" +
                    "(@Identificacion,@NombreEmpleado,@Apellido,@Direccion,@Telefono,@Correo,@sueldo,@Contrasena)";
                Comando.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = empleado.Identificacion;
                Comando.Parameters.Add("@NombreEmpleado", SqlDbType.VarChar).Value = empleado.Nombre;
                Comando.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = empleado.Apellido;
                Comando.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = empleado.Direccion;
                Comando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = empleado.Telefono;
                Comando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = empleado.Correo;
                Comando.Parameters.Add("@Sueldo", SqlDbType.Decimal).Value = empleado.Sueldo;
                Comando.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = empleado.Contrasena;
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
        public Empleado Buscar(string id)
        {
            using (var comando = Conexion.CreateCommand())
            {
                comando.CommandText = "Select * from Empleado Where Identificacion=@identificacion ";
                comando.Parameters.Add("@identificacion", SqlDbType.VarChar).Value = id;
                Conexion.Open();
                Reader = comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    Empleado empleado = new Empleado();
                    Reader.Read();
                    empleado = Map(Reader);
                    Conexion.Close();
                    return empleado;
                }
                else
                {
                    Conexion.Close();
                    return null;
                }
            }
        }
        public Empleado Map(SqlDataReader reader)
        {
            Empleado empleado = new Empleado();
           empleado.Identificacion = (string)reader["Identificacion"];
            empleado.Nombre = (string)reader["Nombre"];
            empleado.Apellido = (string)reader["Apellido"];
            empleado.Direccion = (string)reader["Direccion"];
            empleado.Telefono = (string)reader["Telefono"];
            empleado.Correo = (string)reader["Correo"];
            empleado.Sueldo = (decimal)reader["Sueldo"];
            empleado.Contrasena = (string)reader["Contrasena"];
            return empleado;
        }
        public IList<Empleado> Consultar()
        {
            using (var comando = Conexion.CreateCommand())
            {
                comando.CommandText = "Select * from Empleado ";
                Conexion.Open();
                Reader = comando.ExecuteReader();

                if (Reader.HasRows)
                {
                    empleados.Clear();
                    while (Reader.Read())
                    {
                        Empleado empleado = new Empleado();
                        empleado = Map(Reader);
                        empleados.Add(empleado);
                    }
                    Conexion.Close();
                    return empleados;
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
