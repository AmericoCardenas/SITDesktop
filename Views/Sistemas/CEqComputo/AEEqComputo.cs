using DocumentFormat.OpenXml.Drawing.ChartDrawing;
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

namespace SIT.Views.Sistemas.CEqComputo
{
    public partial class AEEqComputo : Form
    {
        public AEEqComputo(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        SITEntities db = new SITEntities();
        public int idEqComputo;
        EquiposComputo equiposComputo = new EquiposComputo();
        Form _form;

        private void AEEqComputo_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarTipo();

            if (idEqComputo != 0)
            {
                equiposComputo = db.EquiposComputo.Where(x => x.IdEquipoComputo == idEqComputo).FirstOrDefault();
                this.cmb_tipo.Text = equiposComputo.Tipo;
                this.txt_marca.Text = equiposComputo.Marca;
                this.txt_modelo.Text = equiposComputo.Modelo;
                this.txt_ram.Text = equiposComputo.Ram;
                this.txt_proc.Text = equiposComputo.Procesador;
                this.txt_alm.Text = equiposComputo.Almacenamiento;
                this.txt_sn.Text = equiposComputo.SN;
                this.txt_color.Text = equiposComputo.Color;
                this.txt_carac.Text = equiposComputo.Caracteristicas;
                this.txt_deta.Text = equiposComputo.Detalles;
                this.txt_acces.Text = equiposComputo.Accesorios;
                this.txt_valor.Text = equiposComputo.ValorComercial;
                this.cmb_emp.SelectedValue = Convert.ToInt32(equiposComputo.IdEmpleado);

                this.Text = "Editar";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void CargarTipo()
        {
            this.cmb_tipo.Items.Add("ESCRITORIO");
            this.cmb_tipo.Items.Add("LAPTOP");
            this.cmb_tipo.Items.Add("TABLET");
        }

        private void CargarEmpleados()
        {
            var x = db.Trabajadores.ToList();
            this.cmb_emp.DataSource = x;
            this.cmb_emp.DisplayMember = "NombreCompleto";
            this.cmb_emp.ValueMember = "IdEmpleado";
        }

        private void AgregarEquipo()
        {
            if (this.cmb_tipo.Text == "")
            {
                MessageBox.Show("Favor de seleccionar el tipo del equipo");
            }
            else if (this.txt_marca.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar la marca del equipo");
            }
            else if (this.txt_modelo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el modelo del equipo");
            }
            else if (this.txt_ram.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar la RAM del equipo");
            }
            else if (this.txt_proc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el procesador del equipo");
            }
            else if (this.txt_alm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el almacenamiento del equipo");
            }
            else if (this.txt_sn.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el numero de serie del equipo");
            }
            else if (this.txt_color.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el color del equipo");
            }
            else if (this.txt_carac.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar las caracteristicas del equipo");
            }
            else if (this.txt_deta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar los detalles del equipo");
            }
            else if (this.txt_acces.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar los Accesorios del equipo");
            }
            else if (this.txt_valor.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el valor comercial del equipo");
            }
            else if (this.cmb_emp.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado a asignar del equipo");
            }
            else
            {
                equiposComputo.Tipo = this.cmb_tipo.Text;
                equiposComputo.Marca = this.txt_marca.Text;
                equiposComputo.Modelo = this.txt_modelo.Text;
                equiposComputo.Ram = this.txt_ram.Text;
                equiposComputo.Procesador = this.txt_proc.Text;
                equiposComputo.Almacenamiento = this.txt_alm.Text;
                equiposComputo.SN = this.txt_sn.Text;
                equiposComputo.Color = this.txt_color.Text;
                equiposComputo.Caracteristicas = this.txt_carac.Text;
                equiposComputo.Detalles = this.txt_deta.Text;
                equiposComputo.Accesorios = this.txt_acces.Text;
                equiposComputo.ValorComercial = this.txt_valor.Text;
                equiposComputo.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);

                if (idEqComputo > 0)
                {
                    db.Entry(equiposComputo).State = EntityState.Modified;
                    MessageBox.Show("Ruta actualizado exitosamente");
                }
                else
                {
                    db.EquiposComputo.Add(equiposComputo);
                    MessageBox.Show("Ruta agregada exitosamente");
                }

                db.SaveChanges();
                this.Close();
            }

        }

        private void AEEqComputo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VEquiposComputo")
            {
                VEquiposComputo veq = (VEquiposComputo)this._form;
                veq.Enabled = true;
                veq.CargarEquipos();

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarEquipo();
        }
    }
}
