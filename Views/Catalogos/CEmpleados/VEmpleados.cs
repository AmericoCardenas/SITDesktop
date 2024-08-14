using DocumentFormat.OpenXml.Vml.Office;
using GMap.NET;
using RestSharp;
using SIT.Views.Catalogos.CCuentasBancos;
using SIT.Views.Catalogos.CEmpleados;
using SIT.Views.Catalogos.CProductosAlmacen;
using SIT.Views.RH.CArticulos;
using SIT.Views.RH.CAsistencia;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace SIT.Views.Catalogos
{
    public partial class VEmpleados : Form
    {
        SITEntities db = new SITEntities();
        Trabajadores trabajadores = new Trabajadores();
        DatosNominaEmpleados datnom = new DatosNominaEmpleados();  
        DomicilioEmpleados domemp = new DomicilioEmpleados();
       
        
        public VEmpleados(Usuarios usuarios)
        {
            InitializeComponent();
            this.uslog = usuarios;
        }

        private string rutarchivo;
        public string motivobaja;
        public DateTime fbaja;
        private int idbitad;
        private DataTable dataTable;
        Usuarios uslog;
        int idEmpleado = 0;

        private void ImportarTrabajadores()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutarchivo = openFileDialog.FileName;
            }

            using (SLDocument sl = new SLDocument(rutarchivo))
            {
                SLWorksheetStatistics stats = sl.GetWorksheetStatistics();

                dataTable = new DataTable();

                // Leer los datos de las celdas y agregar columnas al DataTable
                for (int col = 1; col <= stats.NumberOfColumns; col++)
                {
                    string columnName = sl.GetCellValueAsString(1, col);
                    dataTable.Columns.Add(columnName);
                }

                // Leer los datos de las filas y agregarlas al DataTable
                for (int row = 2; row <= stats.NumberOfRows; row++)
                {
                    DataRow dataRow = dataTable.NewRow();

                    for (int col = 1; col <= stats.NumberOfColumns; col++)
                    {
                        dataRow[col - 1] = sl.GetCellValueAsString(row, col);
                    }

                    dataTable.Rows.Add(dataRow);
                }
            }

            foreach (DataRow row in dataTable.Rows)
            {


                idbitad = Convert.ToInt32(row["Empleado Id"]);


                trabajadores.IdBitad = idbitad;

                trabajadores.NombreCompleto = row["NOMBRE"].ToString();
                if (row["PUESTO"].ToString() == "OPERADOR")
                {
                    trabajadores.IdPuesto = 2;
                }
                else if (row["PUESTO"].ToString() == "ADMINISTRATIVO")
                {
                    trabajadores.IdPuesto = 1;
                }
                trabajadores.IdEstatus = 1;

                var idbitad2 = (from x in db.Trabajadores
                                where x.IdBitad == idbitad
                                select new { x.IdBitad }).FirstOrDefault();


                if (idbitad2!=null)
                {
                    //trabajadores = db.Trabajadores.Where(x => x.IdBitad == idbitad).FirstOrDefault();
                    //db.Entry(trabajadores).State = EntityState.Modified;
                    //db.SaveChanges();

                }
                else if(idbitad2 == null)
                {
                    db.Trabajadores.Add(trabajadores);
                    db.SaveChanges();
                }



                datnom.IdBitad = Convert.ToInt32(row["Empleado Id"]);
                datnom.Banco = row["BANCO"].ToString();
                datnom.Cuenta = row["CUENTA"].ToString();
                datnom.Tarjeta = row["NO.TARJETA"].ToString();
                datnom.MetodoN1 = row["MÉTODO DE N1"].ToString();
                datnom.MetodoN2 = row["MÉTODO DE N2"].ToString();

                var idbitad3 = (from x in db.DatosNominaEmpleados
                                where x.IdBitad == idbitad
                                select new { x.IdBitad }).FirstOrDefault();

                if (idbitad3 != null)
                {
                    //datnom = db.DatosNominaEmpleados.Where(x => x.IdBitad == idbitad).FirstOrDefault();
                    //db.Entry(datnom).State = EntityState.Modified;
                    //db.SaveChanges();

                }
                else
                {
                    db.DatosNominaEmpleados.Add(datnom);
                    db.SaveChanges();
                }


                //DOMICILIO EMPLEADOS
                domemp.IdBitad = Convert.ToInt32(row["Empleado Id"]);
                domemp.Calle = row["CALLE"].ToString();
                domemp.NoInt = row["NO.INT"].ToString();
                domemp.Colonia = row["COLONIA"].ToString();
                domemp.Municipio = row["MUNCIPIO"].ToString();
                domemp.Estado = row["ESTADO"].ToString();

                var idbitad4 = (from x in db.DomicilioEmpleados
                                where x.IdBitad == idbitad
                                select new { x.IdBitad }).FirstOrDefault();


                if (idbitad4 != null)
                {
                    //domemp = db.DomicilioEmpleados.Where(x => x.IdBitad == idbitad).FirstOrDefault();
                    //db.Entry(domemp).State = EntityState.Modified;
                }
                else
                {
                    db.DomicilioEmpleados.Add(domemp);
                    db.SaveChanges();
                }




            }

            MessageBox.Show("Empleados importados exitosamente");
            CargarEmpleados(1);
        }

        public void CargarEmpleados(int idestatus)
        {
            idEmpleado = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var empleados = from e in db.Trabajadores
                           join p in db.Puestos on e.IdPuesto equals p.IdPuesto
                           where e.IdEstatus==idestatus
                           select new
                           {
                               IdEmpleado = e.IdEmpleado,
                               Nombre = e.NombreCompleto,
                               Puesto = p.Puesto
                           };
            this.dgrid_empleados.DataSource = empleados.ToList();
            this.dgrid_empleados.Columns[0].Visible = false;
            this.dgrid_empleados.EnableHeadersVisualStyles = false;
            this.dgrid_empleados.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgrid_empleados.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgrid_empleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_empleados.Columns)
            {
                if (col.Index > 0 && col.Visible==true)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }


        private void btn_excel_Click(object sender, EventArgs e)
        {
            //ImportarTrabajadores();
        }

        private void VEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados(1);
            CargarFiltros();
        }

        private void dgrid_empleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgrid_empleados.CurrentCell != null && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                this.dgrid_empleados.CurrentRow.Selected = true;
                ResumenEmpleado frm = new ResumenEmpleado(this);
                frm.idempleado = Convert.ToInt32(this.dgrid_empleados.CurrentRow.Cells["IdEmpleado"].Value);
                frm.nombre_empleado = this.dgrid_empleados.CurrentRow.Cells["Nombre"].Value.ToString();
                frm.puesto = this.dgrid_empleados.CurrentRow.Cells["Puesto"].Value.ToString();
                this.Enabled = false;
                frm.uslog = this.uslog;
                frm.Show();
            }
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string txt_filter = this.txt_filtro.Text;
                if (txt_filter != "")
                {
                    var empleados = from t in db.Trabajadores
                                     join p in db.Puestos on t.IdPuesto equals p.IdPuesto
                                     where t.NombreCompleto.Contains(txt_filter)
                                     orderby t.IdBitad ascending
                                    where t.IdEstatus==1
                                     select new
                                     {
                                         IdEmpleado = t.IdEmpleado,
                                         Nombre = t.NombreCompleto,
                                         Puesto = p.Puesto
                                     };
                    this.dgrid_empleados.DataSource = empleados.ToList();
                    this.dgrid_empleados.Columns[0].Visible = false;

                }
                else
                {
                    CargarEmpleados(1);
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void AsignarIdSamsara()
        {

        }
        List<string> lst = new List<string>();

        private void DesactivarConductoresSamsara()
        {

            //this.lst.Add("21746821");
            //this.lst.Add("18960770");
            //this.lst.Add("7315980");
            //this.lst.Add("36526833");
            //this.lst.Add("18661137");
            //this.lst.Add("43132560");
            //this.lst.Add("6930149");
            //this.lst.Add("32463173");
            //this.lst.Add("19778745");
            //this.lst.Add("24129651");
            //this.lst.Add("31197668");
            //this.lst.Add("32030647");
            //this.lst.Add("6930159");
            //this.lst.Add("35982399");
            //this.lst.Add("23836239");
            //this.lst.Add("7485896");
            //this.lst.Add("4556777");
            //this.lst.Add("38915274");
            //this.lst.Add("20226736");
            //this.lst.Add("20202801");
            //this.lst.Add("22391208");
            //this.lst.Add("15348456");
            //this.lst.Add("7751956");
            //this.lst.Add("24579410");
            //this.lst.Add("19180166");
            //this.lst.Add("34859881");
            //this.lst.Add("38417294");
            //this.lst.Add("7315534");
            //this.lst.Add("22340962");
            //this.lst.Add("39815602");
            //this.lst.Add("9674789");
            //this.lst.Add("16760699");
            //this.lst.Add("38759633");
            //this.lst.Add("27316029");
            //this.lst.Add("30031681");
            //this.lst.Add("25183709");
            //this.lst.Add("22612235");
            //this.lst.Add("30648634");
            //this.lst.Add("8105723");
            //this.lst.Add("21405156");
            //this.lst.Add("29853223");
            //this.lst.Add("16761986");
            //this.lst.Add("7315452");
            //this.lst.Add("23202614");
            //this.lst.Add("6930111");
            //this.lst.Add("4562092");
            //this.lst.Add("6930144");
            //this.lst.Add("43881396");
            //this.lst.Add("21746863");
            //this.lst.Add("27845626");
            //this.lst.Add("20168885");
            //this.lst.Add("9788220");
            //this.lst.Add("18415696");
            //this.lst.Add("26355873");
            //this.lst.Add("27068315");
            //this.lst.Add("7751925");
            //this.lst.Add("21976071");
            //this.lst.Add("20489824");
            //this.lst.Add("19522002");
            //this.lst.Add("38417299");
            //this.lst.Add("27984104");
            //this.lst.Add("33545748");
            //this.lst.Add("28939736");
            //this.lst.Add("30186567");

            //foreach(string a in lst)
            //{
            //    var options = new RestClientOptions("https://api.samsara.com/fleet/drivers/"+a);
            //    var client = new RestClient(options);
            //    var request = new RestRequest("");
            //    request.AddHeader("accept", "application/json");
            //    request.AddHeader("authorization", "Bearer samsara_api_zKxBrvmkjHiJUn2s6Ia9MJQGojo8lG");
            //    request.AddJsonBody("{\"usDriverRulesetOverride\":{\"cycle\":\"USA Property (8/70)\",\"restart\":\"34-hour Restart\",\"restbreak\":\"Property (off-duty/sleeper)\",\"usStateToOverride\":\"\"},\"driverActivationStatus\":\"deactivated\"}", false);
            //    var response =  client.PatchAsync(request);
            //    Debug.WriteLine(response);
            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AEEmpleado frm = new AEEmpleado(this);
            frm.uslog = this.uslog;
            frm.IdEmpleado= this.idEmpleado;
            this.Enabled = false;
            frm.Show();
        }

        private async Task insertarop()
        {
            List <string> operadores = db.Trabajadores.Where(x => x.IdPuesto == 2).Select(x => x.NombreCompleto).ToList();
            foreach(string a in operadores)
            {

                string n =a.Trim();
                var options = new RestClientOptions("https://api.samsara.com/fleet/drivers");
                var client = new RestClient(options);
                var request = new RestRequest("");
                request.AddHeader("accept", "application/json");
                request.AddHeader("authorization", "Bearer samsara_api_zKxBrvmkjHiJUn2s6Ia9MJQGojo8lG");
                request.AddJsonBody("{\"tagIds\":[\"4217137\"],\"usDriverRulesetOverride\":{\"cycle\":\"USA Property (8/70)\",\"restart\":\"34-hour Restart\",\"restbreak\":\"Property (off-duty/sleeper)\",\"usStateToOverride\":\"\"},\"name\":\""+a+"\",\"password\":\"123456\",\"username\":\""+n.Replace(" ","")+"\"}", false);
                var response = await client.PostAsync(request);

                Console.WriteLine("{0}", response.Content);

            }
        }

        private void dgrid_empleados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_empleados.CurrentCell.RowIndex != -1)
                {
                    idEmpleado = Convert.ToInt32(this.dgrid_empleados.CurrentRow.Cells[0].Value);
                }
                else
                {
                    idEmpleado = 0;
                    this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el empleado seleccionada", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarEmpleado();

            }
            else
            {
                // Do something
            }
        }

        private void CancelarEmpleado()
        {

            VCuestBajEmp frm = new VCuestBajEmp(this);
            frm.idemp = idEmpleado;
            frm.uslog = this.uslog;
            this.Enabled = false;
            frm.Show();


        }

        private void btn_art_Click(object sender, EventArgs e)
        {
            VArticulos frm = new VArticulos(this);
            this.Enabled = false;
            frm.uslog = this.uslog;
            frm.Show();

        }

        private void btn_asistencia_Click(object sender, EventArgs e)
        {
            VAsistencia frm = new VAsistencia();
            //this.Enabled = false;
            frm.Show();
        }

        private void chk_inactivo_emp_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chk_inactivo_emp.Checked)
            {
                CargarEmpleados(2);

            }
            else
            {
                CargarEmpleados(1);
            }
        }
    }
}
