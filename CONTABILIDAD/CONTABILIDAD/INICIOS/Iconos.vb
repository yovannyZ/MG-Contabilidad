Imports System.Data.SqlClient
Public Class Iconos
    Private obj As New Class1

    Private Sub BTN_COI_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_COI.Click, PictureBox1.Click
        COD_MOD = "COI"
        If Me.SEGURIDAD(COD_MOD) = False Then
            MessageBox.Show("No tiene permisos para acceder a este Modulo", "Modulo de Administración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            My.Forms.INICIO_COI.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        Me.obj.ELIMINAR_CONECTADO()
        End
    End Sub

    Private Sub BTN_ADM_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_ADM.Click, PictureBox3.Click
        COD_MOD = "ADM"
        FECHA_GRAL = Now.Date
        FECHA_INI = Now.Date
        AÑO = (Now.Date.Year)
        MES = (Now.Date.Month)



        If Me.SEGURIDAD(COD_MOD) = False Then
            MessageBox.Show("No tiene permisos para acceder a este Modulo", "Modulo de Administración", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Me.Hide()
            'My.Forms.MOD_ADMIN.Text = ("Modulo de Administración  Empresa : " & DESC_EMPRESA & "                                  Proceso   : " & (FECHA_GRAL))
            My.Forms.MOD_ADMIN.Show()
        End If
    End Sub

    Private Sub BTN_BANCO_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTN_BANCO.Click, PictureBox2.Click
        COD_MOD = "BCO"
        If Me.SEGURIDAD(COD_MOD) = False Then
            MessageBox.Show("No tiene permisos para acceder a este Modulo", "Modulo de Compras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf Me.MOSTRAR_FECHA("BCO") = False Then
            MessageBox.Show("No existe mes activo para el Modulo de Bancos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            My.Forms.MOD_BANCOS.Text = "Modulo de Bancos" ' Empresa : " & DESC_EMPRESA & "                                  Proceso   : " & (FECHA_GRAL))
            My.Forms.MOD_BANCOS.Show()
            Me.Hide()
        End If
    End Sub

    Function MOSTRAR_FECHA(ByVal COD_MODULO As Object) As Boolean
        AÑO = ""
        MES = ""
        Try
            Dim PROG_01 As New SqlCommand("HALLAR_ACTIVO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                AÑO = Rs3.GetValue(0)
                MES = Rs3.GetValue(1)
                FECHA_INI = Date.Parse(Rs3.GetValue(2))
                FECHA_GRAL = Date.Parse(Rs3.GetValue(3))
            Loop
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)
            con.Close()

        End Try
        If (AÑO.ToString = "") Then
            Return False
        End If
        Return True
    End Function

    Function SEGURIDAD(ByVal COD_MOD0 As Object) As Boolean
        Dim ESTADO As Boolean = True
        Try
            Dim PROG_01 As New SqlCommand("SEGURIDAD_MODULO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = (COD_MOD0)
            PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            con.Open()
            PROG_01.ExecuteNonQuery()
            ESTADO = PROG_01.ExecuteReader.HasRows
            con.Close()
        Catch ex As Exception


            con.Close()
            ESTADO = False
            MessageBox.Show(ex.Message)

        End Try
        If (TIPO_USU = "US") Then
            Return ESTADO
        End If
        Return True
    End Function
End Class