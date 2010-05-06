Imports System.Drawing
Imports System.Windows.Forms

Public Class Bindear

    Public Shared Sub dv2Grid(ByVal dg As DataGrid, ByVal dv As DataView)
        Dim i, j As Integer
        Dim gr As Graphics
        Dim sngPadding As Single
        Dim dr As DataRow
        Dim ts As DataGridTableStyle
        Dim cs As DataGridColumnStyle
        ts = New DataGridTableStyle
        ts.MappingName = dv.Table.TableName
        dg.DataSource = dv.Table
        dg.BeginInit()
        For i = 0 To dv.Table.Columns.Count - 1
            If dv.Table.Columns(i).DataType.FullName = "System.Boolean" Then
                cs = New Cedeira.UI.CADataGridBoolCol
            Else
                cs = New Cedeira.UI.CADataGridTextBoxColum
            End If
            cs.MappingName = dv.Table.Columns(i).ColumnName
            cs.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            cs.HeaderText = dv.Table.Columns(i).ToString
            If dv.Table.Rows.Count > 0 Then       ' Don't change size if there are no rows.
                Try
                    'dr = dv.Table.Rows(0)
                    Dim sz As SizeF 'Stores an ordered pair of floating-point numbers, typically the width and height of a rectangle.
                    gr = dg.CreateGraphics
                    sz = gr.MeasureString(New String(CChar("M"), 1), dg.Font)   ' Pad "n" M-width characters
                    sngPadding = sz.Width
                    'For Each dcCol In dv.Table.Columns                 ' Loop through the column header
                    ' Measure the "width" of the text in each grid column header
                    sz = gr.MeasureString(cs.HeaderText, dg.Font)
                    cs.Width = CInt(sz.Width + sngPadding)
                    'Next      ' dcCol loop through each column in the bound DataTable
                    Dim jTope As Integer = Math.Min(dg.VisibleRowCount - 1, dv.Table.Rows.Count - 1)
                    For j = 0 To jTope              ' Calculate width on all visible rows (header row counted)
                        dr = dv.Table.Rows(j)       ' Navigate to visible rows
                        ' Measure the "width" of the txt in the first row of each bound DataTable column
                        sz = gr.MeasureString(dr.Item(i).ToString, dg.Font)         ' Measure "width" of data value
                        cs.Width = CInt(Math.Max(sz.Width + sngPadding, cs.Width))                                  ' Use larger width
                    Next j           ' Next DataRow
                    gr.Dispose() ' Release graphic object
                Catch ex As Exception
                    Cedeira.UI.Mostrar.Excepcion(ex)
                End Try
            End If
            ts.GridColumnStyles.Add(cs)
        Next i
        dg.EndInit()   ' complete graphics edit
        ts.RowHeadersVisible = False
        dg.TableStyles.Clear()
        dg.TableStyles.Add(ts)
        dg.ReadOnly = True
    End Sub
    Public Shared Sub dv2ComboBind(ByVal cbo As ComboBox, ByVal dv As DataView, ByVal obj As Object, ByVal atrib As String)
        cbo.DataSource = dv
        cbo.DisplayMember = "Descr"
        cbo.ValueMember = "Id"
        cbo.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", obj, atrib))
        'If dv.Table.Rows.Count = 1 Then
        '    cbo.SelectedValue = dv.Table.Rows(0)(cbo.ValueMember)
        'End If
    End Sub
    Public Shared Sub dv2Combo(ByVal cbo As ComboBox, ByVal dv As DataView)
        cbo.DataSource = dv
        cbo.DisplayMember = "Descr"
        cbo.ValueMember = "Id"
        'If dv.Table.Rows.Count = 1 Then
        '    cbo.SelectedValue = dv.Table.Rows(0)(cbo.ValueMember)
        'End If
    End Sub
    Public Shared Sub dv2Combo(ByVal cbo As ComboBox, ByVal dv As DataView, ByVal ValueMember As String, ByVal DisplayMember As String)
        cbo.DataSource = dv
        cbo.DisplayMember = DisplayMember
        cbo.ValueMember = ValueMember
        'If dv.Table.Rows.Count = 1 Then
        '    cbo.SelectedValue = dv.Table.Rows(0)(cbo.ValueMember)
        'End If
    End Sub
    Public Shared Sub tb2Combo(ByVal cbo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, ByVal tb As DataTable)
        cbo.DropDownList.AlternatingColors = True
        cbo.DropDownList.ColumnAutoResize = True
        cbo.DropDownList.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False
        cbo.DropDownList.Columns.Clear()
        cbo.DropDownList.Columns.Add("Id", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.DropDownList)
        cbo.DropDownList.Columns(0).Visible = False
        cbo.DropDownList.Columns.Add("Descr", Janus.Windows.GridEX.ColumnType.Text, Janus.Windows.GridEX.EditType.DropDownList)
        cbo.DataSource = tb
        cbo.DisplayMember = "Descr"
        cbo.ValueMember = "Id"
    End Sub
    Public Shared Sub dv2ListBind(ByVal lbo As ListBox, ByVal dv As DataView, ByVal obj As Object, ByVal atrib As String)
        lbo.DataSource = dv
        lbo.DisplayMember = "Descr"
        lbo.ValueMember = "Id"
        lbo.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", obj, atrib))
        'If dv.Table.Rows.Count = 1 Then
        '    lbo.SelectedValue = dv.Table.Rows(0)(lbo.ValueMember)
        'End If
    End Sub
    Public Shared Sub dv2List(ByVal lbo As ListBox, ByVal dv As DataView)
        lbo.DataSource = dv
        lbo.DisplayMember = "Descr"
        lbo.ValueMember = "Id"
        'If dv.Table.Rows.Count = 1 Then
        '    lbo.SelectedValue = dv.Table.Rows(0)(lbo.ValueMember)
        'End If
    End Sub
    Public Shared Sub tb2List(ByVal lbo As ListBox, ByVal tb As DataTable)
        lbo.DataSource = tb
        lbo.DisplayMember = "Descr"
        lbo.ValueMember = "Id"
    End Sub
    Public Shared Sub dv2List(ByVal lbo As ListBox, ByVal dv As DataView, ByVal ValueMember As String, ByVal DisplayMember As String)
        lbo.DataSource = dv
        lbo.DisplayMember = DisplayMember
        lbo.ValueMember = ValueMember
        'If dv.Table.Rows.Count = 1 Then
        '    lbo.SelectedValue = dv.Table.Rows(0)(lbo.ValueMember)
        'End If
    End Sub
End Class
Public Class Mostrar
    Public Shared Function Mensaje(ByVal Texto As String, ByVal Icono As Microsoft.VisualBasic.MsgBoxStyle, ByVal Titulo As String, ByVal MasDetalles As String) As Microsoft.VisualBasic.MsgBoxResult
        Dim oFrm As frmMensaje
        If Titulo = "NOTIFICACION DE EXCEPCION" Then
            Titulo += " en "
            Titulo += Application.ProductName
        End If
        oFrm = New frmMensaje(Texto, Icono, Titulo, MasDetalles)
        Microsoft.VisualBasic.Interaction.Beep()
        oFrm.ShowDialog()
        oFrm.Dispose()
        oFrm = Nothing
        Return MsgBoxResult.OK
    End Function
    Public Shared Function Mensaje(ByVal Texto As String, ByVal Titulo As String) As Microsoft.VisualBasic.MsgBoxResult
        Return Mensaje(Texto, MsgBoxStyle.Information, Titulo, "")
    End Function
    Public Shared Function Mensaje(ByVal Texto As String) As Microsoft.VisualBasic.MsgBoxResult
        Return Mensaje(Texto, MsgBoxStyle.Information, "ATENCIÓN", "")
    End Function
    Public Shared Function Excepcion(ByVal ex As Exception) As Microsoft.VisualBasic.MsgBoxResult
        Return Mensaje(ex.Message, MsgBoxStyle.Critical, "NOTIFICACION DE EXCEPCION", ex.StackTrace)
    End Function
    Public Shared Sub Acerca(ByVal Sistema As String, ByVal CodigoSistema As String, ByVal Version As String, ByVal Segundos As Integer)
        Dim oFrm As frmAcerca
        oFrm = New frmAcerca(Sistema, CodigoSistema, Version, Segundos)
        oFrm.ShowDialog()
        oFrm.Dispose()
        oFrm = Nothing
    End Sub
End Class
Public Class Fun
    Public Shared Sub ChequeoNodosTreeView(ByVal tvw As TreeView, ByVal Valor As Boolean)
        Dim i As Integer
        For i = 0 To tvw.Nodes.Count - 1
            tvw.Nodes(i).Checked = Valor
        Next i
    End Sub
    Public Shared Function ListaTreeView(ByVal tvw As TreeView) As String
        Dim lista As String
        Dim i As Integer
        lista = String.Empty
        For i = 0 To tvw.Nodes.Count - 1
            If tvw.Nodes(i).Checked Then
                lista = lista & "'" & Convert.ToString(tvw.Nodes(i).Tag) & "', "
            End If
        Next i
        If lista <> "" Then
            lista = Left(lista, Len(lista) - 2)
        End If
        Return lista
    End Function
End Class
