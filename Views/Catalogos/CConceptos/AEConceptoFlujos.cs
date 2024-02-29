using CrystalDecisions.ReportAppServer.CommonControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Catalogos.CConceptos
{
    public partial class AEConceptoFlujos : Form
    {
        public AEConceptoFlujos(VConceptosFlujos vconceptos)
        {
            InitializeComponent();
            this._vconceptos = vconceptos;
        }

        public int IdConcepto, IdUsuario;
        VConceptosFlujos _vconceptos;
        SITEntities db = new SITEntities();
        ConceptosFlujos conceptos = new ConceptosFlujos();

        private void AgregarConcepto()
        {
            if (this.txt_concepto.Text == "" || this.txt_concepto.Text.Trim().Length==0)
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
                conceptos.IdEstatus = 1;
                conceptos.IdTipo = Convert.ToInt32(this.cmb_tipo.SelectedValue);
                conceptos.IdRubro = Convert.ToInt32(this.cmb_rubro.SelectedValue);
                conceptos.FechaCreo =DateTime.Now;
                conceptos.IdUsCreo = IdUsuario;


                if (IdConcepto > 0)
                {
                    conceptos.FechaMod=DateTime.Now;
                    conceptos.IdUsMod=IdUsuario;
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
                this.Close();
            }


        }

        private void CargarTipos()
        {
            var x = db.TiposCostos.ToList();
            this.cmb_tipo.DataSource = x;
            this.cmb_tipo.ValueMember = "IdTipoCosto";
            this.cmb_tipo.DisplayMember = "Costo";
        }

        private void AEConceptoFlujos_Load(object sender, EventArgs e)
        {
            CargarRubros();
            CargarTipos();
            this.Text = "Agregar";

            if (IdConcepto != 0)
            {
                this.Text = "Editar";
                conceptos = db.ConceptosFlujos.Where(x => x.IdConcepto == IdConcepto).FirstOrDefault();
                this.txt_concepto.Text=conceptos.Concepto.ToUpper();
                this.cmb_rubro.SelectedValue = conceptos.IdRubro;
                this.cmb_tipo.SelectedValue = conceptos.IdTipo;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarConcepto();
        }

        private void AEConceptoFlujos_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._vconceptos.Enabled = true;
            this._vconceptos.CargarConceptos();
        }

        private void CargarRubros()
        {
            var x = db.RubrosFlujos.ToList();
            this.cmb_rubro.DataSource = x;
            this.cmb_rubro.ValueMember = "IdRubro";
            this.cmb_rubro.DisplayMember = "Rubro";

        }
    }
}
