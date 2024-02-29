using SIT.Views.Contabilidad.CMovimientos;
using SIT.Views.Contabilidad.CNotas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Almacen.COrdenesCompra
{
    public partial class VNotaMov : Form
    {
        public VNotaMov(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        Form _form;
        public Usuarios uslog;
        public string title, idprov, prov, total, idoc;

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this._form.Enabled = true;
        }

        private void btn_nota_Click(object sender, EventArgs e)
        {
            AENotas aenota = new AENotas(_form);
            aenota.folio = idoc;
            aenota.idprov = Convert.ToInt32(idprov);
            aenota.IdUsuario = this.uslog.IdUsuario;
            aenota.total = total;
            this.Close();   
            aenota.Show();

        }

        private void btn_mov_Click(object sender, EventArgs e)
        {
            AEMovimiento aemov = new AEMovimiento(_form);
            aemov.notaproveedor = prov;
            aemov.cantidad = total;
            aemov.referencia = idoc;
            aemov._uslog = uslog;
            this.Close();
            aemov.Show();

        }

        private void VNotaMov_Load(object sender, EventArgs e)
        {
            this.label1.Text= this.title;   
        }
    }
}
