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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SIT.Views.Logistica.CIncidencias
{
    public partial class VIncidencias : Form
    {
        public VIncidencias(Usuarios usuarios)
        {
            InitializeComponent();
            this._uslog = usuarios;
        }

        SITEntities db = new SITEntities();
        IncidenciasOperaciones incidencias = new IncidenciasOperaciones();
        int idIncidencia = 0;
        private Usuarios _uslog;

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_incpend.Columns)
            {
                if (col.Index != 0)
                {
                    this.cmb_filtro.Items.Add(col.Name);
                }
            }

            this.cmb_filtro.SelectedIndex = 0;
        }

        private void btn_catincidencias_Click(object sender, EventArgs e)
        {
            VCatIncidencia frm = new VCatIncidencia(this);
            frm._uslog = this._uslog;
            frm.Show();
            this.Enabled = false;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {

     
                AEIncidencia frm = new AEIncidencia(this);
                frm._uslog = this._uslog;
                frm.idIncidencia = idIncidencia;
                frm.Show();
                this.Enabled = false;
            
        }

        public void CargarIncidencias()
        {
            idIncidencia = 0;
            DataGridView dataGrid = new DataGridView();
            int idestatus = 0;
            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.mas, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

            if (tbcontrol.SelectedIndex == 0)
            {
                if (this._uslog.IdDepto != 7)
                {
                    this.btn_add.Visible = true;
                    this.btn_cancel.Visible = true;
                }

                dataGrid = this.dgrid_incpend;
                idestatus = 1;
                
            }
            else if (tbcontrol.SelectedIndex == 1)
            {
                this.btn_add.Visible = false;
                this.btn_cancel.Visible = false;
                dataGrid = this.dgrid_incaplicadas;
                idestatus = 3;
            }

            if(this._uslog.IdDepto==7 || this._uslog.IdDepto == 3 || this._uslog.IdDepto==4)
            {
                 var x = from n in db.IncidenciasOperaciones
                        join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                        join u in db.Usuarios on n.IdUsCreo equals u.IdUsuario
                        join c in db.CatIncidencias on n.IdCatIncidencia equals c.IdIncidencia
                        join tr in db.Trabajadores on u.IdEmpleado equals tr.IdEmpleado
                        where n.IdEstatus == idestatus
                        orderby n.Fecha descending
                         select new
                        {
                            n.IdIncidencia,
                            n.Fecha,
                            Empleado = t.NombreCompleto,
                            Incidencia=c.Descripcion,
                            n.Monto,
                            n.Observaciones,
                            Capturo = tr.NombreCompleto,
                            FechaCaptura = n.FCreo,
                            FechaNom = n.FNom

                        };

               dataGrid.DataSource = null;
               dataGrid.DataSource = x.ToList();
               dataGrid.Columns[0].Visible = false;
               dataGrid.EnableHeadersVisualStyles = false;
               dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
               dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
               dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else
            {
                var x = from n in db.IncidenciasOperaciones
                        join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                        join c in db.CatIncidencias on n.IdCatIncidencia equals c.IdIncidencia
                        where n.IdEstatus == idestatus && n.IdUsCreo == this._uslog.IdUsuario
                        orderby n.Fecha descending
                        select new
                        {
                            n.IdIncidencia,
                            n.Fecha,
                            Empleado=t.NombreCompleto,
                            Incidencia=c.Descripcion,
                            n.Monto,
                            n.Observaciones
                        };
               dataGrid.DataSource = null;
               dataGrid.DataSource = x.ToList();
               dataGrid.Columns[0].Visible = false;
               dataGrid.EnableHeadersVisualStyles = false;
               dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
               dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
               dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }


        }

        private void dgrid_incpend_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgrid_incpend.CurrentCell.RowIndex != -1)
                {
                    idIncidencia = Convert.ToInt32(this.dgrid_incpend.CurrentRow.Cells[0].Value);
                    incidencias = db.IncidenciasOperaciones.Where(x => x.IdIncidencia == idIncidencia).FirstOrDefault();
                }
                this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
                this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;


            }
            catch (Exception ex) { }
        }

        private void VIncidencias_Load(object sender, EventArgs e)
        {
            CargarIncidencias();
            CargarFiltros();

            if (this._uslog.IdDepto == 7 || this._uslog.IdDepto == 4)
            {
                this.btn_add.Enabled = false;
                this.btn_cancel.Enabled = false;
                this.btn_catincidencias.Enabled = false;
                this.btn_aplicar.Enabled = true;
            }
            else
            {
                this.btn_add.Enabled = true;
                this.btn_cancel.Enabled = true;
                this.btn_catincidencias.Enabled = true;
                this.btn_aplicar.Enabled = false;

            }
        }


        private void CargarxFiltro()
        {
            DataGridView dataGrid = new DataGridView();
            int idestatus = 0;
            var filtro = this.cmb_filtro.Text;
            if (tbcontrol.SelectedIndex == 0)
            {
                if (this._uslog.IdDepto != 7)
                {
                    this.btn_add.Visible = true;
                    this.btn_cancel.Visible = true;
                }

                dataGrid = this.dgrid_incpend;
                idestatus = 1;

            }
            else if (tbcontrol.SelectedIndex == 1)
            {
                this.btn_add.Visible = false;
                this.btn_cancel.Visible = false;
                dataGrid = this.dgrid_incaplicadas;
                idestatus = 3;
            }

            if (this.txt_filtro.Text == string.Empty)
            {
                CargarIncidencias();
            }
            else
            {
                if (filtro == "Fecha")
                {
                    try
                    {
                        var fecha=Convert.ToDateTime(this.txt_filtro.Text);

                        if (this._uslog.IdDepto == 7 || this._uslog.IdDepto == 3 || this._uslog.IdDepto == 4)
                        {
                            var x = from n in db.IncidenciasOperaciones
                                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                                    join u in db.Usuarios on n.IdUsCreo equals u.IdUsuario
                                    join c in db.CatIncidencias on n.IdCatIncidencia equals c.IdIncidencia
                                    join tr in db.Trabajadores on u.IdEmpleado equals tr.IdEmpleado
                                    where n.IdEstatus == idestatus && n.Fecha ==fecha
                                    orderby n.Fecha descending
                                    select new
                                    {
                                        n.IdIncidencia,
                                        n.Fecha,
                                        Operador = t.NombreCompleto,
                                        Incidencia=c.Descripcion,
                                        n.Monto,
                                        n.Observaciones,
                                        Capturo = tr.NombreCompleto,
                                        FechaCaptura = n.FCreo,
                                        FechaNom = n.FNom
                                    };

                            dataGrid.DataSource = null;
                            dataGrid.DataSource = x.ToList();
                            dataGrid.Columns[0].Visible = false;
                            dataGrid.EnableHeadersVisualStyles = false;
                            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }
                        else
                        {
                            var x = from n in db.IncidenciasOperaciones
                                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                                    join c in db.CatIncidencias on n.IdCatIncidencia equals c.IdIncidencia
                                    where n.IdEstatus == idestatus && n.Fecha == fecha && n.IdUsCreo == this._uslog.IdUsuario
                        orderby n.Fecha descending
                                    select new
                                    {
                                        n.IdIncidencia,
                                        n.Fecha,
                                        t.NombreCompleto,
                                        Incidencia = c.Descripcion,
                                        n.Monto,
                                        n.Observaciones
                                    };
                            dataGrid.DataSource = null;
                            dataGrid.DataSource = x.ToList();
                            dataGrid.Columns[0].Visible = false;
                            dataGrid.EnableHeadersVisualStyles = false;
                            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }


                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Empleado")
                {
                    try
                    {

                        if (this._uslog.IdDepto == 7 || this._uslog.IdDepto == 3 || this._uslog.IdDepto == 4)
                        {
                            var x = from n in db.IncidenciasOperaciones
                                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                                    join u in db.Usuarios on n.IdUsCreo equals u.IdUsuario
                                    join c in db.CatIncidencias on n.IdCatIncidencia equals c.IdIncidencia
                                    join tr in db.Trabajadores on u.IdEmpleado equals tr.IdEmpleado
                                    where n.IdEstatus == idestatus && t.NombreCompleto.Contains(this.txt_filtro.Text)
                        orderby n.Fecha descending
                                    select new
                                    {
                                        n.IdIncidencia,
                                        n.Fecha,
                                        Operador = t.NombreCompleto,
                                        Incidencia=c.Descripcion,
                                        n.Monto,
                                        n.Observaciones,
                                        Capturo = tr.NombreCompleto,
                                        FechaCaptura = n.FCreo,
                                        FechaNom = n.FNom
                                    };

                            dataGrid.DataSource = null;
                            dataGrid.DataSource = x.ToList();
                            dataGrid.Columns[0].Visible = false;
                            dataGrid.EnableHeadersVisualStyles = false;
                            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }
                        else
                        {
                            var x = from n in db.IncidenciasOperaciones
                                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                                    join c in db.CatIncidencias on n.IdCatIncidencia equals c.IdIncidencia
                                    where n.IdEstatus == idestatus && t.NombreCompleto.Contains(this.txt_filtro.Text) && n.IdUsCreo == this._uslog.IdUsuario
                        orderby n.Fecha descending
                                    select new
                                    {
                                        n.IdIncidencia,
                                        n.Fecha,
                                        t.NombreCompleto,
                                        Incidencia = c.Descripcion,
                                        n.Monto,
                                        n.Observaciones
                                    };
                            dataGrid.DataSource = null;
                            dataGrid.DataSource = x.ToList();
                            dataGrid.Columns[0].Visible = false;
                            dataGrid.EnableHeadersVisualStyles = false;
                            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }


                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else if (filtro == "Incidencia")
                {
                    try
                    {

                        if (this._uslog.IdDepto == 7 || this._uslog.IdDepto == 3 || this._uslog.IdDepto == 4)
                        {
                            var x = from n in db.IncidenciasOperaciones
                                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                                    join u in db.Usuarios on n.IdUsCreo equals u.IdUsuario
                                    join c in db.CatIncidencias on n.IdCatIncidencia equals c.IdIncidencia
                                    join tr in db.Trabajadores on u.IdEmpleado equals tr.IdEmpleado
                                    where n.IdEstatus == idestatus && c.Descripcion.Contains(this.txt_filtro.Text)
                        orderby n.Fecha descending
                                    select new
                                    {
                                        n.IdIncidencia,
                                        n.Fecha,
                                        Operador = t.NombreCompleto,
                                        Incidencia = c.Descripcion,
                                        n.Monto,
                                        n.Observaciones,
                                        Capturo = tr.NombreCompleto,
                                        FechaCaptura = n.FCreo,
                                        FechaNom = n.FNom
                                    };

                            dataGrid.DataSource = null;
                            dataGrid.DataSource = x.ToList();
                            dataGrid.Columns[0].Visible = false;
                            dataGrid.EnableHeadersVisualStyles = false;
                            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }
                        else
                        {
                            var x = from n in db.IncidenciasOperaciones
                                    join t in db.Trabajadores on n.IdEmpleado equals t.IdEmpleado
                                    join c in db.CatIncidencias on n.IdCatIncidencia equals c.IdIncidencia
                                    where n.IdEstatus == idestatus && c.Descripcion.Contains(this.txt_filtro.Text) && n.IdUsCreo == this._uslog.IdUsuario
                        orderby n.Fecha descending
                                    select new
                                    {
                                        n.IdIncidencia,
                                        n.Fecha,
                                        t.NombreCompleto,
                                        Incidencia = c.Descripcion,
                                        n.Monto,
                                        n.Observaciones
                                    };
                            dataGrid.DataSource = null;
                            dataGrid.DataSource = x.ToList();
                            dataGrid.Columns[0].Visible = false;
                            dataGrid.EnableHeadersVisualStyles = false;
                            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        }


                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    CargarIncidencias();
                }
            }

        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea cancelar la incidencia seleccionada", "Cancelar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                CancelarIncidencia();

            }
            else
            {
                // Do something
            }
        }

        private void CancelarIncidencia()
        {
            if (idIncidencia > 0)
            {
                incidencias.IdEstatus = 2;
                incidencias.FCan = DateTime.Now;
                incidencias.IdUsCan = this._uslog.IdUsuario;
                db.Entry(incidencias).State = EntityState.Modified;
                MessageBox.Show("Incidencia cancelada exitosamente");
                db.SaveChanges();
                CargarIncidencias();
            }
            else
            {
                MessageBox.Show("Favor de seleccionar la incidencia a cancelar");
            }
        }

        private void tbcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarIncidencias();
        }

        private void btn_aplicar_Click(object sender, EventArgs e)
        {
            AEIncidencia frm = new AEIncidencia(this);
            frm._uslog = this._uslog;
            frm.idIncidencia = idIncidencia;
            frm.Show();
            this.Enabled = false;
        }

        private void txt_filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            CargarxFiltro();
        }
    }
}
