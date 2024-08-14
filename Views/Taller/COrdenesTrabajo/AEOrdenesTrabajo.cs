using SIT.Views.General.CRequisiciones;
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

namespace SIT.Views.Taller
{
    public partial class AEOrdenesTrabajo : Form
    {
        public AEOrdenesTrabajo(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        Form _form;
        public int idOT;
        public Usuarios uslog;
        SITEntities db = new SITEntities();
        int idActOT=0;
        OrdenesTrabajoTaller ot = new OrdenesTrabajoTaller();
        ActividadesOT actot = new ActividadesOT();

        private void AEOrdenesTrabajo_Load(object sender, EventArgs e)
        {
            CargarOperadores();
            CargarUnidades();
            CargarUbicaciones();

            if (idOT == 0)
            {
                ot.FCreo = DateTime.Now;
                ot.IdUsCreo = this.uslog.IdUsuario;
                ot.IdEstatus = 1;
                ot.IdEmpleado = 0;
                ot.IdUnidad = 0;
                ot.Hora = "00:00";
                ot.Km = 0;
                ot.IdUbicacion = 0;
                ot.Fecha=DateTime.Now;
                ot.Observaciones = string.Empty;
                db.OrdenesTrabajoTaller.Add(ot);
                db.SaveChanges();
                idOT = ot.IdOrdenTrabajo;
                this.txt_numot.Text = idOT.ToString();
                this.Text = "Orden de Trabajo #" + idOT.ToString();
            }
            else
            {
                ot = db.OrdenesTrabajoTaller.Where(x => x.IdOrdenTrabajo == idOT).FirstOrDefault();
                this.txt_numot.Text = ot.IdOrdenTrabajo.ToString();
                this.cmb_emp.SelectedValue = ot.IdEmpleado;
                this.dtm_fechaot.Value = ot.Fecha.Value;
                this.txt_horaot.Text = ot.Hora.ToString();
                this.cmb_unidad.SelectedValue = ot.IdUnidad;
                this.txt_km.Text = ot.Km.ToString();
                this.txt_obsot.Text = ot.Observaciones;

                if (ot.IdEstatus == 3)
                {
                    this.btn_cancel_actot.Enabled = false;
                    this.btn_add_actot.Enabled = false;
                    this.txt_horaot.Enabled = false;
                    this.txt_km.Enabled = false;
                    this.txt_numot.Enabled = false;
                    this.txt_obsot.Enabled = false;
                    this.cmb_ubicacion.Enabled=false;
                    this.cmb_unidad.Enabled=false;
                    this.cmb_emp.Enabled = false;
                }
                //this.txt_km.Text=ot.km
            }

            CargarActividadesxOT();
        }



        private void CargarUnidades()
        {
            var x = db.Unidades.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_unidad.DataSource = x;
            this.cmb_unidad.ValueMember = "IdUnidad";
            this.cmb_unidad.DisplayMember = "Economico";
        }

        private void CargarOperadores()
        {
            var x = db.Trabajadores.Where(y => y.IdEstatus == 1 && y.IdPuesto==2).ToList();
            this.cmb_emp.DataSource = x;
            this.cmb_emp.ValueMember = "IdEmpleado";
            this.cmb_emp.DisplayMember = "NombreCompleto";
        }

        private void CargarUbicaciones()
        {
            var x = db.UbicacionesOT.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_ubicacion.DataSource = x;
            this.cmb_ubicacion.ValueMember = "IdUbicacion";
            this.cmb_ubicacion.DisplayMember = "Ubicacion";
        }

        public void CargarActividadesxOT()
        {
            idActOT = 0;
            this.btn_add_actot.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
            this.btn_add_actot.BackgroundImageLayout = ImageLayout.Stretch;

            var x = from a in db.ActividadesOT
                    join t in db.Trabajadores on a.IdEmpleado equals t.IdEmpleado
                    join e in db.EstatusActTaller on a.IdEstatus equals e.IdEstatus
                    join at in db.ActividadesTaller on a.IdActTaller equals at.IdAct
                    join ac in db.ActividadesMOT on a.IdActMOT equals ac.IdAct
                    where a.IdOT == idOT && a.IdEstatus!=2
                    select new
                    {
                        a.IdActOt,
                        t.NombreCompleto,
                        Tipo=ac.Actividad,
                        at.Actividad,
                        e.Estatus,
                        a.FI,
                        a.TI,
                        a.FF,
                        a.TF,
                        a.Observaciones                       
                    };

            this.dgrid_actsot.DataSource = x.ToList();
            this.dgrid_actsot.Columns[0].Visible = false;
            this.dgrid_actsot.EnableHeadersVisualStyles = false;
            this.dgrid_actsot.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_actsot.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_actsot.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btn_add_actot_Click(object sender, EventArgs e)
        {
            AEActividadOT frm = new AEActividadOT(this);
            frm.idOT = idOT;
            frm.idActividadOT = idActOT;
            frm._uslog = this.uslog;
            this.Enabled = false;
            frm.Show();
        }

        private void dgrid_actsot_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_actsot.CurrentCell.RowIndex != -1)
                {
                    idActOT = Convert.ToInt32(this.dgrid_actsot.CurrentRow.Cells[0].Value);
                }
                this.btn_add_actot.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add_actot.BackgroundImageLayout = ImageLayout.Stretch;


            }
            catch (Exception ex) { }
        }



        private void btn_cancel_actot_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea eliminar la actividad seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarActividadOT();

            }
            else
            {
                // Do something
            }
        }

        private void CancelarActividadOT()
        {
            try
            {
                if (this.dgrid_actsot.CurrentCell.RowIndex != -1 && this.dgrid_actsot.CurrentCell != null && idActOT != 0)
                {
                    actot = db.ActividadesOT.Where(x => x.IdActOt == idActOT).FirstOrDefault();
                    if (actot.IdEstatus == 3)
                    {
                        MessageBox.Show("No se puede eliminar la actividad debido a que ya se encuentra terminada");
                    }
                    else
                    {
                        actot.IdEstatus = 2;
                        actot.FCan = DateTime.Now;
                        actot.IdUsCan = this.uslog.IdUsuario;

                        if (idActOT > 0)
                        {
                            db.Entry(actot).State = EntityState.Modified;
                            db.SaveChanges();
                            CargarActividadesxOT();
                        }
                        else
                        {
                            MessageBox.Show("Favor de seleccionar la actividad a cancelar");
                        }
                    }
                }
            }


            catch (Exception ex)
            {

            }



        }

        private void GuardarOT()
        {
            if (this.txt_km.Text == string.Empty || this.txt_km.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el km de la unidad");
            }
            else
            {
                if (idOT != 0 && ot.IdEstatus != 3)
                {
                    ot.Fecha = this.dtm_fechaot.Value;
                    ot.Hora = this.txt_horaot.Text;
                    ot.IdUnidad = Convert.ToInt32(this.cmb_unidad.SelectedValue);
                    ot.Km = Convert.ToDouble(this.txt_km.Text);
                    ot.IdUbicacion = Convert.ToInt32(this.cmb_ubicacion.SelectedValue);
                    ot.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                    ot.Observaciones = this.txt_obsot.Text.ToUpper();
                    db.Entry(ot).State = EntityState.Modified;
                    db.SaveChanges();

                    var x = db.ActividadesOT.Where(y => y.IdOT == idOT && y.IdEstatus == 1).ToList();
                    if (!x.Any() && this.dgrid_actsot.Rows.Count > 0) //SI NO TIENE ACTIVIDADES PENDIENTES SE FINALIZA LA OT
                    {
                        ot.IdEstatus = 3;
                        db.Entry(ot).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    MessageBox.Show("Se guardo la OT #" + idOT + " exitosamente");
                }

            }
        }

        private void btn_save_OT_Click(object sender, EventArgs e)
        {
            GuardarOT();
        }

        private void txt_horaot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void txt_km_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AEOrdenesTrabajo_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuardarOT();

            if (this._form.Name == "VOrdenesTrabajo")
            {
                VOrdenesTrabajo frm = (VOrdenesTrabajo)this._form;
                frm.Enabled = true;
                frm.CargarOTS();
            }
        }
    }
}
