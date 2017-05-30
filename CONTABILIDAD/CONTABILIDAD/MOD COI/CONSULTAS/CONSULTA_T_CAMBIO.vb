Imports System.Data.SqlClient
Public Class CONSULTA_T_CAMBIO
    Private año2, dia2, mes5, mes2, año5, boton, COD_MES2, cod_tipo As String
    Private k As Double
    Private obj As New Class1
    Dim RP As New REP_TC_CONSULTA
   Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(137) = 0
        Close()
    End Sub
   Private Sub Cambio_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Cambio_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        mes5 = FECHA_INI.ToString("MM")
        año5 = FECHA_INI.Year
        cbo_año.Text = FECHA_INI.Year
        cbo_mes.Text = FECHA_INI.ToString("MM")
        HALLAR_CIERRE(cbo_año.Text, cbo_mes.Text)
        Dim FEC As DateTime = DateTime.Parse(("01/" & FECHA_INI.ToString("MM") & "/" & (FECHA_INI.Year)))
    End Sub
   Private Sub cbo_año_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_año.SelectedIndexChanged
        If (cbo_año.SelectedIndex <> -1) Then
            año5 = (cbo_año.SelectedItem)
            datagrid()
            If (dgw1.RowCount = 0) Then
                MessageBox.Show("No existen registros de tipo de cambio para ese año y mes", "No existen registro:", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
        If (cbo_año.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1) Then
            COD_MES2 = cbo_mes.Text
            HALLAR_CIERRE(cbo_año.Text, COD_MES2)
        End If
    End Sub
   Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_mes.SelectedIndexChanged
        If (cbo_año.SelectedIndex <> -1) Then
            mes5 = cbo_mes.Text
            datagrid()
            If (dgw1.RowCount = 0) Then
                MessageBox.Show("No existen registros de tipo de cambio para ese año y mes", "No existen registros:", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End If
        End If
        If ((cbo_año.SelectedIndex <> -1) And (cbo_mes.SelectedIndex <> -1)) Then
            COD_MES2 = cbo_mes.Text
            HALLAR_CIERRE(cbo_año.Text, COD_MES2)
        End If
    End Sub
   Sub datagrid()
        Try
            Dim pro As New SqlCommand("Mostrar_cambio", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@año", SqlDbType.Char).Value = año5
            pro.Parameters.Add("@mes", SqlDbType.Char).Value = mes5
            Dim Prog00 As New SqlDataAdapter(pro)
            Dim dt As New DataTable("Cuentas")
            Prog00.Fill(dt)
            dgw1.DataSource = dt
            dgw1.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
            dgw1.Columns.Item(1).Visible = False
            dgw1.Columns.Item(5).Visible = False
            dgw1.Columns.Item(6).Visible = False
            dgw1.Columns.Item(0).Width = 40
            dgw1.Columns.Item(2).Width = 140
            dgw1.Columns.Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgw1.Columns.Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
   Sub HALLAR_CIERRE(ByVal AÑO0 As Object, ByVal MES0 As Object)
        txt_venta2.Text = "0.0000"
        txt_compra2.Text = "0.0000"
        Try
            Dim PROG_01 As New SqlCommand("HALLAR_CAMBIO_MENSUAL", con2)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (AÑO0)
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = (MES0)
            PROG_01.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = "D"
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                txt_venta2.Text = (Rs3.GetValue(0))
                txt_compra2.Text = Rs3.GetValue(1)
            Loop
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
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
   Private Sub txt_compra2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = Numero(e, txt_compra2)
    End Sub
    Private Sub txt_compra2_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        If (txt_compra2.Text <> "") Then
            Try
                txt_compra2.Text = (obj.HACER_CAMBIO(txt_compra2.Text))
            Catch ex As Exception
                MessageBox.Show("El tipo de Compra no es valido", "Ingrese otra vez")
                txt_compra2.Text = "0.0000"
            End Try
        End If
    End Sub
   Private Sub txt_venta2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        e.Handled = Numero(e, txt_venta2)
    End Sub
    Private Sub txt_venta2_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        If (txt_venta2.Text <> "") Then
            Try
                txt_venta2.Text = (obj.HACER_CAMBIO(txt_venta2.Text))
            Catch ex As Exception
                MessageBox.Show("El tipo de Venta no es valido", "Ingrese otra vez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txt_venta2.Text = "0.0000"
            End Try
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LLENAR_DATASET()
        RP.CREAR_REPORTE(obj.DESC_MES(cbo_mes.Text), cbo_año.Text, txt_compra2.Text, txt_venta2.Text)
        RP.ShowDialog()
    End Sub
    Sub LLENAR_DATASET()
        RP.LIMPIAR()
        Dim num2 As Integer = 0
        Dim num As Integer = (dgw1.Rows.Count - 1)
        Dim num8 As Integer = num
        num2 = 0
        Do While (num2 <= num8)

            RP.llenar_dt(dgw1.Item(0, num2).Value, dgw1.Item(1, num2).Value, dgw1.Item(2, num2).Value, dgw1.Item(3, num2).Value, dgw1.Item(4, num2).Value)

            num2 += 1
        Loop
    End Sub
End Class