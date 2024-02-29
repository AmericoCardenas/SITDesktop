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

namespace SIT.Views.Almacen.PHerramientas
{
    public partial class AEPHerramienta : Form
    {
        public AEPHerramienta(VPHerramientas vph)
        {
            InitializeComponent();
            _vph= vph;
        }

        VPHerramientas _vph;
        SITEntities db = new SITEntities();
        PrestamoHerramientas ph = new PrestamoHerramientas();
        public int IdUsuario,IdPrestamo;
        

        private void CargarEmpleados()
        {
                var x = this.db.Trabajadores.ToList();
                this.cmb_empleado.DataSource = x;
                this.cmb_empleado.ValueMember = "IdEmpleado";
                this.cmb_empleado.DisplayMember = "NombreCompleto";
        }

        private void CargarHerramientas()
        {
            var x = this.db.Herramientas.ToList();
            this.cmb_herramienta.DataSource = x;
            this.cmb_herramienta.ValueMember = "IdHerramienta";
            this.cmb_herramienta.DisplayMember = "Herramienta";
        }

        private void CargarEstatus()
        {
            var x = this.db.EstatusPHerramientas.ToList();
            this.cmb_estatus.DataSource = x;
            this.cmb_estatus.ValueMember = "IdEstatus";
            this.cmb_estatus.DisplayMember = "Estatus";
        }

        private void AEPHerramienta_Load(object sender, EventArgs e)
        {
            this.Text = "Agregar";
            CargarEmpleados();
            CargarHerramientas();
            CargarEstatus();

            this.txt_hora.Enabled = false;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            this.txt_hora.Text= currentTime.Hours +":"+currentTime.Minutes;
            this.txt_cantidad.Text = "0";

            if (IdPrestamo != 0)
            {
                ph = db.PrestamoHerramientas.Where(x => x.IdPrestamo == IdPrestamo).FirstOrDefault();
                this.dtm_fecha.Value = Convert.ToDateTime(ph.Fecha);
                this.txt_hora.Text = ph.Hora;
                this.txt_hora.Enabled=true;
                this.cmb_empleado.SelectedValue = ph.IdEmpleado;
                this.cmb_herramienta.SelectedValue = ph.IdHerramienta;
                this.txt_cantidad.Text = ph.Cantidad.ToString();
                this.Text = "Editar";
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarHerramienta();
        }

        private void AEPHerramienta_FormClosed(object sender, FormClosedEventArgs e)
        {
            _vph.Enabled = true;
            _vph.CargarDatos();
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AgregarHerramienta()
        {
            if (this.cmb_empleado.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
                this.cmb_empleado.Focus();
            }
            else if (this.cmb_herramienta.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar la herramienta");
                this.cmb_herramienta.Focus();
            }
            else if (this.txt_cantidad.Text == "")
            {
                MessageBox.Show("Favor de introducir la cantidad de la herramienta");
                this.txt_cantidad.Focus();
            }
            else if (this.txt_hora.Text == "")
            {
                MessageBox.Show("Favor de introducir la hora");
                this.txt_hora.Focus();
            }
            else
            {
                ph.IdHerramienta = Convert.ToInt32(this.cmb_herramienta.SelectedValue);
                ph.IdEmpleado = Convert.ToInt32(this.cmb_empleado.SelectedValue);
                ph.IdEstatus = Convert.ToInt32(this.cmb_estatus.SelectedValue);
                ph.Fecha = this.dtm_fecha.Value;
                ph.Hora = this.txt_hora.Text;
                ph.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                ph.FechaCreacion = DateTime.Now;
                ph.IdUsuarioCreacion = IdUsuario;

                if (IdPrestamo > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ph.IdUsuarioModificacion = this.IdUsuario;
                        ph.FechaModificacion = DateTime.Now;
                        db.Entry(ph).State = EntityState.Modified;
                        MessageBox.Show("Actualizado exitosamente");
                    }
                    else
                    {
                    }
                }
                else
                {
                    db.PrestamoHerramientas.Add(ph);
                    MessageBox.Show("Agregado exitosamente");
                }

                db.SaveChanges();
                this.Close();
                _vph.Enabled = true;
            }
        }
        
    }
}
