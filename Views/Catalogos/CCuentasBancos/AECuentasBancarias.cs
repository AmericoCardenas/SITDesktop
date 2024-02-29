using SIT.Views.Catalogos.CUnidades;
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

namespace SIT.Views.Catalogos.CCuentasBancos
{
    public partial class AECuentasBancarias : Form
    {
        public int IdCuenta;
        public int IdUsuario;
        public VCuentasBancarias vcuentas;
        CuentasBancos cuentas = new CuentasBancos();
        SITEntities db = new SITEntities();

        public AECuentasBancarias()
        {
            InitializeComponent();
        }

        private void CargarBancos()
        {
            var x = db.Bancos.ToList();
            this.cmb_bancos.DataSource = x;
            this.cmb_bancos.ValueMember = "IdBanco";
            this.cmb_bancos.DisplayMember = "Banco";
        }

        private void AECuentasBancarias_Load(object sender, EventArgs e)
        {
            CargarBancos();
            if (IdCuenta != 0)
            {
                cuentas = db.CuentasBancos.Where(x => x.IdCuenta == IdCuenta).FirstOrDefault();
                this.txt_cuenta.Text = cuentas.Cuenta;
                this.cmb_bancos.SelectedValue = cuentas.IdBanco;
                this.Text = "Editar ";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void AgregarCuenta()
        {

            if (this.txt_cuenta.Text == "" || this.txt_cuenta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el numero de cuenta");
                this.txt_cuenta.Focus();
            }
            else if (this.cmb_bancos.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el banco");
                this.cmb_bancos.Focus();
            }
            else
            {
    
                cuentas.Cuenta = this.txt_cuenta.Text;  
                cuentas.IdBanco = Convert.ToInt32(this.cmb_bancos.SelectedValue);
                cuentas.IdEstatus = 1;
                cuentas.FechaCreacion = DateTime.Now;
                cuentas.IdUsuarioCreo = IdUsuario;

                if (IdCuenta > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar la cuenta", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        cuentas.IdUsuarioModifico = IdUsuario;
                        cuentas.FechaModificacion = DateTime.Now;
                        db.Entry(cuentas).State = EntityState.Modified;
                        MessageBox.Show("Cuenta actualizada exitosamente");
                    }
                    else
                    {
                    }

                }
                else
                {
                    db.CuentasBancos.Add(cuentas);
                    MessageBox.Show("Cuenta agregada exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarCuenta();
        }

        private void AECuentasBancarias_FormClosed(object sender, FormClosedEventArgs e)
        {
            vcuentas.Enabled = true;
            vcuentas.CargarCuentas();
        }
    }
}
