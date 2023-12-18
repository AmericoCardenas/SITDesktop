using SIT.Views.RH.CSnack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        Usuarios _usuarios;
        SITEntities db = new SITEntities();

        private void VSnack_Load(object sender, EventArgs e)
        {
            CargarSnack();
            CargarFiltros();
            
        }

        private void CargarSnack()
        {
            this.dgrid_snack.DataSource = null;
            this.dgrid_snack.Rows.Clear();
            this.dgrid_snack.Columns.Clear();
            this.dgrid_snack.Refresh();

            var x = from s in db.Snack
                    join t in db.Trabajadores on s.IdEmpleado equals t.IdEmpleado
                    join p in db.ProductosSnack on s.IdProducto equals p.IdProducto
                    join m in db.TipoPagoSnack on s.IdMetodoPago equals m.IdTipoPago
                    where s.IdEstatus == 1
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
                                where s.IdEstatus == 1 && s.Fecha == filter
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
                                where s.IdEstatus == 1 && t.NombreCompleto.Contains(filter)
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
                                where s.IdEstatus == 1 && p.Producto.Contains(filter)
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
                                where s.IdEstatus == 1 && m.Pago.Contains(filter)
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
    }
}
