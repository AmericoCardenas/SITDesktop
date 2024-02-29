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

namespace SIT.Views.Catalogos.CBancos
{
    public partial class AEBancos : Form
    {
        public AEBancos()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();
        public int IdBanco;
        public int IdUsuario;
        Bancos bancos = new Bancos();
        public VBancos vbancos;

        private void AEBancos_Load(object sender, EventArgs e)
        {
            if (IdBanco != 0)
            {
                bancos = db.Bancos.Where(x => x.IdBanco == IdBanco).FirstOrDefault();
                this.txt_banco.Text = bancos.Banco;
                this.Text = "Editar";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void AgregarBanco()
        {
            if (this.txt_banco.Text == "" || this.txt_banco.Text.Trim().Length==0)
            {
                MessageBox.Show("Favor de introducir el banco");
                this.txt_banco.Focus();
            }
            else
            {
                bancos.Banco = this.txt_banco.Text.ToUpper();
                bancos.IdEstatus = 1;
                bancos.IdUsuarioCreo = IdUsuario;
                bancos.FechaCreacion =DateTime.Now;


                if (IdBanco > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el banco", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        bancos.FechaModificacion = DateTime.Now;
                        bancos.IdUsuarioModifico = IdUsuario;
                        db.Entry(bancos).State = EntityState.Modified;
                        MessageBox.Show("Banco actualizado exitosamente");
                    }
                    else
                    {
                    }

                }
                else
                {
                    db.Bancos.Add(bancos);
                    MessageBox.Show("Banco agregado exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarBanco();
        }

        private void AEBancos_FormClosed(object sender, FormClosedEventArgs e)
        {
            vbancos.Enabled = true;
            vbancos.CargarBancos();

        }
    }
}
