using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Cedeira.SV;

namespace CedForecast
{
    public partial class OrdenCompraBrowserForm : Cedeira.UI.frmBaseEnviarA
    {
        private Janus.Windows.UI.Dock.UIPanelManager BotonesUiPanelManager;
        private Janus.Windows.UI.Tab.UITabPage TabFiltroUiTabPage;
        private System.Windows.Forms.Panel FiltroPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Janus.Windows.CalendarCombo.CalendarCombo FechaHstCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo FechaDsdCalendarCombo;
        private System.Windows.Forms.Label FechaLabel;
        private Janus.Windows.EditControls.UICheckBox EstadoUiCheckBox;
        private System.Windows.Forms.TreeView EstadoTreeView;
        private Janus.Windows.UI.Dock.UIPanel HerramientasUiPanel;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer HerramientasUiPanelContainer;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Panel BrowserPanel;
        private System.Windows.Forms.Panel BrowserGridsPanel;
        private System.Windows.Forms.Panel BrowserGridPanel;
        private Janus.Windows.GridEX.GridEX BrowserGridEX;
        private Janus.Windows.UI.Tab.UITab BrowserUiTab;
        private Janus.Windows.UI.Tab.UITabPage TabBrowserUiTabPage;
        private PureComponents.NicePanel.NicePanel nicePanel3;
        private PureComponents.NicePanel.NicePanel nicePanel2;
        private ImageList iconos;

        #region Código generado por el Diseñador de Windows Forms
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.GridEX.GridEXLayout gridEXLayout1 = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdenCompraBrowserForm));
            PureComponents.NicePanel.ContainerImage containerImage1 = new PureComponents.NicePanel.ContainerImage();
            PureComponents.NicePanel.HeaderImage headerImage1 = new PureComponents.NicePanel.HeaderImage();
            PureComponents.NicePanel.HeaderImage headerImage2 = new PureComponents.NicePanel.HeaderImage();
            PureComponents.NicePanel.PanelStyle panelStyle1 = new PureComponents.NicePanel.PanelStyle();
            PureComponents.NicePanel.ContainerStyle containerStyle1 = new PureComponents.NicePanel.ContainerStyle();
            PureComponents.NicePanel.PanelHeaderStyle panelHeaderStyle1 = new PureComponents.NicePanel.PanelHeaderStyle();
            PureComponents.NicePanel.PanelHeaderStyle panelHeaderStyle2 = new PureComponents.NicePanel.PanelHeaderStyle();
            PureComponents.NicePanel.ContainerImage containerImage2 = new PureComponents.NicePanel.ContainerImage();
            PureComponents.NicePanel.HeaderImage headerImage3 = new PureComponents.NicePanel.HeaderImage();
            PureComponents.NicePanel.HeaderImage headerImage4 = new PureComponents.NicePanel.HeaderImage();
            PureComponents.NicePanel.PanelStyle panelStyle2 = new PureComponents.NicePanel.PanelStyle();
            PureComponents.NicePanel.ContainerStyle containerStyle2 = new PureComponents.NicePanel.ContainerStyle();
            PureComponents.NicePanel.PanelHeaderStyle panelHeaderStyle3 = new PureComponents.NicePanel.PanelHeaderStyle();
            PureComponents.NicePanel.PanelHeaderStyle panelHeaderStyle4 = new PureComponents.NicePanel.PanelHeaderStyle();
            this.BotonesUiPanelManager = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.BrowserPanel = new System.Windows.Forms.Panel();
            this.BrowserGridsPanel = new System.Windows.Forms.Panel();
            this.BrowserGridPanel = new System.Windows.Forms.Panel();
            this.BrowserGridEX = new Janus.Windows.GridEX.GridEX();
            this.HerramientasUiPanel = new Janus.Windows.UI.Dock.UIPanel();
            this.HerramientasUiPanelContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MinimizarUiButton = new Janus.Windows.EditControls.UIButton();
            this.MaximizarUiButton = new Janus.Windows.EditControls.UIButton();
            this.SalirUiButton = new Janus.Windows.EditControls.UIButton();
            this.AnulacionUiButton = new Janus.Windows.EditControls.UIButton();
            this.IngrADepUiButton = new Janus.Windows.EditControls.UIButton();
            this.InspRenarUiButton = new Janus.Windows.EditControls.UIButton();
            this.RegDespUiButton = new Janus.Windows.EditControls.UIButton();
            this.RecepDocsUiButton = new Janus.Windows.EditControls.UIButton();
            this.IngInfoEmbUiButton = new Janus.Windows.EditControls.UIButton();
            this.EnviarAUiButton = new Janus.Windows.EditControls.UIButton();
            this.AltaUiButton = new Janus.Windows.EditControls.UIButton();
            this.BrowserUiTab = new Janus.Windows.UI.Tab.UITab();
            this.TabBrowserUiTabPage = new Janus.Windows.UI.Tab.UITabPage();
            this.TabFiltroUiTabPage = new Janus.Windows.UI.Tab.UITabPage();
            this.FiltroPanel = new System.Windows.Forms.Panel();
            this.EjecutarSeleccionUiButton = new Janus.Windows.EditControls.UIButton();
            this.CancelarUiButton = new Janus.Windows.EditControls.UIButton();
            this.nicePanel3 = new PureComponents.NicePanel.NicePanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaHstCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.FechaDsdCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.FechaLabel = new System.Windows.Forms.Label();
            this.nicePanel2 = new PureComponents.NicePanel.NicePanel();
            this.EstadoUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.EstadoTreeView = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiCommandManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiContextMenu)).BeginInit();
            this.FondoNicePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BotonesUiPanelManager)).BeginInit();
            this.BrowserPanel.SuspendLayout();
            this.BrowserGridsPanel.SuspendLayout();
            this.BrowserGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrowserGridEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HerramientasUiPanel)).BeginInit();
            this.HerramientasUiPanel.SuspendLayout();
            this.HerramientasUiPanelContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrowserUiTab)).BeginInit();
            this.BrowserUiTab.SuspendLayout();
            this.TabBrowserUiTabPage.SuspendLayout();
            this.TabFiltroUiTabPage.SuspendLayout();
            this.FiltroPanel.SuspendLayout();
            this.nicePanel3.SuspendLayout();
            this.nicePanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnviarAUiCommandManager
            // 
            this.EnviarAUiCommandManager.CommandsStateStyles.FormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.EnviarAUiCommandManager.CommandsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.EnviarAUiCommandManager.UseThemes = false;
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
            this.FondoNicePanel.Size = new System.Drawing.Size(958, 503);
            // 
            // BotonesUiPanelManager
            // 
            this.BotonesUiPanelManager.AllowPanelDrag = false;
            this.BotonesUiPanelManager.AllowPanelDrop = false;
            this.BotonesUiPanelManager.AllowPanelResize = false;
            this.BotonesUiPanelManager.BackColorAutoHideStrip = System.Drawing.Color.PeachPuff;
            this.BotonesUiPanelManager.BackColorSplitter = System.Drawing.Color.PeachPuff;
            this.BotonesUiPanelManager.ContainerControl = this.BrowserPanel;
            this.BotonesUiPanelManager.DefaultPanelSettings.ActiveCaptionFormatStyle.BackColor = System.Drawing.Color.Peru;
            this.BotonesUiPanelManager.DefaultPanelSettings.ActiveCaptionFormatStyle.BackColorGradient = System.Drawing.Color.Brown;
            this.BotonesUiPanelManager.DefaultPanelSettings.ActiveCaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.BotonesUiPanelManager.DefaultPanelSettings.ActiveCaptionFormatStyle.ForeColor = System.Drawing.Color.Cornsilk;
            this.BotonesUiPanelManager.DefaultPanelSettings.BorderCaptionColor = System.Drawing.Color.Brown;
            this.BotonesUiPanelManager.DefaultPanelSettings.BorderPanelColor = System.Drawing.Color.Brown;
            this.BotonesUiPanelManager.DefaultPanelSettings.CaptionFormatStyle.BackColor = System.Drawing.Color.Peru;
            this.BotonesUiPanelManager.DefaultPanelSettings.CaptionFormatStyle.BackColorGradient = System.Drawing.Color.Brown;
            this.BotonesUiPanelManager.DefaultPanelSettings.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.BotonesUiPanelManager.DefaultPanelSettings.CaptionFormatStyle.ForeColor = System.Drawing.Color.Cornsilk;
            this.BotonesUiPanelManager.DefaultPanelSettings.CaptionHeight = 25;
            this.BotonesUiPanelManager.DefaultPanelSettings.InnerContainerFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.BotonesUiPanelManager.DefaultPanelSettings.TextAlignment = Janus.Windows.UI.Dock.PanelTextAlignment.Center;
            this.BotonesUiPanelManager.PanelPadding.Bottom = 0;
            this.BotonesUiPanelManager.PanelPadding.Left = 0;
            this.BotonesUiPanelManager.PanelPadding.Right = 0;
            this.BotonesUiPanelManager.PanelPadding.Top = 0;
            this.BotonesUiPanelManager.SplitterSize = 1;
            this.BotonesUiPanelManager.UseThemes = false;
            this.HerramientasUiPanel.Id = new System.Guid("6ee79d23-0754-4daa-993e-d43b72175136");
            this.BotonesUiPanelManager.Panels.Add(this.HerramientasUiPanel);
            // 
            // Design Time Panel Info:
            // 
            this.BotonesUiPanelManager.BeginPanelInfo();
            this.BotonesUiPanelManager.AddDockPanelInfo(new System.Guid("6ee79d23-0754-4daa-993e-d43b72175136"), Janus.Windows.UI.Dock.PanelDockStyle.Right, new System.Drawing.Size(178, 436), true);
            this.BotonesUiPanelManager.AddFloatingPanelInfo(new System.Guid("6ee79d23-0754-4daa-993e-d43b72175136"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.BotonesUiPanelManager.EndPanelInfo();
            // 
            // BrowserPanel
            // 
            this.BrowserPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.BrowserPanel.Controls.Add(this.BrowserGridsPanel);
            this.BrowserPanel.Controls.Add(this.HerramientasUiPanel);
            this.BrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserPanel.Location = new System.Drawing.Point(0, 0);
            this.BrowserPanel.Name = "BrowserPanel";
            this.BrowserPanel.Padding = new System.Windows.Forms.Padding(5);
            this.BrowserPanel.Size = new System.Drawing.Size(951, 446);
            this.BrowserPanel.TabIndex = 5;
            // 
            // BrowserGridsPanel
            // 
            this.BrowserGridsPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.BrowserGridsPanel.Controls.Add(this.BrowserGridPanel);
            this.BrowserGridsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserGridsPanel.Location = new System.Drawing.Point(5, 5);
            this.BrowserGridsPanel.Name = "BrowserGridsPanel";
            this.BrowserGridsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.BrowserGridsPanel.Size = new System.Drawing.Size(763, 436);
            this.BrowserGridsPanel.TabIndex = 6;
            // 
            // BrowserGridPanel
            // 
            this.BrowserGridPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.BrowserGridPanel.Controls.Add(this.BrowserGridEX);
            this.BrowserGridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserGridPanel.Location = new System.Drawing.Point(0, 0);
            this.BrowserGridPanel.Name = "BrowserGridPanel";
            this.BrowserGridPanel.Size = new System.Drawing.Size(759, 436);
            this.BrowserGridPanel.TabIndex = 9;
            // 
            // BrowserGridEX
            // 
            this.BrowserGridEX.AllowColumnDrag = false;
            this.BrowserGridEX.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.BrowserGridEX.AlternatingColors = true;
            this.BrowserGridEX.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.BrowserGridEX.BackColor = System.Drawing.Color.PeachPuff;
            this.BrowserGridEX.BackgroundImageDrawMode = Janus.Windows.GridEX.BackgroundImageDrawMode.None;
            this.BrowserGridEX.BlendColor = System.Drawing.Color.White;
            this.BrowserGridEX.ControlStyle.ControlColor = System.Drawing.Color.PeachPuff;
            this.BrowserGridEX.ControlStyle.ScrollBarColor = System.Drawing.Color.PeachPuff;
            gridEXLayout1.LayoutString = resources.GetString("gridEXLayout1.LayoutString");
            this.BrowserGridEX.DesignTimeLayout = gridEXLayout1;
            this.BrowserGridEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserGridEX.EditorsControlStyle.ButtonAppearance = Janus.Windows.GridEX.ButtonAppearance.Regular;
            this.BrowserGridEX.FlatBorderColor = System.Drawing.Color.Brown;
            this.BrowserGridEX.FocusCellFormatStyle.BackColor = System.Drawing.Color.Gold;
            this.BrowserGridEX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BrowserGridEX.FrozenColumns = 3;
            this.BrowserGridEX.GridLines = Janus.Windows.GridEX.GridLines.Vertical;
            this.BrowserGridEX.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.BrowserGridEX.GroupByBoxVisible = false;
            this.BrowserGridEX.HeaderFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.BrowserGridEX.HeaderFormatStyle.BackColorGradient = System.Drawing.Color.PeachPuff;
            this.BrowserGridEX.HeaderFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.BrowserGridEX.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.BrowserGridEX.HideSelection = Janus.Windows.GridEX.HideSelection.Highlight;
            this.BrowserGridEX.Location = new System.Drawing.Point(0, 0);
            this.BrowserGridEX.Name = "BrowserGridEX";
            this.BrowserGridEX.RowFormatStyle.BackColor = System.Drawing.Color.White;
            this.BrowserGridEX.SelectedFormatStyle.BackColor = System.Drawing.Color.Gold;
            this.BrowserGridEX.SelectedFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.BrowserGridEX.SelectedInactiveFormatStyle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BrowserGridEX.SelectedInactiveFormatStyle.ForeColor = System.Drawing.Color.Empty;
            this.BrowserGridEX.SelectionMode = Janus.Windows.GridEX.SelectionMode.MultipleSelection;
            this.BrowserGridEX.Size = new System.Drawing.Size(759, 436);
            this.BrowserGridEX.TabIndex = 6;
            this.BrowserGridEX.ThemedAreas = Janus.Windows.GridEX.ThemedArea.None;
            this.BrowserGridEX.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.BrowserGridEX.SelectionChanged += new System.EventHandler(this.BrowserGridEX_SelectionChanged);
            // 
            // HerramientasUiPanel
            // 
            this.HerramientasUiPanel.AutoHideButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.HerramientasUiPanel.CaptionFormatStyle.FontBold = Janus.Windows.UI.TriState.False;
            this.HerramientasUiPanel.CaptionFormatStyle.ForeColor = System.Drawing.Color.White;
            this.HerramientasUiPanel.CaptionHeight = 20;
            this.HerramientasUiPanel.CloseButtonVisible = Janus.Windows.UI.InheritableBoolean.False;
            this.HerramientasUiPanel.InnerContainer = this.HerramientasUiPanelContainer;
            this.HerramientasUiPanel.Location = new System.Drawing.Point(768, 5);
            this.HerramientasUiPanel.Name = "HerramientasUiPanel";
            this.HerramientasUiPanel.Size = new System.Drawing.Size(178, 436);
            this.HerramientasUiPanel.TabIndex = 4;
            this.HerramientasUiPanel.Text = "Herramientas";
            // 
            // HerramientasUiPanelContainer
            // 
            this.HerramientasUiPanelContainer.Controls.Add(this.panel1);
            this.HerramientasUiPanelContainer.Controls.Add(this.AnulacionUiButton);
            this.HerramientasUiPanelContainer.Controls.Add(this.IngrADepUiButton);
            this.HerramientasUiPanelContainer.Controls.Add(this.InspRenarUiButton);
            this.HerramientasUiPanelContainer.Controls.Add(this.RegDespUiButton);
            this.HerramientasUiPanelContainer.Controls.Add(this.RecepDocsUiButton);
            this.HerramientasUiPanelContainer.Controls.Add(this.IngInfoEmbUiButton);
            this.HerramientasUiPanelContainer.Controls.Add(this.EnviarAUiButton);
            this.HerramientasUiPanelContainer.Controls.Add(this.AltaUiButton);
            this.HerramientasUiPanelContainer.ForeColor = System.Drawing.Color.Navy;
            this.HerramientasUiPanelContainer.Location = new System.Drawing.Point(2, 20);
            this.HerramientasUiPanelContainer.Name = "HerramientasUiPanelContainer";
            this.HerramientasUiPanelContainer.Size = new System.Drawing.Size(175, 415);
            this.HerramientasUiPanelContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MinimizarUiButton);
            this.panel1.Controls.Add(this.MaximizarUiButton);
            this.panel1.Controls.Add(this.SalirUiButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 385);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 30);
            this.panel1.TabIndex = 40;
            // 
            // MinimizarUiButton
            // 
            this.MinimizarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.MinimizarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizarUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.MinimizarUiButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimizarUiButton.Image")));
            this.MinimizarUiButton.ImageHorizontalAlignment = Janus.Windows.EditControls.ImageHorizontalAlignment.Near;
            this.MinimizarUiButton.Location = new System.Drawing.Point(7, 6);
            this.MinimizarUiButton.Name = "MinimizarUiButton";
            this.MinimizarUiButton.ShowFocusRectangle = false;
            this.MinimizarUiButton.Size = new System.Drawing.Size(20, 20);
            this.MinimizarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.MinimizarUiButton.TabIndex = 42;
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
            this.MaximizarUiButton.Location = new System.Drawing.Point(7, 6);
            this.MaximizarUiButton.Name = "MaximizarUiButton";
            this.MaximizarUiButton.ShowFocusRectangle = false;
            this.MaximizarUiButton.Size = new System.Drawing.Size(20, 20);
            this.MaximizarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.MaximizarUiButton.TabIndex = 41;
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
            this.SalirUiButton.Location = new System.Drawing.Point(112, 4);
            this.SalirUiButton.Name = "SalirUiButton";
            this.SalirUiButton.ShowFocusRectangle = false;
            this.SalirUiButton.Size = new System.Drawing.Size(54, 24);
            this.SalirUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.SalirUiButton.TabIndex = 40;
            this.SalirUiButton.Text = "Salir";
            this.SalirUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Far;
            this.SalirUiButton.UseThemes = false;
            // 
            // AnulacionUiButton
            // 
            this.AnulacionUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.AnulacionUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnulacionUiButton.Enabled = false;
            this.AnulacionUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.AnulacionUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("AnulacionUiButton.Icon")));
            this.AnulacionUiButton.Location = new System.Drawing.Point(8, 153);
            this.AnulacionUiButton.Name = "AnulacionUiButton";
            this.AnulacionUiButton.ShowFocusRectangle = false;
            this.AnulacionUiButton.Size = new System.Drawing.Size(158, 24);
            this.AnulacionUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.AnulacionUiButton.TabIndex = 32;
            this.AnulacionUiButton.Tag = "Baja";
            this.AnulacionUiButton.Text = "Anulación";
            this.AnulacionUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.AnulacionUiButton.UseThemes = false;
            this.AnulacionUiButton.Click += new System.EventHandler(this.AnulacionUiButton_Click);
            // 
            // IngrADepUiButton
            // 
            this.IngrADepUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.IngrADepUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IngrADepUiButton.Enabled = false;
            this.IngrADepUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.IngrADepUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("IngrADepUiButton.Icon")));
            this.IngrADepUiButton.Location = new System.Drawing.Point(8, 129);
            this.IngrADepUiButton.Name = "IngrADepUiButton";
            this.IngrADepUiButton.ShowFocusRectangle = false;
            this.IngrADepUiButton.Size = new System.Drawing.Size(158, 24);
            this.IngrADepUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.IngrADepUiButton.TabIndex = 31;
            this.IngrADepUiButton.Tag = "";
            this.IngrADepUiButton.Text = "Ingreso a Depósito";
            this.IngrADepUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.IngrADepUiButton.UseThemes = false;
            this.IngrADepUiButton.Click += new System.EventHandler(this.IngrADepUiButton_Click);
            // 
            // InspRenarUiButton
            // 
            this.InspRenarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.InspRenarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InspRenarUiButton.Enabled = false;
            this.InspRenarUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.InspRenarUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("InspRenarUiButton.Icon")));
            this.InspRenarUiButton.Location = new System.Drawing.Point(8, 105);
            this.InspRenarUiButton.Name = "InspRenarUiButton";
            this.InspRenarUiButton.ShowFocusRectangle = false;
            this.InspRenarUiButton.Size = new System.Drawing.Size(158, 24);
            this.InspRenarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.InspRenarUiButton.TabIndex = 30;
            this.InspRenarUiButton.Tag = "";
            this.InspRenarUiButton.Text = "Inspección RENAR";
            this.InspRenarUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.InspRenarUiButton.UseThemes = false;
            this.InspRenarUiButton.Click += new System.EventHandler(this.InspRenarUiButton_Click);
            // 
            // RegDespUiButton
            // 
            this.RegDespUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.RegDespUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegDespUiButton.Enabled = false;
            this.RegDespUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.RegDespUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("RegDespUiButton.Icon")));
            this.RegDespUiButton.Location = new System.Drawing.Point(8, 81);
            this.RegDespUiButton.Name = "RegDespUiButton";
            this.RegDespUiButton.ShowFocusRectangle = false;
            this.RegDespUiButton.Size = new System.Drawing.Size(158, 24);
            this.RegDespUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.RegDespUiButton.TabIndex = 29;
            this.RegDespUiButton.Tag = "";
            this.RegDespUiButton.Text = "Registro de Despacho";
            this.RegDespUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.RegDespUiButton.UseThemes = false;
            this.RegDespUiButton.Click += new System.EventHandler(this.RegDespUiButton_Click);
            // 
            // RecepDocsUiButton
            // 
            this.RecepDocsUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.RecepDocsUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RecepDocsUiButton.Enabled = false;
            this.RecepDocsUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.RecepDocsUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("RecepDocsUiButton.Icon")));
            this.RecepDocsUiButton.Location = new System.Drawing.Point(8, 57);
            this.RecepDocsUiButton.Name = "RecepDocsUiButton";
            this.RecepDocsUiButton.ShowFocusRectangle = false;
            this.RecepDocsUiButton.Size = new System.Drawing.Size(158, 24);
            this.RecepDocsUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.RecepDocsUiButton.TabIndex = 28;
            this.RecepDocsUiButton.Tag = "";
            this.RecepDocsUiButton.Text = "Recepción de Documentos";
            this.RecepDocsUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.RecepDocsUiButton.UseThemes = false;
            this.RecepDocsUiButton.Click += new System.EventHandler(this.RecepDocsUiButton_Click);
            // 
            // IngInfoEmbUiButton
            // 
            this.IngInfoEmbUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.IngInfoEmbUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IngInfoEmbUiButton.Enabled = false;
            this.IngInfoEmbUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.IngInfoEmbUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("IngInfoEmbUiButton.Icon")));
            this.IngInfoEmbUiButton.Location = new System.Drawing.Point(8, 33);
            this.IngInfoEmbUiButton.Name = "IngInfoEmbUiButton";
            this.IngInfoEmbUiButton.ShowFocusRectangle = false;
            this.IngInfoEmbUiButton.Size = new System.Drawing.Size(158, 24);
            this.IngInfoEmbUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.IngInfoEmbUiButton.TabIndex = 27;
            this.IngInfoEmbUiButton.Tag = "";
            this.IngInfoEmbUiButton.Text = "Ingreso Info Embarque";
            this.IngInfoEmbUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.IngInfoEmbUiButton.UseThemes = false;
            this.IngInfoEmbUiButton.Click += new System.EventHandler(this.IngInfoEmbUiButton_Click);
            // 
            // EnviarAUiButton
            // 
            this.EnviarAUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.EnviarAUiButton.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDownButton;
            this.EnviarAUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnviarAUiButton.DropDownContextMenu = this.EnviarAUiContextMenu;
            this.EnviarAUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.EnviarAUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("EnviarAUiButton.Icon")));
            this.EnviarAUiButton.Location = new System.Drawing.Point(8, 177);
            this.EnviarAUiButton.Name = "EnviarAUiButton";
            this.EnviarAUiButton.ShowFocusRectangle = false;
            this.EnviarAUiButton.Size = new System.Drawing.Size(158, 24);
            this.EnviarAUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.EnviarAUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.EnviarAUiButton.TabIndex = 26;
            this.EnviarAUiButton.Text = "Enviar a";
            this.EnviarAUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.EnviarAUiButton.UseThemes = false;
            // 
            // AltaUiButton
            // 
            this.AltaUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.AltaUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AltaUiButton.FlatBorderColor = System.Drawing.Color.Transparent;
            this.AltaUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("AltaUiButton.Icon")));
            this.AltaUiButton.Location = new System.Drawing.Point(8, 9);
            this.AltaUiButton.Name = "AltaUiButton";
            this.AltaUiButton.ShowFocusRectangle = false;
            this.AltaUiButton.Size = new System.Drawing.Size(158, 24);
            this.AltaUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.AltaUiButton.TabIndex = 24;
            this.AltaUiButton.Tag = "";
            this.AltaUiButton.Text = "Alta";
            this.AltaUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.AltaUiButton.UseThemes = false;
            this.AltaUiButton.Click += new System.EventHandler(this.AltaUiButton_Click);
            // 
            // BrowserUiTab
            // 
            this.BrowserUiTab.BackColor = System.Drawing.Color.Transparent;
            this.BrowserUiTab.Controls.Add(this.TabBrowserUiTabPage);
            this.BrowserUiTab.Controls.Add(this.TabFiltroUiTabPage);
            this.BrowserUiTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserUiTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowserUiTab.Location = new System.Drawing.Point(5, 30);
            this.BrowserUiTab.MultiLine = true;
            this.BrowserUiTab.Name = "BrowserUiTab";
            this.BrowserUiTab.ShowFocusRectangle = false;
            this.BrowserUiTab.Size = new System.Drawing.Size(953, 468);
            this.BrowserUiTab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.BrowserUiTab.TabIndex = 9;
            this.BrowserUiTab.TabPages.AddRange(new Janus.Windows.UI.Tab.UITabPage[] {
            this.TabBrowserUiTabPage,
            this.TabFiltroUiTabPage});
            this.BrowserUiTab.TabsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.DimGray;
            this.BrowserUiTab.TabsStateStyles.SelectedFormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.BrowserUiTab.TabStripFormatStyle.FontBold = Janus.Windows.UI.TriState.True;
            this.BrowserUiTab.Tag = "";
            this.BrowserUiTab.UseThemes = false;
            this.BrowserUiTab.VisualStyle = Janus.Windows.UI.Tab.TabVisualStyle.Office2003;
            this.BrowserUiTab.SelectedTabChanged += new Janus.Windows.UI.Tab.TabEventHandler(this.BrowserUiTab_SelectedTabChanged);
            // 
            // TabBrowserUiTabPage
            // 
            this.TabBrowserUiTabPage.Controls.Add(this.BrowserPanel);
            this.TabBrowserUiTabPage.Key = "OrdenCompra";
            this.TabBrowserUiTabPage.Location = new System.Drawing.Point(1, 21);
            this.TabBrowserUiTabPage.Name = "TabBrowserUiTabPage";
            this.TabBrowserUiTabPage.Size = new System.Drawing.Size(951, 446);
            this.TabBrowserUiTabPage.StateStyles.HotFormatStyle.BackColor = System.Drawing.Color.PeachPuff;
            this.TabBrowserUiTabPage.TabIndex = 1;
            this.TabBrowserUiTabPage.Tag = "Detalle";
            this.TabBrowserUiTabPage.Text = "Órdenes de Compra";
            // 
            // TabFiltroUiTabPage
            // 
            this.TabFiltroUiTabPage.Controls.Add(this.FiltroPanel);
            this.TabFiltroUiTabPage.Key = "Filtro";
            this.TabFiltroUiTabPage.Location = new System.Drawing.Point(1, 21);
            this.TabFiltroUiTabPage.Name = "TabFiltroUiTabPage";
            this.TabFiltroUiTabPage.Size = new System.Drawing.Size(951, 446);
            this.TabFiltroUiTabPage.StateStyles.HotFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.TabFiltroUiTabPage.TabIndex = 0;
            this.TabFiltroUiTabPage.Tag = "Detalle";
            this.TabFiltroUiTabPage.Text = "Filtro avanzado";
            this.TabFiltroUiTabPage.Visible = false;
            // 
            // FiltroPanel
            // 
            this.FiltroPanel.BackColor = System.Drawing.Color.Cornsilk;
            this.FiltroPanel.Controls.Add(this.EjecutarSeleccionUiButton);
            this.FiltroPanel.Controls.Add(this.CancelarUiButton);
            this.FiltroPanel.Controls.Add(this.nicePanel3);
            this.FiltroPanel.Controls.Add(this.nicePanel2);
            this.FiltroPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FiltroPanel.Location = new System.Drawing.Point(0, 0);
            this.FiltroPanel.Name = "FiltroPanel";
            this.FiltroPanel.Padding = new System.Windows.Forms.Padding(10);
            this.FiltroPanel.Size = new System.Drawing.Size(951, 446);
            this.FiltroPanel.TabIndex = 5;
            // 
            // EjecutarSeleccionUiButton
            // 
            this.EjecutarSeleccionUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.EjecutarSeleccionUiButton.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.EjecutarSeleccionUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EjecutarSeleccionUiButton.FlatBorderColor = System.Drawing.Color.Navy;
            this.EjecutarSeleccionUiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EjecutarSeleccionUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("EjecutarSeleccionUiButton.Icon")));
            this.EjecutarSeleccionUiButton.Location = new System.Drawing.Point(192, 327);
            this.EjecutarSeleccionUiButton.Name = "EjecutarSeleccionUiButton";
            this.EjecutarSeleccionUiButton.ShowFocusRectangle = false;
            this.EjecutarSeleccionUiButton.Size = new System.Drawing.Size(96, 24);
            this.EjecutarSeleccionUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.EjecutarSeleccionUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.EjecutarSeleccionUiButton.TabIndex = 9018;
            this.EjecutarSeleccionUiButton.Text = "Aplicar filtro";
            this.EjecutarSeleccionUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.EjecutarSeleccionUiButton.UseThemes = false;
            this.EjecutarSeleccionUiButton.Click += new System.EventHandler(this.ActualizarBrowserGrid);
            // 
            // CancelarUiButton
            // 
            this.CancelarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.CancelarUiButton.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.CancelarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelarUiButton.FlatBorderColor = System.Drawing.Color.Navy;
            this.CancelarUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("CancelarUiButton.Icon")));
            this.CancelarUiButton.Location = new System.Drawing.Point(494, 327);
            this.CancelarUiButton.Name = "CancelarUiButton";
            this.CancelarUiButton.ShowFocusRectangle = false;
            this.CancelarUiButton.Size = new System.Drawing.Size(72, 24);
            this.CancelarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.CancelarUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.CancelarUiButton.TabIndex = 9017;
            this.CancelarUiButton.Text = "Cancelar";
            this.CancelarUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Far;
            this.CancelarUiButton.UseThemes = false;
            this.CancelarUiButton.Click += new System.EventHandler(this.CancelarUiButton_Click);
            // 
            // nicePanel3
            // 
            this.nicePanel3.BackColor = System.Drawing.Color.Transparent;
            this.nicePanel3.CollapseButton = false;
            containerImage1.Alignment = System.Drawing.ContentAlignment.BottomRight;
            containerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            containerImage1.Image = null;
            containerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small;
            containerImage1.Transparency = 50;
            this.nicePanel3.ContainerImage = containerImage1;
            this.nicePanel3.ContextMenuButton = false;
            this.nicePanel3.Controls.Add(this.label2);
            this.nicePanel3.Controls.Add(this.label4);
            this.nicePanel3.Controls.Add(this.FechaHstCalendarCombo);
            this.nicePanel3.Controls.Add(this.FechaDsdCalendarCombo);
            this.nicePanel3.Controls.Add(this.FechaLabel);
            headerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            headerImage1.Image = null;
            this.nicePanel3.FooterImage = headerImage1;
            this.nicePanel3.FooterText = "";
            this.nicePanel3.FooterVisible = false;
            this.nicePanel3.ForeColor = System.Drawing.Color.Black;
            headerImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            headerImage2.Image = null;
            this.nicePanel3.HeaderImage = headerImage2;
            this.nicePanel3.HeaderText = "Periodo";
            this.nicePanel3.IsExpanded = true;
            this.nicePanel3.Location = new System.Drawing.Point(8, 8);
            this.nicePanel3.Name = "nicePanel3";
            this.nicePanel3.OriginalFooterVisible = false;
            this.nicePanel3.OriginalHeight = 0;
            this.nicePanel3.ShowChildFocus = false;
            this.nicePanel3.Size = new System.Drawing.Size(176, 104);
            containerStyle1.BackColor = System.Drawing.Color.Transparent;
            containerStyle1.BaseColor = System.Drawing.Color.Transparent;
            containerStyle1.BorderColor = System.Drawing.Color.Brown;
            containerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid;
            containerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left;
            containerStyle1.FadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(207)))), ((int)(((byte)(152)))));
            containerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.Flat;
            containerStyle1.FlashItemBackColor = System.Drawing.Color.Red;
            containerStyle1.FocusItemBackColor = System.Drawing.Color.White;
            containerStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            containerStyle1.ForeColor = System.Drawing.Color.Black;
            containerStyle1.Shape = PureComponents.NicePanel.Shape.Rounded;
            panelStyle1.ContainerStyle = containerStyle1;
            panelHeaderStyle1.BackColor = System.Drawing.Color.ForestGreen;
            panelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            panelHeaderStyle1.FadeColor = System.Drawing.Color.LightGreen;
            panelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading;
            panelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(122)))), ((int)(((byte)(1)))));
            panelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(159)))));
            panelHeaderStyle1.FlashForeColor = System.Drawing.Color.White;
            panelHeaderStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            panelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(233)))), ((int)(((byte)(184)))));
            panelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small;
            panelStyle1.FooterStyle = panelHeaderStyle1;
            panelHeaderStyle2.BackColor = System.Drawing.Color.Brown;
            panelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(233)))), ((int)(((byte)(184)))));
            panelHeaderStyle2.FadeColor = System.Drawing.Color.Peru;
            panelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalBackward;
            panelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(122)))), ((int)(((byte)(1)))));
            panelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(159)))));
            panelHeaderStyle2.FlashForeColor = System.Drawing.Color.White;
            panelHeaderStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            panelHeaderStyle2.ForeColor = System.Drawing.Color.White;
            panelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Small;
            panelHeaderStyle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panelStyle1.HeaderStyle = panelHeaderStyle2;
            this.nicePanel3.Style = panelStyle1;
            this.nicePanel3.TabIndex = 9013;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(48, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 9014;
            this.label2.Text = "Fecha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 9012;
            this.label4.Text = "al";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FechaHstCalendarCombo
            // 
            this.FechaHstCalendarCombo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.FechaHstCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2011, 4, 1, 0, 0, 0, 0);
            this.FechaHstCalendarCombo.DropDownCalendar.Location = new System.Drawing.Point(0, 0);
            this.FechaHstCalendarCombo.DropDownCalendar.Name = "";
            this.FechaHstCalendarCombo.DropDownCalendar.Size = new System.Drawing.Size(170, 173);
            this.FechaHstCalendarCombo.DropDownCalendar.TabIndex = 0;
            this.FechaHstCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.FechaHstCalendarCombo.FlatBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.FechaHstCalendarCombo.ForeColor = System.Drawing.Color.Black;
            this.FechaHstCalendarCombo.Location = new System.Drawing.Point(48, 64);
            this.FechaHstCalendarCombo.Name = "FechaHstCalendarCombo";
            this.FechaHstCalendarCombo.Size = new System.Drawing.Size(96, 20);
            this.FechaHstCalendarCombo.TabIndex = 9007;
            this.FechaHstCalendarCombo.ThemedAreas = Janus.Windows.CalendarCombo.ThemedArea.None;
            this.FechaHstCalendarCombo.TodayButtonText = "Hoy";
            this.FechaHstCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // FechaDsdCalendarCombo
            // 
            this.FechaDsdCalendarCombo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.FechaDsdCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2011, 4, 1, 0, 0, 0, 0);
            this.FechaDsdCalendarCombo.DropDownCalendar.Location = new System.Drawing.Point(0, 0);
            this.FechaDsdCalendarCombo.DropDownCalendar.Name = "";
            this.FechaDsdCalendarCombo.DropDownCalendar.Size = new System.Drawing.Size(170, 173);
            this.FechaDsdCalendarCombo.DropDownCalendar.TabIndex = 0;
            this.FechaDsdCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.FechaDsdCalendarCombo.FlatBorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.FechaDsdCalendarCombo.ForeColor = System.Drawing.Color.Black;
            this.FechaDsdCalendarCombo.Location = new System.Drawing.Point(48, 40);
            this.FechaDsdCalendarCombo.Name = "FechaDsdCalendarCombo";
            this.FechaDsdCalendarCombo.Size = new System.Drawing.Size(96, 20);
            this.FechaDsdCalendarCombo.TabIndex = 9004;
            this.FechaDsdCalendarCombo.ThemedAreas = Janus.Windows.CalendarCombo.ThemedArea.None;
            this.FechaDsdCalendarCombo.TodayButtonText = "Hoy";
            this.FechaDsdCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // FechaLabel
            // 
            this.FechaLabel.ForeColor = System.Drawing.Color.Navy;
            this.FechaLabel.Location = new System.Drawing.Point(16, 40);
            this.FechaLabel.Name = "FechaLabel";
            this.FechaLabel.Size = new System.Drawing.Size(24, 20);
            this.FechaLabel.TabIndex = 9003;
            this.FechaLabel.Text = "del";
            this.FechaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nicePanel2
            // 
            this.nicePanel2.BackColor = System.Drawing.Color.Transparent;
            this.nicePanel2.CollapseButton = false;
            containerImage2.Alignment = System.Drawing.ContentAlignment.BottomRight;
            containerImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            containerImage2.Image = null;
            containerImage2.Size = PureComponents.NicePanel.ContainerImageSize.Small;
            containerImage2.Transparency = 50;
            this.nicePanel2.ContainerImage = containerImage2;
            this.nicePanel2.ContextMenuButton = false;
            this.nicePanel2.Controls.Add(this.EstadoUiCheckBox);
            this.nicePanel2.Controls.Add(this.EstadoTreeView);
            headerImage3.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            headerImage3.Image = null;
            this.nicePanel2.FooterImage = headerImage3;
            this.nicePanel2.FooterText = "";
            this.nicePanel2.FooterVisible = false;
            this.nicePanel2.ForeColor = System.Drawing.Color.Black;
            headerImage4.ClipArt = PureComponents.NicePanel.ImageClipArt.None;
            headerImage4.Image = null;
            this.nicePanel2.HeaderImage = headerImage4;
            this.nicePanel2.HeaderText = "Estado(s)";
            this.nicePanel2.IsExpanded = true;
            this.nicePanel2.Location = new System.Drawing.Point(192, 8);
            this.nicePanel2.Name = "nicePanel2";
            this.nicePanel2.OriginalFooterVisible = false;
            this.nicePanel2.OriginalHeight = 0;
            this.nicePanel2.ShowChildFocus = false;
            this.nicePanel2.Size = new System.Drawing.Size(374, 313);
            containerStyle2.BackColor = System.Drawing.Color.Transparent;
            containerStyle2.BaseColor = System.Drawing.Color.Transparent;
            containerStyle2.BorderColor = System.Drawing.Color.Brown;
            containerStyle2.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid;
            containerStyle2.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left;
            containerStyle2.FadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(207)))), ((int)(((byte)(152)))));
            containerStyle2.FillStyle = PureComponents.NicePanel.FillStyle.Flat;
            containerStyle2.FlashItemBackColor = System.Drawing.Color.Red;
            containerStyle2.FocusItemBackColor = System.Drawing.Color.White;
            containerStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            containerStyle2.ForeColor = System.Drawing.Color.Black;
            containerStyle2.Shape = PureComponents.NicePanel.Shape.Rounded;
            panelStyle2.ContainerStyle = containerStyle2;
            panelHeaderStyle3.BackColor = System.Drawing.Color.ForestGreen;
            panelHeaderStyle3.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(191)))), ((int)(((byte)(227)))));
            panelHeaderStyle3.FadeColor = System.Drawing.Color.LightGreen;
            panelHeaderStyle3.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading;
            panelHeaderStyle3.FlashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(122)))), ((int)(((byte)(1)))));
            panelHeaderStyle3.FlashFadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(159)))));
            panelHeaderStyle3.FlashForeColor = System.Drawing.Color.White;
            panelHeaderStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            panelHeaderStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(233)))), ((int)(((byte)(184)))));
            panelHeaderStyle3.Size = PureComponents.NicePanel.PanelHeaderSize.Small;
            panelStyle2.FooterStyle = panelHeaderStyle3;
            panelHeaderStyle4.BackColor = System.Drawing.Color.Brown;
            panelHeaderStyle4.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(233)))), ((int)(((byte)(184)))));
            panelHeaderStyle4.FadeColor = System.Drawing.Color.Peru;
            panelHeaderStyle4.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalBackward;
            panelHeaderStyle4.FlashBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(122)))), ((int)(((byte)(1)))));
            panelHeaderStyle4.FlashFadeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(159)))));
            panelHeaderStyle4.FlashForeColor = System.Drawing.Color.White;
            panelHeaderStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            panelHeaderStyle4.ForeColor = System.Drawing.Color.White;
            panelHeaderStyle4.Size = PureComponents.NicePanel.PanelHeaderSize.Small;
            panelHeaderStyle4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            panelStyle2.HeaderStyle = panelHeaderStyle4;
            this.nicePanel2.Style = panelStyle2;
            this.nicePanel2.TabIndex = 9012;
            // 
            // EstadoUiCheckBox
            // 
            this.EstadoUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.EstadoUiCheckBox.Location = new System.Drawing.Point(10, 2);
            this.EstadoUiCheckBox.Name = "EstadoUiCheckBox";
            this.EstadoUiCheckBox.ShowFocusRectangle = false;
            this.EstadoUiCheckBox.Size = new System.Drawing.Size(20, 16);
            this.EstadoUiCheckBox.TabIndex = 9013;
            this.EstadoUiCheckBox.TextAlignment = Janus.Windows.EditControls.TextAlignment.Center;
            this.EstadoUiCheckBox.UseThemes = false;
            this.EstadoUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.EstadoUiCheckBox.CheckedChanged += new System.EventHandler(this.EstadoUiCheckBox_CheckedChanged);
            // 
            // EstadoTreeView
            // 
            this.EstadoTreeView.BackColor = System.Drawing.Color.Cornsilk;
            this.EstadoTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EstadoTreeView.CheckBoxes = true;
            this.EstadoTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstadoTreeView.ForeColor = System.Drawing.Color.Navy;
            this.EstadoTreeView.FullRowSelect = true;
            this.EstadoTreeView.Location = new System.Drawing.Point(8, 24);
            this.EstadoTreeView.Name = "EstadoTreeView";
            this.EstadoTreeView.ShowRootLines = false;
            this.EstadoTreeView.Size = new System.Drawing.Size(363, 286);
            this.EstadoTreeView.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.BrowserUiTab);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5, 30, 0, 5);
            this.panel4.Size = new System.Drawing.Size(958, 503);
            this.panel4.TabIndex = 31;
            // 
            // OrdenCompraBrowserForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(958, 503);
            this.Name = "OrdenCompraBrowserForm";
            this.Text = "PrecioBrowserForm";
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiCommandManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnviarAUiContextMenu)).EndInit();
            this.FondoNicePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BotonesUiPanelManager)).EndInit();
            this.BrowserPanel.ResumeLayout(false);
            this.BrowserGridsPanel.ResumeLayout(false);
            this.BrowserGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrowserGridEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HerramientasUiPanel)).EndInit();
            this.HerramientasUiPanel.ResumeLayout(false);
            this.HerramientasUiPanelContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrowserUiTab)).EndInit();
            this.BrowserUiTab.ResumeLayout(false);
            this.TabBrowserUiTabPage.ResumeLayout(false);
            this.TabFiltroUiTabPage.ResumeLayout(false);
            this.FiltroPanel.ResumeLayout(false);
            this.nicePanel3.ResumeLayout(false);
            this.nicePanel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private Janus.Windows.EditControls.UIButton EnviarAUiButton;
        public Janus.Windows.EditControls.UIButton AltaUiButton;
        protected Janus.Windows.EditControls.UIButton EjecutarSeleccionUiButton;
        private Janus.Windows.EditControls.UIButton CancelarUiButton;
        public Janus.Windows.EditControls.UIButton IngrADepUiButton;
        public Janus.Windows.EditControls.UIButton InspRenarUiButton;
        public Janus.Windows.EditControls.UIButton RegDespUiButton;
        public Janus.Windows.EditControls.UIButton RecepDocsUiButton;
        public Janus.Windows.EditControls.UIButton IngInfoEmbUiButton;
        protected Janus.Windows.EditControls.UIButton AnulacionUiButton;
        private Panel panel4;
        private Panel panel1;
        private Janus.Windows.EditControls.UIButton MinimizarUiButton;
        private Janus.Windows.EditControls.UIButton MaximizarUiButton;
        protected Janus.Windows.EditControls.UIButton SalirUiButton;
    }
}