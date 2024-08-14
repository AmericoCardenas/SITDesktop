namespace SIT.Views.Contabilidad
{
    partial class VFlujos
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_saldoxfecha = new System.Windows.Forms.Button();
            this.btn_saldoactual = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_canc = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_egreso = new System.Windows.Forms.TabPage();
            this.dgrid_egreso = new System.Windows.Forms.DataGridView();
            this.tb_ingreso = new System.Windows.Forms.TabPage();
            this.dgrid_ingreso = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_egreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_egreso)).BeginInit();
            this.tb_ingreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ingreso)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btn_saldoxfecha);
            this.panel2.Controls.Add(this.btn_saldoactual);
            this.panel2.Controls.Add(this.btn_excel);
            this.panel2.Controls.Add(this.btn_canc);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Controls.Add(this.txt_filtro);
            this.panel2.Controls.Add(this.cmb_filtro);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 52);
            this.panel2.TabIndex = 1;
            // 
            // btn_saldoxfecha
            // 
            this.btn_saldoxfecha.BackgroundImage = global::SIT.Properties.Resources.schedule;
            this.btn_saldoxfecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_saldoxfecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saldoxfecha.Location = new System.Drawing.Point(228, 3);
            this.btn_saldoxfecha.Name = "btn_saldoxfecha";
            this.btn_saldoxfecha.Size = new System.Drawing.Size(48, 39);
            this.btn_saldoxfecha.TabIndex = 25;
            this.btn_saldoxfecha.UseVisualStyleBackColor = true;
            this.btn_saldoxfecha.Click += new System.EventHandler(this.btn_saldoxfecha_Click);
            // 
            // btn_saldoactual
            // 
            this.btn_saldoactual.BackgroundImage = global::SIT.Properties.Resources.money;
            this.btn_saldoactual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_saldoactual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saldoactual.Location = new System.Drawing.Point(172, 3);
            this.btn_saldoactual.Name = "btn_saldoactual";
            this.btn_saldoactual.Size = new System.Drawing.Size(48, 39);
            this.btn_saldoactual.TabIndex = 24;
            this.btn_saldoactual.UseVisualStyleBackColor = true;
            this.btn_saldoactual.Click += new System.EventHandler(this.btn_saldoactual_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Location = new System.Drawing.Point(282, 3);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(48, 39);
            this.btn_excel.TabIndex = 17;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_canc
            // 
            this.btn_canc.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_canc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_canc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_canc.Location = new System.Drawing.Point(61, 3);
            this.btn_canc.Name = "btn_canc";
            this.btn_canc.Size = new System.Drawing.Size(48, 39);
            this.btn_canc.TabIndex = 16;
            this.btn_canc.UseVisualStyleBackColor = true;
            this.btn_canc.Click += new System.EventHandler(this.btn_canc_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(7, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(48, 39);
            this.btn_add.TabIndex = 15;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(814, 6);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(266, 20);
            this.txt_filtro.TabIndex = 1;
            this.txt_filtro.Tag = "Buscar";
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(636, 6);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(175, 21);
            this.cmb_filtro.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tbcontrol);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1108, 398);
            this.panel3.TabIndex = 2;
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_egreso);
            this.tbcontrol.Controls.Add(this.tb_ingreso);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(1104, 394);
            this.tbcontrol.TabIndex = 0;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_egreso
            // 
            this.tb_egreso.Controls.Add(this.dgrid_egreso);
            this.tb_egreso.Location = new System.Drawing.Point(4, 22);
            this.tb_egreso.Name = "tb_egreso";
            this.tb_egreso.Padding = new System.Windows.Forms.Padding(3);
            this.tb_egreso.Size = new System.Drawing.Size(1096, 368);
            this.tb_egreso.TabIndex = 0;
            this.tb_egreso.Text = "Egreso";
            this.tb_egreso.UseVisualStyleBackColor = true;
            // 
            // dgrid_egreso
            // 
            this.dgrid_egreso.AllowUserToAddRows = false;
            this.dgrid_egreso.AllowUserToDeleteRows = false;
            this.dgrid_egreso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_egreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_egreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_egreso.Location = new System.Drawing.Point(3, 3);
            this.dgrid_egreso.Name = "dgrid_egreso";
            this.dgrid_egreso.ReadOnly = true;
            this.dgrid_egreso.Size = new System.Drawing.Size(1090, 362);
            this.dgrid_egreso.TabIndex = 0;
            this.dgrid_egreso.Click += new System.EventHandler(this.dgrid_egreso_Click);
            this.dgrid_egreso.DoubleClick += new System.EventHandler(this.dgrid_egreso_DoubleClick);
            // 
            // tb_ingreso
            // 
            this.tb_ingreso.Controls.Add(this.dgrid_ingreso);
            this.tb_ingreso.Location = new System.Drawing.Point(4, 22);
            this.tb_ingreso.Name = "tb_ingreso";
            this.tb_ingreso.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ingreso.Size = new System.Drawing.Size(1096, 368);
            this.tb_ingreso.TabIndex = 1;
            this.tb_ingreso.Text = "Ingreso";
            this.tb_ingreso.UseVisualStyleBackColor = true;
            // 
            // dgrid_ingreso
            // 
            this.dgrid_ingreso.AllowUserToAddRows = false;
            this.dgrid_ingreso.AllowUserToDeleteRows = false;
            this.dgrid_ingreso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_ingreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_ingreso.Location = new System.Drawing.Point(3, 3);
            this.dgrid_ingreso.Name = "dgrid_ingreso";
            this.dgrid_ingreso.ReadOnly = true;
            this.dgrid_ingreso.Size = new System.Drawing.Size(1090, 362);
            this.dgrid_ingreso.TabIndex = 0;
            this.dgrid_ingreso.Click += new System.EventHandler(this.dgrid_ingreso_Click);
            this.dgrid_ingreso.DoubleClick += new System.EventHandler(this.dgrid_ingreso_DoubleClick);
            // 
            // VFlujos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VFlujos";
            this.Text = "VFlujos";
            this.Load += new System.EventHandler(this.VFlujos_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tbcontrol.ResumeLayout(false);
            this.tb_egreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_egreso)).EndInit();
            this.tb_ingreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ingreso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_egreso;
        private System.Windows.Forms.TabPage tb_ingreso;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.DataGridView dgrid_egreso;
        private System.Windows.Forms.DataGridView dgrid_ingreso;
        private System.Windows.Forms.Button btn_canc;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_saldoxfecha;
        private System.Windows.Forms.Button btn_saldoactual;
    }
}