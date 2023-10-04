using SIT.Views.Contabilidad.CMovimientos;
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

namespace SIT.Views.Contabilidad.CNotas
{
    public partial class AENotas : Form
    {
        public AENotas(VNotas vnotas)
        {
            InitializeComponent();
            this._vnotas = vnotas;
        }

        public int IdUsuario;
        public int IdNota;
        SITEntities db = new SITEntities();
        NotasMovimientos not = new NotasMovimientos();
        VNotas _vnotas;


        private void LimpiarFormulario()
        {
            this.txt_cantidad.Text = string.Empty;
            this.txt_concepto.Text = string.Empty;
            this.txt_folio.Text = string.Empty;
        }

        private void AgregarNotas()
        {
            if (this.txt_folio.Text == "")
            {
                MessageBox.Show("Favor de introducir el folio");
                this.txt_folio.Focus();
            }
            else if (this.txt_concepto.Text == "")
            {
                MessageBox.Show("Favor de introducir el concepto");
                this.txt_concepto.Focus();
            }
            else if (this.txt_cantidad.Text == "")
            {
                MessageBox.Show("Favor de introducir la cantidad");
                this.txt_cantidad.Focus();
            }
            else
            {
                not.IdMovimiento = 0;
                not.Folio = this.txt_folio.Text.ToUpper();
                not.Fecha = this.dtm_fecha.Value;
                not.Concepto = this.txt_concepto.Text.ToUpper();
                not.Total = Convert.ToDouble(this.txt_cantidad.Text);
                not.FechaCreacion = DateTime.Now;
                not.UsuarioCreo = this.IdUsuario;
                not.IdEstatus = 1;

                if (IdNota > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        not.Folio = this.txt_folio.Text.ToUpper();
                        not.Fecha = this.dtm_fecha.Value;
                        not.Concepto = this.txt_concepto.Text.ToUpper();
                        not.Total = Convert.ToDouble(this.txt_cantidad.Text);
                        not.UsuarioModificacion = this.IdUsuario;
                        not.FechaModificacion = DateTime.Now;
                        db.Entry(not).State = EntityState.Modified;
                        MessageBox.Show("Nota actualizada exitosamente");
                        this.btn_add.BackgroundImage = Properties.Resources.mas;
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        LimpiarFormulario();
                        this.btn_add.BackgroundImage = Properties.Resources.mas;
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else
                {
                    db.NotasMovimientos.Add(not);
                    MessageBox.Show("Nota agregada exitosamente");
                }

                db.SaveChanges();
                LimpiarFormulario();
                this.Close();
                _vnotas.Enabled = true;
            }
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarNotas();
        }

        private void AENotas_Load(object sender, EventArgs e)
        {
            if (IdNota != 0)
            {
                not = db.NotasMovimientos.Where(x => x.IdNota == IdNota).FirstOrDefault();
                this.dtm_fecha.Value = not.Fecha.Value;
                this.txt_cantidad.Text = not.Total.ToString();
                this.txt_concepto.Text = not.Concepto;
                this.txt_folio.Text = not.Folio;

                this.Text = "Editar";
            }
        }
    }
}
