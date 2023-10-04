using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Catalogos.CEmpleados
{
    public partial class ResumenEmpleado : Form
    {
        public ResumenEmpleado()
        {
            InitializeComponent();
        }

        public int idempleado;
        public string nombre_empleado,puesto;
        public Form form;
        SITEntities db = new SITEntities();


        private void ResumenEmpleado_Load(object sender, EventArgs e)
        {
            this.lbl_nomemp.Text = nombre_empleado.ToUpper();
            this.lbl_puesto.Text = puesto.ToUpper();
            this.Text = nombre_empleado.ToUpper();
            if (tbcontrol.SelectedIndex == 0)
            {
                CargarDomicilio();
            }
        }

        private void ResumenEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.Enabled = true;
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tbcontrol.SelectedIndex == 0)
            {
                CargarDomicilio();
            }
            else if(tbcontrol.SelectedIndex == 1)
            {
                CargarDatosBancarios();
            }
            else if(tbcontrol.SelectedIndex == 2)
            {
                CargarEquiposComputo();
            }
            else if (tbcontrol.SelectedIndex == 3)
            {
                CargarEquiposMovil();
            }
            else if (tbcontrol.SelectedIndex == 4)
            {
                CargarLineas();
            }

        }

        private void CargarDomicilio()
        {
            var domicilio = db.DomicilioEmpleados.Where(x=>x.IdEmpleado==idempleado).ToList();
            this.dgrid_domemp.DataSource = domicilio;
            foreach(DataGridViewColumn col in this.dgrid_domemp.Columns)
            {
                col.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dgrid_domemp.Columns["IdDomicilioEmp"].Visible = false;
            this.dgrid_domemp.Columns["IdEmpleado"].Visible = false;
            this.dgrid_domemp.Columns["IdBitad"].Visible = false;

        }

        private void CargarDatosBancarios()
        {
            var bancarios = db.DatosNominaEmpleados.Where(x=>x.IdEmpleado==idempleado).ToList().ToList();
            this.dgrid_bancemp.DataSource = bancarios;
            foreach (DataGridViewColumn col in this.dgrid_bancemp.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            this.dgrid_bancemp.Columns["IdNomina"].Visible = false;
            this.dgrid_bancemp.Columns["IdEmpleado"].Visible = false;
            this.dgrid_bancemp.Columns["IdBitad"].Visible = false;
        }

        private void CargarEquiposComputo()
        {
            var eqcomputo = db.EquiposComputo.Where(x => x.IdEmpleado == idempleado).ToList();
            this.dgrid_eqcom.DataSource = eqcomputo;
            foreach (DataGridViewColumn col in this.dgrid_eqcom.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            this.dgrid_eqcom.Columns["IdEquipoComputo"].Visible = false;
            this.dgrid_eqcom.Columns["IdEmpleado"].Visible = false;
        }

        private void CargarEquiposMovil()
        {
            var eqmovil = db.EquiposMovil.Where(x => x.IdEmpleado == idempleado).ToList();
            this.dgrid_eqmov.DataSource = eqmovil;
            foreach (DataGridViewColumn col in this.dgrid_eqmov.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            this.dgrid_eqmov.Columns["IdEquipoMovil"].Visible = false;
            this.dgrid_eqmov.Columns["IdEmpleado"].Visible = false;
        }

        private void CargarLineas()
        {
            var lineas = db.Lineas.Where(x => x.IdEmpleado == idempleado).ToList();
            this.dgrid_lineaemp.DataSource = lineas;
            foreach (DataGridViewColumn col in this.dgrid_lineaemp.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            this.dgrid_lineaemp.Columns["IdLinea"].Visible = false;
            this.dgrid_lineaemp.Columns["IdEmpleado"].Visible = false;
            this.dgrid_lineaemp.Columns["IdProveedor"].Visible = false;
            this.dgrid_lineaemp.Columns["IdEstatus"].Visible = false;



        }

    }
}
