Imports System.Data.SqlClient
Public Class INICIO_COI
    Private obj As New Class1

    Private Sub btn_aceptar1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar1.Click
        If (Me.cbo_a�o.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el A�o", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbo_a�o.Focus()
        ElseIf (Me.cbo_mes.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cbo_mes.Focus()
        Else
            A�O = Me.cbo_a�o.Text
            MES = (Me.obj.COD_MES(Me.cbo_mes.Text))
            If (MES = "00") Then
                FECHA_INI = Date.Parse(("01/01/" & A�O))
            ElseIf (MES = "13") Then
                FECHA_INI = Date.Parse(("01/12/" & A�O))
            Else
                FECHA_INI = Date.Parse(("01/" & MES & "/" & A�O))
            End If
            Select Case MES
                Case "00"
                    FECHA_GRAL = Date.Parse(("31/01/" & A�O))

                Case "01"
                    FECHA_GRAL = Date.Parse(("31/" & MES & "/" & A�O))

                Case "02"
                    If DateTime.IsLeapYear(A�O) Then
                        FECHA_GRAL = Date.Parse(("29/" & MES & "/" & A�O))
                    Else
                        FECHA_GRAL = Date.Parse(("28/" & MES & "/" & A�O))
                    End If

                Case "03"
                    FECHA_GRAL = Date.Parse(("31/" & MES & "/" & A�O))

                Case "04"
                    FECHA_GRAL = Date.Parse(("30/" & MES & "/" & A�O))

                Case "05"
                    FECHA_GRAL = Date.Parse(("31/" & MES & "/" & A�O))

                Case "06"
                    FECHA_GRAL = Date.Parse(("30/" & MES & "/" & A�O))

                Case "07"
                    FECHA_GRAL = Date.Parse(("31/" & MES & "/" & A�O))

                Case "08"
                    FECHA_GRAL = Date.Parse(("31/" & MES & "/" & A�O))

                Case "09"
                    FECHA_GRAL = Date.Parse(("30/" & MES & "/" & A�O))

                Case "10"
                    FECHA_GRAL = Date.Parse(("31/" & MES & "/" & A�O))

                Case "11"
                    FECHA_GRAL = Date.Parse(("30/" & MES & "/" & A�O))

                Case "12"
                    FECHA_GRAL = Date.Parse(("31/" & MES & "/" & A�O))

                Case "13"
                    FECHA_GRAL = Date.Parse(("31/12/" & A�O))

            End Select
            Me.Close()
            My.Forms.MOD_CONTABILIDAD.Text = "Modulo de Contabilidad" '  Empresa : " & DESC_EMPRESA & "                                  Proceso   : " & (FECHA_GRAL))
            My.Forms.MOD_CONTABILIDAD.Show()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Me.Hide()
        My.Forms.Iconos.Show()
    End Sub

    Sub CARGAR_A�O()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_A�O", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Me.cbo_a�o.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

  

    Private Sub INICIO_COI_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub INICIO_COI_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Me.KeyPreview = True
        Me.CARGAR_A�O()
        Me.TXT_EMPRESA.Text = DESC_EMPRESA
        Me.cbo_a�o.Focus()
    End Sub

End Class