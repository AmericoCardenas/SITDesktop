using DocumentFormat.OpenXml.Drawing;
using SIT.Views.Taller.COrdenesTrabajo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIT.SmtpEmail;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Net.Mail;

namespace SIT.Views.Logistica.CIncidencias
{
    public partial class AEIncidencia : Form
    {
        public AEIncidencia(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        SITEntities db = new SITEntities();
        EnviarEmail evm = new EnviarEmail();
    IncidenciasOperaciones incidencias = new IncidenciasOperaciones();
        public int idIncidencia;
        public Usuarios _uslog;
        Form _form;

        private void AEIncidencia_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarIncidencias();

            if (idIncidencia != 0)
            {
                incidencias = db.IncidenciasOperaciones.Where(x=>x.IdIncidencia == idIncidencia).First();
                this.txt_obs.Text = incidencias.Observaciones;
                this.cmb_empleado.SelectedValue = incidencias.IdEmpleado;
                this.cmb_incidencia.SelectedValue=incidencias.IdCatIncidencia;
                this.dtm_fecha.Value = Convert.ToDateTime(incidencias.Fecha);
                if (incidencias.FNom != null)
                {
                    this.dtm_fnom.Value = Convert.ToDateTime(incidencias.FNom);

                }
                this.Text = "Editar";

                if (this._uslog.IdDepto == 7 || this._uslog.IdDepto==4)
                {
                    this.Text = "Aplicar en Nomina";
                    this.cmb_empleado.Enabled = false;
                    this.cmb_incidencia.Enabled = false;
                    this.label1.Enabled = false;
                    this.label2.Enabled = false;
                    this.label3.Enabled = false;
                    this.label4.Enabled = false;
                    this.dtm_fnom.Enabled = true;
                    this.txt_obs.Enabled=false;
                    this.dtm_fecha.Enabled = false;
                }
                else
                {
                    this.dtm_fnom.Enabled=false;
                }

            }
            else
            {
                this.Text = "Agregar";
            }

          
           
        }

        private void CargarEmpleados()
        {
            var x = this.db.Trabajadores.Where(z => z.IdEstatus == 1 && z.IdPuesto == 2).ToList();
            this.cmb_empleado.DataSource = x;
            this.cmb_empleado.DisplayMember = "NombreCompleto";
            this.cmb_empleado.ValueMember = "IdEmpleado";
        }

        private void CargarIncidencias()
        {
            var x = this.db.CatIncidencias.Where(z => z.IdEstatus == 1).ToList();
            this.cmb_incidencia.DataSource = x;
            this.cmb_incidencia.DisplayMember = "Descripcion";
            this.cmb_incidencia.ValueMember = "IdIncidencia";
        }

        private void AgregarIncidencia()
        {
            if (this.cmb_empleado.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar al empleado");
                this.cmb_empleado.Focus();
            }
            else if(this.cmb_incidencia.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar incidencia");
                this.cmb_incidencia.Focus();
            }
            else
            {
                

                if (this._uslog.IdDepto != 7 && this._uslog.IdDepto != 4)
                {
                    incidencias.IdEmpleado = Convert.ToInt32(this.cmb_empleado.SelectedValue);
                    incidencias.IdEstatus = 1;
                    incidencias.IdCatIncidencia = Convert.ToInt32(this.cmb_incidencia.SelectedValue);
                    incidencias.Fecha = this.dtm_fecha.Value;
                    incidencias.Observaciones = this.txt_obs.Text.ToUpper();
                    var idcatincidencia = Convert.ToInt32(this.cmb_incidencia.SelectedValue);
                    var monto = db.CatIncidencias.Where(x => x.IdIncidencia == idcatincidencia).Select(x => x.Monto).First();
                    incidencias.Monto = Convert.ToDouble(monto);

                }

                if (idIncidencia > 0)
                {
                    if (this._uslog.IdDepto == 7 || this._uslog.IdDepto==4)
                    {
                        incidencias.IdEstatus = 3;
                        incidencias.FNom=this.dtm_fnom.Value;
                        incidencias.IdUsAplico = this._uslog.IdUsuario;
                    }

                    DialogResult result = MessageBox.Show("Desea editar la incidencia", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        incidencias.IdUsMod = this._uslog.IdUsuario;
                        incidencias.FMod = DateTime.Now;
                        db.Entry(incidencias).State = EntityState.Modified;
                        MessageBox.Show("Incidencia actualizada exitosamente");
                      
                    }
                    else
                    {
                    }

                }
                else
                {
                    incidencias.FCreo = DateTime.Now;
                    incidencias.IdUsCreo = this._uslog.IdUsuario;

                    db.IncidenciasOperaciones.Add(incidencias);
                    MessageBox.Show("Incidencia agregado exitosamente");

                }

                EnviarEmailIncidencia();

                db.SaveChanges();
                this.Close();
            }
        }

        private void EnviarEmailIncidencia()
        {
            List<string> lst_emto = new List<string>();
            lst_emto.Add("facturacion@transportesdavila.com.mx");
            lst_emto.Add("rh2@transportesdavila.com.mx");
            lst_emto.Add("logistica@transportesdavila.com.mx");
            lst_emto.Add("logistica4.transportesdavila@gmail.com");
            lst_emto.Add("comercial@transportesdavila.com.mx");
            lst_emto.Add("sistemas@transportesdavila.com.mx");
            lst_emto.Add("diesel@transportesdavila.com.mx");
            lst_emto.Add("suplogistica@transportesdavila.com.mx");

            evm.recipients = lst_emto;  

            evm.subject = "SIT - INCIDENCIA " + incidencias.Fecha.ToString() + " " + this.cmb_empleado.Text;
            evm.body = "INFORME  DE SISTEMA (SIT)" + Environment.NewLine +
                "INCIDENCIA: " + this.cmb_incidencia.Text + Environment.NewLine +
                "EMPLEADO: " + this.cmb_empleado.Text + Environment.NewLine +
                "FECHA:  " + this.dtm_fecha.Value.ToString() + Environment.NewLine +
                "MONTO: $" + incidencias.Monto + Environment.NewLine +
                "OBSERVACIONES: " + this.txt_obs.Text + Environment.NewLine +
                "CAPTURO: " + this._uslog.Nombre + " " + this._uslog.Apellidop + " " + this._uslog.Apellidom;
            evm.SendEmail2();

        }

        private void AEIncidencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VIncidencias")
            {
                VIncidencias vIncidencias = (VIncidencias)this._form;
                vIncidencias.Enabled = true;
                vIncidencias.CargarIncidencias();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarIncidencia();
        }
    }
}
