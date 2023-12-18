namespace SIT.Views.RH
{
    partial class VSnack
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
            this.btn_report = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.dgrid_snack = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_snack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_report);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 51);
            this.panel1.TabIndex = 0;
            // 
            // btn_report
            // 
            this.btn_report.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_report.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_report.Location = new System.Drawing.Point(670, 4);
            this.btn_report.Name = "btn_report";
            this.btn_report.Size = new System.Drawing.Size(57, 41);
            this.btn_report.TabIndex = 2;
            this.btn_report.UseVisualStyleBackColor = true;
            this.btn_report.Click += new System.EventHandler(this.btn_report_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(874, 8);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(176, 20);
            this.txt_filtro.TabIndex = 1;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(745, 8);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 0;
            // 
            // dgrid_snack
            // 
            this.dgrid_snack.AllowUserToAddRows = false;
            this.dgrid_snack.AllowUserToDeleteRows = false;
            this.dgrid_snack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_snack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_snack.Location = new System.Drawing.Point(0, 51);
            this.dgrid_snack.Name = "dgrid_snack";
            this.dgrid_snack.ReadOnly = true;
            this.dgrid_snack.Size = new System.Drawing.Size(1056, 399);
            this.dgrid_snack.TabIndex = 1;
            // 
            // VSnack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 450);
            this.Controls.Add(this.dgrid_snack);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VSnack";
            this.ShowIcon = false;
            this.Text = "VSnack";
            this.Load += new System.EventHandler(this.VSnack_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_snack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgrid_snack;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Button btn_report;
    }
}