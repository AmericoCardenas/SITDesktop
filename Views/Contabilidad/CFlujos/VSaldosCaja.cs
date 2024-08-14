using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Contabilidad.CFlujos
{
    public partial class VSaldosCaja : Form
    {
        public VSaldosCaja(Form form)
        {
            InitializeComponent();
            this._form=form;
            this.Text = "Saldo Actual Caja";
        }

        Form _form;
        SITEntities db = new SITEntities();

        private void CalcularSaldoActual()
        {
            var tot_ingresos = db.Flujos.Where(x => x.IdTipo == 2 && x.IdEstatus == 1).Sum(y => y.Cantidad);
            var tot_egresos = db.Flujos.Where(x => x.IdTipo == 1 && x.IdEstatus == 1).Sum(y => y.Cantidad);
            var saldo_actual = (tot_ingresos - tot_egresos);
            if (saldo_actual != null)
            {
                this.lbl_saldo.Text = "$ " + saldo_actual.ToString();

                if (saldo_actual < 0)
                {
                    this.lbl_saldo.ForeColor = Color.Red;
                }
                else
                {
                    this.lbl_saldo.ForeColor = Color.Green;

                }

            }
            else
            {
                this.lbl_saldo.Text = "$0";
                this.lbl_saldo.ForeColor = Color.DodgerBlue;

            }

        }

        private void VSaldosCaja_Load(object sender, EventArgs e)
        {
            CalcularSaldoActual();
        }

        private void VSaldosCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VFlujos")
            {
                VFlujos frm = (VFlujos)this._form;
                frm.Enabled = true;
            }
        }
    }
}
