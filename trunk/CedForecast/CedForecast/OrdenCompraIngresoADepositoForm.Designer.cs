namespace CedForecast
{
    partial class OrdenCompraIngresoADepositoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenCompraIngresoADepositoForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.AceptarUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SalirUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.FechaIngresoDepositoCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.FechaLabel = new System.Windows.Forms.Label();
            this.FondoNicePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // FondoNicePanel
            // 
            this.FondoNicePanel.Controls.Add(this.panel4);
            this.FondoNicePanel.Size = new System.Drawing.Size(286, 90);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AceptarUiButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.panel2.Size = new System.Drawing.Size(281, 30);
            this.panel2.TabIndex = 0;
            // 
            // AceptarUiButton
            // 
            this.AceptarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.AceptarUiButton.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.AceptarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AceptarUiButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AceptarUiButton.FlatBorderColor = System.Drawing.Color.Navy;
            this.AceptarUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("AceptarUiButton.Icon")));
            this.AceptarUiButton.Location = new System.Drawing.Point(0, 3);
            this.AceptarUiButton.Name = "AceptarUiButton";
            this.AceptarUiButton.ShowFocusRectangle = false;
            this.AceptarUiButton.Size = new System.Drawing.Size(73, 24);
            this.AceptarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.AceptarUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.AceptarUiButton.TabIndex = 41;
            this.AceptarUiButton.TabStop = false;
            this.AceptarUiButton.Text = "Aceptar";
            this.AceptarUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.AceptarUiButton.UseThemes = false;
            this.AceptarUiButton.Click += new System.EventHandler(this.AceptarUiButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.SalirUiButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(194, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(82, 24);
            this.panel3.TabIndex = 39;
            // 
            // SalirUiButton
            // 
            this.SalirUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.SalirUiButton.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.SalirUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SalirUiButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.SalirUiButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SalirUiButton.FlatBorderColor = System.Drawing.Color.Navy;
            this.SalirUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("SalirUiButton.Icon")));
            this.SalirUiButton.Location = new System.Drawing.Point(4, 0);
            this.SalirUiButton.Name = "SalirUiButton";
            this.SalirUiButton.ShowFocusRectangle = false;
            this.SalirUiButton.Size = new System.Drawing.Size(78, 24);
            this.SalirUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.SalirUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.SalirUiButton.TabIndex = 19;
            this.SalirUiButton.TabStop = false;
            this.SalirUiButton.Text = "Cancelar";
            this.SalirUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Far;
            this.SalirUiButton.UseThemes = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 30, 0, 5);
            this.panel4.Size = new System.Drawing.Size(286, 90);
            this.panel4.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.FechaIngresoDepositoCalendarCombo);
            this.panel5.Controls.Add(this.FechaLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(281, 55);
            this.panel5.TabIndex = 8;
            // 
            // FechaIngresoDepositoCalendarCombo
            // 
            this.FechaIngresoDepositoCalendarCombo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.FechaIngresoDepositoCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2011, 4, 1, 0, 0, 0, 0);
            this.FechaIngresoDepositoCalendarCombo.DropDownCalendar.Location = new System.Drawing.Point(0, 0);
            this.FechaIngresoDepositoCalendarCombo.DropDownCalendar.Name = "";
            this.FechaIngresoDepositoCalendarCombo.DropDownCalendar.Size = new System.Drawing.Size(170, 173);
            this.FechaIngresoDepositoCalendarCombo.DropDownCalendar.TabIndex = 0;
            this.FechaIngresoDepositoCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.FechaIngresoDepositoCalendarCombo.FlatBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.FechaIngresoDepositoCalendarCombo.ForeColor = System.Drawing.Color.Black;
            this.FechaIngresoDepositoCalendarCombo.Location = new System.Drawing.Point(163, 0);
            this.FechaIngresoDepositoCalendarCombo.Name = "FechaIngresoDepositoCalendarCombo";
            this.FechaIngresoDepositoCalendarCombo.Size = new System.Drawing.Size(96, 20);
            this.FechaIngresoDepositoCalendarCombo.TabIndex = 9078;
            this.FechaIngresoDepositoCalendarCombo.ThemedAreas = Janus.Windows.CalendarCombo.ThemedArea.None;
            this.FechaIngresoDepositoCalendarCombo.TodayButtonText = "Hoy";
            this.FechaIngresoDepositoCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // FechaLabel
            // 
            this.FechaLabel.ForeColor = System.Drawing.Color.Navy;
            this.FechaLabel.Location = new System.Drawing.Point(2, 0);
            this.FechaLabel.Name = "FechaLabel";
            this.FechaLabel.Size = new System.Drawing.Size(157, 20);
            this.FechaLabel.TabIndex = 9077;
            this.FechaLabel.Text = "Fecha de ingreso a depósito";
            this.FechaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OrdenCompraIngresoADepositoForm
            // 
            this.ClientSize = new System.Drawing.Size(286, 90);
            this.Name = "OrdenCompraIngresoADepositoForm";
            this.FondoNicePanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private Janus.Windows.CalendarCombo.CalendarCombo FechaIngresoDepositoCalendarCombo;
        private System.Windows.Forms.Label FechaLabel;
        protected Janus.Windows.EditControls.UIButton AceptarUiButton;
        public Janus.Windows.EditControls.UIButton SalirUiButton;
    }
}