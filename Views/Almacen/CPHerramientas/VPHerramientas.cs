using SIT.Views.Almacen.PHerramientas;
using SIT.Views.Contabilidad.CNotas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Almacen
{
    public partial class VPHerramientas : Form
    {
        public VPHerramientas(Usuarios uslog)
        {
            InitializeComponent();
            this._uslog= uslog;
        }

        SITEntities db = new SITEntities();
        PrestamoHerramientas ph = new PrestamoHerramientas();
        int IdPrestamo=0;
        Usuarios _uslog;

        public void CargarDatos()
        {
            DataGridView dgrid = new DataGridView();

            if (this.tbcontrol.SelectedIndex == 0)
            {
                dgrid = this.dgrid_herramientas_pendientes;
                dgrid.DataSource = null;
                dgrid.Rows.Clear();
                dgrid.Columns.Clear();
                var x = from n in db.PrestamoHerramientas
                        join p in db.Trabajadores on n.IdEmpleado equals p.IdEmpleado
                        join h in db.Herramientas on n.IdHerramienta equals h.IdHerramienta
                        where n.IdEstatus == 1
                        select new
                        {
                            n.IdPrestamo,
                            n.Fecha,
                            n.Hora,
                            h.Herramienta,
                            n.Cantidad,
                            p.NombreCompleto
                        };
                dgrid.DataSource = x.ToList();

            }
            else if (this.tbcontrol.SelectedIndex == 1)
            {
                dgrid = this.dgrid_herramientas_entregados;
                dgrid.DataSource = null;
                dgrid.Rows.Clear();
                dgrid.Columns.Clear();
                var x = from n in db.PrestamoHerramientas
                        join p in db.Trabajadores on n.IdEmpleado equals p.IdEmpleado
                        join h in db.Herramientas on n.IdHerramienta equals h.IdHerramienta
                        where n.IdEstatus == 2
                        select new
                        {
                            n.IdPrestamo,
                            n.Fecha,
                            n.Hora,
                            h.Herramienta,
                            n.Cantidad,
                            p.NombreCompleto
                        };
                dgrid.DataSource = x.ToList();

            }

            dgrid.Columns[0].Visible = false;

            dgrid.EnableHeadersVisualStyles = false;
            dgrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
            dgrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CancelarHerramienta()
        {
            ph = db.PrestamoHerramientas.Where(x => x.IdPrestamo == IdPrestamo).FirstOrDefault();
            ph.IdEstatus = 3;
            ph.FechaCancelacion = DateTime.Now;
            ph.IdUsuarioCancelacion = _uslog.IdUsuario;

            if (IdPrestamo > 0)
            {
                db.Entry(ph).State = EntityState.Modified;
                MessageBox.Show("Cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el prestamo a cancelar");
            }
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_herramientas_pendientes.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        private void dgrid_herramientas_pendientes_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgrid_herramientas_pendientes.CurrentCell.RowIndex != -1)
                {
                    IdPrestamo = Convert.ToInt32(this.dgrid_herramientas_pendientes.CurrentRow.Cells["IdPrestamo"].Value);
                }

                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }

        private void dgrid_herramientas_entregados_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgrid_herramientas_entregados.CurrentCell.RowIndex != -1)
                {
                    IdPrestamo = Convert.ToInt32(this.dgrid_herramientas_entregados.CurrentRow.Cells["IdPrestamo"].Value);
                }

                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void VPHerramientas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CargarFiltros();
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void CargarxFiltro()
        {
            DataGridView dgrid = new DataGridView();
            int estatus = 0;

            if (this.tbcontrol.SelectedIndex == 0)
            {
                dgrid = this.dgrid_herramientas_pendientes;
                estatus = 1;
            }
            else if (this.tbcontrol.SelectedIndex == 1)
            {
                dgrid = this.dgrid_herramientas_entregados;
                estatus = 2;
            }

            if (txt_filtro.Text != "")
            {

                var filtro = this.cmb_filtro.Text;
                if (filtro == "Fecha")
                {
                    try
                    {
                        var filter = Convert.ToDateTime(this.txt_filtro.Text);
                        var x = from n in db.PrestamoHerramientas
                                join p in db.Trabajadores on n.IdEmpleado equals p.IdEmpleado
                                join h in db.Herramientas on n.IdHerramienta equals h.IdHerramienta
                                where n.IdEstatus == estatus && n.Fecha==filter
                                select new
                                {
                                    n.IdPrestamo,
                                    n.Fecha,
                                    n.Hora,
                                    h.Herramienta,
                                    n.Cantidad,
                                    p.NombreCompleto
                                };
                        dgrid.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Herramienta")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from n in db.PrestamoHerramientas
                                join p in db.Trabajadores on n.IdEmpleado equals p.IdEmpleado
                                join h in db.Herramientas on n.IdHerramienta equals h.IdHerramienta
                                where n.IdEstatus == estatus && h.Herramienta.Contains(filter)
                                select new
                                {
                                    n.IdPrestamo,
                                    n.Fecha,
                                    n.Hora,
                                    h.Herramienta,
                                    n.Cantidad,
                                    p.NombreCompleto
                                };
                       dgrid.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "NombreCompleto")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from n in db.PrestamoHerramientas
                                join p in db.Trabajadores on n.IdEmpleado equals p.IdEmpleado
                                join h in db.Herramientas on n.IdHerramienta equals h.IdHerramienta
                                where n.IdEstatus == estatus && p.NombreCompleto.Contains(filter)
                                select new
                                {
                                    n.IdPrestamo,
                                    n.Fecha,
                                    n.Hora,
                                    h.Herramienta,
                                    n.Cantidad,
                                    p.NombreCompleto
                                };
                        dgrid.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else
                {
                    CargarDatos();
                    dgrid.Refresh();
                }
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEPHerramienta frm = new AEPHerramienta(this);
            frm.IdPrestamo = IdPrestamo;
            frm.IdUsuario = this._uslog.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar?", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarHerramienta();
            }
            else
            {
                // Do something
            }
        }
    }
}
