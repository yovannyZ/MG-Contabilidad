Imports System.Data.SqlClient
Public Class Genericos
    Dim OBJ As New Class1
    Public Function CBO_ACTIVIDAD(ByVal con0 As SqlConnection) As DataTable
        Dim DT As New DataTable
        If OBJ.DIR_TABLA_DESC("COS", "TSIST") = "SI" Then
            Try
                Dim PROG_01 As New SqlCommand("CBO_ACTIVIDAD", con0)
                Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
            Catch ex As Exception
                con.Close()
            End Try
        End If
        Return DT
    End Function
    Public Function CBO_AUX() As DataTable
        Dim DT As New DataTable
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return DT
    End Function
    Public Function CBO_BCO() As DataTable
        Dim DT As New DataTable
        Try
            Dim PROG_01 As New SqlCommand("CBO_BANCO", con)
            Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return DT
    End Function
    Public Function CBO_COMP(ByVal COD_AUX0 As Object) As DataTable
        Dim DT As New DataTable
        If (TIPO_USU = "US") Then
            Try
                Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX_USU", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (COD_AUX0)
                PROG_01.Parameters.Add("@COD_USU", SqlDbType.VarChar).Value = COD_USU
                Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
            Catch ex As Exception
                con2.Close()
                MessageBox.Show(ex.Message)
            End Try
            Return DT
        End If
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (COD_AUX0)
            Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return DT
    End Function
    Public Function CBO_MONEDA_COI() As DataTable
        Dim DT As New DataTable
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_MONEDA_COI", con2)
            Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return DT
    End Function
    Public Function CBO_SUCURSAL() As DataTable
        Dim DT As New DataTable
        If (TIPO_USU = "US") Then
            Try
                Dim PROG_01 As New SqlCommand("CBO_SUCURSAL_USU", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
                Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            Return DT
        End If
        Try
            Dim PROG_01 As New SqlCommand("CBO_SUCURSAL0", con)
            Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return DT
    End Function
    Public Function CBO_ORDEN_CUENTA(ByVal TIPO_MOV As Object) As DataTable
        Dim DT As New DataTable
        Try
            Dim PROG_01 As New SqlCommand("CBO_ORDEN_CUENTA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.Char).Value = TIPO_MOV
            Dim Prog00 As New SqlDataAdapter(PROG_01) : Prog00.Fill(DT)
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return DT
    End Function
    Public Function MOSTRAR_CC() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("DGW_AREA", con)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Public Function CBO_MONEDAS() As DataTable
        Dim dt As New DataTable
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_MONEDAS", con2)
            Dim PROG_00 As New SqlDataAdapter(PROG_01)
            PROG_00.Fill(dt)
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
        Return dt
    End Function
End Class
