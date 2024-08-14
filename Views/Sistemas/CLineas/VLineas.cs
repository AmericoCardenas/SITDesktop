using SIT.CrystalReport;
using SIT.Views.Sistemas.CLineas;
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

namespace SIT.Views.Sistemas
{
    public partial class VLineas : Form
    {
        public VLineas(Usuarios usuariolog)
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();
        Lineas lineas = new Lineas();
        int IdLinea = 0;

        private void VLineas_Load(object sender, EventArgs e)
        {
            CargarLineas();
            CargarFiltros();

            this.dgrid_lineas.EnableHeadersVisualStyles = false;
            this.dgrid_lineas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_lineas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_lineas.Columns)
            {
                if (col.Index != 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }
            }

            this.cmb_filtro.SelectedIndex = 0;
        }

        public void CargarLineas()
        {
            var lineas = from l in db.Lineas
                         join e in db.EstatusLineas on l.IdEstatus equals e.IdEstatus
                         join p in db.Proveedores on l.IdProveedor equals p.IdProveedor
                         join t in db.Trabajadores on l.IdEmpleado equals t.IdEmpleado
                         select new
                         {
                             IdLinea = l.IdLinea,
                             Linea = l.Linea,
                             SIM = l.NumSim,
                             Proveedor = p.Proveedor,
                             Estatus = e.Estatus,
                             Empleado = t.NombreCompleto
                         };
        
            this.dgrid_lineas.DataSource = lineas.ToList();

            foreach(DataGridViewColumn col in this.dgrid_lineas.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dgrid_lineas.Columns["IdLinea"].Visible= false;
        }

        private void CargarxLinea()
        {

            var filtro = this.cmb_filtro.Text;

            if (this.txt_filtro.Text == "")
            {
                CargarLineas();
            }
            else
            {
                if (filtro == "Linea")
                {
                    try
                    {
                        var lineas = from l in db.Lineas
                                     join e in db.EstatusLineas on l.IdEstatus equals e.IdEstatus
                                     join p in db.Proveedores on l.IdProveedor equals p.IdProveedor
                                     join t in db.Trabajadores on l.IdEmpleado equals t.IdEmpleado
                                     where l.Linea.Contains(this.txt_filtro.Text)
                                     select new
                                     {
                                         IdLinea = l.IdLinea,
                                         Linea = l.Linea,
                                         SIM = l.NumSim,
                                         Proveedor = p.Proveedor,
                                         Estatus = e.Estatus,
                                         Empleado = t.NombreCompleto
                                     };

                        this.dgrid_lineas.DataSource = lineas.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Proveedor")
                {
                    try
                    {
                        var lineas = from l in db.Lineas
                                     join e in db.EstatusLineas on l.IdEstatus equals e.IdEstatus
                                     join p in db.Proveedores on l.IdProveedor equals p.IdProveedor
                                     join t in db.Trabajadores on l.IdEmpleado equals t.IdEmpleado
                                     where p.Proveedor.Contains(this.txt_filtro.Text)
                                     select new
                                     {
                                         IdLinea = l.IdLinea,
                                         Linea = l.Linea,
                                         SIM = l.NumSim,
                                         Proveedor = p.Proveedor,
                                         Estatus = e.Estatus,
                                         Empleado = t.NombreCompleto
                                     };

                        this.dgrid_lineas.DataSource = lineas.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "SIM")
                {
                    try
                    {
                        var lineas = from l in db.Lineas
                                     join e in db.EstatusLineas on l.IdEstatus equals e.IdEstatus
                                     join p in db.Proveedores on l.IdProveedor equals p.IdProveedor
                                     join t in db.Trabajadores on l.IdEmpleado equals t.IdEmpleado
                                     where l.NumSim.Contains(this.txt_filtro.Text)
                                     select new
                                     {
                                         IdLinea = l.IdLinea,
                                         Linea = l.Linea,
                                         SIM = l.NumSim,
                                         Proveedor = p.Proveedor,
                                         Estatus = e.Estatus,
                                         Empleado = t.NombreCompleto
                                     };

                        this.dgrid_lineas.DataSource = lineas.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Estatus")
                {
                    try
                    {
                        var lineas = from l in db.Lineas
                                     join e in db.EstatusLineas on l.IdEstatus equals e.IdEstatus
                                     join p in db.Proveedores on l.IdProveedor equals p.IdProveedor
                                     join t in db.Trabajadores on l.IdEmpleado equals t.IdEmpleado
                                     where e.Estatus.Contains(this.txt_filtro.Text)
                                     select new
                                     {
                                         IdLinea = l.IdLinea,
                                         Linea = l.Linea,
                                         SIM = l.NumSim,
                                         Proveedor = p.Proveedor,
                                         Estatus = e.Estatus,
                                         Empleado = t.NombreCompleto
                                     };

                        this.dgrid_lineas.DataSource = lineas.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Empleado")
                {
                    try
                    {
                        var lineas = from l in db.Lineas
                                     join e in db.EstatusLineas on l.IdEstatus equals e.IdEstatus
                                     join p in db.Proveedores on l.IdProveedor equals p.IdProveedor
                                     join t in db.Trabajadores on l.IdEmpleado equals t.IdEmpleado
                                     where t.NombreCompleto.Contains(this.txt_filtro.Text)
                                     select new
                                     {
                                         IdLinea = l.IdLinea,
                                         Linea = l.Linea,
                                         SIM = l.NumSim,
                                         Proveedor = p.Proveedor,
                                         Estatus = e.Estatus,
                                         Empleado = t.NombreCompleto
                                     };

                        this.dgrid_lineas.DataSource = lineas.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }

                foreach (DataGridViewColumn col in this.dgrid_lineas.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                this.dgrid_lineas.Columns["IdLinea"].Visible = false;
            }
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            AELinea frm = new AELinea(this);
            frm.idLinea = IdLinea;
            this.Enabled = false;
            frm.Show();
        }

        private void dgrid_lineas_Click(object sender, EventArgs e)
        {
            if (this.dgrid_lineas.CurrentCell.RowIndex != -1)
            {
                IdLinea = Convert.ToInt32(this.dgrid_lineas.CurrentRow.Cells["IdLinea"].Value);

            }

            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            try
            {          
              CargarxLinea();
        
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        private void dgrid_lineas_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            string estatus = this.dgrid_lineas.Rows[e.RowIndex].Cells["Estatus"].Value.ToString();
            if (estatus == "ASIGNADA")
            {
                this.dgrid_lineas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            else if (estatus == "ROBO / EXTRAVIO")
            {
                this.dgrid_lineas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else if (estatus == "SUSPENDIDA")
            {
                this.dgrid_lineas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Purple;
            }
            else if (estatus == "DISPONIBLE")
            {
                this.dgrid_lineas.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.frm = this;
            frm.idlinea = Convert.ToInt32(this.dgrid_lineas.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
