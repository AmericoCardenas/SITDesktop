using DocumentFormat.OpenXml.Office2010.Excel;
using GMap.NET;
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
    public partial class AEUsuarios : Form
    {
        public AEUsuarios(VUsuarios vusuarios)
        {
            InitializeComponent();
            this._vusuarios = vusuarios;
        }

        VUsuarios _vusuarios;
        public int idUsuario;
        SITEntities db = new SITEntities();
        public Usuarios usuarios = new Usuarios();

        private void CargarCombos()
        {
            this.cmb_depto.DataSource = db.Departamentos.ToList();
            this.cmb_depto.DisplayMember = "Departamento";
            this.cmb_depto.ValueMember = "IdDepto";

        }

        private void CargarEmpleados()
        {
            this.cmb_empleado.DataSource= this.db.Trabajadores.Where(x=>x.IdEstatus==1).ToList();
            this.cmb_empleado.DisplayMember = "NombreCompleto";
            this.cmb_empleado.ValueMember = "IdEmpleado";

        }

        private void InsertarUsuario()
        {
            if (this.txt_nombre.Text == "" || this.txt_nombre.Text.Trim().Length==0)
            {
                MessageBox.Show("Favor de capturar el nombre");
            }
            else if (this.txt_app.Text == "")
            {
                MessageBox.Show("Favor de capturar el apellido paterno");
            }
            else if (this.txt_apm.Text == "")
            {
                MessageBox.Show("Favor de capturar el apellido materno");
            }
            else if (this.txt_usuario.Text == "")
            {
                MessageBox.Show("Favor de capturar el usuario");
            }
            else if (this.txt_contraseña.Text == "")
            {
                MessageBox.Show("Favor de capturar la contraseña");
            }
            else if (this.cmb_depto.SelectedItem == null)
            {
                MessageBox.Show("Favor de seleccionar el departamento");

            }
            else if (this.cmb_empleado.SelectedItem == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado");

            }
            else
            {
                usuarios.Usuario = this.txt_usuario.Text.Trim();
                usuarios.Password = this.txt_contraseña.Text.Trim();
                usuarios.Nombre = this.txt_nombre.Text.Trim();
                usuarios.Apellidop = this.txt_app.Text.Trim();
                usuarios.Apellidom = this.txt_apm.Text.Trim();
                usuarios.IdEstatus = 1;
                usuarios.IdEmpleado = Convert.ToInt32(this.cmb_empleado.SelectedValue);
                usuarios.IdDepto = Convert.ToInt32(this.cmb_depto.SelectedValue);

                if (usuarios.IdUsuario == 0 || usuarios == null)
                {

                    usuarios.FechaCreacion = DateTime.Now.ToString("dd-MM-yyyy");
                    usuarios.UsuarioCreacion = Convert.ToInt32(idUsuario);
                    db.Usuarios.Add(usuarios);
                    MessageBox.Show("Usuario agregado exitosamente");
                }
                else if (usuarios.IdUsuario != 0 || usuarios!=null)
                {
                    usuarios.IdEstatus = 1;
                    usuarios.FechaModificacion = DateTime.Now.ToString("dd-MM-yyyy");
                    usuarios.UsuarioModificacion = Convert.ToInt32(idUsuario);
                    db.Entry(usuarios).State = EntityState.Modified;
                    MessageBox.Show("Usuario actualizado exitosamente");

                }


                db.SaveChanges();
                this.Close();
            }





        }






        private void btn_add_Click(object sender, EventArgs e)
        {
            InsertarUsuario();

        }

        private void AEUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarEmpleados();

            if(usuarios!=null && usuarios.IdUsuario!=0)
            {
                try
                {
                    this.txt_nombre.Text = usuarios.Nombre.ToUpper();
                    this.txt_apm.Text = usuarios.Apellidom.ToUpper();
                    this.txt_app.Text = usuarios.Apellidop.ToUpper();
                    this.txt_contraseña.Text = usuarios.Password;
                    this.txt_usuario.Text = usuarios.Usuario;
                    this.cmb_depto.SelectedValue = usuarios.IdDepto;
                    this.cmb_empleado.SelectedValue = usuarios.IdEmpleado;

                }
                catch(Exception ex) { }
            }
            else
            {
                usuarios = new Usuarios();
            }
        }

        private void AEUsuarios_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._vusuarios.DataUsuarios(1);
            this._vusuarios.Enabled = true;

        }
    }
}
