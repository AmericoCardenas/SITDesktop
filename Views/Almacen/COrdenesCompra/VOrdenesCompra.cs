using SIT.CrystalReport;
using SIT.Views.Contabilidad.CMovimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SIT.Views.Almacen.COrdenesCompra
{
    public partial class VOrdenesCompra : Form
    {
        public VOrdenesCompra(Usuarios usuarios)
        {
            InitializeComponent();
            this._uslog=usuarios;

            ToolTip buttonToolTip = new ToolTip();
            buttonToolTip.ToolTipTitle = "";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 500;

            buttonToolTip.SetToolTip(this.btn_cotizacionglobal, "Generar cotización global");
            buttonToolTip.SetToolTip(this.btn_oc, "Generar Orden de Compra");
            buttonToolTip.SetToolTip(this.btn_pagaroc, "Pagar Orden de Compra");
            buttonToolTip.SetToolTip(this.btn_pdf, "Ver Orden de Compra");
            buttonToolTip.SetToolTip(this.btn_entrada, "Generar entrada almacen");
            buttonToolTip.SetToolTip(this.btn_factxml, "Cargar Factura/XML");
            buttonToolTip.SetToolTip(this.btn_autcot, "Autorizar Cotización");
            buttonToolTip.SetToolTip(this.btn_canoc, "Cancelar Orden de Compra");

        }

        Usuarios _uslog;
        int idOCompra,idCotizacion=0;
        Double total=0;
        SITEntities db = new SITEntities();
        OrdenesCompra ordenes = new OrdenesCompra();
        CotizacionesRequisiciones cot = new CotizacionesRequisiciones();
        List<CotizacionesRequisiciones> lst_cotizaciones = new List<CotizacionesRequisiciones>();
        List<CotPendientes> lst_cotpend = new List<CotPendientes>();



        public void CargarReqPendientes()
        {
            var x = from n in db.CotizacionesRequisiciones
                    join d in db.DetalleRequisiciones on n.IdDetalleReq equals d.IdDetalleReq
                    join r in db.Requisiciones on d.IdRequisicion equals r.IdRequisicion
                    join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                    join pr in db.ProductosAlmacen on d.IdProductoAlmacen equals pr.IdProducto
                    where n.IdEstatus == 1 && n.IdOCompra == null
                    orderby n.IdProveedor ascending
                    select new
                    {
                        n.IdCotizacion,
                        n.IdProveedor,
                        p.Proveedor,
                        pr.Nombre,
                        d.Cantidad,
                        n.CostoUnitario,
                        n.Total
                    };

            this.dgrid_reqpendientes.DataSource = null;
            if(this.dgrid_reqpendientes.Columns.Count> 0)
            {
                this.dgrid_reqpendientes.Columns.Clear();

            }
            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.FalseValue = false;
            dgvCmb.TrueValue = true;
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "CheckBox";
            this.dgrid_reqpendientes.Columns.Add(dgvCmb);

            this.dgrid_reqpendientes.DataSource = x.ToList();
            this.dgrid_reqpendientes.Columns[2].Visible = false;
            this.dgrid_reqpendientes.Columns["Chk"].DisplayIndex = this.dgrid_reqpendientes.Columns.Count - 1;
            this.dgrid_reqpendientes.EnableHeadersVisualStyles = false;
            this.dgrid_reqpendientes.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_reqpendientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_reqpendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void CargarReqAutorizadas()
        {
            var x = from n in db.CotizacionesRequisiciones
                    join d in db.DetalleRequisiciones on n.IdDetalleReq equals d.IdDetalleReq
                    join r in db.Requisiciones on d.IdRequisicion equals r.IdRequisicion
                    join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                    join pr in db.ProductosAlmacen on d.IdProductoAlmacen equals pr.IdProducto
                    where n.IdEstatus == 3 && n.IdOCompra==null
                    orderby n.IdProveedor ascending
                    select new
                    {
                        n.IdCotizacion,
                        n.IdProveedor,
                        n.FechaAut,
                        p.Proveedor,
                        pr.Nombre,
                        d.Cantidad,
                        n.CostoUnitario,
                        n.Total
                    };

            this.dgrid_reqautorizadas.DataSource = null;
            if (this.dgrid_reqautorizadas.Columns.Count > 0)
            {
                this.dgrid_reqautorizadas.Columns.Clear();
            }

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.FalseValue = false;
            dgvCmb.TrueValue = true;
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "CheckBox";
            this.dgrid_reqautorizadas.Columns.Add(dgvCmb);
            this.dgrid_reqautorizadas.DataSource=x.ToList();
            this.dgrid_reqautorizadas.Columns[2].Visible = false;
            this.dgrid_reqautorizadas.Columns["Chk"].DisplayIndex = this.dgrid_reqautorizadas.Columns.Count-1;
            this.dgrid_reqautorizadas.EnableHeadersVisualStyles = false;
            this.dgrid_reqautorizadas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_reqautorizadas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_reqautorizadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.lbl_total.Text="$ 0.00";

        }

        public void CargarOrdenesCompraPend()
        {
            idOCompra = 0;
            var x = from n in db.OrdenesCompra
                    join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                    join e in db.EstatusOrdenCompra on n.IdEstatus equals e.IdEstatus
                    where n.IdEstatus ==1
                    orderby n.IdProveedor ascending
                    select new
                    {
                        n.IdOCompra,
                        n.Fecha,
                        p.RazonSocial,
                        n.Subtotal,
                        n.Iva,
                        n.Total,
                        e.Estatus,
                        n.IdProveedor

                    };

            this.dgrid_oc.DataSource = x.ToList();
            this.dgrid_oc.Columns[7].Visible = false;
            this.dgrid_oc.EnableHeadersVisualStyles = false;
            this.dgrid_oc.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_oc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_oc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void CargarOrdenesCompraPagadas()
        {
            idOCompra = 0;
            var x = from n in db.OrdenesCompra
                    join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                    join e in db.EstatusOrdenCompra on n.IdEstatus equals e.IdEstatus
                    where n.IdEstatus == 3
                    orderby n.IdProveedor ascending
                    select new
                    {
                        n.IdOCompra,
                        n.Fecha,
                        p.RazonSocial,
                        n.Subtotal,
                        n.Iva,
                        n.Total,
                        e.Estatus,
                        n.IdProveedor

                    };

            this.dgrid_ocpagadas.DataSource = x.ToList();
            this.dgrid_ocpagadas.Columns[7].Visible = false;
            this.dgrid_ocpagadas.EnableHeadersVisualStyles = false;
            this.dgrid_ocpagadas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_ocpagadas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_ocpagadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void CargarOrdenesCompraSurtidas()
        {
            idOCompra = 0;
            var x = from n in db.OrdenesCompra
                    join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                    join e in db.EstatusOrdenCompra on n.IdEstatus equals e.IdEstatus
                    where n.IdEstatus == 4
                    orderby n.IdProveedor ascending
                    select new
                    {
                        n.IdOCompra,
                        n.Fecha,
                        p.RazonSocial,
                        n.Subtotal,
                        n.Iva,
                        n.Total,
                        e.Estatus,
                        n.IdProveedor

                    };

            this.dgrid_ocsurtidas.DataSource = x.ToList();
            this.dgrid_ocsurtidas.Columns[7].Visible = false;
            this.dgrid_ocsurtidas.EnableHeadersVisualStyles = false;
            this.dgrid_ocsurtidas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_ocsurtidas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_ocsurtidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }



        private void VOrdenesCompra_Load(object sender, EventArgs e)
        {
            
            if (tbcontrol.SelectedIndex == 0)
            {
                this.btn_pdf.Visible = false;
                this.btn_pagaroc.Visible = false;
                this.btn_entrada.Visible = false;
                this.btn_oc.Visible = false;
                this.btn_factxml.Visible = false;
                CargarReqPendientes();
            }
            else if(tbcontrol.SelectedIndex == 1)
            {
                this.btn_pdf.Visible = false;
                this.btn_pagaroc.Visible = false;
                this.btn_entrada.Visible = false;
                this.btn_cotizacionglobal.Visible = false;
                this.btn_factxml.Visible = false;


                CargarReqAutorizadas();
            }
            else if (tbcontrol.SelectedIndex == 2)
            {
                this.btn_cotizacionglobal.Visible = false;
                this.btn_factxml.Visible = true;

            }

            if (this._uslog.IdDepto == 4)
            {
                this.btn_cotizacionglobal.Enabled = false;
                this.btn_entrada.Enabled = false;
                this.btn_oc.Enabled = false;
                this.btn_pagaroc.Enabled = true;
                this.btn_pdf.Enabled = true;
            }

            

            CargarFiltros();



        }

        private void GenerarOC()
        {
            ordenes.Fecha=DateTime.Now;
            ordenes.IdProveedor = this.lst_cotizaciones.Select(x=>x.IdProveedor).FirstOrDefault();
            ordenes.IdEstatus = 1;
            ordenes.FCreo=DateTime.Now;
            ordenes.IdUsCreo = this._uslog.IdUsuario;
            ordenes.Subtotal = this.lst_cotizaciones.Sum(x => x.Total);
            ordenes.Iva = (this.lst_cotizaciones.Sum(x => x.Total) * 0.16);
            ordenes.Total = (this.lst_cotizaciones.Sum(x => x.Total) * 1.16);
            var importe =enletras((this.lst_cotizaciones.Sum(x => x.Total) * 1.16).ToString());
            ordenes.ImporteLetra = importe.ToString();
            db.OrdenesCompra.Add(ordenes);
            db.SaveChanges();

            foreach (var c in this.lst_cotizaciones)
            {
                cot = db.CotizacionesRequisiciones.Where(x=>x.IdCotizacion==c.IdCotizacion).FirstOrDefault();
                cot.IdOCompra = ordenes.IdOCompra;
                db.Entry(cot).State = EntityState.Modified;
                db.SaveChanges();
            }

            MessageBox.Show("Se ha generado la orden de compra: " + ordenes.IdOCompra.ToString());
            this.tbcontrol.SelectedIndex = 1;
        }

        private void dgrid_reqautorizadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex != -1) // Check if the checkbox column is clicked
                {
                    DataGridViewCheckBoxCell checkBoxCell = this.dgrid_reqautorizadas.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {

                        if (checkBoxCell.Value == null)
                        {
                            checkBoxCell.Value = false;
                        }

                        bool isChecked = (bool)checkBoxCell.Value;
                        var tot = Convert.ToDouble(this.dgrid_reqautorizadas.Rows[e.RowIndex].Cells[8].Value);

                        if (isChecked==true) {

                            total = total - tot;
                            this.lbl_total.Text = "$ "+total.ToString();

                        }
                        else if(isChecked==false)
                        {
                            total = total + tot;
                            this.lbl_total.Text = "$ "+total.ToString();

                        }
                        checkBoxCell.Value = !isChecked;



                        this.dgrid_reqautorizadas.CurrentRow.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void PerformActionOnSelectedRows()
        {
            foreach (DataGridViewRow row in this.dgrid_reqautorizadas.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Chk"] as DataGridViewCheckBoxCell;
                if (checkBoxCell.Value == null)
                {
                    checkBoxCell.Value = false;
                }
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {

                    var idproveedor = Convert.ToInt32(row.Cells[2].Value);

                    if (this.lst_cotizaciones.Any())
                    {
                        var r = this.lst_cotizaciones.Where(x => x.IdProveedor == idproveedor).ToList();
                        if(r.Any())
                        {
                            this.lst_cotizaciones.Add(new CotizacionesRequisiciones
                            {
                                IdCotizacion = Convert.ToInt32(row.Cells[1].Value.ToString()),
                                IdProveedor = Convert.ToInt32(row.Cells[2].Value),
                                CostoUnitario = Convert.ToDouble(row.Cells[7].Value),
                                Total = Convert.ToDouble(row.Cells[8].Value),

                            }) ;

                        }
                        else
                        {
                            MessageBox.Show("No se puede crear la OC ya que las requisiciones autorizadas deben ser de un solo proveedor");
                            this.lst_cotizaciones.Clear();
                            this.dgrid_reqautorizadas.Columns.Clear();
                            total = 0;
                            CargarReqAutorizadas();
                            break;
                        }
                    }
                    else
                    {

                        this.lst_cotizaciones.Add(new CotizacionesRequisiciones
                        {
                            IdCotizacion = Convert.ToInt32(row.Cells[1].Value.ToString()),
                            IdProveedor = Convert.ToInt32(row.Cells[2].Value),
                            CostoUnitario = Convert.ToDouble(row.Cells[7].Value),
                            Total = Convert.ToDouble(row.Cells[8].Value),

                        });
                    }



                }
            }

            if (this.lst_cotizaciones.Any())
            {
                GenerarOC();

            }

        }

        private void GenerarCotizacionGlobalReqPendientes()
        {
            foreach (DataGridViewRow row in this.dgrid_reqpendientes.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Chk"] as DataGridViewCheckBoxCell;
                if (checkBoxCell.Value == null)
                {
                    checkBoxCell.Value = false;
                }
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {

                    var idproveedor = Convert.ToInt32(row.Cells[2].Value);

                    if (this.lst_cotpend.Any())
                    {
                        var r = this.lst_cotpend.Where(x => x.IdProveedor == idproveedor).ToList();
                        if (r.Any())
                        {
                            this.lst_cotpend.Add(new CotPendientes
                            {
                                idCotizacion = Convert.ToInt32(row.Cells[1].Value.ToString()),
                                IdProveedor = Convert.ToInt32(row.Cells[2].Value),
                                Proveedor = row.Cells[3].Value.ToString(),
                                Producto = row.Cells[4].Value.ToString(),
                                Cantidad = Convert.ToDouble(row.Cells[5].Value),
                                CUnitario = Convert.ToDouble(row.Cells[6].Value),
                                Subtotal = Convert.ToDouble(row.Cells[7].Value),

                            });

                        }
                        else
                        {
                            MessageBox.Show("No se puede crear la cotizacion ya que las cotizaciones deben ser de un solo proveedor");
                            this.lst_cotpend.Clear();
                            this.dgrid_reqpendientes.Columns.Clear();
                            total = 0;
                            CargarReqPendientes();
                            break;
                        }
                    }
                    else
                    {

                        this.lst_cotpend.Add(new CotPendientes
                        {
                            idCotizacion = Convert.ToInt32(row.Cells[1].Value.ToString()),
                            IdProveedor = Convert.ToInt32(row.Cells[2].Value),
                            Proveedor = row.Cells[3].Value.ToString(),
                            Producto = row.Cells[4].Value.ToString(),
                            Cantidad = Convert.ToDouble(row.Cells[5].Value),
                            CUnitario = Convert.ToDouble(row.Cells[6].Value),
                            Subtotal = Convert.ToDouble(row.Cells[7].Value),

                        });
                    }



                }
            }

            if (this.lst_cotpend.Any())
            {

                VCotizacionGlobal frm = new VCotizacionGlobal(this);
                frm.uslog = this._uslog;
                frm.lst_cot = this.lst_cotpend;
                frm.ShowDialog();
            }

        }


        private void btn_oc_Click(object sender, EventArgs e)
        {
            if (this.dgrid_reqautorizadas.Rows.Count==0)
            {
                MessageBox.Show("Favor de seleccionar las requisiciones para poder generar la orden de compra");
            }
            else
            {
                DialogResult result = MessageBox.Show("Desea generar Orden de Compra", "Cancelar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PerformActionOnSelectedRows();

                }
                else
                {
                    // Do something
                }
            }

        }

        private void CargarFiltros()
        {
            this.cmb_filtro.DataSource = null;
            this.cmb_filtro.Items.Clear();

            if (tbcontrol.SelectedIndex == 0)
            {
                foreach(DataGridViewColumn c in this.dgrid_reqpendientes.Columns)
                {
                    if (c.Index > 0 && c.Visible == true)
                    {
                        this.cmb_filtro.Items.Add(c.Name);
                    }
                }
                this.cmb_filtro.SelectedIndex = 0;
            }
            else if (tbcontrol.SelectedIndex == 1)
            {
                foreach (DataGridViewColumn c in this.dgrid_reqautorizadas.Columns)
                {
                    if(c.Index > 0 && c.Visible==true)
                    {
                        this.cmb_filtro.Items.Add(c.Name);
                    }
                }
                this.cmb_filtro.SelectedIndex = 0;

            }
            else if (tbcontrol.SelectedIndex == 2)
            {
                foreach (DataGridViewColumn c in this.dgrid_oc.Columns)
                {
                    if (c.Visible == true)
                    {
                        this.cmb_filtro.Items.Add(c.Name);

                    }
                }
                this.cmb_filtro.SelectedIndex = 0;

            }
        }
        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            idOCompra = 0;
            if (tbcontrol.SelectedIndex == 0)
            {
                CargarReqPendientes();
                this.btn_pdf.Visible = false;
                this.btn_oc.Visible = false;
                this.lbl_total.Visible = false;
                this.label1.Visible = false;
                this.btn_pagaroc.Visible = false;
                this.btn_entrada.Visible = false;
                this.btn_cotizacionglobal.Visible = true;
                this.btn_factxml.Visible = false;
                this.btn_canoc.Visible = false;
                this.btn_autcot.Visible = true;


            }
            else if (tbcontrol.SelectedIndex == 1)
            {
                CargarReqAutorizadas();
                this.btn_pdf.Visible = false;
                this.btn_oc.Visible = true;
                this.lbl_total.Visible = true;
                this.label1.Visible = true;
                this.btn_pagaroc.Visible = false;
                this.btn_entrada.Visible = false;
                this.btn_cotizacionglobal.Visible = false;
                this.btn_factxml.Visible = false;
                this.btn_canoc.Visible = false;
                this.btn_autcot.Visible = false;


            }
            else if (tbcontrol.SelectedIndex == 2)
            {
                CargarOrdenesCompraPend();
                this.btn_pdf.Visible = true;
                this.btn_oc.Visible = false;
                this.lbl_total.Visible = false;
                this.label1.Visible = false;
                this.btn_entrada.Visible = false;
                this.btn_cotizacionglobal.Visible = false;
                this.btn_factxml.Visible = false;
                this.btn_canoc.Visible = true;
                this.btn_autcot.Visible = false;





                if (this._uslog.IdDepto == 1 || this._uslog.IdDepto == 3 || this._uslog.IdDepto == 4)
                {
                    this.btn_pagaroc.Visible = true;

                }
            }
            else if (tbcontrol.SelectedIndex == 3)
            {
                CargarOrdenesCompraPagadas();
                this.lbl_total.Visible = false;
                this.label1.Visible = false;
                this.btn_pdf.Visible = true;
                this.btn_oc.Visible = false;
                this.btn_entrada.Visible = true;
                this.btn_cotizacionglobal.Visible = false;
                this.btn_factxml.Visible = false;
                this.btn_pagaroc.Visible = false;
                this.btn_canoc.Visible = false;
                this.btn_autcot.Visible = false;


            }
            else if (tbcontrol.SelectedIndex == 4)
            {
                CargarOrdenesCompraSurtidas();
                this.btn_entrada.Visible = false;
                this.btn_factxml.Visible = true;
                this.btn_pagaroc.Visible=false;
                this.btn_oc.Visible = false;
                this.btn_cotizacionglobal.Visible = false;
                this.btn_pdf.Visible=true;
                this.btn_canoc.Visible = true;
                this.btn_autcot.Visible = false;

            }

            CargarFiltros();
        }

        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }

        private void VerOrdenCompra()
        {
            if (idOCompra !=0)
            {
                Reporte frm = new Reporte();
                frm.idocompra=idOCompra;
                frm.frm = this;
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Favor de seleccionar la orden de compra a visualizar");
            }
        }

        private void CancelarOC()
        {
            //idOCompra = Convert.ToInt32(this.dgrid_ocsurtidas.CurrentRow.Cells["IdOCompra"].Value);
            if (idOCompra != 0 && idOCompra != null)
            {
                var oc = db.OrdenesCompra.Where(x=>x.IdOCompra== idOCompra).First();
                if (oc != null)
                {
                    if (oc.IdEstatus == 4)
                    {
                        oc.IdEstatus = 2;
                        oc.FCan = DateTime.Now;
                        oc.IdUsCan = this._uslog.IdUsuario;
                        db.Entry(oc).State = EntityState.Modified;
                        db.SaveChanges();

                        var lstcot = db.CotizacionesRequisiciones.Where(x => x.IdOCompra == idOCompra).ToList();
                        lstcot.ForEach(x => x.IdEstatus = 3);
                        lstcot.ForEach(x => x.IdOCompra = 0);
                        lstcot.ForEach(x => x.FechaMod = DateTime.Now);
                        lstcot.ForEach(x => x.IdUsMod = this._uslog.IdUsuario);


                        foreach (var cot in lstcot)
                        {
                            var cotizacion = db.CotizacionesRequisiciones.Where(x => x.IdCotizacion == cot.IdCotizacion).First();
                            if (cotizacion != null)
                            {
                                db.Entry(cotizacion).State = EntityState.Modified;
                                db.SaveChanges();

                            }

                            var detreq = db.DetalleRequisiciones.Where(x => x.IdCotizacionAut == cot.IdCotizacion).First();
                            if (detreq != null)
                            {
                                detreq.IdEstatus = 1;
                                //detreq.IdCotizacionAut = null;
                                db.Entry(detreq).State = EntityState.Modified;
                                db.SaveChanges();

                            }

                            var prodalm = db.ProductosAlmacen.Where(x => x.IdProducto == detreq.IdProductoAlmacen).First();
                            if (prodalm != null)
                            {
                                var stock = (prodalm.Stock - detreq.Cantidad);
                                prodalm.Stock = stock;
                                prodalm.FechaMod = DateTime.Now;
                                prodalm.IdUsMod = 0;
                                db.Entry(prodalm).State = EntityState.Modified;
                                db.SaveChanges();

                            }

                            var req = db.Requisiciones.Where(x => x.IdRequisicion == detreq.IdRequisicion).First();
                            if (req != null)
                            {
                                req.IdEstatus = 1;
                                req.FechaMod = DateTime.Now;
                                req.IdUsMod = 0;
                                db.Entry(req).State = EntityState.Modified;
                                db.SaveChanges();

                            }

                            var mov = db.Movimientos.Where(x=>x.Descripcion.Equals("OC#"+idOCompra.ToString())).First();
                            if(mov != null)
                            {
                                mov.IdEstatus = 2;
                                mov.FechaCancelacion = DateTime.Now;
                                mov.IdUsuarioCancelacion = 0;
                                db.Entry(mov).State = EntityState.Modified;
                                db.SaveChanges();

                            }

                            var not = db.NotasMovimientos.Where(x => x.Folio.Equals("OC#" + idOCompra.ToString())).First();
                            if (not != null)
                            {
                                not.IdEstatus = 2;
                                not.FechaCancelacion = DateTime.Now;
                                not.UsuarioCancelacion = 0;
                                db.Entry(not).State = EntityState.Modified;
                                db.SaveChanges();

                            }

                        }
                        CargarOrdenesCompraSurtidas();

                    }
                    else if(oc.IdEstatus==1)
                    {

                        oc.IdEstatus = 2;
                        oc.FCan = DateTime.Now;
                        oc.IdUsCan = this._uslog.IdUsuario;
                        db.Entry(oc).State = EntityState.Modified;
                        db.SaveChanges();

                        var lstcot = db.CotizacionesRequisiciones.Where(x => x.IdOCompra == idOCompra).ToList();
                        lstcot.ForEach(x => x.IdEstatus = 3);
                        lstcot.ForEach(x => x.IdOCompra = null);
                        lstcot.ForEach(x => x.FechaMod = DateTime.Now);
                        lstcot.ForEach(x => x.IdUsMod = this._uslog.IdUsuario);

                        foreach (var cot in lstcot)
                        {
                            var cotizacion = db.CotizacionesRequisiciones.Where(x => x.IdCotizacion == cot.IdCotizacion).First();
                            if (cotizacion != null)
                            {
                                db.Entry(cotizacion).State = EntityState.Modified;
                                db.SaveChanges();

                            }

                            var detreq = db.DetalleRequisiciones.Where(x => x.IdCotizacionAut == cot.IdCotizacion).First();
                            if (detreq != null)
                            {
                                detreq.IdEstatus = 1;
                                //detreq.IdCotizacionAut = null;
                                db.Entry(detreq).State = EntityState.Modified;
                                db.SaveChanges();

                            }

                            var req = db.Requisiciones.Where(x => x.IdRequisicion == detreq.IdRequisicion).First();
                            if (req != null)
                            {
                                req.IdEstatus = 1;
                                req.FechaMod = DateTime.Now;
                                req.IdUsMod = 0;
                                db.Entry(req).State = EntityState.Modified;
                                db.SaveChanges();

                            }
                        }

                        CargarOrdenesCompraPend();
                     }

                    MessageBox.Show("La OC#" + idOCompra + " ha sido cancelada");
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar la OC a cancelar");
            }
        }

        private void dgrid_oc_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgrid_oc.CurrentCell.RowIndex != -1)
                {
                    idOCompra = Convert.ToInt32(this.dgrid_oc.CurrentRow.Cells["IdOCompra"].Value);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            VerOrdenCompra();
        }

        private void GenerarEntradaAlmacen()
        {
            if (idOCompra != 0 && this.dgrid_ocpagadas.CurrentRow.Cells["Estatus"].Value.ToString()=="PAGADA")
            {
                var oc = db.OrdenesCompra.Where(x => x.IdOCompra == idOCompra).FirstOrDefault();
                if (oc != null)
                {
                    oc.IdEstatus = 4;
                    oc.IdUsMod = this._uslog.IdUsuario;
                    oc.FMod = DateTime.Now;
                    db.Entry(oc).State = EntityState.Modified;
                    db.SaveChanges();

                    var x = from n in db.CotizacionesRequisiciones
                            join d in db.DetalleRequisiciones on n.IdDetalleReq equals d.IdDetalleReq
                            where n.IdEstatus ==3 && n.IdOCompra==idOCompra
                            select new
                            {
                                d.IdProductoAlmacen,
                                d.Cantidad

                            };

                    foreach(var z in x.ToList())
                    {
                        Double stock = 0;
                        var p = db.ProductosAlmacen.Where(y => y.IdProducto == z.IdProductoAlmacen).FirstOrDefault();
                        stock = Convert.ToDouble(p.Stock);
                        var cantidad = z.Cantidad;
                        Double st = Convert.ToDouble(stock) + Convert.ToDouble(cantidad);
                        p.Stock = st;
                        p.FechaMod = DateTime.Now;
                        p.IdUsMod = this._uslog.IdUsuario;
                        db.Entry(p).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    MessageBox.Show("Se ha generado la entrada al almacen exitosamente");
                    CargarOrdenesCompraPend();
                }
            }
            else
            {
                if(idOCompra == 0)
                {
                    MessageBox.Show("Favor de seleccionar orden de compra");
                }
                else if(this.dgrid_ocpagadas.CurrentRow.Cells["Estatus"].Value.ToString() != "PAGADA")
                {
                    MessageBox.Show("No se puede generar la entrada al almacen\n ya que la OC no se encuentra pagada o ya esta surtida");
                }
            }
        }

        public void SaldarOCompra()
        {
            if (idOCompra != 0 && this.dgrid_oc.CurrentRow.Cells["Estatus"].Value.ToString() == "PENDIENTE")
            {
                var oc = db.OrdenesCompra.Where(x => x.IdOCompra == idOCompra).FirstOrDefault();
                if (oc != null)
                {
                    oc.IdEstatus = 3;
                    oc.IdUsMod = this._uslog.IdUsuario;
                    oc.FMod = DateTime.Now;
                    db.Entry(oc).State = EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Orden de Compra # "+idOCompra+"\n saldada exitosamente");
                    CargarOrdenesCompraPend();
                }
            }
            else
            {
                MessageBox.Show("Favor de seleccionar la orden de compra a saldar");
            }
         
        }



        private void btn_pagaroc_Click(object sender, EventArgs e)
        {
            if (this.dgrid_oc.CurrentRow.Cells["Estatus"].Value.ToString() != "PENDIENTE")
            {
                MessageBox.Show("La OC ya se encuentra pagada o surtida");
            }
            else
            {
                VNotaMov frm = new VNotaMov(this);
                this.Enabled = false;
                frm.title = "¿Desea saldar la Orden de Compra?\n# "+idOCompra.ToString();
                frm.uslog = this._uslog;
                frm.idoc = this.dgrid_oc.CurrentRow.Cells[0].Value.ToString();
                frm.idprov = this.dgrid_oc.CurrentRow.Cells[7].Value.ToString();
                frm.prov = this.dgrid_oc.CurrentRow.Cells[2].Value.ToString();
                frm.total = this.dgrid_oc.CurrentRow.Cells[5].Value.ToString();
                frm.Show();
            }
        }

        private void btn_entrada_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea generar la entrada al almacen? \n Esto afectara las existencias de los productos  ", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                GenerarEntradaAlmacen();

            }
            else
            {
                // Do something
            }
        }

        private void btn_cotizacionglobal_Click(object sender, EventArgs e)
        {
            GenerarCotizacionGlobalReqPendientes();
        }

        private void dgrid_reqpendientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex != -1) // Check if the checkbox column is clicked
                {
                    DataGridViewCheckBoxCell checkBoxCell = this.dgrid_reqpendientes.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {

                        if (checkBoxCell.Value == null)
                        {
                            checkBoxCell.Value = false;
                        }

                        bool isChecked = (bool)checkBoxCell.Value;

                       
                        checkBoxCell.Value = !isChecked;



                        this.dgrid_reqpendientes.CurrentRow.Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void btn_factxml_Click(object sender, EventArgs e)
        {
            if(idOCompra==0)
            { 
                MessageBox.Show("Favor de seleccionar la orden de compra");
            }
            else
            {
                VFacturaOC frm = new VFacturaOC(this);
                frm.idOCompra = idOCompra;
                frm.Show();

            }
        }

        private void dgrid_ocpagadas_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgrid_ocpagadas.CurrentCell.RowIndex != -1)
                {
                    idOCompra = Convert.ToInt32(this.dgrid_ocpagadas.CurrentRow.Cells["IdOCompra"].Value);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dgrid_ocsurtidas_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgrid_ocsurtidas.CurrentCell.RowIndex != -1)
                {
                    idOCompra = Convert.ToInt32(this.dgrid_ocsurtidas.CurrentRow.Cells["IdOCompra"].Value);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btn_canoc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar la OC# "+idOCompra+" ? \n Esto afectara el stock en almacen", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarOC();

            }
            else
            {
                // Do something
            }
        }



        private void btn_autcot_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro de autorizar la cotizacion #" + idCotizacion, "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                AutorizarCotizacion();

            }
            else
            {
                // Do something
            }
        }

        private void AutorizarCotizacion()
        {

            var idcotizacion = idCotizacion;
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

            //SE CANCELAN LAS COTIZACIONES QUE QUEDAN PENDIENTES
            var c = db.CotizacionesRequisiciones.Where(z => z.IdDetalleReq == cotizacion.IdDetalleReq && z.IdEstatus == 1).ToList();
            foreach (var cot in c)
            {
                cot.IdEstatus = 4;
                cot.IdUsCan = this._uslog.IdUsuario;
                cot.FechaCan = DateTime.Now;
                db.Entry(cot).State = EntityState.Modified;
                db.SaveChanges();
            }


            List<DetalleRequisiciones> lst_det = new List<DetalleRequisiciones>();
            lst_det = db.DetalleRequisiciones.Where(x => x.IdEstatus == 1 && x.IdRequisicion == detreq.IdRequisicion).ToList();
            if (!lst_det.Any())
            {
                var req = db.Requisiciones.Where(x => x.IdRequisicion == detreq.IdRequisicion).First();
                req.IdEstatus = 3;
                db.Entry(req).State = EntityState.Modified;
                db.SaveChanges();

            }



            MessageBox.Show("Cotizacion #" +idCotizacion + " autorizada exitosamente");
            CargarReqPendientes();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_filtro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_rpendientes_Click(object sender, EventArgs e)
        {

        }

        private void tb_reqaut_Click(object sender, EventArgs e)
        {

        }

        private void tb_ocpe_Click(object sender, EventArgs e)
        {

        }

        private void dgrid_oc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tb_ocpag_Click(object sender, EventArgs e)
        {

        }

        private void dgrid_ocpagadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tb_ocsurt_Click(object sender, EventArgs e)
        {

        }

        private void dgrid_ocsurtidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_total_Click(object sender, EventArgs e)
        {

        }

        private void dgrid_reqpendientes_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgrid_reqpendientes.CurrentCell.RowIndex != -1)
                {
                    idCotizacion = Convert.ToInt32(this.dgrid_reqpendientes.CurrentRow.Cells["IdCotizacion"].Value);
                }

            }
            catch (Exception ex)
            {

            }
        }
    }

    public class CotPendientes
    {
        public int idCotizacion { get; set; }
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public string Producto { get; set; }
        public Double Cantidad { get; set; }
        public Double CUnitario { get; set; }
        public Double Subtotal { get; set; }
    }
}
