Imports System.Data.SqlClient
Public Class CONSULTA_CIERRE_TEMPORAL
    Public año0, mes0 As String
    Public HOY As Date
    Public tip_camb As Decimal
    Dim OBJ As New Class1
    Private Sub DGW_CAB_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DGW_CAB.CellEnter
        If (con.State <> ConnectionState.Open) And DGW_CAB.RowCount > 0 Then
            If tip_camb = "0.000" Or tip_camb = 0 Then
                MessageBox.Show("Necesita actualizar el tipo de cambio", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            Else
                CARGAR_DETALLES()
            End If
        End If
    End Sub
    Public Sub CARGAR_DETALLES()
        dgw_det.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("TEMPORAL_CUENTA_CIERRE", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes0
            PROG_01.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = tip_camb
            PROG_01.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = HOY
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = DGW_CAB.Item(2, DGW_CAB.CurrentRow.Index).Value
            PROG_01.Parameters.Add("@NRO_SEC", SqlDbType.Char).Value = DGW_CAB.Item(0, DGW_CAB.CurrentRow.Index).Value
            PROG_01.Parameters.Add("@GLOSA", SqlDbType.Char).Value = DGW_CAB.Item(1, DGW_CAB.CurrentRow.Index).Value
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw_det.Rows.Add(Rs3.GetValue(0), Rs3.GetValue(1), Math.Round(Rs3.GetValue(2), 2), Math.Round(Rs3.GetValue(3), 2), Rs3.GetValue(4), _
                Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), _
                Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), _
                Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), _
                Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), _
                Rs3.GetValue(28), Rs3.GetValue(29)) ', Rs3.GetValue(30))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_ACEPTAR.Click
        ULTIMO_REGISTRO()
        DialogResult = Windows.Forms.DialogResult.OK
        Hide()
    End Sub
    Sub ULTIMO_REGISTRO()
        Dim CONT As Integer = dgw_det.Rows.Count - 1
        Dim I As Integer = 0
        Dim DEBE_S = 0, DEBE_D = 0, HABER_S = 0, HABER_D = 0, TOTAL_S, TOTAL_D As Decimal
        While I <= CONT
            If dgw_det.Item(4, I).Value = "D" Then
                DEBE_S = dgw_det.Item(2, I).Value + DEBE_S
                DEBE_D = dgw_det.Item(3, I).Value + DEBE_D
            Else
                HABER_S = dgw_det.Item(2, I).Value + HABER_S
                HABER_D = dgw_det.Item(3, I).Value + HABER_D
            End If
            I += 1
        End While
        TOTAL_S = DEBE_S - HABER_S
        TOTAL_D = DEBE_D - HABER_D
        If TOTAL_S < 0 Then TOTAL_S = TOTAL_S * -1
        If TOTAL_D < 0 Then TOTAL_D = TOTAL_D * -1
        If TOTAL_S <> 0 Then
            If DEBE_S > HABER_S Then
                dgw_det.Rows.Add(DGW_CAB.Item(2, DGW_CAB.CurrentRow.Index).Value, DGW_CAB.Item(1, DGW_CAB.CurrentRow.Index).Value, TOTAL_S, TOTAL_D, "H", "S", tip_camb, "00", "APERTURA1", HOY, "", "", "", "", "", "", "", "", "0", "0", "0", "0", "0", "", "", "", "", HOY, "", "")
            Else
                dgw_det.Rows.Add(DGW_CAB.Item(2, DGW_CAB.CurrentRow.Index).Value, DGW_CAB.Item(1, DGW_CAB.CurrentRow.Index).Value, TOTAL_S, TOTAL_D, "D", "S", tip_camb, "00", "APERTURA1", HOY, "", "", "", "", "", "", "", "", "0", "0", "0", "0", "0", "", "", "", "", HOY, "", "")
            End If
        End If
    End Sub
    Private Sub CONSULTA_REQ_ORD_PROD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mes0 = MES
        tip_camb = SACAR_CAMBIO_MENSUAL(AÑO, MES, "D", "V")
        DGW_CAB.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
        CARGAR_CIERRE_CUENTA()
        'CARGAR_AÑO()
        'cbo_año.Text = AÑO
        'cbo_mes.Text = OBJ.DESC_MESMES
    End Sub
    Private Function SACAR_CAMBIO_MENSUAL(ByVal AÑO00 As Object, ByVal MES00 As Object, ByVal TIPO00 As Object, ByVal CV00 As String) As String
        If MES00 = "12" Or MES00 = "13" Then MES00 = "12"
        Dim cambio As String = ""
        Try
            Dim prog As New SqlCommand("SACAR_CAMBIO_MENSUAL", con2)
            prog.CommandType = CommandType.StoredProcedure
            prog.Parameters.Add("@año", SqlDbType.VarChar).Value = (AÑO00)
            prog.Parameters.Add("@mes", SqlDbType.VarChar).Value = (MES00)
            prog.Parameters.Add("@tipo", SqlDbType.VarChar).Value = (TIPO00)
            prog.Parameters.Add("@C_V", SqlDbType.VarChar).Value = (CV00)
            con2.Open()
            cambio = prog.ExecuteScalar
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
        Return cambio
    End Function
    Sub CARGAR_CIERRE_CUENTA()
        Dim CMD As New SqlCommand("MANT_CUENTA_CIERRE", con)
        CMD.CommandType = CommandType.StoredProcedure
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        Dim ADAP As New SqlDataAdapter(CMD)
        Dim DT As New DataTable("CUENTA_CIERRE")
        ADAP.Fill(DT)
        DGW_CAB.DataSource = (DT)
        DGW_CAB.Columns.Item(0).Width = 40
        DGW_CAB.Columns.Item(0).HeaderText = "Sec."
        DGW_CAB.Columns.Item(1).Width = 310
        DGW_CAB.Columns.Item(2).Width = 60
        DGW_CAB.Columns.Item(2).HeaderText = "Cuenta"
        DGW_CAB.Columns.Item(3).Visible = False
        DGW_CAB.Columns.Item(4).Visible = False
        'Dim colcheckBox As New DataGridViewCheckBoxColumn
        'colcheckBox.Name = "OK"
        'colcheckBox.Width = 30
        'DGW_CAB.Columns.Insert(5, colcheckBox)
        DGW_CAB.ColumnHeadersDefaultCellStyle.Font = (New Font("ARIAL", 8.0!, FontStyle.Bold))
    End Sub
    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Hide()
    End Sub
    Sub MOSTRAR_I_CON()
        DGW_CAB.Rows.Clear()
        Try
            Dim Prog002 As New SqlCommand("MOSTRAR_ICON_DIARIO", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año0
            Prog002.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes0
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                DGW_CAB.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class