using DocumentFormat.OpenXml.Drawing.Wordprocessing;
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

namespace SIT.Views.Sistemas
{
    public partial class VSitios : Form
    {
        public VSitios()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities(); 
        UsuariosSitios us = new UsuariosSitios();
        int IdUs = 0;

        private void CargarEmpleados()
        {
            var empleados = db.Trabajadores.ToList();
            this.cmb_emp.DataSource = empleados;
            this.cmb_emp.ValueMember = "IdEmpleado";
            this.cmb_emp.DisplayMember = "NombreCompleto";
        }

        private void VSitios_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarSitios();
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
                us.Usuario = this.txt_usuario.Text;
                us.Contraseña = this.txt_pass.Text;
                us.Sitio = this.txt_sitio.Text;
                us.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);

                if (IdUs > 0)
                {
                    db.Entry(us).State = EntityState.Modified;
                    MessageBox.Show("Sitio actualizado exitosamente");

                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

                }
                else
                {
                    db.UsuariosSitios.Add(us);
                    MessageBox.Show("Linea agregada exitosamente");

                }
                db.SaveChanges();
                CargarSitios();

            }
        }

        private void CargarSitios()
        {
            var sitios = from x in db.UsuariosSitios
                         join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                         select new
                         {
                             x.IdUs,
                             x.Usuario,
                             x.Contraseña,
                             x.Sitio,
                             t.NombreCompleto
                         } ;
            this.dgrid_sitios.DataSource = sitios.ToList();
            this.dgrid_sitios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_sitios.Columns[0].Visible = false;
        }

        private void dgrid_sitios_Click(object sender, EventArgs e)
        {
            if (this.dgrid_sitios.CurrentCell.RowIndex != -1)
            {
                IdUs = Convert.ToInt32(this.dgrid_sitios.CurrentRow.Cells["IdUs"].Value);
                us = db.UsuariosSitios.Where(x => x.IdUs == IdUs).FirstOrDefault();
                this.txt_usuario.Text = us.Usuario;
                this.txt_pass.Text = us.Contraseña;
                this.txt_sitio.Text = us.Sitio;
                this.cmb_emp.SelectedValue = us.IdEmpleado;
            }

            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarSitio();
        }
    }
}
