namespace SIT.Views.Logistica.CIncidencias
{
    partial class VIncidencias
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
            this.btn_aplicar = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.btn_catincidencias = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_incpend = new System.Windows.Forms.TabPage();
            this.dgrid_incpend = new System.Windows.Forms.DataGridView();
            this.tb_incapl = new System.Windows.Forms.TabPage();
            this.dgrid_incaplicadas = new System.Windows.Forms.DataGridView();
            this.btn_excel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_incpend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_incpend)).BeginInit();
            this.tb_incapl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_incaplicadas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.btn_aplicar);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_catincidencias);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 52);
            this.panel1.TabIndex = 0;
            // 
            // btn_aplicar
            // 
            this.btn_aplicar.BackgroundImage = global::SIT.Properties.Resources.nomina;
            this.btn_aplicar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_aplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aplicar.Location = new System.Drawing.Point(487, 5);
            this.btn_aplicar.Name = "btn_aplicar";
            this.btn_aplicar.Size = new System.Drawing.Size(53, 39);
            this.btn_aplicar.TabIndex = 6;
            this.btn_aplicar.UseVisualStyleBackColor = true;
            this.btn_aplicar.Click += new System.EventHandler(this.btn_aplicar_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef5841;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(63, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(53, 39);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Visible = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(995, 13);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(166, 20);
            this.txt_filtro.TabIndex = 4;
            this.txt_filtro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_filtro_KeyPress);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(867, 13);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 3;
            // 
            // btn_catincidencias
            // 
            this.btn_catincidencias.BackgroundImage = global::SIT.Properties.Resources.megafono;
            this.btn_catincidencias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_catincidencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_catincidencias.Location = new System.Drawing.Point(808, 5);
            this.btn_catincidencias.Name = "btn_catincidencias";
            this.btn_catincidencias.Size = new System.Drawing.Size(53, 39);
            this.btn_catincidencias.TabIndex = 2;
            this.btn_catincidencias.UseVisualStyleBackColor = true;
            this.btn_catincidencias.Click += new System.EventHandler(this.btn_catincidencias_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(4, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(53, 39);
            this.btn_add.TabIndex = 1;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Visible = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tbcontrol);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1175, 398);
            this.panel2.TabIndex = 1;
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_incpend);
            this.tbcontrol.Controls.Add(this.tb_incapl);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(1171, 394);
            this.tbcontrol.TabIndex = 0;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_incpend
            // 
            this.tb_incpend.Controls.Add(this.dgrid_incpend);
            this.tb_incpend.Location = new System.Drawing.Point(4, 22);
            this.tb_incpend.Name = "tb_incpend";
            this.tb_incpend.Padding = new System.Windows.Forms.Padding(3);
            this.tb_incpend.Size = new System.Drawing.Size(1018, 368);
            this.tb_incpend.TabIndex = 0;
            this.tb_incpend.Text = "Pendientes";
            this.tb_incpend.UseVisualStyleBackColor = true;
            // 
            // dgrid_incpend
            // 
            this.dgrid_incpend.AllowUserToAddRows = false;
            this.dgrid_incpend.AllowUserToDeleteRows = false;
            this.dgrid_incpend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_incpend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_incpend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_incpend.Location = new System.Drawing.Point(3, 3);
            this.dgrid_incpend.Name = "dgrid_incpend";
            this.dgrid_incpend.ReadOnly = true;
            this.dgrid_incpend.Size = new System.Drawing.Size(1012, 362);
            this.dgrid_incpend.TabIndex = 0;
            this.dgrid_incpend.Click += new System.EventHandler(this.dgrid_incpend_Click);
            // 
            // tb_incapl
            // 
            this.tb_incapl.Controls.Add(this.dgrid_incaplicadas);
            this.tb_incapl.Location = new System.Drawing.Point(4, 22);
            this.tb_incapl.Name = "tb_incapl";
            this.tb_incapl.Padding = new System.Windows.Forms.Padding(3);
            this.tb_incapl.Size = new System.Drawing.Size(1163, 368);
            this.tb_incapl.TabIndex = 1;
            this.tb_incapl.Text = "Aplicadas";
            this.tb_incapl.UseVisualStyleBackColor = true;
            // 
            // dgrid_incaplicadas
            // 
            this.dgrid_incaplicadas.AllowUserToAddRows = false;
            this.dgrid_incaplicadas.AllowUserToDeleteRows = false;
            this.dgrid_incaplicadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_incaplicadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_incaplicadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_incaplicadas.Location = new System.Drawing.Point(3, 3);
            this.dgrid_incaplicadas.Name = "dgrid_incaplicadas";
            this.dgrid_incaplicadas.ReadOnly = true;
            this.dgrid_incaplicadas.Size = new System.Drawing.Size(1157, 362);
            this.dgrid_incaplicadas.TabIndex = 0;
            // 
            // btn_excel
            // 
            this.btn_excel.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Location = new System.Drawing.Point(749, 5);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(53, 39);
            this.btn_excel.TabIndex = 7;
            this.btn_excel.UseVisualStyleBackColor = true;
            // 
            // VIncidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1175, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VIncidencias";
            this.Text = "VIncidencias";
            this.Load += new System.EventHandler(this.VIncidencias_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tbcontrol.ResumeLayout(false);
            this.tb_incpend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_incpend)).EndInit();
            this.tb_incapl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_incaplicadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_incpend;
        private System.Windows.Forms.TabPage tb_incapl;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Button btn_catincidencias;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.DataGridView dgrid_incpend;
        private System.Windows.Forms.DataGridView dgrid_incaplicadas;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_aplicar;
        private System.Windows.Forms.Button btn_excel;
    }
}