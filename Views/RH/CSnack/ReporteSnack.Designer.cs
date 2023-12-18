namespace SIT.Views.RH.CSnack
{
    partial class ReporteSnack
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtm_inicial = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtm_final = new System.Windows.Forms.DateTimePicker();
            this.btn_export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicial";
            // 
            // dtm_inicial
            // 
            this.dtm_inicial.Location = new System.Drawing.Point(123, 7);
            this.dtm_inicial.Name = "dtm_inicial";
            this.dtm_inicial.Size = new System.Drawing.Size(200, 20);
            this.dtm_inicial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha Final";
            // 
            // dtm_final
            // 
            this.dtm_final.Location = new System.Drawing.Point(123, 40);
            this.dtm_final.Name = "dtm_final";
            this.dtm_final.Size = new System.Drawing.Size(200, 20);
            this.dtm_final.TabIndex = 3;
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(149, 71);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(92, 32);
            this.btn_export.TabIndex = 4;
            this.btn_export.Text = "Exportar";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // ReporteSnack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(333, 112);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.dtm_final);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtm_inicial);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReporteSnack";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.ReporteSnack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtm_inicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtm_final;
        private System.Windows.Forms.Button btn_export;
    }
}