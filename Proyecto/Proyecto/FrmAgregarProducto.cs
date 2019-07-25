using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace Proyecto
{
    public partial class FrmAgregarProducto : MetroFramework.Forms.MetroForm
    {
        ProductoService servicioP = new ProductoService();
        public FrmAgregarProducto()
        {
            InitializeComponent();
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == ""|| txtNombreP.Text == "" || rtxtDescripcion.Text==""|| txtPrecioV.Text == "" || txtPrecioC.Text == "")
            {
                MessageBox.Show("Hay campos Obligatorios sin llenar", "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                Producto producto = new Producto();
                producto.Codigo = txtCodigo.Text;
                producto.NombreProducto = txtNombreP.Text;
                producto.Descripcion = rtxtDescripcion.Text;
                producto.Cantidad = Convert.ToInt32 (txtCantidad.Text);                
                producto.PrecioC = Convert.ToDecimal(txtPrecioC.Text);
                producto.PrecioV = Convert.ToDecimal(txtPrecioV.Text);
                string resultado = servicioP.GuardarProducto(producto);
                MessageBox.Show(resultado, "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                Limpiar();
            }
        }
            public void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombreP.Text = "";
            rtxtDescripcion.Text = "";
            txtPrecioC.Text = "";
            txtPrecioV.Text = "";
            txtCantidad.Text = "";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto = servicioP.Buscar(txtCodigo.Text);
            if (producto != null)
            {
                txtNombreP.Text = producto.NombreProducto;
                rtxtDescripcion.Text = producto.Descripcion;
                txtPrecioC.Text = Convert.ToString(producto.PrecioC);
                txtPrecioV.Text = Convert.ToString(producto.PrecioV);
                txtCantidad.Text = Convert.ToString(producto.Cantidad);
            }
            else
            {
                MessageBox.Show("PRODUCTO NO REGISTRADO ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizarPro_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            if (producto != null)
            {
                DialogResult r = MessageBox.Show("Esta seguro que lo desea Modificarlo", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    producto.Codigo = txtCodigo.Text;
                    producto.NombreProducto = txtNombreP.Text;
                    producto.Descripcion = rtxtDescripcion.Text;
                    producto.PrecioC = Convert.ToDecimal(txtPrecioC.Text);
                    producto.PrecioV = Convert.ToDecimal(txtPrecioV.Text);
                    producto.Cantidad = Convert.ToInt32(txtCantidad.Text);            
                    string mensaje = servicioP.ActualizarProducto(producto);
                    MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBodega frmbodega1 = new FrmBodega();
            frmbodega1.Show();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
