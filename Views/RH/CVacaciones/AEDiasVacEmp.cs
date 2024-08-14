using SIT.Views.Catalogos;
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

namespace SIT.Views.RH.CVacaciones
{
    public partial class AEDiasVacEmp : Form
    {
        public AEDiasVacEmp(Form form)
        {
            InitializeComponent();
            this._form=form;
        }

        public Usuarios _uslog;
        SITEntities db = new SITEntities();
        public int idDV;
        VacDiasEmpPeriodo vac = new VacDiasEmpPeriodo();
        Form _form;


        private void AEDiasVacEmp_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarPeriodos();

            if (idDV == 0)
            {
                this.Text = "Agregar Vacaciones por Periodo";
            }
            else
            {
                this.Text = "Editar Vacaciones por Periodo";
                vac = this.db.VacDiasEmpPeriodo.Where(x=>x.IdDV== idDV).FirstOrDefault();
                this.cmb_emp.SelectedValue = vac.IdEmpleado;
                this.cmb_periodo.SelectedValue = vac.idPeriodo;
                this.txt_dias.Text = vac.Dias.ToString();

            }
        }

        private void CargarEmpleados()
        {
            var x = this.db.Trabajadores.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_emp.DataSource = x;
            this.cmb_emp.ValueMember = "IdEmpleado";
            this.cmb_emp.DisplayMember = "NombreCompleto";
        }

        private void CargarPeriodos()
        {
            var x = this.db.Periodos.ToList();
            this.cmb_periodo.DataSource = x;
            this.cmb_periodo.ValueMember = "IdPeriodo";
            this.cmb_periodo.DisplayMember = "Periodo";

        }

        private void AgregarDias()
        {
            if(this.cmb_emp.SelectedValue==null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
                this.cmb_emp.Focus();
            }
            else if (this.cmb_periodo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el periodo");
                this.cmb_periodo.Focus();
            }
            else if (this.txt_dias.Text == string.Empty)
            {
                MessageBox.Show("Favor de capturar los dias de vacaciones correspondientes al periodo");
                this.txt_dias.Focus();
            }
            else
            {
                var idemp = Convert.ToInt32(this.cmb_emp.SelectedValue);
                var idperiodo = Convert.ToInt32(this.cmb_periodo.SelectedValue);
                var dvacp =this.db.VacDiasEmpPeriodo.Where(x=>x.IdEmpleado==idemp&&x.idPeriodo==idperiodo).ToList();

                vac.idPeriodo = Convert.ToInt32(this.cmb_periodo.SelectedValue);
                vac.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                vac.Dias = Convert.ToInt32(this.txt_dias.Text);
                vac.FCreo=DateTime.Now;
                vac.IdUsCreo = this._uslog.IdUsuario;
                
                if (dvacp.Any())
                {
                    MessageBox.Show("El empleado ya cuenta con dias para el periodo seleccionado");
                }
                else if(idDV == 0 && !dvacp.Any())
                {
                    this.db.VacDiasEmpPeriodo.Add(vac);
                    MessageBox.Show("Dias agregados exitosamente");
                    db.SaveChanges();


                }
                else if (idDV != 0 && !dvacp.Any())
                {
                    db.Entry(vac).State = EntityState.Modified;
                    MessageBox.Show("Dias editados exitosamente");
                    db.SaveChanges();

                }

                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarDias();
        }

        private void txt_dias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AEDiasVacEmp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VDiasVacacionesEmp")
            {
                VDiasVacacionesEmp frm = (VDiasVacacionesEmp)this._form;
                frm.Enabled = true;
                frm.CargarDatos();
            }
        }
    }
}
