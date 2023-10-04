namespace SIT.Views.Catalogos
{
    partial class VEmpleados
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
            this.panelbtn = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filtro = new System.Windows.Forms.TextBox();
            this.btn_excel = new System.Windows.Forms.Button();
            this.paneldatagrid = new System.Windows.Forms.Panel();
            this.dgrid_empleados = new System.Windows.Forms.DataGridView();
            this.panelbtn.SuspendLayout();
            this.paneldatagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_empleados)).BeginInit();
            this.SuspendLayout();
            // 
            // panelbtn
            // 
            this.panelbtn.BackColor = System.Drawing.Color.White;
            this.panelbtn.Controls.Add(this.button1);
            this.panelbtn.Controls.Add(this.label1);
            this.panelbtn.Controls.Add(this.txt_filtro);
            this.panelbtn.Controls.Add(this.btn_excel);
            this.panelbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelbtn.Location = new System.Drawing.Point(0, 0);
            this.panelbtn.Name = "panelbtn";
            this.panelbtn.Size = new System.Drawing.Size(800, 46);
            this.panelbtn.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(483, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // txt_filtro
            // 
            this.txt_filtro.Location = new System.Drawing.Point(566, 13);
            this.txt_filtro.Name = "txt_filtro";
            this.txt_filtro.Size = new System.Drawing.Size(183, 20);
            this.txt_filtro.TabIndex = 1;
            this.txt_filtro.TextChanged += new System.EventHandler(this.txt_filtro_TextChanged);
            // 
            // btn_excel
            // 
            this.btn_excel.BackgroundImage = global::SIT.Properties.Resources.excel;
            this.btn_excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Location = new System.Drawing.Point(12, 3);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(52, 40);
            this.btn_excel.TabIndex = 0;
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // paneldatagrid
            // 
            this.paneldatagrid.Controls.Add(this.dgrid_empleados);
            this.paneldatagrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneldatagrid.Location = new System.Drawing.Point(0, 46);
            this.paneldatagrid.Name = "paneldatagrid";
            this.paneldatagrid.Size = new System.Drawing.Size(800, 404);
            this.paneldatagrid.TabIndex = 1;
            // 
            // dgrid_empleados
            // 
            this.dgrid_empleados.AllowUserToAddRows = false;
            this.dgrid_empleados.AllowUserToDeleteRows = false;
            this.dgrid_empleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_empleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrid_empleados.Location = new System.Drawing.Point(0, 0);
            this.dgrid_empleados.Name = "dgrid_empleados";
            this.dgrid_empleados.ReadOnly = true;
            this.dgrid_empleados.Size = new System.Drawing.Size(800, 404);
            this.dgrid_empleados.TabIndex = 0;
            this.dgrid_empleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrid_empleados_CellDoubleClick);
            // 
            // VEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.paneldatagrid);
            this.Controls.Add(this.panelbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VEmpleados";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleados";
            this.Load += new System.EventHandler(this.VEmpleados_Load);
            this.panelbtn.ResumeLayout(false);
            this.panelbtn.PerformLayout();
            this.paneldatagrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_empleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelbtn;
        private System.Windows.Forms.Panel paneldatagrid;
        private System.Windows.Forms.DataGridView dgrid_empleados;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.TextBox txt_filtro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}