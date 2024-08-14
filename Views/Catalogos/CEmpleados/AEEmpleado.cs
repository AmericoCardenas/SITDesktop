using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Catalogos.CEmpleados
{
    public partial class AEEmpleado : Form
    {
        public AEEmpleado(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        public Usuarios uslog;
        public int IdEmpleado;
        string ruta = "\\\\192.168.1.213\\DocumentosSIT\\DocsEmp\\";
        SITEntities db = new SITEntities();
        Trabajadores tr = new Trabajadores();
        OpenFileDialog op = new OpenFileDialog();
        DocsEmpleado docsemp = new DocsEmpleado();
        VEmpleados vemp;
        Form _form;

        private void CargarDeptos()
        {
            var x = db.Departamentos.ToList();
            this.cmb_depto.DataSource = x;
            this.cmb_depto.ValueMember = "IdDepto";
            this.cmb_depto.DisplayMember = "Departamento";
        }

        private void CargarTipos()
        {
            var x = db.Puestos.ToList();
            this.cmb_tipo.DataSource = x;
            this.cmb_tipo.ValueMember = "IdPuesto";
            this.cmb_tipo.DisplayMember = "Puesto";
        }

        private void AEEmpleado_Load(object sender, EventArgs e)
        {
            CargarDeptos();
            CargarTipos();
            CargarDocEmpleado();
            if (IdEmpleado != 0)
            {
                tr = db.Trabajadores.Where(x => x.IdEmpleado == IdEmpleado).FirstOrDefault();
                this.txt_nombre.Text = tr.Nombre;
                this.txt_apmaterno.Text = tr.ApellidoM;
                this.txt_appaterno.Text = tr.Apellidop;

                if (tr.FIngreso != null)
                {
                    this.dtm_fingreso.Value = Convert.ToDateTime(tr.FIngreso);

                }



                if (tr.IdDepto != null)
                {
                    this.cmb_depto.SelectedValue = tr.IdDepto;

                }

                if (tr.IdPuesto != null)
                {
                    this.cmb_tipo.SelectedValue = tr.IdPuesto;

                }
                this.Text = "Editar ";
            }
            else
            {
                this.Text = "Agregar";
            }
        }

        private void AgregarEmpleado()
        {
            if (this.txt_nombre.Text == string.Empty || this.txt_nombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el nombre del empleado");
                this.txt_nombre.Focus();
            }
            else if (this.txt_apmaterno.Text == string.Empty || this.txt_apmaterno.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el apellido materno del empleado");
                this.txt_apmaterno.Focus();
            }
            else if (this.txt_appaterno.Text == string.Empty || this.txt_appaterno.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el apellido paterno del empleado");
                this.txt_appaterno.Focus();
            }
            else if (this.cmb_depto.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el departamento al que corresponde el empleado");
                this.cmb_depto.Focus();
            }
            else if (this.cmb_tipo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el tipo al que corresponde el empleado");
                this.cmb_tipo.Focus();
            }
            else
            {

                tr.Nombre = this.txt_nombre.Text.ToUpper();
                tr.ApellidoM = this.txt_apmaterno.Text.ToUpper();
                tr.Apellidop = this.txt_appaterno.Text.ToUpper();
                tr.NombreCompleto = this.txt_appaterno.Text.ToUpper() + " " + this.txt_apmaterno.Text.ToUpper() + " " + this.txt_nombre.Text.ToUpper();
                tr.IdEstatus = 1;
                tr.IdDepto = Convert.ToInt32(this.cmb_depto.SelectedValue);
                tr.IdPuesto = Convert.ToInt32(this.cmb_tipo.SelectedValue);
                tr.FIngreso = this.dtm_fingreso.Value;
                tr.FechaCreacion = DateTime.Now;
                tr.IdUsuarioCreo = this.uslog.IdUsuario;

                if (IdEmpleado > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar el empleado", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        tr.IdUsuarioModifico = this.uslog.IdUsuario;
                        tr.FechaModificacion = DateTime.Now;
                        db.Entry(tr).State = EntityState.Modified;
                        MessageBox.Show("Empleado actualizado exitosamente");
                    }
                    else
                    {
                    }

                }
                else
                {
                    db.Trabajadores.Add(tr);
                    MessageBox.Show("Empleado agregado exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarEmpleado();
        }

        private void AEEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            vemp = (VEmpleados)this._form;
            vemp.Enabled = true;
            vemp.CargarEmpleados(1);
        }

        private void txt_totvacaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CargarDocEmpleado()
        {
            var x = this.db.CatDocsEmp.Where(y => y.IdEstatus == 1).ToList();
            this.cmb_docs.DataSource = x;
            this.cmb_docs.DisplayMember = "Documento";
            this.cmb_docs.ValueMember = "IdDoc";
        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            op.Multiselect = true;
            op.Filter = "|*.pdf;";
            op.ShowDialog();
            if (op.FileName != null && op.FileName != string.Empty && op.SafeFileName != null && op.SafeFileName != string.Empty)
            {
                AgregarDocumentoEmp(op.FileName.ToString(), op.SafeFileName.ToString());
            }
            //this.btn_cargarfactura.BackColor = System.Drawing.Color.Green;
        }

        private void AgregarDocumentoEmp(string filename, string safefilename)
        {
            if (this.cmb_docs.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el documento a registrar");
                this.cmb_docs.Focus();
            }
            else
            {
                docsemp.IdEmpleado = IdEmpleado;
                docsemp.Direccion = ruta;
                docsemp.FileName = safefilename;
                docsemp.IdEstatus = 1;
                docsemp.IdDoc = Convert.ToInt32(this.cmb_docs.SelectedValue);
                docsemp.FCreo = DateTime.Now;
                docsemp.IdUsCreo = this.uslog.IdUsuario;


                var FName = filename.Split('\\');
                if (File.Exists(ruta + FName[FName.Length - 1]))
                {

                }
                else
                {
                    File.Copy(filename, ruta + FName[FName.Length - 1]);
                }

                this.db.DocsEmpleado.Add(docsemp);
                this.db.SaveChanges();

                MessageBox.Show("El documento se registro correctamente");
            }

        }

        private void btn_resumen_Click(object sender, EventArgs e)
        {
            ResumenEmpleado frm = new ResumenEmpleado(this);
            frm.uslog = this.uslog;
            frm.idempleado = IdEmpleado;
            frm.puesto = this.cmb_depto.Text;
            frm.nombre_empleado = this.txt_nombre.Text + " " + this.txt_appaterno.Text + " " + this.txt_apmaterno.Text;
            frm.Show();
            this.Enabled = false;
        }
    }
}
