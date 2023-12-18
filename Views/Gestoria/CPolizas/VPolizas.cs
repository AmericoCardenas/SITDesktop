using GMap.NET;
using SIT.Views.Catalogos.CUnidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Gestoria.CPolizas
{
    public partial class VPolizas : Form
    {
        public VPolizas(Usuarios us)
        {
            InitializeComponent();
            this._uslog = us;
        }

        SITEntities db = new SITEntities();
        Usuarios _uslog;
        int IdPoliza = 0;

        private void VPolizas_Load(object sender, EventArgs e)
        {
            CargarPolizas();
        }

        public void CargarPolizas()
        {
            IdPoliza = 0;
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var x = from n in db.PolizasUnidades
                    join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                    join u in db.Unidades on n.IdUnidad equals u.IdUnidad
                    select new
                    {
                        n.IdPoliza,
                        p.Proveedor,
                        n.NumPoliza,
                        n.Costo,
                        n.Endoso,
                        n.Inciso,
                        u.Economico
                    };
            this.dgrid_polizas.DataSource = x.ToList();
            this.dgrid_polizas.Columns[0].Visible = false;
            this.dgrid_polizas.EnableHeadersVisualStyles = false;
            this.dgrid_polizas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_polizas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_polizas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void AgregarUnidad()
        {
            AEPolizas frm = new AEPolizas(this);
            frm.IdPoliza = IdPoliza;
            frm.IdUsuario = _uslog.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarUnidad();
        }

        private void dgrid_polizas_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_polizas.CurrentCell.RowIndex != -1)
                {
                    IdPoliza = Convert.ToInt32(this.dgrid_polizas.CurrentRow.Cells[0].Value);
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
