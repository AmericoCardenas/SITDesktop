namespace SIT.Views.Nominas.CNomGeneral
{
    partial class VNomGeneral
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_upload = new System.Windows.Forms.Button();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_nomgen = new System.Windows.Forms.TabPage();
            this.tb_bonos = new System.Windows.Forms.TabPage();
            this.tb_deducciones = new System.Windows.Forms.TabPage();
            this.tb_servicios = new System.Windows.Forms.TabPage();
            this.tb_tickets = new System.Windows.Forms.TabPage();
            this.dgrid_nomgeneral = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_nomgen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_nomgeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_upload);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 54);
            this.panel1.TabIndex = 0;
            // 
            // btn_upload
            // 
            this.btn_upload.BackColor = System.Drawing.Color.Transparent;
            this.btn_upload.BackgroundImage = global::SIT.Properties.Resources.carga_en_la_nube;
            this.btn_upload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_upload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_upload.Location = new System.Drawing.Point(875, 3);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(63, 45);
            this.btn_upload.TabIndex = 0;
            this.btn_upload.UseVisualStyleBackColor = false;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_nomgen);
            this.tbcontrol.Controls.Add(this.tb_bonos);
            this.tbcontrol.Controls.Add(this.tb_deducciones);
            this.tbcontrol.Controls.Add(this.tb_servicios);
            this.tbcontrol.Controls.Add(this.tb_tickets);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 54);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(950, 396);
            this.tbcontrol.TabIndex = 1;
            // 
            // tb_nomgen
            // 
            this.tb_nomgen.Controls.Add(this.dgrid_nomgeneral);
            this.tb_nomgen.Location = new System.Drawing.Point(4, 22);
            this.tb_nomgen.Name = "tb_nomgen";
            this.tb_nomgen.Padding = new System.Windows.Forms.Padding(3);
            this.tb_nomgen.Size = new System.Drawing.Size(942, 370);
            this.tb_nomgen.TabIndex = 0;
            this.tb_nomgen.Text = "NomGeneral";
            this.tb_nomgen.UseVisualStyleBackColor = true;
            // 
            // tb_bonos
            // 
            this.tb_bonos.Location = new System.Drawing.Point(4, 22);
            this.tb_bonos.Name = "tb_bonos";
            this.tb_bonos.Padding = new System.Windows.Forms.Padding(3);
            this.tb_bonos.Size = new System.Drawing.Size(942, 370);
            this.tb_bonos.TabIndex = 1;
            this.tb_bonos.Text = "Bonos";
            this.tb_bonos.UseVisualStyleBackColor = true;
            // 
            // tb_deducciones
            // 
            this.tb_deducciones.Location = new System.Drawing.Point(4, 22);
            this.tb_deducciones.Name = "tb_deducciones";
            this.tb_deducciones.Padding = new System.Windows.Forms.Padding(3);
            this.tb_deducciones.Size = new System.Drawing.Size(942, 370);
            this.tb_deducciones.TabIndex = 2;
            this.tb_deducciones.Text = "Deducciones";
            this.tb_deducciones.UseVisualStyleBackColor = true;
            // 
            // tb_servicios
            // 
            this.tb_servicios.Location = new System.Drawing.Point(4, 22);
            this.tb_servicios.Name = "tb_servicios";
            this.tb_servicios.Padding = new System.Windows.Forms.Padding(3);
            this.tb_servicios.Size = new System.Drawing.Size(942, 370);
            this.tb_servicios.TabIndex = 3;
            this.tb_servicios.Text = "Servicios";
            this.tb_servicios.UseVisualStyleBackColor = true;
            // 
            // tb_tickets
            // 
            this.tb_tickets.Location = new System.Drawing.Point(4, 22);
            this.tb_tickets.Name = "tb_tickets";
            this.tb_tickets.Padding = new System.Windows.Forms.Padding(3);
            this.tb_tickets.Size = new System.Drawing.Size(942, 370);
            this.tb_tickets.TabIndex = 4;
            this.tb_tickets.Text = "Tickets";
            this.tb_tickets.UseVisualStyleBackColor = true;
            // 
            // dgrid_nomgeneral
            // 
            this.dgrid_nomgeneral.AllowUserToAddRows = false;
            this.dgrid_nomgeneral.AllowUserToDeleteRows = false;
            this.dgrid_nomgeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_nomgeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_nomgeneral.Location = new System.Drawing.Point(3, 3);
            this.dgrid_nomgeneral.Name = "dgrid_nomgeneral";
            this.dgrid_nomgeneral.ReadOnly = true;
            this.dgrid_nomgeneral.Size = new System.Drawing.Size(936, 364);
            this.dgrid_nomgeneral.TabIndex = 0;
            // 
            // VNomGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 450);
            this.Controls.Add(this.tbcontrol);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VNomGeneral";
            this.Text = "VNomGeneral";
            this.panel1.ResumeLayout(false);
            this.tbcontrol.ResumeLayout(false);
            this.tb_nomgen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_nomgeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_nomgen;
        private System.Windows.Forms.TabPage tb_bonos;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.TabPage tb_deducciones;
        private System.Windows.Forms.TabPage tb_servicios;
        private System.Windows.Forms.TabPage tb_tickets;
        private System.Windows.Forms.DataGridView dgrid_nomgeneral;
    }
}