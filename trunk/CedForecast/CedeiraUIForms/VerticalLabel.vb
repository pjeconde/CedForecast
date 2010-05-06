Imports System
Imports System.ComponentModel
Imports System.Drawing

Namespace CustomControls
	''' <summary>
	''' A custom windows control to display text vertically
	''' </summary>
	<ToolboxBitmap(GetType(VerticalLabel), "VerticalLabel.ico")> _
	Public Class VerticalLabel
		Inherits System.Windows.Forms.Control
		Private labelText As String
		Private _dm As DrawMode = DrawMode.BottomUp

		Private components As New System.ComponentModel.Container()

		''' <summary>
		''' VerticalLabel constructor
		''' </summary>
		Public Sub New()
			MyBase.CreateControl()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Dispose override method
		''' </summary>
		''' <param name="disposing">boolean parameter</param>
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not ((components Is Nothing)) Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		<System.Diagnostics.DebuggerStepThrough()> _
		Private Sub InitializeComponent()
			Me.Size = New System.Drawing.Size(24, 100)
		End Sub

		''' <summary>
		''' OnPaint override. This is where the text is rendered vertically.
		''' </summary>
		''' <param name="e">PaintEventArgs</param>
		Protected Overloads Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
			Dim vlblControlWidth As Single
			Dim vlblControlHeight As Single
			Dim vlblTransformX As Single
			Dim vlblTransformY As Single
			Dim controlBackColor As Color = BackColor
			Dim labelBorderPen As New Pen(controlBackColor, 0)
			Dim labelBackColorBrush As New SolidBrush(controlBackColor)
			Dim labelForeColorBrush As New SolidBrush(MyBase.ForeColor)
			MyBase.OnPaint(e)
			vlblControlWidth = Me.Size.Width
			vlblControlHeight = Me.Size.Height
			e.Graphics.DrawRectangle(labelBorderPen, 0, 0, vlblControlWidth, vlblControlHeight)
			e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, vlblControlWidth, vlblControlHeight)


			If Me.TextDrawMode = DrawMode.BottomUp Then
				vlblTransformX = 0
				vlblTransformY = vlblControlHeight
				e.Graphics.TranslateTransform(vlblTransformX, vlblTransformY)
				e.Graphics.RotateTransform(270)
				e.Graphics.DrawString(labelText, Font, labelForeColorBrush, 0, 0)
			Else
				vlblTransformX = vlblControlWidth
				vlblTransformY = vlblControlHeight
				e.Graphics.TranslateTransform(vlblControlWidth, 0)
				e.Graphics.RotateTransform(90)
				e.Graphics.DrawString(labelText, Font, labelForeColorBrush, 0, 0, StringFormat.GenericTypographic)
			End If
		End Sub

		Private Sub VerticalTextBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
			Invalidate()
		End Sub

		''' <summary>
		''' The text to be displayed in the control
		''' </summary>
		<Category("VerticalLabel"), Description("Text is displayed vertically in container.")> _
		Public Overloads Overrides Property Text() As String
			Get
				Return labelText
			End Get
			Set
				labelText = value
				Invalidate()
			End Set
		End Property
		''' <summary>
		''' 
		''' </summary>
		<Category("Properties"), Description("Whether the text will be drawn from Bottom or from Top.")> _
		Public Property TextDrawMode() As DrawMode
			Get
				Return _dm
			End Get
			Set
				_dm = value
			End Set
		End Property
	End Class
	''' <summary>
	''' Text Drawing Mode
	''' </summary>
	Public Enum DrawMode
		''' <summary>
		''' Text is drawn from bottom - up
		''' </summary>
		BottomUp = 1
		''' <summary>
		''' Text is drawn from top to bottom
		''' </summary>
		TopBottom
	End Enum
End Namespace
