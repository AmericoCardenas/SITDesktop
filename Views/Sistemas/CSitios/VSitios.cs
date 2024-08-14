using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using SIT.Views.Contabilidad.CMovimientos;
using SIT.Views.Sistemas.CSitios;
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

namespace SIT.Views.Sistemas
{
    public partial class VSitios : Form
    {
        public VSitios(Usuarios usuarios)
        {
            InitializeComponent();
            this._usuarios = usuarios;
        }

        SITEntities db = new SITEntities();
        Usuarios _usuarios;
        UsuariosSitios us = new UsuariosSitios();
        int IdUs = 0;

        private void VSitios_Load(object sender, EventArgs e)
        {
            CargarSitios();
            CargarFiltros();
            this.dgrid_sitios.EnableHeadersVisualStyles = false;
            this.dgrid_sitios.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_sitios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_sitios.Columns)
            {
                if (col.Index != 0 && col.Name=="Usuario" || col.Name=="Sitio")
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }
            }

            this.cmb_filtro.SelectedIndex = 0;
        }

        public void CargarSitios()
        {
            var sitios = from x in db.UsuariosSitios
                         join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                         select new
                         {
                             x.IdUs,
                             x.Usuario,
                             x.Contraseña,
                             x.Sitio,
                             t.NombreCompleto
                         } ;
            this.dgrid_sitios.DataSource = sitios.ToList();
            this.dgrid_sitios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_sitios.Columns[0].Visible = false;
        }

        private void dgrid_sitios_Click(object sender, EventArgs e)
        {
            if (this.dgrid_sitios.CurrentCell.RowIndex != -1)
            {
                IdUs = Convert.ToInt32(this.dgrid_sitios.CurrentRow.Cells["IdUs"].Value);
            }

            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AESitios frm = new AESitios(this);
            frm.idsitio = IdUs;
            frm.idusuario = this._usuarios.IdUsuario;
            this.Enabled = false;
            frm.Show();
        }

        private void CargarxFiltro()
        {
            var filtro = this.cmb_filtro.Text;

            if (this.txt_filtro.Text == "")
            {
                CargarSitios();
            }
            else
            {
                if (filtro == "Usuario")
                {
                    try
                    {
                        var x = from sit in db.UsuariosSitios
                                     join t in db.Trabajadores on sit.IdEmpleado equals t.IdEmpleado
                                where sit.Usuario.Contains(this.txt_filtro.Text)
                                     select new
                                     {
                                         sit.IdUs,
                                         sit.Usuario,
                                         sit.Contraseña,
                                         sit.Sitio,
                                         t.NombreCompleto
                                     };
                        this.dgrid_sitios.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }
                else if (filtro == "Sitio")
                {
                    try
                    {
                        var x = from sit in db.UsuariosSitios
                                join t in db.Trabajadores on sit.IdEmpleado equals t.IdEmpleado
                                where sit.Sitio.Contains(this.txt_filtro.Text)
                                select new
                                {
                                    sit.IdUs,
                                    sit.Usuario,
                                    sit.Contraseña,
                                    sit.Sitio,
                                    t.NombreCompleto
                                };
                        this.dgrid_sitios.DataSource = x.ToList();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }

                }


            }
            this.dgrid_sitios.Columns[0].Visible = false;
            this.dgrid_sitios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarxFiltro();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
