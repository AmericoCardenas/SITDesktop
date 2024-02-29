using GMap.NET;
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
    public partial class VZonasAlmacen : Form
    {
        public VZonasAlmacen(VAlmacenes valmacen)
        {
            InitializeComponent();
            this._valmacenes = valmacen;
        }

        SITEntities db = new SITEntities();
        ZonasAlmacen zona = new ZonasAlmacen(); 
        public int IdUsuario,IdZona;
        VAlmacenes _valmacenes;

        private void VZonasAlmacen_Load(object sender, EventArgs e)
        {
            CargarZonasAlmacen();
            CargarFiltros();
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_zonasalmacen.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        public void CargarZonasAlmacen()
        {
            IdZona = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            var x = from n in db.ZonasAlmacen
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdZona,
                        n.Zona
                    };
            this.dgrid_zonasalmacen.DataSource = x.ToList();
            this.dgrid_zonasalmacen.Columns[0].Visible = false;
            this.dgrid_zonasalmacen.EnableHeadersVisualStyles = false;
            this.dgrid_zonasalmacen.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_zonasalmacen.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_zonasalmacen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEZonaAlmacen frm = new AEZonaAlmacen(this);
            frm.IdZona = IdZona;
            frm.IdUsuario = IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void CargarxFiltro()
        {

            if (txt_filtro.Text != "")
            {
                var filtro = this.cmb_filtro.Text;
                if (filtro == "Zona")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from n in db.ZonasAlmacen       
                                where n.Zona.Contains(filter) && n.IdEstatus == 1
                                select new
                                {
                                    n.IdZona,
                                    n.Zona
                                };
                        this.dgrid_zonasalmacen.DataSource = x.ToList();
                        this.dgrid_zonasalmacen.Columns[0].Visible = false;
                        this.dgrid_zonasalmacen.EnableHeadersVisualStyles = false;
                        this.dgrid_zonasalmacen.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_zonasalmacen.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_zonasalmacen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    CargarZonasAlmacen();
                    this.dgrid_zonasalmacen.Refresh();
                }
            }

        }

        private void dgrid_zonasalmacen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_zonasalmacen.CurrentCell.RowIndex != -1)
                {
                    IdZona = Convert.ToInt32(this.dgrid_zonasalmacen.CurrentRow.Cells[0].Value);
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
            DialogResult result = MessageBox.Show("Desea cancelar la zona seleccionada", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarZona();

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

        private void VZonasAlmacen_FormClosed(object sender, FormClosedEventArgs e)
        {
            _valmacenes.Enabled = true;
            _valmacenes.CargarAlmacenes();
        }

        private void CancelarZona()
        {
            zona = db.ZonasAlmacen.Where(x => x.IdZona == IdZona).FirstOrDefault();
            zona.IdEstatus = 2;
            zona.FechaCancelacion = DateTime.Now;
            zona.IdUsCancelo = IdUsuario;

            if (IdZona > 0)
            {
                db.Entry(zona).State = EntityState.Modified;
                MessageBox.Show("Zona cancelada exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarZonasAlmacen();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar la zona");
            }
        }

    }
}
