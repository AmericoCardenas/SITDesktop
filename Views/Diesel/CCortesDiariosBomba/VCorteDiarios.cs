using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.Views.Diesel.CCortesDiariosBomba
{
    public partial class VCorteDiarios : Form
    {
        public VCorteDiarios(Usuarios uslog)
        {
            InitializeComponent();
        }

        SITEntities db = new SITEntities();
 

        private void VCorteDiarios_Load(object sender, EventArgs e)
        {
            CargarCortes();
            CargarFiltros();
        }

        public void CargarCortes()
        {
            var x = from c in db.CorteDiarioBomba
                    select new
                    {
                        c.IdCorte,
                        c.FechaInicio,
                        c.HoraInicio,
                        c.LitrosInicio,
                        c.FechaFinal,
                        c.HoraFinal,
                        c.LitrosFinal,
                        c.FotoInicio,
                        c.FotoFinal
                    };
            this.dgrid_corte.DataSource = x.ToList();
            this.dgrid_corte.Columns[0].Visible = false;
            this.dgrid_corte.Columns[7].Visible = false;
            this.dgrid_corte.Columns[8].Visible = false;
            this.dgrid_corte.EnableHeadersVisualStyles = false;
            this.dgrid_corte.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            this.dgrid_corte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgrid_corte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void CargarFiltros()
        {
            foreach (DataGridViewColumn col in this.dgrid_corte.Columns)
            {
                if (col.Index > 0 && col.Index!=7 && col.Index!=8)
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
                if (filtro == "FechaInicio")
                {
                    DateTime date = Convert.ToDateTime(txt_filtro.Text);

                    var x = from c in db.CorteDiarioBomba
                            where c.FechaInicio==date
                            select new
                            {
                                c.IdCorte,
                                c.FechaInicio,
                                c.HoraInicio,
                                c.LitrosInicio,
                                c.FechaFinal,
                                c.HoraFinal,
                                c.LitrosFinal,
                                c.FotoInicio,
                                c.FotoFinal
                            };
                    this.dgrid_corte.DataSource = x.ToList();
                }
                else if(filtro == "FechaFinal")
                {
                    DateTime date = Convert.ToDateTime(txt_filtro.Text);

                    var x = from c in db.CorteDiarioBomba
                            where c.FechaFinal == date
                            select new
                            {
                                c.IdCorte,
                                c.FechaInicio,
                                c.HoraInicio,
                                c.LitrosInicio,
                                c.FechaFinal,
                                c.HoraFinal,
                                c.LitrosFinal,
                                c.FotoInicio,
                                c.FotoFinal
                            };
                    this.dgrid_corte.DataSource = x.ToList();
                }

                this.dgrid_corte.Columns[0].Visible = false;
                this.dgrid_corte.Columns[7].Visible = false;
                this.dgrid_corte.Columns[8].Visible = false;

                this.dgrid_corte.EnableHeadersVisualStyles = false;
                this.dgrid_corte.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
                this.dgrid_corte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dgrid_corte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
            else
            {
                CargarFiltros();
            }
        }

        private void txt_filtro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarxFiltro();
            }
            catch(Exception ex) { }
        }
    }
}
