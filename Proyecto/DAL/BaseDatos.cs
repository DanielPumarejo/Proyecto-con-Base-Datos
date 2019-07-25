using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BaseDatos
    {
        String cadena = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Programacion de computadores 3\3ER corte\Proyecto con Base Datos\Proyecto\Proyecto\Proyecto.mdf;Integrated Security=True;Connect Timeout=30";
        public SqlConnection cnn;
        public BaseDatos()
        {
            cnn = new SqlConnection(cadena);
        }
        public void conectar()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
        }
        public void desconectar()
        {
            if (cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
        public bool ejecutarComando(SqlCommand cmd)
        {
            try
            {
                conectar();
                cmd.Connection = cnn;
                if (cmd.ExecuteNonQuery() > 0)
                {

                    desconectar();
                    return true;
                }
                else
                {
                    desconectar();
                    return false;
                }
            }
            catch (Exception ex)
            {
                desconectar();
                return false;
            }
        }

        public DataTable ejecutarSelect(SqlDataAdapter da)
        {
            try
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
