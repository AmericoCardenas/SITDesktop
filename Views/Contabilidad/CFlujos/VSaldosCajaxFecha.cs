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
    public partial class VSaldosCajaxFecha : Form
    {
        public VSaldosCajaxFecha()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();

        private void ConsultarSaldoxfecha()
        {
            try
            {
                this.lbl_saldo.Text = string.Empty;
  
                var fecha = Convert.ToDateTime(this.dtm_fecha.Value.ToString("yyyy-MM-dd"));
                var totinganterior = db.Flujos.Where(x => x.IdTipo == 2 && x.IdEstatus == 1 && x.Fecha < fecha).Sum(y => y.Cantidad);
                var totegranterior = db.Flujos.Where(x => x.IdTipo == 1 && x.IdEstatus == 1 && x.Fecha < fecha).Sum(y => y.Cantidad);
                var saldoanterior = (totinganterior - totegranterior);

                var tot_ingresos = db.Flujos.Where(x => x.IdTipo == 2 && x.IdEstatus == 1 && x.Fecha == fecha).Sum(y => y.Cantidad);
                var tot_egresos = db.Flujos.Where(x => x.IdTipo == 1 && x.IdEstatus == 1 && x.Fecha == fecha).Sum(y => y.Cantidad);
                if (tot_ingresos is null)
                {
                    tot_ingresos = 0;
                }

                if (tot_egresos is null)
                {
                    tot_egresos = 0;
                }

                var saldo_actual = (saldoanterior + tot_ingresos) - tot_egresos;
                if (saldo_actual != null)
                {
                    this.lbl_saldo.Text = "$ " + Convert.ToDouble(saldo_actual).ToString();
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
                    this.lbl_saldo.ForeColor = Color.Black;

                }

            }
            catch (Exception ex) { }

        }

        private void dtm_fecha_ValueChanged(object sender, EventArgs e)
        {
            ConsultarSaldoxfecha();
        }
    }
}
