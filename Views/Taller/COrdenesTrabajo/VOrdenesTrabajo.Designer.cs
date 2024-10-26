namespace SIT.Views.Taller
{
    partial class VOrdenesTrabajo
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
            this.btn_act_mecanicos = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_pendientes = new System.Windows.Forms.TabPage();
            this.dgrid_otpend = new System.Windows.Forms.DataGridView();
            this.tb_terminadas = new System.Windows.Forms.TabPage();
            this.dgrid_otfin = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_pendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_otpend)).BeginInit();
            this.tb_terminadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_otfin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.btn_act_mecanicos);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 49);
            this.panel1.TabIndex = 0;
            // 
            // btn_excel
            // 
            this.btn_excel.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Location = new System.Drawing.Point(188, 3);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(53, 39);
            this.btn_excel.TabIndex = 4;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // btn_act_mecanicos
            // 
            this.btn_act_mecanicos.BackgroundImage = global::SIT.Properties.Resources.mecanico;
            this.btn_act_mecanicos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_act_mecanicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_act_mecanicos.Location = new System.Drawing.Point(129, 3);
            this.btn_act_mecanicos.Name = "btn_act_mecanicos";
            this.btn_act_mecanicos.Size = new System.Drawing.Size(53, 39);
            this.btn_act_mecanicos.TabIndex = 3;
            this.btn_act_mecanicos.UseVisualStyleBackColor = true;
            this.btn_act_mecanicos.Click += new System.EventHandler(this.btn_act_mecanicos_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(62, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(53, 39);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(3, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(53, 39);
            this.btn_add.TabIndex = 1;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_pendientes);
            this.tbcontrol.Controls.Add(this.tb_terminadas);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 49);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(800, 401);
            this.tbcontrol.TabIndex = 1;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_pendientes
            // 
            this.tb_pendientes.Controls.Add(this.dgrid_otpend);
            this.tb_pendientes.Location = new System.Drawing.Point(4, 22);
            this.tb_pendientes.Name = "tb_pendientes";
            this.tb_pendientes.Padding = new System.Windows.Forms.Padding(3);
            this.tb_pendientes.Size = new System.Drawing.Size(792, 375);
            this.tb_pendientes.TabIndex = 0;
            this.tb_pendientes.Text = "Pendientes";
            this.tb_pendientes.UseVisualStyleBackColor = true;
            // 
            // dgrid_otpend
            // 
            this.dgrid_otpend.AllowUserToAddRows = false;
            this.dgrid_otpend.AllowUserToDeleteRows = false;
            this.dgrid_otpend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_otpend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_otpend.Location = new System.Drawing.Point(3, 3);
            this.dgrid_otpend.Name = "dgrid_otpend";
            this.dgrid_otpend.ReadOnly = true;
            this.dgrid_otpend.Size = new System.Drawing.Size(786, 369);
            this.dgrid_otpend.TabIndex = 0;
            this.dgrid_otpend.Click += new System.EventHandler(this.dgrid_otpend_Click);
            // 
            // tb_terminadas
            // 
            this.tb_terminadas.Controls.Add(this.dgrid_otfin);
            this.tb_terminadas.Location = new System.Drawing.Point(4, 22);
            this.tb_terminadas.Name = "tb_terminadas";
            this.tb_terminadas.Padding = new System.Windows.Forms.Padding(3);
            this.tb_terminadas.Size = new System.Drawing.Size(792, 375);
            this.tb_terminadas.TabIndex = 1;
            this.tb_terminadas.Text = "Finalizadas";
            this.tb_terminadas.UseVisualStyleBackColor = true;
            // 
            // dgrid_otfin
            // 
            this.dgrid_otfin.AllowUserToAddRows = false;
            this.dgrid_otfin.AllowUserToDeleteRows = false;
            this.dgrid_otfin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_otfin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_otfin.Location = new System.Drawing.Point(3, 3);
            this.dgrid_otfin.Name = "dgrid_otfin";
            this.dgrid_otfin.ReadOnly = true;
            this.dgrid_otfin.Size = new System.Drawing.Size(786, 369);
            this.dgrid_otfin.TabIndex = 0;
            this.dgrid_otfin.Click += new System.EventHandler(this.dgrid_otfin_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 401);
            this.panel2.TabIndex = 2;
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(519, 10);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 5;
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(647, 11);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(139, 20);
            this.txt_filtro.TabIndex = 6;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // VOrdenesTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbcontrol);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VOrdenesTrabajo";
            this.Text = "VOrdenesTrabajo";
            this.Load += new System.EventHandler(this.VOrdenesTrabajo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbcontrol.ResumeLayout(false);
            this.tb_pendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_otpend)).EndInit();
            this.tb_terminadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_otfin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_pendientes;
        private System.Windows.Forms.TabPage tb_terminadas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrid_otpend;
        private System.Windows.Forms.DataGridView dgrid_otfin;
        private System.Windows.Forms.Button btn_act_mecanicos;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
    }
}