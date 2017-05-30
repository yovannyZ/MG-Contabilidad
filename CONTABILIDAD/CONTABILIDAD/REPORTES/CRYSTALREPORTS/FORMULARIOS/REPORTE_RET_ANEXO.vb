Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class REPORTE_RET_ANEXO
    Dim OBJ As New Class1
    Dim COD_MES As String
    Dim REP As New REP_RET_ANEXO
    Dim reporte As New ANEXO_RETENCION
    Private Sub REPORTE_RET_ANEXO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_RET_ANEXO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        KeyPreview = True
        dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8, FontStyle.Bold)
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        main(29) = 0
        Me.Close()
    End Sub

    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        COD_MES = OBJ.COD_MES(cbo_mes.Text)
        CARGAR_RETENCIONES_CABACERA()
    End Sub
    Sub CARGAR_RETENCIONES_CABACERA()
        Try
            Dim CMD As New SqlCommand("REPORTE_MOSTRAR_I_RET", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES
            Dim ADAP As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("SD")
            ADAP.Fill(DT)
            dgw1.DataSource = DT
            dgw1.Columns(0).Width = 90
            dgw1.Columns(1).Width = 70
            dgw1.Columns(2).Width = 60
            dgw1.Columns(3).Width = 220
            dgw1.Columns(4).Width = 100
            dgw1.Columns(5).Width = 32
            dgw1.Columns(6).Width = 35
            dgw1.Columns(7).Width = 40
            dgw1.Columns(8).Width = 70
            dgw1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgw1.Columns(1).DefaultCellStyle.Format = "d"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        impresion_horizontal()
        REP.CrystalReportViewer1.ReportSource = reporte
        REP.ShowDialog()
    End Sub
    Sub impresion_horizontal()
        Dim dt As New DT_REP_RET_ANEXO
        Dim I, cont As Integer
        cont = dgw1.Rows.Count - 1
        For I = 0 To cont
            If dgw1.Item(5, I).Value = True Then
                Try
                    Dim PROG_01 As New SqlCommand("REPORTE_MOSTRAR_T_RET", con)
                    PROG_01.CommandType = CommandType.StoredProcedure
                    PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                    PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = COD_MES
                    PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = dgw1.Item(6, I).Value
                    PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = dgw1.Item(7, I).Value
                    PROG_01.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = dgw1.Item(8, I).Value
                    con.Open()
                    PROG_01.ExecuteNonQuery()
                    Dim Rs3 As SqlDataReader
                    Rs3 = PROG_01.ExecuteReader
                    'Dim COD_D_H As String
                    'Dim IMPORTE, IMP_D, IMP_H As Decimal
                    While Rs3.Read
                        '---------------HALLANDO SERIE Y NUMERO CORRELATIVO DEL DOC -----------------
                        Dim SERIE, CORRELATIVO, NUMERO_COMPLETO, GUION As String
                        Dim TAMAÑO As Integer
                        NUMERO_COMPLETO = Rs3.GetValue(1)
                        TAMAÑO = NUMERO_COMPLETO.Length
                        GUION = NUMERO_COMPLETO.LastIndexOf("-")
                        SERIE = NUMERO_COMPLETO.Substring(0, GUION)
                        CORRELATIVO = NUMERO_COMPLETO.Substring((GUION + 1), (TAMAÑO - GUION - 1))
                        '-------------------------------------------------------------------
                        '---------------HALLANDO SERIE Y NUMERO CORRELATIVO REFERENCIA -----------------
                        Dim SERIE2, CORRELATIVO2, NUMERO_COMPLETO2, GUION2 As String
                        Dim TAMAÑO2 As Integer
                        NUMERO_COMPLETO2 = Rs3.GetValue(3)
                        TAMAÑO2 = NUMERO_COMPLETO2.Length
                        GUION2 = NUMERO_COMPLETO2.LastIndexOf("-")
                        SERIE2 = NUMERO_COMPLETO2.Substring(0, GUION)
                        CORRELATIVO2 = NUMERO_COMPLETO2.Substring((GUION2 + 1), (TAMAÑO2 - GUION2 - 1))
                        '-------------------------------------------------------------------
                        dt.DataTable1.Rows.Add((Rs3.GetValue(0)), SERIE, Rs3.GetValue(1), Rs3.GetValue(2), SERIE2, Rs3.GetValue(3), Rs3.GetValue(4).ToString.Substring(0, 10), Rs3.GetValue(5), Rs3.GetValue(10), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(12), Rs3.GetValue(11), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16).ToString.Substring(0, 10), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19))
                    End While
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MessageBox.Show(ex.Message)
                End Try
            End If
        Next
        reporte.SetDataSource(dt)
        Dim Params As New ParameterValues
        Dim Par As New ParameterDiscreteValue
        Params.Clear()
        Par.Value = DESC_EMPRESA
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("EMPRESA").ApplyCurrentValues(Params)
        '======================================================================================
        Params.Clear()
        Par.Value = RUC_EMPRESA
        Params.Add(Par)
        reporte.DataDefinition.ParameterFields("RUC").ApplyCurrentValues(Params)
        ''======================================================================================
        'Params.Clear()
        'Par.Value = cbo_auxiliar.Text
        'Params.Add(Par)
        'reporte2.DataDefinition.ParameterFields("AUXILIAR").ApplyCurrentValues(Params)
        'reporte.PrintToPrinter(1, False, 0, 0)
    End Sub
End Class