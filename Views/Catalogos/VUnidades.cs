using Newtonsoft.Json;
using RestSharp;
using SIT.Models;
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
        public VUnidades()
        {
            InitializeComponent();
            this.dgrid_unidades.EnableHeadersVisualStyles = false;
            this.dgrid_unidades.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_unidades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_unidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

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
            UnidadesSamsara();
        }


    }
}
