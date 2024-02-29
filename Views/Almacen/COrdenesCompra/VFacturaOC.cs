using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Almacen.COrdenesCompra
{
    public partial class VFacturaOC : Form
    {
        public VFacturaOC(Form frm)
        {
            InitializeComponent();
            this._frm = frm;
        }

        Form _frm;
        public int idOCompra;
        VOrdenesCompra _vordenesCompra;
        FacturasOC fact = new FacturasOC();
        OpenFileDialog op = new OpenFileDialog();
        SITEntities db = new SITEntities(); 
        string ruta = "\\\\192.168.1.213\\DocumentosSIT\\FacturasOC\\";
        string filename_factura,rfactura = string.Empty;
        string filename_xml,rxml = string.Empty;
        

        private void CargarFactura()
        {
            fact = db.FacturasOC.Where(x => x.IdOCompra == idOCompra).FirstOrDefault();
            if (fact != null)
            {
                this.txt_folio.Text = fact.FolioFactura;
                this.filename_factura = fact.FileNFactura;
                this.filename_xml = fact.FileNXml;
                this.btn_verfactura.Enabled = true;
                this.btn_cargarfactura.BackColor = Color.Green;
                this.btn_cargarxml.BackColor = Color.Green;
                this.btn_verxml.Enabled = true;
            }
            else
            {
                this.btn_verfactura.Enabled = false;
                this.btn_verxml.Enabled = false;
                fact=new FacturasOC();
            }

            this.Text = "Factura / XML OC #" + idOCompra;
        }

        private void AgregarFacturaXml()
        {
            if (filename_factura == string.Empty)
            {
                MessageBox.Show("Favor de seleccionar la factura");
            }
            else if(filename_xml==string.Empty)
            {
                MessageBox.Show("Favor de seleccionar el xml");
            }
            else if (this.txt_folio.Text == string.Empty || this.txt_folio.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el folio de la factura");

            }
            else
            {

                fact.Ruta = ruta;
                fact.IdOCompra = idOCompra;
                fact.FileNFactura = filename_factura;
                fact.FileNXml = filename_xml;
                fact.FolioFactura = this.txt_folio.Text;
                fact.Fecha = DateTime.Now;


                if (fact != null && fact.IdFactura!=0)
                {
                    if (rfactura!=string.Empty)
                    {
                        var FName = rfactura.Split('\\');
                        if (File.Exists( ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(rfactura, ruta + FName[FName.Length - 1]);

                        }
                    }

                    if(rxml!=string.Empty)
                    {
                        var FName = rxml.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(rxml, ruta + FName[FName.Length - 1]);
                        }
                    }

                    db.Entry(fact).State = EntityState.Modified;

                }
                else
                {
                    var FName = rxml.Split('\\');
                    if (File.Exists(ruta + FName[FName.Length - 1]))
                    {

                    }
                    else
                    {
                        File.Copy(rxml, ruta + FName[FName.Length - 1]);
                    }

                    FName = rfactura.Split('\\');
                    if (File.Exists(ruta + FName[FName.Length - 1]))
                    {

                    }
                    else
                    {
                        File.Copy(rfactura, ruta + FName[FName.Length - 1]);
                    }

                    db.FacturasOC.Add(fact);
                }

                db.SaveChanges();
                MessageBox.Show("Se ha cargado la factura y el xml exitosamente");
                this.Close();
                   
            }
        }

        private void btn_cargarfactura_Click(object sender, EventArgs e)
        {
            op.Multiselect = true;
            op.Filter = "|*.pdf;";
            op.ShowDialog();
            filename_factura = op.SafeFileName;
            rfactura = op.FileName;
            this.btn_cargarfactura.BackColor = System.Drawing.Color.Green;
        }

        private void btn_cargarxml_Click(object sender, EventArgs e)
        {
            op.Multiselect = true;
            op.Filter = "|*.xml;";
            op.ShowDialog();
            filename_xml = op.SafeFileName;
            rxml = op.FileName;
            this.btn_cargarxml.BackColor = System.Drawing.Color.Green;
        }

        private void VFacturaOC_Load(object sender, EventArgs e)
        {
            CargarFactura();
        }

        private void btn_verfactura_Click(object sender, EventArgs e)
        {
            if (this.filename_factura != string.Empty)
            {
                System.Diagnostics.Process.Start(ruta+filename_factura);
            }
        }

        private void btn_verxml_Click(object sender, EventArgs e)
        {
            if (this.filename_xml != string.Empty)
            {
                System.Diagnostics.Process.Start(ruta + filename_xml);
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarFacturaXml();
        }
    }
}
