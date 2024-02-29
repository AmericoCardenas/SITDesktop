using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Almacen.COrdenesCompra
{
    public partial class VCotizacionGlobal : Form
    {
        public VCotizacionGlobal(VOrdenesCompra vordenes)
        {
            InitializeComponent();
            this._vordenes = vordenes;
        }

        VOrdenesCompra _vordenes;
        SITEntities db = new SITEntities();
        public Usuarios uslog;
        public List<CotPendientes> lst_cot;

        private void VCotizacionGlobal_Load(object sender, EventArgs e)
        {
            CargarCotizacion();
        }

        private void CargarCotizacion()
        {
            this.dgrid_cotpend.DataSource=this.lst_cot.ToList();
            this.lbl_fecha.Text = "Fecha: " + DateTime.Now.ToString();

            var nombrecompleto = this.db.Trabajadores.Where(x => x.IdEmpleado == this.uslog.IdEmpleado).Select(x => x.NombreCompleto).First();
            this.lbl_usuario.Text = "Elaborado por: " + nombrecompleto;

            this.lbl_proveedor.Text = this.lst_cot.Select(x=>x.Proveedor).First();

            var subtotal = this.lst_cot.Sum(x => x.Subtotal);
            this.lbl_subtotal.Text = "Subtotal: $" + subtotal;

            var iva = Convert.ToDouble(subtotal * 0.16);
            this.lbl_iva.Text = "IVA: $" + iva;

            var total = Convert.ToDouble(subtotal * 1.16);
            this.lbl_total.Text = "Total $: " + total;

            this.dgrid_cotpend.Columns[1].Visible = false;
            this.dgrid_cotpend.Columns[2].Visible = false;

            this.dgrid_cotpend.Columns[3].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;

        }

        private void VCotizacionGlobal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._vordenes.Enabled = true;

        }

        private void btn_screen_Click(object sender, EventArgs e)
        {
            TomarScreenCotizacion();
        }

        private void TomarScreenCotizacion()
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            // Copy the contents of the screen to the bitmap
            graphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);

            // Save the bitmap to a file (You can change the path and file format as needed)
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\cot.png";
            bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

            // Dispose of objects
            graphics.Dispose();
            bitmap.Dispose();

            MessageBox.Show("Captura guardada en: " + filePath);
        }
    }
}
