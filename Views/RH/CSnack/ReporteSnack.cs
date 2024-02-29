using CrystalDecisions.ReportAppServer.DataDefModel;
using DocumentFormat.OpenXml.Bibliography;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.RH.CSnack
{
    public partial class ReporteSnack : Form
    {
        public ReporteSnack()
        {
            InitializeComponent();
            this.dtm_inicial.Format = DateTimePickerFormat.Custom;
            this.dtm_inicial.CustomFormat = "dd-MM-yyyy";
            this.dtm_final.Format = DateTimePickerFormat.Custom;
            this.dtm_final.CustomFormat = "dd-MM-yyyy";
        }

        SITEntities db = new SITEntities();

        private void ReporteSnack_Load(object sender, EventArgs e)
        {

        }

        private void ExportarExcel()
        {
            string finicial, ffinal;
            finicial = this.dtm_inicial.Value.ToString("dd-MM-yyyy");
            ffinal = this.dtm_final.Value.ToString("dd-MM-yyyy");

            int x, z = 0;
            SLDocument sl = new SLDocument();
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            SLStyle style = sl.CreateStyle();
            Double total =0;


            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            downloadPath = System.IO.Path.Combine(downloadPath, "Documents");

            var fi = Convert.ToDateTime(finicial);
            var ff = Convert.ToDateTime(ffinal);

            var tb = from s in db.Snack
                     join t in db.Trabajadores on s.IdEmpleado equals t.IdEmpleado
                     join p in db.ProductosSnack on s.IdProducto equals p.IdProducto
                     where s.Fecha >= fi &&
                      s.Fecha <= ff && s.IdMetodoPago==2 && s.IdEstatus!=4
                     group s by t.NombreCompleto into g
                     select new
                     {
                         NombreCompleto = g.Key,
                         TOTAL = g.Sum(s => s.Total)
                     };

            DataGridView dgrid = new DataGridView();
            dgrid.Columns.Add("NombreCompleto", "Nombre Completo");
            dgrid.Columns.Add("TOTAL", "Total");

            foreach (var item in tb)
            {
                dgrid.Rows.Add(item.NombreCompleto, item.TOTAL);
            }

            try
            {

                for (int i = 0; i < dgrid.Columns.Count; i++)
                {
                    sl.SetCellValue(1, i + 1, dgrid.Columns[i].HeaderText);
                }


                for (x = 0; x < dgrid.Rows.Count; x++)
                {
                    for (z = 0; z < dgrid.Columns.Count; z++)
                    {
                        DataGridViewCell cell = dgrid.Rows[x].Cells[z];
                        if (cell.Value != null)
                        {

                            if (z >0 && x>-1)
                            {

                                Double num = Convert.ToDouble(cell.Value);
                                sl.SetCellValue(x + 2, z + 1, num);
                                style.FormatCode = "0.00";
                                sl.SetCellStyle("B"+x.ToString(), style);
                                total+= num;

                            }
                            else
                            {
                                sl.SetCellValue(x + 2, z + 1, cell.Value.ToString());

                            }

                        }
                        else
                        {

                        }
                    }
                }
                int lastcell = dgrid.Rows.Count + 1;
                sl.SetCellValue("B"+lastcell.ToString(),total);

                style = sl.CreateStyle();
                style.FormatCode = "$#,##0.00_);[Red]($#,##0.00)";
                sl.SetCellStyle("B" + lastcell.ToString(), style);

                sl.AutoFitColumn(1, stats.EndColumnIndex);

                // Save the Excel file
                sl.Sort("A1","B"+dgrid.Rows.Count, "B", false);
                sl.SaveAs(downloadPath + "\\Snack.xlsx");
                MessageBox.Show("Archivo exportado en " + downloadPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            if(this.dtm_inicial.Value>this.dtm_final.Value)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final");
            }
            else
            {
                ExportarExcel();
            }
        }
    }
}
