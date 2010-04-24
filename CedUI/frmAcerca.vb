Public Class frmAcerca
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal Sistema As String, ByVal CodigoSistema As String, ByVal Version As String, ByVal Segundos As Integer)
        MyBase.New()
        InitializeComponent()
        SistemaLabel.Text = Sistema
        CodigoSistemaLabel.Text = CodigoSistema
        VersionLabel.Text = Version
        If Segundos > 0 Then
            Timer1.Interval = Segundos * 1000
            Timer1.Enabled = True
            SalirButton.Visible = False
        End If

    End Sub

#Region " Código generado por el Diseñador de Windows Forms "


    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents SistemaLabel As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CodigoSistemaLabel As System.Windows.Forms.Label
    Friend WithEvents pictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents SalirButton As System.Windows.Forms.Button
    Friend WithEvents pnlGral As PureComponents.NicePanel.NicePanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcerca))
        Me.SistemaLabel = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlGral = New PureComponents.NicePanel.NicePanel
        Me.SalirButton = New System.Windows.Forms.Button
        Me.VersionLabel = New System.Windows.Forms.Label
        Me.CodigoSistemaLabel = New System.Windows.Forms.Label
        Me.pictureBox2 = New System.Windows.Forms.PictureBox
        Me.pnlGral.SuspendLayout()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SistemaLabel
        '
        Me.SistemaLabel.BackColor = System.Drawing.Color.Transparent
        Me.SistemaLabel.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SistemaLabel.ForeColor = System.Drawing.Color.Brown
        Me.SistemaLabel.Location = New System.Drawing.Point(8, 48)
        Me.SistemaLabel.Name = "SistemaLabel"
        Me.SistemaLabel.Size = New System.Drawing.Size(352, 32)
        Me.SistemaLabel.TabIndex = 5
        Me.SistemaLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Timer1
        '
        '
        'pnlGral
        '
        Me.pnlGral.BackColor = System.Drawing.Color.Transparent
        Me.pnlGral.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomLeft
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 0
        Me.pnlGral.ContainerImage = ContainerImage1
        Me.pnlGral.ContextMenuButton = False
        Me.pnlGral.Controls.Add(Me.SalirButton)
        Me.pnlGral.Controls.Add(Me.VersionLabel)
        Me.pnlGral.Controls.Add(Me.CodigoSistemaLabel)
        Me.pnlGral.Controls.Add(Me.pictureBox2)
        Me.pnlGral.Controls.Add(Me.SistemaLabel)
        Me.pnlGral.Dock = System.Windows.Forms.DockStyle.Fill
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.pnlGral.FooterImage = HeaderImage1
        Me.pnlGral.FooterText = "Desarrollado por Cedeira & Asoc. S. A"
        Me.pnlGral.FooterVisible = False
        Me.pnlGral.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage2.Image = Nothing
        Me.pnlGral.HeaderImage = HeaderImage2
        Me.pnlGral.HeaderText = "Tableros de PFs y CCEs"
        Me.pnlGral.HeaderVisible = False
        Me.pnlGral.IsExpanded = True
        Me.pnlGral.Location = New System.Drawing.Point(0, 0)
        Me.pnlGral.MouseMoveTarget = PureComponents.NicePanel.MouseMoveTarget.Form
        Me.pnlGral.Name = "pnlGral"
        Me.pnlGral.OriginalFooterVisible = False
        Me.pnlGral.OriginalHeight = 182
        Me.pnlGral.ShowChildFocus = False
        Me.pnlGral.Size = New System.Drawing.Size(366, 206)
        ContainerStyle1.BackColor = System.Drawing.Color.Cornsilk
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.Brown
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.PeachPuff
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        ContainerStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Rounded
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(237, Byte), Integer))
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(215, Byte), Integer))
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(227, Byte), Integer))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(127, Byte), Integer))
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(1, Byte), Integer))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(159, Byte), Integer))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.pnlGral.Style = PanelStyle1
        Me.pnlGral.TabIndex = 32
        '
        'SalirButton
        '
        Me.SalirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SalirButton.ForeColor = System.Drawing.Color.Navy
        Me.SalirButton.Location = New System.Drawing.Point(279, 171)
        Me.SalirButton.Name = "SalirButton"
        Me.SalirButton.Size = New System.Drawing.Size(75, 23)
        Me.SalirButton.TabIndex = 13
        Me.SalirButton.Text = "Salir"
        Me.SalirButton.UseVisualStyleBackColor = True
        '
        'VersionLabel
        '
        Me.VersionLabel.BackColor = System.Drawing.Color.Transparent
        Me.VersionLabel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.ForeColor = System.Drawing.Color.Brown
        Me.VersionLabel.Location = New System.Drawing.Point(8, 108)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(352, 16)
        Me.VersionLabel.TabIndex = 12
        Me.VersionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CodigoSistemaLabel
        '
        Me.CodigoSistemaLabel.BackColor = System.Drawing.Color.Transparent
        Me.CodigoSistemaLabel.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodigoSistemaLabel.ForeColor = System.Drawing.Color.Brown
        Me.CodigoSistemaLabel.Location = New System.Drawing.Point(7, 80)
        Me.CodigoSistemaLabel.Name = "CodigoSistemaLabel"
        Me.CodigoSistemaLabel.Size = New System.Drawing.Size(352, 32)
        Me.CodigoSistemaLabel.TabIndex = 11
        Me.CodigoSistemaLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pictureBox2
        '
        Me.pictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox2.Image = CType(resources.GetObject("pictureBox2.Image"), System.Drawing.Image)
        Me.pictureBox2.Location = New System.Drawing.Point(112, 156)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(144, 42)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox2.TabIndex = 10
        Me.pictureBox2.TabStop = False
        '
        'frmAcerca
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(366, 206)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlGral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAcerca"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.pnlGral.ResumeLayout(False)
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Close()
    End Sub

    Private Sub SalirButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirButton.Click
        Timer1.Stop()
        Me.Close()
    End Sub
End Class
