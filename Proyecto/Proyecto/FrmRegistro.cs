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
    public partial class FrmRegistro : MetroFramework.Forms.MetroForm
    {
        ClienteService servicioC = new ClienteService();
        AdministradorService servicioA = new AdministradorService();
        EmpleadoService servicioE = new EmpleadoService();


        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIde.Text == "" || txtNombre.Text == "" || txtApellido.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == "" || txtTelefono.Text == "")
            {
                MessageBox.Show("Hay campos Obligatorios sin llenar", "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                if (cmbTipoUsuario.Text=="Administrador")
                {
                    Administrador administrador = new Administrador();
                    administrador.Identificacion = txtIde.Text;
                    administrador.Nombre = txtNombre.Text;
                    administrador.Apellido = txtApellido.Text;
                    administrador.Direccion = txtDireccion.Text;
                    administrador.Correo = txtCorreo.Text;
                    administrador.Telefono = txtTelefono.Text;
                    administrador.Contrasena = txtContrasena.Text;

                    string resultado = servicioA.GuardarAdministrador(administrador);
                    MessageBox.Show(resultado, "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    Empleado empleado = new Empleado();
                    empleado.Identificacion = txtIde.Text;
                    empleado.Nombre = txtNombre.Text;
                    empleado.Apellido = txtApellido.Text;
                    empleado.Direccion = txtDireccion.Text;
                    empleado.Correo = txtCorreo.Text;
                    empleado.Telefono = txtTelefono.Text;
                    empleado.Sueldo = Convert.ToDecimal(txtSueldo.Text);
                    empleado.Contrasena = txtContrasena.Text;

                    string resultado = servicioE.GuardarEmpleado(empleado);
                    MessageBox.Show(resultado, "Titulo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Limpiar();
                }
                
            }
        }
        public void Limpiar()
        {
            txtIde.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            if (admin != null)
            {
                DialogResult r = MessageBox.Show("Esta seguro que lo desea Modificarlo", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    admin.Identificacion = txtIde.Text;
                    admin.Nombre = txtNombre.Text;
                    admin.Apellido = txtApellido.Text;
                    admin.Correo = txtCorreo.Text;
                    admin.Direccion = txtDireccion.Text;
                    admin.Telefono = txtTelefono.Text;

                    string mensaje = servicioA.ActualizarAdministrador(admin);
                    MessageBox.Show(mensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarC_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            admin = servicioA.Buscar(txtIde.Text);
            if (admin != null)
            {
                txtNombre.Text = admin.Nombre;
                txtApellido.Text = admin.Apellido;
                txtDireccion.Text = admin.Direccion;
                txtTelefono.Text = admin.Telefono;
                txtCorreo.Text = admin.Correo;                
            }
            else
            {
                MessageBox.Show("NO ESTA REGISTRADO EL ADMINISTRADOR ", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
    }
    }
