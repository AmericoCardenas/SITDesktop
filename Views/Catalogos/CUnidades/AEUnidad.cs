using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
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

        SITEntities db =  new SITEntities();
        Unidades unidades = new Unidades();
        VUnidades frm;
        public int IdUnidad;
        public int IdUsuario;

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
                unidades.FechaCreacion = DateTime.Now;
                unidades.IdUsuarioCreo = IdUsuario;

                if (IdUnidad > 0)
                {
                    
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
    }
}
