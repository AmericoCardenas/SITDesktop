using SIT.Views.General.CRequisiciones;
using SIT.Views.Taller.CActMecanicos;
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

namespace SIT.Views.Taller
{
    public partial class VOrdenesTrabajo : Form
    {
        public VOrdenesTrabajo(Usuarios usuarios)
        {
            InitializeComponent();
            this._uslog=usuarios;
        }

        Usuarios _uslog;
        SITEntities db = new SITEntities();
        OrdenesTrabajoTaller ot = new OrdenesTrabajoTaller();
        int idOT = 0;

        public void CargarOTS()
        {
            idOT = 0;
            int idestatus = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            DataGridView dgrid = new DataGridView();


            if (tbcontrol.SelectedIndex == 0)
            {
                dgrid = this.dgrid_otpend;
                idestatus = 1;
                this.btn_add.Enabled = true;
            }
            else if (tbcontrol.SelectedIndex == 1)
            {
                dgrid = this.dgrid_otfin;
                idestatus = 3;
                this.btn_add.Enabled = true;
            }

                var x = from n in db.OrdenesTrabajoTaller
                        join u in db.Unidades on n.IdUnidad equals u.IdUnidad
                        where n.IdEstatus == idestatus  
                        select new
                        {
                            n.IdOrdenTrabajo,
                            n.Fecha,
                            n.Hora,
                            u.Economico,
                            n.Observaciones
                        };

                dgrid.DataSource = null;
                dgrid.DataSource = x.ToList();
                dgrid.EnableHeadersVisualStyles = false;
                dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            AEOrdenesTrabajo frm = new AEOrdenesTrabajo(this);
            frm.idOT = idOT;
            frm.uslog = _uslog;
            this.Enabled = false;
            frm.ShowDialog();
        }

        private void dgrid_otpend_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_otpend.CurrentCell.RowIndex != -1)
                {
                    idOT = Convert.ToInt32(this.dgrid_otpend.CurrentRow.Cells[0].Value);
                    ot = db.OrdenesTrabajoTaller.Where(x => x.IdOrdenTrabajo == idOT).FirstOrDefault();
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            }
            catch (Exception ex) { }
        }

        private void VOrdenesTrabajo_Load(object sender, EventArgs e)
        {
            CargarOTS();
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarOTS();

            if (this.tbcontrol.SelectedIndex == 0)
            {
                this.btn_cancel.Visible = true;
            }
            else if (this.tbcontrol.SelectedIndex==1)
            {
                this.btn_cancel.Visible = false;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar la OT seleccionada", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarOT();

            }
            else
            {
                // Do something
            }
        }

        private void CancelarOT()
        {
            var x = db.ActividadesOT.Where(y=>y.IdOT==idOT && y.IdEstatus!=2).ToList();
            if (!x.Any())
            {
                ot.IdEstatus = 2;
                ot.FCan = DateTime.Now;
                ot.IdUsCan = _uslog.IdUsuario;

                if (idOT > 0)
                {
                    db.Entry(ot).State = EntityState.Modified;
                    MessageBox.Show("OT cancelado exitosamente");
                    db.SaveChanges();
                    CargarOTS();
                }
                else
                {
                    MessageBox.Show("Favor de seleccionar la OT a cancelar");
                }
            }
            else
            {
                MessageBox.Show("No se puede cancelar la OT debido a que cuenta con actividades pendientes");
            }

        }

        private void dgrid_otfin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_otfin.CurrentCell.RowIndex != -1)
                {
                    idOT = Convert.ToInt32(this.dgrid_otfin.CurrentRow.Cells[0].Value);
                    ot = db.OrdenesTrabajoTaller.Where(x => x.IdOrdenTrabajo == idOT).FirstOrDefault();
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.buscar, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            }
            catch (Exception ex) { }
        }

        private void btn_act_mecanicos_Click(object sender, EventArgs e)
        {
            VActMecanicos form = new VActMecanicos();
            form.Show();
        }
    }
}
