using DocumentFormat.OpenXml.Drawing.Wordprocessing;
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
            this.IdUsuario = uslog.IdUsuario;
        }

        private int IdUsuario;
        private int IdNota;
        SITEntities db = new SITEntities();
        NotasMovimientos not = new NotasMovimientos();

        private void VNotas_Load(object sender, EventArgs e)
        {
            CargarNotas();
            CargarFiltros();
        }

        private void CargarFiltros()
        {
            foreach(DataGridViewColumn col in this.dgrid_notas.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        private void CargarNotas()
        {
            var x = from n in db.NotasMovimientos
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdNota,
                        n.Folio,
                        n.Fecha,
                        n.Concepto,
                        n.Total
                    };
            this.dgrid_notas.DataSource = x.ToList();
            this.dgrid_notas.Columns[0].Visible= false;

            this.dgrid_notas.EnableHeadersVisualStyles = false;
            this.dgrid_notas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_notas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_notas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CancelarNota()
        {
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
                if (this.dgrid_notas.CurrentCell.RowIndex != -1)
                {
                    IdNota = Convert.ToInt32(this.dgrid_notas.CurrentRow.Cells["IdNota"].Value);
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
                        this.dgrid_notas.DataSource = x.ToList();
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
                        this.dgrid_notas.DataSource = x.ToList();
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
                        this.dgrid_notas.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else
                {
                    CargarNotas();
                    this.dgrid_notas.Refresh();
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
    }
}
