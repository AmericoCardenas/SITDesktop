using DocumentFormat.OpenXml.Drawing.Wordprocessing;
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

namespace SIT.Views.Sistemas.CLineas
{
    public partial class AELinea : Form
    {
        public AELinea(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        public int idLinea;
        SITEntities db = new SITEntities();
        Lineas lineas = new Lineas();
        Form _form;

        private void CargarEmpleados()
        {
            var x = this.db.Trabajadores.Where(y=>y.IdEstatus==1).ToList();
            this.cmb_emp.DataSource = x;
            this.cmb_emp.ValueMember = "IdEmpleado";
            this.cmb_emp.DisplayMember = "NombreCompleto";
        }
        private void CargarProveedores()
        {
            var x = db.Proveedores.ToList();
            this.cmb_prov.DataSource = x;
            this.cmb_prov.DisplayMember = "Proveedor";
            this.cmb_prov.ValueMember = "IdProveedor";

        }

        private void CargarEstatus()
        {
            var x = db.EstatusLineas.ToList();
            this.cmb_estatus.DataSource = x;
            this.cmb_estatus.DisplayMember = "Estatus";
            this.cmb_estatus.ValueMember = "IdEstatus";
        }

        private void InsertarLinea()
        {
            if (this.txt_linea.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar la linea");
            }
            else if (this.txt_sim.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el numero de simcard");
            }
            else if (this.cmb_prov.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el proveedor");
            }
            else if (this.cmb_emp.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
            }
            else
            {
                lineas.Linea = this.txt_linea.Text;
                lineas.NumSim = this.txt_sim.Text;
                lineas.IdProveedor = Convert.ToInt32(this.cmb_prov.SelectedValue);
                lineas.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                lineas.IdEstatus = Convert.ToInt32(this.cmb_estatus.SelectedValue);

                if (idLinea > 0)
                {
                    db.Entry(lineas).State = EntityState.Modified;
                    MessageBox.Show("Linea actualizado exitosamente");

                }
                else
                {
                    db.Lineas.Add(lineas);
                    MessageBox.Show("Linea agregada exitosamente");

                }

                db.SaveChanges();
                this.Close();
            }
        }

        private void AELinea_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarEstatus();
            CargarProveedores();

            if (idLinea > 0)
            {
                lineas = db.Lineas.Where(x => x.IdLinea == idLinea).FirstOrDefault();
                this.txt_linea.Text = lineas.Linea.ToString();
                this.txt_sim.Text = lineas.NumSim;
                this.cmb_prov.SelectedValue = lineas.IdProveedor;
                this.cmb_estatus.SelectedValue = lineas.IdEstatus;
                this.cmb_emp.SelectedValue = lineas.IdEmpleado;

                this.Text = "Editar";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            InsertarLinea();
        }

        private void AELinea_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VLineas")
            {
                VLineas vlinea = (VLineas)this._form;
                vlinea.Enabled = true;
                vlinea.CargarLineas();

            }
        }
    }
}
