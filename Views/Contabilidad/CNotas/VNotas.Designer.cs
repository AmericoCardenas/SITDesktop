namespace SIT.Views.Contabilidad.CMovimientos
{
    partial class VNotas
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
            this.dgrid_notas = new System.Windows.Forms.DataGridView();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_notas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrid_notas
            // 
            this.dgrid_notas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_notas.Location = new System.Drawing.Point(12, 56);
            this.dgrid_notas.Name = "dgrid_notas";
            this.dgrid_notas.Size = new System.Drawing.Size(984, 262);
            this.dgrid_notas.TabIndex = 1;
            this.dgrid_notas.Click += new System.EventHandler(this.dgrid_notas_Click);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(760, 2);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(115, 21);
            this.cmb_filtro.TabIndex = 11;
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(881, 3);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(115, 20);
            this.txt_filtro.TabIndex = 12;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(67, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(54, 47);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(12, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(49, 47);
            this.btn_add.TabIndex = 2;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // VNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 369);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.txt_filtro);
            this.Controls.Add(this.cmb_filtro);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.dgrid_notas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VNotas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas";
            this.Load += new System.EventHandler(this.VNotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_notas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgrid_notas;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.Button btn_cancel;
    }
}