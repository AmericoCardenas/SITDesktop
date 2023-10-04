namespace SIT.Views.Catalogos.CEmpleados
{
    partial class ResumenEmpleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_datos = new System.Windows.Forms.Panel();
            this.lbl_puesto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_nomemp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_domicilio = new System.Windows.Forms.TabPage();
            this.dgrid_domemp = new System.Windows.Forms.DataGridView();
            this.tb_dbancarios = new System.Windows.Forms.TabPage();
            this.dgrid_bancemp = new System.Windows.Forms.DataGridView();
            this.tb_eqcomputo = new System.Windows.Forms.TabPage();
            this.dgrid_eqcom = new System.Windows.Forms.DataGridView();
            this.tb_eqmovil = new System.Windows.Forms.TabPage();
            this.dgrid_eqmov = new System.Windows.Forms.DataGridView();
            this.tb_lineas = new System.Windows.Forms.TabPage();
            this.dgrid_lineaemp = new System.Windows.Forms.DataGridView();
            this.tb_incidencia = new System.Windows.Forms.TabPage();
            this.pnl_datos.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_domicilio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_domemp)).BeginInit();
            this.tb_dbancarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_bancemp)).BeginInit();
            this.tb_eqcomputo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_eqcom)).BeginInit();
            this.tb_eqmovil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_eqmov)).BeginInit();
            this.tb_lineas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_lineaemp)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_datos
            // 
            this.pnl_datos.BackColor = System.Drawing.Color.White;
            this.pnl_datos.Controls.Add(this.lbl_puesto);
            this.pnl_datos.Controls.Add(this.label3);
            this.pnl_datos.Controls.Add(this.lbl_nomemp);
            this.pnl_datos.Controls.Add(this.label1);
            this.pnl_datos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_datos.Location = new System.Drawing.Point(0, 0);
            this.pnl_datos.Name = "pnl_datos";
            this.pnl_datos.Size = new System.Drawing.Size(800, 38);
            this.pnl_datos.TabIndex = 0;
            // 
            // lbl_puesto
            // 
            this.lbl_puesto.AutoSize = true;
            this.lbl_puesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_puesto.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_puesto.Location = new System.Drawing.Point(560, 7);
            this.lbl_puesto.Name = "lbl_puesto";
            this.lbl_puesto.Size = new System.Drawing.Size(66, 24);
            this.lbl_puesto.TabIndex = 3;
            this.lbl_puesto.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(476, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Puesto:";
            // 
            // lbl_nomemp
            // 
            this.lbl_nomemp.AutoSize = true;
            this.lbl_nomemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomemp.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_nomemp.Location = new System.Drawing.Point(105, 7);
            this.lbl_nomemp.Name = "lbl_nomemp";
            this.lbl_nomemp.Size = new System.Drawing.Size(66, 24);
            this.lbl_nomemp.TabIndex = 1;
            this.lbl_nomemp.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbcontrol);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 412);
            this.panel1.TabIndex = 1;
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_domicilio);
            this.tbcontrol.Controls.Add(this.tb_dbancarios);
            this.tbcontrol.Controls.Add(this.tb_eqcomputo);
            this.tbcontrol.Controls.Add(this.tb_eqmovil);
            this.tbcontrol.Controls.Add(this.tb_lineas);
            this.tbcontrol.Controls.Add(this.tb_incidencia);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(800, 412);
            this.tbcontrol.TabIndex = 0;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_domicilio
            // 
            this.tb_domicilio.Controls.Add(this.dgrid_domemp);
            this.tb_domicilio.Location = new System.Drawing.Point(4, 22);
            this.tb_domicilio.Name = "tb_domicilio";
            this.tb_domicilio.Padding = new System.Windows.Forms.Padding(3);
            this.tb_domicilio.Size = new System.Drawing.Size(792, 386);
            this.tb_domicilio.TabIndex = 0;
            this.tb_domicilio.Text = "Domicilio";
            this.tb_domicilio.UseVisualStyleBackColor = true;
            // 
            // dgrid_domemp
            // 
            this.dgrid_domemp.AllowUserToAddRows = false;
            this.dgrid_domemp.AllowUserToDeleteRows = false;
            this.dgrid_domemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_domemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_domemp.Location = new System.Drawing.Point(3, 3);
            this.dgrid_domemp.Name = "dgrid_domemp";
            this.dgrid_domemp.ReadOnly = true;
            this.dgrid_domemp.Size = new System.Drawing.Size(786, 380);
            this.dgrid_domemp.TabIndex = 0;
            // 
            // tb_dbancarios
            // 
            this.tb_dbancarios.Controls.Add(this.dgrid_bancemp);
            this.tb_dbancarios.Location = new System.Drawing.Point(4, 22);
            this.tb_dbancarios.Name = "tb_dbancarios";
            this.tb_dbancarios.Padding = new System.Windows.Forms.Padding(3);
            this.tb_dbancarios.Size = new System.Drawing.Size(792, 386);
            this.tb_dbancarios.TabIndex = 1;
            this.tb_dbancarios.Text = "Datos Bancarios";
            this.tb_dbancarios.UseVisualStyleBackColor = true;
            // 
            // dgrid_bancemp
            // 
            this.dgrid_bancemp.AllowUserToAddRows = false;
            this.dgrid_bancemp.AllowUserToDeleteRows = false;
            this.dgrid_bancemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_bancemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_bancemp.Location = new System.Drawing.Point(3, 3);
            this.dgrid_bancemp.Name = "dgrid_bancemp";
            this.dgrid_bancemp.ReadOnly = true;
            this.dgrid_bancemp.Size = new System.Drawing.Size(786, 380);
            this.dgrid_bancemp.TabIndex = 0;
            // 
            // tb_eqcomputo
            // 
            this.tb_eqcomputo.Controls.Add(this.dgrid_eqcom);
            this.tb_eqcomputo.Location = new System.Drawing.Point(4, 22);
            this.tb_eqcomputo.Name = "tb_eqcomputo";
            this.tb_eqcomputo.Padding = new System.Windows.Forms.Padding(3);
            this.tb_eqcomputo.Size = new System.Drawing.Size(792, 386);
            this.tb_eqcomputo.TabIndex = 2;
            this.tb_eqcomputo.Text = "Equipos de Computo";
            this.tb_eqcomputo.UseVisualStyleBackColor = true;
            // 
            // dgrid_eqcom
            // 
            this.dgrid_eqcom.AllowUserToAddRows = false;
            this.dgrid_eqcom.AllowUserToDeleteRows = false;
            this.dgrid_eqcom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_eqcom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_eqcom.Location = new System.Drawing.Point(3, 3);
            this.dgrid_eqcom.Name = "dgrid_eqcom";
            this.dgrid_eqcom.ReadOnly = true;
            this.dgrid_eqcom.Size = new System.Drawing.Size(786, 380);
            this.dgrid_eqcom.TabIndex = 0;
            // 
            // tb_eqmovil
            // 
            this.tb_eqmovil.Controls.Add(this.dgrid_eqmov);
            this.tb_eqmovil.Location = new System.Drawing.Point(4, 22);
            this.tb_eqmovil.Name = "tb_eqmovil";
            this.tb_eqmovil.Padding = new System.Windows.Forms.Padding(3);
            this.tb_eqmovil.Size = new System.Drawing.Size(792, 386);
            this.tb_eqmovil.TabIndex = 3;
            this.tb_eqmovil.Text = "Equipos Movil";
            this.tb_eqmovil.UseVisualStyleBackColor = true;
            // 
            // dgrid_eqmov
            // 
            this.dgrid_eqmov.AllowUserToAddRows = false;
            this.dgrid_eqmov.AllowUserToDeleteRows = false;
            this.dgrid_eqmov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_eqmov.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_eqmov.Location = new System.Drawing.Point(3, 3);
            this.dgrid_eqmov.Name = "dgrid_eqmov";
            this.dgrid_eqmov.ReadOnly = true;
            this.dgrid_eqmov.Size = new System.Drawing.Size(786, 380);
            this.dgrid_eqmov.TabIndex = 0;
            // 
            // tb_lineas
            // 
            this.tb_lineas.Controls.Add(this.dgrid_lineaemp);
            this.tb_lineas.Location = new System.Drawing.Point(4, 22);
            this.tb_lineas.Name = "tb_lineas";
            this.tb_lineas.Padding = new System.Windows.Forms.Padding(3);
            this.tb_lineas.Size = new System.Drawing.Size(792, 386);
            this.tb_lineas.TabIndex = 4;
            this.tb_lineas.Text = "Linea Empresarial";
            this.tb_lineas.UseVisualStyleBackColor = true;
            // 
            // dgrid_lineaemp
            // 
            this.dgrid_lineaemp.AllowUserToAddRows = false;
            this.dgrid_lineaemp.AllowUserToDeleteRows = false;
            this.dgrid_lineaemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_lineaemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_lineaemp.Location = new System.Drawing.Point(3, 3);
            this.dgrid_lineaemp.Name = "dgrid_lineaemp";
            this.dgrid_lineaemp.ReadOnly = true;
            this.dgrid_lineaemp.Size = new System.Drawing.Size(786, 380);
            this.dgrid_lineaemp.TabIndex = 0;
            // 
            // tb_incidencia
            // 
            this.tb_incidencia.Location = new System.Drawing.Point(4, 22);
            this.tb_incidencia.Name = "tb_incidencia";
            this.tb_incidencia.Padding = new System.Windows.Forms.Padding(3);
            this.tb_incidencia.Size = new System.Drawing.Size(792, 386);
            this.tb_incidencia.TabIndex = 5;
            this.tb_incidencia.Text = "Incidencias";
            this.tb_incidencia.UseVisualStyleBackColor = true;
            // 
            // ResumenEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_datos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ResumenEmpleado";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResumenEmpleado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResumenEmpleado_FormClosed);
            this.Load += new System.EventHandler(this.ResumenEmpleado_Load);
            this.pnl_datos.ResumeLayout(false);
            this.pnl_datos.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tbcontrol.ResumeLayout(false);
            this.tb_domicilio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_domemp)).EndInit();
            this.tb_dbancarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_bancemp)).EndInit();
            this.tb_eqcomputo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_eqcom)).EndInit();
            this.tb_eqmovil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_eqmov)).EndInit();
            this.tb_lineas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_lineaemp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_datos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_domicilio;
        private System.Windows.Forms.TabPage tb_dbancarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_nomemp;
        private System.Windows.Forms.TabPage tb_eqcomputo;
        private System.Windows.Forms.TabPage tb_eqmovil;
        private System.Windows.Forms.TabPage tb_lineas;
        private System.Windows.Forms.DataGridView dgrid_domemp;
        private System.Windows.Forms.DataGridView dgrid_bancemp;
        private System.Windows.Forms.DataGridView dgrid_eqcom;
        private System.Windows.Forms.DataGridView dgrid_eqmov;
        private System.Windows.Forms.DataGridView dgrid_lineaemp;
        private System.Windows.Forms.Label lbl_puesto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tb_incidencia;
    }
}