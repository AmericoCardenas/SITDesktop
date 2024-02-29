namespace SIT.Views.Taller.CActividadesTaller
{
    partial class AEActividadTaller
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
            this.txt_actividad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_te = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_formato = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_grupo = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_add_grupo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actividad";
            // 
            // txt_actividad
            // 
            this.txt_actividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_actividad.Location = new System.Drawing.Point(166, 7);
            this.txt_actividad.Name = "txt_actividad";
            this.txt_actividad.Size = new System.Drawing.Size(150, 26);
            this.txt_actividad.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiempo Estimado";
            // 
            // txt_te
            // 
            this.txt_te.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_te.Location = new System.Drawing.Point(166, 39);
            this.txt_te.Name = "txt_te";
            this.txt_te.Size = new System.Drawing.Size(150, 26);
            this.txt_te.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Formato";
            // 
            // cmb_formato
            // 
            this.cmb_formato.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_formato.FormattingEnabled = true;
            this.cmb_formato.Location = new System.Drawing.Point(166, 72);
            this.cmb_formato.Name = "cmb_formato";
            this.cmb_formato.Size = new System.Drawing.Size(150, 28);
            this.cmb_formato.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(101, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Grupo";
            // 
            // cmb_grupo
            // 
            this.cmb_grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_grupo.FormattingEnabled = true;
            this.cmb_grupo.Location = new System.Drawing.Point(166, 107);
            this.cmb_grupo.Name = "cmb_grupo";
            this.cmb_grupo.Size = new System.Drawing.Size(150, 28);
            this.cmb_grupo.TabIndex = 7;
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.check;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(193, 141);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 55);
            this.btn_add.TabIndex = 8;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_add_grupo
            // 
            this.btn_add_grupo.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add_grupo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add_grupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_grupo.Location = new System.Drawing.Point(323, 107);
            this.btn_add_grupo.Name = "btn_add_grupo";
            this.btn_add_grupo.Size = new System.Drawing.Size(45, 28);
            this.btn_add_grupo.TabIndex = 9;
            this.btn_add_grupo.UseVisualStyleBackColor = true;
            this.btn_add_grupo.Click += new System.EventHandler(this.btn_add_grupo_Click);
            // 
            // AEActividadTaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 203);
            this.Controls.Add(this.btn_add_grupo);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cmb_grupo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmb_formato);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_te);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_actividad);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AEActividadTaller";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AEActividadTaller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AEActividadTaller_FormClosed);
            this.Load += new System.EventHandler(this.AEActividadTaller_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_actividad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_te;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_formato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_grupo;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_add_grupo;
    }
}