using SIT.CrystalReport;
using SIT.Views.Catalogos;
using SIT.Views.Contabilidad.CFlujos;
using SIT.Views.Contabilidad.CMovimientos;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Contabilidad
{
    public partial class VFlujos : Form
    {
        public VFlujos(Usuarios usuariolog)
        {
            InitializeComponent();
            this._uslog = usuariolog;
        }

        SITEntities db = new SITEntities();
        Flujos flujos = new Flujos();
        DataGridView dgrid;
        int IdFlujo = 0;
        Usuarios _uslog;
        string ruta = "\\\\192.168.1.213\\OneDrive - TRANSPORTES DAVILA\\Transportes Davila\\7.- Contabilidad1\\ArchivosFlujos\\";


        public void CargarFlujos()
        {
            if (this.tbcontrol.SelectedIndex == 0)
            {
                var x = from f in db.Flujos
                        join tf in db.TiposFlujos on f.IdTipo equals tf.IdTipo
                        join m in db.MetodosFlujos on f.IdMetodo equals m.IdMetodo
                        join t in db.Trabajadores on f.IdEmpleado equals t.IdEmpleado
                        join d in db.Departamentos on f.IdDepto equals d.IdDepto
                        where f.IdTipo==1 && f.IdEstatus==1
                        orderby f.IdFlujo descending
                        select new
                        {
                            f.IdFlujo,
                            f.Fecha,
                            tf.Tipo,
                            m.Metodo,
                            t.NombreCompleto,
                            f.Descripcion,
                            f.Cantidad,
                            f.Comprobante

                        };
                dgrid = this.dgrid_egreso;
                dgrid.DataSource = x.ToList();
            }
            else if(this.tbcontrol.SelectedIndex == 1)
            {
                var x = from f in db.Flujos
                        join tf in db.TiposFlujos on f.IdTipo equals tf.IdTipo
                        join m in db.MetodosFlujos on f.IdMetodo equals m.IdMetodo
                        join t in db.Trabajadores on f.IdEmpleado equals t.IdEmpleado
                        join d in db.Departamentos on f.IdDepto equals d.IdDepto
                        where f.IdTipo == 2 && f.IdEstatus == 1
                        orderby f.IdFlujo descending
                        select new
                        {
                            f.IdFlujo,
                            f.Fecha,
                            tf.Tipo,
                            m.Metodo,
                            t.NombreCompleto,
                            f.Descripcion,
                            f.Cantidad,
                            f.Comprobante


                        };

                dgrid = this.dgrid_ingreso;
                dgrid.DataSource = x.ToList();
            }

            dgrid.Columns[0].Visible = false;
            dgrid.Columns[2].Visible = false;
            dgrid.Columns["Comprobante"].Visible = false;
            dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgrid.EnableHeadersVisualStyles = false;
            dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void VFlujos_Load(object sender, EventArgs e)
        {
            CargarFlujos();
            CargarFiltros();
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFlujos();
        }

        private void CancelarFlujo()
        {
            flujos.IdEstatus = 2;
            flujos.FechaCancelacion=DateTime.Now;
            flujos.IdUsuarioCancelo = _uslog.IdUsuario;

            if (IdFlujo > 0)
            {
                db.Entry(flujos).State = EntityState.Modified;
                MessageBox.Show("Flujo cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarFlujos();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar flujo");
            }
        }

        private void btn_canc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el flujo seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarFlujo();

            }
            else
            {
                // Do something
            }
        }

        private void dgrid_egreso_Click(object sender, EventArgs e)
        {
            if (this.dgrid_egreso.CurrentCell.RowIndex != -1)
            {
                IdFlujo = Convert.ToInt32(this.dgrid_egreso.CurrentRow.Cells["IdFlujo"].Value);
                flujos = db.Flujos.Where(x => x.IdFlujo == IdFlujo).FirstOrDefault();

                //this.dtm_fecha.Value = flujos.Fecha.Value;
                //this.cmb_tipo.SelectedValue = flujos.IdTipo;
                //this.cmb_metodo.SelectedValue = flujos.IdMetodo;
                //this.cmb_empleado.SelectedValue = flujos.IdEmpleado;
                //this.cmb_area.SelectedValue = flujos.IdDepto;
                //this.txt_concepto.Text = flujos.Descripcion;
                //this.txt_cantidad.Text = flujos.Cantidad.ToString();
                //filename = flujos.Comprobante;
            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void dgrid_ingreso_Click(object sender, EventArgs e)
        {
            if (this.dgrid_ingreso.CurrentCell.RowIndex != -1)
            {
                IdFlujo = Convert.ToInt32(this.dgrid_ingreso.CurrentRow.Cells["IdFlujo"].Value);
                flujos = db.Flujos.Where(x => x.IdFlujo == IdFlujo).FirstOrDefault();

            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void dgrid_egreso_DoubleClick(object sender, EventArgs e)
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

        private void dgrid_ingreso_DoubleClick(object sender, EventArgs e)
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

        private void CargarFiltros()
        {
            foreach(DataGridViewColumn col in this.dgrid.Columns)
            {
                if (col.Index != 0 && col.Index != 2 && col.Index != 7)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }
            }

            this.cmb_filtro.SelectedIndex = 0;  
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

            if(this.txt_filtro.Text =="") 
            { 
                CargarFlujos(); 
            }
            else
            {
                if (filtro == "Fecha")
                {
                    try
                    {
                        var filter = Convert.ToDateTime(this.txt_filtro.Text);
                        var x = from f in db.Flujos
                                join tf in db.TiposFlujos on f.IdTipo equals tf.IdTipo
                                join m in db.MetodosFlujos on f.IdMetodo equals m.IdMetodo
                                join t in db.Trabajadores on f.IdEmpleado equals t.IdEmpleado
                                join d in db.Departamentos on f.IdDepto equals d.IdDepto
                                where f.Fecha == filter && f.IdTipo == tipo && f.IdEstatus == 1
                                orderby f.IdFlujo descending
                                select new
                                {
                                    f.IdFlujo,
                                    f.Fecha,
                                    tf.Tipo,
                                    m.Metodo,
                                    t.NombreCompleto,
                                    f.Descripcion,
                                    f.Cantidad,
                                    f.Comprobante

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
                    var x = from f in db.Flujos
                            join tf in db.TiposFlujos on f.IdTipo equals tf.IdTipo
                            join m in db.MetodosFlujos on f.IdMetodo equals m.IdMetodo
                            join t in db.Trabajadores on f.IdEmpleado equals t.IdEmpleado
                            join d in db.Departamentos on f.IdDepto equals d.IdDepto
                            where m.Metodo.Contains(filter) && f.IdTipo == tipo && f.IdEstatus == 1
                            orderby f.IdFlujo descending
                            select new
                            {
                                f.IdFlujo,
                                f.Fecha,
                                tf.Tipo,
                                m.Metodo,
                                t.NombreCompleto,
                                f.Descripcion,
                                f.Cantidad,
                                f.Comprobante

                            };
                    dgrid.DataSource = x.ToList();

                }
                else if (filtro == "NombreCompleto")
                {
                    var filter = this.txt_filtro.Text;
                    var x = from f in db.Flujos
                            join tf in db.TiposFlujos on f.IdTipo equals tf.IdTipo
                            join m in db.MetodosFlujos on f.IdMetodo equals m.IdMetodo
                            join t in db.Trabajadores on f.IdEmpleado equals t.IdEmpleado
                            join d in db.Departamentos on f.IdDepto equals d.IdDepto
                            where t.NombreCompleto.Contains(filter) && f.IdTipo == tipo && f.IdEstatus == 1
                            orderby f.IdFlujo descending
                            select new
                            {
                                f.IdFlujo,
                                f.Fecha,
                                tf.Tipo,
                                m.Metodo,
                                t.NombreCompleto,
                                f.Descripcion,
                                f.Cantidad,
                                f.Comprobante

                            };
                    dgrid.DataSource = x.ToList();

                }
                else if (filtro == "Descripcion")
                {
                    var filter = this.txt_filtro.Text;
                    var x = from f in db.Flujos
                            join tf in db.TiposFlujos on f.IdTipo equals tf.IdTipo
                            join m in db.MetodosFlujos on f.IdMetodo equals m.IdMetodo
                            join t in db.Trabajadores on f.IdEmpleado equals t.IdEmpleado
                            join d in db.Departamentos on f.IdDepto equals d.IdDepto
                            where f.Descripcion.Contains(filter) && f.IdTipo == tipo && f.IdEstatus == 1
                            orderby f.IdFlujo descending
                            select new
                            {
                                f.IdFlujo,
                                f.Fecha,
                                tf.Tipo,
                                m.Metodo,
                                t.NombreCompleto,
                                f.Descripcion,
                                f.Cantidad,
                                f.Comprobante

                            };
                    dgrid.DataSource = x.ToList();


                }
                else if (filtro == "Cantidad")
                {
                    try
                    {
                        var filter = Convert.ToDouble(this.txt_filtro.Text);
                        var x = from f in db.Flujos
                                join tf in db.TiposFlujos on f.IdTipo equals tf.IdTipo
                                join m in db.MetodosFlujos on f.IdMetodo equals m.IdMetodo
                                join t in db.Trabajadores on f.IdEmpleado equals t.IdEmpleado
                                join d in db.Departamentos on f.IdDepto equals d.IdDepto
                                where f.Cantidad == filter && f.IdTipo == tipo && f.IdEstatus == 1
                                orderby f.IdFlujo descending
                                select new
                                {
                                    f.IdFlujo,
                                    f.Fecha,
                                    tf.Tipo,
                                    m.Metodo,
                                    t.NombreCompleto,
                                    f.Descripcion,
                                    f.Cantidad,
                                    f.Comprobante

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
            dgrid.Columns[2].Visible = false;
            dgrid.Columns["Comprobante"].Visible = false;
            dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEFlujos frm = new AEFlujos(this);
            frm.IdFlujo = IdFlujo;
            frm._uslog = this._uslog.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportarExcel();
        }

        private void ExportarExcel()
        {

            int x, z = 0;
            SLDocument sl = new SLDocument();
            SLWorksheetStatistics stats = sl.GetWorksheetStatistics();
            SLStyle style = sl.CreateStyle();


            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            downloadPath = System.IO.Path.Combine(downloadPath, "Documents");


            var tb = from f in db.Flujos
                     join tp in db.TiposFlujos on f.IdTipo equals tp.IdTipo
                     join m in db.MetodosFlujos on f.IdMetodo equals m.IdMetodo
                     join t in db.Trabajadores on f.IdEmpleado equals t.IdEmpleado
                     join d in db.Departamentos on f.IdDepto equals d.IdDepto
                     where f.IdEstatus==1
                     select new
                     {
                         f.IdFlujo,
                         f.Fecha,
                         tp.Tipo,
                         m.Metodo,
                         t.NombreCompleto,
                         d.Departamento,
                         f.Descripcion,
                         f.Cantidad



                     };

            DataGridView dgrid = new DataGridView();
            dgrid.Columns.Add("Id", "Id");
            dgrid.Columns.Add("Fecha", "Fecha");
            dgrid.Columns.Add("Tipo", "Tipo");
            dgrid.Columns.Add("Metodo", "Metodo");
            dgrid.Columns.Add("NombreCompleto", "Empleado");
            dgrid.Columns.Add("Departamento", "Departamento");
            dgrid.Columns.Add("Descripcion", "Descripcion");
            dgrid.Columns.Add("Cantidad", "Cantidad");






            foreach (var item in tb)
            {
                dgrid.Rows.Add(item.IdFlujo, item.Fecha,
                    item.Tipo,item.Metodo,item.NombreCompleto,item.Departamento,item.Descripcion,item.Cantidad);
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
                sl.SaveAs(downloadPath + "\\Flujos" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx");
                MessageBox.Show("Archivo exportado en " + downloadPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void btn_saldoactual_Click(object sender, EventArgs e)
        {
            VSaldosCaja frm = new VSaldosCaja(this);
            this.Enabled = false;
            frm.Show();
        }

        private void btn_saldoxfecha_Click(object sender, EventArgs e)
        {
            VSaldosCajaxFecha frm = new VSaldosCajaxFecha();
            frm.Show();
        }
    }
}
