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
            this.components = new System.ComponentModel.Container();
            this.txbCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbLote = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.bGuardar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelRegistrarLote = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.bRegistrarLote = new System.Windows.Forms.Button();
            this.bGenerarInforme = new System.Windows.Forms.Button();
            this.panelGeneradorInforme = new System.Windows.Forms.Panel();
            this.txbFGFecha = new System.Windows.Forms.TextBox();
            this.bSiguiente = new System.Windows.Forms.Button();
            this.bAnterior = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.bGInforme = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txbFGCodigo = new System.Windows.Forms.TextBox();
            this.txbFGLote = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbFGVersion = new System.Windows.Forms.TextBox();
            this.esterilizacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bEsterilizacion = new System.Windows.Forms.Button();
            this.bBuscarLote = new System.Windows.Forms.Button();
            this.dateTimePickerBuscarLote = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelRegistrarLote.SuspendLayout();
            this.panelGeneradorInforme.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esterilizacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txbCodigo
            // 
            this.txbCodigo.Location = new System.Drawing.Point(96, 54);
            this.txbCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbCodigo.Name = "txbCodigo";
            this.txbCodigo.Size = new System.Drawing.Size(175, 22);
            this.txbCodigo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "* Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(392, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "* Version";
            // 
            // txbVersion
            // 
            this.txbVersion.Location = new System.Drawing.Point(469, 54);
            this.txbVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbVersion.Name = "txbVersion";
            this.txbVersion.Size = new System.Drawing.Size(116, 22);
            this.txbVersion.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(342, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "* Lote Produccion";
            // 
            // txbLote
            // 
            this.txbLote.Location = new System.Drawing.Point(469, 99);
            this.txbLote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbLote.Name = "txbLote";
            this.txbLote.Size = new System.Drawing.Size(116, 22);
            this.txbLote.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "* Fecha";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Location = new System.Drawing.Point(96, 99);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(233, 22);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Value = new System.DateTime(2016, 11, 17, 0, 0, 0, 0);
            // 
            // bGuardar
            // 
            this.bGuardar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGuardar.Location = new System.Drawing.Point(610, 54);
            this.bGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bGuardar.Name = "bGuardar";
            this.bGuardar.Size = new System.Drawing.Size(229, 28);
            this.bGuardar.TabIndex = 10;
            this.bGuardar.Text = "Guardar Lote";
            this.bGuardar.UseVisualStyleBackColor = true;
            this.bGuardar.Click += new System.EventHandler(this.bGuardar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 137);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(957, 250);
            this.dataGridView1.TabIndex = 11;
            // 
            // panelRegistrarLote
            // 
            this.panelRegistrarLote.BackColor = System.Drawing.SystemColors.Window;
            this.panelRegistrarLote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRegistrarLote.Controls.Add(this.label5);
            this.panelRegistrarLote.Controls.Add(this.dataGridView1);
            this.panelRegistrarLote.Controls.Add(this.dateTimePicker1);
            this.panelRegistrarLote.Controls.Add(this.label4);
            this.panelRegistrarLote.Controls.Add(this.bGuardar);
            this.panelRegistrarLote.Controls.Add(this.label3);
            this.panelRegistrarLote.Controls.Add(this.txbCodigo);
            this.panelRegistrarLote.Controls.Add(this.txbLote);
            this.panelRegistrarLote.Controls.Add(this.label1);
            this.panelRegistrarLote.Controls.Add(this.label2);
            this.panelRegistrarLote.Controls.Add(this.txbVersion);
            this.panelRegistrarLote.Location = new System.Drawing.Point(12, 42);
            this.panelRegistrarLote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelRegistrarLote.Name = "panelRegistrarLote";
            this.panelRegistrarLote.Size = new System.Drawing.Size(966, 400);
            this.panelRegistrarLote.TabIndex = 12;
            this.panelRegistrarLote.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(290, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(324, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Formulario de Registro de Lote";
            // 
            // bRegistrarLote
            // 
            this.bRegistrarLote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bRegistrarLote.Location = new System.Drawing.Point(12, 5);
            this.bRegistrarLote.Name = "bRegistrarLote";
            this.bRegistrarLote.Size = new System.Drawing.Size(111, 30);
            this.bRegistrarLote.TabIndex = 13;
            this.bRegistrarLote.Text = "Registrar Lote";
            this.bRegistrarLote.UseVisualStyleBackColor = true;
            this.bRegistrarLote.Click += new System.EventHandler(this.bRegistrarLote_Click);
            // 
            // bGenerarInforme
            // 
            this.bGenerarInforme.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGenerarInforme.Location = new System.Drawing.Point(280, 5);
            this.bGenerarInforme.Name = "bGenerarInforme";
            this.bGenerarInforme.Size = new System.Drawing.Size(145, 30);
            this.bGenerarInforme.TabIndex = 14;
            this.bGenerarInforme.Text = "Generar Informe";
            this.bGenerarInforme.UseVisualStyleBackColor = true;
            this.bGenerarInforme.Click += new System.EventHandler(this.bGenerarInforme_Click);
            // 
            // panelGeneradorInforme
            // 
            this.panelGeneradorInforme.BackColor = System.Drawing.SystemColors.Window;
            this.panelGeneradorInforme.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelGeneradorInforme.Controls.Add(this.dateTimePickerBuscarLote);
            this.panelGeneradorInforme.Controls.Add(this.bBuscarLote);
            this.panelGeneradorInforme.Controls.Add(this.txbFGFecha);
            this.panelGeneradorInforme.Controls.Add(this.bSiguiente);
            this.panelGeneradorInforme.Controls.Add(this.bAnterior);
            this.panelGeneradorInforme.Controls.Add(this.label6);
            this.panelGeneradorInforme.Controls.Add(this.dataGridView2);
            this.panelGeneradorInforme.Controls.Add(this.label7);
            this.panelGeneradorInforme.Controls.Add(this.bGInforme);
            this.panelGeneradorInforme.Controls.Add(this.label8);
            this.panelGeneradorInforme.Controls.Add(this.txbFGCodigo);
            this.panelGeneradorInforme.Controls.Add(this.txbFGLote);
            this.panelGeneradorInforme.Controls.Add(this.label9);
            this.panelGeneradorInforme.Controls.Add(this.label10);
            this.panelGeneradorInforme.Controls.Add(this.txbFGVersion);
            this.panelGeneradorInforme.Location = new System.Drawing.Point(13, 42);
            this.panelGeneradorInforme.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelGeneradorInforme.Name = "panelGeneradorInforme";
            this.panelGeneradorInforme.Size = new System.Drawing.Size(962, 400);
            this.panelGeneradorInforme.TabIndex = 13;
            this.panelGeneradorInforme.Visible = false;
            // 
            // txbFGFecha
            // 
            this.txbFGFecha.Location = new System.Drawing.Point(96, 99);
            this.txbFGFecha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbFGFecha.Name = "txbFGFecha";
            this.txbFGFecha.ReadOnly = true;
            this.txbFGFecha.Size = new System.Drawing.Size(175, 22);
            this.txbFGFecha.TabIndex = 15;
            // 
            // bSiguiente
            // 
            this.bSiguiente.Enabled = false;
            this.bSiguiente.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSiguiente.Location = new System.Drawing.Point(711, 90);
            this.bSiguiente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bSiguiente.Name = "bSiguiente";
            this.bSiguiente.Size = new System.Drawing.Size(93, 28);
            this.bSiguiente.TabIndex = 14;
            this.bSiguiente.Text = "Siguiente >";
            this.bSiguiente.UseVisualStyleBackColor = true;
            this.bSiguiente.Click += new System.EventHandler(this.bSiguiente_Click);
            // 
            // bAnterior
            // 
            this.bAnterior.Enabled = false;
            this.bAnterior.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bAnterior.Location = new System.Drawing.Point(610, 90);
            this.bAnterior.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bAnterior.Name = "bAnterior";
            this.bAnterior.Size = new System.Drawing.Size(95, 28);
            this.bAnterior.TabIndex = 13;
            this.bAnterior.Text = "< Anterior";
            this.bAnterior.UseVisualStyleBackColor = true;
            this.bAnterior.Click += new System.EventHandler(this.bAnterior_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LimeGreen;
            this.label6.Location = new System.Drawing.Point(290, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(354, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Formulario Generador de Reporte";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 137);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(957, 250);
            this.dataGridView2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "* Fecha";
            // 
            // bGInforme
            // 
            this.bGInforme.Enabled = false;
            this.bGInforme.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bGInforme.Location = new System.Drawing.Point(827, 90);
            this.bGInforme.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bGInforme.Name = "bGInforme";
            this.bGInforme.Size = new System.Drawing.Size(128, 28);
            this.bGInforme.TabIndex = 10;
            this.bGInforme.Text = "Generar Informe";
            this.bGInforme.UseVisualStyleBackColor = true;
            this.bGInforme.Click += new System.EventHandler(this.bGInforme_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(342, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "* Lote Produccion";
            // 
            // txbFGCodigo
            // 
            this.txbFGCodigo.Location = new System.Drawing.Point(96, 54);
            this.txbFGCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbFGCodigo.Name = "txbFGCodigo";
            this.txbFGCodigo.ReadOnly = true;
            this.txbFGCodigo.Size = new System.Drawing.Size(175, 22);
            this.txbFGCodigo.TabIndex = 0;
            // 
            // txbFGLote
            // 
            this.txbFGLote.Location = new System.Drawing.Point(469, 99);
            this.txbFGLote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbFGLote.Name = "txbFGLote";
            this.txbFGLote.ReadOnly = true;
            this.txbFGLote.Size = new System.Drawing.Size(116, 22);
            this.txbFGLote.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "* Codigo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(392, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "* Version";
            // 
            // txbFGVersion
            // 
            this.txbFGVersion.Location = new System.Drawing.Point(469, 54);
            this.txbFGVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txbFGVersion.Name = "txbFGVersion";
            this.txbFGVersion.ReadOnly = true;
            this.txbFGVersion.Size = new System.Drawing.Size(116, 22);
            this.txbFGVersion.TabIndex = 2;
            // 
            // esterilizacionBindingSource
            // 
            this.esterilizacionBindingSource.DataSource = typeof(SaveToMySQL.Esterilizacion);
            // 
            // bEsterilizacion
            // 
            this.bEsterilizacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bEsterilizacion.Location = new System.Drawing.Point(129, 5);
            this.bEsterilizacion.Name = "bEsterilizacion";
            this.bEsterilizacion.Size = new System.Drawing.Size(145, 30);
            this.bEsterilizacion.TabIndex = 15;
            this.bEsterilizacion.Text = "Editar Esterilizacion";
            this.bEsterilizacion.UseVisualStyleBackColor = true;
            // 
            // bBuscarLote
            // 
            this.bBuscarLote.Enabled = false;
            this.bBuscarLote.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBuscarLote.Location = new System.Drawing.Point(827, 48);
            this.bBuscarLote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bBuscarLote.Name = "bBuscarLote";
            this.bBuscarLote.Size = new System.Drawing.Size(128, 28);
            this.bBuscarLote.TabIndex = 16;
            this.bBuscarLote.Text = "Buscar Lote";
            this.bBuscarLote.UseVisualStyleBackColor = true;
            this.bBuscarLote.Click += new System.EventHandler(this.bBuscarLote_Click);
            // 
            // dateTimePickerBuscarLote
            // 
            this.dateTimePickerBuscarLote.Location = new System.Drawing.Point(610, 54);
            this.dateTimePickerBuscarLote.Name = "dateTimePickerBuscarLote";
            this.dateTimePickerBuscarLote.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerBuscarLote.TabIndex = 17;
            // 
            // FormGeneradordeInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.bEsterilizacion);
            this.Controls.Add(this.panelGeneradorInforme);
            this.Controls.Add(this.bGenerarInforme);
            this.Controls.Add(this.bRegistrarLote);
            this.Controls.Add(this.panelRegistrarLote);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGeneradordeInforme";
            this.Text = "FormGeneradordeInforme";
            this.Load += new System.EventHandler(this.FormGeneradordeInforme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelRegistrarLote.ResumeLayout(false);
            this.panelRegistrarLote.PerformLayout();
            this.panelGeneradorInforme.ResumeLayout(false);
            this.panelGeneradorInforme.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esterilizacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbLote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button bGuardar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource esterilizacionBindingSource;
        private System.Windows.Forms.Panel panelRegistrarLote;
        private System.Windows.Forms.Button bRegistrarLote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bGenerarInforme;
        private System.Windows.Forms.Panel panelGeneradorInforme;
        private System.Windows.Forms.TextBox txbFGFecha;
        private System.Windows.Forms.Button bSiguiente;
        private System.Windows.Forms.Button bAnterior;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bGInforme;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbFGCodigo;
        private System.Windows.Forms.TextBox txbFGLote;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbFGVersion;
        private System.Windows.Forms.DateTimePicker dateTimePickerBuscarLote;
        private System.Windows.Forms.Button bBuscarLote;
        private System.Windows.Forms.Button bEsterilizacion;
    }
}