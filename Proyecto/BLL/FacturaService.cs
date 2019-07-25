using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class FacturaService
    {
        RepositorioFactura repositorioFactura;
        IList<Factura> facturas;
        SqlConnection conexion;
        public FacturaService()
        {
            repositorioFactura = new RepositorioFactura();
        }
        public string GuardarFactura(Factura factura)
        {
            try
            {
                //conexion.Open();
                if (repositorioFactura.GuardarFactura(factura))
                {
                    //conexion.Close();
                    return "Se registro la factura ";
                }
                else
                {
                    return "Error de Base de Datos";
                }
            }
            catch (FormatException ex)
            {

                return "Error de Base de Datos" + ex.ToString();
            }
            catch (Exception e)
            {

                return "Error de Base de Datos: " + e.Message.ToString();
            }
        }

    }
}
