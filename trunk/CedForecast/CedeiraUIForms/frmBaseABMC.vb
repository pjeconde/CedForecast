Public Class frmBaseABMC
    Inherits frmBase

    Public Enum ABMC
        Alta
        Baja
        Consultar
        Modificar
    End Enum

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal ABMC As ABMC)
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        Select Case ABMC
            Case ABMC.Alta
                btnAceptar.Text = "Agregar"
            Case ABMC.Baja
                btnAceptar.Text = "Eliminar"
            Case ABMC.Modificar
                btnAceptar.Text = "Modificar"
            Case ABMC.Consultar
                btnAceptar.Visible = False
                btnCancelar.Text = "Salir"
        End Select
    End Sub

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
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
    Protected WithEvents btnAceptar As System.Windows.Forms.Button
    Protected WithEvents pnlInferior As System.Windows.Forms.Panel
    Protected WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        components = New System.ComponentModel.Container

        Me.pnlInferior = New System.Windows.Forms.Panel
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.pnlInferior.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlInferior
        '
        Me.pnlInferior.BackColor = System.Drawing.SystemColors.Control
        Me.pnlInferior.Controls.Add(Me.btnCancelar)
        Me.pnlInferior.Controls.Add(Me.btnAceptar)
        Me.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlInferior.Location = New System.Drawing.Point(5, 404)
        Me.pnlInferior.Name = "pnlInferior"
        Me.pnlInferior.Size = New System.Drawing.Size(568, 30)
        Me.pnlInferior.TabIndex = 4
        '
        'btnCancelar
        '
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Location = New System.Drawing.Point(468, 0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 30)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Location = New System.Drawing.Point(0, 0)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 30)
        Me.btnAceptar.TabIndex = 2
        '
        'frmBaseABMC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(578, 439)
        Me.Controls.Add(Me.pnlInferior)
        Me.DockPadding.All = 5
        Me.Name = "frmBaseABMC"
        Me.pnlInferior.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dispose()
    End Sub

End Class
