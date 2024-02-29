using DocumentFormat.OpenXml.Drawing;
using SIT.Views.General.CRequisiciones;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SIT.Views.Gerencia.CCotxAutorizar
{
    public partial class VCotxAutorizar : Form
    {
        public VCotxAutorizar(Usuarios usuarios)
        {
            InitializeComponent();
            this._uslog = usuarios;
        }

        SITEntities db = new SITEntities();
        Usuarios _uslog;
        int idDetalleReq, idRequisicion;
        string Empleado, Producto, Cantidad;

        private void CargarDetalleReq()
        {

            var x = from n in db.DetalleRequisiciones
                    join r in db.Requisiciones on n.IdRequisicion equals r.IdRequisicion
                    join t in db.Trabajadores on r.IdEmpleado equals t.IdEmpleado
                    join p in db.ProductosAlmacen on n.IdProductoAlmacen equals p.IdProducto
                    where n.IdEstatus == 1 && n.IdCotizacionAut == null
                    orderby t.NombreCompleto
                    select new
                    {
                        n.IdDetalleReq,
                        n.IdRequisicion,
                        t.NombreCompleto,
                        p.Nombre,
                        n.Cantidad

                    };

            this.dgrid_req.DataSource = null;
            this.dgrid_req.DataSource = x.ToList();
            this.dgrid_req.Columns[0].Visible = false;
            this.dgrid_req.Columns[4].Visible = false;

            this.dgrid_req.EnableHeadersVisualStyles = false;
            this.dgrid_req.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_req.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_req.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrid_req.AutoGenerateColumns = false;

        }

        private void VCotxAutorizar_Load(object sender, EventArgs e)
        {
            CargarDetalleReq();
            if (this._uslog.IdDepto != 1 && this._uslog.IdDepto != 3)
            {
                this.btn_autorizar.Enabled = false;
                this.btn_rechazar.Enabled = false;
            }
            else
            {
                this.btn_autorizar.Enabled = true;
                this.btn_rechazar.Enabled = true;

            }
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgrid_req[column, row];
            DataGridViewCell cell2 = dgrid_req[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void AutorizarCotizacion()
        {

            var idcotizacion = Convert.ToInt32(this.cmb_cotizacion.SelectedValue);
            var cotizacion = this.db.CotizacionesRequisiciones.Where(x => x.IdCotizacion == idcotizacion).FirstOrDefault();
            cotizacion.IdEstatus = 3;
            cotizacion.IdUsAut = this._uslog.IdUsuario;
            cotizacion.FechaAut = DateTime.Now;
            db.Entry(cotizacion).State = EntityState.Modified;
            db.SaveChanges();

            var detreq = this.db.DetalleRequisiciones.Where(x => x.IdDetalleReq == cotizacion.IdDetalleReq).FirstOrDefault();
            detreq.IdEstatus = 3;
            detreq.IdCotizacionAut = cotizacion.IdCotizacion;
            db.Entry(detreq).State = EntityState.Modified;
            db.SaveChanges();

            var c = db.CotizacionesRequisiciones.Where(z=>z.IdDetalleReq==cotizacion.IdDetalleReq && z.IdEstatus==1).ToList();
            foreach(var cot in c)
            {
                cot.IdEstatus = 4;
                cot.IdUsCan = this._uslog.IdUsuario;
                cot.FechaCan=DateTime.Now;
                db.Entry(cot).State = EntityState.Modified;
                db.SaveChanges();
            }


            List<DetalleRequisiciones>lst_det = new List<DetalleRequisiciones>();
            lst_det = db.DetalleRequisiciones.Where(x => x.IdEstatus == 1 && x.IdRequisicion == detreq.IdRequisicion).ToList();
            if (!lst_det.Any())
            {
                var req = db.Requisiciones.Where(x=>x.IdRequisicion==detreq.IdRequisicion).First();
                req.IdEstatus = 3;
                db.Entry(req).State = EntityState.Modified;
                db.SaveChanges();

            }



            MessageBox.Show("Cotizacion #" + this.cmb_cotizacion.SelectedValue.ToString() + " autorizada exitosamente");
            RefrescarPagina();
        }

        private void RefrescarPagina()
        {
            CargarDetalleReq();
            this.cmb_cotizacion.DataSource = null;
            this.lbl_req.Text = "Requisiciones #";
            this.lbl_fecha.Text = "Fecha: ";
            this.lbl_hora.Text = "Hora: ";
            this.lbl_empleado.Text = "Empleado: ";
            this.lbl_producto.Text = "Producto: ";
            this.lbl_cantidad.Text = "Cantidad: ";
            this.lbl_proveedor.Text = "Proveedor: ";
            this.lbl_cu.Text = "Costo Unitario: ";
            this.lbl_total.Text = "Total: ";
            this.lbl_num_cot.Text = "Total de Cotizaciones:";


        }

        private void RechazarCotizacion()
        {
            var idcotizacion = Convert.ToInt32(this.cmb_cotizacion.SelectedValue);
            var cotizacion = this.db.CotizacionesRequisiciones.Where(x => x.IdCotizacion == idcotizacion).FirstOrDefault();
            cotizacion.IdEstatus = 4;
            cotizacion.IdUsCan = this._uslog.IdUsuario;
            cotizacion.FechaCan = DateTime.Now;
            db.Entry(cotizacion).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Cotizacion #" + this.cmb_cotizacion.SelectedValue.ToString() + " rechazada exitosamente");
            RefrescarPagina();


        }

        private void dgrid_req_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgrid_req.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgrid_req_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void dgrid_req_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgrid_req.CurrentCell.RowIndex != -1)
                {
                    var iddetallereq = Convert.ToInt32(this.dgrid_req.CurrentRow.Cells[0].Value);
                    idDetalleReq = iddetallereq;
                    idRequisicion = Convert.ToInt32(this.dgrid_req.CurrentRow.Cells[1].Value);
                    Empleado = this.dgrid_req.CurrentRow.Cells[2].Value.ToString();
                    Producto = this.dgrid_req.CurrentRow.Cells[3].Value.ToString();
                    Cantidad = this.dgrid_req.CurrentRow.Cells[4].Value.ToString();


                    CargarCotizaciones(iddetallereq);
                }


            }
            catch (Exception ex) { }
        }

        private void btn_autorizar_Click(object sender, EventArgs e)
        {
            if (this.cmb_cotizacion.DataSource == null)
            {
                MessageBox.Show("Este producto no cuenta con cotizaciones");
            }
            else
            {
                DialogResult result = MessageBox.Show("Esta seguro de autorizar la cotizacion #" + this.cmb_cotizacion.SelectedValue.ToString(), "Cancelar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    AutorizarCotizacion();

                }
                else
                {
                    // Do something
                }

            }
        }

        private void btn_rechazar_Click(object sender, EventArgs e)
        {
            if (this.cmb_cotizacion.DataSource == null)
            {
                MessageBox.Show("Este producto no cuenta con cotizaciones");
            }
            else
            {
                DialogResult result = MessageBox.Show("Esta seguro de rechazar la cotizacion #" + this.cmb_cotizacion.SelectedValue.ToString(), "Cancelar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    RechazarCotizacion();

                }
                else
                {
                    // Do something
                }

            }
        }

        private void CargarCotizaciones(int iddetallereq)
        {
            var x = db.CotizacionesRequisiciones.Where(y => y.IdDetalleReq == iddetallereq && y.IdEstatus != 2).ToList();
            if (x.Any())
            {
                this.cmb_cotizacion.DataSource = null;
                this.cmb_cotizacion.DataSource = x;
                this.cmb_cotizacion.DisplayMember = "IdCotizacion";
                this.cmb_cotizacion.ValueMember = "IdCotizacion";
                this.lbl_num_cot.Text = "Total de Cotizaciones: " + x.Count.ToString();

            }
            else
            {
                this.cmb_cotizacion.DataSource = null;
                this.lbl_num_cot.Text = "Total de Cotizaciones: 0";

            }
        }

        private void cmb_cotizacion_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idcotizacion = Convert.ToInt32(this.cmb_cotizacion.SelectedValue);
                CargarCotizacionById(idcotizacion);

            }
            catch (Exception ex) { }
        }

        private void CargarCotizacionById(int idcotizacion)
        {
            var cotizacion = db.CotizacionesRequisiciones.Where(x => x.IdCotizacion == idcotizacion).FirstOrDefault();


            if (cotizacion != null)
            {
                var requisicion = db.Requisiciones.Where(x => x.IdRequisicion == idRequisicion).FirstOrDefault();
                var proveedor = db.Proveedores.Where(x => x.IdProveedor == cotizacion.IdProveedor).Select(x => x.Proveedor).FirstOrDefault();
                this.lbl_req.Text = "Requisiciones #" + requisicion.IdRequisicion.ToString();
                this.lbl_fecha.Text = "Fecha: " + requisicion.Fecha.ToString();
                this.lbl_hora.Text = "Hora: " + requisicion.Hora.ToString();
                this.lbl_empleado.Text = "Empleado: " + Empleado;
                this.lbl_producto.Text = "Producto: " + Producto;
                this.lbl_cantidad.Text = "Cantidad: " + Cantidad;
                this.lbl_proveedor.Text = "Proveedor: " + proveedor;
                this.lbl_cu.Text = "Costo Unitario: " + cotizacion.CostoUnitario.ToString();
                this.lbl_total.Text = "Total: " + cotizacion.Total.ToString();
            }
            else
            {
                this.lbl_req.Text = "Requisiciones #";
                this.lbl_fecha.Text = "Fecha: ";
                this.lbl_hora.Text = "Hora: ";
                this.lbl_empleado.Text = "Empleado: ";
                this.lbl_producto.Text = "Producto: ";
                this.lbl_cantidad.Text = "Cantidad: ";
                this.lbl_proveedor.Text = "Proveedor: ";
                this.lbl_cu.Text = "Costo Unitario: ";
                this.lbl_total.Text = "Total: ";
                this.lbl_num_cot.Text = "Total de Cotizaciones:";

            }
        }
    }
}
