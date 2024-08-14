using SIT.CrystalReport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.RH.CVacaciones
{
    public partial class AEVacaciones : Form
    {
        public AEVacaciones(Form form)
        {
            InitializeComponent();
            this.lstbx_fechas.Sorted = true;    
            this._form= form;   
        }

        Form _form;
        public Usuarios _uslog;
        SITEntities db = new SITEntities();
        VacacionesEmp vacemp = new VacacionesEmp(); 

        private void CargarEmpleados()
        {
            var x = this.db.Trabajadores.Where(y=>y.IdEstatus==1).ToList(); 
            this.cmb_emp.DataSource = x;
            this.cmb_emp.DisplayMember = "NombreCompleto";
            this.cmb_emp.ValueMember = "IdEmpleado";
        }

        private void CargarPeriodos()
        {
            var x = this.db.Periodos.ToList();
            this.cmb_periodo.DataSource = x;
            this.cmb_periodo.DisplayMember = "Periodo";
            this.cmb_periodo.ValueMember = "IdPeriodo";
        }

        private void dtm_fecha_ValueChanged(object sender, EventArgs e)
        {
            var fecha = Convert.ToDateTime(this.dtm_fecha.Value.ToString("dd-MM-yyyy"));
            var idemp = Convert.ToInt32(this.cmb_emp.SelectedValue);
            var idperiodo = Convert.ToInt32(this.cmb_periodo.SelectedValue);

            var f = this.db.VacacionesEmp.Where(x => x.Fecha == fecha && x.IdEmpleado == idemp && x.IdPeriodo == idperiodo).FirstOrDefault();
            if (f != null)
            {
                MessageBox.Show("El dia ya se encuentra gozado por el empleado");

            }
            else
            {
                if (this.lstbx_fechas.Items.Contains(this.dtm_fecha.Value.ToShortDateString()))
                {
                    MessageBox.Show("El dia ya se encuentra seleccionado");
                }
                else
                {
                    this.lstbx_fechas.Items.Add(this.dtm_fecha.Value.ToShortDateString());
                }

                this.txt_dgoz.Text = string.Empty;
                this.txt_dgoz.Text = this.lstbx_fechas.Items.Count.ToString();

                CalcularVacacionesPorPeriodo();
            }


        }

        private void AEVacaciones_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarPeriodos();
        }

        private void cmb_emp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularVacacionesPorPeriodo();

            }
            catch (Exception ex)
            {

            }
        }

        private void cmb_periodo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
               CalcularVacacionesPorPeriodo();
            }
            catch (Exception ex)
            {

            }

        }

        private void EliminarDiaLista()
        {
            if(this.lstbx_fechas.Items.Count> 0)
            {
                this.lstbx_fechas.Items.Remove(this.lstbx_fechas.SelectedItem);
                this.txt_dgoz.Text = string.Empty;
                this.txt_dgoz.Text = this.lstbx_fechas.Items.Count.ToString();
                CalcularVacacionesPorPeriodo();
            }
        }

        private void CalcularVacacionesPorPeriodo()
        {
            try
            {
                this.txt_totvacaciones.Text = string.Empty;
                this.txt_vacgoz.Text = string.Empty;
                this.txt_vacpend.Text = string.Empty;


                var idperiodo = Convert.ToInt32(this.cmb_periodo.SelectedValue);
                var idempleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                var v = this.db.VacDiasEmpPeriodo.Where(x => x.idPeriodo == idperiodo && x.IdEmpleado == idempleado).FirstOrDefault();
                if (v != null)
                {

                    this.txt_totvacaciones.Text = v.Dias.ToString();
                }

                var vac = this.db.VacacionesEmp.Where(x => x.IdPeriodo == idperiodo && x.IdEmpleado == idempleado && x.IdEstatus==1).ToList();
                this.txt_vacgoz.Text=vac.Count().ToString();
 

                var dpend = Convert.ToInt32(this.txt_totvacaciones.Text) - Convert.ToInt32(this.txt_vacgoz.Text) - Convert.ToInt32(this.lstbx_fechas.Items.Count);
                this.txt_vacpend.Text = dpend.ToString();

                if (dpend <= 0)
                {
                    MessageBox.Show("El empleado ya no cuenta con dias en el periodo");
                    this.btn_add.Enabled = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            EliminarDiaLista();
            CalcularVacacionesPorPeriodo();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea agregar las vacaciones al empleado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                AgregarVacaciones();

            }
            else
            {
                // Do something
            }
        }

        private void AgregarVacaciones()
        {
            if (this.cmb_emp.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
                this.cmb_emp.Focus();
            }
            else if(this.cmb_periodo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el periodo");
                this.cmb_periodo.Focus();

            }
            else if (this.txt_dgoz.Text == string.Empty || this.txt_dgoz.Text == "0" || this.lstbx_fechas.Items.Count==0)
            {
                MessageBox.Show("Favor de capturar dias a gozar");
                this.lstbx_fechas.Focus();
            }
            else
            {
                foreach (var v in this.lstbx_fechas.Items)
                {
                    var fecha = Convert.ToDateTime(v.ToString());
                    vacemp.IdEstatus = 1;
                    vacemp.IdPeriodo = Convert.ToInt32(this.cmb_periodo.SelectedValue);
                    vacemp.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                    vacemp.Fecha = fecha;
                    vacemp.Observaciones = this.txt_obs.Text.ToUpper();
                    vacemp.FCreo=DateTime.Now;
                    vacemp.IdUsCreo = this._uslog.IdUsuario;
                    this.db.VacacionesEmp.Add(vacemp);
                    this.db.SaveChanges();
                }

                this.btn_add.Enabled = false;
                this.btn_delete.Enabled= false;
                this.cmb_emp.Enabled = false;
                this.cmb_periodo.Enabled = false;
                this.dtm_fecha.Enabled = false;
                this.txt_obs.Enabled = false;

                Reporte rpt = new Reporte();
                var fvac = string.Join(",", this.lstbx_fechas.Items.OfType<object>());
                rpt.frm = this;
                rpt.idempleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                rpt.dias_correspondientes = this.txt_totvacaciones.Text;
                rpt.dias_disfrutados = this.txt_vacgoz.Text;
                rpt.dias_disfrutar = this.txt_dgoz.Text;
                rpt.dias_restantes = this.txt_vacpend.Text;
                rpt.fechas_vacaciones = fvac;
                rpt.obs_vac = this.txt_obs.Text.ToUpper();
                rpt.periodo = this.cmb_periodo.Text;
                rpt.Show();



            }
        }

        private void AEVacaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this._form.Name== "VVacaciones")
            {
                VVacaciones frm = (VVacaciones)this._form;
                frm.Enabled = true;
                frm.CargarDatos();
            }
        }
    }
}
