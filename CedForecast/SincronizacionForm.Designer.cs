namespace CedForecast
{
    partial class SincronizacionForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SincronizacionForm));
            this.ArticuloCheckBox = new System.Windows.Forms.CheckBox();
            this.ClienteCheckBox = new System.Windows.Forms.CheckBox();
            this.CuentaCheckBox = new System.Windows.Forms.CheckBox();
            this.VentaCheckBox = new System.Windows.Forms.CheckBox();
            this.ZonaCheckBox = new System.Windows.Forms.CheckBox();
            this.SincronizarButton = new System.Windows.Forms.Button();
            this.SalirButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ForecastCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ArticuloCheckBox
            // 
            this.ArticuloCheckBox.AutoSize = true;
            this.ArticuloCheckBox.Location = new System.Drawing.Point(12, 51);
            this.ArticuloCheckBox.Name = "ArticuloCheckBox";
            this.ArticuloCheckBox.Size = new System.Drawing.Size(68, 17);
            this.ArticuloCheckBox.TabIndex = 0;
            this.ArticuloCheckBox.Text = "Artículos";
            this.ArticuloCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClienteCheckBox
            // 
            this.ClienteCheckBox.AutoSize = true;
            this.ClienteCheckBox.Location = new System.Drawing.Point(12, 74);
            this.ClienteCheckBox.Name = "ClienteCheckBox";
            this.ClienteCheckBox.Size = new System.Drawing.Size(63, 17);
            this.ClienteCheckBox.TabIndex = 1;
            this.ClienteCheckBox.Text = "Clientes";
            this.ClienteCheckBox.UseVisualStyleBackColor = true;
            // 
            // CuentaCheckBox
            // 
            this.CuentaCheckBox.AutoSize = true;
            this.CuentaCheckBox.Location = new System.Drawing.Point(12, 98);
            this.CuentaCheckBox.Name = "CuentaCheckBox";
            this.CuentaCheckBox.Size = new System.Drawing.Size(83, 17);
            this.CuentaCheckBox.TabIndex = 2;
            this.CuentaCheckBox.Text = "Vendedores";
            this.CuentaCheckBox.UseVisualStyleBackColor = true;
            // 
            // VentaCheckBox
            // 
            this.VentaCheckBox.AutoSize = true;
            this.VentaCheckBox.Location = new System.Drawing.Point(12, 122);
            this.VentaCheckBox.Name = "VentaCheckBox";
            this.VentaCheckBox.Size = new System.Drawing.Size(101, 17);
            this.VentaCheckBox.TabIndex = 3;
            this.VentaCheckBox.Text = "Ventas del mes:";
            this.VentaCheckBox.UseVisualStyleBackColor = true;
            // 
            // ZonaCheckBox
            // 
            this.ZonaCheckBox.AutoSize = true;
            this.ZonaCheckBox.Location = new System.Drawing.Point(12, 146);
            this.ZonaCheckBox.Name = "ZonaCheckBox";
            this.ZonaCheckBox.Size = new System.Drawing.Size(56, 17);
            this.ZonaCheckBox.TabIndex = 4;
            this.ZonaCheckBox.Text = "Zonas";
            this.ZonaCheckBox.UseVisualStyleBackColor = true;
            // 
            // SincronizarButton
            // 
            this.SincronizarButton.Location = new System.Drawing.Point(12, 270);
            this.SincronizarButton.Name = "SincronizarButton";
            this.SincronizarButton.Size = new System.Drawing.Size(75, 23);
            this.SincronizarButton.TabIndex = 5;
            this.SincronizarButton.Text = "Sincronizar";
            this.SincronizarButton.UseVisualStyleBackColor = true;
            this.SincronizarButton.Click += new System.EventHandler(this.SincronizarButton_Click);
            // 
            // SalirButton
            // 
            this.SalirButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SalirButton.Location = new System.Drawing.Point(93, 270);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(75, 23);
            this.SalirButton.TabIndex = 6;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(113, 121);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(62, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Envio de novedades de";
            // 
            // ForecastCheckBox
            // 
            this.ForecastCheckBox.AutoSize = true;
            this.ForecastCheckBox.Location = new System.Drawing.Point(12, 207);
            this.ForecastCheckBox.Name = "ForecastCheckBox";
            this.ForecastCheckBox.Size = new System.Drawing.Size(67, 17);
            this.ForecastCheckBox.TabIndex = 9;
            this.ForecastCheckBox.Text = "Forecast";
            this.ForecastCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(127, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bejerman";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "ForecastWeb";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(168, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "ForecastWeb";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Recepción de novedades desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "a";
            // 
            // SincronizacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 302);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ForecastCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.SalirButton);
            this.Controls.Add(this.SincronizarButton);
            this.Controls.Add(this.ZonaCheckBox);
            this.Controls.Add(this.VentaCheckBox);
            this.Controls.Add(this.CuentaCheckBox);
            this.Controls.Add(this.ClienteCheckBox);
            this.Controls.Add(this.ArticuloCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SincronizacionForm";
            this.Text = "Sincronización";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ArticuloCheckBox;
        private System.Windows.Forms.CheckBox ClienteCheckBox;
        private System.Windows.Forms.CheckBox CuentaCheckBox;
        private System.Windows.Forms.CheckBox VentaCheckBox;
        private System.Windows.Forms.CheckBox ZonaCheckBox;
        private System.Windows.Forms.Button SincronizarButton;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ForecastCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}