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
using SIT.Views;
using static System.Net.Mime.MediaTypeNames;

namespace SIT.Views.Catalogos
{
    public partial class VUsuarios : Form
    {
        SITEntities db = new SITEntities();
        Usuarios Usuarios=new Usuarios();
        int IdUsuario = 0;
        Usuarios _uslog;

        public VUsuarios(Usuarios usuariolog)
        {
            InitializeComponent();
            LimpiarFormulario();
            DataUsuarios(1);
            CargarCombos();
            this._uslog = usuariolog;
            this.btn_delete.Enabled = false;
        }

        private void CargarCombos()
        {
            this.cmb_depto.DataSource = db.Departamentos.ToList<Departamentos>();
            this.cmb_depto.DisplayMember = "Departamento";
            this.cmb_depto.ValueMember = "IdDepto";

        }

        private void LimpiarFormulario()
        {
            this.txt_nombre.Text=this.txt_app.Text=this.txt_apm.Text=this.txt_usuario.Text=this.txt_contraseña.Text=string.Empty;
            this.btn_delete.Enabled=false;
            IdUsuario = 0;
        }

        private void DataUsuarios(int idestatus)
        {

            var usuarios = from u in db.Usuarios
                           join d in db.Departamentos on u.IdDepto equals d.IdDepto
                           join es in db.EstatusUsuarios on u.IdEstatus equals es.IdEstatus
                           where u.IdEstatus==idestatus
                            select new
                            {
                                IdUsuario = u.IdUsuario,
                                Usuario = u.Usuario,
                                Contraseña = u.Password,
                                Nombre = u.Nombre,
                                ApellidoPaterno = u.Apellidop,
                                ApellidoMaterno = u.Apellidom,
                                Departamento = d.Departamento,
                                Estatus = es.Estatus
                            };
            this.dgrid.DataSource = usuarios.ToList();
            this.dgrid.Columns[0].Visible = false;
        }

        private void InsertarUsuario()
        {
            if (this.txt_nombre.Text == "")
            {
                MessageBox.Show("Favor de capturar el nombre");
            }
            else if (this.txt_app.Text == "")
            {
                MessageBox.Show("Favor de capturar el apellido paterno");
            }
            else if (this.txt_apm.Text == "")
            {
                MessageBox.Show("Favor de capturar el apellido materno");
            }
            else if (this.txt_usuario.Text == "")
            {
                MessageBox.Show("Favor de capturar el usuario");
            }
            else if (this.txt_contraseña.Text == "")
            {
                MessageBox.Show("Favor de capturar la contraseña");
            }
            else if (this.cmb_depto.SelectedItem == null)
            {
                MessageBox.Show("Favor de seleccionar el departamento");

            }
            else
            {

                Usuarios.Usuario = this.txt_usuario.Text.Trim();
                Usuarios.Password = this.txt_contraseña.Text.Trim();
                Usuarios.Nombre = this.txt_nombre.Text.Trim();
                Usuarios.Apellidop = this.txt_app.Text.Trim();
                Usuarios.Apellidom = this.txt_apm.Text.Trim();
                Usuarios.IdEstatus = 1;
                Usuarios.IdDepto = Convert.ToInt32(this.cmb_depto.SelectedValue);
                Usuarios.FechaCreacion = DateTime.Now.ToString("dd-MM-yyyy");
                Usuarios.UsuarioCreacion = Convert.ToInt32(_uslog.IdUsuario);

                if (IdUsuario > 0) {
                Usuarios.IdEstatus = 1;
                Usuarios.FechaModificacion = DateTime.Now.ToString("dd-MM-yyyy");
                Usuarios.UsuarioModificacion = Convert.ToInt32(_uslog.IdUsuario);
                db.Entry(Usuarios).State = EntityState.Modified;
                    MessageBox.Show("Usuario actualizado exitosamente");
                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Center;
                    this.btn_delete.Enabled = false;


                }
                else
                {
                    db.Usuarios.Add(Usuarios);
                    MessageBox.Show("Usuario agregado exitosamente");

                }

                db.SaveChanges();
                LimpiarFormulario();
                DataUsuarios(1);
                this.btn_delete.Enabled = false;
            }





        }

        private void EliminarUsuario()
        {
            if (IdUsuario > 0)
            {
                Usuarios.FechaCancelacion = DateTime.Now.ToString("dd-MM-yyyy");
                Usuarios.UsuarioCancelacion = Convert.ToInt32(_uslog.IdUsuario);
                Usuarios.IdEstatus = 2;
                db.Entry(Usuarios).State = EntityState.Modified;
                MessageBox.Show("Usuario inactivado exitosamente");

            }

            db.SaveChanges();
            LimpiarFormulario();
            DataUsuarios(1);
            this.btn_delete.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            InsertarUsuario();
        }

        private void VUsuarios_Load(object sender, EventArgs e)
        {
            this.dgrid.EnableHeadersVisualStyles = false;
            this.dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgrid_Click(object sender, EventArgs e)
        {
            if (this.dgrid.CurrentCell.RowIndex != -1)
            {
                IdUsuario = Convert.ToInt32(this.dgrid.CurrentRow.Cells["IdUsuario"].Value);
                Usuarios = db.Usuarios.Where(x => x.IdUsuario == IdUsuario).FirstOrDefault();
                this.txt_nombre.Text = Usuarios.Nombre;
                this.txt_app.Text = Usuarios.Apellidop;
                this.txt_apm.Text = Usuarios.Apellidom;
                this.cmb_depto.SelectedValue = Usuarios.IdDepto;
                this.txt_usuario.Text = Usuarios.Usuario;
                this.txt_contraseña.Text = Usuarios.Password;
            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            this.btn_delete.Enabled = true;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea eliminar el usuario?", "Confirmación", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                EliminarUsuario();
            }

        }

        private void chk_inactivos_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_inactivos.Checked == true) {
                DataUsuarios(2);
            }
            else
            {
                DataUsuarios(1);
            }
        }
    }
}
