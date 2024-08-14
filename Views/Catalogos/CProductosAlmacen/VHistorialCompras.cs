using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Catalogos.CProductosAlmacen
{
    public partial class VHistorialCompras : Form
    {
        public VHistorialCompras()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();
        public int idProducto;
        public string producto;

        private void CargarHistorial()
        {
            var x = 
                    from d in db.DetalleRequisiciones
                    join c in db.CotizacionesRequisiciones on d.IdDetalleReq equals c.IdDetalleReq
                    join o in db.OrdenesCompra on c.IdOCompra equals o.IdOCompra
                    join p in db.Proveedores on o.IdProveedor equals p.IdProveedor
                    join pr in db.ProductosAlmacen on d.IdProductoAlmacen equals pr.IdProducto
                    where d.IdProductoAlmacen==idProducto && o.IdEstatus>=3
                    select new
                    {
                        o.IdOCompra,
                        o.Fecha,
                        p.Proveedor,
                        d.Cantidad,
                        c.CostoUnitario,
                        c.Total
                    };

            this.dgrid_historial.DataSource = x.ToList();
        }

        private void VHistorialCompras_Load(object sender, EventArgs e)
        {
            this.dgrid_historial.EnableHeadersVisualStyles = false;
            this.dgrid_historial.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_historial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_historial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Text = "Histoial de Compras "+producto;
            CargarHistorial();
        }

        private void VHistorialCompras_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
