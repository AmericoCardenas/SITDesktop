using SIT.Views.Contabilidad.CMovimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Sistemas.CSitios
{
    public partial class AESitios : Form
    {
        public AESitios(VSitios vsitios)
        {
            InitializeComponent();
            frm = vsitios;
        }

        public int idusuario,idsitio;
        SITEntities db = new SITEntities();
        UsuariosSitios usit = new UsuariosSitios();
        VSitios frm;

        private void CargarEmpleados()
        {
            var empleados = db.Trabajadores.ToList();
            this.cmb_emp.DataSource = empleados;
            this.cmb_emp.ValueMember = "IdEmpleado";
            this.cmb_emp.DisplayMember = "NombreCompleto";
        }

        private void AESitios_Load(object sender, EventArgs e)
        {
            CargarEmpleados();

            if (idsitio != 0)
            {
                usit = db.UsuariosSitios.Where(x => x.IdUs == idsitio).FirstOrDefault();
                this.txt_usuario.Text = usit.Usuario;
                this.txt_pass.Text = usit.Contraseña;
                this.txt_sitio.Text = usit.Sitio;
                this.cmb_emp.SelectedValue = usit.IdEmpleado;
                this.Text = "Editar";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void AgregarSitio()
        {
            if (this.txt_usuario.Text == "")
            {
                MessageBox.Show("Favor de introducir el usuario");
            }
            else if (this.txt_pass.Text == "")
            {
                MessageBox.Show("Favor de introducir la contraseña");
            }
            else if (this.txt_sitio.Text == "")
            {
                MessageBox.Show("Favor de introducir el sitio");
            }
            if (this.cmb_emp.SelectedValue == null)
            {
                MessageBox.Show("Favor de introducir el empleado");
            }
            else
            {
                usit.Usuario = this.txt_usuario.Text;
                usit.Contraseña = this.txt_pass.Text;
                usit.Sitio = this.txt_sitio.Text;
                usit.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);

                if (idsitio > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el sitio", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        db.Entry(usit).State = EntityState.Modified;
                        MessageBox.Show("Sitio actualizado exitosamente");
                    }
                    else
                    {
                        LimpiarFormulario();
                        idsitio = 0;
                    }

                }
                else
                {
                    db.UsuariosSitios.Add(usit);
                    MessageBox.Show("Sitio agregado exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void AESitios_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.frm.Enabled = true;
            this.frm.CargarSitios();
            
        }

        private void btn_acept_Click(object sender, EventArgs e)
        {
            AgregarSitio();
        }

        private void LimpiarFormulario()
        {
            this.cmb_emp.SelectedItem= null;
            this.txt_sitio.Text = string.Empty;
            this.txt_pass.Text = string.Empty;
            this.txt_usuario.Text = string.Empty;
        }
    }
}
