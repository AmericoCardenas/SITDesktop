using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SIT.Views;
using SIT.Views.Almacen;
using SIT.Views.Catalogos;
using SIT.Views.Catalogos.CProductosSnack;
using SIT.Views.Comercial;
using SIT.Views.Contabilidad;
using SIT.Views.Contabilidad.CMovimientos;
using SIT.Views.Logistica;
using SIT.Views.Sistemas;

namespace SIT.Views
{
    public partial class Menus : Form
    {
        public Menus(Login login)
        {
            InitializeComponent();
            this._login = login;
        }

        public Usuarios usuariologin;
        private Login _login;
        private bool IsCollapsed;

        private Button button;
        private Panel panel;

        //[DllImport("User32.dll")]
        //public static extern int GetAsyncKeyState(Int32 i);
        //static string kellog = "";

        //public static void CargarKeyLogger()
        //{
        //    while (true)
        //    {
        //        Thread.Sleep(5);

        //        for (int i = 32; i < 127; i++)
        //        {
        //            int keystate = GetAsyncKeyState(i);
        //            if (keystate != 0)
        //            {
        //                Debug.WriteLine(keystate.ToString());
        //            }
        //        }
        //    }
        //}

        private void tmmenu_Tick(object sender, EventArgs e)
        {
            if(IsCollapsed)
            {
                this.button.Image = Properties.Resources.flecha_hacia_abajo;
                this.panel.Height += 10;
                if (this.panel.Size == this.panel.MaximumSize)
                {
                    this.tmmenu.Stop();
                    IsCollapsed = false;
                }
            }
            else
            {
                this.button.Image = Properties.Resources.flecha_hacia_abajo;
                this.panel.Height -= 10;
                if (this.panel.Size == this.panel.MinimumSize)
                {
                    this.tmmenu.Stop();
                    IsCollapsed = true;
                }
            }
        }

        private void btncatalogos_Click(object sender, EventArgs e)
        {
            button = this.btn_catalogos;
            panel = this.pnl_catalogos;
            this.tmmenu.Start();
        }

        private void Menus_Load(object sender, EventArgs e)
        {
            Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var version = "SIT v" + appVersion.Major + "." + appVersion.Minor + "." + appVersion.Build + ".";
            this.Text = version+" / "+usuariologin.Nombre+" "+usuariologin.Apellidop+" "+usuariologin.Apellidom+" / "+usuariologin.Usuario;

            if (usuariologin.IdDepto == 3) //SISTEMAS
            {
                this.btn_catalogos.Enabled = true;
                this.btn_sistemas.Enabled = true;
            }
            else if(usuariologin.IdDepto == 7) //RH
            {
                #region catalogos
                this.btn_catalogos.Enabled = true;
                this.btn_usuarios.Enabled = false;
                this.btn_unidades.Enabled = false;
                this.btn_clientes.Enabled = false;
                this.btn_servicios.Enabled = false;
                this.btn_conceptosf.Enabled = false;
                this.btn_rubros.Enabled = false;
                this.btn_tipos.Enabled = false;
                this.btn_metodos.Enabled = false;
                this.btn_prodsnack.Enabled = true;
                #endregion

                this.btn_snack.Enabled = true;
                this.btn_sistemas.Enabled = false;
                this.btn_logistica.Enabled = false;
                this.btn_contabilidad.Enabled = false;
                this.btn_comercial.Enabled = false;
                this.btn_almacen.Enabled = false;
                this.btn_comedor.Enabled = true;

            }
            else if (usuariologin.IdDepto == 4)
            {
                #region catalogos
                this.btn_catalogos.Enabled = true;
                this.btn_usuarios.Enabled = false;
                this.btn_unidades.Enabled = false;
                this.btn_clientes.Enabled = true;
                this.btn_servicios.Enabled = false;
                this.btn_conceptosf.Enabled = true;
                this.btn_rubros.Enabled = true;
                this.btn_tipos.Enabled = true;
                this.btn_metodos.Enabled = true;
                #endregion

                this.btn_sistemas.Enabled = false;
                this.btn_logistica.Enabled = false;
                this.btn_contabilidad.Enabled = true;
                this.btn_comercial.Enabled = false;
                this.btn_almacen.Enabled = false;             
                this.btn_comedor.Enabled = false;

            }
            else if (usuariologin.IdDepto == 4)
            {
                #region catalogos
                this.btn_catalogos.Enabled = false;
                #endregion

                this.btn_sistemas.Enabled = false;
                this.btn_logistica.Enabled = false;
                this.btn_contabilidad.Enabled = false;
                this.btn_comercial.Enabled = true;
                this.btn_almacen.Enabled = false;
                this.btn_comedor.Enabled = false;


            }
            else if (usuariologin.IdDepto == 5)
            {
                #region catalogos
                this.btn_catalogos.Enabled = false;
                #endregion

                this.btn_sistemas.Enabled = false;
                this.btn_logistica.Enabled = false;
                this.btn_contabilidad.Enabled = false;
                this.btn_comercial.Enabled = false;
                this.btn_almacen.Enabled = true;
                this.btn_comedor.Enabled = false;



            }

            //Thread workerThread = new Thread(new ThreadStart(CargarKeyLogger));
            //workerThread.Start();

        }

        private void btn_usuarios_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VUsuarios(usuariologin));
        }

        private void AbrirFormPanel(object FormHijo)
        {
            if (this.pnl_contenedor.Controls.Count > 0)
            {
                this.pnl_contenedor.Controls.RemoveAt(0);
                Form fh = FormHijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.pnl_contenedor.Controls.Add(fh);
                this.pnl_contenedor.Tag = fh;
                fh.Show();
            }
            else
            {
                Form fh = FormHijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.pnl_contenedor.Controls.Add(fh);
                this.pnl_contenedor.Tag = fh;
                fh.Show();
            }
        }

        private void btn_unidades_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VUnidades());

        }

        private void btn_emp_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VEmpleados());

        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VClientes());
        }

        private void btn_rutas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VRutas(usuariologin));

        }

        private void btn_servicios_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VServicios(usuariologin));

        }

        private void btn_lineas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VLineas(usuariologin));

        }

        private void btn_logistica_Click(object sender, EventArgs e)
        {
            button = this.btn_logistica;
            panel = this.pnl_logistica;
            this.tmmenu.Start();
        }

        private void btn_sistemas_Click(object sender, EventArgs e)
        {
            button = this.btn_sistemas;
            panel = this.pnl_sistemas;
            this.tmmenu.Start();
        }

        private void btn_eqcomp_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VEquiposComputo(usuariologin));

        }

        private void btn_eqmov_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VEquiposMovil(usuariologin));

        }

        private void btn_sitios_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VSitios());

        }

        private void btn_mapa_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VMapa());

        }

        private void btn_conceptosf_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VConceptosFlujos());

        }

        private void btn_rubros_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VRubros());

        }

        private void btn_metodos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VMetodosPago());

        }

        private void btn_flujos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VFlujos(usuariologin));

        }

        private void btn_contabilidad_Click(object sender, EventArgs e)
        {
            button = this.btn_contabilidad;
            panel = this.pnl_contabilidad;
            this.tmmenu.Start();
        }

        private void btn_comercial_Click(object sender, EventArgs e)
        {
            button = this.btn_comercial;
            panel = this.pnl_comercial;
            this.tmmenu.Start();

        }

        private void btn_ve_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VViajesEspeciales(usuariologin));

        }

        private void btn_movimientos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VMovimientos(usuariologin));

        }

        private void btn_conciliador_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VConciliador());

        }

        private void btn_notas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VNotas(usuariologin));

        }

        private void btn_proveedores_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VProveedores(usuariologin));

        }

        private void Menus_FormClosed(object sender, FormClosedEventArgs e)
        {
            _login.Close();
        }

        private void btn_almacen_Click(object sender, EventArgs e)
        {
            button = this.btn_almacen;
            panel = this.pnl_almacen;
            this.tmmenu.Start();
        }

        private void btn_pherramientas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VPHerramientas(usuariologin));
        }

        private void btn_comedor_Click(object sender, EventArgs e)
        {
            button = this.btn_comedor;
            panel = this.pnl_comedor;
            this.tmmenu.Start();
        }

        private void btn_prodsnack_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VProductosSnack(usuariologin));

        }
    }
}
