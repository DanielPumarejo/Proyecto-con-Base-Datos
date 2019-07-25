using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class AdministradorService
    {
        public Administrador administrador { get; set; }
        RepositorioAdministrador DALAdministrador;
        IList<Administrador> administradores;
        SqlConnection conexion;
        public AdministradorService()
        {
            DALAdministrador = new RepositorioAdministrador();
        }
        public string GuardarAdministrador(Administrador administradore)
        {
            try
            {
                //conexion.Open();
                if (DALAdministrador.GuardarAdministrador(administradore))
                {
                    //conexion.Close();
                    return "Se registro el Cliente " + administradore.Nombre + administradore.Apellido;
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
        public IList<Administrador> Consultar()
        {
            administradores = DALAdministrador.Consultar();           
            return administradores;
        }
        public Administrador Buscar(string id)
        {
            Administrador admin = new Administrador();
            admin = DALAdministrador.Buscar(id);
            return admin;
        }
        public string ActualizarAdministrador(Administrador admin)
        {
            try
            {

                DALAdministrador.ActualizarAdministrador(admin);

                return "Administrador actualizado  " + admin.Nombre;
            }
            catch (Exception e)
            {
                return "Error de Base de Datos: " + e.Message.ToString();
            }
        }
    }
}
