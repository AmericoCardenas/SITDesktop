using DocumentFormat.OpenXml.Bibliography;
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

namespace SIT.Views.RH.CSnack
{
    public partial class AESnack : Form
    {
        public AESnack(VSnack vsnack)
        {
            InitializeComponent();
            this._vsnack = vsnack;
        }

        VSnack _vsnack;
        public int idUsuario,idSnack,idlastidemp;
        SITEntities db = new SITEntities();
        Snack snack = new Snack();
        DateTime lastdate = new DateTime();
        Double precioU;

        private void AESnack_Load(object sender, EventArgs e)
        {
            this.Text = "Agregar";
            this.txt_total.Enabled = false;
            this.txt_preciou.Enabled = false;
            CargarEmpleados();
            CargarProductosSnack();
            CargarEstatus();
            CargarMetodos();

            if (idSnack != 0)
            {
                snack = db.Snack.Where(x => x.IdSnack == idSnack).FirstOrDefault();
                this.dtm_fecha.Value = Convert.ToDateTime(snack.Fecha);
                this.txt_hora.Text = snack.Hora.ToString();
                this.cmb_emp.SelectedValue = Convert.ToInt32(snack.IdEmpleado);
                this.cmb_producto.SelectedValue = Convert.ToInt32(snack.IdProducto);
                this.txt_cantidad.Text=snack.Cantidad.ToString();   
                this.txt_total.Text=snack.Total.ToString();
                this.cmb_metodop.SelectedValue = Convert.ToInt32(snack.IdMetodoPago);
                this.cmb_estatus.SelectedValue = Convert.ToInt32(snack.IdEstatus);
                this.Text = "Editar";
            }
        }

        private void CargarEmpleados()
        {
            var x = this.db.Trabajadores.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_emp.DataSource = x;
            this.cmb_emp.ValueMember = "IdEmpleado";
            this.cmb_emp.DisplayMember = "NombreCompleto";
        }

        private void CargarProductosSnack()
        {
            var x = this.db.ProductosSnack.Where(y=>y.IdEstatus==1).ToList();
            this.cmb_producto.DataSource = x;
            this.cmb_producto.ValueMember = "IdProducto";
            this.cmb_producto.DisplayMember = "Producto";
        }

        private void CargarEstatus()
        {
            var x = this.db.EstatusSnack.ToList();
            this.cmb_estatus.DataSource = x;
            this.cmb_estatus.ValueMember = "IdEstatus";
            this.cmb_estatus.DisplayMember = "Estatus";
        }

        private void CargarMetodos()
        {
            var x = this.db.TipoPagoSnack.ToList();
            this.cmb_metodop.DataSource = x;
            this.cmb_metodop.ValueMember = "IdTipoPago";
            this.cmb_metodop.DisplayMember = "Pago";
        }

        private void CalcularTotal()
        {
            try
            {
                this.txt_total.Text = string.Empty;
                var idproducto = Convert.ToInt32(this.cmb_producto.SelectedValue);
                if (idproducto != null)
                {
                    var producto = db.ProductosSnack.Where(x => x.IdProducto == idproducto).FirstOrDefault();
                    this.txt_preciou.Text = producto.Precio.ToString();
                    precioU = Convert.ToDouble(producto.Precio);

                    var cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                    if (cantidad != null)
                    {
                        var total = (cantidad * producto.Precio);
                        this.txt_total.Text = total.ToString();
                    }

                    else if(this.txt_cantidad.Text=="" || this.txt_cantidad.Text.Trim().Length == 0)
                    {
                        this.txt_total.Text = string.Empty;
                    }

                }
                else
                {
                    this.txt_total.Text = string.Empty;
                }
            }
            catch (Exception ex) { }
        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void cmb_producto_SelectedValueChanged(object sender, EventArgs e)
        {
            CalcularTotal(); 
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_hora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void AESnack_FormClosed(object sender, FormClosedEventArgs e)
        {
            _vsnack.Enabled = true;
            _vsnack.CargarSnack();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarSnack();
            LimpiarCampos();
            CargarDatosUltimoTicket();

        }

        private void AgregarSnack()
        {
            if (this.cmb_emp.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
                this.cmb_emp.Focus();
            }
            else if (this.cmb_estatus.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el estatus");
                this.cmb_estatus.Focus();
            }
            else if (this.cmb_metodop.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el metodo de pago");
                this.cmb_metodop.Focus();
            }
            else if (this.cmb_producto.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el producto");
                this.cmb_producto.Focus();
            }
            else if (this.txt_cantidad.Text == "" || this.txt_cantidad.Text.Trim().Length==0)
            {
                MessageBox.Show("Favor de introducir la cantidad");
                this.txt_cantidad.Focus();
            }
            else if (this.txt_hora.Text == "" || this.txt_hora.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir la hora de consumo");
                this.txt_hora.Focus();
            }
            else if (this.txt_total.Text == "" || this.txt_total.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el total");
                this.txt_total.Focus();
            }
            else
            {
                snack.Fecha = this.dtm_fecha.Value;
                snack.Hora = this.txt_hora.Text;
                snack.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                snack.IdProducto = Convert.ToInt32(this.cmb_producto.SelectedValue);
                snack.PrecioU = precioU;
                snack.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                snack.Total = Convert.ToDouble(this.txt_total.Text);
                snack.IdMetodoPago = Convert.ToInt32(this.cmb_metodop.SelectedValue);
                snack.IdEstatus = Convert.ToInt32(this.cmb_estatus.SelectedValue);
                snack.FechaCreacion = DateTime.Now;
                snack.IdUsuarioCreo = idUsuario;

                if (idSnack > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el consumo", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        snack.IdUsuarioModifico = idUsuario;
                        snack.FechaModificacion = DateTime.Now;
                        db.Entry(snack).State = EntityState.Modified;
                        MessageBox.Show("Actualizado exitosamente");
                    }
                    else
                    {
                    }
                }
                else
                {
                    db.Snack.Add(snack);
                    MessageBox.Show("Agregado exitosamente");
                }

                db.SaveChanges();
                this.idlastidemp = Convert.ToInt32(this.cmb_emp.SelectedValue);
                this.lastdate = this.dtm_fecha.Value;
               
                //this.Close();
            }
        }

        private void LimpiarCampos()
        {
            this.txt_hora.Text= string.Empty;
            this.txt_cantidad.Text= string.Empty;
            this.txt_preciou.Text= string.Empty;
            this.txt_total.Text= string.Empty;
            this.cmb_emp.SelectedIndex = 0;
            this.cmb_estatus.SelectedIndex = 0;
            this.cmb_metodop.SelectedIndex = 0;
            this.cmb_producto.SelectedIndex = 0;
            this.txt_hora.Text = "00:00";
           
        }

        private void CargarDatosUltimoTicket()
        {
            this.cmb_emp.SelectedValue = this.idlastidemp;
            this.dtm_fecha.Value = this.lastdate;
        }
    }
}
