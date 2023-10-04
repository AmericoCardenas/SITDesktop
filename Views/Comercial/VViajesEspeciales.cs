using GMap.NET.MapProviders;
using SIT.CrystalReport;
using SIT.Views.Contabilidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Comercial
{
    public partial class VViajesEspeciales : Form
    {
        public VViajesEspeciales(Usuarios usuariolog)
        {
            InitializeComponent();
            this._uslog = usuariolog;
        }

        DataGridView dgrid;
        SITEntities db = new SITEntities();
        ViajesEspeciales vj = new ViajesEspeciales();
        Usuarios _uslog = new Usuarios();
        int IdViaje = 0;

        private void AgregarViajeEspecial()
        {
            double result;
            int res;
            if (this.txt_total.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el total");
                this.txt_total.Focus();
            }
            else if (Double.TryParse(this.txt_total.Text.ToString(), out result) == false)
            {
                MessageBox.Show("Favor de validar el campo total");
                this.txt_total.Focus();
            }
            else if (this.txt_anticipo.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el anticipo");
                this.txt_anticipo.Focus();
            }
            else if (Double.TryParse(this.txt_anticipo.Text.ToString(), out result) == false)
            {
                MessageBox.Show("Favor de validar el campo anticipo");
                this.txt_anticipo.Focus();
            }
            else if (this.txt_pendiente.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el pendiente");
                this.txt_pendiente.Focus();
            }
            else if (Double.TryParse(this.txt_pendiente.Text.ToString(), out result) == false)
            {
                MessageBox.Show("Favor de validar el campo pendiente");
                this.txt_pendiente.Focus();
            }
            else if(this.cmb_metodo.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el metodo de pago");
                this.cmb_metodo.Focus();
            }
            else if (this.txt_unidades.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el campo cantidad unidades");
                this.txt_unidades.Focus();
            }
            else if (Int32.TryParse(this.txt_unidades.Text.ToString(), out res) == false)
            {
                MessageBox.Show("Favor de validar el campo cantidad unidades");
                this.txt_unidades.Focus();
            }
            else if (this.txt_tipounidades.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el campo tipo de unidades");
                this.txt_tipounidades.Focus();
            }
            else if (this.cmb_clientes.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el cliente");
                this.cmb_clientes.Focus();
            }
            else if (this.cmb_estatus.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el cliente");
                this.cmb_estatus.Focus();
            }
            else if (this.txt_observaciones.Text.Trim()=="")
            {
                MessageBox.Show("Favor de capturar el campo observaciones");
                this.txt_observaciones.Focus();
            }
            else if (this.txt_horas.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el campo hora de salida");
                this.txt_horas.Focus();
            }
            else if (this.txt_horal.Text.Trim() == "")
            {
                MessageBox.Show("Favor de capturar el campo hora de llegada");
                this.txt_horal.Focus();
            }
            else
            {
                vj.IdCliente = Convert.ToInt32(this.cmb_clientes.SelectedValue);
                vj.FechaInicio = this.dtm_finicio.Value;
                vj.FechaFin = this.dtm_fin.Value;
                vj.Unidad = this.txt_unidades.Text.ToUpper();
                vj.Origen = this.txt_origen.Text.ToUpper();
                vj.Destino = this.txt_destino.Text.ToUpper();
                vj.Total = Convert.ToDouble(this.txt_total.Text);
                vj.Anticipo = Convert.ToDouble(this.txt_anticipo.Text);
                vj.Pendiente = Convert.ToDouble(this.txt_pendiente.Text);
                vj.IdMetodo = Convert.ToInt32(this.cmb_metodo.SelectedValue);
                vj.Cantidad = Convert.ToInt32(this.txt_unidades.Text);
                vj.Observaciones = this.txt_observaciones.Text.ToUpper();
                vj.HoraLLegada = this.txt_horal.Text;
                vj.HoraSalida = this.txt_horas.Text;
                vj.Telefono = this.txt_telefono.Text;
                vj.IdEstatus = 1;
                vj.FechaCreacion  = DateTime.Now;
                vj.UsuarioCreacion = _uslog.IdUsuario;

                if (IdViaje > 0)
                {
                    DialogResult r = MessageBox.Show("Desea editar el registro", "Editar", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        vj.UsuarioModificacion = _uslog.IdUsuario;
                        vj.FechaModificacion = DateTime.Now;
                        db.Entry(vj).State = EntityState.Modified;
                        MessageBox.Show("Viaje actualizado exitosamente");
                        this.btn_add.BackgroundImage = Properties.Resources.mas;
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        LimpiarFormulario();
                        IdViaje = 0;
                        this.btn_add.BackgroundImage = Properties.Resources.mas;
                        this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else
                {
                    db.ViajesEspeciales.Add(vj);
                    MessageBox.Show("Viaje agregado exitosamente");
                }

                db.SaveChanges();
                LimpiarFormulario();
                CargarViajes();
            }
        }

        private void LimpiarFormulario()
        {
            this.txt_total.Text = "0";
            this.txt_anticipo.Text = "0";
            this.txt_pendiente.Text = "0";
            this.cmb_metodo.SelectedIndex = 0;
            this.txt_unidades.Text = string.Empty;
            this.txt_tipounidades.Text = string.Empty;
            this.cmb_clientes.SelectedIndex = 0;
            this.cmb_estatus.SelectedIndex = 0;
            this.txt_origen.Text=string.Empty;
            this.txt_destino.Text=string.Empty;
            this.txt_observaciones.Text = string.Empty;

        }

        private void CargarClientes()
        {
            var x =  db.Clientes.ToList();
            this.cmb_clientes.DataSource = x;
            this.cmb_clientes.DisplayMember = "RazonSocial";
            this.cmb_clientes.ValueMember = "IdCliente";

        }

        private void CargarMetodos()
        {
            var x = db.MetodosFlujos.ToList();
            this.cmb_metodo.DataSource = x;
            this.cmb_metodo.DisplayMember = "Metodo";
            this.cmb_metodo.ValueMember = "IdMetodo";
        }

        private void CargarEstatus()
        {
            var x = db.EstatusVE.ToList();
            this.cmb_estatus.DataSource = x;
            this.cmb_estatus.DisplayMember = "Estatus";
            this.cmb_estatus.ValueMember = "IdEstatus";

        }

        private void CargarViajes()
        {
            dgrid = new DataGridView();
            int estatus = 0;

            if(tbcontrol.SelectedIndex == 0)
            {
                dgrid = this.dgrid_liquidados;
                estatus = 1;
            }
            else if(tbcontrol.SelectedIndex == 1)
            {
                dgrid = this.dgrid_pendientes;
                estatus = 2;

            }

            var x = from ve in db.ViajesEspeciales
                    join c in db.Clientes on ve.IdCliente equals c.IdCliente
                    join m in db.MetodosFlujos on ve.IdMetodo equals m.IdMetodo
                    join e in db.EstatusVE on ve.IdEstatus equals e.IdEstatus
                    where ve.IdEstatus == estatus
                    select new
                    {

                        ve.IdViaje,
                        c.RazonSocial,
                        ve.FechaInicio,
                        ve.Origen,
                        ve.Destino,
                        ve.Total,
                        ve.Pendiente,
                        ve.Observaciones



                    };

            dgrid.DataSource = x.ToList();
            dgrid.Columns[0].Visible = false;
            dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgrid.EnableHeadersVisualStyles = false;
            dgrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            dgrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private void ViajesEspeciales_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarEstatus();
            CargarMetodos();
            CargarViajes();
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarViajes();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarViajeEspecial();
        }

        private void txt_total_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_anticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txt_pendiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        private void txt_anticipo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double x = Convert.ToDouble(this.txt_total.Text);
                Double y = Convert.ToDouble(this.txt_anticipo.Text);
                Double res;
                if (x < y)
                {
                    MessageBox.Show("El total no puede ser menor al anticipo");
                    this.txt_total.Focus();
                }
                else if (Double.TryParse(this.txt_total.Text.ToString(), out res) == false)
                {
                    MessageBox.Show("Favor de validar el campo total");
                    this.txt_total.Focus();
                }
                else if (Double.TryParse(this.txt_anticipo.Text.ToString(), out res) == false)
                {
                    MessageBox.Show("Favor de validar el campo anticipo");
                    this.txt_anticipo.Focus();
                }
                else
                {
                    this.txt_pendiente.Text = (x - y).ToString();
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }


        }

        private void dgrid_liquidados_Click(object sender, EventArgs e)
        {
            if (this.dgrid_liquidados.CurrentCell.RowIndex != -1)
            {
                IdViaje = Convert.ToInt32(this.dgrid_liquidados.CurrentRow.Cells["IdViaje"].Value);
                vj = db.ViajesEspeciales.Where(x => x.IdViaje == IdViaje).FirstOrDefault();

                this.dtm_finicio.Value = vj.FechaInicio.Value;
                this.dtm_fin.Value = vj.FechaFin.Value;
                this.txt_total.Text = vj.Total.ToString();
                this.txt_anticipo.Text = vj.Anticipo.ToString();
                this.txt_pendiente.Text = vj.Pendiente.ToString();
                this.cmb_clientes.SelectedValue = vj.IdCliente;
                this.cmb_metodo.SelectedValue = vj.IdMetodo;
                this.cmb_estatus.SelectedValue = vj.IdEstatus;
                this.txt_unidades.Text = vj.Cantidad.ToString();
                this.txt_tipounidades.Text = vj.Unidad.ToString();
                this.txt_origen.Text = vj.Origen.ToString();
                this.txt_destino.Text = vj.Destino.ToString();
                this.txt_observaciones.Text = vj.Observaciones;
                this.txt_horas.Text = vj.HoraSalida;
                this.txt_horal.Text = vj.HoraLLegada;
                this.txt_telefono.Text = vj.Telefono;

            }
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void txt_horal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }

        }

        private void txt_horas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }

        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void dgrid_liquidados_DoubleClick(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.frm = this;
            frm.idviaje = Convert.ToInt32(this.dgrid_liquidados.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //this.Enabled = false;
        }

        private void dgrid_pendientes_DoubleClick(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.frm = this;
            frm.idviaje = Convert.ToInt32(this.dgrid_liquidados.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            //this.Enabled = false;
        }
    }
}
