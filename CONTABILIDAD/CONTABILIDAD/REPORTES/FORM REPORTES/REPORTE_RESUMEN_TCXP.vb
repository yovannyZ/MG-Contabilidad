Imports System.Data.SqlClient
Public Class REPORTE_RESUMEN_TCXP
    Dim MES0 As String
    Dim obj As New Class1
    Dim REP2 As New REP_RESUMEN_TCXP
    Dim SALDOS_IMPORTE As Decimal
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If Trim(txt_cod_cta0.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If (cbo_año.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        Dim COD_PER, STATUS_PER As String
        MES0 = obj.COD_MES(cbo_mes.Text)
        '--------------------------------------------------------------------------------------
        Dim FECHA_CONC As DateTime = DateTime.Parse(("01/" & MES0 & "/" & cbo_año.Text))
        Dim VAR01 As String = MES0
        If ((((VAR01 = "01") OrElse (VAR01 = "03")) OrElse (VAR01 = "05")) OrElse (((VAR01 = "07") OrElse (VAR01 = "08")) OrElse (VAR01 = "10"))) Then
        End If
        If VAR01 = "12" Then
            FECHA_CONC = DateTime.Parse(("31/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
        Else
            If (((VAR01 = "04") OrElse (VAR01 = "06")) OrElse (VAR01 = "09")) Then
            End If
            If VAR01 = "11" <> 0 Then
                FECHA_CONC = DateTime.Parse(("30/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
            ElseIf (VAR01 = "02") Then
                If ((Integer.Parse(cbo_año.Text) Mod 4) = 0) Then
                    FECHA_CONC = DateTime.Parse(("29/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                Else
                    FECHA_CONC = DateTime.Parse(("28/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                End If
            End If
        End If
        REP2.CREAR_REPORTE(cbo_mes.Text, txt_desc_cta0.Text, txt_cod_cta0.Text, cbo_año.Text, MES0, "0", FECHA_CONC, "P")
        REP2.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(117) = 0
        Close()
    End Sub

    Sub CUENTAS()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_STATUS_TIPO(AÑO, "P")
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns(2).Visible = False
            dgw_cta.Columns(3).Visible = False
            dgw_cta.Columns(4).Visible = False
            dgw_cta.Columns(0).Width = 80
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dgw_cta_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta.KeyDown
        If (e.KeyData = Keys.Return) Then
            If ((dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value).Length <> 8) Then
                MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_cod_cta0.Clear()
                txt_desc_cta0.Clear()
            Else
                txt_cod_cta0.Text = (dgw_cta.Item(0, dgw_cta.CurrentRow.Index).Value)
                txt_desc_cta0.Text = (dgw_cta.Item(1, dgw_cta.CurrentRow.Index).Value)
                PaneL_CTA.Visible = False
                KL.Focus()
            End If
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_cta0.Clear()
            txt_desc_cta0.Clear()
            PaneL_CTA.Visible = False
            txt_cod_cta0.Focus()
        End If
    End Sub

    Private Sub REPORTE_ANALISIS_TCXP_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_ANALISIS_TCXP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CUENTAS()
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Text = (obj.DESC_MES(MES))
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub SALDOS()
        Try
            Dim cmd As New SqlCommand("HALLAR_MAESTRO_SALDOS", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = txt_cod_cta0.Text
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES2", SqlDbType.Char).Value = MES0
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                SALDOS_IMPORTE = Decimal.Parse(dr.GetValue(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_cta0.Text.ToLower = dgw_cta.Item(0, i).Value.ToString.ToLower) Then
                        If (dgw_cta.Item(0, i).Value.ToString.Length <> 8) Then
                            MessageBox.Show("El Cuenta debe ser de Nivel 3", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            txt_cod_cta0.Clear()
                            txt_desc_cta0.Clear()
                            txt_cod_cta0.Focus()
                        Else
                            txt_cod_cta0.Text = dgw_cta.Item(0, i).Value.ToString
                            txt_desc_cta0.Text = dgw_cta.Item(1, i).Value.ToString
                        End If
                        Return
                    End If
                    If (txt_cod_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(0, i).Value), 1, Strings.Len(txt_cod_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
                dgw_cta.Focus()
            End If
        End If
    End Sub

    Private Sub txt_desc_cta0_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_cta0.KeyDown
        If (e.KeyCode = Keys.Return) Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Conceptos para Egresos", "Falta Conceptos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_desc_cta0.Text.ToLower = Strings.Mid((dgw_cta.Item(1, i).Value), 1, Strings.Len(txt_desc_cta0.Text)).ToLower) Then
                        dgw_cta.CurrentCell = dgw_cta.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta.CurrentCell = dgw_cta.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PaneL_CTA.Visible = True
            End If
        End If
    End Sub
End Class