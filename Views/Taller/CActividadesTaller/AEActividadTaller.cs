using SIT.Views.Catalogos.CEmpleados;
using SIT.Views.Taller.CGruposTaller;
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

namespace SIT.Views.Taller.CActividadesTaller
{
    public partial class AEActividadTaller : Form
    {
        public AEActividadTaller(Form form)
        {
            InitializeComponent();
            this._form=form;
        }

        public int idActividad;
        public Usuarios _uslog;
        SITEntities db = new SITEntities();
        AEActividadOT actot;
        ActividadesTaller act =  new ActividadesTaller();
        Form _form;

        private void CargarFormatosTiempo()
        {
            this.cmb_formato.Items.Clear();
            this.cmb_formato.Items.Add("MINUTOS");
            this.cmb_formato.Items.Add("HORAS");
            this.cmb_formato.Items.Add("DIAS");
            this.cmb_formato.Items.Add("SEMANAS");

        }

        private void AgregarActividadTaller()
        {
            if (this.txt_actividad.Text == string.Empty || this.txt_actividad.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el nombre de la actividad");
                this.txt_actividad.Focus();
            }
            else if (this.txt_te.Text == string.Empty || this.txt_te.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el tiempo estimado de la activdad");
                this.txt_te.Focus();
            }
            else if (this.cmb_formato.Text==string.Empty)
            {
                MessageBox.Show("Favor de seleccionar el formato de la activdad");
                this.cmb_formato.Focus();
            }
            else if (this.cmb_grupo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el grupo de la activdad");
                this.cmb_grupo.Focus();
            }
            else
            {
                act.Actividad = this.txt_actividad.Text.ToUpper();
                act.Formato = this.cmb_formato.Text.ToUpper();
                act.TiempoEstimado = this.txt_te.Text;
                act.IdEstatus = 1;
                act.IdGrupo = Convert.ToInt32(this.cmb_grupo.SelectedValue);
                act.FCreo = DateTime.Now;
                act.IdUsCreo = this._uslog.IdUsuario;

                if (idActividad > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar la actividad", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        act.IdUsMod = this._uslog.IdUsuario;
                        act.FMod = DateTime.Now;
                        db.Entry(act).State = EntityState.Modified;
                        MessageBox.Show("Actividad actualizada exitosamente");
                    }
                    else
                    {
                    }

                }
                else
                {
                    db.ActividadesTaller.Add(act);
                    MessageBox.Show("Actividad agregado exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarActividadTaller();
        }

        private void AEActividadTaller_Load(object sender, EventArgs e)
        {
            CargarFormatosTiempo();
            CargarGrupos();
            if (idActividad != 0)
            {
                act = db.ActividadesTaller.Where(x => x.IdAct == idActividad).FirstOrDefault();
                this.txt_actividad.Text = act.Actividad;
                this.txt_te.Text = act.TiempoEstimado;
                if (act.IdGrupo != null)
                {
                    this.cmb_grupo.SelectedValue = act.IdGrupo;

                }
                this.cmb_formato.Text= act.Formato;
                this.Text = "Editar ";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void AEActividadTaller_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this._form.Name== "AEActividadOT")
            {
                actot = (AEActividadOT)this._form;
                actot.Enabled = true;
                actot.CargarActividades();
            }
        }

        public void CargarGrupos()
        {
            this.cmb_grupo.DataSource = null;
            this.cmb_grupo.Items.Clear();
            var x = db.GruposActTaller.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_grupo.DataSource = x;
            this.cmb_grupo.ValueMember = "IdGrupo";
            this.cmb_grupo.DisplayMember = "Grupo";
        }


        private void btn_add_grupo_Click(object sender, EventArgs e)
        {
            AEGruposTaller frm = new AEGruposTaller(this);
            frm.idGrupo = 0;
            frm._uslog = this._uslog;
            this.Enabled = false;
            frm.Show();
        }
    }
}
