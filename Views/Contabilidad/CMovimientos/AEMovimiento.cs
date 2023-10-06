using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SIT.Views.Contabilidad.CMovimientos
{
    public partial class AEMovimiento : Form
    {
        public AEMovimiento(Form form)
        {
            InitializeComponent();
            this.frm = form;
        }

        Form frm;
        SITEntities db = new SITEntities();
        public Usuarios _uslog;
        DataGridView dgrid;
        Movimientos mov = new Movimientos();
        NotasMovimientos not = new NotasMovimientos();
        OpenFileDialog op1 = new OpenFileDialog();
        public string notaproveedor;
        public List<NotasMovimientos> lst_not;
        public int IdMovimiento;
        string filename = string.Empty;
        string ruta = "\\\\192.168.1.213\\OneDrive - TRANSPORTES DAVILA\\Transportes Davila\\7.- Contabilidad1\\ArchivosMovimientos\\";


        private void AEMovimiento_Load(object sender, EventArgs e)
        {
            this.Text = "Movimiento";
            CargarConceptos();
            CargarMetodos();
            CargarTipos();
            this.txt_numcheque.Text = "0";

            if (IdMovimiento != 0)
            {
                mov = db.Movimientos.Where(x => x.IdMovimiento == IdMovimiento).FirstOrDefault();
                this.dtm_fecha.Value = mov.Fecha.Value;
                this.cmb_tipo.SelectedValue = mov.IdTipo;
                this.cmb_metodo.SelectedValue = mov.IdMetodo;
                this.cmb_concepto.SelectedValue = mov.IdConcepto;
                this.txt_cliente.Text = mov.Cliente;
                this.txt_descripcion.Text = mov.Descripcion;
                this.txt_cantidad.Text = mov.Cantidad.ToString();
                filename = mov.Comprobante;
                this.Text = "Editar";
            }

            if (frm.Name == "VNotas")
            {
                this.txt_cliente.Text = notaproveedor;
                this.txt_cantidad.Text = lst_not.Sum(x => x.Total).ToString();
                this.txt_descripcion.Text = string.Join(",", lst_not.Select(x=>x.IdNota));
                this.txt_cliente.Enabled = false;
                this.txt_cantidad.Enabled = false;
                this.txt_descripcion.Enabled= false;
            }
        }

        private void CargarTipos()
        {
            var x = db.TiposFlujos.ToList();
            this.cmb_tipo.DataSource = x;
            this.cmb_tipo.ValueMember = "IdTipo";
            this.cmb_tipo.DisplayMember = "Tipo";
        }

        private void CargarMetodos()
        {
            var x = db.MetodosFlujos.ToList();
            this.cmb_metodo.DataSource = x;
            this.cmb_metodo.ValueMember = "IdMetodo";
            this.cmb_metodo.DisplayMember = "Metodo";

        }

        private void CargarConceptos()
        {
            var x = db.ConceptosFlujos.ToList();
            this.cmb_concepto.DataSource = x;
            this.cmb_concepto.ValueMember = "IdConcepto";
            this.cmb_concepto.DisplayMember = "Concepto";
        }

        private void AgregarMovimiento()
        {
            Double r;
            if (this.cmb_concepto.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el concepto");
                this.cmb_concepto.Focus();
            }
            else if (this.cmb_tipo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el tipo");
                this.cmb_tipo.Focus();
            }
            else if (this.cmb_metodo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el metodo");
                this.cmb_metodo.Focus();
            }
            else if (this.txt_cliente.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el cliente");
                this.txt_cliente.Focus();
            }
            else if (this.txt_descripcion.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar la descripcion");
                this.txt_descripcion.Focus();
            }
            else if (this.txt_cantidad.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar la cantidad");
                this.txt_cantidad.Focus();
            }
            else if (Double.TryParse(this.txt_cantidad.Text.ToString(), out r) == false)
            {
                MessageBox.Show("Favor de verificar la cantidad");
                this.txt_cantidad.Focus();
            }
            else
            {
                mov.Fecha = dtm_fecha.Value;
                mov.IdTipo = Convert.ToInt32(this.cmb_tipo.SelectedValue);
                mov.IdMetodo = Convert.ToInt32(this.cmb_metodo.SelectedValue);
                mov.Cliente = this.txt_cliente.Text.ToUpper();
                mov.Cantidad = Convert.ToDouble(this.txt_cantidad.Text);
                mov.Descripcion = this.txt_descripcion.Text.ToUpper();
                mov.IdConcepto = Convert.ToInt32(this.cmb_concepto.SelectedValue);
                mov.NumCheque = this.txt_numcheque.Text;
                mov.Ruta = string.Empty;
                mov.Comprobante = string.Empty;
                mov.IdEstatus = 1;
                if (filename != "")
                {
                    mov.Ruta = ruta;
                    mov.Comprobante = filename;
                    int count = 0;

                    string[] FName;

                    foreach (string s in op1.FileNames)

                    {

                        FName = s.Split('\\');

                        if (File.Exists(ruta + FName[FName.Length - 1]))
                        {

                        }
                        else
                        {
                            File.Copy(s, ruta + FName[FName.Length - 1]);
                        }


                        count++;

                    }
                }
                mov.FechaCreacion = DateTime.Now;
                mov.IdUsuarioCreo = this._uslog.IdUsuario;

                if (IdMovimiento > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        mov.IdUsuarioModificacion = _uslog.IdUsuario;
                        mov.FechaModificacion = DateTime.Now;
                        db.Entry(mov).State = EntityState.Modified;
                        MessageBox.Show("Movimiento actualizado exitosamente");
                        this.btn_aceptar.BackgroundImage = Properties.Resources.mas;
                        this.btn_aceptar.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        LimpiarFormulario();
                        IdMovimiento = 0;
                        this.btn_aceptar.BackgroundImage = Properties.Resources.mas;
                        this.btn_aceptar.BackgroundImageLayout = ImageLayout.Stretch;
                    }

                }
                else
                {
                    db.Movimientos.Add(mov);
                    MessageBox.Show("Movimiento agregado exitosamente");
                }

                db.SaveChanges();
                LimpiarFormulario();
                this.Close();


            }
        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            op1.Multiselect = true;
            op1.Filter = "|*.pdf;*.jpeg;*.png;*.jpg";
            op1.ShowDialog();
            filename = op1.SafeFileName;
            this.btn_doc.BackColor = System.Drawing.Color.Green;
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void LimpiarFormulario()
        {
            this.txt_cantidad.Text = string.Empty;
            this.txt_cliente.Text = string.Empty;
            this.txt_descripcion.Text = string.Empty;
            this.cmb_concepto.SelectedIndex = 0;
            this.cmb_metodo.SelectedIndex = 0;
            this.cmb_tipo.SelectedIndex = 0;
            IdMovimiento = 0;
        }

        private void txt_numcheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmb_metodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmb_metodo.Text == "CHEQUE")
            {
                this.lbl_ncheque.Visible = true;
                this.txt_numcheque.Visible = true;
            }
            else
            {
                this.lbl_ncheque.Visible = false;
                this.txt_numcheque.Visible = false;
            }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarMovimiento();
        }

        private void AEMovimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frm.Name == "VMovimientos")
            {
                VMovimientos vmov = new VMovimientos(_uslog);
                vmov.Enabled = true;
                vmov.CargarMovimientos();
            }
            else if(frm.Name == "VNotas")
            {
                var idmov = db.Movimientos
                .OrderByDescending(entity => entity.IdMovimiento)
                .Select(entity => entity.IdMovimiento)
                .FirstOrDefault();

                foreach (NotasMovimientos notmov in lst_not)
                {
                    not = db.NotasMovimientos.Where(x => x.IdNota == notmov.IdNota).FirstOrDefault();
                    not.UsuarioModificacion = _uslog.IdUsuario;
                    not.FechaModificacion = DateTime.Now;
                    not.IdEstatus = 3;
                    not.IdMovimiento = idmov;
                    db.Entry(not).State = EntityState.Modified;
                    db.SaveChanges();
                }

                VNotas vnotas = new VNotas(_uslog);
                vnotas.Enabled = true;
                vnotas.CargarNotas();

            }

        }
    }
}
