namespace CedForecast
{
    partial class TablaGrillaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TablaGrillaForm));
            Janus.Windows.GridEX.GridEXLayout gridEXLayout3 = new Janus.Windows.GridEX.GridEXLayout();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AltaUiButton = new Janus.Windows.EditControls.UIButton();
            this.BajaUiButton = new Janus.Windows.EditControls.UIButton();
            this.EnviarAUiButton = new Janus.Windows.EditControls.UIButton();
            this.ModificacionUiButton = new Janus.Windows.EditControls.UIButton();
            this.ConsultauiButton = new Janus.Windows.EditControls.UIButton();
            this.MinimizarUiButton = new Janus.Windows.EditControls.UIButton();
            this.MaximizarUiButton = new Janus.Windows.EditControls.UIButton();
            this.SalirUiButton = new Janus.Windows.EditControls.UIButton();
            this.ListaGridEX = new Janus.Windows.GridEX.GridEX();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiCommandManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiContextMenu)).BeginInit();
            this.FondoNicePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListaGridEX)).BeginInit();
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
            this.FondoNicePanel.Controls.Add(this.panel1);
            this.FondoNicePanel.Size = new System.Drawing.Size(422, 230);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(322, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 230);
            this.panel1.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.AltaUiButton);
            this.panel3.Controls.Add(this.BajaUiButton);
            this.panel3.Controls.Add(this.EnviarAUiButton);
            this.panel3.Controls.Add(this.ModificacionUiButton);
            this.panel3.Controls.Add(this.ConsultauiButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 195);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MinimizarUiButton);
            this.panel2.Controls.Add(this.MaximizarUiButton);
            this.panel2.Controls.Add(this.SalirUiButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 35);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.ListaGridEX);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 30, 0, 5);
            this.panel4.Size = new System.Drawing.Size(322, 230);
            this.panel4.TabIndex = 29;
            // 
            // AltaUiButton
            // 
            this.AltaUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.AltaUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AltaUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.AltaUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("AltaUiButton.Icon")));
            this.AltaUiButton.Location = new System.Drawing.Point(6, 32);
            this.AltaUiButton.Name = "AltaUiButton";
            this.AltaUiButton.ShowFocusRectangle = false;
            this.AltaUiButton.Size = new System.Drawing.Size(88, 24);
            this.AltaUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.AltaUiButton.TabIndex = 28;
            this.AltaUiButton.Tag = "Alta";
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
            this.BajaUiButton.Location = new System.Drawing.Point(6, 56);
            this.BajaUiButton.Name = "BajaUiButton";
            this.BajaUiButton.ShowFocusRectangle = false;
            this.BajaUiButton.Size = new System.Drawing.Size(88, 24);
            this.BajaUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.BajaUiButton.TabIndex = 29;
            this.BajaUiButton.Tag = "Baja";
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
            this.EnviarAUiButton.Location = new System.Drawing.Point(6, 128);
            this.EnviarAUiButton.Name = "EnviarAUiButton";
            this.EnviarAUiButton.ShowFocusRectangle = false;
            this.EnviarAUiButton.Size = new System.Drawing.Size(88, 24);
            this.EnviarAUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.EnviarAUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.EnviarAUiButton.TabIndex = 32;
            this.EnviarAUiButton.Text = "Enviar a";
            this.EnviarAUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.EnviarAUiButton.UseThemes = false;
            // 
            // ModificacionUiButton
            // 
            this.ModificacionUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.ModificacionUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ModificacionUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.ModificacionUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("ModificacionUiButton.Icon")));
            this.ModificacionUiButton.Location = new System.Drawing.Point(6, 80);
            this.ModificacionUiButton.Name = "ModificacionUiButton";
            this.ModificacionUiButton.ShowFocusRectangle = false;
            this.ModificacionUiButton.Size = new System.Drawing.Size(88, 24);
            this.ModificacionUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.ModificacionUiButton.TabIndex = 30;
            this.ModificacionUiButton.Tag = "Modificacion";
            this.ModificacionUiButton.Text = "Modificar";
            this.ModificacionUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.ModificacionUiButton.UseThemes = false;
            this.ModificacionUiButton.Click += new System.EventHandler(this.ModificacionUiButton_Click);
            // 
            // ConsultauiButton
            // 
            this.ConsultauiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.ConsultauiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConsultauiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.ConsultauiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("ConsultauiButton.Icon")));
            this.ConsultauiButton.Location = new System.Drawing.Point(6, 104);
            this.ConsultauiButton.Name = "ConsultauiButton";
            this.ConsultauiButton.ShowFocusRectangle = false;
            this.ConsultauiButton.Size = new System.Drawing.Size(88, 24);
            this.ConsultauiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.ConsultauiButton.TabIndex = 31;
            this.ConsultauiButton.Tag = "Consulta";
            this.ConsultauiButton.Text = "Consultar";
            this.ConsultauiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.ConsultauiButton.UseThemes = false;
            this.ConsultauiButton.Click += new System.EventHandler(this.ConsultauiButton_Click);
            // 
            // MinimizarUiButton
            // 
            this.MinimizarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.MinimizarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizarUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.MinimizarUiButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimizarUiButton.Image")));
            this.MinimizarUiButton.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.MinimizarUiButton.Location = new System.Drawing.Point(6, 7);
            this.MinimizarUiButton.Name = "MinimizarUiButton";
            this.MinimizarUiButton.ShowFocusRectangle = false;
            this.MinimizarUiButton.Size = new System.Drawing.Size(20, 20);
            this.MinimizarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.MinimizarUiButton.TabIndex = 39;
            this.MinimizarUiButton.Tag = "Min";
            this.MinimizarUiButton.UseThemes = false;
            this.MinimizarUiButton.Visible = false;
            this.MinimizarUiButton.Click += new System.EventHandler(this.MinimizarUiButton_Click);
            // 
            // MaximizarUiButton
            // 
            this.MaximizarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.MaximizarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizarUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.MaximizarUiButton.Image = ((System.Drawing.Image)(resources.GetObject("MaximizarUiButton.Image")));
            this.MaximizarUiButton.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Center;
            this.MaximizarUiButton.Location = new System.Drawing.Point(6, 7);
            this.MaximizarUiButton.Name = "MaximizarUiButton";
            this.MaximizarUiButton.ShowFocusRectangle = false;
            this.MaximizarUiButton.Size = new System.Drawing.Size(20, 20);
            this.MaximizarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.MaximizarUiButton.TabIndex = 38;
            this.MaximizarUiButton.Tag = "Max";
            this.MaximizarUiButton.UseThemes = false;
            this.MaximizarUiButton.Click += new System.EventHandler(this.MaxMinUiButton_Click);
            // 
            // SalirUiButton
            // 
            this.SalirUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.SalirUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SalirUiButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SalirUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.SalirUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("SalirUiButton.Icon")));
            this.SalirUiButton.Location = new System.Drawing.Point(40, 5);
            this.SalirUiButton.Name = "SalirUiButton";
            this.SalirUiButton.ShowFocusRectangle = false;
            this.SalirUiButton.Size = new System.Drawing.Size(54, 24);
            this.SalirUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.SalirUiButton.TabIndex = 37;
            this.SalirUiButton.Text = "Salir";
            this.SalirUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.SalirUiButton.UseThemes = false;
            // 
            // ListaGridEX
            // 
            this.ListaGridEX.AllowColumnDrag = false;
            this.ListaGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.ListaGridEX.AlternatingColors = true;
            this.ListaGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.ListaGridEX.BackColor = System.Drawing.Color.PeachPuff;
            this.ListaGridEX.BackgroundImageDrawMode = Janus.Windows.GridEX.BackgroundImageDrawMode.None;
            this.ListaGridEX.BlendColor = System.Drawing.Color.White;
            this.ListaGridEX.ControlStyle.ControlColor = System.Drawing.Color.PeachPuff;
            this.ListaGridEX.ControlStyle.ScrollBarColor = System.Drawing.Color.PeachPuff;
            gridEXLayout3.LayoutString = resources.GetString("gridEXLayout3.LayoutString");
            this.ListaGridEX.DesignTimeLayout = gridEXLayout3;
            this.ListaGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListaGridEX.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular;
            this.ListaGridEX.FlatBorderColor = System.Drawing.Color.Brown;
            this.ListaGridEX.FocusCellFormatStyle.BackColor = System.Drawing.Color.Gold;
            this.ListaGridEX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ListaGridEX.GridLines = Janus.Windows.GridEX.GridLines.Vertical;
            this.ListaGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.ListaGridEX.GroupByBoxVisible = false;
            this.ListaGridEX.GroupRowFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.ListaGridEX.GroupRowFormatStyle.BackColorGradient = System.Drawing.Color.PeachPuff;
            this.ListaGridEX.GroupTotals = Janus.Windows.GridEX.GroupTotals.Default;
            this.ListaGridEX.HeaderFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.ListaGridEX.HeaderFormatStyle.BackColorGradient = System.Drawing.Color.PeachPuff;
            this.ListaGridEX.HeaderFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.ListaGridEX.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.ListaGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.ListaGridEX.Location = new System.Drawing.Point(5, 30);
            this.ListaGridEX.Name = "ListaGridEX";
            this.ListaGridEX.RowFormatStyle.BackColor = System.Drawing.Color.White;
            this.ListaGridEX.SelectedFormatStyle.BackColor = System.Drawing.Color.Gold;
            this.ListaGridEX.SelectedFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.ListaGridEX.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ListaGridEX.SelectedInactiveFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.ListaGridEX.Size = new System.Drawing.Size(317, 195);
            this.ListaGridEX.TabIndex = 8;
            this.ListaGridEX.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None;
            this.ListaGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // TablaGrillaForm
            // 
            this.ClientSize = new System.Drawing.Size(422, 230);
            this.Name = "TablaGrillaForm";
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiCommandManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiContextMenu)).EndInit();
            this.FondoNicePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListaGridEX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        public Janus.Windows.EditControls.UIButton AltaUiButton;
        protected Janus.Windows.EditControls.UIButton BajaUiButton;
        protected Janus.Windows.EditControls.UIButton EnviarAUiButton;
        protected Janus.Windows.EditControls.UIButton ModificacionUiButton;
        protected Janus.Windows.EditControls.UIButton ConsultauiButton;
        private Janus.Windows.EditControls.UIButton MinimizarUiButton;
        private Janus.Windows.EditControls.UIButton MaximizarUiButton;
        protected Janus.Windows.EditControls.UIButton SalirUiButton;
        private Janus.Windows.GridEX.GridEX ListaGridEX;
    }
}