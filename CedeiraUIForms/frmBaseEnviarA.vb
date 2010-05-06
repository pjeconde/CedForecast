Public Class frmBaseEnviarA
    Inherits UI.frmBase

    Public Sub fcicomThread()
        Dim x As New Interop.CedFCIcom.clsCedFCIxlsClass
        Try
            x.filename = "instancia de pre cacheo"
        Catch
        Finally
            x = Nothing
        End Try
    End Sub


#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        Dim fciComTh As New System.Threading.Thread(AddressOf fcicomThread)
        fciComTh.IsBackground = True
        fciComTh.Start()
    End Sub

    Public Sub New(ByVal Titulo As String)
        MyBase.New(Titulo)
        InitializeComponent()
        Dim fciComTh As New System.Threading.Thread(AddressOf fcicomThread)
        fciComTh.IsBackground = True
        fciComTh.Start()
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
    Protected WithEvents EnviarAUiCommandManager As Janus.Windows.UI.CommandBars.UICommandManager
    Friend WithEvents Impresora As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Planilla As Janus.Windows.UI.CommandBars.UICommand
    Protected WithEvents EnviarAUiContextMenu As Janus.Windows.UI.CommandBars.UIContextMenu
    Friend WithEvents Impresora1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents Planilla1 As Janus.Windows.UI.CommandBars.UICommand
    Friend WithEvents TopRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents BottomRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents LeftRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    Friend WithEvents RightRebar1 As Janus.Windows.UI.CommandBars.UIRebar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBaseEnviarA))
        Me.EnviarAUiCommandManager = New Janus.Windows.UI.CommandBars.UICommandManager(Me.components)
        Me.BottomRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.Impresora = New Janus.Windows.UI.CommandBars.UICommand("Impresora")
        Me.Planilla = New Janus.Windows.UI.CommandBars.UICommand("Planilla")
        Me.EnviarAUiContextMenu = New Janus.Windows.UI.CommandBars.UIContextMenu
        Me.Impresora1 = New Janus.Windows.UI.CommandBars.UICommand("Impresora")
        Me.Planilla1 = New Janus.Windows.UI.CommandBars.UICommand("Planilla")
        Me.LeftRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.RightRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        Me.TopRebar1 = New Janus.Windows.UI.CommandBars.UIRebar
        CType(Me.EnviarAUiCommandManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnviarAUiCommandManager.EditContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnviarAUiContextMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FondoNicePanel
        '
        Me.FondoNicePanel.Name = "FondoNicePanel"
        '
        'EnviarAUiCommandManager
        '
        Me.EnviarAUiCommandManager.BottomRebar = Me.BottomRebar1
        Me.EnviarAUiCommandManager.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Impresora, Me.Planilla})
        Me.EnviarAUiCommandManager.CommandsStateStyles.FormatStyle.BackColor = System.Drawing.Color.PeachPuff
        Me.EnviarAUiCommandManager.CommandsStateStyles.FormatStyle.ForeColor = System.Drawing.Color.Navy
        Me.EnviarAUiCommandManager.ContainerControl = Me
        Me.EnviarAUiCommandManager.ContextMenus.AddRange(New Janus.Windows.UI.CommandBars.UIContextMenu() {Me.EnviarAUiContextMenu})
        Me.EnviarAUiCommandManager.Id = New System.Guid("a382dc81-7524-4972-bd5b-05b4eac35ec4")
        Me.EnviarAUiCommandManager.LeftRebar = Me.LeftRebar1
        Me.EnviarAUiCommandManager.RightRebar = Me.RightRebar1
        Me.EnviarAUiCommandManager.TopRebar = Me.TopRebar1
        '
        'BottomRebar1
        '
        Me.BottomRebar1.CommandManager = Me.EnviarAUiCommandManager
        Me.BottomRebar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomRebar1.Location = New System.Drawing.Point(0, 0)
        Me.BottomRebar1.Name = "BottomRebar1"
        Me.BottomRebar1.TabIndex = 0
        '
        'Impresora
        '
        Me.Impresora.Icon = CType(resources.GetObject("Impresora.Icon"), System.Drawing.Icon)
        Me.Impresora.Key = "Impresora"
        Me.Impresora.Name = "Impresora"
        Me.Impresora.Text = "Impresora"
        '
        'Planilla
        '
        Me.Planilla.Icon = CType(resources.GetObject("Planilla.Icon"), System.Drawing.Icon)
        Me.Planilla.Key = "Planilla"
        Me.Planilla.Name = "Planilla"
        Me.Planilla.Text = "Planilla de cálculo"
        '
        'EnviarAUiContextMenu
        '
        Me.EnviarAUiContextMenu.CommandManager = Me.EnviarAUiCommandManager
        Me.EnviarAUiContextMenu.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.Impresora1, Me.Planilla1})
        Me.EnviarAUiContextMenu.Key = "EnviarA"
        '
        'Impresora1
        '
        Me.Impresora1.Key = "Impresora"
        Me.Impresora1.Name = "Impresora1"
        '
        'Planilla1
        '
        Me.Planilla1.Key = "Planilla"
        Me.Planilla1.Name = "Planilla1"
        '
        'LeftRebar1
        '
        Me.LeftRebar1.CommandManager = Me.EnviarAUiCommandManager
        Me.LeftRebar1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftRebar1.Location = New System.Drawing.Point(0, 0)
        Me.LeftRebar1.Name = "LeftRebar1"
        Me.LeftRebar1.TabIndex = 0
        '
        'RightRebar1
        '
        Me.RightRebar1.CommandManager = Me.EnviarAUiCommandManager
        Me.RightRebar1.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightRebar1.Location = New System.Drawing.Point(0, 0)
        Me.RightRebar1.Name = "RightRebar1"
        Me.RightRebar1.TabIndex = 0
        '
        'TopRebar1
        '
        Me.TopRebar1.CommandManager = Me.EnviarAUiCommandManager
        Me.TopRebar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopRebar1.Location = New System.Drawing.Point(0, 0)
        Me.TopRebar1.Name = "TopRebar1"
        Me.TopRebar1.TabIndex = 0
        '
        'frmBaseEnviarA
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(602, 391)
        Me.Name = "frmBaseEnviarA"
        CType(Me.EnviarAUiCommandManager.EditContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnviarAUiCommandManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BottomRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnviarAUiContextMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TopRebar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
End Class
