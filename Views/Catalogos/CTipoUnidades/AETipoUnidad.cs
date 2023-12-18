using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Catalogos.CTipoUnidades
{
    public partial class AETipoUnidad : Form
    {
        public AETipoUnidad()
        {
            InitializeComponent();
        }

        public int IdTipo;
        public int IdUsuario;
        public VTipoUnidades vtipo;
        TipoUnidades tpu = new TipoUnidades();
        SITEntities db = new SITEntities();


        private void AgregarTipoUnidad()
        {
            bool succes;
            Double ver;

            succes = Double.TryParse(this.txt_rend.Text, out ver);
            if (this.txt_tipo.Text == "")
            {
                MessageBox.Show("Favor de introducir el tipo de unidad");
                this.txt_tipo.Focus();
            }
            else if (this.txt_rend.Text == "")
            {
                MessageBox.Show("Favor de introducir el rendimiento de la unidad");
                this.txt_rend.Focus();
            }
            else if (succes == false)
            {
                MessageBox.Show("Favor de introducir un rendimiento valido");
                this.txt_rend.Focus();
            }
            else
            {
                tpu.Unidad = this.txt_tipo.Text.ToUpper();
                tpu.Rendimiento = Convert.ToDouble(this.txt_rend.Text);
                tpu.IdEstatus = 1;
                tpu.FechaCreacion = DateTime.Now;
                tpu.IdUsuarioCreo = this.IdUsuario;

                if (IdTipo > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        tpu.Unidad = this.txt_tipo.Text.ToUpper();
                        tpu.Rendimiento = Convert.ToDouble(this.txt_rend.Text);
                        tpu.IdUsuarioModifico = this.IdUsuario;
                        tpu.FechaModificacion = DateTime.Now;
                        db.Entry(tpu).State = EntityState.Modified;
                        MessageBox.Show("Tipo de Unidad actualizada exitosamente");
                    }
                    else
                    {
                    }
                }
                else
                {
                    db.TipoUnidades.Add(tpu);
                    MessageBox.Show("Registro agregado exitosamente");
                }

                db.SaveChanges();
                this.Close();
                vtipo.Enabled = true;
                vtipo.CargarTipoUnidades();
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarTipoUnidad();
        }

        private void AETipoUnidad_Load(object sender, EventArgs e)
        {

            if (IdTipo != 0)
            {
                tpu = db.TipoUnidades.Where(x => x.IdTipo == IdTipo).FirstOrDefault();
                this.txt_tipo.Text = tpu.Unidad;
                this.Text = "Editar";
            }
        }

        private void txt_rend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
