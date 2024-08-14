namespace SIT.Views.RH.CAsistencia
{
    partial class VAsistencia
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtm_finicial = new System.Windows.Forms.DateTimePicker();
            this.dtm_ffinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.dgrid_asistencia = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_asistencia)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Controls.Add(this.dtm_ffinal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtm_finicial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 55);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgrid_asistencia);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 395);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicial";
            // 
            // dtm_finicial
            // 
            this.dtm_finicial.Location = new System.Drawing.Point(144, 14);
            this.dtm_finicial.Name = "dtm_finicial";
            this.dtm_finicial.Size = new System.Drawing.Size(148, 20);
            this.dtm_finicial.TabIndex = 1;
            // 
            // dtm_ffinal
            // 
            this.dtm_ffinal.Location = new System.Drawing.Point(451, 15);
            this.dtm_ffinal.Name = "dtm_ffinal";
            this.dtm_ffinal.Size = new System.Drawing.Size(148, 20);
            this.dtm_ffinal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(315, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Final";
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackgroundImage = global::SIT.Properties.Resources.refresh;
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.Location = new System.Drawing.Point(613, 7);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(48, 39);
            this.btn_refresh.TabIndex = 8;
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Location = new System.Drawing.Point(675, 7);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(48, 39);
            this.btn_excel.TabIndex = 9;
            this.btn_excel.UseVisualStyleBackColor = true;
            // 
            // dgrid_asistencia
            // 
            this.dgrid_asistencia.AllowUserToAddRows = false;
            this.dgrid_asistencia.AllowUserToDeleteRows = false;
            this.dgrid_asistencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_asistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_asistencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_asistencia.Location = new System.Drawing.Point(0, 0);
            this.dgrid_asistencia.Name = "dgrid_asistencia";
            this.dgrid_asistencia.ReadOnly = true;
            this.dgrid_asistencia.Size = new System.Drawing.Size(730, 391);
            this.dgrid_asistencia.TabIndex = 0;
            // 
            // VAsistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(734, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "VAsistencia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VAsistencia";
            this.Load += new System.EventHandler(this.VAsistencia_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_asistencia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtm_ffinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtm_finicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.DataGridView dgrid_asistencia;
    }
}