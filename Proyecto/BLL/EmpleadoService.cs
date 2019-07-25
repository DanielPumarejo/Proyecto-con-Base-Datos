using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;

namespace BLL
{
    public class EmpleadoService
    {
        RepositorioEmpleado DALEmpleado;
        IList<Empleado> empleados;
        SqlConnection conexion;
        public EmpleadoService()
        {
            DALEmpleado = new RepositorioEmpleado();
        }
        public string GuardarEmpleado(Empleado empleado)
        {
            try
            {
                //conexion.Open();
                if (DALEmpleado.GuardarEmpleado(empleado))
                {
                    //conexion.Close();
                    return "Se registro el Cliente " + empleado.Nombre + empleado.Apellido;
                }
                else
                {
                    return "Error de Base de Datos: El dato que intenta ingresar en el campo de Sueldo no es valido";
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
        public IList<Empleado> Consultar()
        {
            empleados = DALEmpleado.Consultar();
            return empleados;
        }
        public Empleado Buscar(string id)
        {
            Empleado empleado = new Empleado();
            empleado = DALEmpleado.Buscar(id);
            return empleado;
        }
    }
}
