using SIT.CrystalReport;
using SIT.Views.Sistemas.CEqMovil;
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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SIT.Views.Sistemas
{
    public partial class VEquiposMovil : Form
    {
        public VEquiposMovil(Usuarios usuariolog)
        {
            InitializeComponent();
            this._uslog = usuariolog;

        }

        SITEntities db = new SITEntities();
        EquiposMovil eqmov = new EquiposMovil();
        int IdEquipoMovil = 0;
        Usuarios _uslog;

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_eqmov.Columns)
            {
                if (col.Index != 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }
            }

            this.cmb_filtro.SelectedIndex = 0;
        }

        private void VEquiposMovil_Load(object sender, EventArgs e)
        {
            CargarEquiposMov();
            CargarFiltros();
            this.dgrid_eqmov.EnableHeadersVisualStyles = false;
            this.dgrid_eqmov.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_eqmov.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        public void CargarEquiposMov()
        {
            var equipos = from x in db.EquiposMovil
                          join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                          join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                          select new
                          {
                              x.IdEquipoMovil,
                              x.Marca,
                              x.Modelo,
                              x.SN,
                              x.IMEI,
                              x.IMEI2,
                              x.Color,
                              t.NombreCompleto,
                              e.Estatus
                          };
            this.dgrid_eqmov.DataSource = equipos.ToList();
            this.dgrid_eqmov.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in this.dgrid_eqmov.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            this.dgrid_eqmov.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }




        private void dgrid_eqmov_Click(object sender, EventArgs e)
        {
            if (this.dgrid_eqmov.CurrentCell.RowIndex != -1)
            {
                IdEquipoMovil = Convert.ToInt32(this.dgrid_eqmov.CurrentRow.Cells["IdEquipoMovil"].Value);

            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEEqMovil frm = new AEEqMovil(this);
            frm.idEqMovil = IdEquipoMovil;
            this.Enabled = false;
            frm.Show();
        }

        private void dgrid_eqmov_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            string estatus = this.dgrid_eqmov.Rows[e.RowIndex].Cells["Estatus"].Value.ToString();
            if (estatus == "ROBO")
            {
                this.dgrid_eqmov.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else if (estatus == "ASIGNADO")
            {
                this.dgrid_eqmov.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            else if (estatus == "DISPONIBLE")
            {
                this.dgrid_eqmov.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            }
            else if (estatus == "INUTILIZABLE")
            {
                this.dgrid_eqmov.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Purple;
            }
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
            var filtro = this.cmb_filtro.Text;

            if (this.txt_filtro.Text == "")
            {
                CargarEquiposMov();
            }
            else
            {
                if (filtro == "Marca")
                {
                    try
                    {
                        var z = from x in db.EquiposMovil
                                     join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                                     join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                                     where x.Marca.Contains(this.txt_filtro.Text)
                                     select new
                                     {
                                         x.IdEquipoMovil,
                                         x.Marca,
                                         x.Modelo,
                                         x.SN,
                                         x.IMEI,
                                         x.IMEI2,
                                         x.Color,
                                         t.NombreCompleto,
                                         e.Estatus
                                     };
                        this.dgrid_eqmov.DataSource = z.ToList();
                        this.dgrid_eqmov.Columns[0].Visible = false;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Modelo")
                {
                    try
                    {
                        var z = from x in db.EquiposMovil
                                join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                                join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                                where x.Modelo.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    x.IdEquipoMovil,
                                    x.Marca,
                                    x.Modelo,
                                    x.SN,
                                    x.IMEI,
                                    x.IMEI2,
                                    x.Color,
                                    t.NombreCompleto,
                                    e.Estatus
                                };
                        this.dgrid_eqmov.DataSource = z.ToList();
                        this.dgrid_eqmov.Columns[0].Visible = false;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "SN")
                {
                    try
                    {
                        var z = from x in db.EquiposMovil
                                join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                                join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                                where x.SN.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    x.IdEquipoMovil,
                                    x.Marca,
                                    x.Modelo,
                                    x.SN,
                                    x.IMEI,
                                    x.IMEI2,
                                    x.Color,
                                    t.NombreCompleto,
                                    e.Estatus
                                };
                        this.dgrid_eqmov.DataSource = z.ToList();
                        this.dgrid_eqmov.Columns[0].Visible = false;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "IMEI")
                {
                    try
                    {
                        var z = from x in db.EquiposMovil
                                join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                                join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                                where x.IMEI.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    x.IdEquipoMovil,
                                    x.Marca,
                                    x.Modelo,
                                    x.SN,
                                    x.IMEI,
                                    x.IMEI2,
                                    x.Color,
                                    t.NombreCompleto,
                                    e.Estatus
                                };
                        this.dgrid_eqmov.DataSource = z.ToList();
                        this.dgrid_eqmov.Columns[0].Visible = false;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "IMEI2")
                {
                    try
                    {
                        var z = from x in db.EquiposMovil
                                join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                                join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                                where x.IMEI2.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    x.IdEquipoMovil,
                                    x.Marca,
                                    x.Modelo,
                                    x.SN,
                                    x.IMEI,
                                    x.IMEI2,
                                    x.Color,
                                    t.NombreCompleto,
                                    e.Estatus
                                };
                        this.dgrid_eqmov.DataSource = z.ToList();
                        this.dgrid_eqmov.Columns[0].Visible = false;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Color")
                {
                    try
                    {
                        var z = from x in db.EquiposMovil
                                join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                                join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                                where x.Color.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    x.IdEquipoMovil,
                                    x.Marca,
                                    x.Modelo,
                                    x.SN,
                                    x.IMEI,
                                    x.IMEI2,
                                    x.Color,
                                    t.NombreCompleto,
                                    e.Estatus
                                };
                        this.dgrid_eqmov.DataSource = z.ToList();
                        this.dgrid_eqmov.Columns[0].Visible = false;

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
                        var z = from x in db.EquiposMovil
                                join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                                join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                                where t.NombreCompleto.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    x.IdEquipoMovil,
                                    x.Marca,
                                    x.Modelo,
                                    x.SN,
                                    x.IMEI,
                                    x.IMEI2,
                                    x.Color,
                                    t.NombreCompleto,
                                    e.Estatus
                                };
                        this.dgrid_eqmov.DataSource = z.ToList();
                        this.dgrid_eqmov.Columns[0].Visible = false;

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
                        var z = from x in db.EquiposMovil
                                join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                                join e in db.EstatusEquipos on x.IdEstatus equals e.IdEstatus
                                where e.Estatus.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    x.IdEquipoMovil,
                                    x.Marca,
                                    x.Modelo,
                                    x.SN,
                                    x.IMEI,
                                    x.IMEI2,
                                    x.Color,
                                    t.NombreCompleto,
                                    e.Estatus
                                };
                        this.dgrid_eqmov.DataSource = z.ToList();
                        this.dgrid_eqmov.Columns[0].Visible = false;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }

            foreach (DataGridViewColumn col in this.dgrid_eqmov.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            this.dgrid_eqmov.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.frm = this;
            frm.ideqmovil = Convert.ToInt32(this.dgrid_eqmov.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //this.Enabled = false;
        }
    }
}
