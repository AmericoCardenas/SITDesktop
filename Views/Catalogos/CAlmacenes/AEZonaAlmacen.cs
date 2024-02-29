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
    public partial class AEZonaAlmacen : Form
    {
        public AEZonaAlmacen(VZonasAlmacen vzalmacen)
        {
            InitializeComponent();
            _vzonas = vzalmacen;
        }

        public int IdUsuario,IdZona;
        SITEntities db = new SITEntities();
        ZonasAlmacen zonas = new ZonasAlmacen();
        VZonasAlmacen _vzonas;

        private void AEZonaAlmacen_Load(object sender, EventArgs e)
        {
            this.Text = "Agregar";
            CargarAlmacenes();

            if (IdZona != 0)
            {
                zonas = db.ZonasAlmacen.Where(x => x.IdZona == IdZona).FirstOrDefault();
                this.txt_zona.Text = zonas.Zona;
                this.cmb_almacenes.SelectedItem = zonas.IdAlmacen;
                this.Text = "Editar";
            }
        }

        private void CargarAlmacenes()
        {
            var x = this.db.Almacenes.ToList();
            this.cmb_almacenes.DataSource = x;
            this.cmb_almacenes.ValueMember = "IdAlmacen";
            this.cmb_almacenes.DisplayMember = "Almacen";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarZona();
        }

        private void AEZonaAlmacen_FormClosed(object sender, FormClosedEventArgs e)
        {
            _vzonas.Enabled = true;
            _vzonas.CargarZonasAlmacen();
        }

        private void AgregarZona()
        {
            if (this.cmb_almacenes.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el almacen");
                this.cmb_almacenes.Focus();
            }
            else if (this.txt_zona.Text == "" || this.txt_zona.Text.Length==0)
            {
                MessageBox.Show("Favor de introducir la zona");
                this.txt_zona.Focus();
            }
            else
            {
                zonas.IdAlmacen = Convert.ToInt32(this.cmb_almacenes.SelectedValue);
                zonas.Zona = this.txt_zona.Text.ToUpper();
                zonas.IdEstatus = 1;
                zonas.FechaCreacion = DateTime.Now;
                zonas.IdUsCreo = IdUsuario;

                if (IdZona > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        zonas.IdUsMod = this.IdUsuario;
                        zonas.FechaMod = DateTime.Now;
                        db.Entry(zonas).State = EntityState.Modified;
                        MessageBox.Show("Actualizado exitosamente");
                    }
                    else
                    {
                    }
                }
                else
                {
                    db.ZonasAlmacen.Add(zonas);
                    MessageBox.Show("Agregado exitosamente");
                }

                db.SaveChanges();
                this.Close();
            }
        }




    }
}
