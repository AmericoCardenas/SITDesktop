namespace SIT.Views.Almacen.COrdenesCompra
{
    partial class VOrdenesCompra
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
            this.btn_autcot = new System.Windows.Forms.Button();
            this.btn_canoc = new System.Windows.Forms.Button();
            this.btn_factxml = new System.Windows.Forms.Button();
            this.btn_cotizacionglobal = new System.Windows.Forms.Button();
            this.btn_entrada = new System.Windows.Forms.Button();
            this.btn_pagaroc = new System.Windows.Forms.Button();
            this.btn_pdf = new System.Windows.Forms.Button();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.btn_oc = new System.Windows.Forms.Button();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_rpendientes = new System.Windows.Forms.TabPage();
            this.dgrid_reqpendientes = new System.Windows.Forms.DataGridView();
            this.tb_reqaut = new System.Windows.Forms.TabPage();
            this.dgrid_reqautorizadas = new System.Windows.Forms.DataGridView();
            this.tb_ocpe = new System.Windows.Forms.TabPage();
            this.dgrid_oc = new System.Windows.Forms.DataGridView();
            this.tb_ocpag = new System.Windows.Forms.TabPage();
            this.dgrid_ocpagadas = new System.Windows.Forms.DataGridView();
            this.tb_ocsurt = new System.Windows.Forms.TabPage();
            this.dgrid_ocsurtidas = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_rpendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_reqpendientes)).BeginInit();
            this.tb_reqaut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_reqautorizadas)).BeginInit();
            this.tb_ocpe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_oc)).BeginInit();
            this.tb_ocpag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ocpagadas)).BeginInit();
            this.tb_ocsurt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ocsurtidas)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btn_autcot);
            this.panel1.Controls.Add(this.btn_canoc);
            this.panel1.Controls.Add(this.btn_factxml);
            this.panel1.Controls.Add(this.btn_cotizacionglobal);
            this.panel1.Controls.Add(this.btn_entrada);
            this.panel1.Controls.Add(this.btn_pagaroc);
            this.panel1.Controls.Add(this.btn_pdf);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_oc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 50);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_autcot
            // 
            this.btn_autcot.BackgroundImage = global::SIT.Properties.Resources.check;
            this.btn_autcot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_autcot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_autcot.Location = new System.Drawing.Point(342, 3);
            this.btn_autcot.Name = "btn_autcot";
            this.btn_autcot.Size = new System.Drawing.Size(48, 39);
            this.btn_autcot.TabIndex = 9;
            this.btn_autcot.UseVisualStyleBackColor = true;
            this.btn_autcot.Click += new System.EventHandler(this.btn_autcot_Click);
            // 
            // btn_canoc
            // 
            this.btn_canoc.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef5841;
            this.btn_canoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_canoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_canoc.Location = new System.Drawing.Point(286, 3);
            this.btn_canoc.Name = "btn_canoc";
            this.btn_canoc.Size = new System.Drawing.Size(48, 39);
            this.btn_canoc.TabIndex = 8;
            this.btn_canoc.UseVisualStyleBackColor = true;
            this.btn_canoc.Visible = false;
            this.btn_canoc.Click += new System.EventHandler(this.btn_canoc_Click);
            // 
            // btn_factxml
            // 
            this.btn_factxml.BackgroundImage = global::SIT.Properties.Resources.factura;
            this.btn_factxml.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_factxml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_factxml.Location = new System.Drawing.Point(231, 3);
            this.btn_factxml.Name = "btn_factxml";
            this.btn_factxml.Size = new System.Drawing.Size(48, 39);
            this.btn_factxml.TabIndex = 7;
            this.btn_factxml.UseVisualStyleBackColor = true;
            this.btn_factxml.Click += new System.EventHandler(this.btn_factxml_Click);
            // 
            // btn_cotizacionglobal
            // 
            this.btn_cotizacionglobal.BackgroundImage = global::SIT.Properties.Resources.coti;
            this.btn_cotizacionglobal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cotizacionglobal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cotizacionglobal.Location = new System.Drawing.Point(15, 3);
            this.btn_cotizacionglobal.Name = "btn_cotizacionglobal";
            this.btn_cotizacionglobal.Size = new System.Drawing.Size(48, 39);
            this.btn_cotizacionglobal.TabIndex = 6;
            this.btn_cotizacionglobal.UseVisualStyleBackColor = true;
            this.btn_cotizacionglobal.Click += new System.EventHandler(this.btn_cotizacionglobal_Click);
            // 
            // btn_entrada
            // 
            this.btn_entrada.BackgroundImage = global::SIT.Properties.Resources.bandeja_de_entrada;
            this.btn_entrada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_entrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_entrada.Location = new System.Drawing.Point(176, 3);
            this.btn_entrada.Name = "btn_entrada";
            this.btn_entrada.Size = new System.Drawing.Size(48, 39);
            this.btn_entrada.TabIndex = 5;
            this.btn_entrada.UseVisualStyleBackColor = true;
            this.btn_entrada.Click += new System.EventHandler(this.btn_entrada_Click);
            // 
            // btn_pagaroc
            // 
            this.btn_pagaroc.BackgroundImage = global::SIT.Properties.Resources.money;
            this.btn_pagaroc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_pagaroc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pagaroc.Location = new System.Drawing.Point(121, 3);
            this.btn_pagaroc.Name = "btn_pagaroc";
            this.btn_pagaroc.Size = new System.Drawing.Size(48, 39);
            this.btn_pagaroc.TabIndex = 4;
            this.btn_pagaroc.UseVisualStyleBackColor = true;
            this.btn_pagaroc.Click += new System.EventHandler(this.btn_pagaroc_Click);
            // 
            // btn_pdf
            // 
            this.btn_pdf.BackgroundImage = global::SIT.Properties.Resources.pdf;
            this.btn_pdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_pdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pdf.Location = new System.Drawing.Point(67, 3);
            this.btn_pdf.Name = "btn_pdf";
            this.btn_pdf.Size = new System.Drawing.Size(48, 39);
            this.btn_pdf.TabIndex = 3;
            this.btn_pdf.UseVisualStyleBackColor = true;
            this.btn_pdf.Click += new System.EventHandler(this.btn_pdf_Click);
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(650, 13);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(141, 20);
            this.txt_filtro.TabIndex = 2;
            this.txt_filtro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(523, 12);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 1;
            this.cmb_filtro.SelectedIndexChanged += new System.EventHandler(this.cmb_filtro_SelectedIndexChanged);
            // 
            // btn_oc
            // 
            this.btn_oc.BackgroundImage = global::SIT.Properties.Resources.oc;
            this.btn_oc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_oc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_oc.Location = new System.Drawing.Point(7, 2);
            this.btn_oc.Name = "btn_oc";
            this.btn_oc.Size = new System.Drawing.Size(48, 39);
            this.btn_oc.TabIndex = 0;
            this.btn_oc.UseVisualStyleBackColor = true;
            this.btn_oc.Click += new System.EventHandler(this.btn_oc_Click);
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_rpendientes);
            this.tbcontrol.Controls.Add(this.tb_reqaut);
            this.tbcontrol.Controls.Add(this.tb_ocpe);
            this.tbcontrol.Controls.Add(this.tb_ocpag);
            this.tbcontrol.Controls.Add(this.tb_ocsurt);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(796, 372);
            this.tbcontrol.TabIndex = 1;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_rpendientes
            // 
            this.tb_rpendientes.Controls.Add(this.dgrid_reqpendientes);
            this.tb_rpendientes.Location = new System.Drawing.Point(4, 22);
            this.tb_rpendientes.Name = "tb_rpendientes";
            this.tb_rpendientes.Padding = new System.Windows.Forms.Padding(3);
            this.tb_rpendientes.Size = new System.Drawing.Size(788, 346);
            this.tb_rpendientes.TabIndex = 2;
            this.tb_rpendientes.Text = "C.Pendientes";
            this.tb_rpendientes.UseVisualStyleBackColor = true;
            this.tb_rpendientes.Click += new System.EventHandler(this.tb_rpendientes_Click);
            // 
            // dgrid_reqpendientes
            // 
            this.dgrid_reqpendientes.AllowUserToAddRows = false;
            this.dgrid_reqpendientes.AllowUserToDeleteRows = false;
            this.dgrid_reqpendientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_reqpendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_reqpendientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_reqpendientes.Location = new System.Drawing.Point(3, 3);
            this.dgrid_reqpendientes.Name = "dgrid_reqpendientes";
            this.dgrid_reqpendientes.ReadOnly = true;
            this.dgrid_reqpendientes.Size = new System.Drawing.Size(782, 340);
            this.dgrid_reqpendientes.TabIndex = 0;
            this.dgrid_reqpendientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_reqpendientes_CellContentClick);
            this.dgrid_reqpendientes.Click += new System.EventHandler(this.dgrid_reqpendientes_Click);
            // 
            // tb_reqaut
            // 
            this.tb_reqaut.Controls.Add(this.dgrid_reqautorizadas);
            this.tb_reqaut.Location = new System.Drawing.Point(4, 22);
            this.tb_reqaut.Name = "tb_reqaut";
            this.tb_reqaut.Padding = new System.Windows.Forms.Padding(3);
            this.tb_reqaut.Size = new System.Drawing.Size(788, 346);
            this.tb_reqaut.TabIndex = 0;
            this.tb_reqaut.Text = "C.Autorizadas";
            this.tb_reqaut.UseVisualStyleBackColor = true;
            this.tb_reqaut.Click += new System.EventHandler(this.tb_reqaut_Click);
            // 
            // dgrid_reqautorizadas
            // 
            this.dgrid_reqautorizadas.AllowUserToAddRows = false;
            this.dgrid_reqautorizadas.AllowUserToDeleteRows = false;
            this.dgrid_reqautorizadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_reqautorizadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_reqautorizadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_reqautorizadas.Location = new System.Drawing.Point(3, 3);
            this.dgrid_reqautorizadas.Name = "dgrid_reqautorizadas";
            this.dgrid_reqautorizadas.ReadOnly = true;
            this.dgrid_reqautorizadas.Size = new System.Drawing.Size(782, 340);
            this.dgrid_reqautorizadas.TabIndex = 0;
            this.dgrid_reqautorizadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_reqautorizadas_CellContentClick);
            // 
            // tb_ocpe
            // 
            this.tb_ocpe.Controls.Add(this.dgrid_oc);
            this.tb_ocpe.Location = new System.Drawing.Point(4, 22);
            this.tb_ocpe.Name = "tb_ocpe";
            this.tb_ocpe.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ocpe.Size = new System.Drawing.Size(788, 346);
            this.tb_ocpe.TabIndex = 1;
            this.tb_ocpe.Text = "OC.Pendientes";
            this.tb_ocpe.UseVisualStyleBackColor = true;
            this.tb_ocpe.Click += new System.EventHandler(this.tb_ocpe_Click);
            // 
            // dgrid_oc
            // 
            this.dgrid_oc.AllowUserToAddRows = false;
            this.dgrid_oc.AllowUserToDeleteRows = false;
            this.dgrid_oc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_oc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_oc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_oc.Location = new System.Drawing.Point(3, 3);
            this.dgrid_oc.Name = "dgrid_oc";
            this.dgrid_oc.ReadOnly = true;
            this.dgrid_oc.Size = new System.Drawing.Size(782, 340);
            this.dgrid_oc.TabIndex = 0;
            this.dgrid_oc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_oc_CellContentClick);
            this.dgrid_oc.Click += new System.EventHandler(this.dgrid_oc_Click);
            // 
            // tb_ocpag
            // 
            this.tb_ocpag.Controls.Add(this.dgrid_ocpagadas);
            this.tb_ocpag.Location = new System.Drawing.Point(4, 22);
            this.tb_ocpag.Name = "tb_ocpag";
            this.tb_ocpag.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ocpag.Size = new System.Drawing.Size(788, 346);
            this.tb_ocpag.TabIndex = 3;
            this.tb_ocpag.Text = "OC.Pagadas";
            this.tb_ocpag.UseVisualStyleBackColor = true;
            this.tb_ocpag.Click += new System.EventHandler(this.tb_ocpag_Click);
            // 
            // dgrid_ocpagadas
            // 
            this.dgrid_ocpagadas.AllowUserToAddRows = false;
            this.dgrid_ocpagadas.AllowUserToDeleteRows = false;
            this.dgrid_ocpagadas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_ocpagadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_ocpagadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_ocpagadas.Location = new System.Drawing.Point(3, 3);
            this.dgrid_ocpagadas.Name = "dgrid_ocpagadas";
            this.dgrid_ocpagadas.ReadOnly = true;
            this.dgrid_ocpagadas.Size = new System.Drawing.Size(782, 340);
            this.dgrid_ocpagadas.TabIndex = 0;
            this.dgrid_ocpagadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_ocpagadas_CellContentClick);
            this.dgrid_ocpagadas.Click += new System.EventHandler(this.dgrid_ocpagadas_Click);
            // 
            // tb_ocsurt
            // 
            this.tb_ocsurt.Controls.Add(this.dgrid_ocsurtidas);
            this.tb_ocsurt.Location = new System.Drawing.Point(4, 22);
            this.tb_ocsurt.Name = "tb_ocsurt";
            this.tb_ocsurt.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ocsurt.Size = new System.Drawing.Size(788, 346);
            this.tb_ocsurt.TabIndex = 4;
            this.tb_ocsurt.Text = "OC.Surtidas";
            this.tb_ocsurt.UseVisualStyleBackColor = true;
            this.tb_ocsurt.Click += new System.EventHandler(this.tb_ocsurt_Click);
            // 
            // dgrid_ocsurtidas
            // 
            this.dgrid_ocsurtidas.AllowUserToAddRows = false;
            this.dgrid_ocsurtidas.AllowUserToDeleteRows = false;
            this.dgrid_ocsurtidas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgrid_ocsurtidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_ocsurtidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_ocsurtidas.Location = new System.Drawing.Point(3, 3);
            this.dgrid_ocsurtidas.Name = "dgrid_ocsurtidas";
            this.dgrid_ocsurtidas.ReadOnly = true;
            this.dgrid_ocsurtidas.Size = new System.Drawing.Size(782, 340);
            this.dgrid_ocsurtidas.TabIndex = 0;
            this.dgrid_ocsurtidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_ocsurtidas_CellContentClick);
            this.dgrid_ocsurtidas.Click += new System.EventHandler(this.dgrid_ocsurtidas_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_total);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 35);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(615, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.ForeColor = System.Drawing.Color.Red;
            this.lbl_total.Location = new System.Drawing.Point(677, 2);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(60, 24);
            this.lbl_total.TabIndex = 0;
            this.lbl_total.Text = "$0.00";
            this.lbl_total.Click += new System.EventHandler(this.lbl_total_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.tbcontrol);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 376);
            this.panel3.TabIndex = 3;
            // 
            // VOrdenesCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VOrdenesCompra";
            this.Text = "VOrdenesCompra";
            this.Load += new System.EventHandler(this.VOrdenesCompra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbcontrol.ResumeLayout(false);
            this.tb_rpendientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_reqpendientes)).EndInit();
            this.tb_reqaut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_reqautorizadas)).EndInit();
            this.tb_ocpe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_oc)).EndInit();
            this.tb_ocpag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ocpagadas)).EndInit();
            this.tb_ocsurt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ocsurtidas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_reqaut;
        private System.Windows.Forms.TabPage tb_ocpe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_oc;
        private System.Windows.Forms.DataGridView dgrid_reqautorizadas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.DataGridView dgrid_oc;
        private System.Windows.Forms.Button btn_pdf;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Button btn_pagaroc;
        private System.Windows.Forms.Button btn_entrada;
        private System.Windows.Forms.TabPage tb_rpendientes;
        private System.Windows.Forms.Button btn_cotizacionglobal;
        private System.Windows.Forms.DataGridView dgrid_reqpendientes;
        private System.Windows.Forms.Button btn_factxml;
        private System.Windows.Forms.TabPage tb_ocpag;
        private System.Windows.Forms.DataGridView dgrid_ocpagadas;
        private System.Windows.Forms.TabPage tb_ocsurt;
        private System.Windows.Forms.DataGridView dgrid_ocsurtidas;
        private System.Windows.Forms.Button btn_canoc;
        private System.Windows.Forms.Button btn_autcot;
        private System.Windows.Forms.Panel panel3;
    }
}