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

namespace SIT.Views.Catalogos.CAlmacenes
{
    public partial class AEAlmacen : Form
    {
        public int IdAlmacen,IdUsuario;
        SITEntities db = new SITEntities();
        Almacenes almacenes = new Almacenes();
        VAlmacenes _valmacen;

        private void AEAlmacen_Load(object sender, EventArgs e)
        {
            this.Text = "Agregar";

            if (IdAlmacen != 0)
            {
                almacenes = db.Almacenes.Where(x => x.IdAlmacen == IdAlmacen).FirstOrDefault();
                this.txt_nombrealmacen.Text = almacenes.Almacen;
                this.txt_codinterno.Text = almacenes.CodInterno;
                this.Text = "Editar";
            }
        }

        public AEAlmacen(VAlmacenes valmacen)
        {
            InitializeComponent();
            _valmacen = valmacen;   
        }

        private void AEAlmacen_FormClosed(object sender, FormClosedEventArgs e)
        {
            _valmacen.Enabled = true;
            _valmacen.CargarAlmacenes();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void AgregarProducto()
        {

            if (this.txt_nombrealmacen.Text == "" || this.txt_nombrealmacen.Text.Length==0)
            {
                MessageBox.Show("Favor de introducir el nombre del almacen");
                this.txt_nombrealmacen.Focus();
            }
            else if (this.txt_codinterno.Text == "" || this.txt_codinterno.Text.Length == 0)
            {
                MessageBox.Show("Favor de introducir el codigo interno del almacen");
                this.txt_codinterno.Focus();
            }
            else
            {
                almacenes.Almacen = this.txt_nombrealmacen.Text.ToUpper().ToString();
                almacenes.CodInterno = this.txt_codinterno.Text.ToUpper().ToString();
                almacenes.IdEstatus = 1;
                almacenes.FechaCreacion = DateTime.Now;
                almacenes.IdUsCreo = IdUsuario;

                if (IdAlmacen > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        almacenes.IdUsMod = this.IdUsuario;
                        almacenes.FechaMod = DateTime.Now;
                        db.Entry(almacenes).State = EntityState.Modified;
                        MessageBox.Show("Actualizado exitosamente");
                    }
                    else
                    {
                    }
                }
                else
                {
                    db.Almacenes.Add(almacenes);
                    MessageBox.Show("Agregado exitosamente");
                }

                db.SaveChanges();
                this.Close();
                _valmacen.Enabled = true;
            }
        }

    }
}
