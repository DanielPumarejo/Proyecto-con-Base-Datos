using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class FrmBodega : MetroFramework.Forms.MetroForm
    {
        ProductoService servicio = new ProductoService();
        public IreceptorP FrmReceptor { get; set; }
        public FrmBodega(IreceptorP frmReceptor)
        {
            InitializeComponent();
            FrmReceptor = frmReceptor;
        }

        public FrmBodega()
        {
            InitializeComponent();
        }

        private void btnModificarBodg_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmBodega_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void btnAgregarBodg_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto frmAgregar = new FrmAgregarProducto();
            frmAgregar.Show();
        }

        private void btnBuscarBodg_Click(object sender, EventArgs e)
        {
            IList<Producto> productos = new List<Producto>();
            if (servicio.Consultar() != null)
            {
                productos = servicio.Consultar();
                dtgProductos.DataSource = productos;
            }
            else
            {
                MessageBox.Show("NO HAY INFORMACION  GUARDADA ");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nn_Click(object sender, EventArgs e)
        {
            
        }

        private void dtgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FrmReceptor != null)
            {
                Producto producto = (Producto)dtgProductos.CurrentRow.DataBoundItem;
                FrmReceptor.Recibir(producto);
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se puedo llevar acabo la accion");
            }
        }

        private void dtgProductos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (FrmReceptor != null)
            {
                Producto producto = (Producto)dtgProductos.CurrentRow.DataBoundItem;
                FrmReceptor.Recibir(producto);
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se puedo llevar acabo la accion");
            }
        }
    }
}
