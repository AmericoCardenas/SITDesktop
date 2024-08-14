using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using SIT.Views.Catalogos;
using SIT.Views.Sistemas.CEqComputo;
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

namespace SIT.Views.Taller.COrdenesTrabajo
{
    public partial class AEActMOT : Form
    {
        public AEActMOT(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        Form _form;
        SITEntities db = new SITEntities();
        public int idAct;
        ActividadesMOT act = new ActividadesMOT();

        private void AgregarActividad()
        {
            if(this.txt_act.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar la actividad");
            }
            else
            {
                act.Actividad=this.txt_act.Text.ToUpper();

                if (idAct > 0)
                {
                    this.db.Entry(act).State = EntityState.Modified;
                    MessageBox.Show("Actividad actualizado exitosamente");
                }
                else
                {
                    db.ActividadesMOT.Add(act);
                    MessageBox.Show("Actividad agregada exitosamente");
                }

                db.SaveChanges();
                this.Close();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarActividad();
        }

        private void AEActMOT_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(this._form.Name== "AEActividadOT")
            {
                AEActividadOT act = (AEActividadOT)this._form;
                act.Enabled = true;
                act.CargarActMot();

            }
        }
    }
}
