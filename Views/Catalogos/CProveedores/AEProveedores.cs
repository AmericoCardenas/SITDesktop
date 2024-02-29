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
        DomiciliosProveedores dom = new DomiciliosProveedores();
        Proveedores prov = new Proveedores();
        SITEntities db = new SITEntities();

        private void AgregarProveedor()
        {
            if (this.txt_proveedor.Text == string.Empty || this.txt_proveedor.Text.Trim().Length==0)
            {
                MessageBox.Show("Favor de introducir el proveedor");
                this.txt_proveedor.Focus();
            }
            else if (this.txt_razon.Text == string.Empty || this.txt_razon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de insertar la razon social");
                this.txt_razon.Focus();
            }
            else if (this.txt_rfc.Text == string.Empty || this.txt_rfc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de insertar el RFC");
                this.txt_rfc.Focus();
            }
            else if (this.cmb_regimen.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el regimen fiscal");
                this.txt_rfc.Focus();
            }
            else if (this.txt_cp.Text == string.Empty || this.txt_cp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de insertar el codigo postal");
                this.txt_rfc.Focus();
            }
            else if(this.txt_calle.Text==string.Empty || this.txt_calle.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de insertar la calle");
                this.txt_calle.Focus();

            }
            else if(this.txt_ciudad.Text==string.Empty || this.txt_ciudad.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de insertar la ciudad");
                this.txt_ciudad.Focus();

            }
            else if(this.txt_colonia.Text==string.Empty || this.txt_colonia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de insertar la colonia");
                this.txt_colonia.Focus();

            }
            else if (this.cmb_pais.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el país");
                this.cmb_pais.Focus();

            }
            else if (this.cmb_estado.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el estado");
                this.cmb_estado.Focus();

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
                        MessageBox.Show("Proveedor actualizado exitosamente");
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

                dom.Calle=this.txt_calle.Text.ToUpper();    
                dom.Ciudad=this.txt_ciudad.Text.ToUpper();
                dom.Colonia=this.txt_colonia.Text.ToUpper();

                if (this.txt_numext.Text == string.Empty)
                {
                    dom.NumeroExt = "0";
                }
                else
                {
                    dom.NumeroExt = this.txt_numext.Text;
                }

                if (this.txt_numint.Text == string.Empty)
                {
                    dom.NumeroInt = "0";
                }
                else
                {
                    dom.NumeroInt = this.txt_numext.Text;
                }

                dom.IdEstado = Convert.ToInt32(this.cmb_estado.SelectedValue);
                dom.IdPais = Convert.ToInt32(this.cmb_pais.SelectedValue);

                if (dom!=null && dom.IdDomicilio == 0)
                {
                    dom.IdProveedor = IdProveedor;
                    db.DomiciliosProveedores.Add(dom);
                    db.SaveChanges();

                }
                else if(dom!=null && dom.IdDomicilio!=0)
                {
                    db.Entry(dom).State = EntityState.Modified;
                    db.SaveChanges();

                }

                db.SaveChanges();
                this.Close();
            }
        }

        private void CargarRegimenes()
        {
            var x = this.db.Regimenes.ToList();
            this.cmb_regimen.DataSource = x;
            this.cmb_regimen.ValueMember = "IdRegimen";
            this.cmb_regimen.DisplayMember = "Regimen";

        }

        private void CargarPaises()
        {
            var x = this.db.Paises.ToList();
            this.cmb_pais.DataSource = x;
            this.cmb_pais.ValueMember = "IdPais";
            this.cmb_pais.DisplayMember = "Pais";
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            AgregarProveedor();
        }

        private void AEProveedores_Load(object sender, EventArgs e)
        {
            CargarRegimenes();
            CargarPaises();

            if (IdProveedor != 0)
            {
                prov = db.Proveedores.Where(x => x.IdProveedor == IdProveedor).FirstOrDefault();
                this.txt_proveedor.Text = prov.Proveedor;
                this.txt_razon.Text = prov.RazonSocial;
                this.txt_rfc.Text=prov.RFC;
                this.txt_cp.Text=prov.CP;
                this.cmb_regimen.SelectedValue = prov.IdRegimenFiscal;

                dom= db.DomiciliosProveedores.Where(x=>x.IdProveedor==IdProveedor).FirstOrDefault();
                if (dom != null)
                {
                    this.txt_calle.Text = dom.Calle;
                    this.txt_ciudad.Text = dom.Ciudad;
                    this.txt_colonia.Text = dom.Colonia;
                    this.txt_numext.Text = dom.NumeroExt;
                    this.txt_numint.Text = dom.NumeroInt;
                    this.cmb_pais.SelectedValue = dom.IdPais;
                    this.cmb_estado.SelectedValue = dom.IdEstado;
                }
                else
                {
                    dom = new DomiciliosProveedores();
                }
                this.Text = "Editar";
            }
        }

        private void cmb_pais_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int idpais = Convert.ToInt32(this.cmb_pais.SelectedValue);
                var x = this.db.Estados.Where(y => y.IdPais == idpais).ToList();
                this.cmb_estado.DataSource = null;
                this.cmb_estado.DataSource = x;
                this.cmb_estado.ValueMember = "IdEstado";
                this.cmb_estado.DisplayMember = "Nombre";

            }
            catch(Exception ex)
            {

            }
        }

        private void AEProveedores_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.vprov.Enabled = true;
            this.vprov.CargarProveedores();
        }
    }
}
