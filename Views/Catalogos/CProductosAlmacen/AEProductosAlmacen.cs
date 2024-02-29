using SIT.Views.Almacen.CProductosAlmacen;
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

namespace SIT.Views.Catalogos.CProductosAlmacen
{
    public partial class AEProductosAlmacen : Form
    {
        public AEProductosAlmacen(VProductosAlmacen vprod)
        {
            InitializeComponent();
            this._vprod = vprod;
        }

        public int IdUsuario, IdProducto;
        SITEntities db = new SITEntities();
        ProductosAlmacen productos = new ProductosAlmacen();
        VProductosAlmacen _vprod;

        private void AEProductosAlmacen_Load(object sender, EventArgs e)
        {
            CargarMedidas();
            CargarAlmacenes();

            this.Text = "Agregar";
            this.txt_stock.Enabled = false;

            try
            {
                if (IdProducto != 0)
                {
                    productos = db.ProductosAlmacen.Where(x => x.IdProducto == IdProducto).FirstOrDefault();
                    this.txt_codinterno.Text = productos.CodProducto;
                    this.txt_nombre.Text = productos.Nombre;
                    this.txt_stock.Text = productos.Stock.ToString();
                    this.txt_exmin.Text = productos.ExMin.ToString();
                    this.txt_exmax.Text = productos.ExMax.ToString();
                    this.cmb_medida.SelectedValue = productos.IdMedida;
                    this.cmb_zona.SelectedValue = productos.IdZona;

                    var zona = db.ZonasAlmacen.Where(x => x.IdZona == productos.IdZona).FirstOrDefault();
                    var almacen = db.Almacenes.Where(x => x.IdAlmacen == zona.IdAlmacen).FirstOrDefault();
                    this.cmb_almacen.SelectedValue = almacen.IdAlmacen;
                    this.cmb_zona.SelectedValue=productos.IdZona;
                    this.txt_pasillo.Text = productos.Pasillo.ToString();
                    this.txt_anaquel.Text = productos.Anaquel.ToString();
                    if (productos.IdEstatus == 1)
                    {
                        this.rd_activo.Checked = true;
                        this.rd_inactivo.Checked = false;
                    }
                    else
                    {
                        this.rd_activo.Checked = false;
                        this.rd_inactivo.Checked = true;

                    }
                    this.Text = "Editar";
                }

            }catch(Exception ex) { }

        }

        private void CargarMedidas()
        {
            var x = this.db.Medidas.ToList();
            this.cmb_medida.DataSource = x;
            this.cmb_medida.ValueMember = "IdMedida";
            this.cmb_medida.DisplayMember = "Medida";
        }

        private void cmb__almacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var idAlmacen = Convert.ToInt32(this.cmb_almacen.SelectedValue);
                this.cmb_zona.DataSource = null;
                CargarZonas(idAlmacen);

            }
            catch(Exception ex) { }

        }

        private void CargarAlmacenes()
        {
            var x = this.db.Almacenes.ToList();
            this.cmb_almacen.DataSource = x;
            this.cmb_almacen.ValueMember = "IdAlmacen";
            this.cmb_almacen.DisplayMember = "Almacen";
        }


        private void CargarZonas(int idAlmacen)
        {
            this.cmb_zona.DataSource = null;
            var x = this.db.ZonasAlmacen.Where(z=>z.IdAlmacen==idAlmacen).ToList();
            this.cmb_zona.DataSource = x;
            this.cmb_zona.ValueMember = "IdZona";
            this.cmb_zona.DisplayMember = "Zona";
        }

        private void txt_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_exmin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_exmax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_pasillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void AEProductosAlmacen_FormClosed(object sender, FormClosedEventArgs e)
        {
            _vprod.Enabled = true;
            _vprod.CargarProductosAlmacen();
        }

        private void AgregarProducto()
        {
            if (this.cmb_medida.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar la medida");
                this.cmb_medida.Focus();
            }
            else if (this.txt_codinterno.Text == "" || this.txt_codinterno.Text.Trim().Length==0)
            {
                MessageBox.Show("Favor de introducir el codigo interno");
                this.txt_codinterno.Focus();
            }
            else if (this.txt_nombre.Text == "" || this.txt_nombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el nombre del producto");
                this.txt_nombre.Focus();
            }
            //else if (this.txt_stock.Text == "" || this.txt_stock.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("Favor de introducir el stock");
            //    this.txt_stock.Focus();
            //}
            else if (this.txt_exmin.Text == "" || this.txt_exmin.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir la existencia minima");
                this.txt_exmin.Focus();
            }
            else if (this.txt_exmax.Text == "" || this.txt_exmax.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir la existencia maxima");
                this.txt_exmax.Focus();
            }
            else if (this.cmb_almacen.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el almacen");
                this.cmb_almacen.Focus();
            }
            else if (this.cmb_zona.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar la zona");
                this.cmb_zona.Focus();
            }
            else if (this.txt_pasillo.Text == "" || this.txt_pasillo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el pasillo");
                this.txt_pasillo.Focus();
            }
            else if (this.txt_anaquel.Text == "" || this.txt_anaquel.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el anaquel");
                this.txt_anaquel.Focus();
            }
            else
            {
                productos.CodProducto = this.txt_codinterno.Text.ToUpper();
                productos.Nombre = this.txt_nombre.Text.ToUpper();
                if (this.txt_stock.Text == string.Empty)
                {
                    productos.Stock = 0.00;

                }
                else
                {
                    productos.Stock = Convert.ToDouble(this.txt_stock.Text);
                }
                productos.ExMin = Convert.ToDouble(this.txt_exmin.Text);
                productos.ExMax = Convert.ToDouble(this.txt_exmax.Text);
                productos.IdMedida = Convert.ToInt32(this.cmb_medida.SelectedValue);
                productos.IdZona = Convert.ToInt32(this.cmb_zona.SelectedValue);
                productos.Pasillo = Convert.ToInt32(this.txt_pasillo.Text);
                productos.Anaquel = this.txt_anaquel.Text.ToUpper();
                if (this.rd_activo.Checked == true)
                {
                    productos.IdEstatus = 1;
                }
                else if(this.rd_inactivo.Checked == true)
                {
                    productos.IdEstatus = 2;
                }

                productos.FechaCreo = DateTime.Now;
                productos.IdUsCreo = IdUsuario;

                if (IdProducto > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        productos.IdUsMod = this.IdUsuario;
                        productos.FechaMod = DateTime.Now;
                        db.Entry(productos).State = EntityState.Modified;
                        MessageBox.Show("Actualizado exitosamente");
                    }
                    else
                    {
                    }
                }
                else
                {
                    db.ProductosAlmacen.Add(productos);
                    MessageBox.Show("Agregado exitosamente");
                }

                db.SaveChanges();
                this.Close();
            }
        }
    }
}
