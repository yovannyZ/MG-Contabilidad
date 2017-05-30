Imports System.Data.SqlClient
Public Class REPORTE_CUADRE_TP
    Dim OBJ As New Class1

    Sub DGW_CUENTAS00()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTAS_STATUS_TIPO", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = "P"
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetString(0), dr.GetString(1), False)
                dgw2.Rows.Add(dr.GetString(0), dr.GetString(1), False)
            Loop
            con.Close()
            dgw1.Columns.Item(0).ReadOnly = True
            dgw1.Columns.Item(1).ReadOnly = True

            dgw2.Columns.Item(0).ReadOnly = True
            dgw2.Columns.Item(1).ReadOnly = True
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CARGAR_AÑOS()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "COI"
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                Me.cbo_año.Items.Add(Rs3.GetString(0))
                Me.cbo_año1.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub REPORTE_CUADRE_TP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        dgw2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        CARGAR_AÑOS()
        DGW_CUENTAS00()
        cbo_mes.Text = OBJ.DESC_MES(MES)
        cbo_año.Text = AÑO
        If TIPO_USU <> "MS" Then
            TabPage2.Parent = Nothing
        Else
            TabPage2.Parent = TabControl1
        End If
    End Sub

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        Dim i As Integer
        Dim _rep As String = ""
        Dim _title As String = ""
        Dim marca As Boolean = False
        Dim codCuenta As String = ""
        For i = 0 To dgw1.Rows.Count - 1
            If dgw1.Item(2, i).Value = True Then
                codCuenta += dgw1.Item(0, i).Value + ","
            End If
        Next
        If String.IsNullOrEmpty(codCuenta) Then
            MessageBox.Show("Seleccione al menos un registro para visualizar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        'For i = 0 To dgw1.Rows.Count - 1
        '    If dgw1.Item(2, i).Value = True Then
        '        _criterio += "'" + dgw1.Item(0, i).Value + "',"
        '    End If
        'Next
        codCuenta = Mid(codCuenta, 1, Len(codCuenta) - 1)
        If rb1.Checked = True Then
            _rep = "Reporte_Cuadre_TP.rpt"
            _title = "Reporte cuadre Analisis vs Cuentas por pagar"
        ElseIf rb2.Checked = True Then
            _rep = "Reporte_Cuadre_PPvsTP.rpt"
            _title = "Reporte cuadre Cuentas por pagar"
        ElseIf rb3.Checked = True Then
            _rep = "Reporte_Cuadre_PPvsTP_DOC.rpt"
            _title = "Reporte cuadre Cuentas por pagar(Existencia de Documentos)"
        End If
        CR.conectar(nombre_servidor, con.Database, "miguel", "main")
        CR.rutaRpt = Application.StartupPath & "\reportes"
        CR.custTitle = _title
        CR.printrpt(_rep, "@IN;" & codCuenta, "EMPRESA;" & DESC_EMPRESA, "RUC;" & RUC_EMPRESA, _
            "@FE_AÑO;" & cbo_año.Text, "@FE_MES;" & OBJ.COD_MES(cbo_mes.Text))
    End Sub

    Private Sub ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch1.CheckedChanged
        Dim I, CONT As Integer
        CONT = dgw1.RowCount - 1
        If ch1.Checked = True Then
            For I = 0 To CONT
                dgw1.Item(2, I).Value = True
            Next
        Else
            For I = 0 To CONT
                dgw1.Item(2, I).Value = False
            Next
        End If
    End Sub

    Private Sub BTN_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SALIR.Click
        main(107) = (0)
        Close()
    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch2.CheckedChanged
        Dim I, CONT As Integer
        CONT = dgw2.RowCount - 1
        If ch2.Checked = True Then
            For I = 0 To CONT
                dgw2.Item(2, I).Value = True
            Next
        Else
            For I = 0 To CONT
                dgw2.Item(2, I).Value = False
            Next
        End If
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If cbo_mes1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes1.Focus() : Exit Sub
        If cbo_año1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año1.Focus() : Exit Sub
        Dim i, _tabla, _reg, _regAux As Integer
        Dim codCuenta As String = ""
        Dim _marca As Boolean = False
        For i = 0 To dgw2.Rows.Count - 1
            If dgw2.Item(2, i).Value = True Then
                codCuenta += dgw2.Item(0, i).Value + ","
            End If
        Next
        If String.IsNullOrEmpty(codCuenta) Then
            MessageBox.Show("Seleccione al menos un registro para visualizar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        
        If rb5.Checked Then
            _tabla = 2
        ElseIf rb6.Checked Then
            _tabla = 1
        End If
        Me.Cursor = Cursors.WaitCursor
        For i = 0 To dgw2.Rows.Count - 1
            _reg += _regAux
            _regAux = 0
            codCuenta = dgw2.Item(0, i).Value
            If dgw2.Item(2, i).Value = True Then
                Try
                    'trans = con.BeginTransaction
                    Dim cmd As New SqlCommand("ACTUALIZA_MOV", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = codCuenta
                    cmd.Parameters.Add("@TABLA", SqlDbType.Int).Value = _tabla
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año1.Text
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes1.Text)
                    con.Open()
                    cmd.CommandTimeout = 7200
                    _regAux = cmd.ExecuteNonQuery()
                    'trans.Commit()
                Catch ex As Exception
                    'trans.Rollback()
                    MessageBox.Show("Error al actualizar la cuenta " & codCuenta & vbNewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Default
                    Exit For
                Finally
                    con.Close()
                End Try
            End If
        Next
        MessageBox.Show("La actualización devolvió " & _reg & " registros actualizados", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btn_Salir1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Salir1.Click
        main(107) = (0)
        Close()
    End Sub

    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        If rb1.Checked = True Then
            Label2.Text = "Al mes"
        End If
    End Sub

    Private Sub rb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb2.CheckedChanged
        If rb2.Checked = True Then
            Label2.Text = "Del mes"
        End If
    End Sub

    Private Sub rb5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb5.CheckedChanged
        If rb5.Checked = True Then
            Label1.Text = "Del mes"
        End If
    End Sub

    Private Sub rb6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb6.CheckedChanged
        If rb6.Checked = True Then
            Label1.Text = "Al mes"
        End If
    End Sub
End Class