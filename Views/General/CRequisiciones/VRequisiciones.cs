using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.General.CRequisiciones
{
    public partial class VRequisiciones : Form
    {
        public VRequisiciones(Usuarios us)
        {
            InitializeComponent();
            this._uslog= us;    
        }

        SITEntities db = new SITEntities();
        Requisiciones requisiciones = new Requisiciones();
        Usuarios _uslog;
        int IdRequisicion=0;

        private void btn_add_Click(object sender, EventArgs e)
        {
            VAERequisicion frm = new VAERequisicion(this);
            frm.IdRequisicion = IdRequisicion;
            frm.usuario = _uslog;
            frm.IdUsuario = this._uslog.IdUsuario;
            this.Enabled = false;
            frm.ShowDialog();
        }

        public void CargarRequisiciones()
        {
            IdRequisicion = 0;
            int idestatus = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            DataGridView dgrid = new DataGridView();    


            if (tbcontrol.SelectedIndex==0)
            {
                dgrid = this.dgrid_reqpendientes;
                idestatus = 1;
                this.btn_add.Enabled = true;
            }
            else if(tbcontrol.SelectedIndex==1)
            {
                dgrid = this.dgrid_reqautorizadas;
                idestatus = 3;
                this.btn_add.Enabled = false;
            }



            if (this._uslog.IdDepto==5 || this._uslog.IdDepto==1 || this._uslog.IdDepto == 3)
            {
                var x = from n in db.Requisiciones
                        join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                        where n.IdEstatus == idestatus
                        select new
                        {
                            n.IdRequisicion,
                            t.NombreCompleto,
                            n.Fecha,
                            n.Hora,
                            n.Observaciones
                        };

                dgrid.DataSource = null;
                dgrid.DataSource = x.ToList();
                dgrid.EnableHeadersVisualStyles = false;
                dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                 var x = from n in db.Requisiciones
                        join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                        where n.IdEstatus == idestatus && n.IdEmpleado==this._uslog.IdEmpleado
                        select new
                        {
                            n.IdRequisicion,
                            t.NombreCompleto,
                            n.Fecha,
                            n.Hora,
                            n.Observaciones
                        };

                dgrid.DataSource = null;
                dgrid.DataSource = x.ToList();
                dgrid.EnableHeadersVisualStyles = false;
                dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

          

           
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_reqpendientes.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }


        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarRequisiciones();
        }

        private void VRequisiciones_Load(object sender, EventArgs e)
        {
            CargarRequisiciones();
            CargarFiltros();
        }

        private void CargarxFiltro()
        {
            int idestatus = 0;
            DataGridView dgrid = new DataGridView();


            if (tbcontrol.SelectedIndex == 0)
            {
                dgrid = this.dgrid_reqpendientes;
                idestatus = 1;
            }
            else if (tbcontrol.SelectedIndex == 1)
            {
                dgrid = this.dgrid_reqautorizadas;
                idestatus = 2;
            }



            if (txt_filtro.Text != "")
            {
                var texto = txt_filtro.Text;
                var filtro = this.cmb_filtro.Text;
                if (filtro == "IdRequisicion")
                {
                    int textonum = Convert.ToInt32(texto);
                    try
                    {
                        var x = from n in db.Requisiciones
                                join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                                where n.IdEstatus == idestatus && n.IdRequisicion == textonum
                                select new
                                {
                                    n.IdRequisicion,
                                    t.NombreCompleto,
                                    n.Fecha,
                                    n.Hora
                                };

                        dgrid.DataSource = null;
                        dgrid.DataSource = x.ToList();
                        dgrid.EnableHeadersVisualStyles = false;
                        dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
               else if (filtro == "NombreCompleto")
                {
                    int textonum = Convert.ToInt32(texto);
                    try
                    {
                        var x = from n in db.Requisiciones
                                join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                                where n.IdEstatus == idestatus && n.IdRequisicion == textonum
                                select new
                                {
                                    n.IdRequisicion,
                                    t.NombreCompleto,
                                    n.Fecha,
                                    n.Hora
                                };

                        dgrid.DataSource = null;
                        dgrid.DataSource = x.ToList();
                        dgrid.EnableHeadersVisualStyles = false;
                        dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    CargarRequisiciones();
                    dgrid.Refresh();
                }
            }

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }

        private void dgrid_reqpendientes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_reqpendientes.CurrentCell.RowIndex != -1)
                {
                    IdRequisicion = Convert.ToInt32(this.dgrid_reqpendientes.CurrentRow.Cells[0].Value);
                    requisiciones = db.Requisiciones.Where(x => x.IdRequisicion == IdRequisicion).FirstOrDefault();
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            }
            catch (Exception ex) { }
        }

        private bool VerificarCotizacionesReq()
        {
            var x = from n in db.CotizacionesRequisiciones
                    join d in db.DetalleRequisiciones on n.IdDetalleReq equals d.IdDetalleReq
                    join r in db.Requisiciones on d.IdRequisicion equals r.IdRequisicion
                    where n.IdEstatus !=2 && d.IdRequisicion==IdRequisicion
                    select new { CotizacionesRequisiciones = n};

            var result = x.ToList();

            if(result.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void CancelarRequisicion()
        {
            if (VerificarCotizacionesReq() == true)
            {
                MessageBox.Show("La requisicion no se puede cancelar debido a que cuenta con cotizaciones pendientes y/o autorizadas");
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                IdRequisicion = 0;

            }
            else
            {
                requisiciones = db.Requisiciones.Where(x => x.IdRequisicion == IdRequisicion).FirstOrDefault();
                requisiciones.IdEstatus = 2;
                requisiciones.FechaCan = DateTime.Now;
                requisiciones.IdUsCan = _uslog.IdUsuario;

                if (IdRequisicion > 0)
                {
                    db.Entry(requisiciones).State = EntityState.Modified;
                    MessageBox.Show("Requisicion cancelado exitosamente");
                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    db.SaveChanges();
                    CargarRequisiciones();
                }
                else
                {
                    MessageBox.Show("Favor de seleccionar el concepto a cancelar");
                }
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar la requisicion seleccionada", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarRequisicion();

            }
            else
            {
                // Do something
            }
        }
    }
}
