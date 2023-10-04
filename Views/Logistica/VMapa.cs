using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using Newtonsoft.Json;
using RestSharp;
using SIT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using SIT.Properties;
using DocumentFormat.OpenXml.Presentation;

namespace SIT.Views.Logistica
{
    public partial class VMapa : Form
    {
        public VMapa()
        {
            InitializeComponent();
        }

        GMapOverlay markersOverlay;

        private void ObtenerPosicionUnidades()
        {
            var options = new RestClientOptions("https://api.samsara.com/fleet/vehicles/locations");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("authorization", "Bearer samsara_api_zKxBrvmkjHiJUn2s6Ia9MJQGojo8lG");
            var response =  client.Get(request);
            RootObject deserializedData = JsonConvert.DeserializeObject<RootObject>(response.Content);

            MarkerTooltipMode mode = MarkerTooltipMode.Always;

            Bitmap bmpmark = Resources.autobus;
            Bitmap resized = new Bitmap(bmpmark, new Size(32, 32));

            foreach (var dataItem in deserializedData.data)
            {

                //this.gMapControl1.Position = new PointLatLng(dataItem.location.latitude, dataItem.location.longitude);
                markersOverlay = new GMapOverlay(dataItem.name.ToString());
                GMapMarker marker = new GMarkerGoogle(new PointLatLng(dataItem.location.latitude, dataItem.location.longitude), resized);
                marker.ToolTipText = dataItem.name.ToString();
                marker.ToolTipMode = mode;
                markersOverlay.Markers.Add(marker);
                this.gMapControl1.Overlays.Add(markersOverlay);

            }


        }

        private void VMapa_Load(object sender, EventArgs e)
        {
            
            this.gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            this.gMapControl1.MinZoom = 5;
            this.gMapControl1.MaxZoom = 18;
            this.gMapControl1.Zoom = 10;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            ObtenerPosicionUnidades();
            tmr.Start();


        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            markersOverlay.Markers.Clear();
            this.gMapControl1.Refresh();
            ObtenerPosicionUnidades();
        }
    }
}
