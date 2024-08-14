
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.RH.CAsistencia
{
    public partial class VAsistencia : Form
    {
        public VAsistencia()
        {
            InitializeComponent();
        }

        private void GenerarAsistencia()
        {
            this.dgrid_asistencia.DataSource = null;
            this.dgrid_asistencia.Rows.Clear();
            this.dgrid_asistencia.Columns.Clear();
            this.dgrid_asistencia.Refresh();

            var finicial = this.dtm_finicial.Value.ToString("yyyy-MM-dd");
            var ffinal = this.dtm_ffinal.Value.ToString("yyyy-MM-dd");

            SqlConnection conn = new SqlConnection("Data Source=192.168.1.213\\COMPAC;" + "Initial Catalog=IVMS;" + "User ID=sa;" + "Password=compac;");
            SqlDataReader dr;
            try
            {

                using (conn)
                {
                    conn.Open();
                    using (SqlCommand sql_cmnd = new SqlCommand("ListaAsistencia", conn))
                    {
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                        sql_cmnd.Parameters.AddWithValue("@FECHAINICIAL", SqlDbType.DateTime).Value = finicial;
                        sql_cmnd.Parameters.AddWithValue("@FECHAFINAL", SqlDbType.DateTime).Value = ffinal;
                        SqlDataAdapter adapter = new SqlDataAdapter(sql_cmnd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        this.dgrid_asistencia.DataSource = dataTable;
                        conn.Close();
                    }
                }

                this.dgrid_asistencia.Columns[0].Visible = false;
                this.dgrid_asistencia.Columns[2].Visible = false;


            }
            catch (Exception exp)
            {
                Console.Write(exp.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            GenerarAsistencia();
        }

        private void VAsistencia_Load(object sender, EventArgs e)
        {
            this.dgrid_asistencia.EnableHeadersVisualStyles = false;
            this.dgrid_asistencia.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_asistencia.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_asistencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Text = "Asistencia Diaria";

        }
    }
}
