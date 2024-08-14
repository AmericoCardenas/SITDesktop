namespace SIT.Views.Almacen.CSalidas
{
    partial class VSalidas
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
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgrid_salidas = new System.Windows.Forms.DataGridView();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_vpendientes = new System.Windows.Forms.TabPage();
            this.tb_vaplicados = new System.Windows.Forms.TabPage();
            this.dgrid_vaplicados = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_salidas)).BeginInit();
            this.tbcontrol.SuspendLayout();
            this.tb_vpendientes.SuspendLayout();
            this.tb_vaplicados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_vaplicados)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 48);
            this.panel1.TabIndex = 0;
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(618, 12);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(174, 20);
            this.txt_filtro.TabIndex = 2;
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(489, 12);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 1;
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(10, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(48, 39);
            this.btn_add.TabIndex = 0;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgrid_salidas
            // 
            this.dgrid_salidas.AllowUserToAddRows = false;
            this.dgrid_salidas.AllowUserToDeleteRows = false;
            this.dgrid_salidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_salidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_salidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_salidas.Location = new System.Drawing.Point(3, 3);
            this.dgrid_salidas.Name = "dgrid_salidas";
            this.dgrid_salidas.ReadOnly = true;
            this.dgrid_salidas.Size = new System.Drawing.Size(782, 366);
            this.dgrid_salidas.TabIndex = 1;
            this.dgrid_salidas.Click += new System.EventHandler(this.dgrid_salidas_Click);
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_vpendientes);
            this.tbcontrol.Controls.Add(this.tb_vaplicados);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(796, 398);
            this.tbcontrol.TabIndex = 2;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_vpendientes
            // 
            this.tb_vpendientes.Controls.Add(this.dgrid_salidas);
            this.tb_vpendientes.Location = new System.Drawing.Point(4, 22);
            this.tb_vpendientes.Name = "tb_vpendientes";
            this.tb_vpendientes.Padding = new System.Windows.Forms.Padding(3);
            this.tb_vpendientes.Size = new System.Drawing.Size(788, 372);
            this.tb_vpendientes.TabIndex = 0;
            this.tb_vpendientes.Text = "ValesPendientes";
            this.tb_vpendientes.UseVisualStyleBackColor = true;
            // 
            // tb_vaplicados
            // 
            this.tb_vaplicados.Controls.Add(this.dgrid_vaplicados);
            this.tb_vaplicados.Location = new System.Drawing.Point(4, 22);
            this.tb_vaplicados.Name = "tb_vaplicados";
            this.tb_vaplicados.Padding = new System.Windows.Forms.Padding(3);
            this.tb_vaplicados.Size = new System.Drawing.Size(788, 372);
            this.tb_vaplicados.TabIndex = 1;
            this.tb_vaplicados.Text = "ValesAplicados";
            this.tb_vaplicados.UseVisualStyleBackColor = true;
            // 
            // dgrid_vaplicados
            // 
            this.dgrid_vaplicados.AllowUserToAddRows = false;
            this.dgrid_vaplicados.AllowUserToDeleteRows = false;
            this.dgrid_vaplicados.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_vaplicados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_vaplicados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_vaplicados.Location = new System.Drawing.Point(3, 3);
            this.dgrid_vaplicados.Name = "dgrid_vaplicados";
            this.dgrid_vaplicados.ReadOnly = true;
            this.dgrid_vaplicados.Size = new System.Drawing.Size(782, 366);
            this.dgrid_vaplicados.TabIndex = 0;
            this.dgrid_vaplicados.Click += new System.EventHandler(this.dgrid_vaplicados_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tbcontrol);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 402);
            this.panel2.TabIndex = 3;
            // 
            // VSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VSalidas";
            this.ShowIcon = false;
            this.Text = "VSalidas";
            this.Load += new System.EventHandler(this.VSalidas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_salidas)).EndInit();
            this.tbcontrol.ResumeLayout(false);
            this.tb_vpendientes.ResumeLayout(false);
            this.tb_vaplicados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_vaplicados)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgrid_salidas;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_vpendientes;
        private System.Windows.Forms.TabPage tb_vaplicados;
        private System.Windows.Forms.DataGridView dgrid_vaplicados;
        private System.Windows.Forms.Panel panel2;
    }
}