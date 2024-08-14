using GMap.NET;
using SIT.SmtpEmail;
using SIT.Views.Almacen.CCotizaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.General.CRequisiciones
{
    public partial class VAERequisicion : Form
    {
        public VAERequisicion(VRequisiciones vreq)
        {
            InitializeComponent();
            this._vreq = vreq;
        }

        VRequisiciones _vreq;
        public int IdRequisicion, IdUsuario;
        public Usuarios usuario;
        DataTable dataTable = new DataTable();
        SITEntities db = new SITEntities();
        int idDetalleReq=0;
        Requisiciones requisiciones = new Requisiciones();
        DetalleRequisiciones detalleRequisiciones = new DetalleRequisiciones();
        EnviarEmail email = new EnviarEmail();

        private void VAERequisicion_Load(object sender, EventArgs e)
        {
            this.txt_descripcion.Visible = false;
            this.lbl_descripcion.Visible=false;
            this.lbl_cod.Visible=false;
            this.txt_codprod.Visible = false;

            CargarEmpleados();
            CargarProductos();


            if (this.usuario.IdDepto == 5 || this.usuario.IdDepto == 1 || this.usuario.IdDepto == 3)
            {
                this.btn_cotizar.Enabled = true;
                this.cmb_empleado.Enabled = true;
                this.lbl_cod.Visible = true;
                this.txt_codprod.Visible = true;


            }
            else
            {
                this.btn_cotizar.Enabled = false;
                this.cmb_empleado.SelectedValue = Convert.ToInt32(usuario.IdEmpleado);
                this.cmb_empleado.Enabled = false;

                this.cmb_producto.SelectedValue = 4253;
                this.cmb_producto.Visible = false;
                this.lbl_descripcion.Visible = true;
                this.txt_descripcion.Visible = true;

            }


            if (IdRequisicion == 0 && this.usuario.IdDepto == 5 || IdRequisicion == 0 && this.usuario.IdDepto == 1 || IdRequisicion == 0 && this.usuario.IdDepto == 3)
            {
                requisiciones.FechaCreo = DateTime.Now;
                requisiciones.IdUsCreo = IdUsuario;
                requisiciones.IdEmpleado = 0;
                requisiciones.Fecha = DateTime.Now;
                requisiciones.Hora = DateTime.Now.ToString("h:mm");
                requisiciones.IdEstatus = 1;
                db.Requisiciones.Add(requisiciones);
                db.SaveChanges();
                IdRequisicion = requisiciones.IdRequisicion;
                this.txt_numreq.Text = IdRequisicion.ToString();
                this.Text = "Requisicion R" + IdRequisicion.ToString();
            }
            else if (IdRequisicion == 0 && this.usuario.IdDepto != 5 && this.usuario.IdDepto != 1 && this.usuario.IdDepto != 3)
            {
                requisiciones.FechaCreo = DateTime.Now;
                requisiciones.IdUsCreo = IdUsuario;
                requisiciones.IdEmpleado = Convert.ToInt32(this.cmb_empleado.SelectedValue);
                requisiciones.Fecha = DateTime.Now;
                requisiciones.Hora = DateTime.Now.ToString("h:mm");
                requisiciones.IdEstatus = 1;
                db.Requisiciones.Add(requisiciones);
                db.SaveChanges();
                IdRequisicion = requisiciones.IdRequisicion;
                this.txt_numreq.Text = IdRequisicion.ToString();
                this.Text = "Requisicion R" + IdRequisicion.ToString();
            }
            else if (IdRequisicion != 0 && this.usuario.IdDepto == 5 || IdRequisicion != 0 && this.usuario.IdDepto == 1|| IdRequisicion != 0 && this.usuario.IdDepto == 3)
            {
                requisiciones = db.Requisiciones.Where(x => x.IdRequisicion == IdRequisicion).FirstOrDefault();
                this.cmb_empleado.SelectedValue = Convert.ToInt32(requisiciones.IdEmpleado);
                this.txt_numreq.Text = requisiciones.IdRequisicion.ToString();
                this.txt_hora.Text = requisiciones.Hora.ToString();
                this.dtm_fecha.Value = Convert.ToDateTime(requisiciones.Fecha);
                this.txt_obsreq.Text = requisiciones.Observaciones;


            }
            else if(IdRequisicion != 0 && this.usuario.IdDepto != 5 && this.usuario.IdDepto != 1 && this.usuario.IdDepto != 3)
            {
                requisiciones = db.Requisiciones.Where(x => x.IdRequisicion == IdRequisicion).FirstOrDefault();
                this.cmb_empleado.SelectedValue = Convert.ToInt32(requisiciones.IdEmpleado);
                this.cmb_empleado.Enabled = false;
                this.txt_numreq.Text = requisiciones.IdRequisicion.ToString();
                this.txt_hora.Text = requisiciones.Hora.ToString();
                this.dtm_fecha.Value = Convert.ToDateTime(requisiciones.Fecha);
                this.txt_obsreq.Text = requisiciones.Observaciones;

            }




            CargarDetalles();

            
        }

        private void CargarDetalles()
        {
            try
            {
                idDetalleReq = 0;
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

                var detalles = from n in db.DetalleRequisiciones
                               join p in db.ProductosAlmacen on n.IdProductoAlmacen equals p.IdProducto
                               where n.IdEstatus != 2 && n.IdRequisicion == IdRequisicion
                               select new
                               {
                                   n.IdDetalleReq,
                                   p.Nombre,
                                   n.Cantidad,
                                   n.Observaciones

                               };

                this.dgrid_detalleproductos.Refresh();
                this.dgrid_detalleproductos.DataSource = null;
                this.dgrid_detalleproductos.DataSource = detalles.ToList();
                if (this.usuario.IdDepto == 5 || this.usuario.IdDepto == 1 || this.usuario.IdDepto == 3)
                {
                    this.dgrid_detalleproductos.Columns[0].Visible = false;

                }
                else
                {
                    this.dgrid_detalleproductos.Columns[0].Visible = false;
                    //this.dgrid_detalleproductos.Columns[1].Visible = false;

                }
                this.dgrid_detalleproductos.EnableHeadersVisualStyles = false;
                this.dgrid_detalleproductos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                this.dgrid_detalleproductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dgrid_detalleproductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch(Exception ex) { }
        }

        private void CargarEmpleados()
        {
            var x = this.db.Trabajadores.Where(y=>y.IdEstatus==1 && y.IdPuesto==1).ToList();
            this.cmb_empleado.DataSource = x;
            this.cmb_empleado.ValueMember = "IdEmpleado";
            this.cmb_empleado.DisplayMember = "NombreCompleto";
        }

        private void CargarProductos()
        {
            var x = this.db.ProductosAlmacen.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_producto.DataSource = x;
            this.cmb_producto.ValueMember = "IdProducto";
            this.cmb_producto.DisplayMember = "Nombre";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarDetalleProductos();
        }

        private bool VerificarCotizacionesProducto()
        {
            var x = db.CotizacionesRequisiciones.Where(y=>y.IdDetalleReq==idDetalleReq && y.IdEstatus!=2).ToList();   
            if(x.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AgregarDetalleProductos()
        {
            if (VerificarCotizacionesProducto() == true)
            {
                MessageBox.Show("El producto no se puede editar debido a que tiene cotizaciones pendientes y/o autorizadas");
                idDetalleReq = 0;
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                this.txt_cantidad.Text = string.Empty;
                this.txt_descripcion.Text = string.Empty;


            }
            else
            {
                if (this.cmb_producto.SelectedValue == null)
                {
                    MessageBox.Show("Favor de seleccionar el producto");
                }
                else if (this.txt_cantidad.Text == string.Empty || this.txt_cantidad.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Favor de capturar la cantidad del producto");
                }
                else
                {
                    if (VerificarExistenciaDeProducto(this.cmb_producto.Text) == true && idDetalleReq == 0 && Convert.ToInt32(this.cmb_producto.SelectedValue)!= 4253)
                    {
                        MessageBox.Show("El producto ya existe en la requisicion");
                    }
                    else
                    {
                        detalleRequisiciones.IdRequisicion = IdRequisicion;
                        detalleRequisiciones.IdProductoAlmacen = Convert.ToInt32(this.cmb_producto.SelectedValue);
                        detalleRequisiciones.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                        detalleRequisiciones.Observaciones = this.txt_descripcion.Text.ToUpper();
                        detalleRequisiciones.IdEstatus = 1;

                        if (idDetalleReq != 0)
                        {
                            //db.Entry(requisiciones).State = EntityState.Modified;
                            db.Entry(detalleRequisiciones).State = EntityState.Modified;

                        }
                        else
                        {
                            db.DetalleRequisiciones.Add(detalleRequisiciones);
                        }

                        db.SaveChanges();


                        this.txt_cantidad.Text = string.Empty;
                        this.txt_descripcion.Text = string.Empty;

                        CargarDetalles();

                    }

                }

            }
        }



        private bool VerificarExistenciaDeProducto(string nombreproducto)
        {
            foreach (DataGridViewRow row in this.dgrid_detalleproductos.Rows)
            {
                // Assuming the item name is in the second column (index 1)
                string producto = row.Cells[1].Value?.ToString();

                // Check if the item exists
                if (producto != null && producto.Equals(nombreproducto))
                {
                    return true; // Item exists
                }
            }

            return false; // Item does not exist
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea eliminar el producto seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                EliminarDetalleProducto();

            }
            else
            {
                // Do something
            }
        }

        private void cmb_producto_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txt_descripcion.Text=string.Empty;
                this.txt_cantidad.Text = string.Empty;
            }
            catch(Exception ex)
            {

            }
        }

        private void AgregarDetalleRequisicion()
        {

            if (this.dgrid_detalleproductos.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar proudctos para poder crear la requisicion");
                this.dgrid_detalleproductos.Focus();
            }
            else if (this.cmb_empleado.SelectedValue==null)
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

                requisiciones.Fecha = this.dtm_fecha.Value;
                requisiciones.Hora = this.txt_hora.Text;
                requisiciones.Observaciones = this.txt_obsreq.Text.ToUpper();
                requisiciones.IdEmpleado = Convert.ToInt32(this.cmb_empleado.SelectedValue);
                requisiciones.IdUsMod = IdUsuario;
                requisiciones.FechaMod = DateTime.Now;
                db.Entry(requisiciones).State = EntityState.Modified;
                db.SaveChanges();

                if (usuario.IdDepto != 5)
                {
                    //ENVIAR EMAIL 
                    email.recipients.Add("compras@transportesdavila.com.mx");
                    email.recipients.Add("sistemas@transportesdavila.com.mx");
                    email.subject = "Requisicion #" + this.txt_numreq.Text.ToString() + " " + this.cmb_empleado.Text + " " + DateTime.Now.ToString();
                    var body = "Requisicion #"+this.txt_numreq.Text+"\n "+this.cmb_empleado.Text+"\n"+email.DataGridViewToHtml(this.dgrid_detalleproductos);
                    email.body = body;
                    email.SendEmail();
                }


                MessageBox.Show("Se ha generado la requisición " + IdRequisicion.ToString() + " exitosamente");
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

        private void btn_acept_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea terminar la requisicion", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                AgregarDetalleRequisicion();

            }
            else
            {
                // Do something
            }
        }

        private void dgrid_detalleproductos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_detalleproductos.CurrentCell.RowIndex != -1)
                {
                    idDetalleReq = Convert.ToInt32(this.dgrid_detalleproductos.CurrentRow.Cells[0].Value);
                    detalleRequisiciones = db.DetalleRequisiciones.Where(x => x.IdDetalleReq == idDetalleReq).FirstOrDefault();
                    this.cmb_producto.SelectedValue = detalleRequisiciones.IdProductoAlmacen;
                    this.txt_cantidad.Text = detalleRequisiciones.Cantidad.ToString();
                    this.txt_descripcion.Text=detalleRequisiciones.Observaciones.ToUpper();
                    this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                }


            }
            catch (Exception ex) { }
        }

        private void VAERequisicion_FormClosed(object sender, FormClosedEventArgs e)
        {
            _vreq.Enabled = true;
            _vreq.CargarRequisiciones();
        }

        private void btn_cotizar_Click(object sender, EventArgs e)
        {
            if (idDetalleReq == 0)
            {
                MessageBox.Show("Favor de seleccionar un producto a cotizar");
            }
            else
            {
                VCotizacionesReq frm = new VCotizacionesReq(this);
                frm.deteq = detalleRequisiciones;
                frm.Producto = this.dgrid_detalleproductos.CurrentRow.Cells[1].Value.ToString();
                frm.Cantidad = this.dgrid_detalleproductos.CurrentRow.Cells[2].Value.ToString();
                frm.Observaciones = this.dgrid_detalleproductos.CurrentRow.Cells[3].Value.ToString().ToUpper();
                frm.IdUsuario = this.IdUsuario;
                this.Enabled = false;
                frm.ShowDialog();
            }
        }

        private void txt_codprod_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    BuscarxCodProducto();
                }

            }
            catch(Exception ex) { }
        }

        private void EliminarDetalleProducto()
        {
            try
            {
                if (this.dgrid_detalleproductos.CurrentCell.RowIndex != -1 && this.dgrid_detalleproductos.CurrentCell!=null)
                {
                    if (VerificarCotizacionesProducto() == true)
                    {
                        MessageBox.Show("El producto no se puede eliminar debido a que tiene cotizaciones pendientes y/o autorizadas");
                        idDetalleReq = 0;
                        this.txt_cantidad.Text = string.Empty;
                        this.txt_descripcion.Text = string.Empty;
                        this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    else
                    {
                        detalleRequisiciones.IdEstatus = 2;

                        if (idDetalleReq > 0)
                        {
                            db.Entry(detalleRequisiciones).State = EntityState.Modified;
                            db.SaveChanges();
                            CargarDetalles();
                        }
                        else
                        {
                            MessageBox.Show("Favor de seleccionar el producto a cancelar");
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Favor de seleccionar el producto a cancelar");
                }

            }
            catch(Exception ex)
            {

            }



        }

        private void BuscarxCodProducto()
        {
            if(this.txt_codprod.Text!=string.Empty && this.txt_codprod.Text.Trim().Length>0)
            {
                var idprod = db.ProductosAlmacen.Where(y => y.CodProducto == this.txt_codprod.Text).Select(x => x.IdProducto).First();
                if (idprod != null)
                {
                    this.cmb_producto.SelectedValue = idprod;
                }
                else
                {
                    MessageBox.Show("El codigo no existe en el catalogo de productos");
                    this.cmb_producto.SelectedValue = 0;
                    this.txt_codprod.Focus();

                }
            }
        }

    }
}
