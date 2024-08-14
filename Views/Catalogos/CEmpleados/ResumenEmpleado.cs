using GMap.NET;
using SIT.Views.RH.CUniformes;
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

namespace SIT.Views.Catalogos.CEmpleados
{
    public partial class ResumenEmpleado : Form
    {
        public ResumenEmpleado(Form form)
        {
            InitializeComponent();
            this._form = form;
        }

        public int idempleado,iddocemp,idartemp;
        public string nombre_empleado,puesto;
        public Usuarios uslog;
        Form _form;
        SITEntities db = new SITEntities();
        DocsEmpleado docemp = new DocsEmpleado();
        ArticulosEmp artemp = new ArticulosEmp();



        private void ResumenEmpleado_Load(object sender, EventArgs e)
        {
            this.lbl_nomemp.Text = nombre_empleado.ToUpper();
            this.lbl_puesto.Text = puesto.ToUpper();
            this.Text = nombre_empleado.ToUpper();
            if (tbcontrol.SelectedIndex == 0)
            {
                CargarDomicilio();
            }

            this.dgrid_bancemp.EnableHeadersVisualStyles = false;
            this.dgrid_bancemp.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_bancemp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_bancemp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_docs.EnableHeadersVisualStyles = false;
            this.dgrid_docs.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_docs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_docs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_domemp.EnableHeadersVisualStyles = false;
            this.dgrid_domemp.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_domemp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_domemp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_eqcom.EnableHeadersVisualStyles = false;
            this.dgrid_eqcom.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_eqcom.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_eqcom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_eqmov.EnableHeadersVisualStyles = false;
            this.dgrid_eqmov.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_eqmov.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_eqmov.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_lineaemp.EnableHeadersVisualStyles = false;
            this.dgrid_lineaemp.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_lineaemp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_lineaemp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_articulos.EnableHeadersVisualStyles = false;
            this.dgrid_articulos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_articulos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_articulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgrid_inc_emp.EnableHeadersVisualStyles = false;
            this.dgrid_inc_emp.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_inc_emp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_inc_emp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void ResumenEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            _form.Enabled = true;
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.tbcontrol.SelectedIndex == 0)
            {
                CargarDomicilio();
            }
            else if(this.tbcontrol.SelectedIndex == 1)
            {
                CargarDatosBancarios();
            }
            else if(this.tbcontrol.SelectedIndex == 2)
            {
                CargarEquiposComputo();
            }
            else if (this.tbcontrol.SelectedIndex == 3)
            {
                CargarEquiposMovil();
            }
            else if (this.tbcontrol.SelectedIndex == 4)
            {
                CargarLineas();
            }
            else if (this.tbcontrol.SelectedIndex == 5)
            {
                CargarIncidencias();
            }
            else if (this.tbcontrol.SelectedIndex == 6)
            {
                CargarDocumentacion();
            }
            else if (this.tbcontrol.SelectedIndex == 7)
            {
                CargarArticulosEmpleado();
            }

        }


    private void CargarIncidencias()
        {
            var x = from i in db.IncidenciasOperaciones
                    join t in db.Trabajadores on i.IdEmpleado equals t.IdEmpleado
                    join c in db.CatIncidencias on i.IdCatIncidencia equals c.IdIncidencia
                    join u in db.Usuarios on i.IdUsCreo equals u.IdUsuario
                    where i.IdEstatus == 1 && i.IdEmpleado == idempleado
                    select new
                    {
                        i.IdIncidencia,
                        i.Fecha,
                        c.Descripcion,
                        i.Observaciones,
                        Capturo = u.Nombre +" "+ u.Apellidop+" "+u.Apellidom
                    };

            this.dgrid_inc_emp.DataSource = x.ToList();
        }

    private void CargarDocumentacion()
    {
        var x = from d in db.DocsEmpleado
                join doc in db.CatDocsEmp on d.IdDoc equals doc.IdDoc
                where d.IdEstatus == 1 && d.IdEmpleado == idempleado
                select new
                {
                    d.IdDocEmp,
                    Fecha = d.FCreo,
                    doc.Documento,
                    d.Direccion,
                    d.FileName
                };

        this.dgrid_docs.DataSource = x.ToList();
            this.dgrid_docs.Columns["Direccion"].Visible = false;
            this.dgrid_docs.Columns["FileName"].Visible = false;

        }

        private void CargarDomicilio()
        {
            var domicilio = db.DomicilioEmpleados.Where(x=>x.IdEmpleado==idempleado).ToList();
            this.dgrid_domemp.DataSource = domicilio;
            foreach(DataGridViewColumn col in this.dgrid_domemp.Columns)
            {
                col.AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dgrid_domemp.Columns["IdDomicilioEmp"].Visible = false;
            this.dgrid_domemp.Columns["IdEmpleado"].Visible = false;
            this.dgrid_domemp.Columns["IdBitad"].Visible = false;

        }

        private void CargarDatosBancarios()
        {
            var bancarios = db.DatosNominaEmpleados.Where(x=>x.IdEmpleado==idempleado).ToList().ToList();
            this.dgrid_bancemp.DataSource = bancarios;
            this.dgrid_bancemp.Columns["IdNomina"].Visible = false;
            this.dgrid_bancemp.Columns["IdEmpleado"].Visible = false;
            this.dgrid_bancemp.Columns["IdBitad"].Visible = false;
        }

        private void CargarEquiposComputo()
        {
            var eqcomputo = db.EquiposComputo.Where(x => x.IdEmpleado == idempleado).ToList();
            this.dgrid_eqcom.DataSource = eqcomputo;
            this.dgrid_eqcom.Columns["IdEquipoComputo"].Visible = false;
            this.dgrid_eqcom.Columns["IdEmpleado"].Visible = false;
        }

        private void CargarEquiposMovil()
        {
            var eqmovil = db.EquiposMovil.Where(x => x.IdEmpleado == idempleado).ToList();
            this.dgrid_eqmov.DataSource = eqmovil;
            this.dgrid_eqmov.Columns["IdEquipoMovil"].Visible = false;
            this.dgrid_eqmov.Columns["IdEmpleado"].Visible = false;
        }

        private void dgrid_docs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var doc = this.dgrid_docs.CurrentRow.Cells[3].Value.ToString() + this.dgrid_docs.CurrentRow.Cells[4].Value.ToString();
                System.Diagnostics.Process.Start(doc);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btn_cancel_doc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el documento seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarDocEmp();

            }
            else
            {
                // Do something
            }
        }

        private void CancelarDocEmp()
        {
            docemp.IdEstatus = 2;
            docemp.FCan = DateTime.Now;
            docemp.IdUsCan = this.uslog.IdUsuario;

            if (iddocemp > 0)
            {
                this.db.Entry(docemp).State = EntityState.Modified;
                this.db.SaveChanges();
                MessageBox.Show("Documento cancelado exitosamente");
                CargarDocumentacion();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el documento a cancelar");
            }
        }

        private void CancelarArticuloEmp()
        {
            artemp.IdEstatus = 2;
            artemp.FCan = DateTime.Now;
            artemp.IdUsCan = this.uslog.IdUsuario;

            if (idartemp > 0)
            {
                this.db.Entry(artemp).State = EntityState.Modified;
                this.db.SaveChanges();
                MessageBox.Show("Articulo cancelado exitosamente");
                CargarArticulosEmpleado();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar el articulo a cancelar");
            }
        }

        private void btn_add_art_Click(object sender, EventArgs e)
        {
            AEArtEmp frm = new AEArtEmp(this);
            frm.uslog= this.uslog;
            frm.idEmpleado = idempleado;
            frm.idArtEmp = idartemp;
            this.Enabled = false;
            frm.Show();
        }

        private void dgrid_docs_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_docs.CurrentCell.RowIndex != -1)
                {
                    iddocemp = Convert.ToInt32(this.dgrid_docs.CurrentRow.Cells[0].Value);
                    docemp = this.db.DocsEmpleado.Where(x => x.IdDocEmp == iddocemp).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_can_art_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar el articulo seleccionado", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarArticuloEmp();

            }
            else
            {
                // Do something
            }
        }

        private void dgrid_articulos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_articulos.CurrentCell.RowIndex != -1)
                {
                    idartemp = Convert.ToInt32(this.dgrid_articulos.CurrentRow.Cells[0].Value);
                    artemp = this.db.ArticulosEmp.Where(x => x.IdArtEmp == idartemp).FirstOrDefault();
                    this.btn_add_art.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                    this.btn_add_art.BackgroundImageLayout = ImageLayout.Stretch;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CargarLineas()
        {
            var lineas = this.db.Lineas.Where(x => x.IdEmpleado == idempleado).ToList();
            this.dgrid_lineaemp.DataSource = lineas;
            this.dgrid_lineaemp.Columns["IdLinea"].Visible = false;
            this.dgrid_lineaemp.Columns["IdEmpleado"].Visible = false;
            this.dgrid_lineaemp.Columns["IdProveedor"].Visible = false;
            this.dgrid_lineaemp.Columns["IdEstatus"].Visible = false;
            this.dgrid_lineaemp.Columns["Trabajadores"].Visible = false;
        }

        public void CargarArticulosEmpleado()
        {
            idartemp = 0;
            this.btn_add_art.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
            this.btn_add_art.BackgroundImageLayout = ImageLayout.Stretch;


            var x = from a in db.ArticulosEmp
                    join t in db.Trabajadores on a.IdEmpleado equals t.IdEmpleado
                    join art in db.CatArticulosRh on a.IdArticulo equals art.IdArticulo
                    where a.IdEstatus == 1 && a.IdEmpleado==idempleado
                    select new
                    {
                        a.IdArtEmp,
                        a.Fecha,
                        art.Articulo,
                        a.Cantidad
                    };

            this.dgrid_articulos.DataSource = x.ToList();


        }

    }
}
