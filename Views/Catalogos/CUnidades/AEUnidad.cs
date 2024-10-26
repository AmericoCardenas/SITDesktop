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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SIT.Views.Catalogos.CUnidades
{
    public partial class AEUnidad : Form
    {
        public AEUnidad(VUnidades vunidades)
        {
            InitializeComponent();
            this.frm = vunidades;
        }

        OpenFileDialog op = new OpenFileDialog();
        SITEntities db =  new SITEntities();
        Unidades unidades = new Unidades();
        VUnidades frm;
        public int IdUnidad;
        public int IdUsuario;
        string ruta = "\\\\192.168.1.213\\DocumentosSIT\\UnidadesTD\\";
        string filen_factura, filen_tcirculacion, filen_poliza, filen_arrend, filen_const, filen_refrend = string.Empty;
        string r_factura,r_tcirculacion, r_poliza, r_arrend,r_const,r_refrend = string.Empty;

        private void btn_seguro_Click(object sender, EventArgs e)
        {
            op.Multiselect = false;
            op.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op.ShowDialog();
            filen_poliza = op.SafeFileName;
            r_poliza = op.FileName;
            this.btn_seguro.BackColor = System.Drawing.Color.Green;
        }

        private void btn_arremdamiento_Click(object sender, EventArgs e)
        {
            op.Multiselect = false;
            op.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op.ShowDialog();
            filen_arrend = op.SafeFileName;
            r_arrend = op.FileName;
            this.btn_arremdamiento.BackColor = System.Drawing.Color.Green;
        }

        private void btn_constancia_Click(object sender, EventArgs e)
        {
            op.Multiselect = false;
            op.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op.ShowDialog();
            filen_const = op.SafeFileName;
            r_const = op.FileName;
            this.btn_constancia.BackColor = System.Drawing.Color.Green;

        }

        private void btn_refrendo_Click(object sender, EventArgs e)
        {
            op.Multiselect = false;
            op.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op.ShowDialog();
            filen_refrend = op.SafeFileName;
            r_refrend = op.FileName;
            this.btn_refrendo.BackColor = System.Drawing.Color.Green;

        }

        private void btn_circulacion_Click(object sender, EventArgs e)
        {
            op.Multiselect = false;
            op.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op.ShowDialog();
            filen_tcirculacion = op.SafeFileName;
            r_tcirculacion = op.FileName;
            this.btn_circulacion.BackColor = System.Drawing.Color.Green;

        }

        private void btn_verfactura_Click(object sender, EventArgs e)
        {
            VerArchivo(filen_factura);
        }

        private void btn_vtc_Click(object sender, EventArgs e)
        {
            VerArchivo(filen_tcirculacion);

        }

        private void btn_vpos_Click(object sender, EventArgs e)
        {
            VerArchivo(filen_poliza);

        }

        private void btn_varrend_Click(object sender, EventArgs e)
        {
            VerArchivo(filen_arrend);

        }

        private void btn_vconstancia_Click(object sender, EventArgs e)
        {
            VerArchivo(filen_const);

        }

        private void btn_vrefrendo_Click(object sender, EventArgs e)
        {
            VerArchivo(filen_refrend);

        }

        private void btn_factura_Click(object sender, EventArgs e)
        {
            op.Multiselect = false;
            op.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op.ShowDialog();
            filen_factura = op.SafeFileName;
            r_factura = op.FileName;
            this.btn_factura.BackColor = System.Drawing.Color.Green;

        }

        private void AEUnidad_Load(object sender, EventArgs e)
        {
            CargarTiposUnidad();
            CargarMotores();
            CargarModelos();
            CargarEstatus();

            if (IdUnidad != 0)
            {
                unidades = db.Unidades.Where(x => x.IdUnidad == IdUnidad).FirstOrDefault();
                this.txt_eco.Text = unidades.Economico;
                this.txt_nserie.Text = unidades.NSerie;
                this.txt_placa.Text = unidades.Placa;
                this.cmb_tipo.SelectedValue = unidades.IdTipo;
                this.cmb_motor.SelectedValue = unidades.IdMotor;
                this.txt_rendreq.Text = unidades.RendReq.ToString();
                this.cmb_estatus.SelectedValue = unidades.IdEstatus;
                this.txt_color.Text = unidades.Color;
                this.cmb_modelo.SelectedValue = unidades.IdModelo;
                this.txt_pasajeros.Text=unidades.Pasajeros.ToString();

                //FILENAMES
                if (unidades.FileFactura != null)
                {
                    this.filen_factura = unidades.FileFactura;
                    this.btn_factura.BackColor = Color.Green;
                }

                if(unidades.FileArrendamiento != null)
                {
                    this.filen_arrend = unidades.FileArrendamiento;
                    this.btn_arremdamiento.BackColor = Color.Green;
                }

                if (unidades.FileConstancia != null)
                {
                    this.filen_const = unidades.FileConstancia;
                    this.btn_constancia.BackColor = Color.Green;
                }

                if(unidades.FilePolizaSeguro!= null)
                {
                    this.filen_poliza = unidades.FilePolizaSeguro;
                    this.btn_seguro.BackColor = Color.Green;
                }

                if (unidades.FileRefrendo != null)
                {
                    this.filen_refrend = unidades.FileRefrendo;
                    this.btn_refrendo.BackColor = Color.Green;

                }

                if(unidades.FileTCirculacion != null)
                {
                    this.filen_tcirculacion = unidades.FileTCirculacion;
                    this.btn_circulacion.BackColor = Color.Green;

                }



                this.Text = "Editar "+unidades.Economico.ToString();
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void AgregarUnidad()
        {
            bool rend,pasajeros;
            Double rendreq;
            int pasaj;
            rend = Double.TryParse(this.txt_rendreq.Text, out rendreq);
            pasajeros = Int32.TryParse(this.txt_pasajeros.Text, out pasaj);

            if (this.txt_eco.Text == "" || this.txt_eco.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el economico");
                this.txt_eco.Focus();
            }
            else if (this.cmb_tipo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el tipo de unidad");
                this.cmb_tipo.Focus();
            }
            else if (this.txt_placa.Text == "" || this.txt_placa.Text.Trim().Length==0)
            {
                MessageBox.Show("Favor de introducir el numero de placa");
                this.txt_placa.Focus();
            }
            else if (this.txt_nserie.Text == "" || this.txt_nserie.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el numero de serie de la unidad");
                this.txt_nserie.Focus();
            }
            else if (this.cmb_motor.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el tipo de motor");
                this.cmb_motor.Focus();
            }
            else if (this.cmb_modelo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el modelo de la unidad");
                this.cmb_modelo.Focus();
            }
            else if (this.txt_rendreq.Text == "" || this.txt_rendreq.Text.Trim().Length == 0 || rend==false)
            {
                MessageBox.Show("Favor de introducir el rendimiento de la unidad");
                this.txt_rendreq.Focus();
            }
            else if (this.txt_color.Text == "" || this.txt_color.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el color de la unidad");
                this.txt_color.Focus();
            }
            else if (this.txt_pasajeros.Text == "" || this.txt_pasajeros.Text.Trim().Length == 0 || pasajeros == false)
            {
                MessageBox.Show("Favor de introducir la cantidad de pasajeros de la unidad");
                this.txt_pasajeros.Focus();
            }
            //else if (filen_arrend == string.Empty)
            //{
            //    MessageBox.Show("Favor de seleccionar el archivo de arrendamiento");
            //}
            //else if (filen_const == string.Empty)
            //{
            //    MessageBox.Show("Favor de seleccionar el archivo de constancia");
            //}
            //else if (filen_factura == string.Empty)
            //{
            //    MessageBox.Show("Favor de seleccionar el archivo de factura");
            //}
            //else if (filen_poliza == string.Empty)
            //{
            //    MessageBox.Show("Favor de seleccionar el archivo de poliza");
            //}
            //else if (filen_refrend == string.Empty)
            //{
            //    MessageBox.Show("Favor de seleccionar el archivo de refrendo");
            //}
            //else if (filen_tcirculacion == string.Empty)
            //{
            //    MessageBox.Show("Favor de seleccionar el archivo de tarjeta de circulación");
            //}
            else
            {
                unidades.Economico = this.txt_eco.Text.Trim().ToUpper();
                unidades.IdTipo = Convert.ToInt32(this.cmb_tipo.SelectedValue);
                unidades.Placa = this.txt_placa.Text.Trim().ToUpper();
                unidades.NSerie = this.txt_nserie.Text.Trim().ToUpper();
                unidades.IdMotor = Convert.ToInt32(this.cmb_motor.SelectedValue);
                unidades.RendReq = rendreq;
                unidades.Color = this.txt_color.Text.Trim().ToUpper();
                unidades.IdModelo = Convert.ToInt32(this.cmb_modelo.SelectedValue);
                unidades.Pasajeros = pasaj;
                unidades.IdEstatus = Convert.ToInt32(this.cmb_estatus.SelectedValue);
                unidades.Ruta = ruta;
                unidades.FileConstancia = "";
                unidades.FileArrendamiento = "";
                unidades.FileRefrendo = "";
                unidades.FileFactura = "";
                unidades.FilePolizaSeguro = "";
                unidades.FileTCirculacion = "";
                unidades.FechaCreacion = DateTime.Now;
                unidades.IdUsuarioCreo = IdUsuario;

                if (IdUnidad > 0)
                {
                    if (r_arrend != string.Empty && r_arrend != null)
                    {
                        var FName = r_arrend.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_arrend, ruta + FName[FName.Length - 1]);

                        }
                    }

                    if (r_const != string.Empty && r_const != null)
                    {
                        var FName = r_const.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_const, ruta + FName[FName.Length - 1]);
                        }
                    }

                    if (r_factura != string.Empty && r_factura != null)
                    {
                        var FName = r_factura.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_factura, ruta + FName[FName.Length - 1]);
                        }
                    }

                    if (r_poliza != string.Empty && r_poliza != null)
                    {
                        var FName = r_poliza.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_poliza, ruta + FName[FName.Length - 1]);
                        }
                    }

                    if (r_refrend != string.Empty && r_refrend != null)
                    {
                        var FName = r_refrend.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_refrend, ruta + FName[FName.Length - 1]);
                        }
                    }

                    if (r_tcirculacion != string.Empty && r_tcirculacion != null)
                    {
                        var FName = r_tcirculacion.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_tcirculacion, ruta + FName[FName.Length - 1]);
                        }
                    }

                    DialogResult result = MessageBox.Show("Desea editar la unidad", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        unidades.IdUsuarioModifico = IdUsuario;
                        unidades.FechaModificacion = DateTime.Now;
                        db.Entry(unidades).State = EntityState.Modified;
                        MessageBox.Show("Unidad actualizada exitosamente");
                    }
                    else
                    {
                        IdUnidad = 0;
                    }

                }
                else
                {
                    if (r_arrend != string.Empty && r_arrend != null)
                    {
                        var FName = r_arrend.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }

                        else
                        {
                            File.Copy(r_arrend, ruta + FName[FName.Length - 1]);
                        }
                    }

                    if (r_const != string.Empty && r_const != null)
                    {
                        var FName = r_const.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_const, ruta + FName[FName.Length - 1]);
                        }
                    }

                    if (r_factura != string.Empty && r_factura != null)
                    {
                        var FName = r_factura.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_factura, ruta + FName[FName.Length - 1]);
                        }
                    }

                    if (r_poliza != string.Empty && r_poliza != null)
                    { 
                        var FName = r_poliza.Split('\\');
                    if (File.Exists(ruta + FName[FName.Length - 1]))
                    {

                    }
                    else
                    {
                        File.Copy(r_poliza, ruta + FName[FName.Length - 1]);
                    }
                    }

                    if (r_refrend != string.Empty && r_refrend != null)
                    {
                        var FName = r_refrend.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_refrend, ruta + FName[FName.Length - 1]);
                        }

                    }

                    if (r_tcirculacion != string.Empty && r_tcirculacion != null)
                    {

                        var FName = r_tcirculacion.Split('\\');
                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(r_tcirculacion, ruta + FName[FName.Length - 1]);
                        }
                    }

                    db.Unidades.Add(unidades);
                    MessageBox.Show("Unidad agregada exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarUnidad();
        }

        private void CargarTiposUnidad()
        {
            var x = db.TipoUnidades.ToList();
            this.cmb_tipo.DataSource = x;
            this.cmb_tipo.ValueMember = "IdTipo";
            this.cmb_tipo.DisplayMember = "Tipo";
        }

        private void CargarMotores()
        {
            var x = db.MotoresUnidades.ToList();
            this.cmb_motor.DataSource = x;
            this.cmb_motor.ValueMember = "IdMotor";
            this.cmb_motor.DisplayMember = "Motor";
        }

        private void CargarModelos()
        {
            var x = db.ModelosUnidades.ToList();
            this.cmb_modelo.DataSource = x;
            this.cmb_modelo.ValueMember = "IdModelo";
            this.cmb_modelo.DisplayMember = "Modelo";

        }

        private void CargarEstatus()
        {
            var x = db.EstatusUnidades.ToList();
            this.cmb_estatus.DataSource = x;
            this.cmb_estatus.ValueMember = "IdEstatus";
            this.cmb_estatus.DisplayMember = "Estatus";

        }

        private void AEUnidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm.Enabled = true;
            frm.CargarUnidades();
        }

        private void VerArchivo(string filename)
        {
            if (filename != string.Empty && filename!=null)
            {
                System.Diagnostics.Process.Start(ruta + filename);
            }
            else
            {
                MessageBox.Show("No se encontro el archivo");
            }
        }
    }
}
