using DocumentFormat.OpenXml.Vml.Office;
using SIT.CrystalReport;
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

namespace SIT.Views.Catalogos
{
    public partial class VEquiposComputo : Form
    {
        public VEquiposComputo(Usuarios usuariolog)
        {
            InitializeComponent();
            this._uslog = usuariolog;

        }

        Usuarios _uslog;
        SITEntities db = new SITEntities();
        EquiposComputo equiposComputo = new EquiposComputo();
        int IdEquipo = 0;

        private void CargarTipo()
        {
            this.cmb_tipo.Items.Add("ESCRITORIO");
            this.cmb_tipo.Items.Add("LAPTOP");
            this.cmb_tipo.Items.Add("TABLET");
        }

        private void CargarEmpleados()
        {
            var empleados = db.Trabajadores.ToList();
            this.cmb_emp.DataSource = empleados;
            this.cmb_emp.DisplayMember = "NombreCompleto";
            this.cmb_emp.ValueMember = "IdEmpleado";
        }

        private void CargarEquipos()
        {
            var equipos = from x in db.EquiposComputo
                          join t in db.Trabajadores on x.IdEmpleado equals t.IdEmpleado
                          select new {
                           x.IdEquipoComputo,
                           x.Tipo,
                           x.Marca,
                           x.Modelo,
                           x.Ram,
                           x.Procesador,
                           x.Almacenamiento,
                           x.SN,
                           x.Color,
                           x.Caracteristicas,
                           x.Detalles,
                           x.Accesorios,
                           x.ValorComercial,
                           t.NombreCompleto };
            this.dgrid_equipos.DataSource = equipos.ToList();

            this.dgrid_equipos.Columns["IdEquipoComputo"].Visible = false;
            this.dgrid_equipos.Columns["Almacenamiento"].Visible = false;
            this.dgrid_equipos.Columns["Caracteristicas"].Visible = false;
            this.dgrid_equipos.Columns["Detalles"].Visible = false;

            foreach(DataGridViewColumn col in this.dgrid_equipos.Columns)
            {
                col.AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;  
            }

            this.dgrid_equipos.Columns["NombreCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;





        }

        private void AgregarEquipo()
        {
            if (this.cmb_tipo.Text == "")
            {
                MessageBox.Show("Favor de seleccionar el tipo del equipo");
            }
            else if(this.txt_marca.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar la marca del equipo");
            }
            else if (this.txt_modelo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el modelo del equipo");
            }
            else if (this.txt_ram.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar la RAM del equipo");
            }
            else if (this.txt_proc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el procesador del equipo");
            }
            else if (this.txt_alm.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el almacenamiento del equipo");
            }
            else if (this.txt_sn.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el numero de serie del equipo");
            }
            else if (this.txt_color.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el color del equipo");
            }
            else if (this.txt_carac.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar las caracteristicas del equipo");
            }
            else if (this.txt_deta.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar los detalles del equipo");
            }
            else if (this.txt_acces.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar los Accesorios del equipo");
            }
            else if (this.txt_valor.Text.Trim().Length == 0)
            {
                MessageBox.Show("Favor de capturar el valor comercial del equipo");
            }
            else if (this.cmb_emp.SelectedValue == null)
            {
                MessageBox.Show("Favor de seleccionar el empleado a asignar del equipo");
            }
            else
            {
                equiposComputo.Tipo = this.cmb_tipo.Text;
                equiposComputo.Marca = this.txt_marca.Text;
                equiposComputo.Modelo = this.txt_modelo.Text;
                equiposComputo.Ram = this.txt_ram.Text;
                equiposComputo.Procesador = this.txt_proc.Text;
                equiposComputo.Almacenamiento = this.txt_alm.Text;
                equiposComputo.SN = this.txt_sn.Text;
                equiposComputo.Color = this.txt_color.Text;
                equiposComputo.Caracteristicas = this.txt_carac.Text;
                equiposComputo.Detalles = this.txt_deta.Text;
                equiposComputo.Accesorios = this.txt_acces.Text;
                equiposComputo.ValorComercial = this.txt_valor.Text;
                equiposComputo.IdEmpleado = Convert.ToInt32(this.cmb_emp.SelectedValue);

                if (IdEquipo > 0)
                {
                    db.Entry(equiposComputo).State = EntityState.Modified;
                    MessageBox.Show("Ruta actualizado exitosamente");
                    this.btn_add.BackgroundImage = Properties.Resources.mas;
                    this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    db.EquiposComputo.Add(equiposComputo);
                    MessageBox.Show("Ruta agregada exitosamente");
                }

                db.SaveChanges();
                CargarEquipos();
            }

        }

        private void dgrid_equipos_Click(object sender, EventArgs e)
        {
            if (this.dgrid_equipos.CurrentCell.RowIndex != -1)
            {
                IdEquipo = Convert.ToInt32(this.dgrid_equipos.CurrentRow.Cells["IdEquipoComputo"].Value);
                equiposComputo = db.EquiposComputo.Where(x => x.IdEquipoComputo == IdEquipo).FirstOrDefault();
                this.cmb_tipo.Text = equiposComputo.Tipo;
                this.txt_marca.Text = equiposComputo.Marca;
                this.txt_modelo.Text = equiposComputo.Modelo;
                this.txt_ram.Text = equiposComputo.Ram;
                this.txt_proc.Text = equiposComputo.Procesador;
                this.txt_alm.Text = equiposComputo.Almacenamiento;
                this.txt_sn.Text = equiposComputo.SN;
                this.txt_color.Text = equiposComputo.Color;
                this.txt_carac.Text = equiposComputo.Caracteristicas;
                this.txt_deta.Text = equiposComputo.Detalles;
                this.txt_acces.Text = equiposComputo.Accesorios;
                this.txt_valor.Text = equiposComputo.ValorComercial;
                this.cmb_emp.SelectedValue = Convert.ToInt32(equiposComputo.IdEmpleado);

            }

            this.btn_add.BackgroundImage = new Bitmap(Properties.Resources.lapiz, new Size(32, 32));
            this.btn_add.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AgregarEquipo();
        }

        private void VEquiposComputo_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarTipo();
            CargarEquipos();
            this.dgrid_equipos.EnableHeadersVisualStyles = false;
            this.dgrid_equipos.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_equipos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

        }

        private void btn_doc_Click(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.frm = this;
            frm.ideqcomp = Convert.ToInt32(this.dgrid_equipos.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
