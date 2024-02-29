namespace SIT.Views.Contabilidad
{
    partial class VSaldoxFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VSaldoxFecha));
            this.dtm_fecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_saldo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_cuenta = new System.Windows.Forms.ComboBox();
            this.lbl_banco = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtm_fecha
            // 
            this.dtm_fecha.Location = new System.Drawing.Point(28, 54);
            this.dtm_fecha.Name = "dtm_fecha";
            this.dtm_fecha.Size = new System.Drawing.Size(200, 20);
            this.dtm_fecha.TabIndex = 0;
            this.dtm_fecha.ValueChanged += new System.EventHandler(this.dtm_fecha_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha";
            // 
            // lbl_saldo
            // 
            this.lbl_saldo.AutoSize = true;
            this.lbl_saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_saldo.Location = new System.Drawing.Point(27, 208);
            this.lbl_saldo.Name = "lbl_saldo";
            this.lbl_saldo.Size = new System.Drawing.Size(81, 29);
            this.lbl_saldo.TabIndex = 3;
            this.lbl_saldo.Text = "Saldo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cuenta";
            // 
            // cmb_cuenta
            // 
            this.cmb_cuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_cuenta.FormattingEnabled = true;
            this.cmb_cuenta.Location = new System.Drawing.Point(28, 166);
            this.cmb_cuenta.Name = "cmb_cuenta";
            this.cmb_cuenta.Size = new System.Drawing.Size(200, 28);
            this.cmb_cuenta.TabIndex = 5;
            this.cmb_cuenta.SelectedValueChanged += new System.EventHandler(this.cmb_cuenta_SelectedValueChanged);
            // 
            // lbl_banco
            // 
            this.lbl_banco.AutoSize = true;
            this.lbl_banco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_banco.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_banco.Location = new System.Drawing.Point(12, 125);
            this.lbl_banco.Name = "lbl_banco";
            this.lbl_banco.Size = new System.Drawing.Size(69, 24);
            this.lbl_banco.TabIndex = 6;
            this.lbl_banco.Text = "Banco";
            // 
            // VSaldoxFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(250, 253);
            this.Controls.Add(this.lbl_banco);
            this.Controls.Add(this.cmb_cuenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_saldo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtm_fecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VSaldoxFecha";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saldo por fecha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtm_fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_saldo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_cuenta;
        private System.Windows.Forms.Label lbl_banco;
    }
}