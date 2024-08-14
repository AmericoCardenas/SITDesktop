namespace SIT.Views.Catalogos.CEmpleados
{
    partial class VCuestBajEmp
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtm_bajaemp = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_nombreemp = new System.Windows.Forms.Label();
            this.txt_motivobajaemp = new System.Windows.Forms.RichTextBox();
            this.btn_bajaemp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motivo:";
            // 
            // dtm_bajaemp
            // 
            this.dtm_bajaemp.Location = new System.Drawing.Point(99, 37);
            this.dtm_bajaemp.Name = "dtm_bajaemp";
            this.dtm_bajaemp.Size = new System.Drawing.Size(235, 20);
            this.dtm_bajaemp.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Empleado:";
            // 
            // lbl_nombreemp
            // 
            this.lbl_nombreemp.AutoSize = true;
            this.lbl_nombreemp.Location = new System.Drawing.Point(99, 13);
            this.lbl_nombreemp.Name = "lbl_nombreemp";
            this.lbl_nombreemp.Size = new System.Drawing.Size(99, 13);
            this.lbl_nombreemp.TabIndex = 4;
            this.lbl_nombreemp.Text = "{NombreEmpleado}";
            // 
            // txt_motivobajaemp
            // 
            this.txt_motivobajaemp.Location = new System.Drawing.Point(99, 70);
            this.txt_motivobajaemp.Name = "txt_motivobajaemp";
            this.txt_motivobajaemp.Size = new System.Drawing.Size(235, 96);
            this.txt_motivobajaemp.TabIndex = 5;
            this.txt_motivobajaemp.Text = "";
            // 
            // btn_bajaemp
            // 
            this.btn_bajaemp.BackColor = System.Drawing.Color.Cornsilk;
            this.btn_bajaemp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bajaemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bajaemp.Location = new System.Drawing.Point(145, 173);
            this.btn_bajaemp.Name = "btn_bajaemp";
            this.btn_bajaemp.Size = new System.Drawing.Size(92, 31);
            this.btn_bajaemp.TabIndex = 6;
            this.btn_bajaemp.Text = "Aceptar";
            this.btn_bajaemp.UseVisualStyleBackColor = false;
            this.btn_bajaemp.Click += new System.EventHandler(this.btn_bajaemp_Click);
            // 
            // VCuestBajEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(347, 213);
            this.Controls.Add(this.btn_bajaemp);
            this.Controls.Add(this.txt_motivobajaemp);
            this.Controls.Add(this.lbl_nombreemp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtm_bajaemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "VCuestBajEmp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VCuestBajEmp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VCuestBajEmp_FormClosed);
            this.Load += new System.EventHandler(this.VCuestBajEmp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtm_bajaemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_nombreemp;
        private System.Windows.Forms.RichTextBox txt_motivobajaemp;
        private System.Windows.Forms.Button btn_bajaemp;
    }
}