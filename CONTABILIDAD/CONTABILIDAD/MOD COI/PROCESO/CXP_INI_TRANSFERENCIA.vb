Imports System.Data.SqlClient
Imports System.Text

Public Class CXP_INI_TRANSFERENCIA
    Dim CON_GCO As New SqlConnection
    Dim fila1 As Integer
    Dim fila2 As Integer
    Dim OBJ As New Class1
    Dim SB As New StringBuilder
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.RowCount - 1)

        I = 0
        Do While (I <= CONT)
            If dgw1.Item(11, I).Value = True Then
                If VERIFICAR_CUENTA(I) Then
                    If OBJ.VERIFICAR_PCTAS_PAGAR(dgw1.Item(2, I).Value.ToString, dgw1.Item(3, I).Value.ToString, dgw1.Item(4, I).Value.ToString, dgw1.Item(6, I).Value.ToString, dgw1.Item(10, I).Value.ToString) = False Then
                        MessageBox.Show("El Documento ya existe en Ctas. x Pagar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        If (GRABAR_COI(I) = "EXITO") Then
                            STATUS_COI(I)
                        Else
                            MessageBox.Show("Ocurrió un error al transferir el pendiente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return
                        End If
                    End If
                End If
            End If
            I += 1
        Loop
        MessageBox.Show("Los documentos se transfirieron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        CARGAR_PENDIENTES()
        CARGAR_CERRADAS()
    End Sub
    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw2.RowCount - 1)

        I = 0
        Do While (I <= CONT)
            If dgw2.Item(11, I).Value = True Then
                Dim CTA0 As String = OBJ.BUSCAR_CUENTA_PCXP(Integer.Parse(dgw2.Item(0, I).Value.ToString).ToString("00"), dgw2.Item(4, I).Value.ToString, dgw2.Item(2, I).Value.ToString, dgw2.Item(3, I).Value.ToString)
                If ((CTA0 <> "") AndAlso OBJ.VERIFICAR_ELIMINAR_PCTAS_PAGAR(dgw2.Item(2, I).Value.ToString, dgw2.Item(3, I).Value.ToString, dgw2.Item(4, I).Value.ToString, dgw2.Item(6, I).Value.ToString, CTA0) = False) Then
                    MessageBox.Show("La cuenta esta cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                If (DESTRANSFERIR_COI(I) = "EXITO") Then
                    STATUS_COI2(I)
                Else
                    MessageBox.Show("Ocurrió un error al destransferir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
            End If
            I += 1
        Loop
        MessageBox.Show("Los documentos se transfirieron", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        CARGAR_PENDIENTES()
        CARGAR_CERRADAS()
    End Sub
    Private Sub btn_buscar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar1.Click
        txt_letra1.Focus()
        btn_sgt1.Enabled = True
        'Dim VB$t_i4$L0 As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (dgw1.RowCount - 1))
            'Dim VB$t_i4$L1 As Integer = Strings.Len(dgw1.Item(5, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= Len(dgw1.Item(5, i).Value.ToString))
                If (txt_letra1.Text.ToLower = Strings.Mid(dgw1.Item(5, i).Value.ToString, f, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = (dgw1.Rows.Item(i).Cells.Item(0))
                    fila1 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub
    Private Sub btn_buscar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_buscar2.Click
        txt_letra2.Focus()
        btn_sgt2.Enabled = True
        'Dim VB$t_i4$L0 As Integer = (dgw2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (dgw2.RowCount - 1))
            'Dim VB$t_i4$L1 As Integer = Strings.Len(dgw2.Item(5, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= Len(dgw2.Item(5, i).Value.ToString))
                If (txt_letra2.Text.ToLower = Strings.Mid(dgw2.Item(5, i).Value.ToString, f, Strings.Len(txt_letra2.Text)).ToLower) Then
                    dgw2.CurrentCell = (dgw2.Rows.Item(i).Cells.Item(0))
                    fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
    End Sub
    Private Sub btn_sgt1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt1.Click
        'Dim VB$t_i4$L0 As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = fila1
        Do While (i <= (dgw1.RowCount - 1))
            'Dim VB$t_i4$L1 As Integer = Strings.Len(dgw1.Item(5, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= Len(dgw1.Item(5, i).Value.ToString))
                If (txt_letra1.Text.ToLower = Strings.Mid(dgw1.Item(5, i).Value.ToString, f, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = (dgw1.Rows.Item(i).Cells.Item(1))
                    fila1 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Private Sub btn_sgt2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_sgt2.Click
        'Dim VB$t_i4$L0 As Integer = (dgw2.RowCount - 1)
        Dim i As Integer = fila2
        Do While (i <= (dgw2.RowCount - 1))
            'Dim VB$t_i4$L1 As Integer = Strings.Len(dgw2.Item(5, i).Value.ToString)
            Dim f As Integer = 1
            Do While (f <= Len(dgw2.Item(5, i).Value.ToString))
                If (txt_letra2.Text.ToLower = Strings.Mid(dgw2.Item(5, i).Value.ToString, f, Strings.Len(txt_letra2.Text)).ToLower) Then
                    dgw2.CurrentCell = (dgw2.Rows.Item(i).Cells.Item(1))
                    fila2 = (i + 1)
                    Return
                End If
                f += 1
            Loop
            i += 1
        Loop
        MessageBox.Show("Ya no existen mas registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End Sub
    Sub CARGAR_CERRADAS()
        If (MES = "00") Then
            Try
                Dim CMD As New SqlCommand("COI_MOSTRAR_CXP_INI_CERRADA_00", CON_GCO)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                Dim ADAP As New SqlDataAdapter(CMD)
                Dim DT As New DataTable("SD")
                ADAP.Fill(DT)
                dgw2.DataSource = (DT)
                dgw2.Columns.Item(0).Visible = (False)
                dgw2.Columns.Item(10).Visible = (False)
                dgw2.Columns.Item(17).Visible = (False)
                dgw2.Columns.Item(18).Visible = (False)
                dgw2.Columns.Item(19).Visible = (False)
                dgw2.Columns.Item(20).Visible = (False)
                dgw2.Columns.Item(21).Visible = (False)
                dgw2.Columns.Item(22).Visible = (False)
                dgw2.Columns.Item(23).Visible = (False)
                dgw2.Columns.Item(25).Visible = (False)
                dgw2.Columns.Item(26).Visible = (False)
                dgw2.Columns.Item(1).Width = (90)
                dgw2.Columns.Item(2).Width = (30)
                dgw2.Columns.Item(3).Width = (90)
                dgw2.Columns.Item(4).Width = (50)
                dgw2.Columns.Item(5).Width = (140)
                dgw2.Columns.Item(6).Width = (&H55)
                dgw2.Columns.Item(7).Width = (&H4B)
                dgw2.Columns.Item(7).DefaultCellStyle.Format = ("d")
                dgw2.Columns.Item(8).Width = (&H4B)
                dgw2.Columns.Item(8).DefaultCellStyle.Format = ("d")
                dgw2.Columns.Item(9).Width = (&H55)
                dgw2.Columns.Item(9).DefaultCellStyle.Format = ("N2")
                dgw2.Columns.Item(9).DefaultCellStyle.Alignment = (&H400)
                dgw2.Columns.Item(11).Width = (30)
                dgw2.Columns.Item(12).Width = (30)
                dgw2.Columns.Item(13).Width = (&H37)
                dgw2.Columns.Item(13).DefaultCellStyle.Format = ("N4")
                dgw2.Columns.Item(13).DefaultCellStyle.Alignment = (&H400)
                dgw2.Columns.Item(14).Width = (35)
                dgw2.Columns.Item(15).Width = (35)
                dgw2.Columns.Item(16).Width = (35)
                dgw2.Columns.Item(18).Width = (35)
                dgw2.Columns.Item(24).Width = (35)
            Catch ex As Exception
                MsgBox(ex.Message)
                'MsgBox(ex.Message)

            End Try
        Else
            Try
                Dim CMD As New SqlCommand("COI_MOSTRAR_CXP_INI_CERRADA", CON_GCO)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                Dim ADAP As New SqlDataAdapter(CMD)
                Dim DT As New DataTable("SD")
                ADAP.Fill(DT)
                dgw2.DataSource = (DT)
                dgw2.Columns.Item(0).Visible = (False)
                dgw2.Columns.Item(10).Visible = (False)
                dgw2.Columns.Item(17).Visible = (False)
                dgw2.Columns.Item(18).Visible = (False)
                dgw2.Columns.Item(19).Visible = (False)
                dgw2.Columns.Item(20).Visible = (False)
                dgw2.Columns.Item(21).Visible = (False)
                dgw2.Columns.Item(22).Visible = (False)
                dgw2.Columns.Item(23).Visible = (False)
                dgw2.Columns.Item(1).Width = (90)
                dgw2.Columns.Item(2).Width = (30)
                dgw2.Columns.Item(3).Width = (90)
                dgw2.Columns.Item(4).Width = (50)
                dgw2.Columns.Item(5).Width = (140)
                dgw2.Columns.Item(6).Width = (&H55)
                dgw2.Columns.Item(7).Width = (&H4B)
                dgw2.Columns.Item(7).DefaultCellStyle.Format = ("d")
                dgw2.Columns.Item(8).Width = (&H4B)
                dgw2.Columns.Item(8).DefaultCellStyle.Format = ("d")
                dgw2.Columns.Item(9).Width = (&H55)
                dgw2.Columns.Item(9).DefaultCellStyle.Format = ("N2")
                dgw2.Columns.Item(9).DefaultCellStyle.Alignment = (&H400)
                dgw2.Columns.Item(11).Width = (30)
                dgw2.Columns.Item(12).Width = (30)
                dgw2.Columns.Item(13).Width = (&H37)
                dgw2.Columns.Item(13).DefaultCellStyle.Format = ("N4")
                dgw2.Columns.Item(13).DefaultCellStyle.Alignment = (&H400)
                dgw2.Columns.Item(14).Width = (35)
                dgw2.Columns.Item(15).Width = (35)
                dgw2.Columns.Item(16).Width = (35)
                dgw2.Columns.Item(18).Width = (35)
                dgw2.Columns.Item(24).Width = (35)
            Catch ex As Exception
                MsgBox(ex.Message)
                'MsgBox(ex.Message)

            End Try
        End If
    End Sub
    Sub CARGAR_PENDIENTES()
        If (MES = "00") Then
            Try
                Dim CMD As New SqlCommand("COI_MOSTRAR_CXP_INI_PTE_00", CON_GCO)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                Dim ADAP As New SqlDataAdapter(CMD)
                Dim DT As New DataTable("SD")
                ADAP.Fill(DT)
                dgw1.DataSource = (DT)
                dgw1.Columns.Item(0).Visible = (False)
                dgw1.Columns.Item(17).Visible = (False)
                dgw1.Columns.Item(18).Visible = (False)
                dgw1.Columns.Item(19).Visible = (False)
                dgw1.Columns.Item(20).Visible = (False)
                dgw1.Columns.Item(21).Visible = (False)
                dgw1.Columns.Item(22).Visible = (False)
                dgw1.Columns.Item(23).Visible = (False)
                dgw1.Columns.Item(25).Visible = (False)
                dgw1.Columns.Item(26).Visible = (False)
                dgw1.Columns.Item(1).Width = (&H55)
                dgw1.Columns.Item(2).Width = (30)
                dgw1.Columns.Item(3).Width = (&H55)
                dgw1.Columns.Item(4).Width = (50)
                dgw1.Columns.Item(5).Width = (120)
                dgw1.Columns.Item(6).Width = (&H55)
                dgw1.Columns.Item(7).Width = (&H4B)
                dgw1.Columns.Item(7).DefaultCellStyle.Format = ("d")
                dgw1.Columns.Item(8).Width = (&H4B)
                dgw1.Columns.Item(8).DefaultCellStyle.Format = ("d")
                dgw1.Columns.Item(9).Width = (&H55)
                dgw1.Columns.Item(9).DefaultCellStyle.Format = ("N2")
                dgw1.Columns.Item(9).DefaultCellStyle.Alignment = (&H400)
                dgw1.Columns.Item(10).Width = (&H4B)
                dgw1.Columns.Item(11).Width = (30)
                dgw1.Columns.Item(12).Width = (30)
                dgw1.Columns.Item(13).Width = (&H37)
                dgw1.Columns.Item(13).DefaultCellStyle.Format = ("N4")
                dgw1.Columns.Item(13).DefaultCellStyle.Alignment = (&H400)
                dgw1.Columns.Item(14).Width = (35)
                dgw1.Columns.Item(15).Width = (35)
                dgw1.Columns.Item(16).Width = (35)
                dgw1.Columns.Item(18).Width = (35)
                dgw1.Columns.Item(24).Width = (35)
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        Else
            Try
                Dim CMD As New SqlCommand("COI_MOSTRAR_CXP_INI_PTE", CON_GCO)
                CMD.CommandType = (CommandType.StoredProcedure)
                CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                Dim ADAP As New SqlDataAdapter(CMD)
                Dim DT As New DataTable("SD")
                ADAP.Fill(DT)
                dgw1.DataSource = (DT)
                dgw1.Columns.Item(0).Visible = (False)
                dgw1.Columns.Item(17).Visible = (False)
                dgw1.Columns.Item(18).Visible = (False)
                dgw1.Columns.Item(19).Visible = (False)
                dgw1.Columns.Item(20).Visible = (False)
                dgw1.Columns.Item(21).Visible = (False)
                dgw1.Columns.Item(22).Visible = (False)
                dgw1.Columns.Item(23).Visible = (False)
                dgw1.Columns.Item(1).Width = (&H55)
                dgw1.Columns.Item(2).Width = (30)
                dgw1.Columns.Item(3).Width = (&H55)
                dgw1.Columns.Item(4).Width = (50)
                dgw1.Columns.Item(5).Width = (120)
                dgw1.Columns.Item(6).Width = (&H55)
                dgw1.Columns.Item(7).Width = (&H4B)
                dgw1.Columns.Item(7).DefaultCellStyle.Format = ("d")
                dgw1.Columns.Item(8).Width = (&H4B)
                dgw1.Columns.Item(8).DefaultCellStyle.Format = ("d")
                dgw1.Columns.Item(9).Width = (&H55)
                dgw1.Columns.Item(9).DefaultCellStyle.Format = ("N2")
                dgw1.Columns.Item(9).DefaultCellStyle.Alignment = (&H400)
                dgw1.Columns.Item(10).Width = (&H4B)
                dgw1.Columns.Item(11).Width = (30)
                dgw1.Columns.Item(12).Width = (30)
                dgw1.Columns.Item(13).Width = (&H37)
                dgw1.Columns.Item(13).DefaultCellStyle.Format = ("N4")
                dgw1.Columns.Item(13).DefaultCellStyle.Alignment = (&H400)
                dgw1.Columns.Item(14).Width = (35)
                dgw1.Columns.Item(15).Width = (35)
                dgw1.Columns.Item(16).Width = (35)
                dgw1.Columns.Item(18).Width = (35)
                dgw1.Columns.Item(24).Width = (35)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub ch_cadena1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cadena1.CheckedChanged
        If ch_cadena1.Checked Then
            btn_buscar1.Enabled = True
            txt_letra1.Clear()
            txt_letra1.Focus()
        End If
    End Sub
    Private Sub ch_cadena2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_cadena2.CheckedChanged
        If ch_cadena2.Checked Then
            btn_buscar2.Enabled = True
            txt_letra2.Clear()
            txt_letra2.Focus()
        End If
    End Sub
    Private Sub ch_doc1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc1.CheckedChanged
        If ch_doc1.Checked Then
            dgw1.Sort(dgw1.Columns.Item(3), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Clear()
            txt_letra1.Focus()
        End If
    End Sub
    Private Sub ch_doc2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc2.CheckedChanged
        If ch_doc2.Checked Then
            dgw2.Sort(dgw2.Columns.Item(3), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Clear()
            txt_letra2.Focus()
        End If
    End Sub
    Private Sub ch_per1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per1.CheckedChanged
        If ch_per1.Checked Then
            dgw1.Sort(dgw1.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Clear()
            txt_letra1.Focus()
        End If
    End Sub
    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per2.CheckedChanged
        If ch_per2.Checked Then
            dgw2.Sort(dgw2.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Clear()
            txt_letra2.Focus()
        End If
    End Sub
    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        If (TXT_CUENTA.Text.Trim <> "") AndAlso OBJ.VERIFICAR_CUENTA(TXT_CUENTA.Text, AÑO) = False Then
            MessageBox.Show("La Cuenta no existe en el PLan de Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim i As Integer = 0
            Dim cont As Integer = (dgw1.RowCount - 1)

            i = 0
            Do While (i <= cont)
                dgw1.Item(11, i).Value = (ch1.Checked)
                If ch1.Checked Then
                    dgw1.Item(10, i).Value = (TXT_CUENTA.Text.ToString)
                Else
                    dgw1.Item(10, i).Value = ("")
                End If
                i += 1
            Loop
        End If
    End Sub
    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        Dim i As Integer = 0
        Dim cont As Integer = (dgw2.RowCount - 1)

        i = 0
        Do While (i <= cont)
            dgw2.Item(11, i).Value = (ch2.Checked)
            i += 1
        Loop
    End Sub
    Function DESTRANSFERIR_COI(ByVal FILA0 As Integer) As String
        Dim AÑO0 As String
        Dim MES0 As String
        If (MES = "00") Then
            AÑO0 = dgw2.Item(25, FILA0).Value.ToString
            MES0 = dgw2.Item(26, FILA0).Value.ToString
        Else
            MES0 = MES
            AÑO0 = AÑO
        End If
        Dim estado As String = "FALLO"
        Try
            Dim comand1 As New SqlCommand("GCO_REGRESAR_CXP_INI", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = (CInt(dgw2.Item(0, FILA0).Value.ToString).ToString("00"))
            comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = (dgw2.Item(4, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (dgw2.Item(2, FILA0).Value.ToString)
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = (dgw2.Item(3, FILA0).Value.ToString)
            comand1.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = (dgw2.Item(6, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = ("")
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (AÑO0)
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = (MES0)
            con.Open()
            estado = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception

            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
            estado = "FALLO"

        End Try
        Return estado
    End Function
    Private Sub dgw1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgw1.CellClick
        If (dgw1.CurrentCellAddress.X = 11) Then
            If dgw1.Item(11, dgw1.CurrentRow.Index).Value = False Then
                dgw1.Item(11, dgw1.CurrentRow.Index).Value = (True)
                dgw1.Item(10, dgw1.CurrentRow.Index).Value = (TXT_CUENTA.Text.ToString)
            Else
                dgw1.Item(11, dgw1.CurrentRow.Index).Value = (False)
                dgw1.Item(10, dgw1.CurrentRow.Index).Value = ("")
            End If
        End If
    End Sub
    Function GRABAR_COI(ByVal FILA0 As Integer) As String
        Dim AÑO0 As String
        Dim MES0 As String
        If (MES = "00") Then
            AÑO0 = dgw1.Item(25, FILA0).Value.ToString
            MES0 = dgw1.Item(26, FILA0).Value.ToString
        Else
            MES0 = MES
            AÑO0 = AÑO
        End If
        Dim estado As String = "FALLO"
        Try
            Dim comand1 As New SqlCommand("GCO_TRANSFERIR_CXP_INI", con)
            comand1.CommandType = (CommandType.StoredProcedure)
            comand1.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = (CInt(dgw1.Item(0, FILA0).Value.ToString).ToString("00"))
            comand1.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = (dgw1.Item(4, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (dgw1.Item(2, FILA0).Value.ToString)
            comand1.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = (dgw1.Item(3, FILA0).Value.ToString)
            comand1.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = (dgw1.Item(6, FILA0).Value.ToString)
            comand1.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = (dgw1.Item(7, FILA0).Value.ToString)
            comand1.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = (dgw1.Item(8, FILA0).Value.ToString)
            comand1.Parameters.Add("@IMP_DOC", SqlDbType.Decimal).Value = (dgw1.Item(9, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = (dgw1.Item(12, FILA0).Value.ToString)
            comand1.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = (dgw1.Item(13, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_D_H", SqlDbType.VarChar).Value = (dgw1.Item(24, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_SIT", SqlDbType.VarChar).Value = (dgw1.Item(14, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_EST", SqlDbType.VarChar).Value = (dgw1.Item(15, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_UBI", SqlDbType.VarChar).Value = (dgw1.Item(16, FILA0).Value.ToString)
            comand1.Parameters.Add("@OBSERVACION", SqlDbType.VarChar).Value = (dgw1.Item(17, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_REF", SqlDbType.VarChar).Value = (dgw1.Item(18, FILA0).Value.ToString)
            comand1.Parameters.Add("@NRO_REF", SqlDbType.VarChar).Value = (dgw1.Item(19, FILA0).Value.ToString)
            comand1.Parameters.Add("@FECHA_REF", SqlDbType.DateTime).Value = (dgw1.Item(20, FILA0).Value.ToString)
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw1.Item(10, FILA0).Value.ToString)
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (AÑO0)
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = (MES0)
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = ("")
            comand1.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = (COD_USU)
            comand1.Parameters.Add("@DESC_PER", SqlDbType.VarChar).Value = (dgw1.Item(5, FILA0).Value.ToString)
            con.Open()
            estado = (comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception

            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"

        End Try
        Return estado
    End Function
    Sub STATUS_COI(ByVal FILA0 As Integer)
        Try
            Dim pro_02 As New SqlCommand("COI_CXP_STATUS", CON_GCO)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = (dgw1.Item(0, FILA0).Value.ToString)
            pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = (dgw1.Item(4, FILA0).Value.ToString)
            pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = (dgw1.Item(3, FILA0).Value.ToString)
            pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (dgw1.Item(2, FILA0).Value.ToString)
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = (COD_USU)
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            CON_GCO.Close()
        Catch ex As Exception

            CON_GCO.Close()

            MsgBox(ex.Message)
        End Try
    End Sub
    Sub STATUS_COI2(ByVal FILA0 As Integer)
        Try
            Dim pro_02 As New SqlCommand("COI_CXP_STATUS2", CON_GCO)
            pro_02.CommandType = (CommandType.StoredProcedure)
            pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = (dgw2.Item(0, FILA0).Value.ToString)
            pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = (dgw2.Item(4, FILA0).Value.ToString)
            pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = (dgw2.Item(3, FILA0).Value.ToString)
            pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (dgw2.Item(2, FILA0).Value.ToString)
            pro_02.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = (COD_USU)
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            CON_GCO.Close()
        Catch ex As Exception
            CON_GCO.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TXT_CUENTA_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_CUENTA.LostFocus
        If ((TXT_CUENTA.Text.Trim <> "") AndAlso OBJ.VERIFICAR_CUENTA(TXT_CUENTA.Text, AÑO) = False) Then
            MessageBox.Show("La Cuenta no existe en el Plan de Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_CUENTA.Clear()
        End If
    End Sub
    Private Sub txt_letra1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra1.TextChanged
        Dim i As Integer
        If ch_doc1.Checked Then
            txt_letra1.Focus()
            i = 0
            Do While (i <= (dgw1.RowCount - 1))
                If (txt_letra1.Text.ToLower = Strings.Mid((dgw1.Item(3, i).Value), 1, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = (dgw1.Rows.Item(i).Cells.Item(1))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_per1.Checked Then
            txt_letra1.Focus()
            i = 0
            Do While (i <= (dgw1.RowCount - 1))
                If (txt_letra1.Text.ToLower = Strings.Mid((dgw1.Item(5, i).Value), 1, Strings.Len(txt_letra1.Text)).ToLower) Then
                    dgw1.CurrentCell = (dgw1.Rows.Item(i).Cells.Item(1))
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub
    Private Sub txt_letra2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_letra2.TextChanged
        Dim i As Integer
        If ch_doc2.Checked Then
            txt_letra2.Focus()
            i = 0
            Do While (i <= (dgw2.RowCount - 1))
                If (txt_letra2.Text.ToLower = Strings.Mid((dgw2.Item(3, i).Value), 1, Strings.Len(txt_letra2.Text)).ToLower) Then
                    dgw2.CurrentCell = (dgw2.Rows.Item(i).Cells.Item(1))
                    Exit Do
                End If
                i += 1
            Loop
        ElseIf ch_per2.Checked Then
            txt_letra2.Focus()
            i = 0
            Do While (i <= (dgw2.RowCount - 1))
                If (txt_letra2.Text.ToLower = Strings.Mid((dgw2.Item(5, i).Value), 1, Strings.Len(txt_letra2.Text)).ToLower) Then
                    dgw2.CurrentCell = (dgw2.Rows.Item(i).Cells.Item(1))
                    Exit Do
                End If
                i += 1
            Loop
        End If
    End Sub
    Function VERIFICAR_CUENTA(ByVal FILA0 As Object) As Boolean
        SB.Remove(0, SB.Length)
        If (dgw1.Item(10, (FILA0)).Value.ToString.Trim = "") Then
            SB.ToString.Trim((dgw1.Item(10, (FILA0)).Value.ToString))
            SB.AppendLine(dgw1.Item(10, (FILA0)).Value.ToString)
        Else
            Try
                Dim comand1 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con)
                comand1.CommandType = (CommandType.StoredProcedure)
                comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (dgw1.Item(10, (FILA0)).Value.ToString)
                comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                con.Open()
                comand1.ExecuteNonQuery()
                Dim Rs3 As SqlDataReader = comand1.ExecuteReader
                Do While Rs3.Read
                    SB.ToString.Trim(Rs3.GetValue(0))
                    SB.AppendLine(Rs3.GetValue(0))
                Loop
                con.Close()
            Catch ex As Exception

                con.Close()
                MsgBox(ex.Message)
            End Try
        End If
        If (SB.Length = 0) Then
            Return True
        End If
        MessageBox.Show(("No existen en el Plan de cuentas : " & vbCrLf & SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function
    Private Sub CXP_INI_TRANSFERENCIA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(37) = 0
    End Sub
    Private Sub CXP_INI_TRANSFERENCIA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim emp00 As String = OBJ.DIR_TABLA_DESC("GCO_BD", "TDTRA")
        CON_GCO.ConnectionString = ("data source=" & nombre_servidor & ";initial catalog=BD_GCO" & emp00 & ";uid=miguel;pwd=main;")
        CARGAR_PENDIENTES()
        CARGAR_CERRADAS()
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
    End Sub
End Class