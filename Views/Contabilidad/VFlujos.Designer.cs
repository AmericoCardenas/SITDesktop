namespace SIT.Views.Contabilidad
{
    partial class VFlujos
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
            this.btn_archivo = new System.Windows.Forms.Button();
            this.btn_canc = new System.Windows.Forms.Button();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.cmb_empleado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_concepto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtm_fecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_tipo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_metodo = new System.Windows.Forms.ComboBox();
            this.cmb_area = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbcontrol = new System.Windows.Forms.TabControl();
            this.tb_egreso = new System.Windows.Forms.TabPage();
            this.dgrid_egreso = new System.Windows.Forms.DataGridView();
            this.tb_ingreso = new System.Windows.Forms.TabPage();
            this.dgrid_ingreso = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tbcontrol.SuspendLayout();
            this.tb_egreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_egreso)).BeginInit();
            this.tb_ingreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ingreso)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_archivo);
            this.panel1.Controls.Add(this.btn_canc);
            this.panel1.Controls.Add(this.txt_cantidad);
            this.panel1.Controls.Add(this.cmb_empleado);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.txt_concepto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtm_fecha);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_tipo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmb_metodo);
            this.panel1.Controls.Add(this.cmb_area);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 81);
            this.panel1.TabIndex = 0;
            // 
            // btn_archivo
            // 
            this.btn_archivo.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_archivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_archivo.Location = new System.Drawing.Point(582, 42);
            this.btn_archivo.Name = "btn_archivo";
            this.btn_archivo.Size = new System.Drawing.Size(121, 23);
            this.btn_archivo.TabIndex = 14;
            this.btn_archivo.Text = "...";
            this.btn_archivo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_archivo.UseVisualStyleBackColor = false;
            this.btn_archivo.Click += new System.EventHandler(this.btn_archivo_Click);
            // 
            // btn_canc
            // 
            this.btn_canc.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_canc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_canc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_canc.Location = new System.Drawing.Point(795, 35);
            this.btn_canc.Name = "btn_canc";
            this.btn_canc.Size = new System.Drawing.Size(51, 39);
            this.btn_canc.TabIndex = 16;
            this.btn_canc.UseVisualStyleBackColor = true;
            this.btn_canc.Click += new System.EventHandler(this.btn_canc_Click);
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(394, 44);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(182, 20);
            this.txt_cantidad.TabIndex = 13;
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cantidad_KeyPress);
            // 
            // cmb_empleado
            // 
            this.cmb_empleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_empleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_empleado.FormattingEnabled = true;
            this.cmb_empleado.Location = new System.Drawing.Point(636, 12);
            this.cmb_empleado.Name = "cmb_empleado";
            this.cmb_empleado.Size = new System.Drawing.Size(227, 21);
            this.cmb_empleado.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(307, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cantidad";
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(733, 35);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(48, 39);
            this.btn_add.TabIndex = 15;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_concepto
            // 
            this.txt_concepto.Location = new System.Drawing.Point(114, 44);
            this.txt_concepto.Name = "txt_concepto";
            this.txt_concepto.Size = new System.Drawing.Size(182, 20);
            this.txt_concepto.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Concepto";
            // 
            // dtm_fecha
            // 
            this.dtm_fecha.Location = new System.Drawing.Point(66, 13);
            this.dtm_fecha.Name = "dtm_fecha";
            this.dtm_fecha.Size = new System.Drawing.Size(85, 20);
            this.dtm_fecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(159, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // cmb_tipo
            // 
            this.cmb_tipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_tipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_tipo.FormattingEnabled = true;
            this.cmb_tipo.Location = new System.Drawing.Point(207, 13);
            this.cmb_tipo.Name = "cmb_tipo";
            this.cmb_tipo.Size = new System.Drawing.Size(104, 21);
            this.cmb_tipo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(331, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Metodo";
            // 
            // cmb_metodo
            // 
            this.cmb_metodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_metodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_metodo.FormattingEnabled = true;
            this.cmb_metodo.Location = new System.Drawing.Point(402, 12);
            this.cmb_metodo.Name = "cmb_metodo";
            this.cmb_metodo.Size = new System.Drawing.Size(138, 21);
            this.cmb_metodo.TabIndex = 5;
            // 
            // cmb_area
            // 
            this.cmb_area.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_area.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_area.FormattingEnabled = true;
            this.cmb_area.Location = new System.Drawing.Point(920, 11);
            this.cmb_area.Name = "cmb_area";
            this.cmb_area.Size = new System.Drawing.Size(160, 21);
            this.cmb_area.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(550, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Empleado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(872, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Area";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_filtro);
            this.panel2.Controls.Add(this.cmb_filtro);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 36);
            this.panel2.TabIndex = 1;
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(814, 6);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(266, 20);
            this.txt_filtro.TabIndex = 1;
            this.txt_filtro.Tag = "Buscar";
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(636, 6);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(175, 21);
            this.cmb_filtro.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbcontrol);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 117);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1108, 333);
            this.panel3.TabIndex = 2;
            // 
            // tbcontrol
            // 
            this.tbcontrol.Controls.Add(this.tb_egreso);
            this.tbcontrol.Controls.Add(this.tb_ingreso);
            this.tbcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcontrol.Location = new System.Drawing.Point(0, 0);
            this.tbcontrol.Name = "tbcontrol";
            this.tbcontrol.SelectedIndex = 0;
            this.tbcontrol.Size = new System.Drawing.Size(1108, 333);
            this.tbcontrol.TabIndex = 0;
            this.tbcontrol.SelectedIndexChanged += new System.EventHandler(this.tbcontrol_SelectedIndexChanged);
            // 
            // tb_egreso
            // 
            this.tb_egreso.Controls.Add(this.dgrid_egreso);
            this.tb_egreso.Location = new System.Drawing.Point(4, 22);
            this.tb_egreso.Name = "tb_egreso";
            this.tb_egreso.Padding = new System.Windows.Forms.Padding(3);
            this.tb_egreso.Size = new System.Drawing.Size(1100, 307);
            this.tb_egreso.TabIndex = 0;
            this.tb_egreso.Text = "Egreso";
            this.tb_egreso.UseVisualStyleBackColor = true;
            // 
            // dgrid_egreso
            // 
            this.dgrid_egreso.AllowUserToAddRows = false;
            this.dgrid_egreso.AllowUserToDeleteRows = false;
            this.dgrid_egreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_egreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_egreso.Location = new System.Drawing.Point(3, 3);
            this.dgrid_egreso.Name = "dgrid_egreso";
            this.dgrid_egreso.ReadOnly = true;
            this.dgrid_egreso.Size = new System.Drawing.Size(1094, 301);
            this.dgrid_egreso.TabIndex = 0;
            this.dgrid_egreso.Click += new System.EventHandler(this.dgrid_egreso_Click);
            this.dgrid_egreso.DoubleClick += new System.EventHandler(this.dgrid_egreso_DoubleClick);
            // 
            // tb_ingreso
            // 
            this.tb_ingreso.Controls.Add(this.dgrid_ingreso);
            this.tb_ingreso.Location = new System.Drawing.Point(4, 22);
            this.tb_ingreso.Name = "tb_ingreso";
            this.tb_ingreso.Padding = new System.Windows.Forms.Padding(3);
            this.tb_ingreso.Size = new System.Drawing.Size(1100, 307);
            this.tb_ingreso.TabIndex = 1;
            this.tb_ingreso.Text = "Ingreso";
            this.tb_ingreso.UseVisualStyleBackColor = true;
            // 
            // dgrid_ingreso
            // 
            this.dgrid_ingreso.AllowUserToAddRows = false;
            this.dgrid_ingreso.AllowUserToDeleteRows = false;
            this.dgrid_ingreso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_ingreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_ingreso.Location = new System.Drawing.Point(3, 3);
            this.dgrid_ingreso.Name = "dgrid_ingreso";
            this.dgrid_ingreso.ReadOnly = true;
            this.dgrid_ingreso.Size = new System.Drawing.Size(1094, 301);
            this.dgrid_ingreso.TabIndex = 0;
            this.dgrid_ingreso.Click += new System.EventHandler(this.dgrid_ingreso_Click);
            this.dgrid_ingreso.DoubleClick += new System.EventHandler(this.dgrid_ingreso_DoubleClick);
            // 
            // VFlujos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VFlujos";
            this.Text = "VFlujos";
            this.Load += new System.EventHandler(this.VFlujos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tbcontrol.ResumeLayout(false);
            this.tb_egreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_egreso)).EndInit();
            this.tb_ingreso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_ingreso)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtm_fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tbcontrol;
        private System.Windows.Forms.TabPage tb_egreso;
        private System.Windows.Forms.TabPage tb_ingreso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_empleado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_metodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_tipo;
        private System.Windows.Forms.ComboBox cmb_area;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_canc;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_archivo;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_concepto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.DataGridView dgrid_egreso;
        private System.Windows.Forms.DataGridView dgrid_ingreso;
    }
}