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
    public partial class VMetodosPago : Form
    {
        public VMetodosPago()
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();
        int IdMetodo = 0;
        MetodosFlujos metodos = new MetodosFlujos();

        private void CargarMetodosPago()
        {
            var x = db.MetodosFlujos.ToList();
            this.dgrid_metodos.DataSource = x;
            this.dgrid_metodos.Columns[0].Visible = false;
        }

        private void VMetodosPago_Load(object sender, EventArgs e)
        {
            this.dgrid_metodos.EnableHeadersVisualStyles = false;
            this.dgrid_metodos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_metodos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_metodos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarMetodosPago();

        }

        private void AgregarMetodo()
        {
            if (this.txt_metodo.Text == "")
            {
                MessageBox.Show("Favor de completar el campo metodo");
            }
            else
            {
                metodos.Metodo= this.txt_metodo.Text.ToUpper();

                if(IdMetodo>0)
                {
                    db.Entry(metodos).State = EntityState.Modified;
                    MessageBox.Show("Metodo actualizado exitosamente");
                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    db.MetodosFlujos.Add(metodos);
                    MessageBox.Show("Metodo agregado exitosamente");

                }
                db.SaveChanges();
                LimpiarFormulario();
                CargarMetodosPago();

            }
        }

        private void LimpiarFormulario()
        {
            this.txt_metodo.Text = "";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarMetodo();
        }

        private void dgrid_metodos_Click(object sender, EventArgs e)
        {
            if (this.dgrid_metodos.CurrentCell.RowIndex != -1)
            {
                IdMetodo = Convert.ToInt32(this.dgrid_metodos.CurrentRow.Cells["IdMetodo"].Value);
                metodos = db.MetodosFlujos.Where(x => x.IdMetodo == IdMetodo).FirstOrDefault();
                this.txt_metodo.Text = metodos.Metodo;
            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }
    }
}
