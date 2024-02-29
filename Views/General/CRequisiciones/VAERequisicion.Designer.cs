namespace SIT.Views.General.CRequisiciones
{
    partial class VAERequisicion
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
            this.txt_numreq = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_empleado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtm_fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_hora = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_codprod = new System.Windows.Forms.TextBox();
            this.lbl_cod = new System.Windows.Forms.Label();
            this.btn_cotizar = new System.Windows.Forms.Button();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.lbl_descripcion = new System.Windows.Forms.Label();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_producto = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgrid_detalleproductos = new System.Windows.Forms.DataGridView();
            this.btn_acept = new System.Windows.Forms.Button();
            this.txt_obsreq = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_detalleproductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Requisicion";
            // 
            // txt_numreq
            // 
            this.txt_numreq.Enabled = false;
            this.txt_numreq.Location = new System.Drawing.Point(120, 9);
            this.txt_numreq.Name = "txt_numreq";
            this.txt_numreq.Size = new System.Drawing.Size(100, 20);
            this.txt_numreq.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(231, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empleado";
            // 
            // cmb_empleado
            // 
            this.cmb_empleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_empleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_empleado.FormattingEnabled = true;
            this.cmb_empleado.Location = new System.Drawing.Point(326, 8);
            this.cmb_empleado.Name = "cmb_empleado";
            this.cmb_empleado.Size = new System.Drawing.Size(175, 21);
            this.cmb_empleado.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(534, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(752, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hora";
            // 
            // dtm_fecha
            // 
            this.dtm_fecha.Location = new System.Drawing.Point(599, 8);
            this.dtm_fecha.Name = "dtm_fecha";
            this.dtm_fecha.Size = new System.Drawing.Size(121, 20);
            this.dtm_fecha.TabIndex = 6;
            // 
            // txt_hora
            // 
            this.txt_hora.Location = new System.Drawing.Point(806, 8);
            this.txt_hora.MaxLength = 5;
            this.txt_hora.Name = "txt_hora";
            this.txt_hora.Size = new System.Drawing.Size(100, 20);
            this.txt_hora.TabIndex = 7;
            this.txt_hora.Text = "00:00";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txt_numreq);
            this.panel1.Controls.Add(this.txt_hora);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtm_fecha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmb_empleado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 43);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txt_codprod);
            this.panel2.Controls.Add(this.lbl_cod);
            this.panel2.Controls.Add(this.btn_cotizar);
            this.panel2.Controls.Add(this.txt_descripcion);
            this.panel2.Controls.Add(this.lbl_descripcion);
            this.panel2.Controls.Add(this.btn_cancel);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Controls.Add(this.txt_cantidad);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cmb_producto);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1056, 63);
            this.panel2.TabIndex = 9;
            // 
            // txt_codprod
            // 
            this.txt_codprod.Location = new System.Drawing.Point(51, 7);
            this.txt_codprod.Name = "txt_codprod";
            this.txt_codprod.Size = new System.Drawing.Size(89, 20);
            this.txt_codprod.TabIndex = 10;
            this.txt_codprod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_codprod_KeyPress);
            // 
            // lbl_cod
            // 
            this.lbl_cod.AutoSize = true;
            this.lbl_cod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cod.Location = new System.Drawing.Point(3, 8);
            this.lbl_cod.Name = "lbl_cod";
            this.lbl_cod.Size = new System.Drawing.Size(41, 20);
            this.lbl_cod.TabIndex = 9;
            this.lbl_cod.Text = "Cod";
            // 
            // btn_cotizar
            // 
            this.btn_cotizar.BackgroundImage = global::SIT.Properties.Resources.cotizar;
            this.btn_cotizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cotizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cotizar.Location = new System.Drawing.Point(990, -2);
            this.btn_cotizar.Name = "btn_cotizar";
            this.btn_cotizar.Size = new System.Drawing.Size(56, 39);
            this.btn_cotizar.TabIndex = 8;
            this.btn_cotizar.UseVisualStyleBackColor = true;
            this.btn_cotizar.Click += new System.EventHandler(this.btn_cotizar_Click);
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(259, 7);
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(333, 20);
            this.txt_descripcion.TabIndex = 7;
            // 
            // lbl_descripcion
            // 
            this.lbl_descripcion.AutoSize = true;
            this.lbl_descripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_descripcion.Location = new System.Drawing.Point(150, 8);
            this.lbl_descripcion.Name = "lbl_descripcion";
            this.lbl_descripcion.Size = new System.Drawing.Size(103, 20);
            this.lbl_descripcion.TabIndex = 6;
            this.lbl_descripcion.Text = "Descripción";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef5841;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(929, -2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(56, 39);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(867, -2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(56, 39);
            this.btn_add.TabIndex = 4;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(687, 8);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(49, 20);
            this.txt_cantidad.TabIndex = 3;
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cantidad_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(600, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cantidad";
            // 
            // cmb_producto
            // 
            this.cmb_producto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_producto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_producto.FormattingEnabled = true;
            this.cmb_producto.Location = new System.Drawing.Point(259, 7);
            this.cmb_producto.Name = "cmb_producto";
            this.cmb_producto.Size = new System.Drawing.Size(333, 21);
            this.cmb_producto.TabIndex = 1;
            this.cmb_producto.SelectedValueChanged += new System.EventHandler(this.cmb_producto_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(168, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Producto";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgrid_detalleproductos);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1056, 290);
            this.panel3.TabIndex = 10;
            // 
            // dgrid_detalleproductos
            // 
            this.dgrid_detalleproductos.AllowUserToAddRows = false;
            this.dgrid_detalleproductos.AllowUserToDeleteRows = false;
            this.dgrid_detalleproductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_detalleproductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_detalleproductos.Location = new System.Drawing.Point(0, 0);
            this.dgrid_detalleproductos.Name = "dgrid_detalleproductos";
            this.dgrid_detalleproductos.ReadOnly = true;
            this.dgrid_detalleproductos.Size = new System.Drawing.Size(1056, 290);
            this.dgrid_detalleproductos.TabIndex = 0;
            this.dgrid_detalleproductos.Click += new System.EventHandler(this.dgrid_detalleproductos_Click);
            // 
            // btn_acept
            // 
            this.btn_acept.BackgroundImage = global::SIT.Properties.Resources.check;
            this.btn_acept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_acept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_acept.Location = new System.Drawing.Point(846, 403);
            this.btn_acept.Name = "btn_acept";
            this.btn_acept.Size = new System.Drawing.Size(62, 56);
            this.btn_acept.TabIndex = 11;
            this.btn_acept.UseVisualStyleBackColor = true;
            this.btn_acept.Click += new System.EventHandler(this.btn_acept_Click);
            // 
            // txt_obsreq
            // 
            this.txt_obsreq.Location = new System.Drawing.Point(156, 403);
            this.txt_obsreq.Name = "txt_obsreq";
            this.txt_obsreq.Size = new System.Drawing.Size(672, 20);
            this.txt_obsreq.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 403);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Observaciones";
            // 
            // VAERequisicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1056, 465);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_obsreq);
            this.Controls.Add(this.btn_acept);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VAERequisicion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisicion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VAERequisicion_FormClosed);
            this.Load += new System.EventHandler(this.VAERequisicion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_detalleproductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_numreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_empleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtm_fecha;
        private System.Windows.Forms.TextBox txt_hora;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_producto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgrid_detalleproductos;
        private System.Windows.Forms.Button btn_acept;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.Label lbl_descripcion;
        private System.Windows.Forms.Button btn_cotizar;
        private System.Windows.Forms.TextBox txt_codprod;
        private System.Windows.Forms.Label lbl_cod;
        private System.Windows.Forms.TextBox txt_obsreq;
        private System.Windows.Forms.Label label9;
    }
}