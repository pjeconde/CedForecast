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
            this.BotonesPanel = new System.Windows.Forms.Panel();
            this.OtrosBotonesPanel = new System.Windows.Forms.Panel();
            this.SalirUiButton = new Janus.Windows.EditControls.UIButton();
            this.AceptarUiButton = new Janus.Windows.EditControls.UIButton();
            this.ArticuloUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.CuentaUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ClienteUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.VentaUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ProyeccionAnualUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ZonaUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.RollingForecastUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.ArticuloUIProgressBar = new Janus.Windows.EditControls.UIProgressBar();
            this.ClienteUiProgressBar = new Janus.Windows.EditControls.UIProgressBar();
            this.CuentaUiProgressBar = new Janus.Windows.EditControls.UIProgressBar();
            this.ZonaUiProgressBar = new Janus.Windows.EditControls.UIProgressBar();
            this.VentaUiProgressBar = new Janus.Windows.EditControls.UIProgressBar();
            this.ProyeccionAnualUiProgressBar = new Janus.Windows.EditControls.UIProgressBar();
            this.RollingForecastUiProgressBar = new Janus.Windows.EditControls.UIProgressBar();
            this.VentaCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.ProyeccionAnualCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.RollingForecastCalendarCombo = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.EnviarTodoUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.RecibirTodoUiCheckBox = new Janus.Windows.EditControls.UICheckBox();
            this.FondoNicePanel.SuspendLayout();
            this.BotonesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FondoNicePanel
            // 
            this.FondoNicePanel.Controls.Add(this.panel2);
            this.FondoNicePanel.Controls.Add(this.panel1);
            this.FondoNicePanel.Controls.Add(this.pictureBox1);
            this.FondoNicePanel.Controls.Add(this.BotonesPanel);
            this.FondoNicePanel.Size = new System.Drawing.Size(411, 386);
            // 
            // BotonesPanel
            // 
            this.BotonesPanel.Controls.Add(this.OtrosBotonesPanel);
            this.BotonesPanel.Controls.Add(this.SalirUiButton);
            this.BotonesPanel.Controls.Add(this.AceptarUiButton);
            this.BotonesPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BotonesPanel.Location = new System.Drawing.Point(0, 351);
            this.BotonesPanel.Name = "BotonesPanel";
            this.BotonesPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.BotonesPanel.Size = new System.Drawing.Size(411, 35);
            this.BotonesPanel.TabIndex = 9001;
            // 
            // OtrosBotonesPanel
            // 
            this.OtrosBotonesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OtrosBotonesPanel.Location = new System.Drawing.Point(104, 5);
            this.OtrosBotonesPanel.Name = "OtrosBotonesPanel";
            this.OtrosBotonesPanel.Size = new System.Drawing.Size(225, 25);
            this.OtrosBotonesPanel.TabIndex = 2;
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
            this.SalirUiButton.Location = new System.Drawing.Point(329, 5);
            this.SalirUiButton.Name = "SalirUiButton";
            this.SalirUiButton.ShowFocusRectangle = false;
            this.SalirUiButton.Size = new System.Drawing.Size(72, 25);
            this.SalirUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.SalirUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.SalirUiButton.TabIndex = 1;
            this.SalirUiButton.TabStop = false;
            this.SalirUiButton.Text = "Cancelar";
            this.SalirUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Far;
            this.SalirUiButton.UseThemes = false;
            this.SalirUiButton.Click += new System.EventHandler(this.SalirUiButton_Click);
            // 
            // AceptarUiButton
            // 
            this.AceptarUiButton.Appearance = Janus.Windows.UI.Appearance.FlatBorderless;
            this.AceptarUiButton.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.Button;
            this.AceptarUiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AceptarUiButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AceptarUiButton.FlatBorderColor = System.Drawing.Color.Navy;
            this.AceptarUiButton.Icon = ((System.Drawing.Icon)(resources.GetObject("AceptarUiButton.Icon")));
            this.AceptarUiButton.Location = new System.Drawing.Point(10, 5);
            this.AceptarUiButton.Name = "AceptarUiButton";
            this.AceptarUiButton.ShowFocusRectangle = false;
            this.AceptarUiButton.Size = new System.Drawing.Size(94, 25);
            this.AceptarUiButton.StateStyles.FormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.AceptarUiButton.StateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy;
            this.AceptarUiButton.TabIndex = 0;
            this.AceptarUiButton.TabStop = false;
            this.AceptarUiButton.Text = "Aceptar";
            this.AceptarUiButton.TextHorizontalAlignment = Janus.Windows.EditControls.TextAlignment.Near;
            this.AceptarUiButton.UseThemes = false;
            this.AceptarUiButton.Click += new System.EventHandler(this.AceptarUiButton_Click);
            // 
            // ArticuloUiCheckBox
            // 
            this.ArticuloUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.ArticuloUiCheckBox.Location = new System.Drawing.Point(11, 28);
            this.ArticuloUiCheckBox.Name = "ArticuloUiCheckBox";
            this.ArticuloUiCheckBox.ShowFocusRectangle = false;
            this.ArticuloUiCheckBox.Size = new System.Drawing.Size(118, 20);
            this.ArticuloUiCheckBox.TabIndex = 9014;
            this.ArticuloUiCheckBox.Text = "Articulos";
            this.ArticuloUiCheckBox.UseThemes = false;
            this.ArticuloUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // CuentaUiCheckBox
            // 
            this.CuentaUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.CuentaUiCheckBox.Location = new System.Drawing.Point(11, 76);
            this.CuentaUiCheckBox.Name = "CuentaUiCheckBox";
            this.CuentaUiCheckBox.ShowFocusRectangle = false;
            this.CuentaUiCheckBox.Size = new System.Drawing.Size(118, 20);
            this.CuentaUiCheckBox.TabIndex = 9015;
            this.CuentaUiCheckBox.Text = "Vendedores";
            this.CuentaUiCheckBox.UseThemes = false;
            this.CuentaUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // ClienteUiCheckBox
            // 
            this.ClienteUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.ClienteUiCheckBox.Location = new System.Drawing.Point(11, 52);
            this.ClienteUiCheckBox.Name = "ClienteUiCheckBox";
            this.ClienteUiCheckBox.ShowFocusRectangle = false;
            this.ClienteUiCheckBox.Size = new System.Drawing.Size(118, 20);
            this.ClienteUiCheckBox.TabIndex = 9016;
            this.ClienteUiCheckBox.Text = "Clientes";
            this.ClienteUiCheckBox.UseThemes = false;
            this.ClienteUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // VentaUiCheckBox
            // 
            this.VentaUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.VentaUiCheckBox.Location = new System.Drawing.Point(11, 100);
            this.VentaUiCheckBox.Name = "VentaUiCheckBox";
            this.VentaUiCheckBox.ShowFocusRectangle = false;
            this.VentaUiCheckBox.Size = new System.Drawing.Size(118, 20);
            this.VentaUiCheckBox.TabIndex = 9017;
            this.VentaUiCheckBox.Text = "Ventas del mes";
            this.VentaUiCheckBox.UseThemes = false;
            this.VentaUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // ProyeccionAnualUiCheckBox
            // 
            this.ProyeccionAnualUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.ProyeccionAnualUiCheckBox.Location = new System.Drawing.Point(11, 34);
            this.ProyeccionAnualUiCheckBox.Name = "ProyeccionAnualUiCheckBox";
            this.ProyeccionAnualUiCheckBox.ShowFocusRectangle = false;
            this.ProyeccionAnualUiCheckBox.Size = new System.Drawing.Size(118, 20);
            this.ProyeccionAnualUiCheckBox.TabIndex = 9018;
            this.ProyeccionAnualUiCheckBox.Text = "Proyeccion anual";
            this.ProyeccionAnualUiCheckBox.UseThemes = false;
            this.ProyeccionAnualUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // ZonaUiCheckBox
            // 
            this.ZonaUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.ZonaUiCheckBox.Location = new System.Drawing.Point(11, 124);
            this.ZonaUiCheckBox.Name = "ZonaUiCheckBox";
            this.ZonaUiCheckBox.ShowFocusRectangle = false;
            this.ZonaUiCheckBox.Size = new System.Drawing.Size(118, 20);
            this.ZonaUiCheckBox.TabIndex = 9019;
            this.ZonaUiCheckBox.Text = "Zonas";
            this.ZonaUiCheckBox.UseThemes = false;
            this.ZonaUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // RollingForecastUiCheckBox
            // 
            this.RollingForecastUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.RollingForecastUiCheckBox.Location = new System.Drawing.Point(11, 58);
            this.RollingForecastUiCheckBox.Name = "RollingForecastUiCheckBox";
            this.RollingForecastUiCheckBox.ShowFocusRectangle = false;
            this.RollingForecastUiCheckBox.Size = new System.Drawing.Size(107, 20);
            this.RollingForecastUiCheckBox.TabIndex = 9020;
            this.RollingForecastUiCheckBox.Text = "Rolling Forecast";
            this.RollingForecastUiCheckBox.UseThemes = false;
            this.RollingForecastUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            // 
            // ArticuloUIProgressBar
            // 
            this.ArticuloUIProgressBar.BackgroundFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.ArticuloUIProgressBar.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Transparent;
            this.ArticuloUIProgressBar.BorderStyle = Janus.Windows.UI.BorderStyle.Flat;
            this.ArticuloUIProgressBar.FlatBorderColor = System.Drawing.Color.Transparent;
            this.ArticuloUIProgressBar.Location = new System.Drawing.Point(241, 28);
            this.ArticuloUIProgressBar.Name = "ArticuloUIProgressBar";
            this.ArticuloUIProgressBar.ProgressFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.ArticuloUIProgressBar.ProgressFormatStyle.ForeColor = System.Drawing.Color.Brown;
            this.ArticuloUIProgressBar.Size = new System.Drawing.Size(129, 20);
            this.ArticuloUIProgressBar.TabIndex = 9027;
            this.ArticuloUIProgressBar.UseThemes = false;
            // 
            // ClienteUiProgressBar
            // 
            this.ClienteUiProgressBar.BackgroundFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.ClienteUiProgressBar.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Transparent;
            this.ClienteUiProgressBar.BorderStyle = Janus.Windows.UI.BorderStyle.Flat;
            this.ClienteUiProgressBar.FlatBorderColor = System.Drawing.Color.Transparent;
            this.ClienteUiProgressBar.Location = new System.Drawing.Point(241, 52);
            this.ClienteUiProgressBar.Name = "ClienteUiProgressBar";
            this.ClienteUiProgressBar.ProgressFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.ClienteUiProgressBar.ProgressFormatStyle.ForeColor = System.Drawing.Color.Brown;
            this.ClienteUiProgressBar.Size = new System.Drawing.Size(129, 20);
            this.ClienteUiProgressBar.TabIndex = 9028;
            this.ClienteUiProgressBar.UseThemes = false;
            // 
            // CuentaUiProgressBar
            // 
            this.CuentaUiProgressBar.BackgroundFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.CuentaUiProgressBar.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Transparent;
            this.CuentaUiProgressBar.BorderStyle = Janus.Windows.UI.BorderStyle.Flat;
            this.CuentaUiProgressBar.FlatBorderColor = System.Drawing.Color.Transparent;
            this.CuentaUiProgressBar.Location = new System.Drawing.Point(241, 76);
            this.CuentaUiProgressBar.Name = "CuentaUiProgressBar";
            this.CuentaUiProgressBar.ProgressFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.CuentaUiProgressBar.ProgressFormatStyle.ForeColor = System.Drawing.Color.Brown;
            this.CuentaUiProgressBar.Size = new System.Drawing.Size(129, 20);
            this.CuentaUiProgressBar.TabIndex = 9029;
            this.CuentaUiProgressBar.UseThemes = false;
            // 
            // ZonaUiProgressBar
            // 
            this.ZonaUiProgressBar.BackgroundFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.ZonaUiProgressBar.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Transparent;
            this.ZonaUiProgressBar.BorderStyle = Janus.Windows.UI.BorderStyle.Flat;
            this.ZonaUiProgressBar.FlatBorderColor = System.Drawing.Color.Transparent;
            this.ZonaUiProgressBar.Location = new System.Drawing.Point(241, 124);
            this.ZonaUiProgressBar.Name = "ZonaUiProgressBar";
            this.ZonaUiProgressBar.ProgressFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.ZonaUiProgressBar.ProgressFormatStyle.ForeColor = System.Drawing.Color.Brown;
            this.ZonaUiProgressBar.Size = new System.Drawing.Size(129, 20);
            this.ZonaUiProgressBar.TabIndex = 9030;
            this.ZonaUiProgressBar.UseThemes = false;
            // 
            // VentaUiProgressBar
            // 
            this.VentaUiProgressBar.BackgroundFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.VentaUiProgressBar.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Transparent;
            this.VentaUiProgressBar.BorderStyle = Janus.Windows.UI.BorderStyle.Flat;
            this.VentaUiProgressBar.FlatBorderColor = System.Drawing.Color.Transparent;
            this.VentaUiProgressBar.Location = new System.Drawing.Point(241, 100);
            this.VentaUiProgressBar.Name = "VentaUiProgressBar";
            this.VentaUiProgressBar.ProgressFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.VentaUiProgressBar.ProgressFormatStyle.ForeColor = System.Drawing.Color.Brown;
            this.VentaUiProgressBar.Size = new System.Drawing.Size(129, 20);
            this.VentaUiProgressBar.TabIndex = 9031;
            this.VentaUiProgressBar.UseThemes = false;
            // 
            // ProyeccionAnualUiProgressBar
            // 
            this.ProyeccionAnualUiProgressBar.BackgroundFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.ProyeccionAnualUiProgressBar.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Transparent;
            this.ProyeccionAnualUiProgressBar.BorderStyle = Janus.Windows.UI.BorderStyle.Flat;
            this.ProyeccionAnualUiProgressBar.FlatBorderColor = System.Drawing.Color.Transparent;
            this.ProyeccionAnualUiProgressBar.Location = new System.Drawing.Point(241, 34);
            this.ProyeccionAnualUiProgressBar.Name = "ProyeccionAnualUiProgressBar";
            this.ProyeccionAnualUiProgressBar.ProgressFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.ProyeccionAnualUiProgressBar.ProgressFormatStyle.ForeColor = System.Drawing.Color.Brown;
            this.ProyeccionAnualUiProgressBar.Size = new System.Drawing.Size(129, 20);
            this.ProyeccionAnualUiProgressBar.TabIndex = 9032;
            this.ProyeccionAnualUiProgressBar.UseThemes = false;
            // 
            // RollingForecastUiProgressBar
            // 
            this.RollingForecastUiProgressBar.BackgroundFormatStyle.BackColor = System.Drawing.Color.Transparent;
            this.RollingForecastUiProgressBar.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Transparent;
            this.RollingForecastUiProgressBar.BorderStyle = Janus.Windows.UI.BorderStyle.Flat;
            this.RollingForecastUiProgressBar.FlatBorderColor = System.Drawing.Color.Transparent;
            this.RollingForecastUiProgressBar.Location = new System.Drawing.Point(241, 58);
            this.RollingForecastUiProgressBar.Name = "RollingForecastUiProgressBar";
            this.RollingForecastUiProgressBar.ProgressFormatStyle.BackColor = System.Drawing.Color.Cornsilk;
            this.RollingForecastUiProgressBar.ProgressFormatStyle.ForeColor = System.Drawing.Color.Brown;
            this.RollingForecastUiProgressBar.Size = new System.Drawing.Size(129, 20);
            this.RollingForecastUiProgressBar.TabIndex = 9033;
            this.RollingForecastUiProgressBar.UseThemes = false;
            // 
            // VentaCalendarCombo
            // 
            this.VentaCalendarCombo.BackColor = System.Drawing.Color.White;
            this.VentaCalendarCombo.CustomFormat = "MM/yyyy";
            this.VentaCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.VentaCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2008, 9, 1, 0, 0, 0, 0);
            this.VentaCalendarCombo.DropDownCalendar.Location = new System.Drawing.Point(15, 35);
            this.VentaCalendarCombo.DropDownCalendar.Name = "";
            this.VentaCalendarCombo.DropDownCalendar.Size = new System.Drawing.Size(170, 173);
            this.VentaCalendarCombo.DropDownCalendar.TabIndex = 0;
            this.VentaCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.VentaCalendarCombo.FlatBorderColor = System.Drawing.Color.Black;
            this.VentaCalendarCombo.ForeColor = System.Drawing.Color.Black;
            this.VentaCalendarCombo.Location = new System.Drawing.Point(123, 100);
            this.VentaCalendarCombo.Name = "VentaCalendarCombo";
            this.VentaCalendarCombo.Size = new System.Drawing.Size(70, 20);
            this.VentaCalendarCombo.TabIndex = 9034;
            this.VentaCalendarCombo.ThemedAreas = Janus.Windows.CalendarCombo.ThemedArea.None;
            this.VentaCalendarCombo.TodayButtonText = "Hoy";
            this.VentaCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // ProyeccionAnualCalendarCombo
            // 
            this.ProyeccionAnualCalendarCombo.BackColor = System.Drawing.Color.White;
            this.ProyeccionAnualCalendarCombo.CustomFormat = "yyyy";
            this.ProyeccionAnualCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.ProyeccionAnualCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2008, 9, 1, 0, 0, 0, 0);
            this.ProyeccionAnualCalendarCombo.DropDownCalendar.Location = new System.Drawing.Point(15, 35);
            this.ProyeccionAnualCalendarCombo.DropDownCalendar.Name = "";
            this.ProyeccionAnualCalendarCombo.DropDownCalendar.Size = new System.Drawing.Size(170, 173);
            this.ProyeccionAnualCalendarCombo.DropDownCalendar.TabIndex = 0;
            this.ProyeccionAnualCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.ProyeccionAnualCalendarCombo.FlatBorderColor = System.Drawing.Color.Black;
            this.ProyeccionAnualCalendarCombo.ForeColor = System.Drawing.Color.Black;
            this.ProyeccionAnualCalendarCombo.Location = new System.Drawing.Point(123, 34);
            this.ProyeccionAnualCalendarCombo.Name = "ProyeccionAnualCalendarCombo";
            this.ProyeccionAnualCalendarCombo.Size = new System.Drawing.Size(50, 20);
            this.ProyeccionAnualCalendarCombo.TabIndex = 9035;
            this.ProyeccionAnualCalendarCombo.ThemedAreas = Janus.Windows.CalendarCombo.ThemedArea.None;
            this.ProyeccionAnualCalendarCombo.TodayButtonText = "Hoy";
            this.ProyeccionAnualCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // RollingForecastCalendarCombo
            // 
            this.RollingForecastCalendarCombo.BackColor = System.Drawing.Color.White;
            this.RollingForecastCalendarCombo.CustomFormat = "MM/yyyy";
            this.RollingForecastCalendarCombo.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Custom;
            // 
            // 
            // 
            this.RollingForecastCalendarCombo.DropDownCalendar.FirstMonth = new System.DateTime(2008, 9, 1, 0, 0, 0, 0);
            this.RollingForecastCalendarCombo.DropDownCalendar.Location = new System.Drawing.Point(15, 35);
            this.RollingForecastCalendarCombo.DropDownCalendar.Name = "";
            this.RollingForecastCalendarCombo.DropDownCalendar.Size = new System.Drawing.Size(170, 173);
            this.RollingForecastCalendarCombo.DropDownCalendar.TabIndex = 0;
            this.RollingForecastCalendarCombo.DropDownCalendar.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            this.RollingForecastCalendarCombo.FlatBorderColor = System.Drawing.Color.Black;
            this.RollingForecastCalendarCombo.ForeColor = System.Drawing.Color.Black;
            this.RollingForecastCalendarCombo.Location = new System.Drawing.Point(160, 58);
            this.RollingForecastCalendarCombo.Name = "RollingForecastCalendarCombo";
            this.RollingForecastCalendarCombo.Size = new System.Drawing.Size(70, 20);
            this.RollingForecastCalendarCombo.TabIndex = 9036;
            this.RollingForecastCalendarCombo.ThemedAreas = Janus.Windows.CalendarCombo.ThemedArea.None;
            this.RollingForecastCalendarCombo.TodayButtonText = "Hoy";
            this.RollingForecastCalendarCombo.VisualStyle = Janus.Windows.CalendarCombo.VisualStyle.Office2003;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(122, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 20);
            this.label7.TabIndex = 9037;
            this.label7.Text = "desde";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(99, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 61);
            this.pictureBox1.TabIndex = 9038;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.EnviarTodoUiCheckBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ArticuloUiCheckBox);
            this.panel1.Controls.Add(this.CuentaUiCheckBox);
            this.panel1.Controls.Add(this.ClienteUiCheckBox);
            this.panel1.Controls.Add(this.VentaCalendarCombo);
            this.panel1.Controls.Add(this.ZonaUiCheckBox);
            this.panel1.Controls.Add(this.ArticuloUIProgressBar);
            this.panel1.Controls.Add(this.ClienteUiProgressBar);
            this.panel1.Controls.Add(this.VentaUiProgressBar);
            this.panel1.Controls.Add(this.CuentaUiProgressBar);
            this.panel1.Controls.Add(this.ZonaUiProgressBar);
            this.panel1.Controls.Add(this.VentaUiCheckBox);
            this.panel1.Location = new System.Drawing.Point(12, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 157);
            this.panel1.TabIndex = 9039;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkGreen;
            this.label8.Location = new System.Drawing.Point(158, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 24);
            this.label8.TabIndex = 9024;
            this.label8.Text = "Envíar";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.RecibirTodoUiCheckBox);
            this.panel2.Controls.Add(this.ProyeccionAnualUiProgressBar);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.RollingForecastUiCheckBox);
            this.panel2.Controls.Add(this.RollingForecastCalendarCombo);
            this.panel2.Controls.Add(this.RollingForecastUiProgressBar);
            this.panel2.Controls.Add(this.ProyeccionAnualCalendarCombo);
            this.panel2.Controls.Add(this.ProyeccionAnualUiCheckBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 87);
            this.panel2.TabIndex = 9040;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(154, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 24);
            this.label1.TabIndex = 9025;
            this.label1.Text = "Recibir";
            // 
            // EnviarTodoUiCheckBox
            // 
            this.EnviarTodoUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.EnviarTodoUiCheckBox.Location = new System.Drawing.Point(241, 8);
            this.EnviarTodoUiCheckBox.Name = "EnviarTodoUiCheckBox";
            this.EnviarTodoUiCheckBox.ShowFocusRectangle = false;
            this.EnviarTodoUiCheckBox.Size = new System.Drawing.Size(56, 20);
            this.EnviarTodoUiCheckBox.TabIndex = 9035;
            this.EnviarTodoUiCheckBox.Text = "todo";
            this.EnviarTodoUiCheckBox.UseThemes = false;
            this.EnviarTodoUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.EnviarTodoUiCheckBox.CheckedChanged += new System.EventHandler(this.EnviarTodoUiCheckBox_CheckedChanged);
            // 
            // RecibirTodoUiCheckBox
            // 
            this.RecibirTodoUiCheckBox.ForeColor = System.Drawing.Color.Navy;
            this.RecibirTodoUiCheckBox.Location = new System.Drawing.Point(241, 8);
            this.RecibirTodoUiCheckBox.Name = "RecibirTodoUiCheckBox";
            this.RecibirTodoUiCheckBox.ShowFocusRectangle = false;
            this.RecibirTodoUiCheckBox.Size = new System.Drawing.Size(56, 20);
            this.RecibirTodoUiCheckBox.TabIndex = 9038;
            this.RecibirTodoUiCheckBox.Text = "todo";
            this.RecibirTodoUiCheckBox.UseThemes = false;
            this.RecibirTodoUiCheckBox.VisualStyle = Janus.Windows.UI.VisualStyle.OfficeXP;
            this.RecibirTodoUiCheckBox.CheckedChanged += new System.EventHandler(this.RecibirTodoUiCheckBox_CheckedChanged);
            // 
            // SincronizacionForm
            // 
            this.ClientSize = new System.Drawing.Size(411, 386);
            this.Name = "SincronizacionForm";
            this.FondoNicePanel.ResumeLayout(false);
            this.BotonesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel BotonesPanel;
        protected System.Windows.Forms.Panel OtrosBotonesPanel;
        public Janus.Windows.EditControls.UIButton SalirUiButton;
        protected Janus.Windows.EditControls.UIButton AceptarUiButton;
        private Janus.Windows.EditControls.UICheckBox RollingForecastUiCheckBox;
        private Janus.Windows.EditControls.UICheckBox ZonaUiCheckBox;
        private Janus.Windows.EditControls.UICheckBox ProyeccionAnualUiCheckBox;
        private Janus.Windows.EditControls.UICheckBox VentaUiCheckBox;
        private Janus.Windows.EditControls.UICheckBox ClienteUiCheckBox;
        private Janus.Windows.EditControls.UICheckBox CuentaUiCheckBox;
        private Janus.Windows.EditControls.UICheckBox ArticuloUiCheckBox;
        private Janus.Windows.EditControls.UIProgressBar RollingForecastUiProgressBar;
        private Janus.Windows.EditControls.UIProgressBar ProyeccionAnualUiProgressBar;
        private Janus.Windows.EditControls.UIProgressBar VentaUiProgressBar;
        private Janus.Windows.EditControls.UIProgressBar ZonaUiProgressBar;
        private Janus.Windows.EditControls.UIProgressBar CuentaUiProgressBar;
        private Janus.Windows.EditControls.UIProgressBar ClienteUiProgressBar;
        private Janus.Windows.EditControls.UIProgressBar ArticuloUIProgressBar;
        private Janus.Windows.CalendarCombo.CalendarCombo ProyeccionAnualCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo VentaCalendarCombo;
        private Janus.Windows.CalendarCombo.CalendarCombo RollingForecastCalendarCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Janus.Windows.EditControls.UICheckBox EnviarTodoUiCheckBox;
        private Janus.Windows.EditControls.UICheckBox RecibirTodoUiCheckBox;
    }
}
