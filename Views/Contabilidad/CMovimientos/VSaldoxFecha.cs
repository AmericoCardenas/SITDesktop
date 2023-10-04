using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Contabilidad
{
    public partial class VSaldoxFecha : Form
    {
        public VSaldoxFecha()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();

        private void ConsultarSaldoxfecha()
        {
            this.txt_saldo.Text=string.Empty;
            var fecha = Convert.ToDateTime(this.dtm_fecha.Value.ToString("yyyy-MM-dd"));
            var tot_ingresos = db.Movimientos.Where(x => x.IdTipo == 2 && x.Fecha==fecha).Sum(y => y.Cantidad);
            var tot_egresos = db.Movimientos.Where(x => x.IdTipo == 1 && x.Fecha==fecha).Sum(y => y.Cantidad);
            if(tot_ingresos is null)
            {
                tot_ingresos = 0;
            }

            if(tot_egresos is null)
            {
                tot_egresos = 0;
            }

            var saldo_actual = (tot_ingresos - tot_egresos);
            this.txt_saldo.Text = Math.Round(Convert.ToDouble(saldo_actual)).ToString();

        }

        private void dtm_fecha_ValueChanged(object sender, EventArgs e)
        {
            ConsultarSaldoxfecha();
        }
    }
}
