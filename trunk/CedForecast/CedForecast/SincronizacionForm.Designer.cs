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
            this.VentaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ProyeccionCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ArticuloProgressBar = new System.Windows.Forms.ProgressBar();
            this.ClienteProgressBar = new System.Windows.Forms.ProgressBar();
            this.CuentaProgressBar = new System.Windows.Forms.ProgressBar();
            this.VentaProgressBar = new System.Windows.Forms.ProgressBar();
            this.ZonaProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProyeccionProgressBar = new System.Windows.Forms.ProgressBar();
            this.RollingForecastProgressBar = new System.Windows.Forms.ProgressBar();
            this.RollingForecastCheckBox = new System.Windows.Forms.CheckBox();
            this.ProyeccionDateTimePicker = new System.Windows.Forms.DateTimePicker();
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
            this.SincronizarButton.Image = ((System.Drawing.Image)(resources.GetObject("SincronizarButton.Image")));
            this.SincronizarButton.Location = new System.Drawing.Point(12, 270);
            this.SincronizarButton.Name = "SincronizarButton";
            this.SincronizarButton.Size = new System.Drawing.Size(101, 23);
            this.SincronizarButton.TabIndex = 5;
            this.SincronizarButton.Text = "Sincronizar";
            this.SincronizarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SincronizarButton.UseVisualStyleBackColor = true;
            this.SincronizarButton.Click += new System.EventHandler(this.SincronizarButton_Click);
            // 
            // SalirButton
            // 
            this.SalirButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SalirButton.Image = ((System.Drawing.Image)(resources.GetObject("SalirButton.Image")));
            this.SalirButton.Location = new System.Drawing.Point(119, 270);
            this.SalirButton.Name = "SalirButton";
            this.SalirButton.Size = new System.Drawing.Size(52, 23);
            this.SalirButton.TabIndex = 6;
            this.SalirButton.Text = "Salir";
            this.SalirButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SalirButton.UseVisualStyleBackColor = true;
            // 
            // VentaDateTimePicker
            // 
            this.VentaDateTimePicker.CustomFormat = "MM/yyyy";
            this.VentaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.VentaDateTimePicker.Location = new System.Drawing.Point(113, 121);
            this.VentaDateTimePicker.Name = "VentaDateTimePicker";
            this.VentaDateTimePicker.Size = new System.Drawing.Size(79, 20);
            this.VentaDateTimePicker.TabIndex = 7;
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
            // ProyeccionCheckBox
            // 
            this.ProyeccionCheckBox.AutoSize = true;
            this.ProyeccionCheckBox.Enabled = false;
            this.ProyeccionCheckBox.Location = new System.Drawing.Point(12, 207);
            this.ProyeccionCheckBox.Name = "ProyeccionCheckBox";
            this.ProyeccionCheckBox.Size = new System.Drawing.Size(108, 17);
            this.ProyeccionCheckBox.TabIndex = 9;
            this.ProyeccionCheckBox.Text = "Proyeccion anual";
            this.ProyeccionCheckBox.UseVisualStyleBackColor = true;
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
            // ArticuloProgressBar
            // 
            this.ArticuloProgressBar.Location = new System.Drawing.Point(198, 51);
            this.ArticuloProgressBar.Name = "ArticuloProgressBar";
            this.ArticuloProgressBar.Size = new System.Drawing.Size(159, 17);
            this.ArticuloProgressBar.TabIndex = 19;
            this.ArticuloProgressBar.Visible = false;
            // 
            // ClienteProgressBar
            // 
            this.ClienteProgressBar.Location = new System.Drawing.Point(198, 74);
            this.ClienteProgressBar.Name = "ClienteProgressBar";
            this.ClienteProgressBar.Size = new System.Drawing.Size(159, 17);
            this.ClienteProgressBar.TabIndex = 20;
            this.ClienteProgressBar.Visible = false;
            // 
            // CuentaProgressBar
            // 
            this.CuentaProgressBar.Location = new System.Drawing.Point(198, 98);
            this.CuentaProgressBar.Name = "CuentaProgressBar";
            this.CuentaProgressBar.Size = new System.Drawing.Size(159, 17);
            this.CuentaProgressBar.TabIndex = 21;
            this.CuentaProgressBar.Visible = false;
            // 
            // VentaProgressBar
            // 
            this.VentaProgressBar.Location = new System.Drawing.Point(198, 122);
            this.VentaProgressBar.Name = "VentaProgressBar";
            this.VentaProgressBar.Size = new System.Drawing.Size(159, 17);
            this.VentaProgressBar.TabIndex = 22;
            this.VentaProgressBar.Visible = false;
            // 
            // ZonaProgressBar
            // 
            this.ZonaProgressBar.Location = new System.Drawing.Point(198, 145);
            this.ZonaProgressBar.Name = "ZonaProgressBar";
            this.ZonaProgressBar.Size = new System.Drawing.Size(159, 17);
            this.ZonaProgressBar.TabIndex = 23;
            this.ZonaProgressBar.Visible = false;
            // 
            // ProyeccionProgressBar
            // 
            this.ProyeccionProgressBar.Location = new System.Drawing.Point(198, 207);
            this.ProyeccionProgressBar.Name = "ProyeccionProgressBar";
            this.ProyeccionProgressBar.Size = new System.Drawing.Size(159, 17);
            this.ProyeccionProgressBar.TabIndex = 24;
            this.ProyeccionProgressBar.Visible = false;
            // 
            // RollingForecastProgressBar
            // 
            this.RollingForecastProgressBar.Location = new System.Drawing.Point(198, 230);
            this.RollingForecastProgressBar.Name = "RollingForecastProgressBar";
            this.RollingForecastProgressBar.Size = new System.Drawing.Size(159, 17);
            this.RollingForecastProgressBar.TabIndex = 26;
            this.RollingForecastProgressBar.Visible = false;
            // 
            // RollingForecastCheckBox
            // 
            this.RollingForecastCheckBox.AutoSize = true;
            this.RollingForecastCheckBox.Enabled = false;
            this.RollingForecastCheckBox.Location = new System.Drawing.Point(12, 230);
            this.RollingForecastCheckBox.Name = "RollingForecastCheckBox";
            this.RollingForecastCheckBox.Size = new System.Drawing.Size(102, 17);
            this.RollingForecastCheckBox.TabIndex = 25;
            this.RollingForecastCheckBox.Text = "Rolling Forecast";
            this.RollingForecastCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProyeccionDateTimePicker
            // 
            this.ProyeccionDateTimePicker.CustomFormat = "yyyy";
            this.ProyeccionDateTimePicker.Enabled = false;
            this.ProyeccionDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ProyeccionDateTimePicker.Location = new System.Drawing.Point(124, 206);
            this.ProyeccionDateTimePicker.Name = "ProyeccionDateTimePicker";
            this.ProyeccionDateTimePicker.Size = new System.Drawing.Size(68, 20);
            this.ProyeccionDateTimePicker.TabIndex = 27;
            // 
            // SincronizacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.SalirButton;
            this.ClientSize = new System.Drawing.Size(370, 302);
            this.ControlBox = false;
            this.Controls.Add(this.ProyeccionDateTimePicker);
            this.Controls.Add(this.RollingForecastProgressBar);
            this.Controls.Add(this.RollingForecastCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProyeccionProgressBar);
            this.Controls.Add(this.ZonaProgressBar);
            this.Controls.Add(this.VentaProgressBar);
            this.Controls.Add(this.CuentaProgressBar);
            this.Controls.Add(this.ClienteProgressBar);
            this.Controls.Add(this.ArticuloProgressBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProyeccionCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VentaDateTimePicker);
            this.Controls.Add(this.SalirButton);
            this.Controls.Add(this.SincronizarButton);
            this.Controls.Add(this.ZonaCheckBox);
            this.Controls.Add(this.VentaCheckBox);
            this.Controls.Add(this.CuentaCheckBox);
            this.Controls.Add(this.ClienteCheckBox);
            this.Controls.Add(this.ArticuloCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SincronizacionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.DateTimePicker VentaDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ProyeccionCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar ArticuloProgressBar;
        private System.Windows.Forms.ProgressBar ClienteProgressBar;
        private System.Windows.Forms.ProgressBar CuentaProgressBar;
        private System.Windows.Forms.ProgressBar VentaProgressBar;
        private System.Windows.Forms.ProgressBar ZonaProgressBar;
        private System.Windows.Forms.ProgressBar ProyeccionProgressBar;
        private System.Windows.Forms.ProgressBar RollingForecastProgressBar;
        private System.Windows.Forms.CheckBox RollingForecastCheckBox;
        private System.Windows.Forms.DateTimePicker ProyeccionDateTimePicker;
    }
}