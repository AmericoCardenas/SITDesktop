using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Catalogos
{
    public partial class VClientes : Form
    {
        public VClientes()
        {
            InitializeComponent();
            this.dgrid_clientes.EnableHeadersVisualStyles = false;
            this.dgrid_clientes.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_clientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        SITEntities db = new SITEntities();

        private void CargarClientes()
        {
            this.dgrid_clientes.DataSource = db.Clientes.ToList();
            this.dgrid_clientes.Columns[0].Visible = false;
            this.dgrid_clientes.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrid_clientes.Columns[this.dgrid_clientes.Columns.Count - 1].Visible = false;
        }

        private void VClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }
    }
}
