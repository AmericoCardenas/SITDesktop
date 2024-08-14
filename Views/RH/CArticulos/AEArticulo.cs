using DocumentFormat.OpenXml.Wordprocessing;
using GMap.NET;
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

namespace SIT.Views.RH.CArticulos
{
    public partial class AEArticulo : Form
    {
        public AEArticulo(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        public int idArticulo;
        SITEntities db = new SITEntities();
        CatArticulosRh cat = new CatArticulosRh();
        public Usuarios uslog;
        Form _form;

        private void CargarMedidas()
        {
            var x = this.db.Medidas.ToList();
            this.cmb_medida.DataSource = x;
            this.cmb_medida.DisplayMember = "Medida";
            this.cmb_medida.ValueMember = "IdMedida";
        }

        private void AEArticulo_Load(object sender, EventArgs e)
        {
            CargarMedidas();


            if (idArticulo != 0)
            {
                cat = db.CatArticulosRh.Where(y => y.IdArticulo == idArticulo).FirstOrDefault();
                this.txt_articulo.Text = cat.Articulo;
                this.txt_max.Text = cat.Max.ToString();
                this.txt_min.Text = cat.Min.ToString();
                this.txt_stock.Text = cat.Stock.ToString();
                this.Text = "Editar "+ cat.Articulo;
            }
            else
            {
                this.Text = "Agregar Articulo";
            }
        }

        private void AgregarArticulo()
        {
            if(this.txt_articulo.Text==string.Empty || this.txt_articulo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el articulo");
                this.txt_articulo.Focus();
            }
            else if(this.txt_max.Text==string.Empty || this.txt_max.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el stock maximo del articulo");
                this.txt_max.Focus();

            }
            else if (this.txt_min.Text == string.Empty || this.txt_min.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el stock minimo del articulo");
                this.txt_min.Focus();

            }
            else if (this.txt_stock.Text == string.Empty || this.txt_stock.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el stock actual del articulo");
                this.txt_stock.Focus();
            }
            else if (this.cmb_medida.SelectedValue==null)
            {
                MessageBox.Show("Favor de seleccionar la medida del articulo");
                this.cmb_medida.Focus();
            }
            else
            {
                cat.Articulo = this.txt_articulo.Text.ToUpper();
                cat.IdEstatus = 1;
                cat.IdMedida = Convert.ToInt32(this.cmb_medida.SelectedValue);
                cat.Max = Convert.ToDouble(this.txt_max.Text);
                cat.Min=Convert.ToDouble(this.txt_min.Text);
                cat.Stock = Convert.ToDouble(this.txt_stock.Text);

                if (idArticulo != 0)
                {
                    cat.IdUsMod = this.uslog.IdUsuario;
                    cat.FMod = DateTime.Now;
                    db.Entry(cat).State = EntityState.Modified;
                    MessageBox.Show("Articulo actualizado exitosamente");
                }
                else
                {
                    cat.IdUsCreo= this.uslog.IdUsuario;
                    cat.FCreo = DateTime.Now;
                    db.CatArticulosRh.Add(cat);
                    MessageBox.Show("Articulo agregado exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }




        private void txt_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarArticulo();
        }

        private void AEArticulo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VArticulos")
            {
                VArticulos frm = (VArticulos)this._form;
                frm.CargarArticulos();
                frm.Enabled = true;
            }
        }
    }
}
