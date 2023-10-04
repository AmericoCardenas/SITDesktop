namespace SIT.Views.Catalogos
{
    partial class VRutas
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
            this.btn_bitacora = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.gpbx = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_psalida = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_pentrada = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_codbitad = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_hora = new System.Windows.Forms.TextBox();
            this.dtm_fecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_turno = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_servicio = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_ruta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_cliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_operador = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_unidad = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.dtm_final = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtm_inicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgrid_rutas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gpbx.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_rutas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_bitacora);
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.gpbx);
            this.panel1.Controls.Add(this.btn_refresh);
            this.panel1.Controls.Add(this.dtm_final);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtm_inicio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1127, 150);
            this.panel1.TabIndex = 1;
            // 
            // btn_bitacora
            // 
            this.btn_bitacora.BackgroundImage = global::SIT.Properties.Resources.cuaderno;
            this.btn_bitacora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_bitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bitacora.Location = new System.Drawing.Point(428, 5);
            this.btn_bitacora.Name = "btn_bitacora";
            this.btn_bitacora.Size = new System.Drawing.Size(39, 38);
            this.btn_bitacora.TabIndex = 7;
            this.btn_bitacora.UseVisualStyleBackColor = true;
            this.btn_bitacora.Click += new System.EventHandler(this.btn_bitacora_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Location = new System.Drawing.Point(379, 6);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(39, 38);
            this.btn_excel.TabIndex = 6;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // gpbx
            // 
            this.gpbx.BackColor = System.Drawing.Color.White;
            this.gpbx.Controls.Add(this.label13);
            this.gpbx.Controls.Add(this.txt_psalida);
            this.gpbx.Controls.Add(this.label12);
            this.gpbx.Controls.Add(this.txt_pentrada);
            this.gpbx.Controls.Add(this.label11);
            this.gpbx.Controls.Add(this.txt_codbitad);
            this.gpbx.Controls.Add(this.btn_delete);
            this.gpbx.Controls.Add(this.btn_agregar);
            this.gpbx.Controls.Add(this.label10);
            this.gpbx.Controls.Add(this.txt_hora);
            this.gpbx.Controls.Add(this.dtm_fecha);
            this.gpbx.Controls.Add(this.label9);
            this.gpbx.Controls.Add(this.cmb_turno);
            this.gpbx.Controls.Add(this.label8);
            this.gpbx.Controls.Add(this.cmb_servicio);
            this.gpbx.Controls.Add(this.label7);
            this.gpbx.Controls.Add(this.cmb_ruta);
            this.gpbx.Controls.Add(this.label6);
            this.gpbx.Controls.Add(this.cmb_cliente);
            this.gpbx.Controls.Add(this.label5);
            this.gpbx.Controls.Add(this.cmb_operador);
            this.gpbx.Controls.Add(this.label4);
            this.gpbx.Controls.Add(this.cmb_unidad);
            this.gpbx.Controls.Add(this.label3);
            this.gpbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbx.ForeColor = System.Drawing.Color.Black;
            this.gpbx.Location = new System.Drawing.Point(3, 43);
            this.gpbx.Name = "gpbx";
            this.gpbx.Size = new System.Drawing.Size(1213, 100);
            this.gpbx.TabIndex = 5;
            this.gpbx.TabStop = false;
            this.gpbx.Text = "Capturar Ruta";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(347, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "P.Salida";
            // 
            // txt_psalida
            // 
            this.txt_psalida.Location = new System.Drawing.Point(350, 72);
            this.txt_psalida.Name = "txt_psalida";
            this.txt_psalida.Size = new System.Drawing.Size(51, 20);
            this.txt_psalida.TabIndex = 23;
            this.txt_psalida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_psalida_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(282, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "P.Entrada";
            // 
            // txt_pentrada
            // 
            this.txt_pentrada.Location = new System.Drawing.Point(285, 72);
            this.txt_pentrada.Name = "txt_pentrada";
            this.txt_pentrada.Size = new System.Drawing.Size(51, 20);
            this.txt_pentrada.TabIndex = 21;
            this.txt_pentrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pentrada_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(219, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "CodBitad";
            // 
            // txt_codbitad
            // 
            this.txt_codbitad.Location = new System.Drawing.Point(222, 72);
            this.txt_codbitad.Name = "txt_codbitad";
            this.txt_codbitad.Size = new System.Drawing.Size(51, 20);
            this.txt_codbitad.TabIndex = 19;
            // 
            // btn_delete
            // 
            this.btn_delete.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Location = new System.Drawing.Point(1056, 11);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(47, 39);
            this.btn_delete.TabIndex = 18;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_agregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_agregar.Location = new System.Drawing.Point(997, 11);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(47, 39);
            this.btn_agregar.TabIndex = 17;
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(168, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Hora";
            // 
            // txt_hora
            // 
            this.txt_hora.Location = new System.Drawing.Point(165, 72);
            this.txt_hora.Name = "txt_hora";
            this.txt_hora.Size = new System.Drawing.Size(51, 20);
            this.txt_hora.TabIndex = 15;
            this.txt_hora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_hora_KeyPress);
            // 
            // dtm_fecha
            // 
            this.dtm_fecha.Location = new System.Drawing.Point(90, 72);
            this.dtm_fecha.Name = "dtm_fecha";
            this.dtm_fecha.Size = new System.Drawing.Size(68, 20);
            this.dtm_fecha.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(95, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Fecha";
            // 
            // cmb_turno
            // 
            this.cmb_turno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_turno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_turno.FormattingEnabled = true;
            this.cmb_turno.Location = new System.Drawing.Point(10, 72);
            this.cmb_turno.Name = "cmb_turno";
            this.cmb_turno.Size = new System.Drawing.Size(66, 21);
            this.cmb_turno.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Turno";
            // 
            // cmb_servicio
            // 
            this.cmb_servicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_servicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_servicio.FormattingEnabled = true;
            this.cmb_servicio.Location = new System.Drawing.Point(885, 31);
            this.cmb_servicio.Name = "cmb_servicio";
            this.cmb_servicio.Size = new System.Drawing.Size(87, 21);
            this.cmb_servicio.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(888, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Servicio";
            // 
            // cmb_ruta
            // 
            this.cmb_ruta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_ruta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_ruta.FormattingEnabled = true;
            this.cmb_ruta.Location = new System.Drawing.Point(600, 31);
            this.cmb_ruta.Name = "cmb_ruta";
            this.cmb_ruta.Size = new System.Drawing.Size(279, 21);
            this.cmb_ruta.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(604, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Ruta";
            // 
            // cmb_cliente
            // 
            this.cmb_cliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_cliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_cliente.FormattingEnabled = true;
            this.cmb_cliente.Location = new System.Drawing.Point(279, 31);
            this.cmb_cliente.Name = "cmb_cliente";
            this.cmb_cliente.Size = new System.Drawing.Size(315, 21);
            this.cmb_cliente.TabIndex = 5;
            this.cmb_cliente.SelectedIndexChanged += new System.EventHandler(this.cmb_cliente_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cliente";
            // 
            // cmb_operador
            // 
            this.cmb_operador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_operador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_operador.FormattingEnabled = true;
            this.cmb_operador.Location = new System.Drawing.Point(74, 31);
            this.cmb_operador.Name = "cmb_operador";
            this.cmb_operador.Size = new System.Drawing.Size(195, 21);
            this.cmb_operador.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Operador";
            // 
            // cmb_unidad
            // 
            this.cmb_unidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_unidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_unidad.FormattingEnabled = true;
            this.cmb_unidad.Location = new System.Drawing.Point(3, 31);
            this.cmb_unidad.Name = "cmb_unidad";
            this.cmb_unidad.Size = new System.Drawing.Size(62, 21);
            this.cmb_unidad.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Unidad";
            // 
            // btn_refresh
            // 
            this.btn_refresh.BackgroundImage = global::SIT.Properties.Resources.boton_actualizar;
            this.btn_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_refresh.Location = new System.Drawing.Point(327, 5);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(39, 38);
            this.btn_refresh.TabIndex = 4;
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // dtm_final
            // 
            this.dtm_final.Location = new System.Drawing.Point(213, 8);
            this.dtm_final.Name = "dtm_final";
            this.dtm_final.Size = new System.Drawing.Size(89, 20);
            this.dtm_final.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "al";
            // 
            // dtm_inicio
            // 
            this.dtm_inicio.Location = new System.Drawing.Point(48, 8);
            this.dtm_inicio.Name = "dtm_inicio";
            this.dtm_inicio.Size = new System.Drawing.Size(98, 20);
            this.dtm_inicio.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Del";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgrid_rutas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1127, 300);
            this.panel2.TabIndex = 2;
            // 
            // dgrid_rutas
            // 
            this.dgrid_rutas.AllowUserToAddRows = false;
            this.dgrid_rutas.AllowUserToDeleteRows = false;
            this.dgrid_rutas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_rutas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_rutas.Location = new System.Drawing.Point(0, 0);
            this.dgrid_rutas.Name = "dgrid_rutas";
            this.dgrid_rutas.ReadOnly = true;
            this.dgrid_rutas.Size = new System.Drawing.Size(1127, 300);
            this.dgrid_rutas.TabIndex = 0;
            this.dgrid_rutas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgrid_rutas_CellMouseClick);
            this.dgrid_rutas.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgrid_rutas_RowPrePaint);
            this.dgrid_rutas.Click += new System.EventHandler(this.dgrid_rutas_Click);
            // 
            // VRutas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VRutas";
            this.Text = "VRutas";
            this.Load += new System.EventHandler(this.VRutas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpbx.ResumeLayout(false);
            this.gpbx.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_rutas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgrid_rutas;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.DateTimePicker dtm_final;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtm_inicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_unidad;
        private System.Windows.Forms.ComboBox cmb_servicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_ruta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_cliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_operador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_hora;
        private System.Windows.Forms.DateTimePicker dtm_fecha;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_turno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_codbitad;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_psalida;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_pentrada;
        private System.Windows.Forms.Button btn_bitacora;
    }
}