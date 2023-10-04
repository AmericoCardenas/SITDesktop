namespace SIT.Views.Catalogos
{
    partial class VUnidades
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
            this.dgrid_unidades = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_unidades)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrid_unidades
            // 
            this.dgrid_unidades.AllowUserToAddRows = false;
            this.dgrid_unidades.AllowUserToDeleteRows = false;
            this.dgrid_unidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_unidades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_unidades.Location = new System.Drawing.Point(0, 0);
            this.dgrid_unidades.Name = "dgrid_unidades";
            this.dgrid_unidades.ReadOnly = true;
            this.dgrid_unidades.Size = new System.Drawing.Size(800, 450);
            this.dgrid_unidades.TabIndex = 0;
            // 
            // VUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgrid_unidades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VUnidades";
            this.Text = "Unidades";
            this.Load += new System.EventHandler(this.Unidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_unidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrid_unidades;
    }
}