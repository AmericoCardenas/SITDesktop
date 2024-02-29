using DocumentFormat.OpenXml.Drawing;
using SIT.Views.Taller.CActividadesTaller;
using SIT.Views.Taller.COrdenesTrabajo;
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

namespace SIT.Views.Taller.CGruposTaller
{
    public partial class AEGruposTaller : Form
    {
        public AEGruposTaller(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        Form _form;
        public int idGrupo;
        public Usuarios _uslog;
        AEActividadTaller _vacttaller;
        GruposActTaller grupo = new GruposActTaller();
        SITEntities db = new SITEntities();

        private void AEGruposTaller_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "AEActividadTaller")
            {
                _vacttaller = (AEActividadTaller)this._form;
                _vacttaller.Enabled = true;
                _vacttaller.CargarGrupos();
            }
        }

        private void AEGruposTaller_Load(object sender, EventArgs e)
        {
            if (idGrupo != 0)
            {
                grupo = db.GruposActTaller.Where(x => x.IdGrupo == idGrupo).FirstOrDefault();
                this.txt_grupo.Text = grupo.Grupo;
                this.Text = "Editar ";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void AgregarGrupoTaller()
        {
            if (this.txt_grupo.Text == string.Empty || this.txt_grupo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el nombre del grupo");
                this.txt_grupo.Focus();
            }
            else
            {
                grupo.Grupo = this.txt_grupo.Text.ToUpper();
                grupo.IdEstatus = 1;
                grupo.FCreo=DateTime.Now;
                grupo.IdUsCreo = this._uslog.IdUsuario;


                if (idGrupo > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar el grupo", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        grupo.IdUsMod = this._uslog.IdUsuario;
                        grupo.FMod = DateTime.Now;
                        db.Entry(grupo).State = EntityState.Modified;
                        MessageBox.Show("Grupo actualizado exitosamente");
                    }
                    else
                    {
                    }

                }
                else
                {
                    db.GruposActTaller.Add(grupo);
                    MessageBox.Show("Grupo agregado exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarGrupoTaller();
        }
    }
}
