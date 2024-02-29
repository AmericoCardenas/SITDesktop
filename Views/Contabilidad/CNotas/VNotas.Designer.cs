namespace SIT.Views.Contabilidad.CMovimientos
{
    partial class VNotas
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
            this.dgrid_notas_creditos = new System.Windows.Forms.DataGridView();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_creditos = new System.Windows.Forms.TabPage();
            this.tb_abonos = new System.Windows.Forms.TabPage();
            this.dgrid_notas_abonos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_movs = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_notas_creditos)).BeginInit();
            this.tbcontrol.SuspendLayout();
            this.tb_creditos.SuspendLayout();
            this.tb_abonos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_notas_abonos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrid_notas_creditos
            // 
            this.dgrid_notas_creditos.AllowUserToAddRows = false;
            this.dgrid_notas_creditos.AllowUserToDeleteRows = false;
            this.dgrid_notas_creditos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_notas_creditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_notas_creditos.Location = new System.Drawing.Point(3, 3);
            this.dgrid_notas_creditos.Name = "dgrid_notas_creditos";
            this.dgrid_notas_creditos.ReadOnly = true;
            this.dgrid_notas_creditos.Size = new System.Drawing.Size(994, 266);
            this.dgrid_notas_creditos.TabIndex = 1;
            this.dgrid_notas_creditos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_notas_creditos_CellContentClick);
            this.dgrid_notas_creditos.Click += new System.EventHandler(this.dgrid_notas_Click);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(751, 6);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(115, 21);
            this.cmb_filtro.TabIndex = 11;
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(880, 7);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(115, 20);
            this.txt_filtro.TabIndex = 12;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_creditos);
            this.tbcontrol.Controls.Add(this.tb_abonos);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 71);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(1008, 298);
            this.tbcontrol.TabIndex = 14;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_creditos
            // 
            this.tb_creditos.Controls.Add(this.dgrid_notas_creditos);
            this.tb_creditos.Location = new System.Drawing.Point(4, 22);
            this.tb_creditos.Name = "tb_creditos";
            this.tb_creditos.Padding = new System.Windows.Forms.Padding(3);
            this.tb_creditos.Size = new System.Drawing.Size(1000, 272);
            this.tb_creditos.TabIndex = 0;
            this.tb_creditos.Text = "Creditos";
            this.tb_creditos.UseVisualStyleBackColor = true;
            // 
            // tb_abonos
            // 
            this.tb_abonos.Controls.Add(this.dgrid_notas_abonos);
            this.tb_abonos.Location = new System.Drawing.Point(4, 22);
            this.tb_abonos.Name = "tb_abonos";
            this.tb_abonos.Padding = new System.Windows.Forms.Padding(3);
            this.tb_abonos.Size = new System.Drawing.Size(1000, 272);
            this.tb_abonos.TabIndex = 1;
            this.tb_abonos.Text = "Abonos";
            this.tb_abonos.UseVisualStyleBackColor = true;
            // 
            // dgrid_notas_abonos
            // 
            this.dgrid_notas_abonos.AllowUserToAddRows = false;
            this.dgrid_notas_abonos.AllowUserToDeleteRows = false;
            this.dgrid_notas_abonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_notas_abonos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_notas_abonos.Location = new System.Drawing.Point(3, 3);
            this.dgrid_notas_abonos.Name = "dgrid_notas_abonos";
            this.dgrid_notas_abonos.ReadOnly = true;
            this.dgrid_notas_abonos.Size = new System.Drawing.Size(994, 266);
            this.dgrid_notas_abonos.TabIndex = 2;
            this.dgrid_notas_abonos.Click += new System.EventHandler(this.dgrid_notas_abonos_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_movs);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 71);
            this.panel1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SIT.Properties.Resources.google_docs;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(178, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 47);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(61, 7);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(54, 47);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_movs
            // 
            this.btn_movs.BackgroundImage = global::SIT.Properties.Resources.movimiento;
            this.btn_movs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_movs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_movs.Location = new System.Drawing.Point(121, 7);
            this.btn_movs.Name = "btn_movs";
            this.btn_movs.Size = new System.Drawing.Size(51, 47);
            this.btn_movs.TabIndex = 15;
            this.btn_movs.UseVisualStyleBackColor = true;
            this.btn_movs.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(6, 7);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(49, 47);
            this.btn_add.TabIndex = 2;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // VNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 369);
            this.Controls.Add(this.tbcontrol);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VNotas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas";
            this.Load += new System.EventHandler(this.VNotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_notas_creditos)).EndInit();
            this.tbcontrol.ResumeLayout(false);
            this.tb_creditos.ResumeLayout(false);
            this.tb_abonos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_notas_abonos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgrid_notas_creditos;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_creditos;
        private System.Windows.Forms.TabPage tb_abonos;
        private System.Windows.Forms.Button btn_movs;
        private System.Windows.Forms.DataGridView dgrid_notas_abonos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}