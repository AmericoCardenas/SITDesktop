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

namespace SIT.Views.Catalogos
{
    public partial class VRubros : Form
    {
        public VRubros()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();
        RubrosFlujos rubros = new RubrosFlujos();
        int IdRubro = 0;

        private void CargarRubros()
        {
            var x = db.RubrosFlujos.ToList();
            this.dgrid_rubros.DataSource = x;
            this.dgrid_rubros.Columns[0].Visible = false;
        }

        private void AgregarRubro()
        {
            if (this.txt_rubro.Text == "")
            {
                MessageBox.Show("Favor de completar el campo Rubro");
            }
            else
            {
                rubros.Rubro=this.txt_rubro.Text.ToUpper();

                if (IdRubro > 0)
                {
                    db.Entry(rubros).State = EntityState.Modified;
                    MessageBox.Show("Rubro actualizado exitosamente");
                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    db.RubrosFlujos.Add(rubros);
                    MessageBox.Show("Rubro agregado exitosamente");
                }
                db.SaveChanges();
                LimpiarFormulario();
                CargarRubros();

            }
        }

        private void LimpiarFormulario()
        {
            this.txt_rubro.Text = "";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarRubro();
        }

        private void VRubros_Load(object sender, EventArgs e)
        {
            CargarRubros();
            this.dgrid_rubros.EnableHeadersVisualStyles = false;
            this.dgrid_rubros.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_rubros.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_rubros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgrid_rubros_Click(object sender, EventArgs e)
        {
            if (this.dgrid_rubros.CurrentCell.RowIndex != -1)
            {
                IdRubro = Convert.ToInt32(this.dgrid_rubros.CurrentRow.Cells["IdRubro"].Value);
                rubros = db.RubrosFlujos.Where(x => x.IdRubro == IdRubro).FirstOrDefault();
                this.txt_rubro.Text = rubros.Rubro;
            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }
    }
}
