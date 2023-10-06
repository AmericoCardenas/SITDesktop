using SIT.Views.Catalogos.CProveedores;
using SIT.Views.Contabilidad.CMovimientos;
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

namespace SIT.Views.Catalogos
{
    public partial class VProveedores : Form
    {
        public VProveedores(Usuarios us)
        {
            InitializeComponent();
            this._uslog = us;
        }

        int IdProveedor = 0;
        Usuarios _uslog;
        Proveedores prov = new Proveedores();
        SITEntities db = new SITEntities();

        public void CargarProveedores()
        {
            var x = from n in db.Proveedores
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdProveedor,
                        n.Proveedor
                    };
            this.dgrid_proveedores.DataSource = x.ToList();
            this.dgrid_proveedores.Columns[0].Visible = false;
            this.dgrid_proveedores.EnableHeadersVisualStyles = false;
            this.dgrid_proveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_proveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_proveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_proveedores.Columns)
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
                if (filtro == "Proveedor")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from n in db.Proveedores
                                where n.Proveedor.Contains(filter) && n.IdEstatus == 1
                                select new
                                {
                                    n.IdProveedor,
                                    n.Proveedor
                                };
                        this.dgrid_proveedores.DataSource = x.ToList();
                        this.dgrid_proveedores.Columns[0].Visible = false;
                        this.dgrid_proveedores.EnableHeadersVisualStyles = false;
                        this.dgrid_proveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_proveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_proveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    CargarProveedores();
                    this.dgrid_proveedores.Refresh();
                }
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEProveedores frm = new AEProveedores();
            frm.IdProveedor= IdProveedor;
            frm.IdUsuario = _uslog.IdUsuario;
            frm.vprov = this;
            this.Enabled = false;
            frm.Show();
        }

        private void CancelarProveedor()
        {
            prov = db.Proveedores.Where(x => x.IdProveedor == IdProveedor).FirstOrDefault();
            prov.IdEstatus = 2;
            prov.FechaCancelacion = DateTime.Now;
            prov.UsuarioCancelacion = _uslog.IdUsuario;

            if (IdProveedor > 0)
            {
                db.Entry(prov).State = EntityState.Modified;
                MessageBox.Show("Proveedor cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarProveedores();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el proveedor");
            }
        }

        private void dgrid_proveedores_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_proveedores.CurrentCell.RowIndex != -1)
                {
                    IdProveedor = Convert.ToInt32(this.dgrid_proveedores.CurrentRow.Cells[0].Value);
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
            DialogResult result = MessageBox.Show("Desea cancelar el proveedor seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarProveedor();

            }
            else
            {
                // Do something
            }
        }

        private void VProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarFiltros();

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }
    }
}
