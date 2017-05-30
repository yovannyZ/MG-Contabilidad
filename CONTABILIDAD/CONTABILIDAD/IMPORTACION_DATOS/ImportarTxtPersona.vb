Imports System.Data.SqlClient
Public Class ImportarTxtPersona
    Dim ruta, arch As String
    Private trans As SqlTransaction
    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        main(111) = (0)
        Close()
    End Sub

    Function SGT_CODIGO() As String
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_PERSONA", con, trans)
            'con.Open()
            SGT = CMD.ExecuteScalar.ToString
            'con.Close()
        Catch ex As Exception
            'con.Close()
            MsgBox(ex.Message)
        End Try
        If SGT = "" Then
            SGT_CODIGO = "00001"
        Else
            SGT_CODIGO = SGT
        End If
    End Function

    Private Sub Btn_Abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Abrir.Click
        If Len(ruta) = 0 Then
            ruta = "D:\"
        End If
        If Len(arch) = 0 Then
            arch = ""
        End If
        DialogOpen.InitialDirectory = ruta
        DialogOpen.FileName = arch
        DialogOpen.Filter = "Archivo de texto (*.txt)|*.txt"
        DialogOpen.FilterIndex = 2
        DialogOpen.RestoreDirectory = False
        If DialogOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_Datos.Text = DialogOpen.FileName
            ruta = IO.Path.GetDirectoryName(DialogOpen.FileName)
            arch = IO.Path.GetFileName(DialogOpen.FileName)
        End If
    End Sub

    Private Sub txt_Datos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Datos.TextChanged
        If Len(txt_Datos.Text) > 0 And txt_Datos.Text <> "" Then
            GroupBox3.Enabled = True
            Btn_Cargar.Enabled = True
        Else
            GroupBox3.Enabled = False
            Btn_Cargar.Enabled = False
        End If
    End Sub

    Private Sub Btn_Cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cargar.Click
        Dim lista As New List(Of String)
        Dim fila As DataRow
        Dim tabla As New DataTable
        Dim Limite As String = ""
        If Rb_1.Checked = True Then
            Limite = ";"
        ElseIf Rb_2.Checked = True Then
            Limite = "|"
        End If
        '---------------------------------------------------------------
        'obtengo los datos del fichero.
        '---------------------------------------------------------------
        Try
            Me.Cursor = Cursors.WaitCursor
            DG.DataSource = Nothing
            DGPersona.Rows.Clear()
            DGPersonaDet.Rows.Clear()
            Dim fic As New IO.StreamReader(txt_Datos.Text)
            Dim linea As String = Nothing

            linea = fic.ReadLine()
            While (linea <> Nothing)
                lista.Add(linea)
                linea = fic.ReadLine()
            End While
            '---------------------------------------------------------------
            ' Añado las columnas a la tabla antes
            For col As Integer = 0 To lista(0).Split(New Char(), Limite).Length - 1
                tabla.Columns.Add(col.ToString())
            Next
            '---------------------------------------------------------------
            'Creo el array para meter los campos.
            Dim Datos() As String
            For i As Integer = 0 To lista.Count - 1
                Datos = lista(i).Split(New Char(), Limite)
                fila = tabla.NewRow()
                For j As Integer = 0 To Datos.Length - 1
                    fila(j) = Datos(j)
                Next
                tabla.Rows.Add(fila)
            Next
            fic.Close()
            '---------------------------------------------------------------
            ' La asigno a mi tabla.
            Me.DG.DataSource = tabla
            Me.Cursor = Cursors.Default
            '---------------------------------------------------------------
            Dim f As Integer = -1
            Dim x As Integer, reg As Integer
            Dim existe As Boolean
            reg = 0
            For x = 0 To tabla.Rows.Count - 1
                existe = False
                For i As Integer = 0 To tabla.Rows.Count - 1
                    If x = 0 And i = 0 Then
                        existe = False
                        Exit For
                    Else
                        If x <> i Then
                            If DG.Item(0, x).Value = tabla.Rows.Item(i).Item(0) And _
                            DG.Item(3, x).Value = tabla.Rows.Item(i).Item(3) Then
                                existe = True
                                Exit For
                            End If
                        End If
                    End If
                Next
                If existe = False Then
                    'tabla.Rows.Item(x)(10) = reg
                    DGPersona.Rows.Add()
                    DGPersona.Item(0, reg).Value = tabla.Rows.Item(x).Item(0)
                    DGPersona.Item(1, reg).Value = tabla.Rows.Item(x).Item(1)
                    DGPersona.Item(2, reg).Value = tabla.Rows.Item(x).Item(2)
                    DGPersona.Item(3, reg).Value = tabla.Rows.Item(x).Item(3)
                    DGPersona.Item(4, reg).Value = tabla.Rows.Item(x).Item(4)
                    DGPersona.Item(5, reg).Value = tabla.Rows.Item(x).Item(5)
                    DGPersona.Item(6, reg).Value = tabla.Rows.Item(x).Item(6)
                    DGPersona.Item(7, reg).Value = tabla.Rows.Item(x).Item(7)

                    reg = reg + 1
                End If
            Next
            reg = 0
            For x = 0 To tabla.Rows.Count - 1
                DGPersonaDet.Rows.Add()
                DGPersonaDet.Item(0, reg).Value = tabla.Rows.Item(x).Item(0)
                DGPersonaDet.Item(1, reg).Value = tabla.Rows.Item(x).Item(8)
                DGPersonaDet.Item(2, reg).Value = tabla.Rows.Item(x).Item(9)
                DGPersonaDet.Item(3, reg).Value = tabla.Rows.Item(x).Item(1)
                DGPersonaDet.Item(4, reg).Value = tabla.Rows.Item(x).Item(2)
                DGPersonaDet.Item(5, reg).Value = tabla.Rows.Item(x).Item(3)
                reg = reg + 1
            Next
        Catch ex As Exception
            MsgBox("Error al leer el archivo" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        Dim cod As String
        Dim x As Integer, y As Integer, auxcod As Integer
        If DGPersona.Rows.Count < 1 Then
            MsgBox("No hay items a grabar", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Try
            con.Open()
            trans = con.BeginTransaction
            auxcod = 0
            For x = 0 To DGPersona.Rows.Count - 1
                If DGPersona.Item(0, x).Value = "" Then
                    cod = SGT_CODIGO() '+ auxcod
                    For y = 0 To DGPersonaDet.Rows.Count - 1
                        If DGPersonaDet.Item(0, y).Value = DGPersona.Item(0, x).Value And _
                        DGPersonaDet.Item(5, y).Value = DGPersona.Item(3, x).Value Then
                            DGPersonaDet.Item(0, y).Value = cod
                        End If
                    Next
                    DGPersona.Item(0, x).Value = cod
                    'auxcod = auxcod + 1
                End If
                Dim CMD As New SqlCommand("[INSERTAR_PERSONA]", con, trans)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = DGPersona.Item(0, x).Value
                CMD.Parameters.Add("@TIPO_PER", SqlDbType.Char).Value = DGPersona.Item(1, x).Value
                CMD.Parameters.Add("@DESC_PER", SqlDbType.VarChar).Value = DGPersona.Item(4, x).Value
                CMD.Parameters.Add("@NOM", SqlDbType.VarChar).Value = DGPersona.Item(5, x).Value
                CMD.Parameters.Add("@PAT", SqlDbType.VarChar).Value = DGPersona.Item(6, x).Value
                CMD.Parameters.Add("@MAT", SqlDbType.VarChar).Value = DGPersona.Item(7, x).Value
                CMD.Parameters.Add("@NOM_COMERCIAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@COD_TIPO_DOC", SqlDbType.Char).Value = DGPersona.Item(2, x).Value
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = DGPersona.Item(3, x).Value
                CMD.Parameters.Add("@NOM_AVAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@NRO_DOC_AVAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@DIR_AVAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@FONO_AVAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@ST_CONTRIBUYENTE", SqlDbType.Char).Value = System.DBNull.Value
                CMD.Parameters.Add("@ST_RETENEDOR", SqlDbType.Char).Value = System.DBNull.Value
                CMD.ExecuteNonQuery()
            Next
            For x = 0 To DGPersonaDet.Rows.Count - 1
                Dim CMD As New SqlCommand("INSERTAR_CLASES", con, trans)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = DGPersonaDet.Item(0, x).Value
                CMD.Parameters.Add("@COD_CLASE", SqlDbType.Char).Value = DGPersonaDet.Item(1, x).Value
                CMD.Parameters.Add("@COD_CAT", SqlDbType.Char).Value = DGPersonaDet.Item(2, x).Value
                CMD.Parameters.Add("@linea", SqlDbType.Decimal).Value = 0
                CMD.ExecuteNonQuery()
            Next
            MsgBox("Datos grabados correctamente", MsgBoxStyle.Information)
            trans.Commit()
        Catch ex As Exception
            MsgBox("Error al grabar" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            trans.Rollback()
        Finally
            con.Close()
        End Try
    End Sub

  
    Private Sub ImportarTxtPersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGPersona.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        DGPersonaDet.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
    End Sub
End Class