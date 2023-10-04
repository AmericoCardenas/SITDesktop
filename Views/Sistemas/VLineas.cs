using SIT.CrystalReport;
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
            CargarProveedores();
            CargarEstatus();
            CargarEmpleados();
            CargarFiltros();
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

        private void CargarLineas()
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
            InsertarLinea();
        }

        private void CargarProveedores()
        {
            var proveedores = db.Proveedores.ToList();
            this.cmb_prov.DataSource = proveedores;
            this.cmb_prov.DisplayMember = "Proveedor";
            this.cmb_prov.ValueMember = "IdProveedor";

        }

        private void CargarEstatus()
        {
            var estatus = db.EstatusLineas.ToList();
            this.cmb_estatus.DataSource = estatus;
            this.cmb_estatus.DisplayMember = "Estatus";
            this.cmb_estatus.ValueMember = "IdEstatus";
        }

        private void InsertarLinea()
        {
            if (this.txt_linea.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar la linea");
            }
            else if (this.txt_sim.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el numero de simcard");
            }
            else if (this.cmb_prov.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el proveedor");
            }
            else if (this.cmb_emp.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
            }
            else
            {
                lineas.Linea = this.txt_linea.Text;
                lineas.NumSim = this.txt_sim.Text;
                lineas.IdProveedor = Convert.ToInt32(this.cmb_prov.SelectedValue);
                lineas.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                lineas.IdEstatus = Convert.ToInt32(this.cmb_estatus.SelectedValue);

                if (IdLinea > 0)
                {
                    db.Entry(lineas).State = EntityState.Modified;
                    MessageBox.Show("Linea actualizado exitosamente");

                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    //this.btn_delete.Visible = false;
                }
                else
                {
                    db.Lineas.Add(lineas);
                    MessageBox.Show("Linea agregada exitosamente");

                }

                db.SaveChanges();
                CargarLineas();

            }
        }

        private void CargarEmpleados()
        {
            var empleados = db.Trabajadores.ToList();
            this.cmb_emp.DataSource = empleados;
            this.cmb_emp.DisplayMember = "NombreCompleto";
            this.cmb_emp.ValueMember = "IdEmpleado";
        }

        private void dgrid_lineas_Click(object sender, EventArgs e)
        {
            if (this.dgrid_lineas.CurrentCell.RowIndex != -1)
            {
                IdLinea = Convert.ToInt32(this.dgrid_lineas.CurrentRow.Cells["IdLinea"].Value);
                lineas = db.Lineas.Where(x => x.IdLinea == IdLinea).FirstOrDefault();
                this.txt_linea.Text = lineas.Linea.ToString();
                this.txt_sim.Text = lineas.NumSim;
                this.cmb_prov.SelectedValue = lineas.IdProveedor;
                this.cmb_estatus.SelectedValue = lineas.IdEstatus;
                this.cmb_emp.SelectedValue = lineas.IdEmpleado;
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
