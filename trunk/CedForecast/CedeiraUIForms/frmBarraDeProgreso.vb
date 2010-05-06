Public Class frmBarraDeProgreso
    Inherits UI.frmBase

public sub valorProgreso(byval act as Int32)
        BarraUIProgressBar.Value = act
        BarraUIProgressBar.Text = Str(act)
    End Sub

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub
    Public Sub New(ByVal Titulo As String)
        MyBase.New(Titulo)
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
    Friend WithEvents BarraUIProgressBar As Janus.Windows.EditControls.UIProgressBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.BarraUIProgressBar = New Janus.Windows.EditControls.UIProgressBar
        Me.FondoNicePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'FondoNicePanel
        '
        Me.FondoNicePanel.Controls.Add(Me.BarraUIProgressBar)
        Me.FondoNicePanel.Name = "FondoNicePanel"
        Me.FondoNicePanel.Size = New System.Drawing.Size(280, 60)
        '
        'BarraUIProgressBar
        '
        Me.BarraUIProgressBar.BackgroundFormatStyle.BackColor = System.Drawing.Color.Transparent
        Me.BarraUIProgressBar.BackgroundFormatStyle.BackColorGradient = System.Drawing.Color.Transparent
        Me.BarraUIProgressBar.FlatBorderColor = System.Drawing.Color.Transparent
        Me.BarraUIProgressBar.Location = New System.Drawing.Point(8, 32)
        Me.BarraUIProgressBar.Name = "BarraUIProgressBar"
        Me.BarraUIProgressBar.ProgressFormatStyle.BackColor = System.Drawing.Color.Cornsilk
        Me.BarraUIProgressBar.ProgressFormatStyle.ForeColor = System.Drawing.Color.Brown
        Me.BarraUIProgressBar.ShowPercentage = True
        Me.BarraUIProgressBar.Size = New System.Drawing.Size(264, 20)
        Me.BarraUIProgressBar.TabIndex = 127
        Me.BarraUIProgressBar.UseThemes = False
        '
        'frmBarraDeProgreso
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(280, 60)
        Me.Name = "frmBarraDeProgreso"
        Me.ShowInTaskbar = False
        Me.FondoNicePanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
