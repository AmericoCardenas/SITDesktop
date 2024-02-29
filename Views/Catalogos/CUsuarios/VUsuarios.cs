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
using SIT.Views.Catalogos.CCuentasBancos;
using static System.Net.Mime.MediaTypeNames;

namespace SIT.Views.Catalogos
{
    public partial class VUsuarios : Form
    {
        SITEntities db = new SITEntities();
        Usuarios usuario=new Usuarios();
        int IdUsuario = 0;
        Usuarios _uslog;

        public VUsuarios(Usuarios usuariolog)
        {
            InitializeComponent();
            DataUsuarios(1);
            this._uslog = usuariolog;
            this.btn_delete.Enabled = false;
        }





        public void DataUsuarios(int idestatus)
        {

            usuario = new Usuarios();

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


        private void EliminarUsuario()
        {
            if (IdUsuario > 0)
            {
                usuario.FechaCancelacion = DateTime.Now.ToString("dd-MM-yyyy");
                usuario.UsuarioCancelacion = Convert.ToInt32(this._uslog.IdUsuario);
                usuario.IdEstatus = 2;
                db.Entry(usuario).State = EntityState.Modified;
                MessageBox.Show("Usuario inactivado exitosamente");

            }

            db.SaveChanges();
            DataUsuarios(1);
            this.btn_delete.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEUsuarios frm = new AEUsuarios(this);
            frm.idUsuario = this._uslog.IdUsuario;
            frm.usuarios = usuario;
            this.Enabled = false;
            frm.Show();
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
                usuario = db.Usuarios.Where(x => x.IdUsuario == IdUsuario).FirstOrDefault();

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
