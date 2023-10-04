using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using RestSharp;
using SIT.Models;
using SIT.Views.Logistica.CRutas;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace SIT.Views.Catalogos
{
    public partial class VRutas : Form
    {
        SITEntities db = new SITEntities();
        Rutas rutas = new Rutas();
        Usuarios _uslog;
        int IdRuta = 0;


        public VRutas(Usuarios usuariolog)
        {
           
            InitializeComponent();
            CargarUnidadesSamsara();
            CargarOperadores();
            CargarClientes();
            CargarTurnos();
            CargarServicios();
            CargarRutas();
            this._uslog = usuariolog;
            this.btn_delete.Visible=false;
        }

        private void VRutas_Load(object sender, EventArgs e)
        {
            this.dgrid_rutas.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            this.txt_hora.MaxLength = 5;
            this.dgrid_rutas.Columns["IdRuta"].Visible=false;
            this.dgrid_rutas.Columns["Estatus"].Visible = false;
            this.txt_codbitad.Text = "0";
            this.txt_pentrada.Text="0";
            this.txt_psalida.Text="0";
        }

        public void CargarUnidadesSamsara()
        {
            var options = new RestClientOptions("https://api.samsara.com/fleet/vehicles");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("authorization", "Bearer samsara_api_zKxBrvmkjHiJUn2s6Ia9MJQGojo8lG");
            var response =  client.Get(request);

            Root root = JsonConvert.DeserializeObject<Root>(response.Content);

            this.cmb_unidad.DisplayMember = "name";
            this.cmb_unidad.ValueMember = "name";

            foreach (Datum datum in root.data)
            {
                this.cmb_unidad.Items.Add(datum.name);
            }
            // Acceder a los datos del objeto deserializado
        }

        private void CargarOperadores()
        {
            this.cmb_operador.DataSource = db.Trabajadores.Where(x => x.IdPuesto == 2).ToList<Trabajadores>();
            this.cmb_operador.DisplayMember = "NombreCompleto";
            this.cmb_operador.ValueMember = "IdEmpleado";
        }

        private void CargarClientes()
        {
            this.cmb_cliente.DataSource = db.Clientes.ToList<Clientes>();
            this.cmb_cliente.DisplayMember = "RazonSocial";
            this.cmb_cliente.ValueMember = "IdCliente";
        }

        private void CargarTurnos()
        {
            this.cmb_turno.DataSource = db.Turnos.ToList<Turnos>();
            this.cmb_turno.DisplayMember = "Turno";
            this.cmb_turno.ValueMember = "IdTurno";

        }

        private void CargarServicios()
        {
            this.cmb_servicio.DataSource = db.Servicios.ToList<Servicios>();
            this.cmb_servicio.DisplayMember = "Servicio";
            this.cmb_servicio.ValueMember = "IdServicio";
        }

        public void CargarRutas()
        {
            try
            {
                DateTime fecha1 = this.dtm_inicio.Value;
                DateTime fecha2 = this.dtm_final.Value;

                var rutas2 = from r in db.Rutas
                            join c in db.Clientes on r.IdCliente equals c.IdCliente
                            join p in db.Productos on r.IdProducto equals p.IdProducto
                            join s in db.Servicios on r.IdTipo equals s.IdServicio
                            join tu in db.Turnos on r.IdTurno equals tu.IdTurno
                            join tr in db.Trabajadores on r.IdEmpleado equals tr.IdEmpleado
                             where r.Fecha >= fecha1.Date  && r.Fecha <= fecha2.Date && r.IdEstatus != 3
                             select new
                            {
                                IdRuta = r.IdRuta,
                                 CBitad = r.CodigoBitad,
                                 Fecha = r.Fecha,
                                 Hora = r.Hora,
                                Cliente = c.RazonSocial,
                                Ruta = p.NombreProducto,
                                Servicio = s.Servicio,
                                Turno = tu.Turno,
                                Operador = tr.NombreCompleto,
                                Unidad = r.Unidad,
                                PEntrada = r.PEntrada,
                                PSalida = r.PSalida,
                                Estatus = r.IdEstatus
                            };

                this.dgrid_rutas.DataSource = rutas2.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt_hora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ':')
            {
                e.Handled = true; // Prevent the character from being entered
            }

        }

        private void cmb_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.cmb_ruta.DataSource = null;

                int idcliente = Convert.ToInt32(this.cmb_cliente.SelectedValue);
                var rfc_cliente = db.Clientes.FirstOrDefault(x => x.IdCliente == idcliente).Rfc;

                var rutas_cliente = from p in db.Productos
                                    where p.RfcCliente == rfc_cliente.ToString()
                                    select p;

                this.cmb_ruta.DataSource = rutas_cliente.ToList();
                this.cmb_ruta.DisplayMember = "NombreProducto";
                this.cmb_ruta.ValueMember = "IdProducto";
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        private void AgregarRuta()
        {
            if(this.cmb_unidad.Text == "")
            {
                MessageBox.Show("Favor de seleccionar la unidad");
            }
            else if (this.cmb_operador.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el operador");
            }
            else if (this.cmb_cliente.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el cliente");
            }
            else if (this.cmb_ruta.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar la ruta");
            }
            else if (this.cmb_servicio.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el servicio");
            }
            else if (this.cmb_turno.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el turno");
            }
            else if (this.txt_hora.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar la hora");
            }
            else
            {
                rutas.Fecha = this.dtm_fecha.Value;
                rutas.Hora = this.txt_hora.Text.ToString();
                rutas.IdCliente = Convert.ToInt32(this.cmb_cliente.SelectedValue);
                rutas.IdProducto = Convert.ToInt32(this.cmb_ruta.SelectedValue);
                rutas.IdTipo = Convert.ToInt32(this.cmb_servicio.SelectedValue);
                rutas.IdTurno = Convert.ToInt32(this.cmb_turno.SelectedValue);
                rutas.IdEmpleado=Convert.ToInt32(this.cmb_operador.SelectedValue);
                rutas.Unidad =this.cmb_unidad.Text;
                rutas.CodigoBitad = this.txt_codbitad.Text;
                rutas.FechaCreacion = DateTime.Now.ToString("dd-MM-yyyy");
                rutas.UsuarioCreacion = Convert.ToInt32(this._uslog.IdUsuario);
                rutas.PEntrada = Convert.ToInt32(this.txt_pentrada.Text);
                rutas.PSalida = Convert.ToInt32(this.txt_psalida.Text);
                rutas.IdEstatus = 1;

                if (IdRuta > 0)
                {
                    rutas.FechaModificacion = DateTime.Now.ToString("dd-MM-yyyy");
                    rutas.UsuarioModificacion = Convert.ToInt32(_uslog.IdUsuario);
                    db.Entry(rutas).State = EntityState.Modified;
                    MessageBox.Show("Ruta actualizado exitosamente");

                    this.btn_agregar.BackgroundImage = Properties.Resources.mas;
                    this.btn_agregar.BackgroundImageLayout = ImageLayout.Stretch;
                    this.btn_delete.Visible = false;


                }
                else
                {
                    db.Rutas.Add(rutas);
                    MessageBox.Show("Ruta agregada exitosamente");

                }

                db.SaveChanges();
                CargarRutas();
            }

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            AgregarRuta();
        }

        private void dgrid_rutas_Click(object sender, EventArgs e)
        {
            if (this.dgrid_rutas.CurrentCell.RowIndex != -1)
            {
                IdRuta = Convert.ToInt32(this.dgrid_rutas.CurrentRow.Cells["IdRuta"].Value);
                rutas = db.Rutas.Where(x => x.IdRuta == IdRuta).FirstOrDefault();
                this.cmb_unidad.Text = rutas.Unidad;
                this.cmb_operador.SelectedValue = rutas.IdEmpleado;
                this.cmb_cliente.SelectedValue = rutas.IdCliente;
                this.cmb_ruta.SelectedValue = rutas.IdProducto;
                this.cmb_servicio.SelectedValue = rutas.IdTipo;
                this.cmb_turno.SelectedValue= rutas.IdTurno;
                this.dtm_fecha.Value = rutas.Fecha.Value;
                this.txt_hora.Text = rutas.Hora;
                this.txt_codbitad.Text = rutas.CodigoBitad;
                this.txt_pentrada.Text = rutas.PEntrada.ToString();
                this.txt_psalida.Text = rutas.PSalida.ToString();

            }

            this.btn_agregar.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_agregar.BackgroundImageLayout = ImageLayout.Stretch;
            this.btn_delete.Visible = true;

        }

        private void CancelarRuta()
        {
            DialogResult result = MessageBox.Show("Desea cancelar la ruta seleccionada?", "Confirmación", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                if (IdRuta > 0)
                {
                    rutas.FechaCancelacion = DateTime.Now.ToString("dd-MM-yyyy");
                    rutas.UsuarioCancelacion = Convert.ToInt32(_uslog.IdUsuario);
                    rutas.IdEstatus = 3;
                    db.Entry(rutas).State = EntityState.Modified;
                    MessageBox.Show("Ruta cancelada exitosamente");

                }

                db.SaveChanges();
                CargarRutas();
                this.btn_delete.Visible = false;
                this.btn_agregar.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_agregar.BackgroundImageLayout = ImageLayout.Stretch;

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            CancelarRuta();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            CargarRutas();
        }

        private void ExportarExcel()
        {
            SLDocument sl = new SLDocument();
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            downloadPath = System.IO.Path.Combine(downloadPath, "Documents");

            // Set the header row
            for (int i = 0; i < this.dgrid_rutas.Columns.Count; i++)
            {
                if (this.dgrid_rutas.Columns[i].Name != "IdRuta" && this.dgrid_rutas.Columns[i].Name != "Estatus")
                {
                    sl.SetCellValue(1, i + 1, this.dgrid_rutas.Columns[i].HeaderText);
                    sl.SetCellStyle(1, i + 1, GetHeaderCellStyle(sl));

                }
            }

            // Set the data rows
            for (int i = 0; i < this.dgrid_rutas.Rows.Count; i++)
            {
                for (int j = 0; j < this.dgrid_rutas.Columns.Count; j++)
                {
                    if (this.dgrid_rutas.Columns[j].Name != "IdRuta" && this.dgrid_rutas.Columns[j].Name != "Estatus")
                    {
                        DataGridViewCell cell = this.dgrid_rutas.Rows[i].Cells[j];
                        if(cell.Value != null)
                        {
                            sl.SetCellValue(i + 2, j + 1, cell.Value.ToString());
                            sl.SetCellStyle(i + 2, j + 1, GetDataCellStyle(sl));

                        }
                        else
                        {
                            sl.SetCellValue(i + 2, j + 1,"");
                            sl.SetCellStyle(i + 2, j + 1, GetDataCellStyle(sl));

                        }
                    }
                }
            }

            sl.AutoFitColumn(1, stats.EndColumnIndex);

            // Save the Excel file
            sl.SaveAs(downloadPath+"\\Bitacora"+DateTime.Now.ToString("dd-MM-yyyy")+".xlsx");
            MessageBox.Show("Archivo exportado en " + downloadPath);

        }

        private SLStyle GetHeaderCellStyle(SLDocument sl)
        {
            SLStyle style = sl.CreateStyle();
            style.SetFontBold(true);
            style.Fill.SetPatternType(PatternValues.Solid);
            style.Fill.SetPatternForegroundColor(SLThemeColorIndexValues.Accent1Color, 0.35);
            style.Alignment.Horizontal = DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center;
            return style;
        }

        private SLStyle GetDataCellStyle(SLDocument sl)
        {
            SLStyle style = sl.CreateStyle();
            style.Alignment.Horizontal = DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left;
            return style;
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }


        private void dgrid_rutas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.dgrid_rutas.CurrentCell != null && e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    this.dgrid_rutas.CurrentRow.Selected = true;
                    this.dgrid_rutas.CurrentCell = this.dgrid_rutas.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    ContextMenuStrip menu = new ContextMenuStrip();
                    menu.Items.Add("OP-Localizado").Name = "OP-Localizado";
                    menu.Items.Add("Finalizar").Name = "Finalizar";

                    //Obtienes las coordenadas de la celda seleccionada. 
                    Rectangle coordenada = this.dgrid_rutas.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                    int anchoCelda = coordenada.Location.X; //Ancho de la localizacion de la celda
                    int altoCelda = coordenada.Location.Y;  //Alto de la localizacion de la celda

                    //Y para mostrar el menú lo haces de esta forma:  
                    int X = anchoCelda + this.dgrid_rutas.Location.X;
                    int Y = altoCelda + this.dgrid_rutas.Location.Y + 15;

                    menu.Show(this.dgrid_rutas, new Point(X, Y));

                    menu.ItemClicked -= OnContextMenuItem_Click;
                    menu.ItemClicked += OnContextMenuItem_Click;
                }

            }

        }

        private void OnContextMenuItem_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            var menuText = clickedItem.Text.ToString();
            IdRuta = Convert.ToInt32(this.dgrid_rutas.CurrentRow.Cells["IdRuta"].Value);


            switch (menuText)
            {
                case "OP-Localizado":

                    if (IdRuta > 0)
                    {
                        rutas.IdEstatus = 4;
                        rutas.FechaModificacion = DateTime.Now.ToString("dd-MM-yyyy");
                        rutas.UsuarioModificacion = Convert.ToInt32(_uslog.IdUsuario);
                        db.Entry(rutas).State = EntityState.Modified;

                    }
                    db.SaveChanges();
                    CargarRutas();
                    break;

                case "Finalizar":

                    if (IdRuta > 0)
                    {
                        rutas.IdEstatus = 2;
                        rutas.FechaModificacion = DateTime.Now.ToString("dd-MM-yyyy");
                        rutas.UsuarioModificacion = Convert.ToInt32(_uslog.IdUsuario);
                        db.Entry(rutas).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    CargarRutas();

                    break;

            }

        }

        private void dgrid_rutas_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int idestatus = Convert.ToInt32(this.dgrid_rutas.Rows[e.RowIndex].Cells["Estatus"].Value);
            if(idestatus == 4 )
            {
                this.dgrid_rutas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            else if(idestatus == 2 ) 
            {
                this.dgrid_rutas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void txt_pentrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

        private void txt_psalida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
            }
        }

        private void btn_bitacora_Click(object sender, EventArgs e)
        {
            VImportarBitacora frm = new VImportarBitacora(this._uslog);
            frm.Show();
            frm._frm = this;
            this.Enabled = false;

        }
    }
}
