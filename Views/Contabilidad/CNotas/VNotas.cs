using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Wordprocessing;
using GMap.NET;
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
            this.dgrid_notas_creditos.CellContentClick += this.dgrid_notas_creditos_CellContentClick;
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

            var x = from n in db.NotasMovimientos
                    join p in db.Proveedores on n.IdProveedor equals p.IdProveedor
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdNota,
                        n.Folio,
                        p.Proveedor,
                        n.Fecha,
                        n.Concepto,
                        n.Total
                    };
            this.dgrid_notas_creditos.DataSource = x.ToList();
            this.dgrid_notas_creditos.Columns[0].Visible= false;

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.FalseValue = false;
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "CheckBox";
            this.dgrid_notas_creditos.Columns.Add(dgvCmb);

            this.dgrid_notas_creditos.EnableHeadersVisualStyles = false;
            this.dgrid_notas_creditos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.dgrid_notas_creditos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgrid_notas_creditos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            if (txt_filtro.Text != "")
            {
                var filtro = this.cmb_filtro.Text;
                if (filtro == "Fecha")
                {
                    try
                    {
                        var filter = Convert.ToDateTime(this.txt_filtro.Text);
                        var x = from n in db.NotasMovimientos
                                where n.Fecha == filter && n.IdEstatus == 1
                                select new
                                {
                                    n.IdNota,
                                    n.Folio,
                                    n.Fecha,
                                    n.Concepto,
                                    n.Total
                                };
                        this.dgrid_notas_creditos.DataSource = x.ToList();
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
                        var x = from n in db.NotasMovimientos
                                where n.Concepto.Contains(filter) && n.IdEstatus == 1
                                select new
                                {
                                    n.IdNota,
                                    n.Folio,
                                    n.Fecha,
                                    n.Concepto,
                                    n.Total
                                };
                        this.dgrid_notas_creditos.DataSource = x.ToList();
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
                        var x = from n in db.NotasMovimientos
                                where n.Total == filter && n.IdEstatus == 1
                                select new
                                {
                                    n.IdNota,
                                    n.Folio,
                                    n.Fecha,
                                    n.Concepto,
                                    n.Total
                                };
                        this.dgrid_notas_creditos.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else
                {
                    CargarNotas();
                    this.dgrid_notas_creditos.Refresh();
                }
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
                        if(checkBoxCell.Value==null)
                        {
                            checkBoxCell.Value = true;
                        }
                        bool isChecked = (bool)checkBoxCell.Value;
                        checkBoxCell.Value = !isChecked;

                        this.dgrid_notas_creditos.CurrentRow.Selected = true;
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }

        private void PerformActionOnSelectedRows()
        {
            string proveedor = string.Empty;
            foreach (DataGridViewRow row in this.dgrid_notas_creditos.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Chk"] as DataGridViewCheckBoxCell;
                if (checkBoxCell != null && (bool)checkBoxCell.Value)
                {
                    proveedor = row.Cells["Proveedor"].Value.ToString();
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
    }
}
