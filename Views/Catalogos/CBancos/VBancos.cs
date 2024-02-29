using GMap.NET;
using SIT.Views.Catalogos.CProveedores;
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

namespace SIT.Views.Catalogos.CBancos
{
    public partial class VBancos : Form
    {
        public VBancos(Usuarios usuarios)
        {
            InitializeComponent();
            this._uslog = usuarios;
        }

        int IdBanco = 0;
        SITEntities db = new SITEntities();
        Bancos bancos = new Bancos();
        Usuarios _uslog;

        private void VBancos_Load(object sender, EventArgs e)
        {
            CargarBancos();
            CargarFiltros();

        }

        public void CargarBancos()
        {
            IdBanco = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            var x = from n in db.Bancos
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdBanco,
                        n.Banco
                    };
            this.dgrid_bancos.DataSource = x.ToList();
            this.dgrid_bancos.Columns[0].Visible = false;
            this.dgrid_bancos.EnableHeadersVisualStyles = false;
            this.dgrid_bancos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_bancos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_bancos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_bancos.Columns)
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

            if (txt_filtro.Text != "")
            {
                var filtro = this.cmb_filtro.Text;
                if (filtro == "Banco")
                {
                    try
                    {
                        var filter = this.txt_filtro.Text;
                        var x = from n in db.Bancos
                                where n.Banco.Contains(filter) && n.IdEstatus == 1
                                select new
                                {
                                    n.IdBanco,
                                    n.Banco
                                };
                        this.dgrid_bancos.DataSource = x.ToList();
                        this.dgrid_bancos.Columns[0].Visible = false;
                        this.dgrid_bancos.EnableHeadersVisualStyles = false;
                        this.dgrid_bancos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_bancos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_bancos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    CargarBancos();
                    this.dgrid_bancos.Refresh();
                }
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AEBancos frm = new AEBancos();
            frm.IdBanco = IdBanco;
            frm.IdUsuario = _uslog.IdUsuario;
            frm.vbancos = this;
            this.Enabled = false;
            frm.Show();
        }

        private void CancelarBanco()
        {
            bancos = db.Bancos.Where(x => x.IdBanco == IdBanco).FirstOrDefault();
            bancos.IdEstatus = 2;
            bancos.FechaCancelacion = DateTime.Now;
            bancos.IdUsuarioCancelo = _uslog.IdUsuario;

            if (IdBanco > 0)
            {
                db.Entry(bancos).State = EntityState.Modified;
                MessageBox.Show("Banco cancelado exitosamente");
                this.btn_add.BackgroundImage = Properties.Resources.mas;
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                db.SaveChanges();
                CargarBancos();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el banco");
            }
        }


        private void dgrid_bancos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_bancos.CurrentCell.RowIndex != -1)
                {
                    IdBanco = Convert.ToInt32(this.dgrid_bancos.CurrentRow.Cells[0].Value);
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
            DialogResult result = MessageBox.Show("Desea cancelar el banco seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarBanco();

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
