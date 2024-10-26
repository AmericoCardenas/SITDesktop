using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Taller.CActMecanicos
{
    public partial class VActMecanicos : Form
    {
        public VActMecanicos()
        {
            InitializeComponent();
        }
        SITEntities db = new SITEntities();
        private void CargarAct()
        {
            var x = from n in db.ActividadesOT
                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                    join a in db.ActividadesTaller on n.IdActTaller equals a.IdAct
                    where n.IdEstatus == 1
                    orderby n.FI descending
                    select new
                    {
                        n.IdOT,
                        Empleado=t.NombreCompleto,
                        a.Actividad,
                        n.FI,
                        n.TI,
                        n.Observaciones
                    };
            this.dgrid_actividades.DataSource = x.ToList();
            this.dgrid_actividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void VActMecanicos_Load(object sender, EventArgs e)
        {
            CargarAct();
        }
    }
}
