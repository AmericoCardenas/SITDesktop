using SIT.Views.Taller.CActividadesTaller;
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

namespace SIT.Views.Taller.COrdenesTrabajo
{
    public partial class AEActividadOT : Form
    {
        public AEActividadOT(Form form)
        {
            InitializeComponent();
            this._form=form;
        }

        Form _form;
        SITEntities db = new SITEntities();
        ActividadesOT actot = new ActividadesOT();
        public Usuarios _uslog;
        public int idActividadOT,idOT;

        private void CargarMecanicos()
        {
            var x = db.Trabajadores.Where(y => y.IdEstatus == 1 && y.IdDepto == 9).ToList();
            this.cmb_mecanico.DataSource = x;
            this.cmb_mecanico.ValueMember = "IdEmpleado";
            this.cmb_mecanico.DisplayMember = "NombreCompleto";
        }

        public void CargarActividades()
        {
            this.cmb_actividad.DataSource = null;
            this.cmb_actividad.Items.Clear();
            var x = db.ActividadesTaller.Where(y=>y.IdEstatus==1).ToList();
            this.cmb_actividad.DataSource = x;
            this.cmb_actividad.ValueMember = "IdAct";
            this.cmb_actividad.DisplayMember = "Actividad";
        }

        private void CargarMttos()
        {
            var x = db.MantenimientosTaller.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_mtto.DataSource = x;
            this.cmb_mtto.ValueMember = "IdMantenimiento";
            this.cmb_mtto.DisplayMember = "Mantenimiento";
        }

        private void CargarEstatus()
        {
            var x = db.EstatusActTaller.Where(y => y.IdEstatus != 2).ToList();
            this.cmb_estatus.DataSource = x;
            this.cmb_estatus.ValueMember = "IdEstatus";
            this.cmb_estatus.DisplayMember = "Estatus";
        }

        private void AgregarActividadTaller()
        {
            if (this.txt_hi.Text == string.Empty || this.txt_hi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir la hora inicial de la actividad");
                this.txt_hi.Focus();
            }
            else if (this.cmb_actividad.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar la activdad");
                this.cmb_actividad.Focus();
            }
            else if (this.cmb_mecanico.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el mecanico");
                this.cmb_mecanico.Focus();
            }
            else if (this.cmb_estatus.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el estatus de la OT");
                this.cmb_estatus.Focus();
            }
            else if (this.cmb_mtto.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el tipo de mantenimiento de la OT");
                this.cmb_mtto.Focus();
            }
            else
            {
                actot.IdOT = idOT;
                actot.IdEmpleado = Convert.ToInt32(this.cmb_mecanico.SelectedValue);
                actot.IdEstatus = Convert.ToInt32(this.cmb_estatus.SelectedValue);
                actot.FI = this.dtm_fi.Value;
                actot.TI = this.txt_hi.Text;
                actot.FF=this.dtm_ft.Value;
                actot.TF=this.txt_ht.Text;
                actot.IdActTaller=Convert.ToInt32(this.cmb_actividad.SelectedValue);
                actot.Observaciones = this.txt_obs.Text.ToUpper();
                actot.IdEstatus = Convert.ToInt32(this.cmb_estatus.SelectedValue);
                actot.FCreo = DateTime.Now;
                actot.IdUsCreo = this._uslog.IdUsuario;

                if (idActividadOT > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar la actividad", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        actot.IdUsMod = this._uslog.IdUsuario;
                        actot.FMod = DateTime.Now;
                        db.Entry(actot).State = EntityState.Modified;
                        MessageBox.Show("Actividad actualizada exitosamente");
                    }
                    else
                    {
                    }

                }
                else
                {
                    db.ActividadesOT.Add(actot);
                    MessageBox.Show("Actividad agregado exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }




        private void AEActividadOT_Load(object sender, EventArgs e)
        {
            CargarMecanicos();
            CargarActividades();
            CargarMttos();
            CargarEstatus();

             if(idActividadOT!=0)
            {
                actot = db.ActividadesOT.Where(x => x.IdActOt == idActividadOT).FirstOrDefault();
                this.Text = "Editar Act OT# " + actot.IdOT;
                this.cmb_mecanico.SelectedValue = actot.IdEmpleado;
                this.cmb_actividad.SelectedValue = actot.IdActTaller;
                this.cmb_estatus.SelectedValue = actot.IdEstatus;
                this.txt_hi.Text = actot.TI;
                this.dtm_fi.Value = Convert.ToDateTime(actot.FI);
                this.txt_ht.Text = actot.TF;
                this.dtm_ft.Value = Convert.ToDateTime(actot.FF);
                this.txt_obs.Text = actot.Observaciones;

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarActividadTaller();
        }

        private void AEActividadOT_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "AEOrdenesTrabajo")
            {
                AEOrdenesTrabajo frm = (AEOrdenesTrabajo)this._form;
                frm.Enabled = true;
                frm.CargarActividadesxOT();
            }
        }

        private void btn_add_actividad_Click(object sender, EventArgs e)
        {
            AEActividadTaller frm = new AEActividadTaller(this);
            frm.idActividad = 0;
            frm._uslog = this._uslog;
            this.Enabled = false;
            frm.Show();
        }
    }
}
