namespace SIT.Views.Catalogos.CProductosAlmacen
{
    partial class AEProductosAlmacen
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
            this.txt_codinterno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_stock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_exmin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_exmax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_medida = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_almacen = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_zona = new System.Windows.Forms.ComboBox();
            this.rd_activo = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.rd_inactivo = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_anaquel = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_pasillo = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Interno";
            // 
            // txt_codinterno
            // 
            this.txt_codinterno.Location = new System.Drawing.Point(160, 6);
            this.txt_codinterno.Margin = new System.Windows.Forms.Padding(4);
            this.txt_codinterno.Name = "txt_codinterno";
            this.txt_codinterno.Size = new System.Drawing.Size(148, 22);
            this.txt_codinterno.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(395, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(465, 6);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(148, 22);
            this.txt_nombre.TabIndex = 2;
            // 
            // txt_stock
            // 
            this.txt_stock.Location = new System.Drawing.Point(160, 36);
            this.txt_stock.Margin = new System.Windows.Forms.Padding(4);
            this.txt_stock.Name = "txt_stock";
            this.txt_stock.Size = new System.Drawing.Size(148, 22);
            this.txt_stock.TabIndex = 3;
            this.txt_stock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_stock_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stock";
            // 
            // txt_exmin
            // 
            this.txt_exmin.Location = new System.Drawing.Point(465, 38);
            this.txt_exmin.Margin = new System.Windows.Forms.Padding(4);
            this.txt_exmin.Name = "txt_exmin";
            this.txt_exmin.Size = new System.Drawing.Size(148, 22);
            this.txt_exmin.TabIndex = 4;
            this.txt_exmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_exmin_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(325, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Existencia Minima";
            // 
            // txt_exmax
            // 
            this.txt_exmax.Location = new System.Drawing.Point(160, 66);
            this.txt_exmax.Margin = new System.Windows.Forms.Padding(4);
            this.txt_exmax.Name = "txt_exmax";
            this.txt_exmax.Size = new System.Drawing.Size(148, 22);
            this.txt_exmax.TabIndex = 5;
            this.txt_exmax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_exmax_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Existencia Maxima";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(388, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Medida";
            // 
            // cmb_medida
            // 
            this.cmb_medida.FormattingEnabled = true;
            this.cmb_medida.Location = new System.Drawing.Point(465, 64);
            this.cmb_medida.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_medida.Name = "cmb_medida";
            this.cmb_medida.Size = new System.Drawing.Size(148, 24);
            this.cmb_medida.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(75, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Almacen";
            // 
            // cmb_almacen
            // 
            this.cmb_almacen.FormattingEnabled = true;
            this.cmb_almacen.Location = new System.Drawing.Point(160, 96);
            this.cmb_almacen.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_almacen.Name = "cmb_almacen";
            this.cmb_almacen.Size = new System.Drawing.Size(148, 24);
            this.cmb_almacen.TabIndex = 7;
            this.cmb_almacen.SelectedIndexChanged += new System.EventHandler(this.cmb__almacen_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(405, 104);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Zona";
            // 
            // cmb_zona
            // 
            this.cmb_zona.FormattingEnabled = true;
            this.cmb_zona.Location = new System.Drawing.Point(465, 96);
            this.cmb_zona.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_zona.Name = "cmb_zona";
            this.cmb_zona.Size = new System.Drawing.Size(148, 24);
            this.cmb_zona.TabIndex = 8;
            // 
            // rd_activo
            // 
            this.rd_activo.AutoSize = true;
            this.rd_activo.Location = new System.Drawing.Point(162, 154);
            this.rd_activo.Margin = new System.Windows.Forms.Padding(4);
            this.rd_activo.Name = "rd_activo";
            this.rd_activo.Size = new System.Drawing.Size(68, 20);
            this.rd_activo.TabIndex = 11;
            this.rd_activo.TabStop = true;
            this.rd_activo.Text = "Activo";
            this.rd_activo.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(92, 154);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Estatus";
            // 
            // rd_inactivo
            // 
            this.rd_inactivo.AutoSize = true;
            this.rd_inactivo.Location = new System.Drawing.Point(238, 154);
            this.rd_inactivo.Margin = new System.Windows.Forms.Padding(4);
            this.rd_inactivo.Name = "rd_inactivo";
            this.rd_inactivo.Size = new System.Drawing.Size(79, 20);
            this.rd_inactivo.TabIndex = 12;
            this.rd_inactivo.TabStop = true;
            this.rd_inactivo.Text = "Inactivo";
            this.rd_inactivo.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(383, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Anaquel";
            // 
            // txt_anaquel
            // 
            this.txt_anaquel.Location = new System.Drawing.Point(465, 127);
            this.txt_anaquel.Margin = new System.Windows.Forms.Padding(4);
            this.txt_anaquel.Name = "txt_anaquel";
            this.txt_anaquel.Size = new System.Drawing.Size(148, 22);
            this.txt_anaquel.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Pasillo";
            // 
            // txt_pasillo
            // 
            this.txt_pasillo.Location = new System.Drawing.Point(160, 124);
            this.txt_pasillo.Margin = new System.Windows.Forms.Padding(4);
            this.txt_pasillo.Name = "txt_pasillo";
            this.txt_pasillo.Size = new System.Drawing.Size(148, 22);
            this.txt_pasillo.TabIndex = 9;
            this.txt_pasillo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pasillo_KeyPress);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.check;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(536, 155);
            this.btn_add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(63, 51);
            this.btn_add.TabIndex = 13;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // AEProductosAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(622, 211);
            this.Controls.Add(this.txt_pasillo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_anaquel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.rd_inactivo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rd_activo);
            this.Controls.Add(this.cmb_zona);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_almacen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_medida);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_exmax);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_exmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_stock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_codinterno);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AEProductosAlmacen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductosAlmacen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AEProductosAlmacen_FormClosed);
            this.Load += new System.EventHandler(this.AEProductosAlmacen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_codinterno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_stock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_exmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_exmax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_medida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_almacen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_zona;
        private System.Windows.Forms.RadioButton rd_activo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rd_inactivo;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_anaquel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_pasillo;
    }
}