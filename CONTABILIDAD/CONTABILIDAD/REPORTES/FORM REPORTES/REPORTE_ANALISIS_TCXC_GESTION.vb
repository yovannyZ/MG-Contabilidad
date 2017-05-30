Imports System.Data.SqlClient
Public Class REPORTE_ANALISIS_TCXC_GESTION
    Private MES0 As String
    Private obj As New Class1
    Private REP As New REP_PENDIENTE_CXC_GESTION
    Private SALDOS_IMPORTE As Decimal

    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If (cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_mes.Focus()
        ElseIf (CH_PER.Checked And (txt_cod_per.Text = "")) Then
            MessageBox.Show("Debe insertar el código de persona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_per.Focus()
        ElseIf (Strings.Trim(txt_cod_cta0.Text) = "") Then
            MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_cod_cta0.Focus()
        ElseIf (cbo_año.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_año.Focus()
        Else
            Dim COD_PER As String
            Dim STATUS_PER As String
            If CH_PER.Checked = False Then
                STATUS_PER = "1"
                COD_PER = " "
            Else
                STATUS_PER = "0"
                COD_PER = txt_cod_per.Text
            End If
            MES0 = (obj.COD_MES(cbo_mes.Text))
            Dim FECHA_CONC As DateTime
            If MES0 <> "00" Then
                FECHA_CONC = DateTime.Parse(("01/" & MES0 & "/" & cbo_año.Text))
            End If
            Dim CONT0 As String = MES0
            If ((((CONT0 = "01") Or (CONT0 = "03")) Or (CONT0 = "05")) Or (((CONT0 = "07") Or (CONT0 = "08")) Or (CONT0 = "10"))) Then
            End If
            If CONT0 = "12" Then
                FECHA_CONC = DateTime.Parse(("31/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
            Else
                If (((CONT0 = "04") OrElse (CONT0 = "06")) OrElse (CONT0 = "09")) Then
                End If
                If CONT0 = "11" Then
                    FECHA_CONC = DateTime.Parse(("30/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                ElseIf (CONT0 = "02") Then
                    If ((Integer.Parse(cbo_año.Text) Mod 4) = 0) Then
                        FECHA_CONC = DateTime.Parse(("29/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                    Else
                        FECHA_CONC = DateTime.Parse(("28/" & FECHA_CONC.ToString("MM") & "/" & FECHA_CONC.Year.ToString))
                    End If
                End If
            End If
            If MES0 = "00" Then
                FECHA_CONC = DateTime.Parse(("12/12/" & (cbo_año.Text - 1)))
            End If
            SALDOS()
            REP.CREAR_REPORTE(cbo_mes.Text, txt_desc_cta0.Text, txt_cod_cta0.Text, cbo_año.Text, MES0, "0", COD_PER, STATUS_PER, FECHA_CONC)
            REP.ShowDialog()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(122) = 0
        Close()
    End Sub

    Private Sub CH_PER_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CH_PER.CheckedChanged
        If CH_PER.Checked Then
            txt_cod_per.ReadOnly = False
            txt_desc_per.ReadOnly = False
            txt_doc_per.ReadOnly = False
        Else
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            txt_cod_per.ReadOnly = True
            txt_desc_per.ReadOnly = True
            txt_doc_per.ReadOnly = True
        End If
    End Sub

    Public Sub CUENTAS()
        Try
            Dim DT As New DataTable
            DT = obj.MOSTRAR_CUENTAS_STATUS_TIPO(AÑO, "C")
            dgw_cta.DataSource = DT
            dgw_cta.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_cta.Columns.Item(2).Visible = False
            dgw_cta.Columns.Item(3).Visible = False
            dgw_cta.Columns.Item(4).Visible = False
            dgw_cta.Columns.Item(0).Width = 80
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

    Private Sub dgw_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_per.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cod_per.Text = (dgw_per.Item(0, dgw_per.CurrentRow.Index).Value)
            txt_desc_per.Text = (dgw_per.Item(1, dgw_per.CurrentRow.Index).Value)
            txt_doc_per.Text = (dgw_per.Item(2, dgw_per.CurrentRow.Index).Value)
            Panel_per.Visible = False
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cod_per.Clear()
            txt_desc_per.Clear()
            txt_doc_per.Clear()
            Panel_per.Visible = False
            txt_cod_per.Focus()
        End If
    End Sub

    Public Sub PERSONAS()
        Try
            dgw_per.DataSource = obj.MOSTRAR_PERSONAS_COBRAR
            dgw_per.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw_per.Columns.Item(0).Width = 50
            dgw_per.Columns.Item(1).Width = &HEB
        Catch ex As Exception


            MsgBox(ex.Message)
            MessageBox.Show("Ocurrió un Error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
    End Sub

    Private Sub REPORTE_ANALISIS_TCXP_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub REPORTE_ANALISIS_TCXP_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CUENTAS()
        PERSONAS()
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Text = obj.DESC_MES(MES)
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
                Me.cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub SALDOS()
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

    Private Sub txt_cod_per_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_per.LostFocus
        If (Strings.Trim(txt_cod_per.Text) <> "") Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                dgw_per.Sort(dgw_per.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_cod_per.Text.ToLower = dgw_per.Item(0, i).Value.ToString.ToLower) Then
                        txt_cod_per.Text = dgw_per.Item(0, i).Value.ToString
                        txt_desc_per.Text = dgw_per.Item(1, i).Value.ToString
                        txt_doc_per.Text = dgw_per.Item(2, i).Value.ToString
                        Return
                    End If
                    If (txt_cod_per.Text.ToLower = Strings.Mid((dgw_per.Item(0, i).Value), 1, Strings.Len(txt_cod_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
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
    Private Sub txt_desc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_desc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_desc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla pendientes por cobrar", "Mensaje")
            Else
                dgw_per.Sort(dgw_per.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_desc_per.Text.ToLower = Strings.Mid((dgw_per.Item(1, i).Value), 1, Strings.Len(txt_desc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
    Private Sub txt_doc_per_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_doc_per.KeyDown
        If ((e.KeyData = Keys.Return) AndAlso (Strings.Trim(txt_doc_per.Text) <> "")) Then
            If (dgw_per.RowCount = 0) Then
                MessageBox.Show("No existen personas en la tabla maestro de personas", "Mensaje")
            Else
                dgw_per.Sort(dgw_per.Columns.Item(2), System.ComponentModel.ListSortDirection.Ascending)
                Dim VAR0 As Integer = (dgw_per.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= VAR0)
                    If (txt_doc_per.Text.ToLower = Strings.Mid((dgw_per.Item(2, i).Value), 1, Strings.Len(txt_doc_per.Text)).ToLower) Then
                        dgw_per.CurrentCell = dgw_per.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    i += 1
                Loop
                Panel_per.Visible = True
                dgw_per.Focus()
            End If
        End If
    End Sub
End Class