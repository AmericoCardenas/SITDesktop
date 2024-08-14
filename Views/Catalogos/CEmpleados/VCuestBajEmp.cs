using log4net.Appender;
using SIT.SmtpEmail;
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

namespace SIT.Views.Catalogos.CEmpleados
{
    public partial class VCuestBajEmp : Form
    {
        public Usuarios uslog;
        public int idemp;
        Trabajadores _t = new Trabajadores();
        Form _form;
        HistBajasEmp histbaja = new HistBajasEmp();
        SITEntities db = new SITEntities();
        EnviarEmail email = new EnviarEmail();



        public VCuestBajEmp(Form form)
        {
            InitializeComponent();
            this._form = form;

        }

        private void VCuestBajEmp_Load(object sender, EventArgs e)
        {
            _t = db.Trabajadores.Where(x => x.IdEmpleado == idemp).FirstOrDefault();

            this.Text = "Baja de Empleado " + _t.NombreCompleto.ToString();
            this.lbl_nombreemp.Text = _t.NombreCompleto;
        }

        private void VCuestBajEmp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VEmpleados")
            {
                VEmpleados vemp = this._form as VEmpleados;
                vemp.Enabled = true;
                vemp.CargarEmpleados(1);
            }
        }

        private void btn_bajaemp_Click(object sender, EventArgs e)
        {
            CrearBajaEmp();
        }

        private void CrearBajaEmp()
        {
            if (this.txt_motivobajaemp.Text.Trim().Length == 0)
            {

                MessageBox.Show("Favor de capturar el motivo de baja del empleado");
                this.txt_motivobajaemp.Focus();
            }
            else
            {
                this.histbaja.IdEmpleado = _t.IdEmpleado;
                this.histbaja.Motivo = this.txt_motivobajaemp.Text.ToUpper();
                this.histbaja.Fecha = this.dtm_bajaemp.Value;
                this.histbaja.IdEstatus = 1;
                this.histbaja.IdUsCreo = this.uslog.IdUsuario;
                this.histbaja.FCreo = DateTime.Now;

                this._t.IdUsuarioCancelo = this.uslog.IdUsuario;
                this._t.FechaCancelacion = DateTime.Now;
                this._t.IdEstatus = 2;

                if (this._t != null && this.histbaja != null)
                {
                    
                        this.db.Entry(_t).State = EntityState.Modified;
                        this.db.SaveChanges();


                        this.db.HistBajasEmp.Add(histbaja);
                        this.db.SaveChanges();


                         EnviarEmailBajaEmp();


                    MessageBox.Show("Empleado inhabilitado exitosamente");


                }
                else
                {
                    MessageBox.Show("Favor de seleccionar el empleado");
                }


                this.Close();
            }
        } 

        private void EnviarEmailBajaEmp()
        {
            List<string> lst_rec = new List<string>();
            lst_rec.Add("facturacion@transportesdavila.com.mx");
            lst_rec.Add("rh2@transportesdavila.com.mx");
            lst_rec.Add("logistica@transportesdavila.com.mx");
            lst_rec.Add("logistica4.transportesdavila@gmail.com");
            lst_rec.Add("comercial@transportesdavila.com.mx");
            lst_rec.Add("sistemas@transportesdavila.com.mx");
            lst_rec.Add("diesel@transportesdavila.com.mx");
            lst_rec.Add("suplogistica@transportesdavila.com.mx");
            lst_rec.Add("operaciones@transportesdavila.com.mx");
            lst_rec.Add("suplogistica@transportesdavila.com.mx");
            lst_rec.Add("contabilidad@transportesdavila.com.mx");
            lst_rec.Add("contabilidad2@transportesdavila.com.mx");
            lst_rec.Add("taller@transportesdavila.com.mx");
            lst_rec.Add("compras@transportesdavila.com.mx");
            lst_rec.Add("gestoria2@transportesdavila.com.mx");
            lst_rec.Add("amazon@transportesdavila.com.mx");


            email.subject = "SIT - BAJA "+DateTime.Now+" EMPLEADO: " + _t.NombreCompleto.ToString();
            email.body =
                "INFORME  DE SISTEMA (SIT)" + Environment.NewLine +
                "BAJA DE EMPLEADO" + Environment.NewLine +
                "FECHA: " + this.dtm_bajaemp.Value.ToString() + Environment.NewLine +
                "EMPLEADO: " + _t.NombreCompleto.ToString() + Environment.NewLine +
                "MOTIVO: " + this.txt_motivobajaemp.Text.ToUpper() + Environment.NewLine +
                "CAPTURO: " + this.uslog.Nombre + " " + this.uslog.Apellidop + " " + this.uslog.Apellidom;
            email.recipients= lst_rec;
            email.SendEmail2();
        }
    }
}
