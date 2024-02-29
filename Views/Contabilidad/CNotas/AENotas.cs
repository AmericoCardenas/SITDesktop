using DocumentFormat.OpenXml.Wordprocessing;
using SIT.Views.Almacen.COrdenesCompra;
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
        public AENotas(Form frm)
        {
            InitializeComponent();
            this._form = frm;
            if (frm.Name == "VNotas")
            {
                this._vnotas = (VNotas)_form;

            }
            else if(frm.Name == "VOrdenesCompra")
            {
                this._vordenes = (VOrdenesCompra)_form;
            }
        }

        public int IdUsuario,idprov;
        public int IdNota;
        Form _form;
        SITEntities db = new SITEntities();
        NotasMovimientos not = new NotasMovimientos();
        VNotas _vnotas;
        VOrdenesCompra _vordenes;

        public string folio, total;


        private void LimpiarFormulario()
        {
            this.txt_cantidad.Text = string.Empty;
            this.txt_concepto.Text = string.Empty;
            this.txt_folio.Text = string.Empty;
        }

        private void CargarProveedores()
        {
            var x = db.Proveedores.Where(z=>z.IdEstatus==1).ToList();
            this.cmb_proveedor.DataSource = x;
            this.cmb_proveedor.DisplayMember = "Proveedor";
            this.cmb_proveedor.ValueMember = "IdProveedor";
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
            else if (this.cmb_proveedor.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el proveedor");
                this.cmb_proveedor.Focus();
            }
            else
            {
                not.IdMovimiento = 0;
                not.Folio = this.txt_folio.Text.ToUpper();
                not.FechaPago = this.dtm_fechapago.Value;
                not.FechaFactura = this.dtm_fechafactura.Value;
                not.Concepto = this.txt_concepto.Text.ToUpper();
                not.IdProveedor = Convert.ToInt32(this.cmb_proveedor.SelectedValue);
                not.Total = Convert.ToDouble(this.txt_cantidad.Text);
                not.FechaCreacion = DateTime.Now;
                not.UsuarioCreo = this.IdUsuario;
                not.IdEstatus = 1;

                if (IdNota > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        //not.Folio = this.txt_folio.Text.ToUpper();
                        //not.FechaPago = this.dtm_fechapago.Value;
                        //not.Concepto = this.txt_concepto.Text.ToUpper();
                        //not.Total = Convert.ToDouble(this.txt_cantidad.Text);
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

                if (this._form.Name == "VOrdenesCompra")
                {
                    _vordenes.SaldarOCompra();
                }
                this.Close();
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
            CargarProveedores();
            if (IdNota != 0 && this._form.Name=="VNotas")
            {
                not = db.NotasMovimientos.Where(x => x.IdNota == IdNota).FirstOrDefault();
                this.dtm_fechapago.Value = not.FechaPago.Value;
                this.dtm_fechafactura.Value = not.FechaFactura.Value;
                this.txt_cantidad.Text = not.Total.ToString();
                this.txt_concepto.Text = not.Concepto;
                this.cmb_proveedor.SelectedItem = not.IdProveedor;
                this.txt_folio.Text = not.Folio;

                this.Text = "Editar";
            }

            if (this._form.Name=="VOrdenesCompra")
            {
                this.cmb_proveedor.SelectedValue = idprov;
                this.cmb_proveedor.Enabled = false;
                this.txt_folio.Text ="OC#"+folio;
                this.txt_folio.Enabled = false;
                this.txt_cantidad.Text = total;
                this.txt_cantidad.Enabled = false;
            }
        }

        private void AENotas_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VNotas")
            {
                _vnotas.Enabled = true;
                _vnotas.CargarNotas();

            }
            else if(this._form.Name == "VOrdenesCompra")
            {
                _vordenes.Enabled = true;
                _vordenes.CargarOrdenesCompraPend();
                //_vordenes.SaldarOCompra();
            }

        }
    }
}
