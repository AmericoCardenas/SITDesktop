using SIT.Views.General.CRequisiciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Logistica.CIncidencias
{
    public partial class VCatIncidencia : Form
    {
        public VCatIncidencia(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        int idCatIncidencia = 0;
        SITEntities db = new SITEntities();
        public Usuarios _uslog;
        CatIncidencias cat = new CatIncidencias();
        Form _form;

        public void CargarCatalogoIncidencias()
        {
            idCatIncidencia = 0;
            this.btn_add.BackgroundImage = Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            var x = from n in db.CatIncidencias
                    where n.IdEstatus == 1
                    select new
                    {
                        n.IdIncidencia,
                        n.Descripcion,
                        n.Monto
                    };

            this.dgrid_catincidencias.DataSource = null;
            this.dgrid_catincidencias.DataSource = x.ToList();
            this.dgrid_catincidencias.Columns[0].Visible = false;
            this.dgrid_catincidencias.EnableHeadersVisualStyles = false;
            this.dgrid_catincidencias.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_catincidencias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_catincidencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AECatIncidencias frm = new AECatIncidencias(this);
            frm._uslog = this._uslog;
            frm.idIncidencia=idCatIncidencia;
            this.Enabled = false;
            frm.Show();
        }

        private void dgrid_catincidencias_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_catincidencias.CurrentCell.RowIndex != -1)
                {
                    idCatIncidencia = Convert.ToInt32(this.dgrid_catincidencias.CurrentRow.Cells[0].Value);
                    cat = db.CatIncidencias.Where(x => x.IdIncidencia == idCatIncidencia).FirstOrDefault();
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            }
            catch (Exception ex) { }
        }

        private void VCatIncidencia_Load(object sender, EventArgs e)
        {
            CargarCatalogoIncidencias();
            CargarFiltros();
        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_catincidencias.Columns)
            {
                if (col.Index > 0 && col.Visible==true)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }

            }
            this.cmb_filtro.SelectedIndex = 0;
        }

        private void VCatIncidencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._form.Name == "VIncidencias")
            {
                VIncidencias vIncidencias = (VIncidencias)this._form;
                vIncidencias.Enabled = true;
            }
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            if (txt_filtro.Text != "")
            {
                var texto = txt_filtro.Text;
                var filtro = this.cmb_filtro.Text;
                if (filtro == "Descripcion")
                {
                
                    try
                    {
                        var x = from n in db.CatIncidencias
                                where n.IdEstatus == 1 && n.Descripcion.Contains(texto)
                                select new
                                {
                                    n.IdIncidencia,
                                    n.Descripcion,
                                    n.Monto
                                };

                        this.dgrid_catincidencias.DataSource = null;
                        this.dgrid_catincidencias.DataSource = x.ToList();
                        this.dgrid_catincidencias.Columns[0].Visible = false;
                        this.dgrid_catincidencias.EnableHeadersVisualStyles = false;
                        this.dgrid_catincidencias.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                        this.dgrid_catincidencias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        this.dgrid_catincidencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    CargarCatalogoIncidencias();
                    this.dgrid_catincidencias.Refresh();
                }
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cancelar el tipo de incidencia?", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarTipoIncidencia();

            }
            else
            {
                // Do something
            }
        }

        private void CancelarTipoIncidencia()
        {

                cat = db.CatIncidencias.Where(x => x.IdIncidencia == idCatIncidencia).FirstOrDefault();
                cat.IdEstatus = 2;
                cat.FCan = DateTime.Now;
                cat.IdUsCan = _uslog.IdUsuario;

                if (idCatIncidencia > 0)
                {
                    db.Entry(cat).State = EntityState.Modified;
                    MessageBox.Show("Cancelada exitosamente");
                    db.SaveChanges();
                    CargarCatalogoIncidencias();
                }
                else
                {
                    MessageBox.Show("Favor de seleccionar el tipo de incidencia a cancelar");
                }
            

        }

    }
}
