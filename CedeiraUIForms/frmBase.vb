
Public Class frmBase
    Inherits System.Windows.Forms.Form

    Public ReadOnly Property Titulo() As String
        Get
            Titulo = FondoNicePanel.HeaderText
        End Get
    End Property
    Protected Sub MostrarMensajeError(ByVal ex As System.Exception)
        Cedeira.UI.Mostrar.Excepcion(ex)
    End Sub

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal Titulo As String)
        Me.New()
        FondoNicePanel.HeaderText = Titulo
        Me.Text = Titulo
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
    Protected WithEvents FondoNicePanel As PureComponents.NicePanel.NicePanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim ContainerImage1 As PureComponents.NicePanel.ContainerImage = New PureComponents.NicePanel.ContainerImage
        Dim HeaderImage1 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim HeaderImage2 As PureComponents.NicePanel.HeaderImage = New PureComponents.NicePanel.HeaderImage
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBase))
        Dim PanelStyle1 As PureComponents.NicePanel.PanelStyle = New PureComponents.NicePanel.PanelStyle
        Dim ContainerStyle1 As PureComponents.NicePanel.ContainerStyle = New PureComponents.NicePanel.ContainerStyle
        Dim PanelHeaderStyle1 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Dim PanelHeaderStyle2 As PureComponents.NicePanel.PanelHeaderStyle = New PureComponents.NicePanel.PanelHeaderStyle
        Me.FondoNicePanel = New PureComponents.NicePanel.NicePanel
        Me.SuspendLayout()
        '
        'FondoNicePanel
        '
        Me.FondoNicePanel.BackColor = System.Drawing.Color.Transparent
        Me.FondoNicePanel.CollapseButton = False
        ContainerImage1.Alignment = System.Drawing.ContentAlignment.BottomLeft
        ContainerImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        ContainerImage1.Image = Nothing
        ContainerImage1.Size = PureComponents.NicePanel.ContainerImageSize.Small
        ContainerImage1.Transparency = 0
        Me.FondoNicePanel.ContainerImage = ContainerImage1
        Me.FondoNicePanel.ContextMenuButton = False
        Me.FondoNicePanel.Dock = System.Windows.Forms.DockStyle.Fill
        HeaderImage1.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage1.Image = Nothing
        Me.FondoNicePanel.FooterImage = HeaderImage1
        Me.FondoNicePanel.FooterText = ""
        Me.FondoNicePanel.FooterVisible = False
        Me.FondoNicePanel.ForeColor = System.Drawing.Color.Navy
        HeaderImage2.ClipArt = PureComponents.NicePanel.ImageClipArt.None
        HeaderImage2.Image = CType(resources.GetObject("HeaderImage2.Image"), System.Drawing.Image)
        Me.FondoNicePanel.HeaderImage = HeaderImage2
        Me.FondoNicePanel.HeaderText = ""
        Me.FondoNicePanel.IsExpanded = True
        Me.FondoNicePanel.Location = New System.Drawing.Point(0, 0)
        Me.FondoNicePanel.MouseMoveTarget = PureComponents.NicePanel.MouseMoveTarget.Form
        Me.FondoNicePanel.Name = "FondoNicePanel"
        Me.FondoNicePanel.OriginalFooterVisible = False
        Me.FondoNicePanel.OriginalHeight = 182
        Me.FondoNicePanel.ShowChildFocus = False
        Me.FondoNicePanel.Size = New System.Drawing.Size(602, 391)
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
        ContainerStyle1.ForeColor = System.Drawing.Color.Navy
        ContainerStyle1.Shape = PureComponents.NicePanel.Shape.Squared
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
        PanelHeaderStyle2.ButtonColor = System.Drawing.Color.Cornsilk
        PanelHeaderStyle2.FadeColor = System.Drawing.Color.Brown
        PanelHeaderStyle2.FillStyle = PureComponents.NicePanel.FillStyle.VerticalFading
        PanelHeaderStyle2.FlashBackColor = System.Drawing.Color.FromArgb(CType(243, Byte), CType(122, Byte), CType(1, Byte))
        PanelHeaderStyle2.FlashFadeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(215, Byte), CType(159, Byte))
        PanelHeaderStyle2.FlashForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        PanelHeaderStyle2.ForeColor = System.Drawing.Color.White
        PanelHeaderStyle2.Size = PureComponents.NicePanel.PanelHeaderSize.Medium
        PanelStyle1.HeaderStyle = PanelHeaderStyle2
        Me.FondoNicePanel.Style = PanelStyle1
        Me.FondoNicePanel.TabIndex = 1
        '
        'frmBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(602, 391)
        Me.Controls.Add(Me.FondoNicePanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim loProcess As System.Diagnostics.Process
        loProcess = System.Diagnostics.Process.GetCurrentProcess()
        Dim setMax As IntPtr = New IntPtr(10000000)
        Dim setMin As IntPtr = New IntPtr(5000000)
        loProcess.MaxWorkingSet = setMax
        loProcess.MinWorkingSet = setMin
    End Sub

    Private Sub frmBase_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Dim loProcess As System.Diagnostics.Process
        loProcess = System.Diagnostics.Process.GetCurrentProcess()
        Dim setMax As IntPtr = New IntPtr(10000000)
        Dim setMin As IntPtr = New IntPtr(5000000)
        loProcess.MaxWorkingSet = setMax
        loProcess.MinWorkingSet = setMin
    End Sub
End Class
