using GMap.NET;
using SIT.Views.Catalogos.CConceptos;
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

namespace SIT.Views.Catalogos
{
    public partial class VConceptosFlujos : Form
    {
        public VConceptosFlujos(Usuarios usuario)
        {
            InitializeComponent();
            this._uslog = usuario;
        }

        SITEntities db = new SITEntities();
        ConceptosFlujos conceptos = new ConceptosFlujos();
        int IdConcepto = 0;
        Usuarios _uslog;


        public void CargarConceptos()
        {
            var conceptos = from x in db.ConceptosFlujos
                            join t in db.TiposCostos on x.IdTipo equals t.IdTipoCosto
                            join r in db.RubrosFlujos on x.IdRubro equals r.IdRubro
                            where x.IdEstatus == 1
                            select new
                            {
                                x.IdConcepto,
                                x.Concepto,
                                t.Costo,
                                r.Rubro
                            };
            this.dgrid_conc.DataSource = conceptos.ToList();
            this.dgrid_conc.Columns[0].Visible = false;
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            AEConceptoFlujos frm = new AEConceptoFlujos(this);
            frm.IdConcepto = IdConcepto;
            frm.IdUsuario = _uslog.IdUsuario;
            this.Enabled = false;
            frm.ShowDialog();
        }

        private void CancelarConcepto()
        {
            conceptos = db.ConceptosFlujos.Where(x => x.IdConcepto == IdConcepto).FirstOrDefault();
            conceptos.IdEstatus = 2;
            conceptos.FechaCancelo = DateTime.Now;
            conceptos.IdUsCancelo = _uslog.IdUsuario;

            if (IdConcepto > 0)
            {
                db.Entry(conceptos).State = EntityState.Modified;
                MessageBox.Show("Concepto cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarConceptos();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el concepto a cancelar");
            }
        }


        private void dgrid_conc_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_conc.CurrentCell.RowIndex != -1)
                {
                    IdConcepto = Convert.ToInt32(this.dgrid_conc.CurrentRow.Cells["IdConcepto"].Value);
                    conceptos = db.ConceptosFlujos.Where(x => x.IdConcepto == IdConcepto).FirstOrDefault();
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            }
            catch(Exception ex) { }
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_conc.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        private void VConceptosFlujos_Load(object sender, EventArgs e)
        {
            this.dgrid_conc.EnableHeadersVisualStyles = false;
            this.dgrid_conc.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_conc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_conc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarConceptos();
            CargarFiltros();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el concepto seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarConcepto();

            }
            else
            {
                // Do something
            }
        }

        private void CargarxFiltro()
        {

            if (txt_filtro.Text != "")
            {

                var filtro = this.cmb_filtro.Text;
                if (filtro == "Concepto")
                {
                    try
                    {

                        var conceptos = from x in db.ConceptosFlujos
                                        join t in db.TiposCostos on x.IdTipo equals t.IdTipoCosto
                                        join r in db.RubrosFlujos on x.IdRubro equals r.IdRubro
                                        where x.IdEstatus == 1 && x.Concepto.Contains(this.txt_filtro.Text)
                                        select new
                                        {
                                            x.IdConcepto,
                                            x.Concepto,
                                            t.Costo,
                                            r.Rubro
                                        };
                        this.dgrid_conc.DataSource = conceptos.ToList();
                        this.dgrid_conc.Columns[0].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Costo")
                {
                    try
                    {
                        var conceptos = from x in db.ConceptosFlujos
                                        join t in db.TiposCostos on x.IdTipo equals t.IdTipoCosto
                                        join r in db.RubrosFlujos on x.IdRubro equals r.IdRubro
                                        where x.IdEstatus == 1 && t.Costo.Contains(this.txt_filtro.Text)
                                        select new
                                        {
                                            x.IdConcepto,
                                            x.Concepto,
                                            t.Costo,
                                            r.Rubro
                                        };
                        this.dgrid_conc.DataSource = conceptos.ToList();
                        this.dgrid_conc.Columns[0].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "Rubro")
                {
                    try
                    {
                        var conceptos = from x in db.ConceptosFlujos
                                        join t in db.TiposCostos on x.IdTipo equals t.IdTipoCosto
                                        join r in db.RubrosFlujos on x.IdRubro equals r.IdRubro
                                        where x.IdEstatus == 1 && r.Rubro.Contains(this.txt_filtro.Text)
                                        select new
                                        {
                                            x.IdConcepto,
                                            x.Concepto,
                                            t.Costo,
                                            r.Rubro
                                        };
                        this.dgrid_conc.DataSource = conceptos.ToList();
                        this.dgrid_conc.Columns[0].Visible = false;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else
                {
                    CargarConceptos();
                    this.dgrid_conc.Refresh();
                }
            }

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }
    }
}
