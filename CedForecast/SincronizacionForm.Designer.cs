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
            this.ArticuloCheckBox = new System.Windows.Forms.CheckBox();
            this.ClienteCheckBox = new System.Windows.Forms.CheckBox();
            this.CuentaCheckBox = new System.Windows.Forms.CheckBox();
            this.VentaCheckBox = new System.Windows.Forms.CheckBox();
            this.ZonaCheckBox = new System.Windows.Forms.CheckBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.SalirButton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ArticuloCheckBox
            // 
            this.ArticuloCheckBox.AutoSize = true;
            this.ArticuloCheckBox.Location = new System.Drawing.Point(12, 38);
            this.ArticuloCheckBox.Name = "ArticuloCheckBox";
            this.ArticuloCheckBox.Size = new System.Drawing.Size(68, 17);
            this.ArticuloCheckBox.TabIndex = 0;
            this.ArticuloCheckBox.Text = "Artículos";
            this.ArticuloCheckBox.UseVisualStyleBackColor = true;
            // 
            // ClienteCheckBox
            // 
            this.ClienteCheckBox.AutoSize = true;
            this.ClienteCheckBox.Location = new System.Drawing.Point(12, 61);
            this.ClienteCheckBox.Name = "ClienteCheckBox";
            this.ClienteCheckBox.Size = new System.Drawing.Size(63, 17);
            this.ClienteCheckBox.TabIndex = 1;
            this.ClienteCheckBox.Text = "Clientes";
            this.ClienteCheckBox.UseVisualStyleBackColor = true;
            // 
            // CuentaCheckBox
            // 
            this.CuentaCheckBox.AutoSize = true;
            this.CuentaCheckBox.Location = new System.Drawing.Point(12, 85);
            this.CuentaCheckBox.Name = "CuentaCheckBox";
            this.CuentaCheckBox.Size = new System.Drawing.Size(83, 17);
            this.CuentaCheckBox.TabIndex = 2;
            this.CuentaCheckBox.Text = "Vendedores";
            this.CuentaCheckBox.UseVisualStyleBackColor = true;
            // 
            // VentaCheckBox
            // 
            this.VentaCheckBox.AutoSize = true;
            this.VentaCheckBox.Location = new System.Drawing.Point(12, 109);
            this.VentaCheckBox.Name = "VentaCheckBox";
            this.VentaCheckBox.Size = new System.Drawing.Size(101, 17);
            this.VentaCheckBox.TabIndex = 3;
            this.VentaCheckBox.Text = "Ventas del mes:";
            this.VentaCheckBox.UseVisualStyleBackColor = true;
            // 
            // ZonaCheckBox
            // 
            this.ZonaCheckBox.AutoSize = true;
            this.ZonaCheckBox.Location = new System.Drawing.Point(12, 133);
            this.ZonaCheckBox.Name = "ZonaCheckBox";
            this.ZonaCheckBox.Size = new System.Drawing.Size(56, 17);
            this.ZonaCheckBox.TabIndex = 4;
            this.ZonaCheckBox.Text = "Zonas";
            this.ZonaCheckBox.UseVisualStyleBackColor = true;
            // 
            // AceptarButton
            // 
            this.AceptarButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AceptarButton.Location = new System.Drawing.Point(12, 171);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(75, 23);
            this.AceptarButton.TabIndex = 5;
            this.AceptarButton.Text = "Sincronizar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            // 
            // SalirButton
            // 
            this.SalirButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SalirButton.Location = new System.Drawing.Point(94, 171);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(75, 23);
            this.SalirButton.TabIndex = 6;
            this.SalirButton.Text = "Salir";
            this.SalirButton.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "mm/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 109);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(62, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Envio de novedades del sistema Bejerman al sistema ForecastWeb";
            // 
            // SincronizacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 201);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.SalirButton);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.ZonaCheckBox);
            this.Controls.Add(this.VentaCheckBox);
            this.Controls.Add(this.CuentaCheckBox);
            this.Controls.Add(this.ClienteCheckBox);
            this.Controls.Add(this.ArticuloCheckBox);
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
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.Button SalirButton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
    }
}