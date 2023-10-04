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
using SIT.Views;
using SIT.Views.Catalogos;

namespace SIT.Views.Logistica.CRutas
{
    public partial class VImportarBitacora : Form
    {
        public VImportarBitacora(Usuarios usuariolog)
        {
            InitializeComponent();
            this._uslog = usuariolog;
        }

        public Form _frm;
        Usuarios _uslog;
        SITEntities db = new SITEntities();
        Rutas rutas = new Rutas();

        private void ImportarBitacoraFecha()
        {
            DateTime fecha = this.dtm_fecha.Value;
            DateTime fecha_actual= DateTime.Now;


            var query = (from b in db.Rutas.AsEnumerable()
                         where b.Fecha == fecha.Date
                         select new Rutas()
                         {
                             Fecha = fecha_actual,
                             Hora = "00:00",
                             CodigoBitad = "0",
                             IdCliente = b.IdCliente,
                             IdProducto = b.IdProducto,
                             IdTipo = b.IdTipo,
                             IdTurno = b.IdTurno,
                             IdEmpleado = 0,
                             Unidad = "0",
                             PEntrada = 0,
                             PSalida = 0,
                             FechaCreacion = fecha_actual.ToString("dd-MM-yyyy"),
                             UsuarioCreacion = _uslog.IdUsuario,
                             IdEstatus = 1
                         }).ToList();
                           

            if(query==null )
            {
                MessageBox.Show("Favor de seleccionar una fecha con rutas");
            }
            else
            {
                db.Rutas.AddRange(query);
                db.SaveChanges();
                MessageBox.Show("Se ha importado la bitacora con exito");
                this.Close();
                _frm.Enabled = true;

                if (_frm.Name == "VRutas")
                {
                    VRutas vrutas = new VRutas(_uslog);
                    vrutas.CargarRutas();
                }
            }

            

        }

        private void btn_importar_Click(object sender, EventArgs e)
        {
            ImportarBitacoraFecha();
        }
    }
}
