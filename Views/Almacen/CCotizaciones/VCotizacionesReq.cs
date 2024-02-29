using SIT.Views.General.CRequisiciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Almacen.CCotizaciones
{
    public partial class VCotizacionesReq : Form
    {
        public VCotizacionesReq(VAERequisicion vaereq)
        {
            InitializeComponent();
            this._vaereq = vaereq;
        }

        VAERequisicion _vaereq;
        public int IdUsuario;
        public string Producto, Cantidad,Observaciones;
        int idCotizacion=0;
        public DetalleRequisiciones deteq;
        CotizacionesRequisiciones cotizaciones = new CotizacionesRequisiciones();
        SITEntities db = new SITEntities();


        private void VCotizacionesReq_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._vaereq.Enabled = true;
        }

        private void CargarProveedores()
        {
            var x = this.db.Proveedores.Where(y=>y.IdEstatus==1).ToList();
            this.cmb_proveedor.DataSource = x;
            this.cmb_proveedor.ValueMember = "IdProveedor";
            this.cmb_proveedor.DisplayMember = "Proveedor";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarCotizacion();
        }

        private void dgrid_cotizaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_cotizaciones.CurrentCell.RowIndex != -1)
                {
                    idCotizacion = Convert.ToInt32(this.dgrid_cotizaciones.CurrentRow.Cells[0].Value);
                    cotizaciones = db.CotizacionesRequisiciones.Where(x => x.IdCotizacion == idCotizacion).FirstOrDefault();
                    this.cmb_proveedor.SelectedValue = cotizaciones.IdProveedor;
                    this.txt_cu.Text = cotizaciones.CostoUnitario.ToString();
                    this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                }


            }
            catch (Exception ex) { }
        }

        private void CargarCotizaciones()
        {
            idCotizacion = 0;
            this.txt_cu.Text = string.Empty;
            this.chk_iva.Checked = false;
            this.txt_total.Text = string.Empty;
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            var x = from n in db.CotizacionesRequisiciones
                    join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                    join e in db.EstatusCotizaciones on n.IdEstatus equals e.IdEstatus
                    where n.IdEstatus !=2 && n.IdDetalleReq==deteq.IdDetalleReq
                    select new
                    {
                        n.IdCotizacion,
                        p.Proveedor,
                        n.CostoUnitario,
                        n.Total,
                        e.Estatus
                    };

            this.dgrid_cotizaciones.DataSource = null;
            this.dgrid_cotizaciones.Refresh();
            this.dgrid_cotizaciones.DataSource = x.ToList();
            this.dgrid_cotizaciones.Columns[0].Visible = false;
            this.dgrid_cotizaciones.EnableHeadersVisualStyles = false;
            this.dgrid_cotizaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_cotizaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_cotizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CancelarCotizacion()
        {
            try
            {
                if (this.dgrid_cotizaciones.CurrentCell.RowIndex != -1 && this.dgrid_cotizaciones.CurrentCell != null)
                {
                    if (cotizaciones.IdEstatus == 3)
                    {
                        MessageBox.Show("La cotizacion no se puede eliminar debido a que ya se encuentra autorizada");
                        this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                        idCotizacion = 0;
                        cotizaciones=new CotizacionesRequisiciones();
                        this.txt_cu.Text = string.Empty;
                        this.txt_total.Text = string.Empty;

                    }
                    else if (cotizaciones.IdEstatus == 4)
                    {
                        MessageBox.Show("La cotizacion no se puede eliminar debido a que ya se encuentra rechazada");
                        this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                        idCotizacion = 0;
                        cotizaciones = new CotizacionesRequisiciones();
                        this.txt_cu.Text = string.Empty;
                        this.txt_total.Text = string.Empty;
                    }
                    else
                    {
                        cotizaciones.IdEstatus = 2;

                        if (idCotizacion > 0)
                        {
                            db.Entry(cotizaciones).State = EntityState.Modified;
                            db.SaveChanges();
                            CargarCotizaciones();
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
            catch (Exception ex)
            {

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar la cotizacion seleccionada", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarCotizacion();

            }
            else
            {
                // Do something
            }
        }

        private void txt_cu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var cant = Convert.ToDouble(Cantidad);
                var cu = Convert.ToDouble(this.txt_cu.Text);
                var total = cant * cu;
                if (chk_iva.Checked == true)
                {
                    total = total * 1.16;
                }
                this.txt_total.Text = total.ToString();
            }
            catch(Exception ex) { }
        }

        private void VCotizacionesReq_Load(object sender, EventArgs e)
        {
            CargarProveedores();

            if (deteq != null)
            {
                this.Text = "Cotización / Requisición #" + deteq.IdRequisicion.ToString() + " / Producto: "+Producto+" / Cantidad: "+Cantidad;
                this.lbl_productoinfo.Text = "Producto: " + Producto + "\nCantidad: " + Cantidad + " \nObservaciones: " + Observaciones;
                CargarCotizaciones();
            }
        }

        private bool VerificarCotizaciones()
        {
            bool result=false;
            foreach(DataGridViewRow row in this.dgrid_cotizaciones.Rows)
            {
                if (row.Cells[4].Value.ToString() == "AUTORIZADA")
                {
                    result= true;
                    break;
                }
                else
                {
                    result= false;
                }
            }
            return result;
        }

        private void AgregarCotizacion()
        {
            if (cotizaciones.IdEstatus == 3)
            {
                MessageBox.Show("La cotizacion no se puede editar debido a que ya se encuentra autorizada");
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                idCotizacion = 0;
                cotizaciones = new CotizacionesRequisiciones();
                this.txt_cu.Text = string.Empty;
                this.txt_total.Text = string.Empty;
            }
            else
            {
                if (VerificarCotizaciones() == true)
                {
                    MessageBox.Show("No se pueden agregar cotizaciones debido a que ya existe una cotizacion autorizada");
                }
                else
                {
                    if (this.cmb_proveedor.SelectedValue == null)
                    {
                        MessageBox.Show("Favor de seleccionar proveedor");
                        this.cmb_proveedor.Focus();
                    }
                    else if (this.txt_cu.Text == string.Empty || this.txt_cu.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Favor de insertar el costo unitario");
                        this.txt_cu.Focus();
                    }
                    else
                    {

                        cotizaciones.IdDetalleReq = deteq.IdDetalleReq;
                        cotizaciones.IdProveedor = Convert.ToInt32(this.cmb_proveedor.SelectedValue);
                        cotizaciones.CostoUnitario = Convert.ToDouble(this.txt_cu.Text);
                        cotizaciones.IdEstatus = 1;
                        var cant = Convert.ToDouble(Cantidad);
                        var cu = Convert.ToDouble(this.txt_cu.Text);
                        var total = cant * cu;
                        if (chk_iva.Checked == true)
                        {
                            total = total * 1.16;
                        }
                        cotizaciones.Total = total;

                        if (idCotizacion != 0)
                        {
                            db.Entry(cotizaciones).State = EntityState.Modified;

                        }
                        else
                        {
                            db.CotizacionesRequisiciones.Add(cotizaciones);

                        }
                        db.SaveChanges();

                        CargarCotizaciones();

                    }

                }
            }

        }


    }
}
