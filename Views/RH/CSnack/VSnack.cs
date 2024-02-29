using GMap.NET;
using SIT.Views.Catalogos.CBancos;
using SIT.Views.Catalogos.CProductosSnack;
using SIT.Views.RH.CSnack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.RH
{
    public partial class VSnack : Form
    {
        public VSnack(Usuarios usuarios)
        {
            InitializeComponent();
            this._uslog= usuarios;  
        }

        int idSnack=0;
        Usuarios _uslog;
        Snack snack = new Snack();
        SITEntities db = new SITEntities();

        private void VSnack_Load(object sender, EventArgs e)
        {
            CargarSnack();
            CargarFiltros();
            
        }

        public void CargarSnack()
        {
            this.dgrid_snack.DataSource = null;
            this.dgrid_snack.Rows.Clear();
            this.dgrid_snack.Columns.Clear();
            this.dgrid_snack.Refresh();

            var x = from s in db.Snack
                    join t in db.Trabajadores on s.IdEmpleado equals t.IdEmpleado
                    join p in db.ProductosSnack on s.IdProducto equals p.IdProducto
                    join m in db.TipoPagoSnack on s.IdMetodoPago equals m.IdTipoPago
                    where s.IdEstatus != 4
                    orderby s.Fecha descending
                    select new
                    {
                        s.IdSnack,
                        s.Fecha,
                        s.Hora,
                        t.NombreCompleto,
                        p.Producto,
                        s.Cantidad,
                        s.Total,
                        m.Pago
                    };
            this.dgrid_snack.DataSource = x.ToList();
            this.dgrid_snack.Columns[0].Visible = false;
            this.dgrid_snack.EnableHeadersVisualStyles = false;
            this.dgrid_snack.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgrid_snack.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgrid_snack.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_snack.Columns)
            {
                if (col.Index > 0 && col.Name!="Cantidad" && col.Name!="Total")
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        private void CargarxFiltro()
        {

            if (txt_filtro.Text != "")
            {

                var filtro = this.cmb_filtro.Text;
                if (filtro == "Fecha")
                {
                    try
                    {
                        var filter = Convert.ToDateTime(this.txt_filtro.Text);

                        var x = from s in db.Snack
                                join t in db.Trabajadores on s.IdEmpleado equals t.IdEmpleado
                                join p in db.ProductosSnack on s.IdProducto equals p.IdProducto
                                join m in db.TipoPagoSnack on s.IdMetodoPago equals m.IdTipoPago
                                where s.IdEstatus != 4 && s.Fecha == filter
                                orderby s.Fecha descending
                                select new
                                {
                                    s.IdSnack,
                                    s.Fecha,
                                    s.Hora,
                                    t.NombreCompleto,
                                    p.Producto,
                                    s.Cantidad,
                                    s.Total,
                                    m.Pago
                                };
                        this.dgrid_snack.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "NombreCompleto")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;

                        var x = from s in db.Snack
                                join t in db.Trabajadores on s.IdEmpleado equals t.IdEmpleado
                                join p in db.ProductosSnack on s.IdProducto equals p.IdProducto
                                join m in db.TipoPagoSnack on s.IdMetodoPago equals m.IdTipoPago
                                where s.IdEstatus != 4 && t.NombreCompleto.Contains(filter)
                                orderby s.Fecha descending
                                select new
                                {
                                    s.IdSnack,
                                    s.Fecha,
                                    s.Hora,
                                    t.NombreCompleto,
                                    p.Producto,
                                    s.Cantidad,
                                    s.Total,
                                    m.Pago
                                };
                        this.dgrid_snack.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "Producto")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from s in db.Snack
                                join t in db.Trabajadores on s.IdEmpleado equals t.IdEmpleado
                                join p in db.ProductosSnack on s.IdProducto equals p.IdProducto
                                join m in db.TipoPagoSnack on s.IdMetodoPago equals m.IdTipoPago
                                where s.IdEstatus != 4 && p.Producto.Contains(filter)
                                orderby s.Fecha descending
                                select new
                                {
                                    s.IdSnack,
                                    s.Fecha,
                                    s.Hora,
                                    t.NombreCompleto,
                                    p.Producto,
                                    s.Cantidad,
                                    s.Total,
                                    m.Pago
                                };
                        this.dgrid_snack.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "Pago")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from s in db.Snack
                                join t in db.Trabajadores on s.IdEmpleado equals t.IdEmpleado
                                join p in db.ProductosSnack on s.IdProducto equals p.IdProducto
                                join m in db.TipoPagoSnack on s.IdMetodoPago equals m.IdTipoPago
                                where s.IdEstatus != 4 && m.Pago.Contains(filter)
                                orderby s.Fecha descending
                                select new
                                {
                                    s.IdSnack,
                                    s.Fecha,
                                    s.Hora,
                                    t.NombreCompleto,
                                    p.Producto,
                                    s.Cantidad,
                                    s.Total,
                                    m.Pago
                                };
                        this.dgrid_snack.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else
                {
                    CargarSnack();
                    this.dgrid_snack.Refresh();
                }
            }

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            ReporteSnack frm = new ReporteSnack();
            frm.ShowDialog();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AESnack frm = new AESnack(this);
            frm.idUsuario = _uslog.IdUsuario;
            frm.idSnack = idSnack;
            this.Enabled = false;
            frm.Show();
        }

        private void CancelarProductoSnack()
        {
            snack = db.Snack.Where(x => x.IdSnack == idSnack).FirstOrDefault();
            snack.IdEstatus = 4;
            snack.FechaCancelacion = DateTime.Now;
            snack.IdUsuarioCancelo = _uslog.IdUsuario;

            if (idSnack > 0)
            {
                db.Entry(snack).State = EntityState.Modified;
                MessageBox.Show("Consumo cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarSnack();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el consumo a cancelar");
            }
        }

        private void dgrid_snack_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_snack.CurrentCell.RowIndex != -1)
                {
                    idSnack = Convert.ToInt32(this.dgrid_snack.CurrentRow.Cells[0].Value);
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el consumo seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarProductoSnack();

            }
            else
            {
                // Do something
            }
        }

        private void btn_reporte_Click(object sender, EventArgs e)
        {
            VRptConsumoFechasEmp frm = new VRptConsumoFechasEmp();
            frm.Show();
        }
    }
}
