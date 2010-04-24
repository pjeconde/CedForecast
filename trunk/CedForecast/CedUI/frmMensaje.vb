Friend Class frmMensaje
    Inherits System.Windows.Forms.Form
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Const EM_GETLINECOUNT As Integer = &HBA

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New(ByVal Mensaje As String, ByVal Icono As Microsoft.VisualBasic.MsgBoxStyle, ByVal Titulo As String, ByVal MasDetalles As String)
        MyBase.New()

        InitializeComponent()
        Text = Titulo
        txtMensaje.Text = Mensaje
        txtMensaje.SelectionLength = 0
        pnlMensaje.Size = New System.Drawing.Size(pnlMensaje.Size.Width, Math.Max(CInt(SendMessage(txtMensaje.Handle, EM_GETLINECOUNT, 0, 0)), CInt(3)) * CSng(txtMensaje.CreateGraphics().MeasureString("M", txtMensaje.Font).Height))
        txtMasDetalles.Text = MasDetalles
        txtMasDetalles.SelectionLength = 0
        pnlMasDetalles.Size = New System.Drawing.Size(pnlMasDetalles.Size.Width, CInt(SendMessage(txtMasDetalles.Handle, EM_GETLINECOUNT, 0, 0) * CSng(txtMasDetalles.CreateGraphics().MeasureString("M", txtMasDetalles.Font).Height)))
        Me.Size = New System.Drawing.Size(Me.Size.Width, pnlMensaje.Size.Height + SplitterMensaje.Size.Height + 35 + 24 + 20)
        Select Case Icono
            Case MsgBoxStyle.Critical
                PictureBox.Image = SystemIcons.Error.ToBitmap
            Case MsgBoxStyle.Exclamation
                PictureBox.Image = SystemIcons.Exclamation.ToBitmap
            Case MsgBoxStyle.Information
                PictureBox.Image = SystemIcons.Information.ToBitmap
            Case MsgBoxStyle.Question
                PictureBox.Image = SystemIcons.Question.ToBitmap
        End Select
        btnAceptar.Select()
        If MasDetalles = "" Then
            btnMasDetalles.Visible = False
        End If
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
    Friend WithEvents pnlMensaje As System.Windows.Forms.Panel
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pnlMasDetalles As System.Windows.Forms.Panel
    Friend WithEvents txtMasDetalles As System.Windows.Forms.TextBox
    Friend WithEvents btnMasDetalles As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents SplitterMensaje As System.Windows.Forms.Splitter
    Friend WithEvents SplitterMasDetalles As System.Windows.Forms.Splitter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMensaje))
        Me.pnlMensaje = New System.Windows.Forms.Panel
        Me.txtMensaje = New System.Windows.Forms.TextBox
        Me.Splitter3 = New System.Windows.Forms.Splitter
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.pnlMasDetalles = New System.Windows.Forms.Panel
        Me.txtMasDetalles = New System.Windows.Forms.TextBox
        Me.SplitterMensaje = New System.Windows.Forms.Splitter
        Me.SplitterMasDetalles = New System.Windows.Forms.Splitter
        Me.pnlBotones = New System.Windows.Forms.Panel
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnMasDetalles = New System.Windows.Forms.Button
        Me.pnlMensaje.SuspendLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMasDetalles.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMensaje
        '
        Me.pnlMensaje.Controls.Add(Me.txtMensaje)
        Me.pnlMensaje.Controls.Add(Me.Splitter3)
        Me.pnlMensaje.Controls.Add(Me.PictureBox)
        Me.pnlMensaje.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMensaje.Location = New System.Drawing.Point(5, 5)
        Me.pnlMensaje.Name = "pnlMensaje"
        Me.pnlMensaje.Size = New System.Drawing.Size(478, 72)
        Me.pnlMensaje.TabIndex = 5
        '
        'txtMensaje
        '
        Me.txtMensaje.BackColor = System.Drawing.SystemColors.Control
        Me.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMensaje.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMensaje.Location = New System.Drawing.Point(42, 0)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ReadOnly = True
        Me.txtMensaje.Size = New System.Drawing.Size(436, 72)
        Me.txtMensaje.TabIndex = 2
        '
        'Splitter3
        '
        Me.Splitter3.Enabled = False
        Me.Splitter3.Location = New System.Drawing.Point(32, 0)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(10, 72)
        Me.Splitter3.TabIndex = 6
        Me.Splitter3.TabStop = False
        '
        'PictureBox
        '
        Me.PictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(32, 72)
        Me.PictureBox.TabIndex = 5
        Me.PictureBox.TabStop = False
        '
        'pnlMasDetalles
        '
        Me.pnlMasDetalles.Controls.Add(Me.txtMasDetalles)
        Me.pnlMasDetalles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMasDetalles.Location = New System.Drawing.Point(5, 180)
        Me.pnlMasDetalles.Name = "pnlMasDetalles"
        Me.pnlMasDetalles.Size = New System.Drawing.Size(478, 88)
        Me.pnlMasDetalles.TabIndex = 6
        Me.pnlMasDetalles.Visible = False
        '
        'txtMasDetalles
        '
        Me.txtMasDetalles.BackColor = System.Drawing.SystemColors.Control
        Me.txtMasDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMasDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMasDetalles.Location = New System.Drawing.Point(0, 0)
        Me.txtMasDetalles.Multiline = True
        Me.txtMasDetalles.Name = "txtMasDetalles"
        Me.txtMasDetalles.ReadOnly = True
        Me.txtMasDetalles.Size = New System.Drawing.Size(478, 88)
        Me.txtMasDetalles.TabIndex = 3
        '
        'SplitterMensaje
        '
        Me.SplitterMensaje.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitterMensaje.Enabled = False
        Me.SplitterMensaje.Location = New System.Drawing.Point(5, 77)
        Me.SplitterMensaje.Name = "SplitterMensaje"
        Me.SplitterMensaje.Size = New System.Drawing.Size(478, 10)
        Me.SplitterMensaje.TabIndex = 7
        Me.SplitterMensaje.TabStop = False
        '
        'SplitterMasDetalles
        '
        Me.SplitterMasDetalles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitterMasDetalles.Enabled = False
        Me.SplitterMasDetalles.Location = New System.Drawing.Point(5, 170)
        Me.SplitterMasDetalles.Name = "SplitterMasDetalles"
        Me.SplitterMasDetalles.Size = New System.Drawing.Size(478, 10)
        Me.SplitterMasDetalles.TabIndex = 8
        Me.SplitterMasDetalles.TabStop = False
        Me.SplitterMasDetalles.Visible = False
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Controls.Add(Me.btnMasDetalles)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBotones.Location = New System.Drawing.Point(5, 87)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(478, 83)
        Me.pnlBotones.TabIndex = 9
        '
        'btnAceptar
        '
        Me.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Location = New System.Drawing.Point(398, 0)
        Me.btnAceptar.MinimumSize = New System.Drawing.Size(0, 23)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 83)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnMasDetalles
        '
        Me.btnMasDetalles.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnMasDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMasDetalles.Location = New System.Drawing.Point(0, 0)
        Me.btnMasDetalles.MinimumSize = New System.Drawing.Size(0, 23)
        Me.btnMasDetalles.Name = "btnMasDetalles"
        Me.btnMasDetalles.Size = New System.Drawing.Size(128, 83)
        Me.btnMasDetalles.TabIndex = 1
        Me.btnMasDetalles.Text = "Ver detalles"
        '
        'frmMensaje
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 273)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlBotones)
        Me.Controls.Add(Me.SplitterMasDetalles)
        Me.Controls.Add(Me.SplitterMensaje)
        Me.Controls.Add(Me.pnlMasDetalles)
        Me.Controls.Add(Me.pnlMensaje)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMensaje"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mensaje"
        Me.pnlMensaje.ResumeLayout(False)
        Me.pnlMensaje.PerformLayout()
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMasDetalles.ResumeLayout(False)
        Me.pnlMasDetalles.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        DialogResult = DialogResult.OK
    End Sub

    Private Sub btnMasDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasDetalles.Click
        Select Case btnMasDetalles.Text
            Case "Ver detalles"
                btnMasDetalles.Text = "No ver detalles"
                SplitterMasDetalles.Visible = True
                pnlMasDetalles.Visible = True
                Me.Size = New System.Drawing.Size(Me.Size.Width, pnlMensaje.Size.Height + SplitterMensaje.Size.Height + 35 + 24 + 20 + SplitterMasDetalles.Size.Height + pnlMasDetalles.Size.Height)
                If Me.Size.Height > 500 Then
                    Me.Size = New System.Drawing.Size(Me.Size.Width, 500)
                    pnlMasDetalles.Size = New System.Drawing.Size(pnlMasDetalles.Size.Width, 500 - pnlMensaje.Size.Height - SplitterMensaje.Size.Height - 35 - 24 - 20 - 10)
                    txtMasDetalles.ScrollBars = ScrollBars.Vertical
                End If
            Case "No ver detalles"
                btnMasDetalles.Text = "Ver detalles"
                SplitterMasDetalles.Visible = False
                pnlMasDetalles.Visible = False
                Me.Size = New System.Drawing.Size(Me.Size.Width, pnlMensaje.Size.Height + SplitterMensaje.Size.Height + 35 + 24 + 20)
        End Select
    End Sub
End Class
