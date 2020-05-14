namespace CompareExcel
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblFile1 = new System.Windows.Forms.Label();
            this.LblFile2 = new System.Windows.Forms.Label();
            this.BtnFile1 = new System.Windows.Forms.Button();
            this.BtnFile2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtSheetName = new System.Windows.Forms.TextBox();
            this.BtnCompare = new System.Windows.Forms.Button();
            this.CbxStartExcel = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblFile1
            // 
            this.LblFile1.Location = new System.Drawing.Point(12, 16);
            this.LblFile1.Name = "LblFile1";
            this.LblFile1.Size = new System.Drawing.Size(351, 23);
            this.LblFile1.TabIndex = 0;
            this.LblFile1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblFile2
            // 
            this.LblFile2.Location = new System.Drawing.Point(9, 51);
            this.LblFile2.Name = "LblFile2";
            this.LblFile2.Size = new System.Drawing.Size(354, 23);
            this.LblFile2.TabIndex = 1;
            this.LblFile2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnFile1
            // 
            this.BtnFile1.Location = new System.Drawing.Point(375, 16);
            this.BtnFile1.Name = "BtnFile1";
            this.BtnFile1.Size = new System.Drawing.Size(133, 23);
            this.BtnFile1.TabIndex = 2;
            this.BtnFile1.Text = "Seleccione el archivo 1";
            this.BtnFile1.UseVisualStyleBackColor = true;
            this.BtnFile1.Click += new System.EventHandler(this.BtnFile1_Click);
            // 
            // BtnFile2
            // 
            this.BtnFile2.Location = new System.Drawing.Point(375, 51);
            this.BtnFile2.Name = "BtnFile2";
            this.BtnFile2.Size = new System.Drawing.Size(133, 23);
            this.BtnFile2.TabIndex = 3;
            this.BtnFile2.Text = "Seleccione el archivo 2";
            this.BtnFile2.UseVisualStyleBackColor = true;
            this.BtnFile2.Click += new System.EventHandler(this.BtnFile2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblFile1);
            this.groupBox1.Controls.Add(this.LblFile2);
            this.groupBox1.Controls.Add(this.BtnFile1);
            this.groupBox1.Controls.Add(this.BtnFile2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 84);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtSheetName);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 55);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hoja";
            // 
            // TxtSheetName
            // 
            this.TxtSheetName.Location = new System.Drawing.Point(12, 19);
            this.TxtSheetName.Name = "TxtSheetName";
            this.TxtSheetName.Size = new System.Drawing.Size(496, 20);
            this.TxtSheetName.TabIndex = 8;
            // 
            // BtnCompare
            // 
            this.BtnCompare.Location = new System.Drawing.Point(393, 171);
            this.BtnCompare.Name = "BtnCompare";
            this.BtnCompare.Size = new System.Drawing.Size(133, 23);
            this.BtnCompare.TabIndex = 9;
            this.BtnCompare.Text = "Comparar";
            this.BtnCompare.UseVisualStyleBackColor = true;
            this.BtnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // CbxStartExcel
            // 
            this.CbxStartExcel.AutoSize = true;
            this.CbxStartExcel.Location = new System.Drawing.Point(12, 175);
            this.CbxStartExcel.Name = "CbxStartExcel";
            this.CbxStartExcel.Size = new System.Drawing.Size(85, 17);
            this.CbxStartExcel.TabIndex = 10;
            this.CbxStartExcel.Text = "Abrir archivo";
            this.CbxStartExcel.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 208);
            this.Controls.Add(this.CbxStartExcel);
            this.Controls.Add(this.BtnCompare);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparar archivos de Excel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblFile1;
        private System.Windows.Forms.Label LblFile2;
        private System.Windows.Forms.Button BtnFile1;
        private System.Windows.Forms.Button BtnFile2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtSheetName;
        private System.Windows.Forms.Button BtnCompare;
        private System.Windows.Forms.CheckBox CbxStartExcel;
    }
}

