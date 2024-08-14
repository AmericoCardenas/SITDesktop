namespace SIT.Views.Sistemas
{
    partial class VEquiposMovil
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
            this.dgrid_eqmov = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_doc = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_eqmov)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgrid_eqmov
            // 
            this.dgrid_eqmov.AllowUserToAddRows = false;
            this.dgrid_eqmov.AllowUserToDeleteRows = false;
            this.dgrid_eqmov.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_eqmov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_eqmov.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_eqmov.Location = new System.Drawing.Point(0, 0);
            this.dgrid_eqmov.Name = "dgrid_eqmov";
            this.dgrid_eqmov.ReadOnly = true;
            this.dgrid_eqmov.Size = new System.Drawing.Size(1180, 393);
            this.dgrid_eqmov.TabIndex = 0;
            this.dgrid_eqmov.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgrid_eqmov_RowPrePaint);
            this.dgrid_eqmov.Click += new System.EventHandler(this.dgrid_eqmov_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btn_doc);
            this.panel3.Controls.Add(this.txt_filtro);
            this.panel3.Controls.Add(this.btn_add);
            this.panel3.Controls.Add(this.cmb_filtro);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1184, 53);
            this.panel3.TabIndex = 32;
            // 
            // btn_doc
            // 
            this.btn_doc.BackgroundImage = global::SIT.Properties.Resources.google_docs;
            this.btn_doc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_doc.Location = new System.Drawing.Point(61, 3);
            this.btn_doc.Name = "btn_doc";
            this.btn_doc.Size = new System.Drawing.Size(48, 39);
            this.btn_doc.TabIndex = 31;
            this.btn_doc.UseVisualStyleBackColor = true;
            this.btn_doc.Click += new System.EventHandler(this.btn_doc_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(957, 10);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(180, 20);
            this.txt_filtro.TabIndex = 30;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(7, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(48, 39);
            this.btn_add.TabIndex = 26;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(830, 9);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgrid_eqmov);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 397);
            this.panel1.TabIndex = 0;
            // 
            // VEquiposMovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1184, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VEquiposMovil";
            this.Text = "VEquiposMovil";
            this.Load += new System.EventHandler(this.VEquiposMovil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_eqmov)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgrid_eqmov;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_doc;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Panel panel1;
    }
}