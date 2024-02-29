using GMap.NET;
using SIT.Views.Catalogos.CBancos;
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

namespace SIT.Views.Catalogos.CCuentasBancos
{
    public partial class VCuentasBancarias : Form
    {
        public VCuentasBancarias(Usuarios usuarios)
        {
            InitializeComponent();
            this._uslog = usuarios;
        }

        SITEntities db = new SITEntities();
        CuentasBancos cuentas = new CuentasBancos();
        Usuarios _uslog;
        int IdCuenta = 0;

        public void CargarCuentas()
        {
            IdCuenta = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var x = from c in db.CuentasBancos
                    join b in db.Bancos on c.IdBanco equals b.IdBanco
                    where c.IdEstatus==1
                    select new
                    {
                        c.IdCuenta,
                        c.Cuenta,
                        b.Banco

                    };

            this.dgrid_cuentas.DataSource = x.ToList();
            this.dgrid_cuentas.Columns[0].Visible = false;
            this.dgrid_cuentas.EnableHeadersVisualStyles = false;
            this.dgrid_cuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_cuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_cuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void VCuentasBancarias_Load(object sender, EventArgs e)
        {
            CargarCuentas();
            CargarFiltros();
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_cuentas.Columns)
            {
                if (col.Index > 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;

        }

        private void CargarxFiltro()
        {

            if (this.txt_filtro.Text != "" && this.txt_filtro.Text!=string.Empty && this.txt_filtro.Text.Trim().Length!=0)
            {
                var filtro = this.cmb_filtro.Text;
                if (filtro == "Cuenta")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from n in db.CuentasBancos
                                join b in db.Bancos on n.IdBanco equals b.IdBanco
                                where n.Cuenta.Contains(filter) && n.IdEstatus == 1
                                select new
                                {
                                    n.IdCuenta,
                                    n.Cuenta,
                                    b.Banco
                                };
                        this.dgrid_cuentas.DataSource = x.ToList();
                        this.dgrid_cuentas.Columns[0].Visible = false;
                        this.dgrid_cuentas.EnableHeadersVisualStyles = false;
                        this.dgrid_cuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_cuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_cuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }

                else if (filtro == "Banco")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from n in db.CuentasBancos
                                join b in db.Bancos on n.IdBanco equals b.IdBanco
                                where b.Banco.Contains(filter) && n.IdEstatus == 1
                                select new
                                {
                                    n.IdCuenta,
                                    n.Cuenta,
                                    b.Banco
                                };
                        this.dgrid_cuentas.DataSource = x.ToList();
                        this.dgrid_cuentas.Columns[0].Visible = false;
                        this.dgrid_cuentas.EnableHeadersVisualStyles = false;
                        this.dgrid_cuentas.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_cuentas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_cuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }

            }
            else
            {
                CargarCuentas();
                this.dgrid_cuentas.Refresh();

            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AECuentasBancarias frm = new AECuentasBancarias();
            frm.IdCuenta = IdCuenta;
            frm.IdUsuario = _uslog.IdUsuario;
            frm.vcuentas = this;
            this.Enabled = false;
            frm.Show();
        }

        private void CancelarCuenta()
        {
            cuentas = db.CuentasBancos.Where(x => x.IdCuenta == IdCuenta).FirstOrDefault();
            cuentas.IdEstatus = 2;
            cuentas.FechaCancelacion = DateTime.Now;
            cuentas.IdUsuarioCancelo = _uslog.IdUsuario;

            if (IdCuenta > 0)
            {
                db.Entry(cuentas).State = EntityState.Modified;
                MessageBox.Show("Cuenta cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarCuentas();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar la cuenta");
            }
        }

        private void dgrid_cuentas_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_cuentas.CurrentCell.RowIndex != -1)
                {
                    IdCuenta = Convert.ToInt32(this.dgrid_cuentas.CurrentRow.Cells[0].Value);
                }
                else
                {
                    IdCuenta = 0;
                    this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar la cuenta seleccionada", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarCuenta();

            }
            else
            {
                // Do something
            }
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            CargarxFiltro();
        }
    }
}
