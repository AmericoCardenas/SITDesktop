namespace SIT.Views.Contabilidad
{
    partial class VMovimientos
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
            this.btn_excel = new System.Windows.Forms.Button();
            this.btn_saldoxfecha = new System.Windows.Forms.Button();
            this.btn_saldoactual = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_egreso = new System.Windows.Forms.TabPage();
            this.dgrid_egreso = new System.Windows.Forms.DataGridView();
            this.tb_ingreso = new System.Windows.Forms.TabPage();
            this.dgrid_ingreso = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_egreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_egreso)).BeginInit();
            this.tb_ingreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ingreso)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.btn_saldoxfecha);
            this.panel1.Controls.Add(this.btn_saldoactual);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 52);
            this.panel1.TabIndex = 0;
            // 
            // btn_excel
            // 
            this.btn_excel.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Location = new System.Drawing.Point(231, 3);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(47, 39);
            this.btn_excel.TabIndex = 24;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_saldoxfecha
            // 
            this.btn_saldoxfecha.BackgroundImage = global::SIT.Properties.Resources.schedule;
            this.btn_saldoxfecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_saldoxfecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saldoxfecha.Location = new System.Drawing.Point(175, 3);
            this.btn_saldoxfecha.Name = "btn_saldoxfecha";
            this.btn_saldoxfecha.Size = new System.Drawing.Size(50, 39);
            this.btn_saldoxfecha.TabIndex = 23;
            this.btn_saldoxfecha.UseVisualStyleBackColor = true;
            this.btn_saldoxfecha.Click += new System.EventHandler(this.btn_saldoxfecha_Click);
            // 
            // btn_saldoactual
            // 
            this.btn_saldoactual.BackgroundImage = global::SIT.Properties.Resources.money;
            this.btn_saldoactual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_saldoactual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saldoactual.Location = new System.Drawing.Point(112, 3);
            this.btn_saldoactual.Name = "btn_saldoactual";
            this.btn_saldoactual.Size = new System.Drawing.Size(56, 39);
            this.btn_saldoactual.TabIndex = 22;
            this.btn_saldoactual.UseVisualStyleBackColor = true;
            this.btn_saldoactual.Click += new System.EventHandler(this.btn_saldoactual_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(811, 12);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(202, 20);
            this.txt_filtro.TabIndex = 19;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(681, 12);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 18;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef5841;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(59, 2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(47, 40);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(7, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(47, 39);
            this.btn_add.TabIndex = 16;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbcontrol);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 398);
            this.panel2.TabIndex = 1;
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_egreso);
            this.tbcontrol.Controls.Add(this.tb_ingreso);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(1020, 398);
            this.tbcontrol.TabIndex = 0;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_egreso
            // 
            this.tb_egreso.Controls.Add(this.dgrid_egreso);
            this.tb_egreso.Location = new System.Drawing.Point(4, 22);
            this.tb_egreso.Name = "tb_egreso";
            this.tb_egreso.Padding = new System.Windows.Forms.Padding(3);
            this.tb_egreso.Size = new System.Drawing.Size(1012, 372);
            this.tb_egreso.TabIndex = 0;
            this.tb_egreso.Text = "Egreso";
            this.tb_egreso.UseVisualStyleBackColor = true;
            // 
            // dgrid_egreso
            // 
            this.dgrid_egreso.AllowUserToAddRows = false;
            this.dgrid_egreso.AllowUserToDeleteRows = false;
            this.dgrid_egreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_egreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_egreso.Location = new System.Drawing.Point(3, 3);
            this.dgrid_egreso.Name = "dgrid_egreso";
            this.dgrid_egreso.ReadOnly = true;
            this.dgrid_egreso.Size = new System.Drawing.Size(1006, 366);
            this.dgrid_egreso.TabIndex = 0;
            this.dgrid_egreso.Click += new System.EventHandler(this.dgrid_ingreso_Click);
            this.dgrid_egreso.DoubleClick += new System.EventHandler(this.dgrid_egreso_DoubleClick);
            // 
            // tb_ingreso
            // 
            this.tb_ingreso.Controls.Add(this.dgrid_ingreso);
            this.tb_ingreso.Location = new System.Drawing.Point(4, 22);
            this.tb_ingreso.Name = "tb_ingreso";
            this.tb_ingreso.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ingreso.Size = new System.Drawing.Size(1012, 372);
            this.tb_ingreso.TabIndex = 1;
            this.tb_ingreso.Text = "Ingreso";
            this.tb_ingreso.UseVisualStyleBackColor = true;
            // 
            // dgrid_ingreso
            // 
            this.dgrid_ingreso.AllowUserToAddRows = false;
            this.dgrid_ingreso.AllowUserToDeleteRows = false;
            this.dgrid_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_ingreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_ingreso.Location = new System.Drawing.Point(3, 3);
            this.dgrid_ingreso.Name = "dgrid_ingreso";
            this.dgrid_ingreso.ReadOnly = true;
            this.dgrid_ingreso.Size = new System.Drawing.Size(1006, 366);
            this.dgrid_ingreso.TabIndex = 0;
            this.dgrid_ingreso.Click += new System.EventHandler(this.dgrid_egreso_Click);
            this.dgrid_ingreso.DoubleClick += new System.EventHandler(this.dgrid_ingreso_DoubleClick);
            // 
            // VMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VMovimientos";
            this.Text = "VMovimientos";
            this.Load += new System.EventHandler(this.VMovimientos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tbcontrol.ResumeLayout(false);
            this.tb_egreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_egreso)).EndInit();
            this.tb_ingreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ingreso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_egreso;
        private System.Windows.Forms.TabPage tb_ingreso;
        private System.Windows.Forms.DataGridView dgrid_egreso;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgrid_ingreso;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Button btn_saldoactual;
        private System.Windows.Forms.Button btn_saldoxfecha;
        private System.Windows.Forms.Button btn_excel;
    }
}