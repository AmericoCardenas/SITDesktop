namespace SIT.Views.Contabilidad.CMovimientos
{
    partial class VSaldoActual
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
            this.cmb_cuentas = new System.Windows.Forms.ComboBox();
            this.lbl_saldo = new System.Windows.Forms.Label();
            this.lbl_banco = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo Actual";
            // 
            // cmb_cuentas
            // 
            this.cmb_cuentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_cuentas.FormattingEnabled = true;
            this.cmb_cuentas.Location = new System.Drawing.Point(33, 94);
            this.cmb_cuentas.Name = "cmb_cuentas";
            this.cmb_cuentas.Size = new System.Drawing.Size(223, 32);
            this.cmb_cuentas.TabIndex = 1;
            this.cmb_cuentas.SelectedValueChanged += new System.EventHandler(this.cmb_cuentas_SelectedValueChanged);
            // 
            // lbl_saldo
            // 
            this.lbl_saldo.AutoSize = true;
            this.lbl_saldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_saldo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_saldo.Location = new System.Drawing.Point(40, 138);
            this.lbl_saldo.Name = "lbl_saldo";
            this.lbl_saldo.Size = new System.Drawing.Size(207, 37);
            this.lbl_saldo.TabIndex = 2;
            this.lbl_saldo.Text = "$$SALDO$$";
            // 
            // lbl_banco
            // 
            this.lbl_banco.AutoSize = true;
            this.lbl_banco.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_banco.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_banco.Location = new System.Drawing.Point(32, 47);
            this.lbl_banco.Name = "lbl_banco";
            this.lbl_banco.Size = new System.Drawing.Size(78, 25);
            this.lbl_banco.TabIndex = 3;
            this.lbl_banco.Text = "Banco";
            // 
            // VSaldoActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(289, 202);
            this.Controls.Add(this.lbl_banco);
            this.Controls.Add(this.lbl_saldo);
            this.Controls.Add(this.cmb_cuentas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VSaldoActual";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SaldoActual";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_cuentas;
        private System.Windows.Forms.Label lbl_saldo;
        private System.Windows.Forms.Label lbl_banco;
    }
}