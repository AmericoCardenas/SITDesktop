using DocumentFormat.OpenXml.Wordprocessing;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.RH.CSnack
{
    public partial class VRptConsumoFechasEmp : Form
    {
        public VRptConsumoFechasEmp()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();

        private void CargarRptxFechas()
        {
            string finicial, ffinal;
            finicial = this.dtm_finicial.Value.ToString("dd-MM-yyyy");
            ffinal = this.dtm_final.Value.ToString("dd-MM-yyyy");

            var fi = Convert.ToDateTime(finicial);
            var ff = Convert.ToDateTime(ffinal);

            var x = from s in db.Snack
                    join t in db.Trabajadores on s.IdEmpleado equals t.IdEmpleado
                    join p in db.ProductosSnack on s.IdProducto equals p.IdProducto
                    join m in db.TipoPagoSnack on s.IdMetodoPago equals m.IdTipoPago
                    where s.IdMetodoPago == 2 && s.IdEstatus!=4 && s.Fecha >= fi && s.Fecha <= ff
                    orderby t.NombreCompleto ascending
                    select new
                    {
                        s.Fecha,
                        s.Hora,
                        t.NombreCompleto,
                        p.Producto,
                        s.PrecioU,
                        s.Cantidad,
                        s.Total,
                        m.Pago
                    };

            this.dgrid_report.DataSource=x.ToList();

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            CargarRptxFechas();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void ExportarExcel()
        {
            int x, z = 0;
            SLDocument sl = new SLDocument();
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            downloadPath = System.IO.Path.Combine(downloadPath, "Documents");


            try
            {

                for (int i = 0; i < dgrid_report.Columns.Count; i++)
                {
                    sl.SetCellValue(1, i + 1, this.dgrid_report.Columns[i].HeaderText);
                }


                for (x = 0; x < this.dgrid_report.Rows.Count; x++)
                {
                    for (z = 0; z < this.dgrid_report.Columns.Count; z++)
                    {
                        DataGridViewCell cell = this.dgrid_report.Rows[x].Cells[z];
                        if (cell.Value != null)
                        {
                            sl.SetCellValue(x + 2, z + 1, cell.Value.ToString());

                        }
                        else
                        {

                        }
                    }
                }


                sl.AutoFitColumn(1, stats.EndColumnIndex);

                // Save the Excel file
                sl.SaveAs(downloadPath + "\\RptSnack" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                MessageBox.Show("Archivo exportado en " + downloadPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
