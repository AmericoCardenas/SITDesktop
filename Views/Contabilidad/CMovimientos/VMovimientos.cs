using SIT.Views.Contabilidad.CMovimientos;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Contabilidad
{
    public partial class VMovimientos : Form
    {
        public VMovimientos(Usuarios usuarioslog)
        {
            InitializeComponent();
            this._uslog = usuarioslog;
        }

        SITEntities db = new SITEntities();
        Usuarios _uslog;
        DataGridView dgrid;
        Movimientos mov = new Movimientos();
        OpenFileDialog op1 = new OpenFileDialog();
        private int IdMovimiento=0;
        string filename = string.Empty;
        string ruta = "\\\\192.168.1.213\\OneDrive - TRANSPORTES DAVILA\\Transportes Davila\\7.- Contabilidad1\\ArchivosMovimientos\\";


        private void VMovimientos_Load(object sender, EventArgs e)
        {
            this.tbcontrol.SelectedIndex = 0;
            CargarMovimientos();
            CargarFiltros();
        }

        public void CargarMovimientos()
        {
            if (this.tbcontrol.SelectedIndex == 0)
            {
                var x = from m in db.Movimientos
                        join tf in db.TiposFlujos on m.IdTipo equals tf.IdTipo
                        join mt in db.MetodosFlujos on m.IdMetodo equals mt.IdMetodo
                        join co in db.ConceptosFlujos on m.IdConcepto equals co.IdConcepto
                        where m.IdTipo == 1 && m.IdEstatus == 1
                        orderby m.IdMovimiento descending
                        select new
                        {
                            m.IdMovimiento,
                            m.Fecha,
                            mt.Metodo,
                            m.Cliente,
                            m.Descripcion,
                            m.Cantidad,
                            m.Comprobante,
                            tf.Tipo

                        };
                dgrid = this.dgrid_egreso;
                dgrid.DataSource = x.ToList();
            }
            else if (this.tbcontrol.SelectedIndex == 1)
            {
                var x = from m in db.Movimientos
                        join tf in db.TiposFlujos on m.IdTipo equals tf.IdTipo
                        join mt in db.MetodosFlujos on m.IdMetodo equals mt.IdMetodo
                        join co in db.ConceptosFlujos on m.IdConcepto equals co.IdConcepto
                        where m.IdTipo == 2 && m.IdEstatus == 1
                        orderby m.IdMovimiento descending
                        select new
                        {
                            m.IdMovimiento,
                            m.Fecha,
                            mt.Metodo,
                            m.Cliente,
                            m.Descripcion,
                            m.Cantidad,
                            m.Comprobante,
                            tf.Tipo

                        };

                dgrid = this.dgrid_ingreso;
                dgrid.DataSource = x.ToList();
            }

            dgrid.Columns[0].Visible = false;
            dgrid.Columns[7].Visible = false;

            dgrid.Columns["Comprobante"].Visible = false;

            dgrid.EnableHeadersVisualStyles = false;
            dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgrid.Refresh();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEMovimiento frm = new AEMovimiento(this);
            frm.IdMovimiento = IdMovimiento;
            frm._uslog = this._uslog;
            this.Enabled = false;
            frm.Show();
        }

        private void dgrid_ingreso_Click(object sender, EventArgs e)
        {
            if (this.dgrid_egreso.CurrentCell.RowIndex != -1)
            {
                IdMovimiento = Convert.ToInt32(this.dgrid_egreso.CurrentRow.Cells["IdMovimiento"].Value);

            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void dgrid_egreso_Click(object sender, EventArgs e)
        {
            if (this.dgrid_ingreso.CurrentCell.RowIndex != -1)
            {
                IdMovimiento = Convert.ToInt32(this.dgrid_ingreso.CurrentRow.Cells["IdMovimiento"].Value);

            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el movimiento seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarMovimiento();

            }
            else
            {
                // Do something
            }
        }

        private void CancelarMovimiento()
        {
            mov = db.Movimientos.Where(x => x.IdMovimiento == IdMovimiento).FirstOrDefault();
            mov.IdEstatus = 2;
            mov.FechaCancelacion = DateTime.Now;
            mov.IdUsuarioCancelacion = _uslog.IdUsuario;

            if (IdMovimiento > 0)
            {
                db.Entry(mov).State = EntityState.Modified;
                MessageBox.Show("Movimiento cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarMovimientos();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar movimiento");
            }

        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid.Columns)
            {
                if (col.Index != 0 && col.Name != "Comprobante" && col.Name != "Ruta" && col.Name!="Tipo")
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }
            }

            this.cmb_filtro.SelectedIndex = 0;
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarMovimientos();
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarxFiltro();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void CargarxFiltro()
        {
            int tipo = 0;
            dgrid = new DataGridView();
            if (this.tbcontrol.SelectedIndex == 0)
            {
                dgrid = this.dgrid_egreso;
                tipo = 1;
            }
            else if (this.tbcontrol.SelectedIndex == 1)
            {
                dgrid = this.dgrid_ingreso;
                tipo = 2;
            }
            var filtro = this.cmb_filtro.Text;

            if (this.txt_filtro.Text == "")
            {
                CargarMovimientos();
            }
            else
            {
                if (filtro == "Fecha")
                {
                    try
                    {
                        var filter = Convert.ToDateTime(this.txt_filtro.Text);
                        var x = from m in db.Movimientos
                                join tf in db.TiposFlujos on m.IdTipo equals tf.IdTipo
                                join mt in db.MetodosFlujos on m.IdMetodo equals mt.IdMetodo
                                join co in db.ConceptosFlujos on m.IdConcepto equals co.IdConcepto
                                where m.Fecha == filter && m.IdTipo == tipo && m.IdEstatus == 1
                                orderby m.IdMovimiento descending
                                select new
                                {
                                    m.IdMovimiento,
                                    m.Fecha,
                                    mt.Metodo,
                                    m.Cliente,
                                    m.Descripcion,
                                    m.Cantidad,
                                    m.Comprobante,
                                    tf.Tipo
                                };
                        dgrid.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "Metodo")
                {
                    var filter = this.txt_filtro.Text;
                    var x = from m in db.Movimientos
                            join tf in db.TiposFlujos on m.IdTipo equals tf.IdTipo
                            join mt in db.MetodosFlujos on m.IdMetodo equals mt.IdMetodo
                            join co in db.ConceptosFlujos on m.IdConcepto equals co.IdConcepto
                            where mt.Metodo.Contains(filter) && m.IdTipo == tipo && m.IdEstatus == 1
                            orderby m.IdMovimiento descending
                            select new
                            {
                                m.IdMovimiento,
                                m.Fecha,
                                mt.Metodo,
                                m.Cliente,
                                m.Descripcion,
                                m.Cantidad,
                                m.Comprobante,
                                tf.Tipo
                            };
                    dgrid.DataSource = x.ToList();

                }
                else if (filtro == "Cliente")
                {
                    var filter = this.txt_filtro.Text;
                    var x = from m in db.Movimientos
                            join tf in db.TiposFlujos on m.IdTipo equals tf.IdTipo
                            join mt in db.MetodosFlujos on m.IdMetodo equals mt.IdMetodo
                            join co in db.ConceptosFlujos on m.IdConcepto equals co.IdConcepto
                            where m.Cliente.Contains(filter) && m.IdTipo == tipo && m.IdEstatus == 1
                            orderby m.IdMovimiento descending
                            select new
                            {
                                m.IdMovimiento,
                                m.Fecha,
                                mt.Metodo,
                                m.Cliente,
                                m.Descripcion,
                                m.Cantidad,
                                m.Comprobante,
                                tf.Tipo
                            };
                    dgrid.DataSource = x.ToList();

                }
                else if (filtro == "Descripcion")
                {
                    var filter = this.txt_filtro.Text;
                    var x = from m in db.Movimientos
                            join tf in db.TiposFlujos on m.IdTipo equals tf.IdTipo
                            join mt in db.MetodosFlujos on m.IdMetodo equals mt.IdMetodo
                            join co in db.ConceptosFlujos on m.IdConcepto equals co.IdConcepto
                            where m.Descripcion.Contains(filter) && m.IdTipo == tipo && m.IdEstatus == 1
                            orderby m.IdMovimiento descending
                            select new
                            {
                                m.IdMovimiento,
                                m.Fecha,
                                mt.Metodo,
                                m.Cliente,
                                m.Descripcion,
                                m.Cantidad,
                                m.Comprobante,
                                tf.Tipo

                            };
                    dgrid.DataSource = x.ToList();


                }
                else if (filtro == "Cantidad")
                {
                    try
                    {
                        var filter = Convert.ToDouble(this.txt_filtro.Text);
                        var x = from m in db.Movimientos
                                join tf in db.TiposFlujos on m.IdTipo equals tf.IdTipo
                                join mt in db.MetodosFlujos on m.IdMetodo equals mt.IdMetodo
                                join co in db.ConceptosFlujos on m.IdConcepto equals co.IdConcepto
                                where m.Cantidad == filter && m.IdTipo == tipo && m.IdEstatus == 1
                                orderby m.IdMovimiento descending
                                select new
                                {
                                    m.IdMovimiento,
                                    m.Fecha,
                                    mt.Metodo,
                                    m.Cliente,
                                    m.Descripcion,
                                    m.Cantidad,
                                    m.Comprobante,
                                    tf.Tipo
                                };

                        dgrid.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }


                }

            }
            dgrid.Columns[0].Visible = false;
            dgrid.Columns[7].Visible = false;
            dgrid.Columns["Comprobante"].Visible = false;
            dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgrid_ingreso_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_ingreso.CurrentCell.RowIndex != -1)
                {
                    var archivo = this.dgrid_ingreso.CurrentRow.Cells["Comprobante"].Value.ToString();
                    if (archivo == null)
                    {

                    }
                    else
                    {
                        System.Diagnostics.Process.Start(ruta + archivo);

                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgrid_egreso_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_egreso.CurrentCell.RowIndex != -1)
                {
                    var archivo = this.dgrid_egreso.CurrentRow.Cells["Comprobante"].Value.ToString();
                    if (archivo == null)
                    {

                    }
                    else
                    {

                        System.Diagnostics.Process.Start(ruta + archivo);

                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_saldoactual_Click(object sender, EventArgs e)
        {
            ConsultarSaldoActual();
        }

        private void ConsultarSaldoActual()
        {
            VSaldoActual frm = new VSaldoActual();
            frm.Show();
        }

        private void ExportarExcel()
        {
            DataGridView dgrid = new DataGridView();
            int x, z = 0;
            SLDocument sl = new SLDocument();
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            downloadPath = System.IO.Path.Combine(downloadPath, "Documents");


            if (this.tbcontrol.SelectedIndex == 0)
            {
                dgrid = this.dgrid_egreso;

            }
            else if (this.tbcontrol.SelectedIndex == 1)
            {
                dgrid = this.dgrid_ingreso;
            }

            try
            {

                for (int i = 0; i < dgrid.Columns.Count; i++)
                {
                    sl.SetCellValue(1, i + 1, dgrid.Columns[i].HeaderText);
                }


                for (x = 0; x < dgrid.Rows.Count; x++)
                {
                    for (z = 0; z < dgrid.Columns.Count; z++)
                    {
                        DataGridViewCell cell = dgrid.Rows[x].Cells[z];
                        if (cell.Value != null)
                        {
                            sl.SetCellValue(x + 2, z + 1, cell.Value.ToString());

                        }
                        else
                        {

                        }
                    }
                }


                sl.AutoFitColumn(1, stats.EndColumnIndex);

                // Save the Excel file
                sl.SaveAs(downloadPath + "\\Movimientos" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                MessageBox.Show("Archivo exportado en " + downloadPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_saldoxfecha_Click(object sender, EventArgs e)
        {
            VSaldoxFecha frm  = new VSaldoxFecha();
            frm.Show();
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }


    }
}
