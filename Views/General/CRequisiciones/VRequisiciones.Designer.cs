namespace SIT.Views.General.CRequisiciones
{
    partial class VRequisiciones
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_pendientes = new System.Windows.Forms.TabPage();
            this.dgrid_reqpendientes = new System.Windows.Forms.DataGridView();
            this.tb_autorizadas = new System.Windows.Forms.TabPage();
            this.dgrid_reqautorizadas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_pendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_reqpendientes)).BeginInit();
            this.tb_autorizadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_reqautorizadas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 44);
            this.panel1.TabIndex = 0;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(65, 0);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(48, 39);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(657, 9);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(176, 20);
            this.txt_filtro.TabIndex = 2;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(491, 10);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(147, 21);
            this.cmb_filtro.TabIndex = 1;
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(6, 0);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(48, 39);
            this.btn_add.TabIndex = 0;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tbcontrol);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 406);
            this.panel2.TabIndex = 1;
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_pendientes);
            this.tbcontrol.Controls.Add(this.tb_autorizadas);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(841, 402);
            this.tbcontrol.TabIndex = 1;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_pendientes
            // 
            this.tb_pendientes.Controls.Add(this.dgrid_reqpendientes);
            this.tb_pendientes.Location = new System.Drawing.Point(4, 22);
            this.tb_pendientes.Name = "tb_pendientes";
            this.tb_pendientes.Padding = new System.Windows.Forms.Padding(3);
            this.tb_pendientes.Size = new System.Drawing.Size(833, 376);
            this.tb_pendientes.TabIndex = 0;
            this.tb_pendientes.Text = "Pendientes";
            this.tb_pendientes.UseVisualStyleBackColor = true;
            // 
            // dgrid_reqpendientes
            // 
            this.dgrid_reqpendientes.AllowUserToAddRows = false;
            this.dgrid_reqpendientes.AllowUserToDeleteRows = false;
            this.dgrid_reqpendientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_reqpendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_reqpendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_reqpendientes.Location = new System.Drawing.Point(3, 3);
            this.dgrid_reqpendientes.Name = "dgrid_reqpendientes";
            this.dgrid_reqpendientes.ReadOnly = true;
            this.dgrid_reqpendientes.Size = new System.Drawing.Size(827, 370);
            this.dgrid_reqpendientes.TabIndex = 0;
            this.dgrid_reqpendientes.Click += new System.EventHandler(this.dgrid_reqpendientes_Click);
            // 
            // tb_autorizadas
            // 
            this.tb_autorizadas.Controls.Add(this.dgrid_reqautorizadas);
            this.tb_autorizadas.Location = new System.Drawing.Point(4, 22);
            this.tb_autorizadas.Name = "tb_autorizadas";
            this.tb_autorizadas.Padding = new System.Windows.Forms.Padding(3);
            this.tb_autorizadas.Size = new System.Drawing.Size(833, 376);
            this.tb_autorizadas.TabIndex = 1;
            this.tb_autorizadas.Text = "Autorizadas";
            this.tb_autorizadas.UseVisualStyleBackColor = true;
            // 
            // dgrid_reqautorizadas
            // 
            this.dgrid_reqautorizadas.AllowUserToAddRows = false;
            this.dgrid_reqautorizadas.AllowUserToDeleteRows = false;
            this.dgrid_reqautorizadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_reqautorizadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_reqautorizadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_reqautorizadas.Location = new System.Drawing.Point(3, 3);
            this.dgrid_reqautorizadas.Name = "dgrid_reqautorizadas";
            this.dgrid_reqautorizadas.ReadOnly = true;
            this.dgrid_reqautorizadas.Size = new System.Drawing.Size(827, 370);
            this.dgrid_reqautorizadas.TabIndex = 0;
            this.dgrid_reqautorizadas.Click += new System.EventHandler(this.dgrid_reqautorizadas_Click);
            // 
            // VRequisiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(845, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VRequisiciones";
            this.Text = "VRequisiciones";
            this.Load += new System.EventHandler(this.VRequisiciones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tbcontrol.ResumeLayout(false);
            this.tb_pendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_reqpendientes)).EndInit();
            this.tb_autorizadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_reqautorizadas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgrid_reqpendientes;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_pendientes;
        private System.Windows.Forms.TabPage tb_autorizadas;
        private System.Windows.Forms.DataGridView dgrid_reqautorizadas;
        private System.Windows.Forms.Button btn_cancel;
    }
}