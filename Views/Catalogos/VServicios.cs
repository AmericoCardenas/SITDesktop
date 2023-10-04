using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views
{
    public partial class VServicios : Form
    {
        public VServicios(Usuarios usuariolog)
        {
            InitializeComponent();
            CargarServicios();
        }

        SITEntities db = new SITEntities();

        private void CargarServicios()
        {
            var servicios = db.Productos.ToList();
            this.dgrid_servicios.DataSource = servicios;
        }
    }
}
