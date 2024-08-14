using GMap.NET;
using SIT.Views.Catalogos;
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

namespace SIT.Views.RH.CArticulos
{
    public partial class VArticulos : Form
    {
        public VArticulos(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        Form _form;
        SITEntities db = new SITEntities();
        public Usuarios uslog;
        private int idArticulo = 0;
        CatArticulosRh cat = new CatArticulosRh();

        public void CargarArticulos()
        {
            idArticulo = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var x = from a in db.CatArticulosRh
                    where a.IdEstatus == 1
                    orderby a.Articulo ascending
                    select new
                    {
                        a.IdArticulo,
                        a.Articulo,
                        a.Stock,
                        a.Max,
                        a.Min

                    };
            this.dgrid_articulos.DataSource = x.ToList();
        }

        private void VArticulos_Load(object sender, EventArgs e)
        {
            CargarArticulos();
            this.dgrid_articulos.EnableHeadersVisualStyles = false;
            this.dgrid_articulos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_articulos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_articulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEArticulo frm = new AEArticulo(this);
            frm.idArticulo = idArticulo;
            frm.uslog = uslog;
            frm.Show();
            this.Enabled = false;
        }

        private void CancelarArticulo()
        {
            cat.IdEstatus = 2;
            cat.FCan = DateTime.Now;
            cat.IdUsCan = this.uslog.IdUsuario;

            if (idArticulo > 0)
            {
                this.db.Entry(cat).State = EntityState.Modified;
                MessageBox.Show("Articulo cancelado exitosamente");
                this.db.SaveChanges();
                CargarArticulos();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el articulo a cancelar");
            }
        }

        private void dgrid_articulos_Click(object sender, EventArgs e)
        {
            if (this.dgrid_articulos.CurrentCell.RowIndex != -1)
            {
                idArticulo = Convert.ToInt32(this.dgrid_articulos.CurrentRow.Cells["IdArticulo"].Value);
                cat = this.db.CatArticulosRh.Where(x => x.IdArticulo == idArticulo).FirstOrDefault();


            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el articulo seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarArticulo();

            }
            else
            {
                // Do something
            }
        }

        private void VArticulos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VEmpleados")
            {
                VEmpleados frm = (VEmpleados)this._form;
                frm.Enabled = true;
                frm.CargarEmpleados(1);
            }
        }
    }
}
