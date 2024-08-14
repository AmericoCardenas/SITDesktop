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

namespace SIT.Views.Sistemas.CEqMovil
{
    public partial class AEEqMovil : Form
    {
        public AEEqMovil(Form form)
        {
            InitializeComponent();
            this._form = form;

        }

        public int idEqMovil;
        public Usuarios _uslog;
        EquiposMovil eqmov = new EquiposMovil();
        SITEntities db = new SITEntities();
        Form _form;

        private void AEEqMovil_Load(object sender, EventArgs e)
        {
            CargarEstatus();
            CargarEmpleados();

            if (idEqMovil != 0)
            {
                eqmov = db.EquiposMovil.Where(x => x.IdEquipoMovil == idEqMovil).FirstOrDefault();
                this.txt_marca.Text = eqmov.Marca;
                this.txt_modelo.Text = eqmov.Modelo;
                this.txt_ram.Text = eqmov.Ram;
                this.txt_procesador.Text = eqmov.Procesador;
                this.txt_imei.Text = eqmov.IMEI;
                this.txt_imei2.Text = eqmov.IMEI2;
                this.txt_sn.Text = eqmov.SN;
                this.txt_color.Text = eqmov.Color;
                this.txt_carac.Text = eqmov.Caracteristicas;
                this.txt_detalles.Text = eqmov.Detalles;
                this.txt_acces.Text = eqmov.Accesorios;
                this.txt_valor.Text = eqmov.ValorComercial;
                this.cmb_emp.SelectedValue = Convert.ToInt32(eqmov.IdEmpleado);
                this.cmb_estatus.SelectedValue = Convert.ToInt32(eqmov.IdEstatus);

               
                this.Text = "Editar ";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void CargarEstatus()
        {
            var x = this.db.EstatusEquipos.ToList();
            this.cmb_estatus.DataSource = x;
            this.cmb_estatus.ValueMember = "IdEstatus";
            this.cmb_estatus.DisplayMember = "Estatus";
        }

        private void CargarEmpleados()
        {
            var x = this.db.Trabajadores.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_emp.DataSource = x;
            this.cmb_emp.ValueMember = "IdEmpleado";
            this.cmb_emp.DisplayMember = "NombreCompleto";

        }

        private void AgregarEquipos()
        {
            if (this.txt_marca.Text == "")
            {
                MessageBox.Show("Favor de capturar la marca del equipo");
            }
            else if (this.txt_modelo.Text == "")
            {
                MessageBox.Show("Favor de capturar el modelo del equipo");
            }
            else if (this.txt_ram.Text == "")
            {
                MessageBox.Show("Favor de capturar la ram del equipo");
            }
            else if (this.txt_procesador.Text == "")
            {
                MessageBox.Show("Favor de capturar el procesador del equipo");
            }
            else if (this.txt_imei.Text == "")
            {
                MessageBox.Show("Favor de capturar el imei del equipo");
            }
            else if (this.txt_imei2.Text == "")
            {
                MessageBox.Show("Favor de capturar imei2 del equipo");
            }
            else if (this.txt_sn.Text == "")
            {
                MessageBox.Show("Favor de capturar numero de serie del equipo");
            }
            else if (this.txt_color.Text == "")
            {
                MessageBox.Show("Favor de capturar el color del equipo");
            }
            else if (this.txt_carac.Text == "")
            {
                MessageBox.Show("Favor de capturar las caracteristicas del equipo");
            }
            else if (this.txt_detalles.Text == "")
            {
                MessageBox.Show("Favor de capturar los detalles del equipo");
            }
            else if (this.txt_acces.Text == "")
            {
                MessageBox.Show("Favor de capturar los accesorios del equipo");
            }
            else if (this.txt_valor.Text == "")
            {
                MessageBox.Show("Favor de capturar el valor del equipo");
            }
            else if (this.cmb_emp.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado asignado");
            }
            else if (this.cmb_estatus.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el estatus del equipo");
            }
            else
            {
                eqmov.Marca = this.txt_marca.Text;
                eqmov.Modelo = this.txt_modelo.Text;
                eqmov.Ram = this.txt_ram.Text;
                eqmov.Procesador = this.txt_procesador.Text;
                eqmov.IMEI = this.txt_imei.Text;
                eqmov.IMEI2 = this.txt_imei2.Text;
                eqmov.SN = this.txt_sn.Text;
                eqmov.Color = this.txt_color.Text;
                eqmov.Caracteristicas = this.txt_carac.Text;
                eqmov.Detalles = this.txt_detalles.Text;
                eqmov.Accesorios = this.txt_acces.Text;
                eqmov.ValorComercial = this.txt_valor.Text;
                eqmov.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                eqmov.IdEstatus = Convert.ToInt32(this.cmb_estatus.SelectedValue);


                if (idEqMovil > 0)
                {
                    db.Entry(eqmov).State = EntityState.Modified;
                    MessageBox.Show("Equipo actualizado exitosamente");
                }
                else
                {
                    db.EquiposMovil.Add(eqmov);
                    MessageBox.Show("Equipo agregado exitosamente");
                }

                db.SaveChanges();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarEquipos();
        }

        private void AEEqMovil_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VEquiposMovil")
            {
                VEquiposMovil veqmov = (VEquiposMovil)this._form;
                veqmov.Enabled = true;
                veqmov.CargarEquiposMov();

            }
        }
    }
}
