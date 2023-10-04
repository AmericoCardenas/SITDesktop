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
    public partial class VNotas : Form
    {
        public VNotas()
        {
            InitializeComponent();
        }

        public int IdMovimiento;
        public int IdUsuario;
        SITEntities db = new SITEntities();
        NotasMovimientos not = new NotasMovimientos();

        private void VNotas_Load(object sender, EventArgs e)
        {
            CargarNotas();
        }

        private void CargarNotas()
        {
            var x = db.NotasMovimientos.Where(i=>i.IdMovimiento == IdMovimiento).FirstOrDefault();
            this.dgrid_notas.DataSource = x;
        }

        private void AgregarNotas()
        {
            if (this.txt_folio.Text == "")
            {
                MessageBox.Show("Favor de introducir el folio");
                this.txt_folio.Focus();
            }
            else if (this.txt_concepto.Text == "")
            {
                MessageBox.Show("Favor de introducir el concepto");
                this.txt_concepto.Focus();
            }
            else if (this.txt_cantidad.Text == "")
            {
                MessageBox.Show("Favor de introducir la cantidad");
                this.txt_cantidad.Focus();
            }
            else
            {
                not.IdMovimiento = IdMovimiento;
                not.Folio = this.txt_folio.Text.ToUpper();
                not.F

            }
        }
    }
}
