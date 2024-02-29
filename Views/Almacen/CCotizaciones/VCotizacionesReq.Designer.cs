namespace SIT.Views.Almacen.CCotizaciones
{
    partial class VCotizacionesReq
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
            this.lbl_productoinfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk_iva = new System.Windows.Forms.CheckBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_cu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_proveedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgrid_cotizaciones = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_cotizaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbl_productoinfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 89);
            this.panel1.TabIndex = 0;
            // 
            // lbl_productoinfo
            // 
            this.lbl_productoinfo.AutoSize = true;
            this.lbl_productoinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_productoinfo.ForeColor = System.Drawing.Color.Red;
            this.lbl_productoinfo.Location = new System.Drawing.Point(11, 11);
            this.lbl_productoinfo.Name = "lbl_productoinfo";
            this.lbl_productoinfo.Size = new System.Drawing.Size(138, 20);
            this.lbl_productoinfo.TabIndex = 0;
            this.lbl_productoinfo.Text = "lbl_productoinfo";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.chk_iva);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Controls.Add(this.txt_total);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_cu);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmb_proveedor);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 48);
            this.panel2.TabIndex = 1;
            // 
            // chk_iva
            // 
            this.chk_iva.AutoSize = true;
            this.chk_iva.Enabled = false;
            this.chk_iva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_iva.Location = new System.Drawing.Point(571, 12);
            this.chk_iva.Name = "chk_iva";
            this.chk_iva.Size = new System.Drawing.Size(47, 20);
            this.chk_iva.TabIndex = 8;
            this.chk_iva.Text = "Iva";
            this.chk_iva.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef5841;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(720, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(55, 35);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(659, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(55, 35);
            this.btn_add.TabIndex = 6;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_total
            // 
            this.txt_total.Enabled = false;
            this.txt_total.Location = new System.Drawing.Point(499, 11);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(49, 20);
            this.txt_total.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(450, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total";
            // 
            // txt_cu
            // 
            this.txt_cu.Location = new System.Drawing.Point(390, 10);
            this.txt_cu.Name = "txt_cu";
            this.txt_cu.Size = new System.Drawing.Size(49, 20);
            this.txt_cu.TabIndex = 3;
            this.txt_cu.TextChanged += new System.EventHandler(this.txt_cu_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(278, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Costo Unitario";
            // 
            // cmb_proveedor
            // 
            this.cmb_proveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_proveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_proveedor.FormattingEnabled = true;
            this.cmb_proveedor.Location = new System.Drawing.Point(90, 10);
            this.cmb_proveedor.Name = "cmb_proveedor";
            this.cmb_proveedor.Size = new System.Drawing.Size(181, 21);
            this.cmb_proveedor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Proveedor";
            // 
            // dgrid_cotizaciones
            // 
            this.dgrid_cotizaciones.AllowUserToAddRows = false;
            this.dgrid_cotizaciones.AllowUserToDeleteRows = false;
            this.dgrid_cotizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_cotizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_cotizaciones.Location = new System.Drawing.Point(0, 137);
            this.dgrid_cotizaciones.Name = "dgrid_cotizaciones";
            this.dgrid_cotizaciones.ReadOnly = true;
            this.dgrid_cotizaciones.Size = new System.Drawing.Size(789, 228);
            this.dgrid_cotizaciones.TabIndex = 2;
            this.dgrid_cotizaciones.Click += new System.EventHandler(this.dgrid_cotizaciones_Click);
            // 
            // VCotizacionesReq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(789, 365);
            this.Controls.Add(this.dgrid_cotizaciones);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VCotizacionesReq";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VCotizacionesReq";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VCotizacionesReq_FormClosed);
            this.Load += new System.EventHandler(this.VCotizacionesReq_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_cotizaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrid_cotizaciones;
        private System.Windows.Forms.Label lbl_productoinfo;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_proveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_iva;
    }
}