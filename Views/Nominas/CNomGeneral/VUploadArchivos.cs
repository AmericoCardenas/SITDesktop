using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SIT.Views.Nominas.CNomGeneral
{
    public partial class VUploadArchivos : Form
    {
        public VUploadArchivos()
        {
            InitializeComponent();
        }

        string fileContent = string.Empty;
        string filePath = string.Empty;
        SLDocument sl = new SLDocument();
        OpenFileDialog opfd = new OpenFileDialog();
        SITEntities db = new SITEntities();
        DateTime finicial, ffinal;

        private void VUploadArchivos_Load(object sender, EventArgs e)
        {
            this.dtm_inicial.Format = DateTimePickerFormat.Custom;
            this.dtm_inicial.CustomFormat = "dd-MM-yyyy";
            this.dtm_final.Format = DateTimePickerFormat.Custom;
            this.dtm_final.CustomFormat = "dd-MM-yyyy";
        }
        private void SubirArchivoNomGeneral()
        {
            int iRow = 2;
            List<NomGenCheckin> lst = new List<NomGenCheckin>();
            opfd.Filter = "txt files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            opfd.FilterIndex = 2;
            opfd.RestoreDirectory = true;

            if (opfd.ShowDialog() == DialogResult.OK)
            {
                filePath = opfd.FileName;
                sl = new SLDocument(filePath);

                finicial = sl.GetCellValueAsDateTime(iRow, 3);
                ffinal = sl.GetCellValueAsDateTime(iRow, 4);

                lst = db.NomGenCheckin.Where(j=>j.FInicial>=finicial && j.FFinal<=ffinal || j.IdNomCheckin.Contains("Count")).ToList();

                if(lst.Count > 0)
                {
                        db.NomGenCheckin.RemoveRange(lst);
                        db.SaveChanges();
                        lst.Clear();
                }

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow,1))) { 
                    NomGenCheckin nomGen = new NomGenCheckin();
                    nomGen.IdNomCheckin = sl.GetCellValueAsString(iRow, 1);
                    nomGen.Empleado = sl.GetCellValueAsString(iRow,2);
                    nomGen.FInicial = sl.GetCellValueAsDateTime(iRow, 3);
                    nomGen.FFinal = sl.GetCellValueAsDateTime(iRow,4);
                    nomGen.TotServ = sl.GetCellValueAsInt32(iRow, 5);
                    nomGen.TotSencillos  = sl.GetCellValueAsInt32(iRow,6);
                    nomGen.TotRedondos = sl.GetCellValueAsInt32(iRow,7);
                    nomGen.TotTaxis = sl.GetCellValueAsInt32(iRow,8);
                    nomGen.TotEsp = sl.GetCellValueAsInt32(iRow,9);
                    nomGen.Salario = sl.GetCellValueAsDouble(iRow,12);  
                    nomGen.Deducciones = sl.GetCellValueAsDouble(iRow,13);
                    nomGen.Bonos = sl.GetCellValueAsDouble(iRow,14);
                    nomGen.Total = sl.GetCellValueAsDouble(iRow,15);
                    lst.Add(nomGen);
                    iRow++;
                }

                db.NomGenCheckin.AddRange(lst);
                db.SaveChanges();

                MessageBox.Show("Se han cargado los registros con exito");

            }
        }
        private void SubirServicios()
        {
            int iRow = 2;
            List<ServiciosCheckin> lst = new List<ServiciosCheckin>();
            opfd.Filter = "txt files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            opfd.FilterIndex = 2;
            opfd.RestoreDirectory = true;

            if (opfd.ShowDialog() == DialogResult.OK)
            {
                filePath = opfd.FileName;
                sl = new SLDocument(filePath);

                finicial = this.dtm_inicial.Value;
                ffinal = this.dtm_final.Value;

                lst = db.ServiciosCheckin.Where(j => j.FServicio >= finicial && j.FServicio <= ffinal || j.IdServicioCheckin.Contains("Count")).ToList();

                if (lst.Count > 0)
                {
                    db.ServiciosCheckin.RemoveRange(lst);
                    db.SaveChanges();
                    lst.Clear();
                }

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    ServiciosCheckin z = new ServiciosCheckin();
                    z.IdServicioCheckin = sl.GetCellValueAsString(iRow, 1);
                    z.FServicio = sl.GetCellValueAsDateTime(iRow, 6);
                    z.HServicio = sl.GetCellValueAsString(iRow, 7).ToString();
                    z.Cliente = sl.GetCellValueAsString(iRow, 8);
                    z.Ruta = sl.GetCellValueAsString(iRow, 9);
                    z.Turno = sl.GetCellValueAsString(iRow, 10);
                    z.Tipo = sl.GetCellValueAsString(iRow, 11);
                    z.Unidad = sl.GetCellValueAsString(iRow, 12);
                    z.Empleado = sl.GetCellValueAsString(iRow, 13);
                    z.ATarde = sl.GetCellValueAsString(iRow, 20);
                    lst.Add(z);
                    iRow++;
                }

                db.ServiciosCheckin.AddRange(lst);
                db.SaveChanges();

                MessageBox.Show("Se han cargado los registros con exito");

            }
        }
        private void SubirBonos()
        {
            int iRow = 2;
            List<BonosCheckin> lst = new List<BonosCheckin>();
            opfd.Filter = "txt files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            opfd.FilterIndex = 2;
            opfd.RestoreDirectory = true;

            if (opfd.ShowDialog() == DialogResult.OK)
            {
                filePath = opfd.FileName;
                sl = new SLDocument(filePath);

                finicial = this.dtm_inicial.Value;
                ffinal = this.dtm_final.Value;

                lst = db.BonosCheckin.Where(j => j.Fecha >= finicial && j.Fecha <= ffinal || j.IdBonoCheckin.Contains("Count")).ToList();

                if (lst.Count > 0)
                {
                    db.BonosCheckin.RemoveRange(lst);
                    db.SaveChanges();
                    lst.Clear();
                }

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    BonosCheckin z = new BonosCheckin();
                    z.IdBonoCheckin = sl.GetCellValueAsString(iRow, 1);
                    z.Empleado = sl.GetCellValueAsString(iRow, 2);
                    z.Bono = sl.GetCellValueAsString(iRow, 4);
                    z.Total = sl.GetCellValueAsDouble(iRow, 5);
                    z.Observaciones = sl.GetCellValueAsString(iRow, 6);
                    z.Fecha = sl.GetCellValueAsDateTime(iRow, 7);
                    lst.Add(z);
                    iRow++;
                }

                db.BonosCheckin.AddRange(lst);
                db.SaveChanges();

                MessageBox.Show("Se han cargado los registros con exito");

            }
        }
        private void SubirDeducciones()
        {
            int iRow = 2;
            List<DeduccionesCheckin> lst = new List<DeduccionesCheckin>();
            opfd.Filter = "txt files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            opfd.FilterIndex = 2;
            opfd.RestoreDirectory = true;

            if (opfd.ShowDialog() == DialogResult.OK)
            {
                filePath = opfd.FileName;
                sl = new SLDocument(filePath);

                finicial = this.dtm_inicial.Value;
                ffinal = this.dtm_final.Value;

                lst = db.DeduccionesCheckin.Where(j => j.Fecha >= finicial && j.Fecha <= ffinal || j.IdDeduccionCheckin.Contains("Count")).ToList();

                if (lst.Count > 0)
                {
                    db.DeduccionesCheckin.RemoveRange(lst);
                    db.SaveChanges();
                    lst.Clear();
                }

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    DeduccionesCheckin z = new DeduccionesCheckin();
                    z.IdDeduccionCheckin = sl.GetCellValueAsString(iRow, 1);
                    z.Empleado = sl.GetCellValueAsString(iRow, 2);
                    z.Deduccion = sl.GetCellValueAsString(iRow, 4);
                    z.Total = sl.GetCellValueAsDouble(iRow, 5);
                    z.Observaciones = sl.GetCellValueAsString(iRow, 6);
                    z.Fecha = sl.GetCellValueAsDateTime(iRow, 7);
                    lst.Add(z);
                    iRow++;
                }

                db.DeduccionesCheckin.AddRange(lst);
                db.SaveChanges();

                MessageBox.Show("Se han cargado los registros con exito");

            }
        }
        private void SubirTickets()
        {
            int iRow = 2;
            List<TicketsCheckin> lst = new List<TicketsCheckin>();
            opfd.Filter = "txt files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            opfd.FilterIndex = 2;
            opfd.RestoreDirectory = true;

            if (opfd.ShowDialog() == DialogResult.OK)
            {
                filePath = opfd.FileName;
                sl = new SLDocument(filePath);

                finicial = this.dtm_inicial.Value;
                ffinal = this.dtm_final.Value;

                lst = db.TicketsCheckin.Where(j => j.FInicial >= finicial && j.FFinal <= ffinal).ToList();

                if (lst.Count > 0)
                {
                    db.TicketsCheckin.RemoveRange(lst);
                    db.SaveChanges();
                    lst.Clear();
                }

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    TicketsCheckin z = new TicketsCheckin();
                    z.IdTicketCheckin = sl.GetCellValueAsString(iRow, 1);
                    z.Unidad = sl.GetCellValueAsString(iRow, 2);
                    z.Empleado = sl.GetCellValueAsString(iRow, 3);
                    z.FInicial = sl.GetCellValueAsDateTime(iRow, 4);
                    z.FFinal = sl.GetCellValueAsDateTime(iRow, 5);
                    z.Litros = sl.GetCellValueAsDouble(iRow, 6);
                    z.RendReq = sl.GetCellValueAsDouble(iRow, 7);
                    z.KmGpsAnt = sl.GetCellValueAsDouble(iRow, 16);
                    z.KmGps = sl.GetCellValueAsDouble(iRow, 17);
                    z.KmGpsRec = sl.GetCellValueAsDouble(iRow, 18);
                    z.RendGps = sl.GetCellValueAsDouble(iRow, 19);
                    lst.Add(z);
                    iRow++;
                }

                db.TicketsCheckin.AddRange(lst);
                db.SaveChanges();

                MessageBox.Show("Se han cargado los registros con exito");

            }
        }
        private void btn_imp_servicios_Click(object sender, EventArgs e)
        {
            SubirServicios();
        }
        private void btn_imp_bonos_Click(object sender, EventArgs e)
        {
            SubirBonos();
        }
        private void btn_imp_deducciones_Click(object sender, EventArgs e)
        {
            SubirDeducciones();
        }
        private void btn_imp_tickets_Click(object sender, EventArgs e)
        {
            SubirTickets();
        }
        private void btn_import_nomgeneral_Click(object sender, EventArgs e)
        {
            SubirArchivoNomGeneral();
        }
    }
}
