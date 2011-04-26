namespace CedForecast
{
    partial class TablaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablaForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.AceptarUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SalirUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DescrEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.IdEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.DescripcionLabel = new System.Windows.Forms.Label();
            this.IdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiCommandManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiContextMenu)).BeginInit();
            this.FondoNicePanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnviarAUiCommandManager
            // 
            this.EnviarAUiCommandManager.CommandsStateStyles.FormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.EnviarAUiCommandManager.CommandsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            // 
            // EnviarAUiContextMenu
            // 
            this.EnviarAUiContextMenu.UseThemes = Janus.Windows.UI.InheritableBoolean.False;
            this.EnviarAUiContextMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Standard;
            // 
            // FondoNicePanel
            // 
            this.FondoNicePanel.Controls.Add(this.panel4);
            this.FondoNicePanel.Size = new System.Drawing.Size(351, 118);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AceptarUiButton);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 83);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.panel2.Size = new System.Drawing.Size(346, 30);
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
            this.AceptarUiButton.TabIndex = 40;
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
            this.panel3.Location = new System.Drawing.Point(259, 3);
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
            this.SalirUiButton.TabIndex = 18;
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
            this.panel4.Size = new System.Drawing.Size(351, 118);
            this.panel4.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DescrEditBox);
            this.panel5.Controls.Add(this.IdEditBox);
            this.panel5.Controls.Add(this.DescripcionLabel);
            this.panel5.Controls.Add(this.IdLabel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(346, 83);
            this.panel5.TabIndex = 8;
            // 
            // DescrEditBox
            // 
            this.DescrEditBox.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.DescrEditBox.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.DescrEditBox.BackColor = System.Drawing.Color.White;
            this.DescrEditBox.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None;
            this.DescrEditBox.FlatBorderColor = System.Drawing.Color.Black;
            this.DescrEditBox.ForeColor = System.Drawing.Color.Black;
            this.DescrEditBox.Location = new System.Drawing.Point(79, 29);
            this.DescrEditBox.Name = "DescrEditBox";
            this.DescrEditBox.Size = new System.Drawing.Size(250, 20);
            this.DescrEditBox.TabIndex = 5;
            this.DescrEditBox.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.DescrEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // IdEditBox
            // 
            this.IdEditBox.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.IdEditBox.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.IdEditBox.BackColor = System.Drawing.Color.White;
            this.IdEditBox.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None;
            this.IdEditBox.FlatBorderColor = System.Drawing.Color.Black;
            this.IdEditBox.ForeColor = System.Drawing.Color.Black;
            this.IdEditBox.Location = new System.Drawing.Point(79, 3);
            this.IdEditBox.Name = "IdEditBox";
            this.IdEditBox.Size = new System.Drawing.Size(36, 20);
            this.IdEditBox.TabIndex = 4;
            this.IdEditBox.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.IdEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // DescripcionLabel
            // 
            this.DescripcionLabel.ForeColor = System.Drawing.Color.Navy;
            this.DescripcionLabel.Location = new System.Drawing.Point(3, 27);
            this.DescripcionLabel.Name = "DescripcionLabel";
            this.DescripcionLabel.Size = new System.Drawing.Size(70, 20);
            this.DescripcionLabel.TabIndex = 4;
            this.DescripcionLabel.Text = "Descripción";
            this.DescripcionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IdLabel
            // 
            this.IdLabel.CausesValidation = false;
            this.IdLabel.ForeColor = System.Drawing.Color.Navy;
            this.IdLabel.Location = new System.Drawing.Point(3, 3);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(70, 20);
            this.IdLabel.TabIndex = 2;
            this.IdLabel.Text = "Id";
            this.IdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TablaForm
            // 
            this.ClientSize = new System.Drawing.Size(351, 118);
            this.Name = "TablaForm";
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiCommandManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiContextMenu)).EndInit();
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
        protected System.Windows.Forms.Label DescripcionLabel;
        private System.Windows.Forms.Label IdLabel;
        private System.Windows.Forms.Panel panel3;
        private Janus.Windows.GridEX.EditControls.EditBox DescrEditBox;
        private Janus.Windows.GridEX.EditControls.EditBox IdEditBox;
        protected Janus.Windows.EditControls.UIButton AceptarUiButton;
        public Janus.Windows.EditControls.UIButton SalirUiButton;
    }
}