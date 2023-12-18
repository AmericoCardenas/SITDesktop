using GMap.NET;
using Newtonsoft.Json;
using RestSharp;
using SIT.Models;
using SIT.Views.Catalogos.CProveedores;
using SIT.Views.Catalogos.CUnidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SIT.Views.Catalogos
{
    public partial class VUnidades : Form
    {
        public VUnidades(Usuarios us)
        {
            InitializeComponent();
            this._uslog = us;
            this.dgrid_unidades.EnableHeadersVisualStyles = false;
            this.dgrid_unidades.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_unidades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_unidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        SITEntities db = new SITEntities();
        Usuarios _uslog;
        int IdUnidad = 0;

        public void UnidadesSamsara()
        {
            var options = new RestClientOptions("https://api.samsara.com/fleet/vehicles");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("authorization", "Bearer samsara_api_zKxBrvmkjHiJUn2s6Ia9MJQGojo8lG");
            var response =  client.Get(request);

            Root root = JsonConvert.DeserializeObject<Root>(response.Content);
            this.dgrid_unidades.Columns.Add("Unidad", "Unidad");
            this.dgrid_unidades.Columns.Add("Serial", "Serial");
            this.dgrid_unidades.Columns.Add("SerialCamara", "SerialCamara");
            this.dgrid_unidades.Columns.Add("Notas", "Notas");


            foreach (Datum datum in root.data)
            {
                this.dgrid_unidades.Rows.Add(datum.name, datum.serial, datum.cameraSerial, datum.notes);
            }
            // Acceder a los datos del objeto deserializado



        }

        private void Unidades_Load(object sender, EventArgs e)
        {
            CargarUnidades();
        }

        public void CargarUnidades()
        {
            IdUnidad = 0;
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            var x = from n in db.Unidades
                    join m in db.MotoresUnidades on n.IdMotor equals m.IdMotor
                    join mod in db.ModelosUnidades on n.IdModelo equals mod.IdModelo
                    select new
                    {
                        n.IdUnidad,
                        n.Economico,
                        n.Placa,
                        n.NSerie,
                        m.Motor,
                        mod.Modelo,
                        n.Color,
                        n.Pasajeros,
                        n.RendReq
                    };
            this.dgrid_unidades.DataSource = x.ToList();
            this.dgrid_unidades.Columns[0].Visible = false;
            this.dgrid_unidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void AgregarUnidad() {
            AEUnidad frm = new AEUnidad(this);
            frm.IdUnidad = IdUnidad;
            frm.IdUsuario = _uslog.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarUnidad();
        }

        private void CargarxFiltro()
        {
            var filtro = this.cmb_filtro.Text;

            if (this.txt_filtro.Text == "")
            {
                CargarUnidades();
            }
            else
            {
                if (filtro == "Economico")
                {
                    try
                    {
                        var x = from n in db.Unidades
                                join m in db.MotoresUnidades on n.IdMotor equals m.IdMotor
                                join mod in db.ModelosUnidades on n.IdModelo equals mod.IdModelo
                                where n.Economico.Contains(filtro)
                                select new
                                {
                                    n.IdUnidad,
                                    n.Economico,
                                    n.Placa,
                                    n.NSerie,
                                    m.Motor,
                                    mod.Modelo,
                                    n.Color,
                                    n.Pasajeros,
                                    n.RendReq
                                };
                        this.dgrid_unidades.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "Modelo")
                {
                    try
                    {
                        var x = from n in db.Unidades
                                join m in db.MotoresUnidades on n.IdMotor equals m.IdMotor
                                join mod in db.ModelosUnidades on n.IdModelo equals mod.IdModelo
                                where mod.Modelo.Contains(filtro)
                                select new
                                {
                                    n.IdUnidad,
                                    n.Economico,
                                    n.Placa,
                                    n.NSerie,
                                    m.Motor,
                                    mod.Modelo,
                                    n.Color,
                                    n.Pasajeros,
                                    n.RendReq
                                };
                        this.dgrid_unidades.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }


            }
            this.dgrid_unidades.Columns[0].Visible = false;
            this.dgrid_unidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void dgrid_unidades_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_unidades.CurrentCell.RowIndex != -1)
                {
                    IdUnidad = Convert.ToInt32(this.dgrid_unidades.CurrentRow.Cells[0].Value);
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
