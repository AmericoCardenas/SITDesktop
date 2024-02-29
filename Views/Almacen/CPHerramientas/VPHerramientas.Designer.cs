namespace SIT.Views.Almacen
{
    partial class VPHerramientas
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
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_pendientes = new System.Windows.Forms.TabPage();
            this.dgrid_herramientas_pendientes = new System.Windows.Forms.DataGridView();
            this.tb_entregados = new System.Windows.Forms.TabPage();
            this.dgrid_herramientas_entregados = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_pendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_herramientas_pendientes)).BeginInit();
            this.tb_entregados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_herramientas_entregados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cancelar);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 54);
            this.panel1.TabIndex = 0;
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.White;
            this.btn_cancelar.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Location = new System.Drawing.Point(67, 3);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(58, 42);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(833, 13);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(140, 20);
            this.txt_filtro.TabIndex = 2;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(705, 11);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 1;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.White;
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(3, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(58, 41);
            this.btn_add.TabIndex = 0;
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbcontrol);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 396);
            this.panel2.TabIndex = 1;
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_pendientes);
            this.tbcontrol.Controls.Add(this.tb_entregados);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(985, 396);
            this.tbcontrol.TabIndex = 1;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_pendientes
            // 
            this.tb_pendientes.Controls.Add(this.dgrid_herramientas_pendientes);
            this.tb_pendientes.Location = new System.Drawing.Point(4, 22);
            this.tb_pendientes.Name = "tb_pendientes";
            this.tb_pendientes.Padding = new System.Windows.Forms.Padding(3);
            this.tb_pendientes.Size = new System.Drawing.Size(977, 370);
            this.tb_pendientes.TabIndex = 0;
            this.tb_pendientes.Text = "Pendientes";
            this.tb_pendientes.UseVisualStyleBackColor = true;
            // 
            // dgrid_herramientas_pendientes
            // 
            this.dgrid_herramientas_pendientes.AllowUserToAddRows = false;
            this.dgrid_herramientas_pendientes.AllowUserToDeleteRows = false;
            this.dgrid_herramientas_pendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_herramientas_pendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_herramientas_pendientes.Location = new System.Drawing.Point(3, 3);
            this.dgrid_herramientas_pendientes.Name = "dgrid_herramientas_pendientes";
            this.dgrid_herramientas_pendientes.ReadOnly = true;
            this.dgrid_herramientas_pendientes.Size = new System.Drawing.Size(971, 364);
            this.dgrid_herramientas_pendientes.TabIndex = 0;
            this.dgrid_herramientas_pendientes.Click += new System.EventHandler(this.dgrid_herramientas_pendientes_Click);
            // 
            // tb_entregados
            // 
            this.tb_entregados.Controls.Add(this.dgrid_herramientas_entregados);
            this.tb_entregados.Location = new System.Drawing.Point(4, 22);
            this.tb_entregados.Name = "tb_entregados";
            this.tb_entregados.Padding = new System.Windows.Forms.Padding(3);
            this.tb_entregados.Size = new System.Drawing.Size(977, 370);
            this.tb_entregados.TabIndex = 1;
            this.tb_entregados.Text = "Entregados";
            this.tb_entregados.UseVisualStyleBackColor = true;
            // 
            // dgrid_herramientas_entregados
            // 
            this.dgrid_herramientas_entregados.AllowUserToAddRows = false;
            this.dgrid_herramientas_entregados.AllowUserToDeleteRows = false;
            this.dgrid_herramientas_entregados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_herramientas_entregados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_herramientas_entregados.Location = new System.Drawing.Point(3, 3);
            this.dgrid_herramientas_entregados.Name = "dgrid_herramientas_entregados";
            this.dgrid_herramientas_entregados.ReadOnly = true;
            this.dgrid_herramientas_entregados.Size = new System.Drawing.Size(971, 364);
            this.dgrid_herramientas_entregados.TabIndex = 0;
            this.dgrid_herramientas_entregados.Click += new System.EventHandler(this.dgrid_herramientas_entregados_Click);
            // 
            // VPHerramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(985, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VPHerramientas";
            this.Text = "VPHerramientas";
            this.Load += new System.EventHandler(this.VPHerramientas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tbcontrol.ResumeLayout(false);
            this.tb_pendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_herramientas_pendientes)).EndInit();
            this.tb_entregados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_herramientas_entregados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.DataGridView dgrid_herramientas_pendientes;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_pendientes;
        private System.Windows.Forms.TabPage tb_entregados;
        private System.Windows.Forms.DataGridView dgrid_herramientas_entregados;
    }
}