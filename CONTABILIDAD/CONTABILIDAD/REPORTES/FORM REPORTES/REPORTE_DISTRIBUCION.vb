Imports System.Data.SqlClient
Public Class REPORTE_DISTRIBUCION
    Private OFR As New REP_DISTRIBUCION
    Dim obj As New Class1

    Private Sub REPORTE_DISTRIBUCION_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Return Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub REPORTE_DISTRIBUCION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_NEGOCIO()
        CARGAR_CENTRO_COSTOS()
        CargarAño()
    End Sub
    Private Sub CargarAño()
        cboAñoCosto.Items.Clear()
        cboAñoNegocio.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cboAñoCosto.Items.Add(Rs3.GetString(0))
                cboAñoNegocio.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub CARGAR_CENTRO_COSTOS()
        Try
            Dim pro_02 As New SqlCommand("MOSTRAR_AREA2", con)
            pro_02.CommandType = CommandType.StoredProcedure
            Dim Prog02 As New SqlDataAdapter(pro_02)
            Dim dt_02 As New DataTable("Origen")
            Prog02.Fill(dt_02)
            dgwArea.DataSource = dt_02
            dgwArea.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CARGAR_NEGOCIO()
        Try
            Dim Cmd As New SqlCommand("MOSTRAR_DIRECTORIO_DATO", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = "TNEGO"
            Dim da As New SqlDataAdapter(Cmd)
            Dim dt As New DataTable("Negocio")
            da.Fill(dt)
            cboNegocio.DataSource = dt
            cboNegocio.DisplayMember = dt.Columns.Item(1).ToString
            cboNegocio.ValueMember = dt.Columns.Item(0).ToString
            cboNegocio.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If (chkNegocio.Checked AndAlso cboNegocio.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Negocio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboNegocio.Focus()
        Else
            'OFR.TIPOK = "01"
            'OFR.UBICAR_REPORTE()
            'NIVEL = OBJ.COD_NIVEL(cbo_nivel.Text)
            Dim STNEG As String = "0"
            If chkNegocio.Checked Then
                STNEG = "1"
            End If
            Dim codneg As String = cboNegocio.SelectedValue
            OFR.FICHA = "0"
            OFR.VISUALIZAR_REPORTVIEWER()
            OFR.CREAR_REPORTE(STNEG, codneg, "", "", cboAñoNegocio.Text, obj.COD_MES(cboMesNegocio.Text))
            OFR.ShowDialog()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        main(156) = 0
        Close()
    End Sub

    Private Sub chkNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNegocio.CheckedChanged
        If chkNegocio.Checked Then cboNegocio.Enabled = True Else cboNegocio.Enabled = False : cboNegocio.SelectedIndex = -1
    End Sub
    Private Sub chkCentroCostos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCentroCostos.CheckedChanged
        txtCodArea.Enabled = chkCentroCostos.Checked
        txtArea.Enabled = chkCentroCostos.Checked
        txtCodArea.Clear()
        txtArea.Clear()
    End Sub
    Private Sub btnpantalla2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpantalla2.Click
        If chkCentroCostos.Checked And txtCodArea.Text = "" Then MessageBox.Show("Debe seleccionar un Centro de Costos", "Information", MessageBoxButtons.OK) : txtCodArea.Focus() : Exit Sub

        Dim STCC As String = "0"
        If chkCentroCostos.Checked Then
            STCC = "1"
        End If
        Dim CODCC As String = txtCodArea.Text
        OFR.FICHA = "1"
        OFR.VISUALIZAR_REPORTVIEWER()
        OFR.CREAR_REPORTE("", "", STCC, CODCC, cboAñoCosto.Text, obj.COD_MES(cboMesCosto.Text))
        OFR.ShowDialog()
    End Sub

    Private Sub txtCodArea_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodArea.LostFocus
        If (Strings.Trim(txtCodArea.Text) <> "") Then
            If (dgwArea.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgwArea.Sort(dgwArea.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgwArea.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtCodArea.Text.ToLower = dgwArea.Item(0, i).Value.ToString.ToLower) Then
                        txtCodArea.Text = dgwArea.Item(0, i).Value.ToString
                        txtArea.Text = dgwArea.Item(1, i).Value.ToString
                        Label6.Focus()
                        Return
                    End If
                    If (txtCodArea.Text.ToLower = Strings.Mid((dgwArea.Item(0, i).Value), 1, Strings.Len(txtCodArea.Text)).ToLower) Then
                        dgwArea.CurrentCell = dgwArea.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgwArea.CurrentCell = dgwArea.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PanelArea.Visible = True
                dgwArea.Focus()
            End If
        End If
    End Sub

    Private Sub txtArea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArea.KeyDown
        If ((Strings.Trim(txtArea.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgwArea.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgwArea.Sort(dgwArea.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgwArea.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txtArea.Text.ToLower = Strings.Mid((dgwArea.Item(1, i).Value), 1, Strings.Len(txtArea.Text)).ToLower) Then
                        dgwArea.CurrentCell = dgwArea.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgwArea.CurrentCell = dgwArea.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                PanelArea.Visible = True
                dgwArea.Focus()
            End If
        End If
    End Sub

    Private Sub dgwArea_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgwArea.KeyDown
        If (e.KeyData = Keys.Return) Then
            txtCodArea.Text = (dgwArea.Item(0, dgwArea.CurrentRow.Index).Value)
            txtArea.Text = (dgwArea.Item(1, dgwArea.CurrentRow.Index).Value)
            PanelArea.Visible = False
            Label6.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txtCodArea.Clear()
            txtArea.Clear()
            PanelArea.Visible = False
            txtCodArea.Focus()
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        main(156) = 0
        Close()
    End Sub
End Class