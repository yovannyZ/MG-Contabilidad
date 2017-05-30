Imports System.Data.SqlClient
Public Class REFERENCIA_RETENCION
    Dim año0, mes0, cod_mon0, cod_ref As String
    Dim RET As Decimal
    Dim OBJ As New Class1
    Public COD_PER, COD_SUC As String
    Public FECHA0 As DateTime
    Public TC, IMPORTE00 As Decimal

    Public Sub CBO_TIPO_DOC00()
        Try
            Dim PROG_01 As New SqlCommand("mostrar_desc_doc", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_tipo_ref.Items.Add(Rs3.GetString(0))
            Loop
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
    End Sub

    Public Sub CBO_MONEDA00()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_MONEDA_COI
        cbo_moneda.DataSource = DT
        cbo_moneda.DisplayMember = DT.Columns.Item(0).ToString
        cbo_moneda.ValueMember = DT.Columns.Item(1).ToString
        cbo_moneda.SelectedIndex = -1
    End Sub

    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_ACEPTAR.Click
        If txt_total.Text <> txt_doc_total.Text Then
            MessageBox.Show("Los Totales de Documento deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'Exit Sub
            If txt_total2.Text <> txt_doc_total2.Text Then
                MessageBox.Show("Los Totales de Retención deben ser iguales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Exit Sub
            End If
        End If
        RETENCION_CXP.ValorSoles = txt_ret.Text
        DialogResult = Windows.Forms.DialogResult.OK
        Hide()
    End Sub

    Private Sub REFERENCIA_RETENCION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CONSULTA_REQ_ORD_PROD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.CBO_MONEDA00()
        Me.CBO_TIPO_DOC00()
        DGW_CAB.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        RET = OBJ.IMPUESTO("RET")
    End Sub

    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Hide()
    End Sub

    Sub HALLAR_DATOS_REF(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal CUENTA0 As Object, ByVal SUC0 As String)
        cbo_moneda.SelectedIndex = -1
        txt_ini.Text = "0.00"
        cod_mon0 = ""
        Try
            Dim PROG_01 As New SqlCommand("BUSCAR_DATOS_CXP", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC0
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER0
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = CUENTA0
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = SUC0
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While rs3.Read
                dtp_ref.Value = (Rs3.GetValue(0))
                cod_mon0 = rs3.GetValue(1)
                txt_ini.Text = rs3.GetValue(2)

                TXT_INI_2DO.Text = rs3.GetValue(2)
                TXT_PDTE.Text = rs3.GetValue(3)
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        '-----------------------------------------------------------------------------------
        Try
            If cod_mon0 Is Nothing Then cod_mon0 = ""
            If txt_ini.Text.Trim = "" Then txt_ini.Text = "0"
            cbo_moneda.SelectedValue = cod_mon0
            If cod_mon0 = "S" Then
                txt_conv.Text = txt_ini.Text
                txt_ret.Text = Math.Round(Decimal.Parse(txt_conv.Text * RET / 100), 2, MidpointRounding.AwayFromZero)

            Else
                txt_conv.Text = Math.Round(Decimal.Parse(txt_ini.Text * TC), 2)
                Dim porcentaje As Decimal
                'porcentaje = OBJ.HACER_DECIMAL(txt_ini.Text * RET / 100)
                'txt_ret.Text = porcentaje * TC
                txt_ret.Text = CDec(txt_conv.Text) * (RET / 100)
                txt_ret.Text = Math.Round(CDec(txt_ret.Text), 2, MidpointRounding.AwayFromZero)
                '------------------------------------------------
                Dim sgdo, pdte As Decimal
                sgdo = Math.Round(Decimal.Parse(TXT_INI_2DO.Text * TC), 2)
                pdte = Math.Round(Decimal.Parse(TXT_PDTE.Text * TC), 2)
            End If
            '-----------------------------------------------------
            txt_ini.Text = OBJ.HACER_DECIMAL(txt_ini.Text)
            txt_conv.Text = OBJ.HACER_DECIMAL(txt_conv.Text)
            txt_ret.Text = OBJ.HACER_DECIMAL(txt_ret.Text)
            TXT_INI_2DO.Text = OBJ.HACER_DECIMAL(TXT_INI_2DO.Text)
            TXT_PDTE.Text = OBJ.HACER_DECIMAL(TXT_PDTE.Text)
            '-----------------------------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Sub CARGAR_DOC_REF(ByVal SUC0 As String, ByVal COD_PER0 As Object, ByVal COD_DOC0 As Object, _
        ByVal FECHA00 As DateTime)
        dgw_doc.Rows.Clear()
        cbo_moneda.SelectedIndex = -1
        txt_ini.Text = "0.00"
        cod_mon0 = ""
        Dim fechaInicio As Date = New Date(FECHA00.AddMonths(-8).Year, FECHA00.AddMonths(-8).Month, 1)
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_REFERENCIA_RET_CXP", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = SUC0
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER0
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            PROG_01.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = fechaInicio
            PROG_01.Parameters.Add("@FECHA_FIN", SqlDbType.DateTime).Value = FECHA00
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While rs3.Read
                dgw_doc.Rows.Add(rs3(0), rs3(1), rs3(2), rs3(3))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_fec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_fec.Click
        If cbo_tipo_ref.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la referencia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_ref.Focus() : Exit Sub
        If txt_nro_ref.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de referencia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ref.Focus() : Exit Sub
        cod_ref = OBJ.COD_DOC(cbo_tipo_ref.Text)
        HALLAR_DATOS_REF(cod_ref, txt_nro_ref.Text, COD_PER, "", COD_SUC)
        If cbo_moneda.SelectedIndex = -1 Then MessageBox.Show("No existe el documento Nº " & txt_nro_ref.Text, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        btn_guardar.Focus()
    End Sub

    Private Sub BTN_AGREGAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_AGREGAR.Click
        Panel1.Visible = True
        txt_ini.Text = txt_doc_total.Text
        '----------------------------------------CARGUE X DEFECTO LOS DATOS
        If txt_ini.Text <> " " Then
            If cbo_tipo_ref.SelectedIndex <> -1 Then
                cod_ref = OBJ.COD_DOC(cbo_tipo_ref.Text)
                If cbo_tipo_ref.Enabled Then
                    CARGAR_DOC_REF(COD_SUC, COD_PER, cod_ref, FECHA0)
                    'HALLAR_DATOS_REF(cod_ref, txt_nro_ref.Text, COD_PER, "", COD_SUC)
                    cbo_tipo_ref.Focus()
                    'Else
                    '    LIMPIAR2()
                End If
            Else
                LIMPIAR2()
                cbo_tipo_ref.Focus()
            End If
        End If
    End Sub

    Sub LIMPIAR2()
        If cbo_tipo_ref.Enabled Then
            cbo_tipo_ref.SelectedIndex = -1
            txt_nro_ref.Clear()
            dgw_doc.Rows.Clear()
        End If
        cbo_moneda.SelectedIndex = -1
        txt_ini.Text = "0.00"
        txt_conv.Text = "0.00"
        txt_ret.Text = "0.00"
        TXT_INI_2DO.Text = "0.00"
        TXT_PDTE.Text = "0.00"
        txt_NroPago.Text = "1"
    End Sub

    Private Sub BTN_ELIMINAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_ELIMINAR.Click
        Try
            Dim i As Integer = DGW_CAB.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el Detalle.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            DGW_CAB.Rows.RemoveAt(DGW_CAB.CurrentRow.Index)
        End If
        HALLAR_TOTAL()
    End Sub

    Sub HALLAR_TOTAL()
        Dim i, cont As Integer
        i = 0 : cont = DGW_CAB.RowCount - 1
        Dim TOTAL0 As Decimal = 0
        Dim TOTAL2 As Decimal = 0
        For i = 0 To cont
            If OBJ.COD_D_H(DGW_CAB.Item(0, i).Value.ToString) = "H" Then
                TOTAL0 = TOTAL0 - DGW_CAB.Item(4, i).Value
                TOTAL2 = TOTAL2 - DGW_CAB.Item(6, i).Value
            Else
                TOTAL0 = TOTAL0 + DGW_CAB.Item(4, i).Value
                TOTAL2 = TOTAL2 + DGW_CAB.Item(6, i).Value
            End If
        Next
        txt_total.Text = TOTAL0
        txt_total.Text = OBJ.HACER_DECIMAL(txt_total.Text)
        '---------------------------------------------------
        txt_total2.Text = TOTAL2
        txt_total2.Text = OBJ.HACER_DECIMAL(txt_total2.Text)
    End Sub

    Sub HALLAR_TOTAL2()
        '-----------------------------------------------------
        RET = OBJ.IMPUESTO("RET")
        If cod_mon0 = "S" Then
            txt_doc_total2.Text = OBJ.HACER_DECIMAL(txt_doc_total.Text * RET / 100)
        Else
            Dim porcentaje As Decimal
            'porcentaje =0.00
            If txt_doc_total.Text <> " " Then
                'porcentaje = OBJ.HACER_DECIMAL(txt_doc_total.Text * RET / 100)
                'txt_doc_total2.Text = porcentaje * TC
                txt_doc_total2.Text = Math.Round(Math.Round(CDec(txt_doc_total.Text) * TC, 2) * (RET / 100), 2)
                txt_doc_total2.Text = OBJ.HACER_DECIMAL(txt_doc_total2.Text)
            End If
        End If
    End Sub

    Private Sub btn_canc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_canc.Click
        Panel1.Visible = False
        BTN_AGREGAR.Focus()
    End Sub

    Private Sub btn_guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_guardar.Click
        If cbo_tipo_ref.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la referencia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_tipo_ref.Focus() : Exit Sub
        If txt_nro_ref.Text.Trim = "" Then MessageBox.Show("Debe ingresar el Nº de referencia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_ref.Focus() : Exit Sub
        If cbo_moneda.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la Moneda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_moneda.Focus() : Exit Sub
        If txt_ini.Text.Trim = "" Or txt_ini.Text = "0.00" Then MessageBox.Show("Debe ingresar el Importe Inicial", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_ini.Focus() : Exit Sub
        cod_mon0 = cbo_moneda.SelectedValue.ToString
        cod_ref = OBJ.COD_DOC(cbo_tipo_ref.Text)
        Dim COD_DH As String
        If cod_ref = "07" Then
            COD_DH = "H"
        Else
            COD_DH = "D"
        End If
        Dim i As Integer
        Dim existe As Boolean = False
        For i = 0 To DGW_CAB.RowCount - 1
            If DGW_CAB.Item(0, i).Value = cod_ref AndAlso DGW_CAB.Item(1, i).Value = txt_nro_ref.Text Then
                existe = True
                MessageBox.Show("El documento de referencia existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit For
            End If
        Next
        If Not existe Then
            DGW_CAB.Rows.Add(cod_ref, txt_nro_ref.Text, dtp_ref.Value.Date, cod_mon0, txt_ini.Text, txt_conv.Text, _
                txt_ret.Text, COD_DH, TXT_INI_2DO.Text, TXT_PDTE.Text, txt_NroPago.Text)
            HALLAR_TOTAL()
            LIMPIAR2()
            cbo_tipo_ref.Focus()
        End If
    End Sub

    Private Sub txt_ini_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ini.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btn_guardar.Focus()
            'btn_fec.Focus()
        End If
    End Sub

    Private Sub txt_ini_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_ini.KeyPress
        e.Handled = Numero(e, txt_ini)
    End Sub

    Private Sub txt_ini_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ini.LostFocus
        If (Strings.Trim(txt_ini.Text) <> "") Then
            Try
                '-----------------------------------------------------
                If txt_ini.Text.Trim = "" Then txt_ini.Text = "0"
                If cod_mon0 = "S" Then
                    txt_conv.Text = txt_ini.Text
                    txt_ret.Text = Math.Round(Decimal.Parse(txt_conv.Text * RET / 100), 2)
                Else
                    txt_conv.Text = Math.Round(Decimal.Parse(txt_ini.Text * TC), 2)
                    Dim porcentaje As Decimal
                    porcentaje = OBJ.HACER_DECIMAL(txt_ini.Text * RET / 100)
                    txt_ret.Text = porcentaje * TC
                End If
                '-----------------------------------------------------
                txt_ini.Text = OBJ.HACER_DECIMAL(txt_ini.Text)
                txt_conv.Text = OBJ.HACER_DECIMAL(txt_conv.Text)
                txt_ret.Text = OBJ.HACER_DECIMAL(txt_ret.Text)
                '-----------------------------------------------------
            Catch ex As Exception
                txt_ini.Text = "0.00"
                txt_conv.Text = "0.00"
                txt_ret.Text = "0.00"
            End Try
        End If
        btn_fec.Focus()

    End Sub

    Function Numero(ByVal e As KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[!0-9.]" Then
            Return True
        End If
        Dim c As Short = 0
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(cajasTexto.Text, ".") > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub cbo_moneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_moneda.SelectedIndexChanged
        If (cbo_moneda.SelectedIndex <> -1) Then
            cod_mon0 = cbo_moneda.SelectedValue.ToString
            '    '-----------------------------------------------------
            If txt_ini.Text.Trim = "" Then txt_ini.Text = "0"
            If cod_mon0 = "S" Then
                txt_conv.Text = txt_ini.Text
                txt_ret.Text = Math.Round(Decimal.Parse(txt_conv.Text * RET / 100), 2)
            Else
                txt_conv.Text = Math.Round(Decimal.Parse(txt_ini.Text * TC), 2)
                Dim porcentaje As Decimal
                'porcentaje = Math.Round(CDec(txt_conv.Text) * (RET / 100), 2) 'OBJ.HACER_DECIMAL(txt_ini.Text * RET / 100)
                txt_ret.Text = Math.Round(CDec(txt_conv.Text) * (RET / 100), 2) 'porcentaje * TC
            End If

            '-----------------------------------------------------
            txt_ini.Text = OBJ.HACER_DECIMAL(txt_ini.Text)
            txt_conv.Text = OBJ.HACER_DECIMAL(txt_conv.Text)
            txt_ret.Text = OBJ.HACER_DECIMAL(txt_ret.Text)
            '-----------------------------------------------------
        End If
    End Sub

    Private Sub cbo_tipo_ref_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_tipo_ref.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_nro_ref.Focus()
        End If
    End Sub

    Private Sub txt_nro_ref_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_nro_ref.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_ini.Focus()
        End If
    End Sub


    Private Sub cbo_tipo_ref_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_ref.SelectionChangeCommitted
        If cbo_tipo_ref.SelectedIndex <> -1 Then
            cod_ref = OBJ.COD_DOC(cbo_tipo_ref.Text)
            If cbo_tipo_ref.Enabled Then
                CARGAR_DOC_REF(COD_SUC, COD_PER, cod_ref, FECHA0)
                'HALLAR_DATOS_REF(cod_ref, txt_nro_ref.Text, COD_PER, "", COD_SUC)
                cbo_tipo_ref.Focus()
            End If
        End If
    End Sub

    Private Sub dgw_doc_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw_doc.CellEnter
        Try
            Dim i As Integer = dgw_doc.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        If (dgw_doc.RowCount = 0 Or con.State = ConnectionState.Open) Then
        Else
            txt_nro_ref.Text = dgw_doc.Item(0, dgw_doc.CurrentRow.Index).Value
            btn_fec_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txt_NroRef_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_NroPago.KeyPress
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class