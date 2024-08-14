using SIT.Views.General.CRequisiciones;
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

namespace SIT.Views.Almacen.CSalidas
{
    public partial class AESalida : Form
    {
        public AESalida(VSalidas vsalidas)
        {
            InitializeComponent();
            this._vsalidas = vsalidas;
        }

        SITEntities db = new SITEntities(); 
        DetalleSalidasAlmacen detalleSalidas = new DetalleSalidasAlmacen();
        SalidasAlmacen salidas =new SalidasAlmacen();
        ProductosAlmacen prod = new ProductosAlmacen();
        VSalidas _vsalidas;
        int idDetalleSalida = 0;
        public Usuarios us;
        public int IdSalida;

        private void CargarEmpleados()
        {
            var x = db.Trabajadores.Where(y=>y.IdEstatus==1).ToList();
            this.cmb_empleado.DataSource = x;
            this.cmb_empleado.ValueMember = "IdEmpleado";
            this.cmb_empleado.DisplayMember = "NombreCompleto";
        }

        private void CargarProductos()
        {
            var x = db.ProductosAlmacen.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_producto.DataSource = x;
            this.cmb_producto.ValueMember = "IdProducto";
            this.cmb_producto.DisplayMember = "Nombre";
        }

        private void CargarUnidades()
        {
            var x = db.Unidades.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_unidad.DataSource = x;
            this.cmb_unidad.ValueMember = "IdUnidad";
            this.cmb_unidad.DisplayMember = "Economico";
        }

        private void IniciarSalida()
        {
            salidas.FCreo = DateTime.Now;
            salidas.IdUsCreo = this.us.IdUsuario;
            salidas.IdEmpleado = 0;
            salidas.Fecha = DateTime.Now;
            salidas.Hora = DateTime.Now.ToString("h:mm");
            salidas.IdEstatus = 1;
            db.SalidasAlmacen.Add(salidas);
            db.SaveChanges();
            IdSalida = salidas.IdSalida;
            this.txt_num_salida.Text = IdSalida.ToString();
            this.Text = "VALE DE SALIDA ALMACEN #" + IdSalida.ToString();
        }

        private void CargarSalida()
        {
            salidas = db.SalidasAlmacen.Where(x => x.IdSalida == IdSalida).FirstOrDefault();
            this.cmb_empleado.SelectedValue = Convert.ToInt32(salidas.IdEmpleado);
            this.txt_num_salida.Text = salidas.IdSalida.ToString();
            this.txt_hora.Text = salidas.Hora.ToString();
            this.dtm_fecha.Value = Convert.ToDateTime(salidas.Fecha);

            if(salidas.IdEstatus==3)
            {
                this.btn_acept.Enabled = false;
                this.btn_add.Enabled = false;
                this.btn_cancel.Enabled=false;
                this.cmb_empleado.Enabled=false;
                this.cmb_producto.Enabled=false;
                this.cmb_unidad.Enabled=false;
                this.txt_cantidad.Enabled=false;
                this.txt_hora.Enabled=false;
                this.txt_num_salida.Enabled=false;
                this.dtm_fecha.Enabled=false;
            }
        }

        private void CargarDetalles()
        {
            try
            {
                idDetalleSalida = 0;
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

                var detalles = from n in db.DetalleSalidasAlmacen
                               join p in db.ProductosAlmacen on n.IdProducto equals p.IdProducto
                               join u in db.Unidades on n.IdUnidad equals u.IdUnidad
                               join e in db.EstatusSalidas on n.IdEstatus equals e.IdEstatus
                               where n.IdEstatus != 2 && n.IdSalidaAlmacen == IdSalida
                               select new
                               {
                                   n.IdDetalleSal,
                                   p.CodProducto,
                                   p.IdProducto,
                                   p.Nombre,
                                   n.Cantidad,
                                   u.Economico,
                                   e.Estatus
                               };

                this.dgrid_detallesalida.Refresh();
                this.dgrid_detallesalida.DataSource = null;
                this.dgrid_detallesalida.DataSource = detalles.ToList();
                this.dgrid_detallesalida.Columns[0].Visible = false;
                this.dgrid_detallesalida.Columns[2].Visible = false;
                this.dgrid_detallesalida.EnableHeadersVisualStyles = false;
                this.dgrid_detallesalida.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                this.dgrid_detallesalida.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dgrid_detallesalida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex) { }
        }

        private bool VerificarExistenciaDeProducto(string nombreproducto)
        {
            foreach (DataGridViewRow row in this.dgrid_detallesalida.Rows)
            {
                // Assuming the item name is in the second column (index 1)
                string producto = row.Cells[2].Value?.ToString();

                // Check if the item exists
                if (producto != null && producto.Equals(nombreproducto))
                {
                    return true; // Item exists
                }
            }

            return false; // Item does not exist
        }

        private void AgregarDetalleSalidas()
        {
            if (this.dgrid_detallesalida.CurrentRow != null && this.dgrid_detallesalida.CurrentRow.Cells[6].Value.ToString() == "APLICADA")
            {
                MessageBox.Show("No se puede agregar o editar el producto ya que el vale de salida ya fue aplicado al almacen");

            }
            else
            {
                if (this.cmb_producto.SelectedValue == null)
                {
                    MessageBox.Show("Favor de seleccionar el producto");
                    this.cmb_producto.Focus();
                }
                else if (this.txt_cantidad.Text == string.Empty || this.txt_cantidad.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Favor de capturar la cantidad del producto");
                    this.txt_cantidad.Focus();

                }
                else if (this.cmb_unidad.SelectedValue == null)
                {
                    MessageBox.Show("Favor de seleccionar la unidad");
                    this.cmb_unidad.Focus();
                }
                else
                {
                    var idprod = Convert.ToInt32(this.cmb_producto.SelectedValue);
                    prod = this.db.ProductosAlmacen.Where(x=>x.IdProducto==idprod).First();

                    if (VerificarExistenciaDeProducto(this.cmb_producto.Text) == true && idDetalleSalida == 0)
                    {
                        MessageBox.Show("El producto ya existe en el vale de salida");
                    }
                    else if (prod.Stock==0 || prod.Stock==null)
                    {
                        MessageBox.Show("No se puede realizar la salida para este producto, debido a que cuenta con 0 existencias");
                    }
                    else
                    {
                        detalleSalidas.IdSalidaAlmacen = IdSalida;
                        detalleSalidas.IdProducto = Convert.ToInt32(this.cmb_producto.SelectedValue);
                        detalleSalidas.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                        detalleSalidas.IdUnidad = Convert.ToInt32(this.cmb_unidad.SelectedValue);
                        detalleSalidas.IdEstatus = 1;
                        detalleSalidas.FCreo = DateTime.Now;
                        detalleSalidas.IdUsCreo = this.us.IdUsuario;

                        if (idDetalleSalida != 0)
                        {
                            db.Entry(detalleSalidas).State = EntityState.Modified;
                        }
                        else
                        {
                            db.DetalleSalidasAlmacen.Add(detalleSalidas);
                        }

                        db.SaveChanges();

                        this.cmb_producto.SelectedIndex = 0;
                        this.cmb_unidad.SelectedIndex = 0;
                        this.txt_cantidad.Text = string.Empty;

                        CargarDetalles();
                    }
                }

            }

        }

        private void AESalida_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarProductos();
            CargarUnidades();
            if (IdSalida == 0)
            {
                IniciarSalida();
            }
            else
            {
                CargarSalida();
            }

            CargarDetalles();

            this.Text = "Vale de Salida de Almacen";
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
            AgregarDetalleSalidas();
        }

        private void cmb_producto_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txt_cantidad.Text = string.Empty;
                this.cmb_unidad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {

            }
        }

        private void txt_hora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void dgrid_detallesalida_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_detallesalida.CurrentCell.RowIndex != -1)
                {
                    idDetalleSalida = Convert.ToInt32(this.dgrid_detallesalida.CurrentRow.Cells[0].Value);
                    detalleSalidas = db.DetalleSalidasAlmacen.Where(x => x.IdDetalleSal == idDetalleSalida).FirstOrDefault();
                    this.cmb_producto.SelectedValue = detalleSalidas.IdProducto;
                    this.txt_cantidad.Text = detalleSalidas.Cantidad.ToString();
                    this.cmb_unidad.SelectedValue = detalleSalidas.IdUnidad;
                    this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                }


            }
            catch (Exception ex) { }
        }

        private void EliminarDetalleProducto()
        {
            try
            {
                if (this.dgrid_detallesalida.CurrentCell.RowIndex != -1 && this.dgrid_detallesalida.CurrentCell != null)
                {

           
                        detalleSalidas.IdEstatus = 2;
                        detalleSalidas.FCan=DateTime.Now;
                        detalleSalidas.IdUsCan = this.us.IdUsuario;

                        if (idDetalleSalida > 0)
                        {
                            db.Entry(detalleSalidas).State = EntityState.Modified;
                            db.SaveChanges();
                            CargarDetalles();
                        }
                        else
                        {
                            MessageBox.Show("Favor de seleccionar el producto a cancelar");
                        }
                    


                }
                else
                {
                    MessageBox.Show("Favor de seleccionar el producto a cancelar");
                }

            }
            catch (Exception ex)
            {

            }



        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el producto", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                EliminarDetalleProducto();

            }
            else
            {
                // Do something
            }
        }

        private void btn_acept_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea terminar la salida de almacen? \n Esto afectara el almacen y sus existencias", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                TerminarDetalleSalida();

            }
            else
            {
                // Do something
            }
        }

        private void TerminarDetalleSalida()
        {

            if (this.dgrid_detallesalida.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar proudctos para poder crear la requisicion");
                this.dgrid_detallesalida.Focus();
            }
            else if (this.cmb_empleado.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
                this.cmb_empleado.Focus();
            }
            else if (this.txt_hora.Text == string.Empty)
            {
                MessageBox.Show("Favor de introducir la hora");
                this.txt_hora.Focus();
            }
            else
            {

                salidas.Fecha = this.dtm_fecha.Value;
                salidas.Hora = this.txt_hora.Text;
                salidas.IdEmpleado = Convert.ToInt32(this.cmb_empleado.SelectedValue);
                salidas.IdUsMod = this.us.IdUsuario;
                salidas.IdEstatus = 3;
                salidas.FMod = DateTime.Now;
                db.Entry(salidas).State = EntityState.Modified;
                db.SaveChanges();

                GenerarSalidaAlmacen();
                MessageBox.Show("Se ha generado el vale de salida " + IdSalida.ToString() + " exitosamente");
                this.Close();
            }
        }

        private void AESalida_FormClosed(object sender, FormClosedEventArgs e)
        {
            _vsalidas.Enabled = true;
            _vsalidas.CargarSalidas();
        }

        private void GenerarSalidaAlmacen()
        {
            foreach(DataGridViewRow row in this.dgrid_detallesalida.Rows)
            {
                var idDetalleSalida= Convert.ToInt32(row.Cells[0].Value);
                var idProducto = Convert.ToInt32(row.Cells[2].Value);
                var cantidad = Convert.ToDouble(row.Cells[4].Value);
                var producto = this.db.ProductosAlmacen.Where(x=>x.IdProducto==idProducto).FirstOrDefault();
                var stock = Convert.ToDouble(producto.Stock);
                var newstock = Convert.ToDouble((stock - cantidad));
                producto.Stock = newstock;
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();

                detalleSalidas = db.DetalleSalidasAlmacen.Where(x => x.IdDetalleSal == idDetalleSalida).FirstOrDefault();
                detalleSalidas.IdEstatus = 3;
                db.Entry(detalleSalidas).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        private void txt_cod_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    BuscarxCodProducto();
                }

            }
            catch (Exception ex) { }
        }

        private void BuscarxCodProducto()
        {
            if (this.txt_cod.Text != string.Empty && this.txt_cod.Text.Trim().Length > 0)
            {
                var idprod = db.ProductosAlmacen.Where(y => y.CodProducto == this.txt_cod.Text).Select(x => x.IdProducto).First();
                if (idprod != null)
                {
                    this.cmb_producto.SelectedValue = idprod;
                }
                else
                {
                    MessageBox.Show("El codigo no existe en el catalogo de productos");
                    this.cmb_producto.SelectedValue = 0;
                    this.txt_cod.Focus();

                }
            }
        }
    }
}
