namespace SIT.Views.Catalogos.CAlmacenes
{
    partial class AEZonaAlmacen
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
            this.cmb_almacenes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_zona = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Almacen";
            // 
            // cmb_almacenes
            // 
            this.cmb_almacenes.FormattingEnabled = true;
            this.cmb_almacenes.Location = new System.Drawing.Point(100, 10);
            this.cmb_almacenes.Name = "cmb_almacenes";
            this.cmb_almacenes.Size = new System.Drawing.Size(179, 21);
            this.cmb_almacenes.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zona";
            // 
            // txt_zona
            // 
            this.txt_zona.Location = new System.Drawing.Point(100, 47);
            this.txt_zona.Name = "txt_zona";
            this.txt_zona.Size = new System.Drawing.Size(179, 20);
            this.txt_zona.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SIT.Properties.Resources.check;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(304, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 51);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AEZonaAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(381, 86);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_zona);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_almacenes);
            this.Controls.Add(this.label1);
            this.Name = "AEZonaAlmacen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AEZonaAlmacen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AEZonaAlmacen_FormClosed);
            this.Load += new System.EventHandler(this.AEZonaAlmacen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_almacenes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_zona;
        private System.Windows.Forms.Button button1;
    }
}