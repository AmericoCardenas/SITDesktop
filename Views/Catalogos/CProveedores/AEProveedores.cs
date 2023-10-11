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

namespace SIT.Views.Catalogos.CProveedores
{
    public partial class AEProveedores : Form
    {
        public AEProveedores()
        {
            InitializeComponent();
        }

        public int IdProveedor;
        public int IdUsuario;
        public VProveedores vprov;
        Proveedores prov = new Proveedores();
        SITEntities db = new SITEntities();

        private void AgregarProveedor()
        {
            if (this.txt_proveedor.Text == "")
            {
                MessageBox.Show("Favor de introducir el proveedor");
                this.txt_proveedor.Focus();
            }
            else if (this.txt_razon.Text == "")
            {
                MessageBox.Show("Favor de insertar la razon social");
                this.txt_razon.Focus();
            }
            else if (this.txt_rfc.Text == "")
            {
                MessageBox.Show("Favor de insertar el RFC");
                this.txt_rfc.Focus();
            }
            else if (this.cmb_regimen.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el regimen fiscal");
                this.txt_rfc.Focus();
            }
            else if (this.txt_cp.Text == "")
            {
                MessageBox.Show("Favor de insertar el codigo postal");
                this.txt_rfc.Focus();
            }
            else
            {
                prov.Proveedor = this.txt_proveedor.Text.ToUpper();
                prov.RazonSocial = this.txt_razon.Text.ToUpper();
                prov.RFC = this.txt_rfc.Text.ToUpper();
                prov.CP = this.txt_cp.Text;
                prov.IdRegimenFiscal = Convert.ToInt32(this.cmb_regimen.SelectedValue);
                prov.FechaCreacion = DateTime.Now;
                prov.UsuarioCreacion = this.IdUsuario;
                prov.IdEstatus = 1;

                if (IdProveedor > 0)
                {
                    DialogResult result = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        prov.Proveedor = this.txt_proveedor.Text.ToUpper();
                        prov.UsuarioModificacion = this.IdUsuario;
                        prov.FechaModificacion = DateTime.Now;
                        db.Entry(prov).State = EntityState.Modified;
                        MessageBox.Show("Nota actualizada exitosamente");
                        this.btn_aceptar.BackgroundImage = Properties.Resources.mas;
                        this.btn_aceptar.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        this.btn_aceptar.BackgroundImage = Properties.Resources.mas;
                        this.btn_aceptar.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else
                {
                    db.Proveedores.Add(prov);
                    MessageBox.Show("Proveedor agregado exitosamente");
                }

                db.SaveChanges();
                this.Close();
                vprov.Enabled = true;
                vprov.CargarProveedores();
            }
        }

        private void CargarRegimenes()
        {
            var x = this.db.Regimenes.ToList();
            this.cmb_regimen.DataSource = x;
            this.cmb_regimen.ValueMember = "IdRegimen";
            this.cmb_regimen.DisplayMember = "Regimen";

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarProveedor();
        }

        private void AEProveedores_Load(object sender, EventArgs e)
        {
            CargarRegimenes();

            if (IdProveedor != 0)
            {
                prov = db.Proveedores.Where(x => x.IdProveedor == IdProveedor).FirstOrDefault();
                this.txt_proveedor.Text = prov.Proveedor;
                this.txt_razon.Text = prov.RazonSocial;
                this.txt_rfc.Text=prov.RFC;
                this.txt_cp.Text=prov.CP;
                this.cmb_regimen.SelectedValue = prov.IdRegimenFiscal;
                this.Text = "Editar";
            }
        }
    }
}
