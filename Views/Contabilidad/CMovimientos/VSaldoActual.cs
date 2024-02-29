using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Contabilidad.CMovimientos
{
    public partial class VSaldoActual : Form
    {
        public VSaldoActual()
        {
            InitializeComponent();
            CargarCuentas();
        }

        SITEntities db = new SITEntities(); 
        private void CargarCuentas()
        {
            var x = this.db.CuentasBancos.ToList();
            this.cmb_cuentas.DataSource = x;
            this.cmb_cuentas.ValueMember = "IdCuenta";
            this.cmb_cuentas.DisplayMember = "Cuenta";
        }

        private void cmb_cuentas_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var idcuenta = Convert.ToInt32(this.cmb_cuentas.SelectedValue);
                var cuenta = db.CuentasBancos.Where(x=>x.IdCuenta == idcuenta).FirstOrDefault();
                var banco = db.Bancos.Where(x=>x.IdBanco==cuenta.IdBanco).FirstOrDefault();
               if (banco != null) {
                    this.lbl_banco.Text = banco.Banco.ToString().ToUpper();
                }

                var tot_ingresos = db.Movimientos.Where(x => x.IdTipo == 2 && x.IdEstatus==1 && x.IdCuenta==idcuenta).Sum(y => y.Cantidad);
                var tot_egresos = db.Movimientos.Where(x => x.IdTipo == 1 && x.IdEstatus == 1 && x.IdCuenta==idcuenta).Sum(y => y.Cantidad);
                var saldo_actual = (tot_ingresos - tot_egresos);
                if(saldo_actual != null)
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
            catch(Exception ex)
            {

            }
        }
    }
}
