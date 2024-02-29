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
using SIT.Views.Almacen.COrdenesCompra;
using SIT.Views.Almacen.CProductosAlmacen;
using SIT.Views.Almacen.CSalidas;
using SIT.Views.Catalogos;
using SIT.Views.Catalogos.CAlmacenes;
using SIT.Views.Catalogos.CBancos;
using SIT.Views.Catalogos.CCuentasBancos;
using SIT.Views.Catalogos.CProductosAlmacen;
using SIT.Views.Catalogos.CProductosSnack;
using SIT.Views.Catalogos.CTipoUnidades;
using SIT.Views.Comercial;
using SIT.Views.Contabilidad;
using SIT.Views.Contabilidad.CMovimientos;
using SIT.Views.Diesel.CCortesDiariosBomba;
using SIT.Views.General.CRequisiciones;
using SIT.Views.Gerencia.CCotxAutorizar;
using SIT.Views.Gestoria.CPolizas;
using SIT.Views.Logistica;
using SIT.Views.Nominas.CNomGeneral;
using SIT.Views.RH;
using SIT.Views.Sistemas;
using SIT.Views.Taller;

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

            if (usuariologin.IdDepto == 3 || usuariologin.IdDepto==1) //SISTEMAS o GERENCIA
            {
                #region catalogos
                this.btn_emp.Enabled = true;
                this.btn_unidades.Enabled = true;
                this.btn_clientes.Enabled = true;
                this.btn_usuarios.Enabled = true;
                this.btn_servicios.Enabled = true;
                this.btn_conceptosf.Enabled = true;
                this.btn_rubros.Enabled = true;
                this.btn_tipos.Enabled = true;
                this.btn_metodos.Enabled = true;
                this.btn_proveedores.Enabled = true;
                this.btn_prodsnack.Enabled = true;
                this.btn_tipounidades.Enabled = true;
                this.btn_bancos.Enabled = true;
                this.btn_cuentasbanc.Enabled = true;

                #endregion
                this.btn_catalogos.Enabled = true;
                this.btn_sistemas.Enabled = true;
                this.btn_gerencia.Enabled = true;
                this.btn_almacen.Enabled = true;
                this.btn_comedor.Enabled = true;
                this.btn_comercial.Enabled = true;
                this.btn_contabilidad.Enabled = true;
                this.btn_diesel.Enabled = true;
                this.btn_general.Enabled = true;
                this.btn_logistica.Enabled = true;
                this.btn_sistemas.Enabled = true;
                this.btn_gestoria.Enabled = true;
                this.btn_nominas.Enabled = true;
                this.btn_general.Enabled = true;
                this.btn_oc.Enabled = true;
                this.btn_almacenes.Enabled = true;
                this.btn_requisiciones.Enabled = true;
                this.btn_oc.Enabled = true;
                this.btn_pherramientas.Enabled = true;
                this.btn_salidas.Enabled = true;
                this.btn_productosalm.Enabled = true;
                this.btn_taller.Enabled = true;





            }
            else if(usuariologin.IdDepto == 7) //RH
            {
                #region catalogos
                this.btn_catalogos.Enabled = true;
                this.btn_prodsnack.Enabled = true;
                this.btn_emp.Enabled = true;

                #endregion

                this.btn_snack.Enabled = true;
                this.btn_comedor.Enabled = true;
                this.btn_nominas.Enabled = true;
                this.btn_general.Enabled = true;




            }
            else if (usuariologin.IdDepto == 4) //CONTABILIDAD
            {
                #region catalogos
                this.btn_catalogos.Enabled = true;
                this.btn_clientes.Enabled = true;
                this.btn_conceptosf.Enabled = true;
                this.btn_rubros.Enabled = true;
                this.btn_tipos.Enabled = true;
                this.btn_metodos.Enabled = true;
                this.btn_proveedores.Enabled = true;

                #endregion


                this.btn_contabilidad.Enabled = true;  
                this.btn_comedor.Enabled = true;
                this.btn_nominas.Enabled = true;
                this.btn_bancos.Enabled = true;
                this.btn_cuentasbanc.Enabled = true;
                this.btn_general.Enabled = true;
                this.btn_almacen.Enabled = true;
                this.btn_oc.Enabled = true;



            }
            else if (usuariologin.IdDepto == 5) //ALMACEN
            {
                #region catalogos
                this.btn_catalogos.Enabled = true;
                this.btn_productosalm.Enabled = true;
                this.btn_proveedores.Enabled = true;
                #endregion

                this.btn_almacen.Enabled = true;
                this.btn_almacenes.Enabled = true;
                this.btn_requisiciones.Enabled = true;
                this.btn_oc.Enabled = true;
                this.btn_pherramientas.Enabled = true;
                this.btn_salidas.Enabled = true;
                this.btn_general.Enabled = true;




            }
            else if (usuariologin.IdDepto == 13) //GESTORIA
            {
                #region catalogos
                this.btn_catalogos.Enabled = true;
                this.btn_unidades.Enabled = true;

                #endregion

                this.btn_gestoria.Enabled = true;
                this.btn_general.Enabled = true;


            }
            else if (usuariologin.IdDepto == 12) //DIESEL
            {
                #region catalogos
                #endregion

                this.btn_diesel.Enabled = true;
                this.btn_general.Enabled = true;

            }
            else if(usuariologin.IdDepto==9)
            {
                this.btn_taller.Enabled = true;
                this.btn_general.Enabled = true;
            }
            else
            {
                this.btn_general.Enabled = true;

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
            AbrirFormPanel(new VUnidades(usuariologin));

        }

        private void btn_emp_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VEmpleados(usuariologin));

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
            AbrirFormPanel(new VSitios(usuariologin));

        }

        private void btn_mapa_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VMapa());

        }

        private void btn_conceptosf_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VConceptosFlujos(usuariologin));

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

        private void btn_snack_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VSnack(usuariologin));

        }

        private void btn_nominas_Click(object sender, EventArgs e)
        {
            button = this.btn_nominas;
            panel = this.pnl_nominas;
            this.tmmenu.Start();
        }

        private void btn_nomgen_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VNomGeneral());

        }

        private void btn_tipounidades_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VTipoUnidades(usuariologin));

        }

        private void btn_gestoria_Click(object sender, EventArgs e)
        {
            button = this.btn_gestoria;
            panel = this.pnl_gestoria;
            this.tmmenu.Start();
        }

        private void btn_polizas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VPolizas(usuariologin));

        }

        private void btn_diesel_Click(object sender, EventArgs e)
        {
            button = this.btn_diesel;
            panel = this.pnl_diesel;
            this.tmmenu.Start();

        }

        private void btn_cortediario_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VCorteDiarios(usuariologin));

        }

        private void btn_bancos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VBancos(usuariologin));

        }

        private void btn_cuentasbanc_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VCuentasBancarias(usuariologin));

        }

        private void btn_almacenes_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VAlmacenes(usuariologin));

        }

        private void btn_productosalm_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VProductosAlmacen(usuariologin));

        }

        private void btn_requisiciones_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VRequisiciones(usuariologin));

        }

        private void btn_gerencia_Click(object sender, EventArgs e)
        {
            button = this.btn_gerencia;
            panel = this.pnl_gerencia;
            this.tmmenu.Start();
        }

        private void btn_reqxautorizar_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VCotxAutorizar(usuariologin));

        }

        private void btn_general_Click(object sender, EventArgs e)
        {
            button = this.btn_general;
            panel = this.pnl_general;
            this.tmmenu.Start();
        }

        private void btn_genreq_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VRequisiciones(usuariologin));

        }

        private void btn_oc_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VOrdenesCompra(usuariologin));

        }

        private void btn_salidas_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VSalidas(usuariologin));

        }

        private void btn_taller_Click(object sender, EventArgs e)
        {
            button = this.btn_taller;
            panel = this.pnl_taller;
            this.tmmenu.Start();
        }

        private void btn_ot_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new VOrdenesTrabajo(usuariologin));

        }
    }
}
