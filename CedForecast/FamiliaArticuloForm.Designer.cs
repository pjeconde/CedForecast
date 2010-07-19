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
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamiliaArticuloForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AltaUiButton = new Janus.Windows.EditControls.UIButton();
            this.BajaUiButton = new Janus.Windows.EditControls.UIButton();
            this.EnviarAUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.MaximizarUiButton = new Janus.Windows.EditControls.UIButton();
            this.MinimizarUiButton = new Janus.Windows.EditControls.UIButton();
            this.SalirUiButton = new Janus.Windows.EditControls.UIButton();
            this.AceptarUiButton = new Janus.Windows.EditControls.UIButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ArticulosGridEX = new Janus.Windows.GridEX.GridEX();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DescripcionLabel = new System.Windows.Forms.Label();
            this.DescrFamiliaArticuloEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            this.IdLabel = new System.Windows.Forms.Label();
            this.IdFamiliaArticuloEditBox = new Janus.Windows.GridEX.EditControls.EditBox();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiCommandManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiContextMenu)).BeginInit();
            this.FondoNicePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArticulosGridEX)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnviarAUiCommandManager
            // 
            this.EnviarAUiCommandManager.CommandsStateStyles.FormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.EnviarAUiCommandManager.CommandsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.EnviarAUiCommandManager.CommandClick += new Janus.Windows.UI.CommandBars.CommandEventHandler(this.EnviarAUiCommandManager_CommandClick);
            // 
            // EnviarAUiContextMenu
            // 
            this.EnviarAUiContextMenu.UseThemes = Janus.Windows.UI.InheritableBoolean.False;
            this.EnviarAUiContextMenu.VisualStyle = Janus.Windows.UI.VisualStyle.Standard;
            // 
            // FondoNicePanel
            // 
            this.FondoNicePanel.Controls.Add(this.panel4);
            this.FondoNicePanel.Size = new System.Drawing.Size(572, 598);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AltaUiButton);
            this.panel1.Controls.Add(this.BajaUiButton);
            this.panel1.Controls.Add(this.EnviarAUiButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(467, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 457);
            this.panel1.TabIndex = 29;
            // 
            // AltaUiButton
            // 
            this.AltaUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.AltaUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AltaUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.AltaUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("AltaUiButton.Icon")));
            this.AltaUiButton.Location = new System.Drawing.Point(7, 6);
            this.AltaUiButton.Name = "AltaUiButton";
            this.AltaUiButton.ShowFocusRectangle = false;
            this.AltaUiButton.Size = new System.Drawing.Size(88, 24);
            this.AltaUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.AltaUiButton.TabIndex = 22;
            this.AltaUiButton.Text = "Agregar";
            this.AltaUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.AltaUiButton.UseThemes = false;
            this.AltaUiButton.Click += new System.EventHandler(this.AltaUiButton_Click);
            // 
            // BajaUiButton
            // 
            this.BajaUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.BajaUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BajaUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.BajaUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("BajaUiButton.Icon")));
            this.BajaUiButton.Location = new System.Drawing.Point(7, 30);
            this.BajaUiButton.Name = "BajaUiButton";
            this.BajaUiButton.ShowFocusRectangle = false;
            this.BajaUiButton.Size = new System.Drawing.Size(88, 24);
            this.BajaUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.BajaUiButton.TabIndex = 23;
            this.BajaUiButton.Text = "Eliminar";
            this.BajaUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.BajaUiButton.UseThemes = false;
            this.BajaUiButton.Click += new System.EventHandler(this.BajaUiButton_Click);
            // 
            // EnviarAUiButton
            // 
            this.EnviarAUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.EnviarAUiButton.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton;
            this.EnviarAUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnviarAUiButton.DropDownContextMenu = this.EnviarAUiContextMenu;
            this.EnviarAUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.EnviarAUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("EnviarAUiButton.Icon")));
            this.EnviarAUiButton.Location = new System.Drawing.Point(7, 54);
            this.EnviarAUiButton.Name = "EnviarAUiButton";
            this.EnviarAUiButton.ShowFocusRectangle = false;
            this.EnviarAUiButton.Size = new System.Drawing.Size(88, 24);
            this.EnviarAUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.EnviarAUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.EnviarAUiButton.TabIndex = 27;
            this.EnviarAUiButton.Text = "Enviar a";
            this.EnviarAUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.EnviarAUiButton.UseThemes = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.AceptarUiButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 563);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 3, 5, 3);
            this.panel2.Size = new System.Drawing.Size(567, 30);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.MaximizarUiButton);
            this.panel3.Controls.Add(this.MinimizarUiButton);
            this.panel3.Controls.Add(this.SalirUiButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(467, 3);
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
            this.MaximizarUiButton.Click += new System.EventHandler(this.MaxMinUiButton_Click);
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
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 30, 0, 5);
            this.panel4.Size = new System.Drawing.Size(572, 598);
            this.panel4.TabIndex = 30;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Transparent;
            this.panel7.Controls.Add(this.ArticulosGridEX);
            this.panel7.Controls.Add(this.panel1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(5, 106);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(79, 0, 0, 0);
            this.panel7.Size = new System.Drawing.Size(567, 457);
            this.panel7.TabIndex = 10;
            // 
            // ArticulosGridEX
            // 
            this.ArticulosGridEX.AcceptsEscape = false;
            this.ArticulosGridEX.AllowColumnDrag = false;
            this.ArticulosGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.ArticulosGridEX.AlternatingColors = true;
            this.ArticulosGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.ArticulosGridEX.BackColor = System.Drawing.Color.PeachPuff;
            this.ArticulosGridEX.BackgroundImageDrawMode = Janus.Windows.GridEX.BackgroundImageDrawMode.None;
            this.ArticulosGridEX.BlendColor = System.Drawing.Color.White;
            this.ArticulosGridEX.ControlStyle.ControlColor = System.Drawing.Color.PeachPuff;
            this.ArticulosGridEX.ControlStyle.ScrollBarColor = System.Drawing.Color.PeachPuff;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.ArticulosGridEX.DesignTimeLayout = gridEXLayout1;
            this.ArticulosGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArticulosGridEX.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular;
            this.ArticulosGridEX.FlatBorderColor = System.Drawing.Color.Brown;
            this.ArticulosGridEX.FocusCellFormatStyle.BackColor = System.Drawing.Color.Gold;
            this.ArticulosGridEX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ArticulosGridEX.GridLines = Janus.Windows.GridEX.GridLines.Vertical;
            this.ArticulosGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.ArticulosGridEX.GroupByBoxVisible = false;
            this.ArticulosGridEX.GroupRowFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.ArticulosGridEX.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.PeachPuff;
            this.ArticulosGridEX.GroupTotals = Janus.Windows.GridEX.GroupTotals.Default;
            this.ArticulosGridEX.HeaderFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.ArticulosGridEX.HeaderFormatStyle.BackColorGradient = System.Drawing.Color.PeachPuff;
            this.ArticulosGridEX.HeaderFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.ArticulosGridEX.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ArticulosGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.ArticulosGridEX.Location = new System.Drawing.Point(79, 0);
            this.ArticulosGridEX.Name = "ArticulosGridEX";
            this.ArticulosGridEX.RowFormatStyle.BackColor = System.Drawing.Color.White;
            this.ArticulosGridEX.SelectedFormatStyle.BackColor = System.Drawing.Color.Gold;
            this.ArticulosGridEX.SelectedFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.ArticulosGridEX.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ArticulosGridEX.SelectedInactiveFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.ArticulosGridEX.Size = new System.Drawing.Size(388, 457);
            this.ArticulosGridEX.TabIndex = 7;
            this.ArticulosGridEX.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None;
            this.ArticulosGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.DescripcionLabel);
            this.panel5.Controls.Add(this.DescrFamiliaArticuloEditBox);
            this.panel5.Controls.Add(this.IdLabel);
            this.panel5.Controls.Add(this.IdFamiliaArticuloEditBox);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 30);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(567, 76);
            this.panel5.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Artículos que la componen:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.DescrFamiliaArticuloEditBox.Size = new System.Drawing.Size(476, 20);
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
            this.ClientSize = new System.Drawing.Size(572, 598);
            this.Name = "FamiliaArticuloForm";
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiCommandManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiContextMenu)).EndInit();
            this.FondoNicePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArticulosGridEX)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public Janus.Windows.EditControls.UIButton AltaUiButton;
        protected Janus.Windows.EditControls.UIButton BajaUiButton;
        private System.Windows.Forms.Panel panel2;
        private Janus.Windows.EditControls.UIButton MinimizarUiButton;
        private Janus.Windows.EditControls.UIButton MaximizarUiButton;
        protected Janus.Windows.EditControls.UIButton EnviarAUiButton;
        private System.Windows.Forms.Panel panel4;
        private Janus.Windows.GridEX.GridEX ArticulosGridEX;
        private System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.Label DescripcionLabel;
        private Janus.Windows.GridEX.EditControls.EditBox DescrFamiliaArticuloEditBox;
        private System.Windows.Forms.Label IdLabel;
        private Janus.Windows.GridEX.EditControls.EditBox IdFamiliaArticuloEditBox;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        public Janus.Windows.EditControls.UIButton SalirUiButton;
        protected Janus.Windows.EditControls.UIButton AceptarUiButton;
        private System.Windows.Forms.Panel panel3;
    }
}
