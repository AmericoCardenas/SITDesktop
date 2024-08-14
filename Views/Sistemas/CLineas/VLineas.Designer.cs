namespace SIT.Views.Sistemas
{
    partial class VLineas
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
            this.btn_doc = new System.Windows.Forms.Button();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgrid_lineas = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_lineas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_doc);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 54);
            this.panel1.TabIndex = 0;
            // 
            // btn_doc
            // 
            this.btn_doc.BackgroundImage = global::SIT.Properties.Resources.google_docs;
            this.btn_doc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_doc.Location = new System.Drawing.Point(69, 3);
            this.btn_doc.Name = "btn_doc";
            this.btn_doc.Size = new System.Drawing.Size(48, 39);
            this.btn_doc.TabIndex = 14;
            this.btn_doc.UseVisualStyleBackColor = true;
            this.btn_doc.Click += new System.EventHandler(this.btn_doc_Click);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_filtro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(868, 18);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 13;
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(997, 18);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(136, 20);
            this.txt_filtro.TabIndex = 12;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(12, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(48, 39);
            this.btn_add.TabIndex = 6;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgrid_lineas
            // 
            this.dgrid_lineas.AllowUserToAddRows = false;
            this.dgrid_lineas.AllowUserToDeleteRows = false;
            this.dgrid_lineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_lineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_lineas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_lineas.Location = new System.Drawing.Point(0, 0);
            this.dgrid_lineas.Name = "dgrid_lineas";
            this.dgrid_lineas.ReadOnly = true;
            this.dgrid_lineas.Size = new System.Drawing.Size(1143, 392);
            this.dgrid_lineas.TabIndex = 1;
            this.dgrid_lineas.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgrid_lineas_RowPrePaint);
            this.dgrid_lineas.Click += new System.EventHandler(this.dgrid_lineas_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgrid_lineas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 396);
            this.panel2.TabIndex = 2;
            // 
            // VLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VLineas";
            this.Text = "VLineas";
            this.Load += new System.EventHandler(this.VLineas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_lineas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgrid_lineas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Button btn_doc;
    }
}