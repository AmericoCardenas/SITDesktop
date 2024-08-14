namespace SIT.Views.Catalogos
{
    partial class VClientes
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
            this.dgrid_clientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrid_clientes
            // 
            this.dgrid_clientes.AllowUserToAddRows = false;
            this.dgrid_clientes.AllowUserToDeleteRows = false;
            this.dgrid_clientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_clientes.Location = new System.Drawing.Point(0, 0);
            this.dgrid_clientes.Name = "dgrid_clientes";
            this.dgrid_clientes.ReadOnly = true;
            this.dgrid_clientes.Size = new System.Drawing.Size(800, 450);
            this.dgrid_clientes.TabIndex = 0;
            // 
            // VClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgrid_clientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VClientes";
            this.ShowIcon = false;
            this.Text = "VClientes";
            this.Load += new System.EventHandler(this.VClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_clientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrid_clientes;
    }
}