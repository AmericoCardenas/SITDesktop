namespace SIT.Views.Catalogos.CProductosSnack
{
    partial class VProductosSnack
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
            this.btn_add = new System.Windows.Forms.Button();
            this.dgrid_prodsnack = new System.Windows.Forms.DataGridView();
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_prodsnack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cancelar);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(4, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(56, 39);
            this.btn_add.TabIndex = 0;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgrid_prodsnack
            // 
            this.dgrid_prodsnack.AllowUserToAddRows = false;
            this.dgrid_prodsnack.AllowUserToDeleteRows = false;
            this.dgrid_prodsnack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_prodsnack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_prodsnack.Location = new System.Drawing.Point(0, 46);
            this.dgrid_prodsnack.Name = "dgrid_prodsnack";
            this.dgrid_prodsnack.ReadOnly = true;
            this.dgrid_prodsnack.Size = new System.Drawing.Size(800, 404);
            this.dgrid_prodsnack.TabIndex = 1;
            this.dgrid_prodsnack.Click += new System.EventHandler(this.dgrid_prodsnack_Click);
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(502, 12);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 1;
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(633, 12);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(157, 20);
            this.txt_filtro.TabIndex = 2;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackgroundImage = global::SIT.Properties.Resources._4854a15a23db464f53599f35ab4ef584;
            this.btn_cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancelar.Location = new System.Drawing.Point(66, 4);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(56, 39);
            this.btn_cancelar.TabIndex = 3;
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // VProductosSnack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgrid_prodsnack);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VProductosSnack";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VProductosSnack";
            this.Load += new System.EventHandler(this.VProductosSnack_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_prodsnack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgrid_prodsnack;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Button btn_cancelar;
    }
}