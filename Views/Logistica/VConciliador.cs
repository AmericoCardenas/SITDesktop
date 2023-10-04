using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SIT.Views.Logistica
{
    public partial class VConciliador : Form
    {
        public VConciliador()
        {
            InitializeComponent();
        }

        string filePath = string.Empty;
        string connectionString = string.Empty;

        string serverName = "SERVIDOR\\COMPAC";
        string databaseName = "SIT";
        string username = "sa";
        string password = "compac";

        int totalrows = 0;
        int processedRows = 0;

        SITEntities db = new SITEntities();


        private void VConciliador_Load(object sender, EventArgs e)
        {
            connectionString = $"Server={serverName};Database={databaseName};User Id={username};Password={password};";
        }
        private void btn_impRol_Click(object sender, EventArgs e)
        {
            ImportarExcelRol();
        }


        private void ImportarExcelRol()
        {
            string fecha = this.dtm_fecha.Value.ToString("dd-MM-yyyy");
            var entitiesToDelete = db.BitacoraRol.Where(e => e.Fecha.Equals(fecha)).ToList();
            db.BitacoraRol.RemoveRange(entitiesToDelete);
            db.SaveChanges();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the title and filter for the dialog
            openFileDialog.Title = "Seleccionar Excel";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                Debug.WriteLine("Selected file path: " + filePath);
            }
            else
            {
                Debug.WriteLine("No file selected.");
            }


            using (var slDocument = new SLDocument(filePath))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SLWorksheetStatistics stats = slDocument.GetWorksheetStatistics();

                    totalrows = stats.EndRowIndex;


                    for (int row = 1; row <= stats.EndRowIndex; row++) // Empezamos desde la fila 2 para omitir encabezados
                    {
                        processedRows++;
                        int progressPercentage = (int)((processedRows / (double)totalrows) * 100);
                        this.pgrbar.Value = progressPercentage;
                        Application.DoEvents();

                        string cv1 = slDocument.GetCellValueAsString(row, 1); // Suponiendo que la columna 1 contiene el primer valor

                        DateTime date = DateTime.FromOADate(slDocument.GetCellValueAsDouble(row, 2));
                        string cv2 = date.ToString("dd-MM-yyyy");
                        string cv3 = slDocument.GetCellValueAsString(row, 3); // Suponiendo que la columna 2 contiene el segundo valor
                        string cv4 = slDocument.GetCellValueAsString(row, 4); // Suponiendo que la columna 2 contiene el segundo valor
                        string cv6 = slDocument.GetCellValueAsString(row, 6); // Suponiendo que la columna 2 contiene el segundo valor
                        string cv9 = slDocument.GetCellValueAsString(row, 10); // Suponiendo que la columna 2 contiene el segundo valor
                        string cv10 = slDocument.GetCellValueAsString(row, 11); // Suponiendo que la columna 2 contiene el segundo valor


                        // Crear la consulta de inserción
                        string insertQuery = $"INSERT INTO BitacoraRol (CodBitad,Fecha,Turno,Ruta,Unidad,Servicio,Operador) VALUES (@C1,@C2,@C3,@C4,@C5,@C6,@C7)";

                        using (var command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@C1", cv1);
                            command.Parameters.AddWithValue("@C2", cv2);
                            command.Parameters.AddWithValue("@C3", cv3);
                            command.Parameters.AddWithValue("@C4", cv4);
                            command.Parameters.AddWithValue("@C5", cv6);
                            command.Parameters.AddWithValue("@C6", cv9);
                            command.Parameters.AddWithValue("@C7", cv10);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Datos importados correctamente");
            this.pgrbar.Value = 0;

            Debug.WriteLine("Datos importados a la base de datos.");
        }

        private void ImportarExcelBitad()
        {
            string fecha = this.dtm_fecha.Value.ToString("dd-MM-yyyy");
            var entitiesToDelete = db.BitacoraBitad.Where(e => e.Fecha.Equals(fecha)).ToList();
            db.BitacoraBitad.RemoveRange(entitiesToDelete);
            db.SaveChanges();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the title and filter for the dialog
            openFileDialog.Title = "Seleccionar Excel";
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*";

            // Show the dialog and check if the user clicked OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                Debug.WriteLine("Selected file path: " + filePath);
            }
            else
            {
                Debug.WriteLine("No file selected.");
            }


            using (var slDocument = new SLDocument(filePath))
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SLWorksheetStatistics stats = slDocument.GetWorksheetStatistics();

                    totalrows = stats.EndRowIndex;
                    processedRows = 0;


                    for (int row = 2; row <= stats.EndRowIndex; row++) // Empezamos desde la fila 2 para omitir encabezados
                    {
                        processedRows++;
                        int progressPercentage = (int)((processedRows / (double)totalrows) * 100);
                        this.pgrbar.Value = progressPercentage;
                        Application.DoEvents();

                        string cv1 = slDocument.GetCellValueAsString(row, 1); // Suponiendo que la columna 1 contiene el primer valor

                        DateTime date = DateTime.FromOADate(slDocument.GetCellValueAsDouble(row, 2));
                        string cv2 = date.ToString("dd-MM-yyyy");
                        string cv3 = slDocument.GetCellValueAsString(row, 7); // Suponiendo que la columna 2 contiene el segundo valor
                        string cv4 = slDocument.GetCellValueAsString(row, 6); // Suponiendo que la columna 2 contiene el segundo valor
                        string cv6 = slDocument.GetCellValueAsString(row, 5); // Suponiendo que la columna 2 contiene el segundo valor
                        string cv9 = slDocument.GetCellValueAsString(row, 8); // Suponiendo que la columna 2 contiene el segundo valor
                        string cv10 = slDocument.GetCellValueAsString(row, 4); // Suponiendo que la columna 2 contiene el segundo valor


                        // Crear la consulta de inserción
                        string insertQuery = $"INSERT INTO BitacoraBitad (CodBitad,Fecha,Turno,Ruta,Unidad,Servicio,Operador) VALUES (@C1,@C2,@C3,@C4,@C5,@C6,@C7)";

                        using (var command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@C1", cv1);
                            command.Parameters.AddWithValue("@C2", cv2);
                            command.Parameters.AddWithValue("@C3", cv3);
                            command.Parameters.AddWithValue("@C4", cv4);
                            command.Parameters.AddWithValue("@C5", cv6);
                            command.Parameters.AddWithValue("@C6", cv9);
                            command.Parameters.AddWithValue("@C7", cv10);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            MessageBox.Show("Datos importados correctamente");
            this.pgrbar.Value = 0;

            Debug.WriteLine("Datos importados a la base de datos.");
        }

        private void btn_impBitad_Click(object sender, EventArgs e)
        {
            ImportarExcelBitad();
        }

        private void btn_conciliar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            string fecha = this.dtm_fecha.Value.ToString("dd-MM-yyyy");

            this.dgrid_bitad.DataSource = null;
            this.dgrid_rol.DataSource= null;    

            var x = db.BitacoraRol.Where(a => a.Fecha.Contains(fecha)).ToList();
            this.dgrid_rol.DataSource = x;
            this.dgrid_rol.Columns[0].Visible = false;
            this.dgrid_rol.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_rol.EnableHeadersVisualStyles = false;
            this.dgrid_rol.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgrid_rol.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;


            var y = db.BitacoraBitad.Where(b => b.Fecha.Contains(fecha)).ToList();
            this.dgrid_bitad.DataSource = y;
            this.dgrid_bitad.Columns[0].Visible = false;
            this.dgrid_bitad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_bitad.EnableHeadersVisualStyles = false;
            this.dgrid_bitad.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgrid_bitad.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;


            Conciliar();

            this.lbl_cantrol.Text = this.dgrid_rol.RowCount.ToString();
            this.lbl_cantbitad.Text = this.dgrid_bitad.RowCount.ToString();


        }

        private void Conciliar()
        {
            foreach (DataGridViewRow row in this.dgrid_rol.Rows)
            {
                string codbitad = row.Cells[1].Value.ToString();
                var z = db.BitacoraBitad.Where(a => a.CodBitad.Equals(codbitad)).FirstOrDefault();
                if (z == null)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                else if (z.Fecha != row.Cells[2].Value.ToString())
                {
                    row.Cells[2].Style.BackColor = System.Drawing.Color.Red;
                }
                else if (z.Turno != row.Cells[3].Value.ToString())
                {
                    row.Cells[3].Style.BackColor = System.Drawing.Color.Red;
                }
                else if (z.Ruta != row.Cells[4].Value.ToString())
                {
                    row.Cells[4].Style.BackColor = System.Drawing.Color.Red;
                }
                else if (z.Unidad != row.Cells[5].Value.ToString())
                {
                    row.Cells[5].Style.BackColor = System.Drawing.Color.Red;
                }
                else if (z.Servicio != row.Cells[6].Value.ToString())
                {
                    row.Cells[6].Style.BackColor = System.Drawing.Color.Red;
                }
                else if (z.Operador != row.Cells[7].Value.ToString())
                {
                    row.Cells[7].Style.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Green;
                }


            }
        }

        private void ExportarExcelConciliado()
        {
            try
            {
                using (var slDocument = new SLDocument())
                {

                    SLStyle style5 = slDocument.CreateStyle();
                    style5.SetFont("Arial", 16);

                    int column = 1;
                    foreach (DataGridViewColumn col in this.dgrid_rol.Columns)
                    {
                        if (col.Index > 0)
                        {
                            slDocument.SetCellValue(1, column, col.HeaderText.ToString());
                            column++;
                        }
                    }

                    for (int row = 2; row < this.dgrid_rol.Rows.Count; row++)
                    {
                        for (int col = 1; col < this.dgrid_rol.Columns.Count; col++)
                        {
                            slDocument.SetCellValue(row, col, this.dgrid_rol.Rows[row].Cells[col].Value.ToString());
                            style5.Fill.SetPattern(PatternValues.LightTrellis, SLThemeColorIndexValues.Dark1Color, this.dgrid_rol.Rows[row].Cells[col].Style.BackColor);
                            slDocument.SetCellStyle(this.dgrid_rol.Rows[row].Cells[col].ToString(), style5);

                        }
                    }

                    var outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\output.xlsx";
                    slDocument.SaveAs(outputFile);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ExportarExcelConciliado();
        }
    }
    }



