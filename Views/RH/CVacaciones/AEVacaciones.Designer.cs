namespace SIT.Views.RH.CVacaciones
{
    partial class AEVacaciones
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_emp = new System.Windows.Forms.ComboBox();
            this.txt_totvacaciones = new System.Windows.Forms.TextBox();
            this.txt_vacgoz = new System.Windows.Forms.TextBox();
            this.txt_vacpend = new System.Windows.Forms.TextBox();
            this.txt_obs = new System.Windows.Forms.TextBox();
            this.lstbx_fechas = new System.Windows.Forms.ListBox();
            this.dtm_fecha = new System.Windows.Forms.DateTimePicker();
            this.txt_dgoz = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_periodo = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empleado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tot. Vacaciones";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dias Gozados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dias a gozar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dias Pendientes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Observaciones";
            // 
            // cmb_emp
            // 
            this.cmb_emp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_emp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_emp.FormattingEnabled = true;
            this.cmb_emp.Location = new System.Drawing.Point(129, 7);
            this.cmb_emp.Name = "cmb_emp";
            this.cmb_emp.Size = new System.Drawing.Size(162, 21);
            this.cmb_emp.TabIndex = 6;
            this.cmb_emp.SelectedValueChanged += new System.EventHandler(this.cmb_emp_SelectedValueChanged);
            // 
            // txt_totvacaciones
            // 
            this.txt_totvacaciones.Enabled = false;
            this.txt_totvacaciones.Location = new System.Drawing.Point(129, 65);
            this.txt_totvacaciones.Name = "txt_totvacaciones";
            this.txt_totvacaciones.Size = new System.Drawing.Size(162, 20);
            this.txt_totvacaciones.TabIndex = 7;
            // 
            // txt_vacgoz
            // 
            this.txt_vacgoz.Enabled = false;
            this.txt_vacgoz.Location = new System.Drawing.Point(129, 95);
            this.txt_vacgoz.Name = "txt_vacgoz";
            this.txt_vacgoz.Size = new System.Drawing.Size(162, 20);
            this.txt_vacgoz.TabIndex = 8;
            // 
            // txt_vacpend
            // 
            this.txt_vacpend.Enabled = false;
            this.txt_vacpend.Location = new System.Drawing.Point(129, 121);
            this.txt_vacpend.Name = "txt_vacpend";
            this.txt_vacpend.Size = new System.Drawing.Size(162, 20);
            this.txt_vacpend.TabIndex = 9;
            // 
            // txt_obs
            // 
            this.txt_obs.Location = new System.Drawing.Point(129, 153);
            this.txt_obs.Name = "txt_obs";
            this.txt_obs.Size = new System.Drawing.Size(162, 20);
            this.txt_obs.TabIndex = 10;
            // 
            // lstbx_fechas
            // 
            this.lstbx_fechas.FormattingEnabled = true;
            this.lstbx_fechas.Location = new System.Drawing.Point(312, 29);
            this.lstbx_fechas.Name = "lstbx_fechas";
            this.lstbx_fechas.Size = new System.Drawing.Size(301, 147);
            this.lstbx_fechas.TabIndex = 11;
            // 
            // dtm_fecha
            // 
            this.dtm_fecha.Location = new System.Drawing.Point(410, 5);
            this.dtm_fecha.Name = "dtm_fecha";
            this.dtm_fecha.Size = new System.Drawing.Size(96, 20);
            this.dtm_fecha.TabIndex = 12;
            this.dtm_fecha.ValueChanged += new System.EventHandler(this.dtm_fecha_ValueChanged);
            // 
            // txt_dgoz
            // 
            this.txt_dgoz.Enabled = false;
            this.txt_dgoz.Location = new System.Drawing.Point(512, 5);
            this.txt_dgoz.Name = "txt_dgoz";
            this.txt_dgoz.Size = new System.Drawing.Size(71, 20);
            this.txt_dgoz.TabIndex = 14;
            // 
            // btn_delete
            // 
            this.btn_delete.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Location = new System.Drawing.Point(589, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(24, 23);
            this.btn_delete.TabIndex = 13;
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Periodo";
            // 
            // cmb_periodo
            // 
            this.cmb_periodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_periodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_periodo.FormattingEnabled = true;
            this.cmb_periodo.Location = new System.Drawing.Point(129, 34);
            this.cmb_periodo.Name = "cmb_periodo";
            this.cmb_periodo.Size = new System.Drawing.Size(162, 21);
            this.cmb_periodo.TabIndex = 16;
            this.cmb_periodo.SelectedValueChanged += new System.EventHandler(this.cmb_periodo_SelectedValueChanged);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.check;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(626, 47);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(63, 55);
            this.btn_add.TabIndex = 17;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // AEVacaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 185);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cmb_periodo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_dgoz);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.dtm_fecha);
            this.Controls.Add(this.lstbx_fechas);
            this.Controls.Add(this.txt_obs);
            this.Controls.Add(this.txt_vacpend);
            this.Controls.Add(this.txt_vacgoz);
            this.Controls.Add(this.txt_totvacaciones);
            this.Controls.Add(this.cmb_emp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "AEVacaciones";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AEVacaciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AEVacaciones_FormClosed);
            this.Load += new System.EventHandler(this.AEVacaciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_emp;
        private System.Windows.Forms.TextBox txt_totvacaciones;
        private System.Windows.Forms.TextBox txt_vacgoz;
        private System.Windows.Forms.TextBox txt_vacpend;
        private System.Windows.Forms.TextBox txt_obs;
        private System.Windows.Forms.ListBox lstbx_fechas;
        private System.Windows.Forms.DateTimePicker dtm_fecha;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_dgoz;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_periodo;
        private System.Windows.Forms.Button btn_add;
    }
}