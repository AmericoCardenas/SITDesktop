using SIT.Views.Catalogos.CEmpleados;
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

namespace SIT.Views.RH.CUniformes
{
    public partial class AEArtEmp : Form
    {
        public AEArtEmp(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        public Usuarios uslog;
        Form _form;
        SITEntities db = new SITEntities();
        ArticulosEmp artemp = new ArticulosEmp();
        public int idEmpleado,idArtEmp;


        private void CargarEmpleados()
        {
            var x = this.db.Trabajadores.Where(y=>y.IdEstatus==1).ToList();
            this.cmb_emp.DataSource = x;
            this.cmb_emp.DisplayMember = "NombreCompleto";
            this.cmb_emp.ValueMember = "IdEmpleado";
        }

        private void CargarArticulos()
        {
            var x = this.db.CatArticulosRh.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_art.DataSource = x;
            this.cmb_art.DisplayMember = "Articulo";
            this.cmb_art.ValueMember = "IdArticulo";
        }

        private void AEArtEmp_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            this.cmb_emp.SelectedValue = idEmpleado;
            this.cmb_emp.Enabled = false;

            CargarArticulos();

            if (idArtEmp != 0)
            {
                artemp=this.db.ArticulosEmp.Where(x=>x.IdArtEmp==idArtEmp).First();
                if (artemp != null)
                {
                    this.txt_cantidad.Text = artemp.Cantidad.ToString();
                    this.dtm_fecha.Value = Convert.ToDateTime(artemp.Fecha);
                    this.cmb_emp.SelectedValue=artemp.IdEmpleado;
                    this.cmb_art.SelectedValue = artemp.IdArticulo;
                }

                this.Text = "Editar";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void AEArtEmp_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "ResumenEmpleado")
            {
                ResumenEmpleado frm = (ResumenEmpleado)this._form;
                frm.Enabled = true;
                frm.CargarArticulosEmpleado();
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarArticuloEmp();
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AgregarArticuloEmp()
        {
            if (this.cmb_art.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el articulo");
                this.cmb_art.Focus();
            }
            else if(this.cmb_emp.SelectedValue==null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");
                this.cmb_art.Focus();
            }
            else if(this.txt_cantidad.Text.Trim().Length == 0||this.txt_cantidad.Text==string.Empty)
            {
                MessageBox.Show("Favor de capturar la cantidad");
                this.txt_cantidad.Focus();
            }
            else
            {
                artemp.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                artemp.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);
                artemp.IdArticulo = Convert.ToInt32(this.cmb_art.SelectedValue);
                artemp.IdEstatus = 1;
                artemp.Fecha = this.dtm_fecha.Value;

                if (idArtEmp != 0)
                {
                    artemp.IdUsMod = this.uslog.IdUsuario;
                    artemp.FMod = DateTime.Now;
                    this.db.Entry(artemp).State = EntityState.Modified;
                    MessageBox.Show("Articulo actualizado exitosamente");


                }
                else
                {
                    artemp.IdUsCreo = this.uslog.IdUsuario;
                    artemp.FCreo = DateTime.Now;
                    this.db.ArticulosEmp.Add(artemp);
                    MessageBox.Show("Articulo agregado exitosamente");
                }
                this.db.SaveChanges();
                this.Close();
            }

        }
    }
}
