Imports System.Data.SqlClient
Imports System.Text
Public Class BCO_TRANSFERENCIA
    Dim cod_aux, cod_banco, nro_mp, cod_com, cod_mp, nro_com As String
    Private obj As New Class1
    Private SB As New StringBuilder
    Private TIPO As String
    Public Sub BANCO_I_E()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_BANCO_COI_PTE", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("I_banco")
            adap.Fill(dt)
            DGW_IE.DataSource = dt
            DGW_IE.Columns.Item(0).ReadOnly = True
            DGW_IE.Columns.Item(1).ReadOnly = True
            DGW_IE.Columns.Item(2).ReadOnly = True
            DGW_IE.Columns.Item(3).ReadOnly = True
            DGW_IE.Columns.Item(4).ReadOnly = True
            DGW_IE.Columns.Item(5).ReadOnly = True
            DGW_IE.Columns.Item(6).ReadOnly = True
            DGW_IE.Columns.Item(7).ReadOnly = True
            DGW_IE.Columns.Item(8).ReadOnly = True
            DGW_IE.Columns.Item(10).ReadOnly = True
            DGW_IE.Columns.Item(11).ReadOnly = True
            DGW_IE.Columns.Item(12).ReadOnly = True
            DGW_IE.Columns.Item(13).ReadOnly = True
            DGW_IE.Columns.Item(14).ReadOnly = True
            DGW_IE.Columns.Item(15).Visible = False
            DGW_IE.Columns.Item(16).Visible = False
            DGW_IE.Columns.Item(0).Width = 30
            DGW_IE.Columns.Item(1).Width = 120
            DGW_IE.Columns.Item(2).Width = 40
            DGW_IE.Columns.Item(3).Width = 140
            DGW_IE.Columns.Item(4).Width = 25
            DGW_IE.Columns.Item(5).Width = &H4B
            DGW_IE.Columns.Item(5).DefaultCellStyle.Format = "d"
            DGW_IE.Columns.Item(6).Width = 140
            DGW_IE.Columns.Item(7).Width = 90
            DGW_IE.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW_IE.Columns.Item(8).Width = 35
            DGW_IE.Columns.Item(9).Width = 30
            DGW_IE.Columns.Item(10).Width = 35
            DGW_IE.Columns.Item(11).Width = 35
            DGW_IE.Columns.Item(12).Width = 30
            DGW_IE.Columns.Item(13).Width = 40
            DGW_IE.Columns.Item(14).Width = 40
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub BANCO_I_E_TRANS()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_BANCO_COI_IE_TRANS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("I_banco")
            adap.Fill(dt)
            DGW_IE_TRANS.DataSource = dt
            DGW_IE_TRANS.Columns.Item(0).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(1).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(2).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(3).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(4).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(5).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(6).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(7).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(8).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(10).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(11).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(12).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(13).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(14).ReadOnly = True
            DGW_IE_TRANS.Columns.Item(15).Visible = False
            DGW_IE_TRANS.Columns.Item(0).Width = 30
            DGW_IE_TRANS.Columns.Item(1).Width = 120
            DGW_IE_TRANS.Columns.Item(2).Width = 40
            DGW_IE_TRANS.Columns.Item(3).Width = 140
            DGW_IE_TRANS.Columns.Item(4).Width = 25
            DGW_IE_TRANS.Columns.Item(5).Width = &H4B
            DGW_IE_TRANS.Columns.Item(5).DefaultCellStyle.Format = "d"
            DGW_IE_TRANS.Columns.Item(6).Width = 140
            DGW_IE_TRANS.Columns.Item(7).Width = 90
            DGW_IE_TRANS.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW_IE_TRANS.Columns.Item(8).Width = 35
            DGW_IE_TRANS.Columns.Item(9).Width = 30
            DGW_IE_TRANS.Columns.Item(10).Width = 35
            DGW_IE_TRANS.Columns.Item(11).Width = 35
            DGW_IE_TRANS.Columns.Item(12).Width = 30
            DGW_IE_TRANS.Columns.Item(13).Width = 40
            DGW_IE_TRANS.Columns.Item(14).Width = 40
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub BANCO_TRANSF()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_BANCO_COI_PTE_TRANS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("trnas")
            adap.Fill(dt)
            DGW_TRANS.DataSource = dt
            DGW_TRANS.Columns.Item(0).ReadOnly = True
            DGW_TRANS.Columns.Item(1).ReadOnly = True
            DGW_TRANS.Columns.Item(2).ReadOnly = True
            DGW_TRANS.Columns.Item(3).ReadOnly = True
            DGW_TRANS.Columns.Item(4).ReadOnly = True
            DGW_TRANS.Columns.Item(5).ReadOnly = True
            DGW_TRANS.Columns.Item(6).ReadOnly = True
            DGW_TRANS.Columns.Item(7).ReadOnly = True
            DGW_TRANS.Columns.Item(8).ReadOnly = True
            DGW_TRANS.Columns.Item(10).ReadOnly = True
            DGW_TRANS.Columns.Item(11).ReadOnly = True
            DGW_TRANS.Columns.Item(12).ReadOnly = True
            DGW_TRANS.Columns.Item(13).ReadOnly = True
            DGW_TRANS.Columns.Item(14).ReadOnly = True
            DGW_TRANS.Columns.Item(0).Width = 30
            DGW_TRANS.Columns.Item(1).Width = 120
            DGW_TRANS.Columns.Item(2).Width = 40
            DGW_TRANS.Columns.Item(3).Width = 140
            DGW_TRANS.Columns.Item(4).Width = 25
            DGW_TRANS.Columns.Item(5).Width = &H4B
            DGW_TRANS.Columns.Item(5).DefaultCellStyle.Format = "d"
            DGW_TRANS.Columns.Item(6).Width = 140
            DGW_TRANS.Columns.Item(7).Width = 90
            DGW_TRANS.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW_TRANS.Columns.Item(8).Width = 35
            DGW_TRANS.Columns.Item(9).Width = 30
            DGW_TRANS.Columns.Item(10).Width = 35
            DGW_TRANS.Columns.Item(11).Width = 35
            DGW_TRANS.Columns.Item(12).Width = 30
            DGW_TRANS.Columns.Item(13).Width = 40
            DGW_TRANS.Columns.Item(14).Width = 40
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub BANCO_TRANSF_TRANSF()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_BANCO_COI_TRANS_TRANS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            Dim adap As New SqlDataAdapter(cmd)
            Dim dt As New DataTable("trnas")
            adap.Fill(dt)
            DGW_TRANS_TRANS.DataSource = dt
            DGW_TRANS_TRANS.Columns.Item(0).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(1).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(2).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(3).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(4).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(5).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(6).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(7).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(8).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(10).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(11).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(12).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(13).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(14).ReadOnly = True
            DGW_TRANS_TRANS.Columns.Item(0).Width = 30
            DGW_TRANS_TRANS.Columns.Item(1).Width = 120
            DGW_TRANS_TRANS.Columns.Item(2).Width = 40
            DGW_TRANS_TRANS.Columns.Item(3).Width = 140
            DGW_TRANS_TRANS.Columns.Item(4).Width = 25
            DGW_TRANS_TRANS.Columns.Item(5).Width = &H4B
            DGW_TRANS_TRANS.Columns.Item(5).DefaultCellStyle.Format = "d"
            DGW_TRANS_TRANS.Columns.Item(6).Width = 140
            DGW_TRANS_TRANS.Columns.Item(7).Width = 90
            DGW_TRANS_TRANS.Columns.Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            DGW_TRANS_TRANS.Columns.Item(8).Width = 35
            DGW_TRANS_TRANS.Columns.Item(9).Width = 30
            DGW_TRANS_TRANS.Columns.Item(10).Width = 35
            DGW_TRANS_TRANS.Columns.Item(11).Width = 35
            DGW_TRANS_TRANS.Columns.Item(12).Width = 30
            DGW_TRANS_TRANS.Columns.Item(13).Width = 40
            DGW_TRANS_TRANS.Columns.Item(14).Width = 40
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BCO_TRANSFERENCIA_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        main(29) = 0
    End Sub
    Private Sub BTN_ACEPTAR1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_ACEPTAR1.Click
        If (DGW_IE.RowCount = 0) Then
            MessageBox.Show("No existen Detalles", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim I As Integer = 0
            Dim CONT As Integer = (DGW_IE.RowCount - 1)
            I = 0
            Do While (I <= CONT)
                If DGW_IE.Item(9, I).Value.ToString = "True" Then
                    Dim estado As String = "FALLO"
                    cod_banco = DGW_IE.Item(2, I).Value.ToString
                    cod_mp = DGW_IE.Item(0, I).Value.ToString
                    nro_mp = DGW_IE.Item(1, I).Value.ToString
                    cod_aux = DGW_IE.Item(11, I).Value.ToString
                    cod_com = DGW_IE.Item(12, I).Value.ToString
                    nro_com = DGW_IE.Item(13, I).Value.ToString

                    If obj.VERIFICAR_I_CON(cod_aux, cod_com, nro_com, AÑO, MES) = False Then
                        MessageBox.Show("El Comprobante " & cod_aux & " - " & cod_com & " Nº " & nro_com & " ya existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    Dim fecha_com As DateTime = DateTime.Parse(DGW_IE.Item(5, I).Value.ToString)
                    TIPO = DGW_IE.Item(15, I).Value.ToString
                    If VERIFICAR_CPTO() Then
                        If Not VERIFICAR_T_BANCO_CUENTA() Then
                            Return
                        End If
                    Else
                        Return
                    End If
                    If VERIFICAR_IMPORTE() = False Then Return
                    Try
                        Dim CMD As New SqlCommand("TRANSFERENCIA_BANCOS_COI_IE", con)
                        CMD.CommandType = CommandType.StoredProcedure
                        CMD.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = cod_banco
                        CMD.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = cod_mp
                        CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = nro_mp
                        CMD.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = cod_aux
                        CMD.Parameters.Add("@COD_COM", SqlDbType.VarChar).Value = cod_com
                        CMD.Parameters.Add("@NRO_COM", SqlDbType.VarChar).Value = nro_com
                        CMD.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                        CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                        CMD.Parameters.Add("@FECHA_COM", SqlDbType.DateTime).Value = fecha_com
                        CMD.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                        CMD.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
                        CMD.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TIPO
                        CMD.Parameters.Add("@DESC_GIRO", SqlDbType.VarChar).Value = DGW_IE.Item(6, I).Value.ToString
                        CMD.Parameters.Add("@COD_MONEDA0", SqlDbType.VarChar).Value = DGW_IE.Item(10, I).Value.ToString
                        CMD.Parameters.Add("@TIPO_CAMBIO0", SqlDbType.Decimal).Value = DGW_IE.Item(16, I).Value.ToString
                        CMD.Parameters.Add("@IMP_TOTAL", SqlDbType.Decimal).Value = DGW_IE.Item(7, I).Value.ToString
                        con.Open()
                        estado = (CMD.ExecuteScalar)
                        'CMD.ExecuteNonQuery()
                        con.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        con.Close()
                    End Try
                    If (estado = "FALLO") Then
                        MessageBox.Show("Ocurrió un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                I += 1
            Loop
            MessageBox.Show("Los Comprobantes se transfirieron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BANCO_I_E()
            BANCO_I_E_TRANS()
        End If
    End Sub
    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        If (DGW_TRANS.RowCount = 0) Then
            MessageBox.Show("No existen Detalles", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim j As Integer = 0
            Dim k As Integer = (DGW_TRANS.RowCount - 1)
            j = 0
            Do While (j <= k)
                If DGW_TRANS.Item(9, j).Value.ToString = "True" Then
                    Dim estado As String = "FALLO"
                    Dim cod_doc As String = ""
                    Dim cod_banco As String = (DGW_TRANS.Item(2, j).Value)
                    Dim cod_mp As String = (DGW_TRANS.Item(0, j).Value)
                    Dim nro_mp As String = (DGW_TRANS.Item(1, j).Value)
                    Dim cod_aux As String = (DGW_TRANS.Item(11, j).Value)
                    Dim cod_com As String = (DGW_TRANS.Item(12, j).Value)
                    Dim nro_com As String = (DGW_TRANS.Item(13, j).Value)

                    If obj.VERIFICAR_I_CON(cod_aux, cod_com, nro_com, AÑO, MES) = False Then
                        MessageBox.Show("El Comprobante " & cod_aux & " - " & cod_com & " Nº " & nro_com & " ya existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If

                    Dim fecha_com As DateTime = DateTime.Parse(DGW_TRANS.Item(5, j).Value)
                    Try
                        Dim CMD As New SqlCommand("TRANSFERENCIA_BANCOS_COI_TRANS", con)
                        CMD.CommandType = CommandType.StoredProcedure
                        CMD.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = cod_banco
                        CMD.Parameters.Add("@COD_MP_INI", SqlDbType.VarChar).Value = cod_mp
                        CMD.Parameters.Add("@NRO_MP_INI", SqlDbType.VarChar).Value = nro_mp
                        CMD.Parameters.Add("@COD_AUX_INI", SqlDbType.VarChar).Value = cod_aux
                        CMD.Parameters.Add("@COD_COM_INI", SqlDbType.VarChar).Value = cod_com
                        CMD.Parameters.Add("@NRO_COM_INI", SqlDbType.VarChar).Value = nro_com
                        CMD.Parameters.Add("@FE_AÑO_INI", SqlDbType.VarChar).Value = AÑO
                        CMD.Parameters.Add("@FE_MES_INI", SqlDbType.VarChar).Value = MES
                        CMD.Parameters.Add("@FECHA_COM", SqlDbType.DateTime).Value = fecha_com
                        CMD.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                        CMD.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = cod_doc
                        CMD.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
                        con.Open()
                        estado = CMD.ExecuteScalar
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        MsgBox(ex.Message)
                    End Try
                    If (estado = "FALLO") Then
                        MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                j += 1
            Loop
            MessageBox.Show("Los Comprobantes se transfirieron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BANCO_TRANSF()
            BANCO_TRANSF_TRANSF()
        End If
    End Sub
    Private Sub BTN_DES_TRANS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_DES_TRANS.Click
        If (DGW_IE_TRANS.RowCount = 0) Then
            MessageBox.Show("No existen Detalles", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim I As Integer = 0
            Dim CONT As Integer = (DGW_IE_TRANS.RowCount - 1)
            I = 0
            Do While (I <= CONT)
                If DGW_IE_TRANS.Item(9, I).Value.ToString = "True" Then
                    Dim estado As String = "FALLO"
                    cod_banco = DGW_IE_TRANS.Item(2, I).Value.ToString
                    cod_mp = DGW_IE_TRANS.Item(0, I).Value.ToString
                    nro_mp = DGW_IE_TRANS.Item(1, I).Value.ToString
                    cod_aux = DGW_IE_TRANS.Item(11, I).Value.ToString
                    cod_com = DGW_IE_TRANS.Item(12, I).Value.ToString
                    nro_com = DGW_IE_TRANS.Item(13, I).Value.ToString
                    Dim fecha_com As DateTime = DateTime.Parse(DGW_IE_TRANS.Item(5, I).Value.ToString)
                    TIPO = DGW_IE_TRANS.Item(15, I).Value.ToString

                    If obj.VERIFICAR_TRANSF_ANALISIS(cod_aux, cod_com, nro_com, AÑO, MES) = False Then
                        MessageBox.Show("Los detalles se han transferido a Análisis", "No se puede destransferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        BANCO_I_E()
                        BANCO_I_E_TRANS()
                        Exit Sub
                    End If

                    'If VALIDAR_DESTRANSFERIR(cod_aux, cod_com, nro_com) = False Then
                    '    BANCO_I_E()
                    '    BANCO_I_E_TRANS()
                    '    Exit Sub
                    'End If
                    Try
                        Dim CMD As New SqlCommand("TRANSFERENCIA_BANCOS_COI_IE_DES", con)
                        CMD.CommandType = CommandType.StoredProcedure
                        CMD.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = cod_banco
                        CMD.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = cod_mp
                        CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = nro_mp
                        CMD.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = cod_aux
                        CMD.Parameters.Add("@COD_COM", SqlDbType.VarChar).Value = cod_com
                        CMD.Parameters.Add("@NRO_COM", SqlDbType.VarChar).Value = nro_com
                        CMD.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                        CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                        CMD.Parameters.Add("@FECHA_COM", SqlDbType.DateTime).Value = fecha_com
                        CMD.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                        CMD.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
                        CMD.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TIPO
                        CMD.Parameters.Add("@DESC_GIRO", SqlDbType.VarChar).Value = DGW_IE_TRANS.Item(6, I).Value.ToString
                        con.Open()
                        estado = (CMD.ExecuteScalar)
                        con.Close()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        con.Close()
                    End Try
                    If (estado = "FALLO") Then
                        MessageBox.Show("Ocurrió un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                I += 1
            Loop
            MessageBox.Show("Los Comprobantes se Des-transfirieron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BANCO_I_E()
            BANCO_I_E_TRANS()
        End If
    End Sub
    Function VALIDAR_DESTRANSFERIR(ByVal AUX0, ByVal COMP, ByVal NRO_COMP) As Boolean
        Dim RSPTA As String = ""
        Try
            Dim CMD As New SqlCommand("VALIDAR_DESTRANSFERIR_BANCOS_COI", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = AUX0
            CMD.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COMP
            CMD.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            con.Open()
            RSPTA = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
        If (RSPTA = "1") Then
            MessageBox.Show("El Documento de Nº de Medio de Pago : " & cod_mp & " - " & nro_mp & " no se puede Des-transferir.", "El comprobante ya se transfirió a Análisis.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Private Function VERIFICAR_CPTO() As Boolean
        SB.Remove(0, SB.Length)
        Dim Verifica As Boolean = False
        Try
            Dim CMD As New SqlCommand("VERIFICAR_CONCEPTO_CUENTA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = cod_banco
            CMD.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = cod_mp
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = nro_mp
            con.Open()
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                SB.AppendLine((Rs3.GetValue(0)) & " - " & Rs3.GetValue(1) & "  " & Rs3.GetValue(2))
            Loop
            con.Close()
        Catch ex As Exception
            Verifica = False
            MsgBox(ex.Message)
            con.Close()
            Return Verifica
        End Try
        If (SB.Length > 0) Then
            MessageBox.Show(("No existen los Concepto(s) : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Verifica = False
        Else
            Verifica = True
        End If
        Return Verifica
    End Function

    Private Sub BTN_DES_TRANS2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_DES_TRANS2.Click
        If (DGW_TRANS_TRANS.RowCount = 0) Then
            MessageBox.Show("No existen Detalles", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim j As Integer = 0
            Dim k As Integer = (DGW_TRANS_TRANS.RowCount - 1)
            j = 0
            Do While (j <= k)
                If DGW_TRANS_TRANS.Item(9, j).Value.ToString = "True" Then
                    Dim estado As String = "FALLO"
                    Dim cod_banco As String = (DGW_TRANS_TRANS.Item(2, j).Value)
                    Dim cod_mp As String = (DGW_TRANS_TRANS.Item(0, j).Value)
                    Dim nro_mp As String = (DGW_TRANS_TRANS.Item(1, j).Value)
                    Dim cod_aux As String = (DGW_TRANS_TRANS.Item(11, j).Value)
                    Dim cod_com As String = (DGW_TRANS_TRANS.Item(12, j).Value)
                    Dim nro_com As String = (DGW_TRANS_TRANS.Item(13, j).Value)
                    Dim fecha_com As DateTime = DateTime.Parse(DGW_TRANS_TRANS.Item(5, j).Value)
                    Try
                        Dim CMD As New SqlCommand("TRANSFERENCIA_BANCOS_COI_TRANS_DES", con)
                        CMD.CommandType = CommandType.StoredProcedure
                        CMD.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = cod_banco
                        CMD.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = cod_mp
                        CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = nro_mp
                        CMD.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = cod_aux
                        CMD.Parameters.Add("@COD_COM", SqlDbType.VarChar).Value = cod_com
                        CMD.Parameters.Add("@NRO_COM", SqlDbType.VarChar).Value = nro_com
                        CMD.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
                        CMD.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
                        CMD.Parameters.Add("@FECHA_COM", SqlDbType.DateTime).Value = fecha_com
                        CMD.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                        CMD.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = Now.Date
                        con.Open()
                        estado = (CMD.ExecuteScalar)
                        con.Close()
                    Catch ex As Exception
                        con.Close()
                        MsgBox(ex.Message)
                    End Try
                    If (estado = "FALLO") Then
                        MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
                j += 1
            Loop
            MessageBox.Show("Los Comprobantes se transfirieron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BANCO_TRANSF()
            BANCO_TRANSF_TRANSF()
        End If
    End Sub
    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        Dim CONT As Integer = (DGW_IE.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            DGW_IE.Item(9, i).Value = ch1.Checked
            i += 1
        Loop
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim CONT As Integer = (DGW_IE_TRANS.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            DGW_IE_TRANS.Item(9, i).Value = CheckBox1.Checked
            i += 1
        Loop
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim CONT As Integer = (DGW_TRANS.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            DGW_TRANS.Item(9, i).Value = CheckBox2.Checked
            i += 1
        Loop
    End Sub
    Private Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CheckBox3.CheckedChanged
        Dim CONT As Integer = (DGW_TRANS_TRANS.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= CONT)
            DGW_TRANS_TRANS.Item(9, i).Value = CheckBox3.Checked
            i += 1
        Loop
    End Sub
    Private Sub Transf_Banco_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        BANCO_I_E()
        BANCO_I_E_TRANS()
        BANCO_TRANSF()
        BANCO_TRANSF_TRANSF()
        DGW_IE.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW_TRANS.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW_IE_TRANS.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW_TRANS_TRANS.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
    End Sub
    Public Function VERIFICAR_IMPORTE() As Boolean
        Dim RSPTA As String = ""
        Try
            Dim CMD As New SqlCommand("VALIDAR_TRANSFERENCIA_BANCOS_COI_IE2", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = cod_banco
            CMD.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = cod_mp
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = nro_mp
            con.Open()
            RSPTA = (CMD.ExecuteScalar)
            'CMD.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = CMD.ExecuteReader
            Dim MON As String
            Dim SUM_DEBE_SOLES_1, SUM_HABER_SOLES_1 As Decimal
            Dim SUM_DEBE_DOLAR_2, SUM_HABER_DOLAR_2 As Decimal
            Do While rs3.Read
                MON = (Rs3.GetValue(0))
                If MON = "S" Then
                    SUM_DEBE_SOLES_1 = rs3.GetValue(1) + rs3.GetValue(2)
                    SUM_HABER_SOLES_1 = rs3.GetValue(3) + rs3.GetValue(4)
                    SUM_DEBE_DOLAR_2 = rs3.GetValue(5) + rs3.GetValue(6)
                    SUM_HABER_DOLAR_2 = rs3.GetValue(7) + rs3.GetValue(8)

                    If (SUM_DEBE_SOLES_1 = SUM_HABER_SOLES_1 And SUM_DEBE_DOLAR_2 = SUM_HABER_DOLAR_2) Then
                        RSPTA = "EXITO"
                    ElseIf -0.01 <= SUM_DEBE_SOLES_1 - SUM_HABER_SOLES_1 <= 0.01 And -0.01 <= SUM_DEBE_DOLAR_2 - SUM_HABER_DOLAR_2 <= 0.01 Then
                        RSPTA = "EXITO"
                    Else
                        RSPTA = "FALLO"
                    End If
                Else
                    If (SUM_DEBE_DOLAR_2 = SUM_HABER_DOLAR_2) Then
                        RSPTA = "EXITO"
                    Else
                        RSPTA = "FALLO"
                    End If
                End If
                'End If
            Loop
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
        If (RSPTA = "EXITO") Then
            Return True
        End If
        MessageBox.Show(String.Concat(New String() {"El Documento de Nº de Medio de Pago : ", cod_mp, " - ", nro_mp, " no se puede transferir."}), "El importe debe y haber deben ser iguales", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function
    Public Function VERIFICAR_T_BANCO_CUENTA() As Boolean
        SB.Remove(0, SB.Length)
        Try
            Dim CMD As New SqlCommand("VERIFICAR_TRANSF_BAN_COI", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = cod_banco
            CMD.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = cod_mp
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = nro_mp
            CMD.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TIPO
            con.Open()
            CMD.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader
            Do While Rs3.Read
                SB.AppendLine((Rs3.GetValue(0)) & " - " & Rs3.GetValue(1) & "  " & Rs3.GetValue(2))
            Loop
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            con.Close()
        End Try
        If (SB.Length > 0) Then
            MessageBox.Show(("No existen cuentas para los Concepto(s) : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function
End Class