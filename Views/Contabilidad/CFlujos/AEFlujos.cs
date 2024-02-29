using GMap.NET;
using SIT.Views.Contabilidad.CMovimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Contabilidad.CFlujos
{
    public partial class AEFlujos : Form
    {
        public AEFlujos(VFlujos frm)
        {
            InitializeComponent();
           this.vflujos = frm;

        }

        VFlujos vflujos;
        public int IdFlujo; 
        public int _uslog;
        SITEntities db = new SITEntities();
        string filename;
        OpenFileDialog op1 = new OpenFileDialog();
        Flujos flujos = new Flujos();
        string ruta = "\\\\192.168.1.213\\OneDrive - TRANSPORTES DAVILA\\Transportes Davila\\7.- Contabilidad1\\ArchivosFlujos\\";



        private void AgregarFlujo()
        {
            if (this.cmb_tipo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el tipo");
            }
            else if (this.cmb_metodo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el metodo");
            }
            else if (this.cmb_empleado.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
            }
            else if (this.cmb_area.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el area");
            }
            else if (this.txt_concepto.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el concepto");
            }
            else if (this.txt_cantidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el concepto");
            }
            else
            {
                flujos.Fecha = this.dtm_fecha.Value;
                flujos.IdTipo = Convert.ToInt32(this.cmb_tipo.SelectedValue);
                flujos.IdMetodo = Convert.ToInt32(this.cmb_metodo.SelectedValue);
                flujos.IdEmpleado = Convert.ToInt32(this.cmb_empleado.SelectedValue);
                flujos.IdDepto = Convert.ToInt32(this.cmb_area.SelectedValue);
                flujos.Descripcion = this.txt_concepto.Text.ToUpper();
                flujos.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                flujos.IdEstatus = 1;
                flujos.IdUsuarioCreo = _uslog;
                flujos.FechaCreacion = DateTime.Now;

                if (filename != "")
                {
                    flujos.Ruta = ruta;
                    flujos.Comprobante = filename;
                    int count = 0;

                    string[] FName;

                    foreach (string s in op1.FileNames)

                    {

                        FName = s.Split('\\');

                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(s, ruta + FName[FName.Length - 1]);
                        }


                        count++;

                    }
                }

                if (IdFlujo > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        flujos.IdUsuarioModifico = _uslog;
                        flujos.FechaModifico = DateTime.Now;
                        db.Entry(flujos).State = EntityState.Modified;
                        MessageBox.Show("Flujo actualizado exitosamente");
                        this.btn_add.BackgroundImage = Properties.Resources.mas;
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        LimpiarFormulario();
                        IdFlujo = 0;
                        this.btn_add.BackgroundImage = Properties.Resources.mas;
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                }
                else
                {
                    db.Flujos.Add(flujos);
                    MessageBox.Show("Concepto agregado exitosamente");
                }

                db.SaveChanges();
                LimpiarFormulario();
                this.Close();
            }
        }

        private void CargarTipos()
        {
            var x = db.TiposFlujos.ToList();
            this.cmb_tipo.DataSource = x;
            this.cmb_tipo.DisplayMember = "Tipo";
            this.cmb_tipo.ValueMember = "IdTipo";
        }

        private void CargarMetodo()
        {
            var x = db.MetodosFlujos.ToList();
            this.cmb_metodo.DataSource = x;
            this.cmb_metodo.DisplayMember = "Metodo";
            this.cmb_metodo.ValueMember = "IdMetodo";
        }

        private void CargarEmpleados()
        {
            var x = db.Trabajadores.ToList();
            this.cmb_empleado.DataSource = x;
            this.cmb_empleado.DisplayMember = "NombreCompleto";
            this.cmb_empleado.ValueMember = "IdEmpleado";
        }

        private void CargarDeptos()
        {
            var x = db.Departamentos.ToList();
            this.cmb_area.DataSource = x;
            this.cmb_area.DisplayMember = "Departamento";
            this.cmb_area.ValueMember = "IdDepto";

        }

        private void LimpiarFormulario()
        {
            this.txt_cantidad.Text = string.Empty;
            this.txt_concepto.Text = string.Empty;
            this.btn_archivo.BackColor = Color.DeepSkyBlue;
        }

        private void btn_archivo_Click(object sender, EventArgs e)
        {
            op1.Multiselect = true;
            op1.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op1.ShowDialog();
            filename = op1.SafeFileName;
            this.btn_archivo.BackColor = Color.Green;
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AEFlujos_Load(object sender, EventArgs e)
        {
            CargarTipos();
            CargarMetodo();
            CargarEmpleados();
            CargarDeptos();

            if (IdFlujo != 0)
            {
                flujos = db.Flujos.Where(x => x.IdFlujo == IdFlujo).FirstOrDefault();

                this.dtm_fecha.Value = flujos.Fecha.Value;
                this.cmb_tipo.SelectedValue = flujos.IdTipo;
                this.cmb_metodo.SelectedValue = flujos.IdMetodo;
                this.cmb_empleado.SelectedValue = flujos.IdEmpleado;
                this.cmb_aa.SelectedValue = flujos.IdDepto;
                this.txt_concepto.Text = flujos.Descripcion;
                this.txt_cantidad.Text = flujos.Cantidad.ToString();
                filename = flujos.Comprobante;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarFlujo();
        }

        private void AEFlujos_FormClosed(object sender, FormClosedEventArgs e)
        {
            vflujos.Enabled = true;
            vflujos.CargarFlujos();
        }
    }
}
