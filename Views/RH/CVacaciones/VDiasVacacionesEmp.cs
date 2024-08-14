using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.RH.CVacaciones
{
    public partial class VDiasVacacionesEmp : Form
    {
        public VDiasVacacionesEmp(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        int idDV = 0;
        public Usuarios _uslog;
        SITEntities db = new SITEntities();
        Form _form;
        
        public void CargarDatos()
        {
            idDV = 0;
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var tb = from x in db.VacDiasEmpPeriodo
                     join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                     join p in db.Periodos on x.idPeriodo equals p.IdPeriodo
                          select new
                          {
                            x.IdDV,
                            t.NombreCompleto,
                            x.Dias,
                            p.Periodo
                          };
            this.dgrid_dvac.DataSource = tb.ToList();
        }

        private void VDiasVacacionesEmp_Load(object sender, EventArgs e)
        {
            this.dgrid_dvac.EnableHeadersVisualStyles = false;
            this.dgrid_dvac.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_dvac.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_dvac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarDatos();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEDiasVacEmp frm = new AEDiasVacEmp(this);
            frm.idDV = idDV;
            frm._uslog = this._uslog;
            this.Enabled = false;
            frm.Show();
        }

        private void dgrid_dvac_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_dvac.CurrentCell.RowIndex != -1)
                {
                    idDV = Convert.ToInt32(this.dgrid_dvac.CurrentRow.Cells[0].Value);
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            }
            catch (Exception ex) { }
        }

        private void VDiasVacacionesEmp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VVacaciones")
            {
                VVacaciones frm = (VVacaciones)this._form;
                frm.Enabled = true;

            }
        }
    }
}
