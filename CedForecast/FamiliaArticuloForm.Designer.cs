namespace CedForecast
{
    partial class FamiliaArticuloForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamiliaArticuloForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MaximizarUiButton = new Janus.Windows.EditControls.UIButton();
            this.MinimizarUiButton = new Janus.Windows.EditControls.UIButton();
            this.SalirUiButton = new Janus.Windows.EditControls.UIButton();
            this.AceptarUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DescripcionLabel = new System.Windows.Forms.Label();
            this.DescrFamiliaArticuloEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.IdFamiliaArticuloEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
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
            this.FondoNicePanel.Size = new System.Drawing.Size(407, 116);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.AceptarUiButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 81);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.panel2.Size = new System.Drawing.Size(402, 30);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.MaximizarUiButton);
            this.panel3.Controls.Add(this.MinimizarUiButton);
            this.panel3.Controls.Add(this.SalirUiButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(302, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(95, 24);
            this.panel3.TabIndex = 39;
            // 
            // MaximizarUiButton
            // 
            this.MaximizarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.MaximizarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizarUiButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.MaximizarUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.MaximizarUiButton.Image = ((System.Drawing.Image)(resources.GetObject("MaximizarUiButton.Image")));
            this.MaximizarUiButton.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Center;
            this.MaximizarUiButton.Location = new System.Drawing.Point(20, 0);
            this.MaximizarUiButton.Name = "MaximizarUiButton";
            this.MaximizarUiButton.ShowFocusRectangle = false;
            this.MaximizarUiButton.Size = new System.Drawing.Size(20, 24);
            this.MaximizarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.MaximizarUiButton.TabIndex = 35;
            this.MaximizarUiButton.Tag = "Max";
            this.MaximizarUiButton.UseThemes = false;
            this.MaximizarUiButton.Click += new System.EventHandler(this.MaximizarUiButton_Click);
            // 
            // MinimizarUiButton
            // 
            this.MinimizarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.MinimizarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizarUiButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.MinimizarUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.MinimizarUiButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimizarUiButton.Image")));
            this.MinimizarUiButton.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.MinimizarUiButton.Location = new System.Drawing.Point(0, 0);
            this.MinimizarUiButton.Name = "MinimizarUiButton";
            this.MinimizarUiButton.ShowFocusRectangle = false;
            this.MinimizarUiButton.Size = new System.Drawing.Size(20, 24);
            this.MinimizarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.MinimizarUiButton.TabIndex = 36;
            this.MinimizarUiButton.Tag = "Min";
            this.MinimizarUiButton.UseThemes = false;
            this.MinimizarUiButton.Visible = false;
            this.MinimizarUiButton.Click += new System.EventHandler(this.MinimizarUiButton_Click);
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
            this.SalirUiButton.Location = new System.Drawing.Point(17, 0);
            this.SalirUiButton.Name = "SalirUiButton";
            this.SalirUiButton.ShowFocusRectangle = false;
            this.SalirUiButton.Size = new System.Drawing.Size(78, 24);
            this.SalirUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.SalirUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.SalirUiButton.TabIndex = 38;
            this.SalirUiButton.TabStop = false;
            this.SalirUiButton.Text = "Cancelar";
            this.SalirUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Far;
            this.SalirUiButton.UseThemes = false;
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
            this.AceptarUiButton.TabIndex = 37;
            this.AceptarUiButton.TabStop = false;
            this.AceptarUiButton.Text = "Aceptar";
            this.AceptarUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.AceptarUiButton.UseThemes = false;
            this.AceptarUiButton.Click += new System.EventHandler(this.AceptarUiButton_Click);
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
            this.panel4.Size = new System.Drawing.Size(407, 116);
            this.panel4.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.DescripcionLabel);
            this.panel5.Controls.Add(this.DescrFamiliaArticuloEditBox);
            this.panel5.Controls.Add(this.IdLabel);
            this.panel5.Controls.Add(this.IdFamiliaArticuloEditBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(5, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(402, 81);
            this.panel5.TabIndex = 8;
            // 
            // DescripcionLabel
            // 
            this.DescripcionLabel.ForeColor = System.Drawing.Color.Navy;
            this.DescripcionLabel.Location = new System.Drawing.Point(9, 27);
            this.DescripcionLabel.Name = "DescripcionLabel";
            this.DescripcionLabel.Size = new System.Drawing.Size(64, 20);
            this.DescripcionLabel.TabIndex = 4;
            this.DescripcionLabel.Text = "Descripción";
            this.DescripcionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DescrFamiliaArticuloEditBox
            // 
            this.DescrFamiliaArticuloEditBox.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.DescrFamiliaArticuloEditBox.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.DescrFamiliaArticuloEditBox.BackColor = System.Drawing.Color.White;
            this.DescrFamiliaArticuloEditBox.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None;
            this.DescrFamiliaArticuloEditBox.FlatBorderColor = System.Drawing.Color.Black;
            this.DescrFamiliaArticuloEditBox.ForeColor = System.Drawing.Color.Black;
            this.DescrFamiliaArticuloEditBox.Location = new System.Drawing.Point(79, 27);
            this.DescrFamiliaArticuloEditBox.Name = "DescrFamiliaArticuloEditBox";
            this.DescrFamiliaArticuloEditBox.Size = new System.Drawing.Size(303, 20);
            this.DescrFamiliaArticuloEditBox.TabIndex = 5;
            this.DescrFamiliaArticuloEditBox.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.DescrFamiliaArticuloEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // IdLabel
            // 
            this.IdLabel.CausesValidation = false;
            this.IdLabel.ForeColor = System.Drawing.Color.Navy;
            this.IdLabel.Location = new System.Drawing.Point(9, 3);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(64, 20);
            this.IdLabel.TabIndex = 2;
            this.IdLabel.Text = "Id";
            this.IdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IdFamiliaArticuloEditBox
            // 
            this.IdFamiliaArticuloEditBox.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.IdFamiliaArticuloEditBox.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.IdFamiliaArticuloEditBox.BackColor = System.Drawing.Color.White;
            this.IdFamiliaArticuloEditBox.ControlThemedAreas = Janus.Windows.GridEX.ControlThemedAreas.None;
            this.IdFamiliaArticuloEditBox.FlatBorderColor = System.Drawing.Color.Black;
            this.IdFamiliaArticuloEditBox.ForeColor = System.Drawing.Color.Black;
            this.IdFamiliaArticuloEditBox.Location = new System.Drawing.Point(79, 3);
            this.IdFamiliaArticuloEditBox.Name = "IdFamiliaArticuloEditBox";
            this.IdFamiliaArticuloEditBox.Size = new System.Drawing.Size(120, 20);
            this.IdFamiliaArticuloEditBox.TabIndex = 3;
            this.IdFamiliaArticuloEditBox.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
            this.IdFamiliaArticuloEditBox.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // FamiliaArticuloForm
            // 
            this.ClientSize = new System.Drawing.Size(407, 116);
            this.Name = "FamiliaArticuloForm";
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
        private Janus.Windows.EditControls.UIButton MinimizarUiButton;
        private Janus.Windows.EditControls.UIButton MaximizarUiButton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.Label DescripcionLabel;
        private Janus.Windows.GridEX.EditControls.EditBox DescrFamiliaArticuloEditBox;
        private System.Windows.Forms.Label IdLabel;
        private Janus.Windows.GridEX.EditControls.EditBox IdFamiliaArticuloEditBox;
        public Janus.Windows.EditControls.UIButton SalirUiButton;
        protected Janus.Windows.EditControls.UIButton AceptarUiButton;
        private System.Windows.Forms.Panel panel3;
    }
}
