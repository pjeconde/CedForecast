Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class CADataGridTextBoxColum
    Inherits DataGridTextBoxColumn
    Private SelectedRow As Integer
    'Fields
    'Constructors
    'Events
    'Methods
    Public Sub New()
        'Warning: Implementation not found
    End Sub
    Protected Overloads Overrides Sub Edit(ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal bounds As Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
        'make sure selectedrow is valid
        If (SelectedRow > -1) And (SelectedRow < source.List.Count + 1) Then
            Me.DataGridTableStyle.DataGrid.UnSelect(SelectedRow)
        End If
        SelectedRow = rowNum
        Me.DataGridTableStyle.DataGrid.Select(SelectedRow)

    End Sub
End Class
Public Class CADataGridBoolCol
    Inherits DataGridBoolColumn
    Private SelectedRow As Integer
    Protected Overloads Overrides Sub Edit(ByVal source As System.Windows.Forms.CurrencyManager, ByVal rowNum As Integer, ByVal bounds As System.Drawing.Rectangle, ByVal [readOnly] As Boolean, ByVal instantText As String, ByVal cellIsVisible As Boolean)
        If (SelectedRow > -1) And (SelectedRow < source.List.Count + 1) Then
            Me.DataGridTableStyle.DataGrid.UnSelect(SelectedRow)
        End If
        SelectedRow = rowNum
        Me.DataGridTableStyle.DataGrid.Select(SelectedRow)
    End Sub

End Class
