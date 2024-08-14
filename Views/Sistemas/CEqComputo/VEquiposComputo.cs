using DocumentFormat.OpenXml.Vml.Office;
using SIT.CrystalReport;
using SIT.Views.Sistemas.CEqComputo;
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

namespace SIT.Views.Catalogos
{
    public partial class VEquiposComputo : Form
    {
        public VEquiposComputo(Usuarios usuariolog)
        {
            InitializeComponent();
            this._uslog = usuariolog;

        }

        Usuarios _uslog;
        SITEntities db = new SITEntities();
        EquiposComputo equiposComputo = new EquiposComputo();
        int IdEquipo = 0;


        public void CargarEquipos()
        {
            var equipos = from x in db.EquiposComputo
                          join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                          select new {
                           x.IdEquipoComputo,
                           x.Tipo,
                           x.Marca,
                           x.Modelo,
                           x.Ram,
                           x.Procesador,
                           x.Almacenamiento,
                           x.SN,
                           x.Color,
                           x.Caracteristicas,
                           x.Detalles,
                           x.Accesorios,
                           x.ValorComercial,
                           t.NombreCompleto };
            this.dgrid_equipos.DataSource = equipos.ToList();

            this.dgrid_equipos.Columns["IdEquipoComputo"].Visible = false;
            this.dgrid_equipos.Columns["Almacenamiento"].Visible = false;
            this.dgrid_equipos.Columns["Caracteristicas"].Visible = false;
            this.dgrid_equipos.Columns["Detalles"].Visible = false;

            foreach(DataGridViewColumn col in this.dgrid_equipos.Columns)
            {
                col.AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;  
            }

            this.dgrid_equipos.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;





        }


        private void dgrid_equipos_Click(object sender, EventArgs e)
        {
            if (this.dgrid_equipos.CurrentCell.RowIndex != -1)
            {
                IdEquipo = Convert.ToInt32(this.dgrid_equipos.CurrentRow.Cells["IdEquipoComputo"].Value);

            }

            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEEqComputo frm =  new AEEqComputo(this);
            frm.idEqComputo = IdEquipo;
            this.Enabled = false;
            frm.Show();
        }

        private void VEquiposComputo_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            this.dgrid_equipos.EnableHeadersVisualStyles = false;
            this.dgrid_equipos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_equipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.frm = this;
            frm.ideqcomp = Convert.ToInt32(this.dgrid_equipos.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
