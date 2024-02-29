namespace SIT.Views.Gerencia.CCotxAutorizar
{
    partial class VCotxAutorizar
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
            this.dgrid_req = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_num_cot = new System.Windows.Forms.Label();
            this.cmb_cotizacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_req = new System.Windows.Forms.Label();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn_rechazar = new System.Windows.Forms.Button();
            this.lbl_proveedor = new System.Windows.Forms.Label();
            this.btn_autorizar = new System.Windows.Forms.Button();
            this.lbl_cu = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_cantidad = new System.Windows.Forms.Label();
            this.lbl_producto = new System.Windows.Forms.Label();
            this.lbl_hora = new System.Windows.Forms.Label();
            this.lbl_empleado = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_req)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgrid_req);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 450);
            this.panel1.TabIndex = 0;
            // 
            // dgrid_req
            // 
            this.dgrid_req.AllowUserToAddRows = false;
            this.dgrid_req.AllowUserToDeleteRows = false;
            this.dgrid_req.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_req.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_req.Location = new System.Drawing.Point(0, 0);
            this.dgrid_req.Name = "dgrid_req";
            this.dgrid_req.ReadOnly = true;
            this.dgrid_req.Size = new System.Drawing.Size(494, 446);
            this.dgrid_req.TabIndex = 0;
            this.dgrid_req.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_req_CellClick);
            this.dgrid_req.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgrid_req_CellFormatting);
            this.dgrid_req.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgrid_req_CellPainting);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Azure;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbl_num_cot);
            this.panel2.Controls.Add(this.cmb_cotizacion);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(498, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(637, 44);
            this.panel2.TabIndex = 1;
            // 
            // lbl_num_cot
            // 
            this.lbl_num_cot.AutoSize = true;
            this.lbl_num_cot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_num_cot.Location = new System.Drawing.Point(4, 7);
            this.lbl_num_cot.Name = "lbl_num_cot";
            this.lbl_num_cot.Size = new System.Drawing.Size(132, 20);
            this.lbl_num_cot.TabIndex = 2;
            this.lbl_num_cot.Text = "#Cotizaciones: ";
            // 
            // cmb_cotizacion
            // 
            this.cmb_cotizacion.FormattingEnabled = true;
            this.cmb_cotizacion.Location = new System.Drawing.Point(502, 10);
            this.cmb_cotizacion.Name = "cmb_cotizacion";
            this.cmb_cotizacion.Size = new System.Drawing.Size(121, 21);
            this.cmb_cotizacion.TabIndex = 1;
            this.cmb_cotizacion.SelectedValueChanged += new System.EventHandler(this.cmb_cotizacion_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(403, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cotización";
            // 
            // lbl_req
            // 
            this.lbl_req.AutoSize = true;
            this.lbl_req.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_req.ForeColor = System.Drawing.Color.White;
            this.lbl_req.Location = new System.Drawing.Point(10, 6);
            this.lbl_req.Name = "lbl_req";
            this.lbl_req.Size = new System.Drawing.Size(63, 20);
            this.lbl_req.TabIndex = 2;
            this.lbl_req.Text = "lbl_req";
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fecha.ForeColor = System.Drawing.Color.White;
            this.lbl_fecha.Location = new System.Drawing.Point(245, 6);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(82, 20);
            this.lbl_fecha.TabIndex = 3;
            this.lbl_fecha.Text = "lbl_fecha";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(498, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(637, 406);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btn_rechazar);
            this.panel5.Controls.Add(this.lbl_proveedor);
            this.panel5.Controls.Add(this.btn_autorizar);
            this.panel5.Controls.Add(this.lbl_cu);
            this.panel5.Controls.Add(this.lbl_total);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 183);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(633, 219);
            this.panel5.TabIndex = 14;
            // 
            // btn_rechazar
            // 
            this.btn_rechazar.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef5841;
            this.btn_rechazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_rechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rechazar.Location = new System.Drawing.Point(358, 139);
            this.btn_rechazar.Name = "btn_rechazar";
            this.btn_rechazar.Size = new System.Drawing.Size(75, 54);
            this.btn_rechazar.TabIndex = 13;
            this.btn_rechazar.UseVisualStyleBackColor = true;
            this.btn_rechazar.Click += new System.EventHandler(this.btn_rechazar_Click);
            // 
            // lbl_proveedor
            // 
            this.lbl_proveedor.AutoSize = true;
            this.lbl_proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_proveedor.Location = new System.Drawing.Point(24, 17);
            this.lbl_proveedor.Name = "lbl_proveedor";
            this.lbl_proveedor.Size = new System.Drawing.Size(117, 20);
            this.lbl_proveedor.TabIndex = 8;
            this.lbl_proveedor.Text = "lbl_proveedor";
            // 
            // btn_autorizar
            // 
            this.btn_autorizar.BackgroundImage = global::SIT.Properties.Resources.check;
            this.btn_autorizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_autorizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_autorizar.Location = new System.Drawing.Point(205, 139);
            this.btn_autorizar.Name = "btn_autorizar";
            this.btn_autorizar.Size = new System.Drawing.Size(75, 54);
            this.btn_autorizar.TabIndex = 12;
            this.btn_autorizar.UseVisualStyleBackColor = true;
            this.btn_autorizar.Click += new System.EventHandler(this.btn_autorizar_Click);
            // 
            // lbl_cu
            // 
            this.lbl_cu.AutoSize = true;
            this.lbl_cu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cu.Location = new System.Drawing.Point(69, 61);
            this.lbl_cu.Name = "lbl_cu";
            this.lbl_cu.Size = new System.Drawing.Size(56, 20);
            this.lbl_cu.TabIndex = 10;
            this.lbl_cu.Text = "lbl_cu";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(360, 61);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(73, 20);
            this.lbl_total.TabIndex = 11;
            this.lbl_total.Text = "lbl_total";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lbl_cantidad);
            this.panel4.Controls.Add(this.lbl_req);
            this.panel4.Controls.Add(this.lbl_fecha);
            this.panel4.Controls.Add(this.lbl_producto);
            this.panel4.Controls.Add(this.lbl_hora);
            this.panel4.Controls.Add(this.lbl_empleado);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(633, 183);
            this.panel4.TabIndex = 9;
            // 
            // lbl_cantidad
            // 
            this.lbl_cantidad.AutoSize = true;
            this.lbl_cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cantidad.ForeColor = System.Drawing.Color.White;
            this.lbl_cantidad.Location = new System.Drawing.Point(12, 128);
            this.lbl_cantidad.Name = "lbl_cantidad";
            this.lbl_cantidad.Size = new System.Drawing.Size(106, 20);
            this.lbl_cantidad.TabIndex = 7;
            this.lbl_cantidad.Text = "lbl_cantidad";
            // 
            // lbl_producto
            // 
            this.lbl_producto.AutoSize = true;
            this.lbl_producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_producto.ForeColor = System.Drawing.Color.White;
            this.lbl_producto.Location = new System.Drawing.Point(10, 92);
            this.lbl_producto.Name = "lbl_producto";
            this.lbl_producto.Size = new System.Drawing.Size(108, 20);
            this.lbl_producto.TabIndex = 6;
            this.lbl_producto.Text = "lbl_producto";
            // 
            // lbl_hora
            // 
            this.lbl_hora.AutoSize = true;
            this.lbl_hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hora.ForeColor = System.Drawing.Color.White;
            this.lbl_hora.Location = new System.Drawing.Point(472, 6);
            this.lbl_hora.Name = "lbl_hora";
            this.lbl_hora.Size = new System.Drawing.Size(73, 20);
            this.lbl_hora.TabIndex = 4;
            this.lbl_hora.Text = "lbl_hora";
            // 
            // lbl_empleado
            // 
            this.lbl_empleado.AutoSize = true;
            this.lbl_empleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_empleado.ForeColor = System.Drawing.Color.White;
            this.lbl_empleado.Location = new System.Drawing.Point(10, 52);
            this.lbl_empleado.Name = "lbl_empleado";
            this.lbl_empleado.Size = new System.Drawing.Size(115, 20);
            this.lbl_empleado.TabIndex = 5;
            this.lbl_empleado.Text = "lbl_empleado";
            // 
            // VCotxAutorizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VCotxAutorizar";
            this.Text = "VCotxAutorizar";
            this.Load += new System.EventHandler(this.VCotxAutorizar_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_req)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgrid_req;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmb_cotizacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_req;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_hora;
        private System.Windows.Forms.Label lbl_cantidad;
        private System.Windows.Forms.Label lbl_producto;
        private System.Windows.Forms.Label lbl_empleado;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label lbl_cu;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_proveedor;
        private System.Windows.Forms.Button btn_rechazar;
        private System.Windows.Forms.Button btn_autorizar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_num_cot;
    }
}