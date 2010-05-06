Public Class frmLogin
    Inherits System.Windows.Forms.Form

#Region " Código generado por el Diseñador de Windows Forms "
    Public Sub New(ByVal Sistema As String, ByVal Version As String, ByVal IdUsuarioDefault As String)
        Me.New()
        Me.Text = Sistema
        pnlGral.HeaderText = Sistema
        VersionLabel.Text = Version
        IdUsuarioTextBox.Text = IdUsuarioDefault
        PasswordTextBox.Select()
    End Sub

    Private Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

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
    Protected WithEvents pnlGral As PureComponents.NicePanel.NicePanel
    Protected WithEvents label2 As System.Windows.Forms.Label
    Protected WithEvents label1 As System.Windows.Forms.Label
    Public WithEvents IdUsuarioTextBox As System.Windows.Forms.TextBox
    Public WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Public WithEvents LoginInfoValoresLabel As System.Windows.Forms.Label
    Public WithEvents LoginInfoLabel As System.Windows.Forms.Label
    Public WithEvents AceptarLoginInfoButton As System.Windows.Forms.Button
    Public WithEvents CancelarButton As System.Windows.Forms.Button
    Public WithEvents AceptarButton As System.Windows.Forms.Button
    Friend WithEvents VersionLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Me.pnlGral = New PureComponents.NicePanel.NicePanel
        Me.LoginInfoValoresLabel = New System.Windows.Forms.Label
        Me.AceptarLoginInfoButton = New System.Windows.Forms.Button
        Me.IdUsuarioTextBox = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.CancelarButton = New System.Windows.Forms.Button
        Me.AceptarButton = New System.Windows.Forms.Button
        Me.PasswordTextBox = New System.Windows.Forms.TextBox
        Me.LoginInfoLabel = New System.Windows.Forms.Label
        Me.VersionLabel = New System.Windows.Forms.Label
        Me.pnlGral.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlGral
        '
        Me.pnlGral.BackColor = System.Drawing.Color.Transparent
        Me.pnlGral.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomLeft
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.Contact
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 0
        Me.pnlGral.ContainerImage = ContainerImage1
        Me.pnlGral.ContextMenuButton = False
        Me.pnlGral.Controls.Add(Me.VersionLabel)
        Me.pnlGral.Controls.Add(Me.LoginInfoValoresLabel)
        Me.pnlGral.Controls.Add(Me.AceptarLoginInfoButton)
        Me.pnlGral.Controls.Add(Me.IdUsuarioTextBox)
        Me.pnlGral.Controls.Add(Me.label2)
        Me.pnlGral.Controls.Add(Me.label1)
        Me.pnlGral.Controls.Add(Me.CancelarButton)
        Me.pnlGral.Controls.Add(Me.AceptarButton)
        Me.pnlGral.Controls.Add(Me.PasswordTextBox)
        Me.pnlGral.Controls.Add(Me.LoginInfoLabel)
        Me.pnlGral.Dock = System.Windows.Forms.DockStyle.Fill
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.pnlGral.FooterImage = HeaderImage1
        Me.pnlGral.FooterText = "Desarrollado por Cedeira & Asoc. S. A"
        Me.pnlGral.ForeColor = System.Drawing.Color.Black
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.Login
        HeaderImage2.Image = Nothing
        Me.pnlGral.HeaderImage = HeaderImage2
        Me.pnlGral.HeaderText = ""
        Me.pnlGral.IsExpanded = True
        Me.pnlGral.Location = New System.Drawing.Point(0, 0)
        Me.pnlGral.MouseMoveTarget = PureComponents.NicePanel.MouseMoveTarget.Form
        Me.pnlGral.Name = "pnlGral"
        Me.pnlGral.OriginalFooterVisible = True
        Me.pnlGral.OriginalHeight = 182
        Me.pnlGral.ShowChildFocus = False
        Me.pnlGral.Size = New System.Drawing.Size(384, 160)
        ContainerStyle1.BackColor = System.Drawing.Color.Cornsilk
        ContainerStyle1.BaseColor = System.Drawing.Color.Transparent
        ContainerStyle1.BorderColor = System.Drawing.Color.Brown
        ContainerStyle1.BorderStyle = PureComponents.NicePanel.BorderStyle.Solid
        ContainerStyle1.CaptionAlign = PureComponents.NicePanel.CaptionAlign.Left
        ContainerStyle1.FadeColor = System.Drawing.Color.PeachPuff
        ContainerStyle1.FillStyle = PureComponents.NicePanel.FillStyle.DiagonalForward
        ContainerStyle1.FlashItemBackColor = System.Drawing.Color.Red
        ContainerStyle1.FocusItemBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        ContainerStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ContainerStyle1.ForeColor = System.Drawing.Color.Black
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Rounded
        PanelStyle1.ContainerStyle = ContainerStyle1
        PanelHeaderStyle1.BackColor = System.Drawing.Color.Brown
        PanelHeaderStyle1.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle1.FadeColor = System.Drawing.Color.Peru
        PanelHeaderStyle1.FillStyle = PureComponents.NicePanel.FillStyle.HorizontalFading
        PanelHeaderStyle1.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle1.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle1.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        PanelHeaderStyle1.ForeColor = System.Drawing.Color.White
        PanelHeaderStyle1.Size = PureComponents.NicePanel.PanelHeaderSize.Small
        PanelStyle1.FooterStyle = PanelHeaderStyle1
        PanelHeaderStyle2.BackColor = System.Drawing.Color.Peru
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.FromArgb(CType(172, Byte), CType(191, Byte), CType(227, Byte))
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.Brown
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.pnlGral.Style = PanelStyle1
        Me.pnlGral.TabIndex = 0
        '
        'LoginInfoValoresLabel
        '
        Me.LoginInfoValoresLabel.ForeColor = System.Drawing.Color.Navy
        Me.LoginInfoValoresLabel.Location = New System.Drawing.Point(248, 144)
        Me.LoginInfoValoresLabel.Name = "LoginInfoValoresLabel"
        Me.LoginInfoValoresLabel.Size = New System.Drawing.Size(136, 72)
        Me.LoginInfoValoresLabel.TabIndex = 40
        Me.LoginInfoValoresLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LoginInfoValoresLabel.Visible = False
        '
        'AceptarLoginInfoButton
        '
        Me.AceptarLoginInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AceptarLoginInfoButton.ForeColor = System.Drawing.Color.Navy
        Me.AceptarLoginInfoButton.Location = New System.Drawing.Point(112, 224)
        Me.AceptarLoginInfoButton.Name = "AceptarLoginInfoButton"
        Me.AceptarLoginInfoButton.Size = New System.Drawing.Size(264, 30)
        Me.AceptarLoginInfoButton.TabIndex = 38
        Me.AceptarLoginInfoButton.Text = "Aceptar"
        '
        'IdUsuarioTextBox
        '
        Me.IdUsuarioTextBox.BackColor = System.Drawing.Color.White
        Me.IdUsuarioTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IdUsuarioTextBox.Location = New System.Drawing.Point(112, 40)
        Me.IdUsuarioTextBox.Name = "IdUsuarioTextBox"
        Me.IdUsuarioTextBox.Size = New System.Drawing.Size(264, 20)
        Me.IdUsuarioTextBox.TabIndex = 0
        Me.IdUsuarioTextBox.Text = ""
        '
        'label2
        '
        Me.label2.ForeColor = System.Drawing.Color.Navy
        Me.label2.Location = New System.Drawing.Point(8, 72)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(72, 20)
        Me.label2.TabIndex = 36
        Me.label2.Text = "Contraseña:"
        '
        'label1
        '
        Me.label1.ForeColor = System.Drawing.Color.Navy
        Me.label1.Location = New System.Drawing.Point(8, 40)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(112, 20)
        Me.label1.TabIndex = 35
        Me.label1.Text = "Nombre del usuario:"
        '
        'CancelarButton
        '
        Me.CancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CancelarButton.ForeColor = System.Drawing.Color.Navy
        Me.CancelarButton.Location = New System.Drawing.Point(248, 104)
        Me.CancelarButton.Name = "CancelarButton"
        Me.CancelarButton.Size = New System.Drawing.Size(128, 30)
        Me.CancelarButton.TabIndex = 3
        Me.CancelarButton.Text = "Cancelar"
        '
        'AceptarButton
        '
        Me.AceptarButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.AceptarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AceptarButton.ForeColor = System.Drawing.Color.Navy
        Me.AceptarButton.Location = New System.Drawing.Point(112, 104)
        Me.AceptarButton.Name = "AceptarButton"
        Me.AceptarButton.Size = New System.Drawing.Size(128, 30)
        Me.AceptarButton.TabIndex = 2
        Me.AceptarButton.Text = "Aceptar"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.White
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Location = New System.Drawing.Point(112, 72)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Microsoft.VisualBasic.ChrW(88)
        Me.PasswordTextBox.Size = New System.Drawing.Size(264, 20)
        Me.PasswordTextBox.TabIndex = 1
        Me.PasswordTextBox.Text = ""
        '
        'LoginInfoLabel
        '
        Me.LoginInfoLabel.ForeColor = System.Drawing.Color.Navy
        Me.LoginInfoLabel.Location = New System.Drawing.Point(16, 144)
        Me.LoginInfoLabel.Name = "LoginInfoLabel"
        Me.LoginInfoLabel.Size = New System.Drawing.Size(224, 72)
        Me.LoginInfoLabel.TabIndex = 39
        Me.LoginInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LoginInfoLabel.Visible = False
        '
        'VersionLabel
        '
        Me.VersionLabel.ForeColor = System.Drawing.Color.White
        Me.VersionLabel.Location = New System.Drawing.Point(240, 10)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(136, 11)
        Me.VersionLabel.TabIndex = 41
        Me.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmLogin
        '
        Me.AcceptButton = Me.AceptarButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.CancelarButton
        Me.ClientSize = New System.Drawing.Size(384, 160)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlGral)
        Me.ForeColor = System.Drawing.Color.Navy
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLogin"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.pnlGral.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
