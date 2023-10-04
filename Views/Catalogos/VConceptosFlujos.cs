using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        public VConceptosFlujos()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();
        ConceptosFlujos conceptos = new ConceptosFlujos();
        int IdConcepto = 0;

        private void CargarConceptos()
        {
            var conceptos = from x in db.ConceptosFlujos
                            join t in db.TiposCostos on x.IdTipo equals t.IdTipoCosto
                            join r in db.RubrosFlujos on x.IdRubro equals r.IdRubro
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

        private void AgregarConcepto()
        {
            if (this.txt_concepto.Text == "")
            {
                MessageBox.Show("Favor de completar el campo concepto");
            }
            else if (this.cmb_tipo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el campo tipo");
            }
            else if (this.cmb_rubro.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el campo rubro");
            }
            else
            {
                conceptos.Concepto = this.txt_concepto.Text.ToUpper();
                conceptos.IdTipo = Convert.ToInt32(this.cmb_tipo.SelectedValue);
                conceptos.IdRubro = Convert.ToInt32(this.cmb_rubro.SelectedValue);


                if (IdConcepto > 0)
                {
                    db.Entry(conceptos).State = EntityState.Modified;
                    MessageBox.Show("Concepto actualizado exitosamente");
                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    db.ConceptosFlujos.Add(conceptos);
                    MessageBox.Show("Concepto agregado exitosamente");
                }

                db.SaveChanges();
                CargarConceptos();
                LimpiarFormulario();
            }


        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarConcepto();
        }

        private void dgrid_conc_Click(object sender, EventArgs e)
        {
            if (this.dgrid_conc.CurrentCell.RowIndex != -1)
            {
                IdConcepto = Convert.ToInt32(this.dgrid_conc.CurrentRow.Cells["IdConcepto"].Value);
                conceptos = db.ConceptosFlujos.Where(x => x.IdConcepto == IdConcepto).FirstOrDefault();
                this.txt_concepto.Text = conceptos.Concepto;
                this.cmb_tipo.SelectedValue = conceptos.IdTipo;
                this.cmb_rubro.SelectedValue = conceptos.IdRubro;
            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void VConceptosFlujos_Load(object sender, EventArgs e)
        {
            this.dgrid_conc.EnableHeadersVisualStyles = false;
            this.dgrid_conc.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_conc.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_conc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarConceptos();
            CargarTipos();
            CargarRubros();
        }

        private void CargarTipos()
        {
            var x = db.TiposCostos.ToList();
            this.cmb_tipo.DataSource = x;
            this.cmb_tipo.ValueMember = "IdTipoCosto";
            this.cmb_tipo.DisplayMember = "Costo";
        }

        private void CargarRubros()
        {
            var x = db.RubrosFlujos.ToList();
            this.cmb_rubro.DataSource = x;
            this.cmb_rubro.ValueMember = "IdRubro";
            this.cmb_rubro.DisplayMember = "Rubro";

        }

        private void LimpiarFormulario()
        {
            this.txt_concepto.Text = "";
        }
    }
}
