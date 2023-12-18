using SIT.Views.Catalogos;
using SIT.Views.Catalogos.CUnidades;
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

namespace SIT.Views.Gestoria.CPolizas
{
    public partial class AEPolizas : Form
    {
        public AEPolizas(VPolizas frm)
        {
            InitializeComponent();
            this._frm = frm;
        }

        public int IdPoliza;
        public int IdUsuario;
        SITEntities db = new SITEntities();
        PolizasUnidades pol = new PolizasUnidades();
        VPolizas _frm;

        private void AEPolizas_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            CargarUnidades();

            if (IdPoliza != 0)
            {
                pol = db.PolizasUnidades.Where(x => x.IdPoliza == IdPoliza).FirstOrDefault();
                this.txt_npoliza.Text = pol.NumPoliza;
                this.txt_costo.Text = pol.Costo.ToString();
                this.txt_endoso.Text = pol.Endoso;
                this.txt_inciso.Text = pol.Inciso;
                this.cmb_proveedor.SelectedValue = pol.IdProveedor;
                this.cmb_unidad.SelectedValue = pol.IdUnidad;
                this.dtm_fvenc.Value = Convert.ToDateTime(pol.FVencimiento);
                this.Text = "Editar " + pol.NumPoliza.ToString();
            }
            else
            {
                this.Text = "Agregar";
            }

        }

        private void AgregarPoliza()
        {
            bool bolcosto;
            Double costo;
            bolcosto = Double.TryParse(this.txt_costo.Text, out costo);

            if (this.txt_costo.Text == "" || this.txt_costo.Text.Trim().Length == 0 || bolcosto == false)
            {
                MessageBox.Show("Favor de introducir el costo anual de la poliza");
                this.txt_costo.Focus();
            }
            else if (this.cmb_proveedor.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el proveedor");
                this.cmb_proveedor.Focus();
            }
            else if (this.txt_npoliza.Text == "" || this.txt_npoliza.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de introducir el numero de poliza");
                this.txt_npoliza.Focus();
            }
            else if (this.txt_endoso.Text == "" || this.txt_endoso.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el endoso");
                this.txt_endoso.Focus();
            }
            else if (this.cmb_unidad.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar la unidad");
                this.cmb_unidad.Focus();
            }
            else if (this.txt_inciso.Text == "" || this.txt_inciso.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el inciso");
                this.txt_inciso.Focus();
            }
            else
            {
                pol.IdProveedor = Convert.ToInt32(this.cmb_proveedor.SelectedValue);
                pol.NumPoliza = this.txt_npoliza.Text;
                pol.Costo = costo;
                pol.Endoso = this.txt_endoso.Text.Trim().ToUpper();
                pol.Inciso = this.txt_inciso.Text;
                pol.IdUnidad = Convert.ToInt32(this.cmb_unidad.SelectedValue);
                pol.FVencimiento = this.dtm_fvenc.Value;
                pol.FechaCreacion = DateTime.Now;
                pol.IdUsuarioCreo = IdUsuario;

                if (IdPoliza > 0)
                {

                    DialogResult result = MessageBox.Show("Desea editar la poliza", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        pol.IdUsuarioModifico = IdUsuario;
                        pol.FechaModificacion = DateTime.Now;
                        db.Entry(pol).State = EntityState.Modified;
                        MessageBox.Show("Poliza actualizada exitosamente");
                    }
                    else
                    {
                        IdPoliza = 0;
                    }

                }
                else
                {
                    db.PolizasUnidades.Add(pol);
                    MessageBox.Show("Poliza agregada exitosamente");

                }
                db.SaveChanges();
                this.Close();
            }
        }


        private void CargarProveedores()
        {
            var x = db.Proveedores.ToList();
            this.cmb_proveedor.DataSource = x;
            this.cmb_proveedor.ValueMember = "IdProveedor";
            this.cmb_proveedor.DisplayMember = "Proveedor";
        }

        private void CargarUnidades()
        {
            var x = db.Unidades.ToList();
            this.cmb_unidad.DataSource = x;
            this.cmb_unidad.ValueMember = "IdUnidad";
            this.cmb_unidad.DisplayMember = "Economico";
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarPoliza();
        }
    }
}
