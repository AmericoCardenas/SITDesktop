using GMap.NET;
using SIT.Views.RH.CSnack;
using SpreadsheetLight;
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

namespace SIT.Views.RH.CVacaciones
{
    public partial class VVacaciones : Form
    {
        public VVacaciones(Usuarios uslog)
        {
            InitializeComponent();
            this._uslog = uslog;
        }

        SITEntities db = new SITEntities();
        VacacionesEmp vac = new VacacionesEmp();
        Usuarios _uslog;
        int idVacacion = 0;

        public void CargarDatos()
        {
            idVacacion = 0;

            var x = from v in db.VacacionesEmp
                    join t in db.Trabajadores on v.IdEmpleado equals t.IdEmpleado
                    join p in db.Periodos on v.IdPeriodo equals p.IdPeriodo
                    where v.IdEstatus==1
                    select new
                    {
                        v.IdVacacion,
                        v.Fecha,
                        t.NombreCompleto,
                        p.Periodo,
                        v.Observaciones
                    };

            this.dgrid_vacaciones.DataSource = x.ToList();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEVacaciones frm = new AEVacaciones(this);
            frm.Show();
            frm._uslog = this._uslog;
            this.Enabled = false;
        }

        private void btn_dias_Click(object sender, EventArgs e)
        {
            VDiasVacacionesEmp frm = new VDiasVacacionesEmp(this);
            frm.Show();
            frm._uslog=this._uslog;
            this.Enabled = false;

        }

        private void VVacaciones_Load(object sender, EventArgs e)
        {
            this.dgrid_vacaciones.EnableHeadersVisualStyles = false;
            this.dgrid_vacaciones.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_vacaciones.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_vacaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarDatos();


        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el consumo seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarVacaciones();

            }
            else
            {
                // Do something
            }
        }

        private void CancelarVacaciones()
        {
            vac.IdEstatus = 2;
            vac.FMod = DateTime.Now;
            vac.IdUsCan = _uslog.IdUsuario;

            if (idVacacion > 0)
            {
                this.db.Entry(vac).State = EntityState.Modified;
                this.db.SaveChanges();
                MessageBox.Show("Dia cancelado exitosamente");
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el dia a cancelar");
            }
        }

        private void dgrid_vacaciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_vacaciones.CurrentCell.RowIndex != -1)
                {
                    idVacacion = Convert.ToInt32(this.dgrid_vacaciones.CurrentRow.Cells[0].Value);
                    vac = this.db.VacacionesEmp.Where(x => x.IdVacacion == idVacacion).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void ExportarExcel()
        {


            SLDocument sl = new SLDocument();
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            downloadPath = System.IO.Path.Combine(downloadPath, "Documents");



            try
            {
                for (int i = 0; i < this.dgrid_vacaciones.Columns.Count; i++)
                {
                    sl.SetCellValue(1, i + 1, this.dgrid_vacaciones.Columns[i].Name);
                }

                for (int i = 0; i < this.dgrid_vacaciones.Rows.Count; i++)
                {
                    for (int j = 0; j < this.dgrid_vacaciones.Columns.Count; j++)
                    {
                        DataGridViewCell cell = this.dgrid_vacaciones.Rows[i].Cells[j];
                        if (cell.Value != null)
                        {
                            sl.SetCellValue(i + 2, j + 1, this.dgrid_vacaciones.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                }



                sl.AutoFitColumn(1, stats.EndColumnIndex);

                // Save the Excel file
                sl.SaveAs(downloadPath + "\\RptVacaciones" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                MessageBox.Show("Archivo exportado en " + downloadPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
