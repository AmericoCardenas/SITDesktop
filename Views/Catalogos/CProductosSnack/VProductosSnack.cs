using SIT.Views.Almacen.PHerramientas;
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

namespace SIT.Views.Catalogos.CProductosSnack
{
    public partial class VProductosSnack : Form
    {
        public VProductosSnack(Usuarios uslog)
        {
            InitializeComponent();
            this._uslog = uslog;

        }

        SITEntities db = new SITEntities();
        ProductosSnack ps = new ProductosSnack();
        int IdProducto = 0;
        Usuarios _uslog;

        public void CargarDatos()
        {
            this.dgrid_prodsnack.DataSource = null;
            this.dgrid_prodsnack.Rows.Clear();
            this.dgrid_prodsnack.Columns.Clear();
            var x = from p in db.ProductosSnack
                    join m in db.Medidas on p.IdMedida equals m.IdMedida
                    where p.IdEstatus==1
                    select new
                    {
                        p.IdProducto,
                        p.Producto,
                        p.Precio,
                        p.Cantidad,
                        m.Medida
                    };
            this.dgrid_prodsnack.DataSource = x.ToList();
            this.dgrid_prodsnack.Columns[0].Visible = false;
             this.dgrid_prodsnack.EnableHeadersVisualStyles = false;
             this.dgrid_prodsnack.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
             this.dgrid_prodsnack.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
             this.dgrid_prodsnack.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_prodsnack.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        private void dgrid_prodsnack_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgrid_prodsnack.CurrentCell.RowIndex != -1)
                {
                    IdProducto = Convert.ToInt32(this.dgrid_prodsnack.CurrentRow.Cells["IdProducto"].Value);
                }

                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEProductosSnack frm = new AEProductosSnack(this);
            frm.IdProducto = IdProducto;
            frm.IdUsuario = this._uslog.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void CargarxFiltro()
        {
            if (txt_filtro.Text != "")
            {

                var filtro = this.cmb_filtro.Text;
                if (filtro == "Producto")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from p in db.ProductosSnack
                                join m in db.Medidas on p.IdMedida equals m.IdMedida
                                where p.IdEstatus==1 && p.Producto.Contains(filter)
                                select new
                                {
                                    p.IdProducto,
                                    p.Producto,
                                    p.Precio,
                                    p.Cantidad,
                                    m.Medida
                                };
                        this.dgrid_prodsnack.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Precio")
                {
                    try
                    {
                        var filter = Convert.ToDouble(this.txt_filtro.Text);
                        var x = from p in db.ProductosSnack
                                join m in db.Medidas on p.IdMedida equals m.IdMedida
                                where p.IdEstatus == 1 && p.Precio == filter
                                select new
                                {
                                    p.IdProducto,
                                    p.Producto,
                                    p.Precio,
                                    p.Cantidad,
                                    m.Medida
                                };
                        this.dgrid_prodsnack.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "Cantidad")
                {
                    try
                    {
                        var filter = Convert.ToDouble(this.txt_filtro.Text);
                        var x = from p in db.ProductosSnack
                                join m in db.Medidas on p.IdMedida equals m.IdMedida
                                where p.IdEstatus == 1 && p.Cantidad == filter
                                select new
                                {
                                    p.IdProducto,
                                    p.Producto,
                                    p.Precio,
                                    p.Cantidad,
                                    m.Medida
                                };
                        this.dgrid_prodsnack.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Medida")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from p in db.ProductosSnack
                                join m in db.Medidas on p.IdMedida equals m.IdMedida
                                where p.IdEstatus == 1 && m.Medida.Contains(filter)
                                select new
                                {
                                    p.IdProducto,
                                    p.Producto,
                                    p.Precio,
                                    p.Cantidad,
                                    m.Medida
                                };
                        this.dgrid_prodsnack.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    CargarDatos();
                    this.dgrid_prodsnack.Refresh();
                }
            }

        }

        private void VProductosSnack_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarFiltros();
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar?", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarProducto();
            }
            else
            {
                // Do something
            }
        }

        private void CancelarProducto()
        {
            if(this.dgrid_prodsnack.SelectedRows.Count == 0) { 
            
            }
            else {
                ps = db.ProductosSnack.Where(x => x.IdProducto == IdProducto).FirstOrDefault();
                ps.IdEstatus = 2;
                ps.FechaCancelacion = DateTime.Now;
                ps.IdUsuarioCancelo = _uslog.IdUsuario;

                if (IdProducto > 0)
                {
                    db.Entry(ps).State = EntityState.Modified;
                    MessageBox.Show("Cancelado exitosamente");
                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    db.SaveChanges();
                    CargarDatos();
                }
                else
                {
                    MessageBox.Show("Favor de seleccionar el producto a cancelar");
                }
            }

        }

    }
}
