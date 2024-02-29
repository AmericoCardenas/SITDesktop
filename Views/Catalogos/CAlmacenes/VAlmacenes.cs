using SIT.Views.Catalogos.CBancos;
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

namespace SIT.Views.Catalogos.CAlmacenes
{
    public partial class VAlmacenes : Form
    {
        SITEntities db = new SITEntities();
        Usuarios _uslog;
        Almacenes almacen = new Almacenes();    
        int idAlmacen;

        public VAlmacenes(Usuarios us)
        {
            InitializeComponent();
            _uslog = us;
        }

        private void VAlmacenes_Load(object sender, EventArgs e)
        {
            CargarAlmacenes();
            CargarFiltros();
        }

        public void CargarAlmacenes()
        {
            idAlmacen = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            var x = from n in db.Almacenes
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdAlmacen,
                        n.Almacen
                    };
            this.dgrid_almacenes.DataSource = x.ToList();
            this.dgrid_almacenes.Columns[0].Visible = false;
            this.dgrid_almacenes.EnableHeadersVisualStyles = false;
            this.dgrid_almacenes.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_almacenes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_almacenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_almacenes.Columns)
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

            if (txt_filtro.Text != "")
            {
                var filtro = this.cmb_filtro.Text;
                if (filtro == "Almacen")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from n in db.Almacenes
                                where n.Almacen.Contains(filter) && n.IdEstatus == 1
                                select new
                                {
                                    n.IdAlmacen,
                                    n.Almacen
                                };
                        this.dgrid_almacenes.DataSource = x.ToList();
                        this.dgrid_almacenes.Columns[0].Visible = false;
                        this.dgrid_almacenes.EnableHeadersVisualStyles = false;
                        this.dgrid_almacenes.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_almacenes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_almacenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    CargarAlmacenes();
                    this.dgrid_almacenes.Refresh();
                }
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEAlmacen frm = new AEAlmacen(this);
            frm.IdAlmacen = idAlmacen;
            frm.IdUsuario = _uslog.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void CancelarAlmacen()
        {
            almacen = db.Almacenes.Where(x => x.IdAlmacen == idAlmacen).FirstOrDefault();
            almacen.IdEstatus = 2;
            almacen.FechaCancelacion = DateTime.Now;
            almacen.IdUsCancelo = _uslog.IdUsuario;

            if (idAlmacen > 0)
            {
                db.Entry(almacen).State = EntityState.Modified;
                MessageBox.Show("Almacen cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarAlmacenes();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el almacen");
            }
        }

        private void dgrid_almacenes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_almacenes.CurrentCell.RowIndex != -1)
                {
                    idAlmacen = Convert.ToInt32(this.dgrid_almacenes.CurrentRow.Cells[0].Value);
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
            DialogResult result = MessageBox.Show("Desea cancelar el almacen seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarAlmacen();

            }
            else
            {
                // Do something
            }
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void btn_zonasalmacen_Click(object sender, EventArgs e)
        {
            VZonasAlmacen frm = new VZonasAlmacen(this);
            frm.IdUsuario = _uslog.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }
    }
}
