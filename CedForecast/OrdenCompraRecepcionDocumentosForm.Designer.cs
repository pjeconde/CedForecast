namespace CedForecast
{
    partial class OrdenCompraRecepcionDocumentosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenCompraRecepcionDocumentosForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.AceptarUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SalirUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.FacturaEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NroConocimientoEmbarqueEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.FechaRecepcionDocumentosCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
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
            this.FondoNicePanel.Size = new System.Drawing.Size(317, 143);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AceptarUiButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 108);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.panel2.Size = new System.Drawing.Size(312, 30);
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
            this.AceptarUiButton.TabIndex = 42;
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
            this.panel3.Location = new System.Drawing.Point(225, 3);
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
            this.SalirUiButton.TabIndex = 20;
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
            this.panel4.Size = new System.Drawing.Size(317, 143);
            this.panel4.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.FacturaEditBox);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.NroConocimientoEmbarqueEditBox);
            this.panel5.Controls.Add(this.FechaRecepcionDocumentosCalendarCombo);
            this.panel5.Controls.Add(this.FechaLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(312, 108);
            this.panel5.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 9092;
            this.label1.Text = "Nº Factura";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FacturaEditBox
            // 
            this.FacturaEditBox.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.FacturaEditBox.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.FacturaEditBox.BackColor = System.Drawing.Color.White;
            this.FacturaEditBox.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None;
            this.FacturaEditBox.FlatBorderColor = System.Drawing.Color.Black;
            this.FacturaEditBox.ForeColor = System.Drawing.Color.Black;
            this.FacturaEditBox.Location = new System.Drawing.Point(176, 25);
            this.FacturaEditBox.Name = "FacturaEditBox";
            this.FacturaEditBox.Size = new System.Drawing.Size(124, 20);
            this.FacturaEditBox.TabIndex = 9091;
            this.FacturaEditBox.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.FacturaEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 20);
            this.label2.TabIndex = 9090;
            this.label2.Text = "Nº Conocimiento de Embarque";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NroConocimientoEmbarqueEditBox
            // 
            this.NroConocimientoEmbarqueEditBox.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.NroConocimientoEmbarqueEditBox.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.NroConocimientoEmbarqueEditBox.BackColor = System.Drawing.Color.White;
            this.NroConocimientoEmbarqueEditBox.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None;
            this.NroConocimientoEmbarqueEditBox.FlatBorderColor = System.Drawing.Color.Black;
            this.NroConocimientoEmbarqueEditBox.ForeColor = System.Drawing.Color.Black;
            this.NroConocimientoEmbarqueEditBox.Location = new System.Drawing.Point(176, 0);
            this.NroConocimientoEmbarqueEditBox.Name = "NroConocimientoEmbarqueEditBox";
            this.NroConocimientoEmbarqueEditBox.Size = new System.Drawing.Size(124, 20);
            this.NroConocimientoEmbarqueEditBox.TabIndex = 9089;
            this.NroConocimientoEmbarqueEditBox.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.NroConocimientoEmbarqueEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // FechaRecepcionDocumentosCalendarCombo
            // 
            this.FechaRecepcionDocumentosCalendarCombo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.FechaRecepcionDocumentosCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2011, 4, 1, 0, 0, 0, 0);
            this.FechaRecepcionDocumentosCalendarCombo.DropDownCalendar.Location = new System.Drawing.Point(0, 0);
            this.FechaRecepcionDocumentosCalendarCombo.DropDownCalendar.Name = "";
            this.FechaRecepcionDocumentosCalendarCombo.DropDownCalendar.Size = new System.Drawing.Size(170, 173);
            this.FechaRecepcionDocumentosCalendarCombo.DropDownCalendar.TabIndex = 0;
            this.FechaRecepcionDocumentosCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.FechaRecepcionDocumentosCalendarCombo.FlatBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.FechaRecepcionDocumentosCalendarCombo.ForeColor = System.Drawing.Color.Black;
            this.FechaRecepcionDocumentosCalendarCombo.Location = new System.Drawing.Point(176, 50);
            this.FechaRecepcionDocumentosCalendarCombo.Name = "FechaRecepcionDocumentosCalendarCombo";
            this.FechaRecepcionDocumentosCalendarCombo.Size = new System.Drawing.Size(96, 20);
            this.FechaRecepcionDocumentosCalendarCombo.TabIndex = 9078;
            this.FechaRecepcionDocumentosCalendarCombo.ThemedAreas = Janus.Windows.CalendarCombo.ThemedArea.None;
            this.FechaRecepcionDocumentosCalendarCombo.TodayButtonText = "Hoy";
            this.FechaRecepcionDocumentosCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // FechaLabel
            // 
            this.FechaLabel.ForeColor = System.Drawing.Color.Navy;
            this.FechaLabel.Location = new System.Drawing.Point(0, 50);
            this.FechaLabel.Name = "FechaLabel";
            this.FechaLabel.Size = new System.Drawing.Size(172, 20);
            this.FechaLabel.TabIndex = 9077;
            this.FechaLabel.Text = "Fecha recepción documentos";
            this.FechaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OrdenCompraRecepcionDocumentosForm
            // 
            this.ClientSize = new System.Drawing.Size(317, 143);
            this.Name = "OrdenCompraRecepcionDocumentosForm";
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
        private Janus.Windows.CalendarCombo.CalendarCombo FechaRecepcionDocumentosCalendarCombo;
        private System.Windows.Forms.Label FechaLabel;
        protected System.Windows.Forms.Label label2;
        private Janus.Windows.GridEX.EditControls.EditBox NroConocimientoEmbarqueEditBox;
        protected System.Windows.Forms.Label label1;
        private Janus.Windows.GridEX.EditControls.EditBox FacturaEditBox;
        protected Janus.Windows.EditControls.UIButton AceptarUiButton;
        public Janus.Windows.EditControls.UIButton SalirUiButton;
    }
}