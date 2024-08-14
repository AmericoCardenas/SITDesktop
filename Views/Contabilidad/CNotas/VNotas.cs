using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using GMap.NET;
using SIT.CrystalReport;
using SIT.Views.Contabilidad.CNotas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Contabilidad.CMovimientos
{
    public partial class VNotas : Form
    {
        public VNotas(Usuarios uslog)
        {
            InitializeComponent();
            this._uslog = uslog;
            this.dgrid_notas_creditos.EnableHeadersVisualStyles = false;
            this.dgrid_notas_creditos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_notas_creditos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_notas_creditos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private int IdUsuario;
        private int IdNota;
        Usuarios _uslog;
        SITEntities db = new SITEntities();
        NotasMovimientos not = new NotasMovimientos();
        Movimientos mov = new Movimientos();
        List<NotasMovimientos>lst_not = new List<NotasMovimientos>();

        private void VNotas_Load(object sender, EventArgs e)
        {
            CargarNotas();
            CargarFiltros();
        }

        private void CargarFiltros()
        {
            foreach(DataGridViewColumn col in this.dgrid_notas_creditos.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        public void CargarNotas()
        {
            DataGridView dgrid = new DataGridView();

            if(this.tbcontrol.SelectedIndex == 0)
            {
                var x = from n in db.NotasMovimientos
                        join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                        where n.IdEstatus == 1
                        select new
                        {
                            n.IdNota,
                            n.Folio,
                            n.FechaFactura,
                            p.RazonSocial,
                            n.FechaPago,
                            n.Concepto,
                            n.Total
                        };
                this.dgrid_notas_creditos.DataSource = null;

                if (this.dgrid_notas_creditos.Columns.Count > 0)
                {
                    this.dgrid_notas_creditos.Columns.Clear();
                }

                DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                dgvCmb.ValueType = typeof(bool);
                dgvCmb.FalseValue = false;
                dgvCmb.TrueValue = true;
                dgvCmb.Name = "Chk";
                dgvCmb.HeaderText = "CheckBox";
                this.dgrid_notas_creditos.Columns.Add(dgvCmb);
                this.dgrid_notas_creditos.DataSource = x.ToList();
                this.dgrid_notas_creditos.Columns["Chk"].DisplayIndex = this.dgrid_notas_creditos.Columns.Count - 1;

            }
            else if (this.tbcontrol.SelectedIndex == 1)
            {
                dgrid = this.dgrid_notas_abonos;
                  dgrid.DataSource = null;
                  dgrid.Rows.Clear();
                  dgrid.Columns.Clear();
                var x = from n in db.NotasMovimientos
                        join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                        where n.IdEstatus == 3
                        select new
                        {
                            n.IdNota,
                            n.Folio,
                            n.FechaFactura,
                            p.RazonSocial,
                            n.FechaPago,
                            n.Concepto,
                            n.Total

                        };
                dgrid.DataSource = x.ToList();

                    
            }


        }

        private void CancelarNota()
        {
            not = db.NotasMovimientos.Where(x => x.IdNota == IdNota).FirstOrDefault();
            not.IdEstatus = 2;
            not.FechaCancelacion = DateTime.Now;
            not.UsuarioCancelacion = IdUsuario;

            if (IdNota > 0)
            {
                db.Entry(not).State = EntityState.Modified;
                MessageBox.Show("Nota cancelada exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarNotas();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar la nota");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar la nota seleccionada", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarNota();

            }
            else
            {
                // Do something
            }
        }

        private void dgrid_notas_Click(object sender, EventArgs e)
        {
            try
            {
  
                if (this.dgrid_notas_creditos.CurrentCell.RowIndex != -1)
                {
                    IdNota = Convert.ToInt32(this.dgrid_notas_creditos.CurrentRow.Cells["IdNota"].Value);
                }

                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            }
            catch(Exception ex)
            {

            }
        }

        private void CargarxFiltro()
        {
            DataGridView dgrid = new DataGridView();
            int idestatus=0;

            if (txt_filtro.Text != "")
            {
                if(this.tbcontrol.SelectedIndex== 0)
                {
                    dgrid = this.dgrid_notas_creditos;
                    idestatus = 1;
                }
                else if(this.tbcontrol.SelectedIndex==1)
                {
                    dgrid = this.dgrid_notas_abonos;
                    idestatus = 3;
                }

                var filtro = this.cmb_filtro.Text;
                if (filtro == "Folio")
                {
                    try
                    {
                        dgrid.DataSource = null;
                        dgrid.Rows.Clear();
                        dgrid.Columns.Clear();
                        var x = from n in db.NotasMovimientos
                                join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                                where n.Folio.Contains(txt_filtro.Text) && n.IdEstatus == idestatus
                                select new
                                {
                                    n.IdNota,
                                    n.Folio,
                                    n.FechaFactura,
                                    p.RazonSocial,
                                    n.FechaPago,
                                    n.Concepto,
                                    n.Total
                                };

                        if (this.tbcontrol.SelectedIndex == 0)
                        {
                            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                            dgvCmb.ValueType = typeof(bool);
                            dgvCmb.FalseValue = false;
                            dgvCmb.TrueValue = true;
                            dgvCmb.Name = "Chk";
                            dgvCmb.HeaderText = "CheckBox";
                            dgrid.Columns.Add(dgvCmb);
                            dgrid.DataSource = x.ToList();
                            dgrid.Columns["Chk"].DisplayIndex = dgrid.Columns.Count - 1;

                        }
                        else
                        {
                            dgrid.DataSource = x.ToList();

                        }



                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "RazonSocial")
                {
                    try
                    {
                        dgrid.DataSource = null;
                        dgrid.Rows.Clear();
                        dgrid.Columns.Clear();
                        var x = from n in db.NotasMovimientos
                                join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                                where p.RazonSocial.Contains(txt_filtro.Text) && n.IdEstatus == idestatus
                                select new
                                {
                                    n.IdNota,
                                    n.Folio,
                                    n.FechaFactura,
                                    p.RazonSocial,
                                    n.FechaPago,
                                    n.Concepto,
                                    n.Total
                                };


                        if (this.tbcontrol.SelectedIndex == 0)
                        {
                            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                            dgvCmb.ValueType = typeof(bool);
                            dgvCmb.FalseValue = false;
                            dgvCmb.TrueValue = true;
                            dgvCmb.Name = "Chk";
                            dgvCmb.HeaderText = "CheckBox";
                            dgrid.Columns.Add(dgvCmb);
                            dgrid.DataSource = x.ToList();
                            dgrid.Columns["Chk"].DisplayIndex = dgrid.Columns.Count - 1;

                        }
                        else
                        {
                            dgrid.DataSource = x.ToList();

                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "FechaFactura")
                {
                    try
                    {
                        var filter = Convert.ToDateTime(this.txt_filtro.Text);
                        dgrid.DataSource = null;
                        dgrid.Rows.Clear();
                        dgrid.Columns.Clear();
                        var x = from n in db.NotasMovimientos
                                join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                                where n.FechaFactura == filter && n.IdEstatus == idestatus
                                select new
                                {
                                    n.IdNota,
                                    n.Folio,
                                    n.FechaFactura,
                                    p.RazonSocial,
                                    n.FechaPago,
                                    n.Concepto,
                                    n.Total
                                };


                        if (this.tbcontrol.SelectedIndex == 0)
                        {
                            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                            dgvCmb.ValueType = typeof(bool);
                            dgvCmb.FalseValue = false;
                            dgvCmb.TrueValue = true;
                            dgvCmb.Name = "Chk";
                            dgvCmb.HeaderText = "CheckBox";
                            dgrid.Columns.Add(dgvCmb);
                            dgrid.DataSource = x.ToList();
                            dgrid.Columns["Chk"].DisplayIndex = dgrid.Columns.Count - 1;

                        }
                        else
                        {
                            dgrid.DataSource = x.ToList();

                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Concepto")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        dgrid.DataSource = null;
                        dgrid.Rows.Clear();
                        dgrid.Columns.Clear();
                        var x = from n in db.NotasMovimientos
                                join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                                where n.Concepto.Contains(filter) && n.IdEstatus == idestatus
                                select new
                                {
                                    n.IdNota,
                                    n.Folio,
                                    n.FechaFactura,
                                    p.RazonSocial,
                                    n.FechaPago,
                                    n.Concepto,
                                    n.Total

                                };


                        if (this.tbcontrol.SelectedIndex == 0)
                        {
                            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                            dgvCmb.ValueType = typeof(bool);
                            dgvCmb.FalseValue = false;
                            dgvCmb.TrueValue = true;
                            dgvCmb.Name = "Chk";
                            dgvCmb.HeaderText = "CheckBox";
                            dgrid.Columns.Add(dgvCmb);
                            dgrid.DataSource = x.ToList();
                            dgrid.Columns["Chk"].DisplayIndex = dgrid.Columns.Count - 1;

                        }
                        else
                        {
                            dgrid.DataSource = x.ToList();

                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "Total")
                {
                    try
                    {
                        var filter = Convert.ToDouble(this.txt_filtro.Text);
                        dgrid.DataSource = null;
                        dgrid.Rows.Clear();
                        dgrid.Columns.Clear();
                        var x = from n in db.NotasMovimientos
                                join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                                where n.Total == filter && n.IdEstatus == idestatus
                                select new
                                {
                                    n.IdNota,
                                    n.Folio,
                                    n.FechaFactura,
                                    p.RazonSocial,
                                    n.FechaPago,
                                    n.Concepto,
                                    n.Total
                                };


                        if (this.tbcontrol.SelectedIndex == 0)
                        {
                            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
                            dgvCmb.ValueType = typeof(bool);
                            dgvCmb.FalseValue = false;
                            dgvCmb.TrueValue = true;
                            dgvCmb.Name = "Chk";
                            dgvCmb.HeaderText = "CheckBox";
                            dgrid.Columns.Add(dgvCmb);
                            dgrid.DataSource = x.ToList();
                            dgrid.Columns["Chk"].DisplayIndex = dgrid.Columns.Count - 1;

                        }
                        else
                        {
                            dgrid.DataSource = x.ToList();

                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else
                {
                    CargarNotas();
                    dgrid.Refresh();
                }
            }
            else
            {
                CargarNotas();
            }

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AENotas frm = new AENotas(this);
            frm.IdNota = IdNota;
            frm.IdUsuario = this.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void dgrid_notas_creditos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex != -1) // Check if the checkbox column is clicked
                {
                    DataGridViewCheckBoxCell checkBoxCell = this.dgrid_notas_creditos.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
                    if (checkBoxCell != null)
                    {


                        if (checkBoxCell.Value == null)
                        {
                            checkBoxCell.Value = false;
                        }

                        bool isChecked = (bool)checkBoxCell.Value;
                            checkBoxCell.Value = !isChecked;

                        

                        this.dgrid_notas_creditos.CurrentRow.Selected = true;
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PerformActionOnSelectedRows()
        {
            string proveedor = string.Empty;
            foreach (DataGridViewRow row in this.dgrid_notas_creditos.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Chk"] as DataGridViewCheckBoxCell;
                if(checkBoxCell.Value == null)
                {
                    checkBoxCell.Value = false;
                }
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {
                    proveedor = row.Cells["RazonSocial"].Value.ToString();
                    lst_not.Add(new NotasMovimientos
                    {
                        IdNota = Convert.ToInt32(row.Cells["IdNota"].Value.ToString()),
                        Folio = row.Cells["Folio"].Value.ToString(),
                        Total = Convert.ToDouble(row.Cells["Total"].Value.ToString()),

                    });
                    Debug.WriteLine(row.Cells["IdNota"].Value.ToString());               
                }
            }

            AEMovimiento frm = new AEMovimiento(this);
            frm.IdMovimiento = 0;
            frm._uslog = _uslog;
            frm.notaproveedor = proveedor;
            frm.lst_not = this.lst_not;
            this.Enabled = false;
            frm.Show();

            //AGREGAR MOVIMIENTO

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformActionOnSelectedRows();
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNotas();
            if (this.tbcontrol.SelectedIndex == 0)
            {
                this.btn_movs.Visible = true;
            }
            else if(this.tbcontrol.SelectedIndex == 1)
            {
                this.btn_movs.Visible= false;
            }
        }

        private void dgrid_notas_abonos_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.dgrid_notas_abonos.CurrentCell.RowIndex != -1)
                {
                    IdNota = Convert.ToInt32(this.dgrid_notas_abonos.CurrentRow.Cells["IdNota"].Value);
                }

                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.frm = this;
            frm.ShowDialog();
        }
    }
}
