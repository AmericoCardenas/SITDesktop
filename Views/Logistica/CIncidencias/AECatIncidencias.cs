using DocumentFormat.OpenXml.Drawing.ChartDrawing;
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

namespace SIT.Views.Logistica.CIncidencias
{
    public partial class AECatIncidencias : Form
    {
        public AECatIncidencias(Form form)
        {
            InitializeComponent();
            this._form= form;
        }

        SITEntities db = new SITEntities();
        public Usuarios _uslog;
        CatIncidencias incidencia = new CatIncidencias();
        public int idIncidencia;
        Form _form;

        private void CargarDatos()
        {
            if (idIncidencia != 0)
            {
                incidencia = db.CatIncidencias.Where(x=>x.IdIncidencia == idIncidencia).First();
                this.txt_descripcion.Text = incidencia.Descripcion.ToUpper();
                this.txt_monto.Text= incidencia.Monto.ToString();
                this.Text = "Editar";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        

        private void AECatIncidencias_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    
        private void AgregarTipoInc()
        {
            if(this.txt_monto.Text==string.Empty || this.txt_monto.Text.Trim().Length==0) {
                MessageBox.Show("Favor de capturar el monto de la incidencia");
                this.txt_monto.Focus();
            }
            else if(this.txt_descripcion.Text == string.Empty || this.txt_descripcion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el nombre de la incidencia");
                this.txt_descripcion.Focus();
            }
            else
            {
                incidencia.Descripcion=this.txt_descripcion.Text.ToUpper();
                incidencia.Monto=Convert.ToDouble(this.txt_monto.Text);
                incidencia.FCreo=DateTime.Now;
                incidencia.IdUsCreo = this._uslog.IdUsuario;
                incidencia.IdEstatus = 1;

                if (idIncidencia > 0)
                {
                    DialogResult result = MessageBox.Show("¿Desea editar?", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        incidencia.IdUsMod = this._uslog.IdUsuario;
                        incidencia.FMod = DateTime.Now;
                        db.Entry(incidencia).State = EntityState.Modified;
                        MessageBox.Show("Se ha actualizado exitosamente");
                    }
                    else
                    {
                    }

                }
                else
                {
                    db.CatIncidencias.Add(incidencia);
                    MessageBox.Show("Agregado exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarTipoInc();
        }

        private void txt_monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AECatIncidencias_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this._form.Name== "VCatIncidencia")
            {
                VCatIncidencia vcat = (VCatIncidencia)this._form;
                vcat.CargarCatalogoIncidencias();
                vcat.Enabled = true;
            }
        }
    }
}
