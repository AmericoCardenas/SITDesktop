using SIT.Views.Catalogos.CBancos;
using SIT.Views.Catalogos.CProductosAlmacen;
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

namespace SIT.Views.Almacen.CProductosAlmacen
{
    public partial class VProductosAlmacen : Form
    {
        public VProductosAlmacen(Usuarios usuarios)
        {
            InitializeComponent();
            this._uslog = usuarios;
        }

        SITEntities db = new SITEntities();
        ProductosAlmacen productos = new ProductosAlmacen();
        Usuarios _uslog;
        int IdProducto;

        private void AEProductosAlmacen_Load(object sender, EventArgs e)
        {
            CargarProductosAlmacen();
            CargarFiltros();
        }

        public void CargarProductosAlmacen()
        {
            IdProducto = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var x = from n in db.ProductosAlmacen
                    join z in db.ZonasAlmacen on n.IdZona equals z.IdZona
                    join a in db.Almacenes on z.IdAlmacen equals a.IdAlmacen
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdProducto,
                        n.CodProducto,
                        n.Nombre,
                        n.Stock,
                        a.Almacen,
                        z.Zona
                        
                    };

            this.dgrid_prods.DataSource = x.ToList();
            this.dgrid_prods.Columns[0].Visible = false;
            this.dgrid_prods.EnableHeadersVisualStyles = false;
            this.dgrid_prods.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_prods.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_prods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_prods.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        private void CargarxFiltro()
        {

            if (this.txt_filtro.Text != "")
            {
                var filtro = this.cmb_filtro.Text;
                if (filtro == "CodProducto")
                {
                    try
                    {
                        var x = from n in db.ProductosAlmacen
                                join z in db.ZonasAlmacen on n.IdZona equals z.IdZona
                                join a in db.Almacenes on z.IdAlmacen equals a.IdAlmacen
                                where n.IdEstatus == 1 && n.CodProducto.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    n.IdProducto,
                                    n.CodProducto,
                                    n.Nombre,
                                    n.Stock,
                                    a.Almacen,
                                    z.Zona

                                };
                        this.dgrid_prods.DataSource = x.ToList();
                        this.dgrid_prods.Columns[0].Visible = false;
                        this.dgrid_prods.EnableHeadersVisualStyles = false;
                        this.dgrid_prods.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_prods.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_prods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Nombre")
                {
                    try
                    {
                        var x = from n in db.ProductosAlmacen
                                join z in db.ZonasAlmacen on n.IdZona equals z.IdZona
                                join a in db.Almacenes on z.IdAlmacen equals a.IdAlmacen
                                where n.IdEstatus == 1 && n.Nombre.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    n.IdProducto,
                                    n.CodProducto,
                                    n.Nombre,
                                    n.Stock,
                                    a.Almacen,
                                    z.Zona

                                };
                        this.dgrid_prods.DataSource = x.ToList();
                        this.dgrid_prods.Columns[0].Visible = false;
                        this.dgrid_prods.EnableHeadersVisualStyles = false;
                        this.dgrid_prods.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_prods.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_prods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Almacen")
                {
                    try
                    {
                        var x = from n in db.ProductosAlmacen
                                join z in db.ZonasAlmacen on n.IdZona equals z.IdZona
                                join a in db.Almacenes on z.IdAlmacen equals a.IdAlmacen
                                where n.IdEstatus == 1 && a.Almacen.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    n.IdProducto,
                                    n.CodProducto,
                                    n.Nombre,
                                    n.Stock,
                                    a.Almacen,
                                    z.Zona

                                };
                        this.dgrid_prods.DataSource = x.ToList();
                        this.dgrid_prods.Columns[0].Visible = false;
                        this.dgrid_prods.EnableHeadersVisualStyles = false;
                        this.dgrid_prods.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_prods.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_prods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }

                else
                {
                    CargarProductosAlmacen();
                    this.dgrid_prods.Refresh();
                }
            }

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEProductosAlmacen frm = new AEProductosAlmacen(this);
            frm.IdProducto = this.IdProducto;
            frm.IdUsuario = _uslog.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void CancelarProducto()
        {
            productos.IdEstatus = 2;
            productos.FechaCan = DateTime.Now;
            productos.IdUsCan = _uslog.IdUsuario;

            if (IdProducto > 0)
            {
                db.Entry(productos).State = EntityState.Modified;
                MessageBox.Show("Producto cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarProductosAlmacen();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el producto");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el producto seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarProducto();

            }
            else
            {
                // Do something
            }
        }

        private void dgrid_prods_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_prods.CurrentCell.RowIndex != -1)
                {
                    IdProducto = Convert.ToInt32(this.dgrid_prods.CurrentRow.Cells[0].Value);
                    productos = db.ProductosAlmacen.Where(x => x.IdProducto == IdProducto).FirstOrDefault();

                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_historial_Click(object sender, EventArgs e)
        {
            VHistorialCompras frm = new VHistorialCompras();
            frm.idProducto = IdProducto;
            frm.producto = productos.Nombre;
            //this.Enabled = false;
            frm.Show();

        }
    }
}
