namespace Envio_de_datos_Net
{
    partial class FormGeneradordeInforme
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
            this.txbCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.bCargar = new System.Windows.Forms.Button();
            this.bGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbCodigo
            // 
            this.txbCodigo.Location = new System.Drawing.Point(58, 31);
            this.txbCodigo.Name = "txbCodigo";
            this.txbCodigo.Size = new System.Drawing.Size(151, 20);
            this.txbCodigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Version";
            // 
            // txbVersion
            // 
            this.txbVersion.Location = new System.Drawing.Point(365, 32);
            this.txbVersion.Name = "txbVersion";
            this.txbVersion.Size = new System.Drawing.Size(100, 20);
            this.txbVersion.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lote Produccion";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(365, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Location = new System.Drawing.Point(58, 64);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Value = new System.DateTime(2016, 11, 17, 0, 0, 0, 0);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(15, 118);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(450, 244);
            this.checkedListBox1.TabIndex = 8;
            // 
            // bCargar
            // 
            this.bCargar.Location = new System.Drawing.Point(471, 118);
            this.bCargar.Name = "bCargar";
            this.bCargar.Size = new System.Drawing.Size(75, 23);
            this.bCargar.TabIndex = 9;
            this.bCargar.Text = "Cargar ";
            this.bCargar.UseVisualStyleBackColor = true;
            this.bCargar.Click += new System.EventHandler(this.bCargar_Click);
            // 
            // bGuardar
            // 
            this.bGuardar.Location = new System.Drawing.Point(471, 156);
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(75, 23);
            this.bGuardar.TabIndex = 10;
            this.bGuardar.Text = "Guardar";
            this.bGuardar.UseVisualStyleBackColor = true;
            // 
            // FormGeneradordeInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 374);
            this.Controls.Add(this.bGuardar);
            this.Controls.Add(this.bCargar);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbCodigo);
            this.Name = "FormGeneradordeInforme";
            this.Text = "FormGeneradordeInforme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button bCargar;
        private System.Windows.Forms.Button bGuardar;
    }
}