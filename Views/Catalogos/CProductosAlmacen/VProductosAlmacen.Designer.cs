﻿namespace SIT.Views.Almacen.CProductosAlmacen
{
    partial class VProductosAlmacen
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
            this.btn_historial = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgrid_prods = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_excel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_prods)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.btn_historial);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 49);
            this.panel1.TabIndex = 0;
            // 
            // btn_historial
            // 
            this.btn_historial.BackgroundImage = global::SIT.Properties.Resources.gestion_del_tiempo;
            this.btn_historial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_historial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_historial.Location = new System.Drawing.Point(432, 3);
            this.btn_historial.Name = "btn_historial";
            this.btn_historial.Size = new System.Drawing.Size(48, 39);
            this.btn_historial.TabIndex = 4;
            this.btn_historial.UseVisualStyleBackColor = true;
            this.btn_historial.Click += new System.EventHandler(this.btn_historial_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(716, 11);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(160, 20);
            this.txt_filtro.TabIndex = 3;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(562, 11);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(146, 21);
            this.cmb_filtro.TabIndex = 2;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef5841;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(62, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(48, 39);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(7, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(48, 39);
            this.btn_add.TabIndex = 0;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgrid_prods
            // 
            this.dgrid_prods.AllowUserToAddRows = false;
            this.dgrid_prods.AllowUserToDeleteRows = false;
            this.dgrid_prods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_prods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_prods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_prods.Location = new System.Drawing.Point(0, 0);
            this.dgrid_prods.Name = "dgrid_prods";
            this.dgrid_prods.ReadOnly = true;
            this.dgrid_prods.Size = new System.Drawing.Size(912, 397);
            this.dgrid_prods.TabIndex = 1;
            this.dgrid_prods.Click += new System.EventHandler(this.dgrid_prods_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dgrid_prods);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 401);
            this.panel2.TabIndex = 2;
            // 
            // btn_excel
            // 
            this.btn_excel.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Location = new System.Drawing.Point(508, 4);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(48, 39);
            this.btn_excel.TabIndex = 5;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // VProductosAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VProductosAlmacen";
            this.Text = "AEProductosAlmacen";
            this.Load += new System.EventHandler(this.AEProductosAlmacen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_prods)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgrid_prods;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_historial;
        private System.Windows.Forms.Button btn_excel;
    }
}