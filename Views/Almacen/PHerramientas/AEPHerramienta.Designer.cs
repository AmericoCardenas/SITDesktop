namespace SIT.Views.Almacen.PHerramientas
{
    partial class AEPHerramienta
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
            this.button1 = new System.Windows.Forms.Button();
            this.dtm_fecha = new System.Windows.Forms.DateTimePicker();
            this.cmb_empleado = new System.Windows.Forms.ComboBox();
            this.cmb_herramienta = new System.Windows.Forms.ComboBox();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.txt_hora = new System.Windows.Forms.TextBox();
            this.cmb_estatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hora:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Empleado:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Herramienta:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cantidad:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(183, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtm_fecha
            // 
            this.dtm_fecha.Location = new System.Drawing.Point(114, 13);
            this.dtm_fecha.Name = "dtm_fecha";
            this.dtm_fecha.Size = new System.Drawing.Size(239, 20);
            this.dtm_fecha.TabIndex = 6;
            // 
            // cmb_empleado
            // 
            this.cmb_empleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_empleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_empleado.FormattingEnabled = true;
            this.cmb_empleado.Location = new System.Drawing.Point(114, 74);
            this.cmb_empleado.Name = "cmb_empleado";
            this.cmb_empleado.Size = new System.Drawing.Size(239, 21);
            this.cmb_empleado.TabIndex = 7;
            // 
            // cmb_herramienta
            // 
            this.cmb_herramienta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_herramienta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_herramienta.FormattingEnabled = true;
            this.cmb_herramienta.Location = new System.Drawing.Point(114, 104);
            this.cmb_herramienta.Name = "cmb_herramienta";
            this.cmb_herramienta.Size = new System.Drawing.Size(239, 21);
            this.cmb_herramienta.TabIndex = 8;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(114, 133);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(239, 20);
            this.txt_cantidad.TabIndex = 9;
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cantidad_KeyPress);
            // 
            // txt_hora
            // 
            this.txt_hora.Location = new System.Drawing.Point(114, 43);
            this.txt_hora.Name = "txt_hora";
            this.txt_hora.Size = new System.Drawing.Size(239, 20);
            this.txt_hora.TabIndex = 10;
            // 
            // cmb_estatus
            // 
            this.cmb_estatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_estatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_estatus.FormattingEnabled = true;
            this.cmb_estatus.Location = new System.Drawing.Point(114, 161);
            this.cmb_estatus.Name = "cmb_estatus";
            this.cmb_estatus.Size = new System.Drawing.Size(239, 21);
            this.cmb_estatus.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Estatus:";
            // 
            // AEPHerramienta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 234);
            this.Controls.Add(this.cmb_estatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_hora);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.cmb_herramienta);
            this.Controls.Add(this.cmb_empleado);
            this.Controls.Add(this.dtm_fecha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AEPHerramienta";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AEPHerramienta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AEPHerramienta_FormClosed);
            this.Load += new System.EventHandler(this.AEPHerramienta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dtm_fecha;
        private System.Windows.Forms.ComboBox cmb_empleado;
        private System.Windows.Forms.ComboBox cmb_herramienta;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.TextBox txt_hora;
        private System.Windows.Forms.ComboBox cmb_estatus;
        private System.Windows.Forms.Label label6;
    }
}