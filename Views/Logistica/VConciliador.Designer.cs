namespace SIT.Views.Logistica
{
    partial class VConciliador
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
            this.label3 = new System.Windows.Forms.Label();
            this.btn_conciliar = new System.Windows.Forms.Button();
            this.dtm_fecha = new System.Windows.Forms.DateTimePicker();
            this.pgrbar = new System.Windows.Forms.ProgressBar();
            this.btn_impBitad = new System.Windows.Forms.Button();
            this.btn_impRol = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgrid_rol = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgrid_bitad = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_cantrol = new System.Windows.Forms.Label();
            this.lbl_cantbitad = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_rol)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_bitad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_conciliar);
            this.panel1.Controls.Add(this.dtm_fecha);
            this.panel1.Controls.Add(this.pgrbar);
            this.panel1.Controls.Add(this.btn_impBitad);
            this.panel1.Controls.Add(this.btn_impRol);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 43);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha";
            // 
            // btn_conciliar
            // 
            this.btn_conciliar.Location = new System.Drawing.Point(664, 12);
            this.btn_conciliar.Name = "btn_conciliar";
            this.btn_conciliar.Size = new System.Drawing.Size(75, 23);
            this.btn_conciliar.TabIndex = 5;
            this.btn_conciliar.Text = "Conciliar";
            this.btn_conciliar.UseVisualStyleBackColor = true;
            this.btn_conciliar.Click += new System.EventHandler(this.btn_conciliar_Click);
            // 
            // dtm_fecha
            // 
            this.dtm_fecha.Location = new System.Drawing.Point(88, 11);
            this.dtm_fecha.Name = "dtm_fecha";
            this.dtm_fecha.Size = new System.Drawing.Size(163, 20);
            this.dtm_fecha.TabIndex = 4;
            // 
            // pgrbar
            // 
            this.pgrbar.Location = new System.Drawing.Point(427, 11);
            this.pgrbar.Name = "pgrbar";
            this.pgrbar.Size = new System.Drawing.Size(222, 23);
            this.pgrbar.TabIndex = 3;
            // 
            // btn_impBitad
            // 
            this.btn_impBitad.Location = new System.Drawing.Point(345, 10);
            this.btn_impBitad.Name = "btn_impBitad";
            this.btn_impBitad.Size = new System.Drawing.Size(75, 23);
            this.btn_impBitad.TabIndex = 2;
            this.btn_impBitad.Text = "ExcelBitad";
            this.btn_impBitad.UseVisualStyleBackColor = true;
            this.btn_impBitad.Click += new System.EventHandler(this.btn_impBitad_Click);
            // 
            // btn_impRol
            // 
            this.btn_impRol.Location = new System.Drawing.Point(264, 10);
            this.btn_impRol.Name = "btn_impRol";
            this.btn_impRol.Size = new System.Drawing.Size(75, 23);
            this.btn_impRol.TabIndex = 1;
            this.btn_impRol.Text = "ExcelRol";
            this.btn_impRol.UseVisualStyleBackColor = true;
            this.btn_impRol.Click += new System.EventHandler(this.btn_impRol_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgrid_rol);
            this.panel2.Location = new System.Drawing.Point(3, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 182);
            this.panel2.TabIndex = 2;
            // 
            // dgrid_rol
            // 
            this.dgrid_rol.AllowUserToAddRows = false;
            this.dgrid_rol.AllowUserToDeleteRows = false;
            this.dgrid_rol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_rol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_rol.Location = new System.Drawing.Point(0, 0);
            this.dgrid_rol.Name = "dgrid_rol";
            this.dgrid_rol.ReadOnly = true;
            this.dgrid_rol.Size = new System.Drawing.Size(863, 182);
            this.dgrid_rol.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgrid_bitad);
            this.panel3.Location = new System.Drawing.Point(3, 237);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(863, 210);
            this.panel3.TabIndex = 3;
            // 
            // dgrid_bitad
            // 
            this.dgrid_bitad.AllowUserToAddRows = false;
            this.dgrid_bitad.AllowUserToDeleteRows = false;
            this.dgrid_bitad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_bitad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_bitad.Location = new System.Drawing.Point(0, 0);
            this.dgrid_bitad.Name = "dgrid_bitad";
            this.dgrid_bitad.ReadOnly = true;
            this.dgrid_bitad.Size = new System.Drawing.Size(863, 210);
            this.dgrid_bitad.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(895, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(895, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bitad";
            // 
            // lbl_cantrol
            // 
            this.lbl_cantrol.AutoSize = true;
            this.lbl_cantrol.Location = new System.Drawing.Point(896, 92);
            this.lbl_cantrol.Name = "lbl_cantrol";
            this.lbl_cantrol.Size = new System.Drawing.Size(35, 13);
            this.lbl_cantrol.TabIndex = 6;
            this.lbl_cantrol.Text = "label3";
            // 
            // lbl_cantbitad
            // 
            this.lbl_cantbitad.AutoSize = true;
            this.lbl_cantbitad.Location = new System.Drawing.Point(899, 285);
            this.lbl_cantbitad.Name = "lbl_cantbitad";
            this.lbl_cantbitad.Size = new System.Drawing.Size(35, 13);
            this.lbl_cantbitad.TabIndex = 7;
            this.lbl_cantbitad.Text = "label4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(754, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VConciliador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(955, 450);
            this.Controls.Add(this.lbl_cantbitad);
            this.Controls.Add(this.lbl_cantrol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VConciliador";
            this.Text = "VConciliador";
            this.Load += new System.EventHandler(this.VConciliador_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_rol)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_bitad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_impRol;
        private System.Windows.Forms.ProgressBar pgrbar;
        private System.Windows.Forms.Button btn_impBitad;
        private System.Windows.Forms.Button btn_conciliar;
        private System.Windows.Forms.DateTimePicker dtm_fecha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgrid_rol;
        private System.Windows.Forms.DataGridView dgrid_bitad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_cantrol;
        private System.Windows.Forms.Label lbl_cantbitad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}