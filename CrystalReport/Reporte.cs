using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIT.CrystalReport
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        public Form frm;
        public int idviaje,ideqmovil,idlinea,ideqcomp,idocompra;
        ReportDocument report = new ReportDocument();


        private void CargarReporte()
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = "SIT";
            connectionInfo.UserID = "sa";
            connectionInfo.Password = "compac";

            if (this.frm.Name == "VViajesEspeciales")
            {
                report.Load("\\\\192.168.1.213\\Reportes\\RptVjEsp.rpt");
                SqlConnection con = new SqlConnection();
                con.ConnectionString= "Server=SERVIDOR\\COMPAC;Database=SIT;User Id=sa;Password=compac;";

                ParameterFields parameterFields = new ParameterFields();
                ParameterField parameterField = new ParameterField();
                ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();

                parameterField.ParameterFieldName = "@IDVIAJE"; // Replace with your parameter name
                parameterValue.Value = idviaje; // Replace with the actual parameter value
                parameterField.CurrentValues.Add(parameterValue);
                parameterFields.Add(parameterField);

                crystalReportViewer1.ParameterFieldInfo = parameterFields;

            }
            else if (this.frm.Name == "VEquiposMovil")
            {
                report.Load("\\\\192.168.1.213\\Reportes\\RptResponsivaEqMovil.rpt");
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=SERVIDOR\\COMPAC;Database=SIT;User Id=sa;Password=compac;";

                ParameterFields parameterFields = new ParameterFields();
                ParameterField parameterField = new ParameterField();
                ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();

                parameterField.ParameterFieldName = "@IDEQMOVIL"; // Replace with your parameter name
                parameterValue.Value = ideqmovil; // Replace with the actual parameter value
                parameterField.CurrentValues.Add(parameterValue);
                parameterFields.Add(parameterField);

                crystalReportViewer1.ParameterFieldInfo = parameterFields;

            }
            else if (this.frm.Name == "VLineas")
            {
                report.Load("\\\\192.168.1.213\\Reportes\\RptResponsivaLinea.rpt");
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=SERVIDOR\\COMPAC;Database=SIT;User Id=sa;Password=compac;";

                ParameterFields parameterFields = new ParameterFields();
                ParameterField parameterField = new ParameterField();
                ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();

                parameterField.ParameterFieldName = "@IDLINEA"; // Replace with your parameter name
                parameterValue.Value = idlinea; // Replace with the actual parameter value
                parameterField.CurrentValues.Add(parameterValue);
                parameterFields.Add(parameterField);

                crystalReportViewer1.ParameterFieldInfo = parameterFields;

            }
            else if (this.frm.Name == "VEquiposComputo")
            {
                report.Load("\\\\192.168.1.213\\Reportes\\RptResponsivaEqComputo.rpt");
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=SERVIDOR\\COMPAC;Database=SIT;User Id=sa;Password=compac;";

                ParameterFields parameterFields = new ParameterFields();
                ParameterField parameterField = new ParameterField();
                ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();

                parameterField.ParameterFieldName = "@IDEQCOMP"; // Replace with your parameter name
                parameterValue.Value = ideqcomp; // Replace with the actual parameter value
                parameterField.CurrentValues.Add(parameterValue);
                parameterFields.Add(parameterField);

                crystalReportViewer1.ParameterFieldInfo = parameterFields;

            }
            else if (this.frm.Name == "VNotas")
            {
                report.Load("\\\\192.168.1.213\\Reportes\\RptNotaCreditos.rpt");
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=SERVIDOR\\COMPAC;Database=SIT;User Id=sa;Password=compac;";

            }
            else if (this.frm.Name == "VOrdenesCompra")
            {
                report.Load("\\\\192.168.1.213\\Reportes\\RptOrdenCompra.rpt");
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=SERVIDOR\\COMPAC;Database=SIT;User Id=sa;Password=compac;";
                ParameterFields parameterFields = new ParameterFields();
                ParameterField parameterField = new ParameterField();
                ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();

                parameterField.ParameterFieldName = "@IDOCOMPRA"; // Replace with your parameter name
                parameterValue.Value = idocompra; // Replace with the actual parameter value
                parameterField.CurrentValues.Add(parameterValue);
                parameterFields.Add(parameterField);
                crystalReportViewer1.ParameterFieldInfo = parameterFields;
                
            }

            report.SetDatabaseLogon("sa", "compac", "SERVIDOR\\COMPAC", "SIT");

            foreach (Table var in report.Database.Tables)
            {
                TableLogOnInfo tablainformacion = var.LogOnInfo;
                tablainformacion.ConnectionInfo = connectionInfo;
                var.ApplyLogOnInfo(tablainformacion);
            }
            crystalReportViewer1.ReportSource = report;

        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void Reporte_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        
        }
    }
}
