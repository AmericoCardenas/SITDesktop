using SIT.Views.General.CRequisiciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Almacen.CSalidas
{
    public partial class VSalidas : Form
    {
        public VSalidas(Usuarios usuario)
        {
            InitializeComponent();
            this._uslog = usuario;   
        }

        Usuarios _uslog;
        SITEntities db = new SITEntities();
        SalidasAlmacen salidas = new SalidasAlmacen();
        int idSalida = 0;

        public void CargarSalidas()
        {
            idSalida = 0;
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var x = from n in db.SalidasAlmacen
                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdSalida,
                        n.Fecha,
                        n.Hora,
                        t.NombreCompleto
                    };
            this.dgrid_salidas.DataSource = null;
            this.dgrid_salidas.DataSource = x.ToList();
            this.dgrid_salidas.Columns[0].Visible = false;
            this.dgrid_salidas.EnableHeadersVisualStyles = false;
            this.dgrid_salidas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgrid_salidas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgrid_salidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void CargarSalidasAplicadas()
        {
            idSalida = 0;

            var x = from n in db.SalidasAlmacen
                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                    where n.IdEstatus == 3
                    select new
                    {
                        n.IdSalida,
                        n.Fecha,
                        n.Hora,
                        t.NombreCompleto
                    };
            this.dgrid_vaplicados.DataSource = null;
            this.dgrid_vaplicados.DataSource = x.ToList();
            this.dgrid_vaplicados.Columns[0].Visible = false;
            this.dgrid_vaplicados.EnableHeadersVisualStyles = false;
            this.dgrid_vaplicados.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgrid_vaplicados.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgrid_vaplicados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }


        private void VSalidas_Load(object sender, EventArgs e)
        {           
            CargarSalidas();
            CargarFiltros();
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_salidas.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AESalida frm = new AESalida(this);
            frm.IdSalida = idSalida;
            frm.us = _uslog;
            this.Enabled = false;
            frm.ShowDialog();
        }

        private void dgrid_salidas_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_salidas.CurrentCell.RowIndex != -1)
                {
                    idSalida = Convert.ToInt32(this.dgrid_salidas.CurrentRow.Cells[0].Value);
                    //requisiciones = db.Requisiciones.Where(x => x.IdRequisicion == IdRequisicion).FirstOrDefault();
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            }
            catch (Exception ex) { }
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.tbcontrol.SelectedIndex==0)
            {
                CargarSalidas();
                this.btn_add.Visible = true;
            }
            else if (this.tbcontrol.SelectedIndex == 1)
            {
                CargarSalidasAplicadas();
                this.btn_add.Visible=true;
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.buscar, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            }
        }

        private void dgrid_vaplicados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_vaplicados.CurrentCell.RowIndex != -1)
                {
                    idSalida = Convert.ToInt32(this.dgrid_vaplicados.CurrentRow.Cells[0].Value);
                }


            }
            catch (Exception ex) { }
        }
    }
}
