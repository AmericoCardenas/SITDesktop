namespace SIT.Views.Sistemas
{
    partial class VLineas
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
            this.cmb_filtro = new System.Windows.Forms.ComboBox();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_emp = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_estatus = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_prov = new System.Windows.Forms.ComboBox();
            this.txt_sim = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_linea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgrid_lineas = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_doc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_lineas)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_doc);
            this.panel1.Controls.Add(this.cmb_filtro);
            this.panel1.Controls.Add(this.txt_filtro);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmb_emp);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmb_estatus);
            this.panel1.Controls.Add(this.btn_add);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmb_prov);
            this.panel1.Controls.Add(this.txt_sim);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_linea);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 86);
            this.panel1.TabIndex = 0;
            // 
            // cmb_filtro
            // 
            this.cmb_filtro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_filtro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_filtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_filtro.FormattingEnabled = true;
            this.cmb_filtro.Location = new System.Drawing.Point(25, 44);
            this.cmb_filtro.Name = "cmb_filtro";
            this.cmb_filtro.Size = new System.Drawing.Size(121, 21);
            this.cmb_filtro.TabIndex = 13;
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(164, 44);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(136, 20);
            this.txt_filtro.TabIndex = 12;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(859, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Empleado";
            // 
            // cmb_emp
            // 
            this.cmb_emp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_emp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_emp.FormattingEnabled = true;
            this.cmb_emp.Location = new System.Drawing.Point(943, 16);
            this.cmb_emp.Name = "cmb_emp";
            this.cmb_emp.Size = new System.Drawing.Size(121, 21);
            this.cmb_emp.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(650, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Estatus";
            // 
            // cmb_estatus
            // 
            this.cmb_estatus.FormattingEnabled = true;
            this.cmb_estatus.Location = new System.Drawing.Point(720, 17);
            this.cmb_estatus.Name = "cmb_estatus";
            this.cmb_estatus.Size = new System.Drawing.Size(121, 21);
            this.cmb_estatus.TabIndex = 7;
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::SIT.Properties.Resources.mas;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(1082, 8);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(51, 38);
            this.btn_add.TabIndex = 6;
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(422, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Proveedor";
            // 
            // cmb_prov
            // 
            this.cmb_prov.FormattingEnabled = true;
            this.cmb_prov.Location = new System.Drawing.Point(508, 17);
            this.cmb_prov.Name = "cmb_prov";
            this.cmb_prov.Size = new System.Drawing.Size(121, 21);
            this.cmb_prov.TabIndex = 4;
            // 
            // txt_sim
            // 
            this.txt_sim.Location = new System.Drawing.Point(263, 18);
            this.txt_sim.Name = "txt_sim";
            this.txt_sim.Size = new System.Drawing.Size(136, 20);
            this.txt_sim.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(225, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "SIM";
            // 
            // txt_linea
            // 
            this.txt_linea.Location = new System.Drawing.Point(73, 18);
            this.txt_linea.Name = "txt_linea";
            this.txt_linea.Size = new System.Drawing.Size(136, 20);
            this.txt_linea.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linea";
            // 
            // dgrid_lineas
            // 
            this.dgrid_lineas.AllowUserToAddRows = false;
            this.dgrid_lineas.AllowUserToDeleteRows = false;
            this.dgrid_lineas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_lineas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_lineas.Location = new System.Drawing.Point(0, 0);
            this.dgrid_lineas.Name = "dgrid_lineas";
            this.dgrid_lineas.ReadOnly = true;
            this.dgrid_lineas.Size = new System.Drawing.Size(1147, 364);
            this.dgrid_lineas.TabIndex = 1;
            this.dgrid_lineas.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgrid_lineas_RowPrePaint);
            this.dgrid_lineas.Click += new System.EventHandler(this.dgrid_lineas_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgrid_lineas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 364);
            this.panel2.TabIndex = 2;
            // 
            // btn_doc
            // 
            this.btn_doc.BackgroundImage = global::SIT.Properties.Resources.google_docs;
            this.btn_doc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_doc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_doc.Location = new System.Drawing.Point(315, 42);
            this.btn_doc.Name = "btn_doc";
            this.btn_doc.Size = new System.Drawing.Size(51, 39);
            this.btn_doc.TabIndex = 14;
            this.btn_doc.UseVisualStyleBackColor = true;
            this.btn_doc.Click += new System.EventHandler(this.btn_doc_Click);
            // 
            // VLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VLineas";
            this.Text = "VLineas";
            this.Load += new System.EventHandler(this.VLineas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_lineas)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_prov;
        private System.Windows.Forms.TextBox txt_sim;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_linea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgrid_lineas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_estatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_emp;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.ComboBox cmb_filtro;
        private System.Windows.Forms.Button btn_doc;
    }
}