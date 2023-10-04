using SIT.Views.Catalogos;
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
        string filename;
        int IdFlujo = 0;
        OpenFileDialog op1 = new OpenFileDialog();
        Usuarios _uslog;
        string ruta = "\\\\192.168.1.213\\OneDrive - TRANSPORTES DAVILA\\Transportes Davila\\7.- Contabilidad1\\ArchivosFlujos\\";


        private void CargarFlujos()
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
            CargarEmpleados();
            CargarDeptos();
            CargarTipos();
            CargarMetodo();
            CargarFiltros();
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFlujos();
        }

        private void AgregarFlujo()
        {
            if(this.cmb_tipo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el tipo");
            }
            else if (this.cmb_metodo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el metodo");
            }
            else if (this.cmb_empleado.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
            }
            else if (this.cmb_area.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el area");
            }
            else if (this.txt_concepto.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el concepto");
            }
            else if (this.txt_cantidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el concepto");
            }
            else
            {
                flujos.Fecha = this.dtm_fecha.Value;
                flujos.IdTipo = Convert.ToInt32(this.cmb_tipo.SelectedValue);
                flujos.IdMetodo = Convert.ToInt32(this.cmb_metodo.SelectedValue);
                flujos.IdEmpleado = Convert.ToInt32(this.cmb_empleado.SelectedValue);
                flujos.IdDepto = Convert.ToInt32(this.cmb_area.SelectedValue);
                flujos.Descripcion = this.txt_concepto.Text.ToUpper();
                flujos.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                flujos.IdEstatus = 1;
                flujos.IdUsuarioCreo = _uslog.IdUsuario;
                flujos.FechaCreacion = DateTime.Now;

                if (filename != "")
                {
                    flujos.Ruta = ruta;
                    flujos.Comprobante = filename;
                    int count = 0;

                    string[] FName;

                    foreach (string s in op1.FileNames)

                    {

                        FName = s.Split('\\');

                        if(File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(s, ruta + FName[FName.Length - 1]);
                        }


                        count++;

                    }
                }

                if (IdFlujo > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        flujos.IdUsuarioModifico = _uslog.IdUsuario;
                        flujos.FechaModifico = DateTime.Now;
                        db.Entry(flujos).State = EntityState.Modified;
                        MessageBox.Show("Flujo actualizado exitosamente");
                        this.btn_add.BackgroundImage = Properties.Resources.mas;
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        LimpiarFormulario();
                        IdFlujo = 0;
                        this.btn_add.BackgroundImage = Properties.Resources.mas;
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                }
                else
                {
                    db.Flujos.Add(flujos);
                    MessageBox.Show("Concepto agregado exitosamente");
                }

                db.SaveChanges();
                CargarFlujos();
                LimpiarFormulario();
            }
        }

        private void CargarTipos()
        {
            var x = db.TiposFlujos.ToList();
            this.cmb_tipo.DataSource = x;
            this.cmb_tipo.DisplayMember = "Tipo";
            this.cmb_tipo.ValueMember = "IdTipo";
        }

        private void CargarMetodo()
        {
            var x = db.MetodosFlujos.ToList();
            this.cmb_metodo.DataSource = x;
            this.cmb_metodo.DisplayMember = "Metodo";
            this.cmb_metodo.ValueMember = "IdMetodo";
        }

        private void CargarEmpleados()
        {
            var x = db.Trabajadores.ToList();
            this.cmb_empleado.DataSource = x;
            this.cmb_empleado.DisplayMember = "NombreCompleto";
            this.cmb_empleado.ValueMember = "IdEmpleado";
        }

        private void CargarDeptos()
        {
            var x = db.Departamentos.ToList();
            this.cmb_area.DataSource = x;
            this.cmb_area.DisplayMember = "Departamento";
            this.cmb_area.ValueMember = "IdDepto";

        }

        private void btn_archivo_Click(object sender, EventArgs e)
        {
            op1.Multiselect = true;
            op1.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op1.ShowDialog();
            filename = op1.SafeFileName;
            this.btn_archivo.BackColor = Color.Green;
        }

        private void LimpiarFormulario()
        {
            this.txt_cantidad.Text = string.Empty;
            this.txt_concepto.Text = string.Empty;
            this.btn_archivo.BackColor = Color.DeepSkyBlue;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarFlujo();
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

                this.dtm_fecha.Value = flujos.Fecha.Value;
                this.cmb_tipo.SelectedValue = flujos.IdTipo;
                this.cmb_metodo.SelectedValue = flujos.IdMetodo;
                this.cmb_empleado.SelectedValue = flujos.IdEmpleado;
                this.cmb_area.SelectedValue = flujos.IdDepto;
                this.txt_concepto.Text = flujos.Descripcion;
                this.txt_cantidad.Text = flujos.Cantidad.ToString();
                filename = flujos.Comprobante;
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

                this.dtm_fecha.Value = flujos.Fecha.Value;
                this.cmb_tipo.SelectedValue = flujos.IdTipo;
                this.cmb_metodo.SelectedValue = flujos.IdMetodo;
                this.cmb_empleado.SelectedValue = flujos.IdEmpleado;
                this.cmb_area.SelectedValue = flujos.IdDepto;
                this.txt_concepto.Text = flujos.Descripcion;
                this.txt_cantidad.Text = flujos.Cantidad.ToString();
                filename = flujos.Comprobante;
            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


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
    }
}
