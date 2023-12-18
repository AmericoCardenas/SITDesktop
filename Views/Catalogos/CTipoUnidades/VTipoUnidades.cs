using SIT.Views.Catalogos.CProveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Catalogos.CTipoUnidades
{
    public partial class VTipoUnidades : Form
    {
        public VTipoUnidades(Usuarios us)
        {
            InitializeComponent();
            this._uslog = us;
        }

        int IdTipo = 0;
        Usuarios _uslog;
        TipoUnidades tpu = new TipoUnidades();
        SITEntities db = new SITEntities();

        public void CargarTipoUnidades()
        {
            IdTipo = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var x = from n in db.TipoUnidades
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdTipo,
                        n.Unidad,
                        n.Rendimiento
                    };
            this.dgrid_tpu.DataSource = x.ToList();
            this.dgrid_tpu.Columns[0].Visible = false;
            this.dgrid_tpu.EnableHeadersVisualStyles = false;
            this.dgrid_tpu.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_tpu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_tpu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarFiltros()
        {
            //foreach (DataGridViewColumn col in this.dgrid_tpu.Columns)
            //{
            //    if (col.Index > 0)
            //    {
            //        this.cmb_filtro.Items.Add(col.Name);
            //    }

            //}
            //this.cmb_filtro.SelectedIndex = 0;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AETipoUnidad frm = new AETipoUnidad();
            frm.IdTipo = IdTipo;
            frm.IdUsuario = _uslog.IdUsuario;
            frm.vtipo = this;
            this.Enabled = false;
            frm.Show();
        }

        private void CancelarTipoUnidad()
        {
            tpu = db.TipoUnidades.Where(x => x.IdTipo == IdTipo).FirstOrDefault();
            tpu.IdEstatus = 2;
            tpu.FechaCancelacion = DateTime.Now;
            tpu.IdUsuarioCancelo = _uslog.IdUsuario;

            if (IdTipo > 0)
            {
                db.Entry(tpu).State = EntityState.Modified;
                MessageBox.Show("Registro cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarTipoUnidades();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el registro");
            }
        }

        private void dgrid_tpu_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_tpu.CurrentCell.RowIndex != -1)
                {
                    IdTipo = Convert.ToInt32(this.dgrid_tpu.CurrentRow.Cells[0].Value);
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
            DialogResult result = MessageBox.Show("Desea cancelar el registro seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarTipoUnidad();

            }
            else
            {
                // Do something
            }
        }

        private void VTipoUnidades_Load(object sender, EventArgs e)
        {
            CargarTipoUnidades();

        }
    }
}
