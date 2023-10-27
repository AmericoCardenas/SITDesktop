using SIT.Views.Almacen;
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

namespace SIT.Views.Catalogos.CProductosSnack
{
    public partial class AEProductosSnack : Form
    {
        public AEProductosSnack(VProductosSnack vprods)
        {
            InitializeComponent();
            this._vps = vprods;
        }

        VProductosSnack _vps;
        SITEntities db = new SITEntities();
        ProductosSnack ps = new ProductosSnack();
        public int IdUsuario, IdProducto;

        private void AEProductosSnack_Load(object sender, EventArgs e)
        {
            this.Text = "Agregar";
            CargarMedidas();

            if (IdProducto != 0)
            {
                ps = db.ProductosSnack.Where(x => x.IdProducto == IdProducto).FirstOrDefault();
                this.txt_producto.Text = ps.Producto;
                this.txt_costo.Text=ps.Precio.ToString();
                this.txt_cantidad.Text= ps.Cantidad.ToString();
                this.cmb_medida.SelectedItem = ps.IdMedida;
                this.Text = "Editar";
            }
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void AgregarProducto()
        {
            if (this.cmb_medida.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar la medida");
                this.cmb_medida.Focus();
            }
            else if (this.txt_cantidad.Text == "")
            {
                MessageBox.Show("Favor de introducir la cantidad");
                this.txt_cantidad.Focus();
            }
            else if (this.txt_costo.Text == "")
            {
                MessageBox.Show("Favor de introducir el costo");
                this.txt_costo.Focus();
            }
            else if (this.txt_producto.Text == "")
            {
                MessageBox.Show("Favor de introducir el producto");
                this.txt_producto.Focus();
            }
            else
            {
                ps.Producto = this.txt_producto.Text.ToUpper().ToString();
                ps.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                ps.Precio = Convert.ToDouble(this.txt_costo.Text);
                ps.IdMedida = Convert.ToInt32(this.cmb_medida.SelectedValue);
                ps.IdEstatus = 1;
                ps.FechaCreacion = DateTime.Now;
                ps.IdUsuarioCreo = IdUsuario;

                if (IdProducto > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        ps.IdUsuarioModifico = this.IdUsuario;
                        ps.FechaModifico = DateTime.Now;
                        db.Entry(ps).State = EntityState.Modified;
                        MessageBox.Show("Actualizado exitosamente");
                    }
                    else
                    {
                    }
                }
                else
                {
                    db.ProductosSnack.Add(ps);
                    MessageBox.Show("Agregado exitosamente");
                }

                db.SaveChanges();
                this.Close();
                _vps.Enabled = true;
            }
        }

        private void AEProductosSnack_FormClosed(object sender, FormClosedEventArgs e)
        {
            _vps.Enabled = true;
            _vps.CargarDatos();

        }

        private void CargarMedidas()
        {
            var x = this.db.Medidas.ToList();
            this.cmb_medida.DataSource = x;
            this.cmb_medida.ValueMember = "IdMedida";
            this.cmb_medida.DisplayMember = "Medida";
        }
    }
}
