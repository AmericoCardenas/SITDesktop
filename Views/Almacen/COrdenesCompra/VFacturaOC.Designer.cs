namespace SIT.Views.Almacen.COrdenesCompra
{
    partial class VFacturaOC
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
            this.btn_cargarfactura = new System.Windows.Forms.Button();
            this.btn_cargarxml = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_folio = new System.Windows.Forms.TextBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_verxml = new System.Windows.Forms.Button();
            this.btn_verfactura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Factura PDF";
            // 
            // btn_cargarfactura
            // 
            this.btn_cargarfactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cargarfactura.Location = new System.Drawing.Point(121, 47);
            this.btn_cargarfactura.Name = "btn_cargarfactura";
            this.btn_cargarfactura.Size = new System.Drawing.Size(154, 23);
            this.btn_cargarfactura.TabIndex = 1;
            this.btn_cargarfactura.Text = ". . .";
            this.btn_cargarfactura.UseVisualStyleBackColor = true;
            this.btn_cargarfactura.Click += new System.EventHandler(this.btn_cargarfactura_Click);
            // 
            // btn_cargarxml
            // 
            this.btn_cargarxml.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cargarxml.Location = new System.Drawing.Point(121, 92);
            this.btn_cargarxml.Name = "btn_cargarxml";
            this.btn_cargarxml.Size = new System.Drawing.Size(154, 23);
            this.btn_cargarxml.TabIndex = 2;
            this.btn_cargarxml.Text = ". . . ";
            this.btn_cargarxml.UseVisualStyleBackColor = true;
            this.btn_cargarxml.Click += new System.EventHandler(this.btn_cargarxml_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "XML";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Folio";
            // 
            // txt_folio
            // 
            this.txt_folio.Location = new System.Drawing.Point(122, 6);
            this.txt_folio.Name = "txt_folio";
            this.txt_folio.Size = new System.Drawing.Size(153, 20);
            this.txt_folio.TabIndex = 7;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackgroundImage = global::SIT.Properties.Resources.check;
            this.btn_aceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aceptar.Location = new System.Drawing.Point(157, 121);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(58, 38);
            this.btn_aceptar.TabIndex = 8;
            this.btn_aceptar.UseVisualStyleBackColor = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_verxml
            // 
            this.btn_verxml.BackgroundImage = global::SIT.Properties.Resources.eye;
            this.btn_verxml.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_verxml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_verxml.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verxml.Location = new System.Drawing.Point(281, 91);
            this.btn_verxml.Name = "btn_verxml";
            this.btn_verxml.Size = new System.Drawing.Size(34, 23);
            this.btn_verxml.TabIndex = 5;
            this.btn_verxml.UseVisualStyleBackColor = true;
            this.btn_verxml.Click += new System.EventHandler(this.btn_verxml_Click);
            // 
            // btn_verfactura
            // 
            this.btn_verfactura.BackgroundImage = global::SIT.Properties.Resources.eye;
            this.btn_verfactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_verfactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_verfactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verfactura.Location = new System.Drawing.Point(281, 47);
            this.btn_verfactura.Name = "btn_verfactura";
            this.btn_verfactura.Size = new System.Drawing.Size(34, 23);
            this.btn_verfactura.TabIndex = 4;
            this.btn_verfactura.UseVisualStyleBackColor = true;
            this.btn_verfactura.Click += new System.EventHandler(this.btn_verfactura_Click);
            // 
            // VFacturaOC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(327, 168);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.txt_folio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_verxml);
            this.Controls.Add(this.btn_verfactura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cargarxml);
            this.Controls.Add(this.btn_cargarfactura);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VFacturaOC";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VFacturaOC";
            this.Load += new System.EventHandler(this.VFacturaOC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cargarfactura;
        private System.Windows.Forms.Button btn_cargarxml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_verfactura;
        private System.Windows.Forms.Button btn_verxml;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_folio;
        private System.Windows.Forms.Button btn_aceptar;
    }
}