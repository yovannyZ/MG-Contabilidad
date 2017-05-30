Public Class FrmReporteConciliadasCXCSinCuadre
    Dim obj As New Class1
    Dim MES0, HOJA As String
    Dim REP1 As New FrmConciliadasCXCSincuadreViewer

    Private Shared _instancia As FrmReporteConciliadasCXCSinCuadre

    Public Shared Function ObtenerInstancia() As FrmReporteConciliadasCXCSinCuadre
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New FrmReporteConciliadasCXCSinCuadre
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Sub FrmReporteConciliadasCXCSinCuadre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarCuentas()
        CargarAño()
        cbo_año.Text = AÑO
        cbo_mes.Text = obj.DESC_MES(MES)
    End Sub

    Sub CargarCuentas()
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

    Sub CargarAño()
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

    Private Sub dgw_cta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgw_cta.KeyDown
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

    Private Sub txt_cod_cta0_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cod_cta0.LostFocus
        If (Strings.Trim(txt_cod_cta0.Text) <> "") Then
            If (dgw_cta.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Falta Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
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
                MessageBox.Show("No existen cuentas", "Faltan cuentas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta.Sort(dgw_cta.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT0 As Integer = (dgw_cta.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT0)
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

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If (Strings.Trim(txt_cod_cta0.Text) = "") Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cod_cta0.Focus() : Exit Sub
        If (cbo_año.SelectedIndex = -1) Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub


        Dim COD_PER As String = " "
        Dim STATUS_PER As String = "1"
     
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
        REP1.LIMPIAR()
        LlenarDataTable(MES0, "1", COD_PER, STATUS_PER, FECHA_CONC, txt_cod_cta0.Text)

        REP1.CREAR_REPORTE(cbo_mes.Text, txt_cod_cta0.Text, txt_desc_cta0.Text, cbo_año.Text, "CUENTAS POR COBRAR - CUADRE")
        REP1.ShowDialog()
        
    End Sub

    Private Sub LlenarDataTable(ByVal mes As String, ByVal statusCon As String, ByVal codPer As String, ByVal statusPer As String, ByVal fechaConcili As Date, ByVal codcuenta As String)
        Try

            Dim cmd As New SqlCommand("REPORTE_CONCILIADAS_CXC_SIN_CUADRAR", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = codcuenta
            cmd.Parameters.Add("@STATUS_CONCILIADO", SqlDbType.Char).Value = statusCon
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codPer
            cmd.Parameters.Add("@S_PER", SqlDbType.Char).Value = statusPer
            cmd.Parameters.Add("@FECHA_CONC", SqlDbType.Date).Value = fechaConcili
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                REP1.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr(10), dr(11), _
                 dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), dr(19))
            End While
        Catch ex As Exception
            MessageBox.Show(String.Format("Error: {0}{1}", vbCrLf, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub FrmReporteConciliadasCXCSinCuadre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
End Class