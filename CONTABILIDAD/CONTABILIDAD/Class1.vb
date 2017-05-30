Imports System.Text
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Reflection

Public Class Class1
    Public frm_mes As String
    Public frm_año As String

    Public Function COD_UBICACION(ByVal DESC_CLASE As Object) As String
        Dim str As String = ""
        Try
            Dim command As New SqlCommand("COD_UBI", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@DESC_UBI", SqlDbType.VarChar).Value = (DESC_CLASE)
            con.Open()
            str = (command.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If (str = "") Then
            str = " "
        End If
        Return str
    End Function

    Public Function BUSCAR_CUENTA_PCXC(ByVal COD_SUC0 As Object, ByVal COD_PER0 As Object, ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("BUSCAR_CUENTA_PCXC", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = COD_SUC0
            pro03.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER0
            pro03.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            pro03.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC0
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (NUM Is Nothing) Then
            NUM = ""
        End If
        Return NUM.ToString
    End Function

    Public Function HALLAR_ST_ANA_CTA(ByVal AÑO0 As Object, ByVal CTA0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_ST_ANA_CTA", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO0
            pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = CTA0
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HALLAR_COMP_X_BANCO(ByVal COD_BCO0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_COD_COMP_X_BCO", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BCO0
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function NumText(ByVal value As Double) As String
        Select Case value
            Case 0 : NumText = "CERO"
            Case 1 : NumText = "UN"
            Case 2 : NumText = "DOS"
            Case 3 : NumText = "TRES"
            Case 4 : NumText = "CUATRO"
            Case 5 : NumText = "CINCO"
            Case 6 : NumText = "SEIS"
            Case 7 : NumText = "SIETE"
            Case 8 : NumText = "OCHO"
            Case 9 : NumText = "NUEVE"
            Case 10 : NumText = "DIEZ"
            Case 11 : NumText = "ONCE"
            Case 12 : NumText = "DOCE"
            Case 13 : NumText = "TRECE"
            Case 14 : NumText = "CATORCE"
            Case 15 : NumText = "QUINCE"
            Case Is < 20 : NumText = "DIECI" & NumText(value - 10)
            Case 20 : NumText = "VEINTE"
            Case Is < 30 : NumText = "VEINTI" & NumText(value - 20)
            Case 30 : NumText = "TREINTA"
            Case 40 : NumText = "CUARENTA"
            Case 50 : NumText = "CINCUENTA"
            Case 60 : NumText = "SESENTA"
            Case 70 : NumText = "SETENTA"
            Case 80 : NumText = "OCHENTA"
            Case 90 : NumText = "NOVENTA"
            Case Is < 100 : NumText = NumText(Int(value \ 10) * 10) & " Y " & NumText(value Mod 10)
            Case 100 : NumText = "CIEN"
            Case Is < 200 : NumText = "CIENTO " & NumText(value - 100)
            Case 200, 300, 400, 600, 800 : NumText = NumText(Int(value \ 100)) & "CIENTOS"
            Case 500 : NumText = "QUINIENTOS"
            Case 700 : NumText = "SETECIENTOS"
            Case 900 : NumText = "NOVECIENTOS"
            Case Is < 1000 : NumText = NumText(Int(value \ 100) * 100) & " " & NumText(value Mod 100)
            Case 1000 : NumText = "MIL"
            Case Is < 2000 : NumText = "MIL " & NumText(value Mod 1000)
            Case Is < 1000000 : NumText = NumText(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then NumText = NumText & " " & NumText(value Mod 1000)
            Case 1000000 : NumText = "UN MILLON"
            Case Is < 2000000 : NumText = "UN MILLON " & NumText(value Mod 1000000)
            Case Is < 1000000000000.0# : NumText = NumText(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then NumText = NumText & " " & NumText(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : NumText = "UN BILLON"
            Case Is < 2000000000000.0# : NumText = "UN BILLON " & NumText(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : NumText = NumText(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then NumText = NumText & " " & NumText(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    Public Function HALLAR_FECHA_REF(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal CUENTA0 As Object, ByVal SUC0 As String) As Date
        Dim I As Date
        Try
            Dim PROG_01 As New SqlCommand("BUSCAR_FECHA_CXP", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC0
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER0
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = CUENTA0
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = SUC0
            con.Open()
            I = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return I
    End Function

    Public Function BUSCAR_CUENTA_PCXP(ByVal COD_SUC0 As Object, ByVal COD_PER0 As Object, ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("BUSCAR_CUENTA_PCXP", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = COD_SUC0
            pro03.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER0
            pro03.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            pro03.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC0
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (NUM Is Nothing) Then
            NUM = ""
        End If
        Return NUM.ToString
    End Function

    Public Function BUSCAR_IMP_PCXC(ByVal COD_SUC0 As Object, ByVal COD_PER0 As Object, ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_CTA0 As Object) As Decimal
        Dim IMP As New Decimal
        Try
            Dim pro03 As New SqlCommand("BUSCAR_IMP_PCXC", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = COD_SUC0
            pro03.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER0
            pro03.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            pro03.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC0
            pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CTA0
            con.Open()
            IMP = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If IMP = Nothing Then IMP = 0
        Return IMP
    End Function

    Public Function BUSCAR_IMP_PCXP(ByVal COD_SUC0 As Object, ByVal COD_PER0 As Object, ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_CTA0 As Object) As Decimal
        Dim IMP As New Decimal
        Try
            Dim pro03 As New SqlCommand("BUSCAR_IMP_PCXP", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = COD_SUC0
            pro03.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER0
            pro03.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            pro03.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC0
            pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CTA0
            con.Open()
            IMP = Decimal.Parse(pro03.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return IMP
    End Function

    Public Function COD_ACTIVIDAD(ByVal DESC As String, ByVal con0 As SqlConnection) As String
        Dim COD As String = ""
        If DIR_TABLA_DESC("COS", "TSIST") = "SI" Then

            Try
                Dim CMD As New SqlCommand("COD_ACTIVIDAD", con0)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@DESC_ACTIVIDAD", SqlDbType.VarChar).Value = DESC
                con0.Open()
                COD = CMD.ExecuteScalar
                con0.Close()
            Catch ex As Exception
                con0.Close()
                MsgBox(ex.Message)
            End Try
        End If
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_AUX(ByVal desc As Object) As String
        Dim cod As String = ""
        Try
            Dim PROG_01 As New SqlCommand("COD_AUXILIAR", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@desc_aux", SqlDbType.VarChar).Value = desc
            con.Open()
            cod = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return cod
    End Function

    Public Function COD_BANCO_EQ(ByVal desc As String) As String
        Dim cod As String = ""
        Try
            Dim pro03 As New SqlCommand("cod_eq", con2)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@desc_eq", SqlDbType.VarChar).Value = desc
            con2.Open()
            cod = pro03.ExecuteScalar
            con2.Close()
        Catch ex As Exception
            con2.Close()
        End Try
        Return cod
    End Function

    Public Function COD_CAT_PER(ByVal DESC_CAT As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_CAT_PER", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_CAT", SqlDbType.VarChar).Value = DESC_CAT
            con2.Open()
            COD = CMD.ExecuteScalar
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
        If COD = "" Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_CC(ByVal DESC As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_AREA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_AREA", SqlDbType.VarChar).Value = DESC
            con.Open()
            COD = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If COD = "" Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_CLASE_PER(ByVal DESC_CLASE As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_CLASE_PER", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_CLASE", SqlDbType.VarChar).Value = DESC_CLASE
            con2.Open()
            COD = CMD.ExecuteScalar
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
        If COD = "" Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_COMP(ByVal desc As Object, ByVal aux As Object) As String
        Dim cod As String = ""
        Try
            Dim PROG_01 As New SqlCommand("COD_COMPROBANTE", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@DESC_COMP", SqlDbType.VarChar).Value = desc
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = aux
            con.Open()
            cod = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Return cod
    End Function

    Public Function COD_CONTROL(ByVal DESC As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_CONTROL", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_CONTROL", SqlDbType.VarChar).Value = DESC
            con.Open()
            COD = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If COD = "" Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_D_H(ByVal COD_DOC As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("d_h_COD_DOC", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (COD_DOC)
            con2.Open()
            COD = CMD.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_DEP(ByVal desc As Object) As String
        Dim var1_cod_doc As String = ""
        Try
            Dim pro As New SqlCommand("cod_DEP", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@desc_DEP", SqlDbType.Char).Value = (desc)
            con2.Open()
            var1_cod_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        If (var1_cod_doc = "") Then
            var1_cod_doc = " "
        End If
        Return var1_cod_doc
    End Function

    Public Function COD_DETALLE_FORMATO(ByVal desc As Object, ByVal formato As Object, ByVal grupo As Object) As String
        Dim cod As String = ""
        Try
            Dim PROG_01 As New SqlCommand("COD_RELACION_FORMATO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_FORMATO", SqlDbType.Char).Value = (formato)
            PROG_01.Parameters.Add("@COD_GRUPO", SqlDbType.Char).Value = (grupo)
            PROG_01.Parameters.Add("DESC_DETALLE", SqlDbType.VarChar).Value = (desc)
            con.Open()
            cod = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
        Return cod
    End Function

    Public Function COD_DIST(ByVal desc As Object, ByVal COD_PRO As Object, ByVal COD_DEP As Object) As String
        Dim var1_cod_doc As String = ""
        Try
            Dim pro As New SqlCommand("cod_DIST", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@COD_DEP", SqlDbType.Char).Value = (COD_DEP)
            pro.Parameters.Add("@COD_PRO", SqlDbType.Char).Value = (COD_PRO)
            pro.Parameters.Add("@desc_DIST", SqlDbType.Char).Value = (desc)
            con2.Open()
            var1_cod_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (var1_cod_doc = "") Then
            var1_cod_doc = " "
        End If
        Return var1_cod_doc
    End Function

    Public Function COD_DOC(ByVal desc As Object) As String
        Dim var1_cod_doc As String = ""
        Try
            Dim pro As New SqlCommand("cod_doc", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@desc_doc", SqlDbType.Char).Value = (desc)
            con2.Open()
            var1_cod_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        Return var1_cod_doc
    End Function

    Public Function COD_DOC_EQ_MP(ByVal COD_MP As Object) As String
        Dim var1_cod_doc As String = ""
        Try
            Dim pro As New SqlCommand("buscar_cod_doc_eq", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@COD_MP", SqlDbType.Char).Value = (COD_MP)
            con2.Open()
            var1_cod_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        Return var1_cod_doc
    End Function

    Public Function COD_ELEMENTO(ByVal desc As Object) As String
        Dim var1_cod_orden As String = ""
        Try
            Dim pro As New SqlCommand("COD_ELEMENTO", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@DESC_ELEMENTO", SqlDbType.Char).Value = (desc)
            con.Open()
            var1_cod_orden = pro.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return var1_cod_orden
    End Function

    Public Function COD_EMPRESA(ByVal desc As Object) As String
        Dim var1_cod_doc As String = ""
        Try
            Dim pro As New SqlCommand("codigo_empresa", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@desc_empresa", SqlDbType.Char).Value = (desc)
            con2.Open()
            var1_cod_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        Return var1_cod_doc
    End Function

    Public Function COD_FONO(ByVal DESC_UNIDAD As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_FONO", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_TIPO", SqlDbType.VarChar).Value = (DESC_UNIDAD)
            con2.Open()
            COD = CMD.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_FORMATO(ByVal desc As Object) As String
        Dim cod As String = ""
        Try
            Dim PROG_01 As New SqlCommand("COD_FORMATO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@desc_FORMATO", SqlDbType.VarChar).Value = (desc)
            con.Open()
            cod = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
        Return cod
    End Function

    Public Function COD_GRUPO_FORMATO(ByVal desc As Object, ByVal formato As Object) As String
        Dim cod As String = ""
        Try
            Dim PROG_01 As New SqlCommand("COD_GRUPO_FORMATO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = (formato)
            PROG_01.Parameters.Add("@DESC_GRUPO", SqlDbType.VarChar).Value = (desc)
            con.Open()
            cod = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
        Return cod
    End Function

    Public Function COD_MES(ByVal DESC As Object) As Object
        Dim COD As String = ""
        Select Case DESC
            Case "INICIO" : COD = "00"
            Case "ENERO" : COD = "01"
            Case "FEBRERO" : COD = "02"
            Case "MARZO" : COD = "03"
            Case "ABRIL" : COD = "04"
            Case "MAYO" : COD = "05"
            Case "JUNIO" : COD = "06"
            Case "JULIO" : COD = "07"
            Case "AGOSTO" : COD = "08"
            Case "SETIEMBRE" : COD = "09"
            Case "OCTUBRE" : COD = "10"
            Case "NOVIEMBRE" : COD = "11"
            Case "DICIEMBRE" : COD = "12"
            Case "CIERRE" : COD = "13"
        End Select
        Return COD
    End Function

    Public Function COD_MONEDA(ByVal desc As Object) As String
        Dim cod As String = ""
        Try
            Dim PROG_01 As New SqlCommand("cod_moneda2", con2)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@desc_moneda", SqlDbType.VarChar).Value = desc
            con2.Open()
            cod = PROG_01.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
        Return cod
    End Function

    Public Function COD_MP(ByVal desc As Object) As String
        Dim cod As String = ""
        Try
            Dim pro03 As New SqlCommand("cod_MP", con2)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@desc_mp", SqlDbType.VarChar).Value = (desc)
            con2.Open()
            cod = pro03.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        Return cod
    End Function

    Public Function COD_NIVEL(ByVal DESC_NIVEL As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_NIVEL", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_NIVEL", SqlDbType.VarChar).Value = (DESC_NIVEL)
            con.Open()
            COD = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_NRO_ORDEN(ByVal desc As Object, ByVal TIPO_MOV As String) As String
        Dim cod As String = ""
        Try
            Dim PROG_01 As New SqlCommand("COD_NRO_ORDEN", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@DESC_ORDEN", SqlDbType.VarChar).Value = (desc)
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = TIPO_MOV
            con.Open()
            cod = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        Return cod
    End Function

    Public Function COD_PAIS(ByVal DESC As Object) As String
        Dim var1_cod_doc As String = ""
        Try
            Dim pro As New SqlCommand("cod_PAIS", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@desc_PAIS", SqlDbType.Char).Value = (DESC)
            con2.Open()
            var1_cod_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (var1_cod_doc = "") Then
            var1_cod_doc = " "
        End If
        Return var1_cod_doc
    End Function

    Public Function COD_PRO(ByVal desc As Object, ByVal COD_DEP As Object) As String
        Dim var1_cod_doc As String = ""
        Try
            Dim pro As New SqlCommand("cod_PRO", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@COD_DEP", SqlDbType.Char).Value = (COD_DEP)
            pro.Parameters.Add("@desc_PRO", SqlDbType.Char).Value = (desc)
            con2.Open()
            var1_cod_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (var1_cod_doc = "") Then
            var1_cod_doc = " "
        End If
        Return var1_cod_doc
    End Function

    Public Function COD_PROYECTO(ByVal DESC As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_PROYECTO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_PROYECTO", SqlDbType.VarChar).Value = (DESC)
            con.Open()
            COD = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_SUCURSAL(ByVal DESC As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_SUCURSAL", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_SUCURSAL", SqlDbType.VarChar).Value = (DESC)
            con.Open()
            COD = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_TIPO_CUENTA(ByVal DESC As Object) As String
        Dim COD As String = ""
        Try
            Dim PROG_01 As New SqlCommand("COD_TIPO_CUENTA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@DESC_TIPO", SqlDbType.VarChar).Value = (DESC)
            con.Open()
            COD = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        Return COD
    End Function

    Public Function COD_TIPO_DIRECCION(ByVal desc As Object) As String
        Dim var1_cod_doc As String = ""
        Try
            Dim pro As New SqlCommand("cod_TIPO_DIRECCION", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@desc_TIPO", SqlDbType.Char).Value = (desc)
            con2.Open()
            var1_cod_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        If (var1_cod_doc = "") Then
            var1_cod_doc = " "
        End If
        Return var1_cod_doc
    End Function

    Public Function COD_TIPO_DOC_PER(ByVal DESC_UNIDAD As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_TIPO_DOC_PER", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_TIPO", SqlDbType.VarChar).Value = (DESC_UNIDAD)
            con2.Open()
            COD = CMD.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function COD_TIPO_PROY_CONT(ByVal DESC As Object, ByVal TIPO As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_TIPO_PROY_CONT", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESC_TIPO", SqlDbType.VarChar).Value = (DESC)
            CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = (TIPO)
            con.Open()
            COD = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function DATOS_EMPRESA(ByVal cod As Object) As ArrayList
        Dim datos As New ArrayList
        Try
            con2.Open()
            Using cmd As New SqlCommand("MOSTRAR_DATOS_EMPRESA", con2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@COD_EMPRESA", SqlDbType.Char).Value = (cod)
                Using reader As SqlDataReader = cmd.ExecuteReader
                    If Not reader Is Nothing AndAlso reader.HasRows Then
                        reader.Read()
                        datos.Add(reader(0))
                        datos.Add(reader(1))
                        datos.Add(reader(2))
                        datos.Add(reader(3))
                        datos.Add(reader(4))
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con2.Close()
        End Try
        Return datos
    End Function

    Public Function DESC_ACT(ByVal cod As Object) As String
        Dim var1_desc_doc As String = ""
        Try
            Dim pro As New SqlCommand("DESC_ACT", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@COD", SqlDbType.VarChar).Value = (cod)
            con.Open()
            var1_desc_doc = pro.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return var1_desc_doc
    End Function

    Public Function DESC_ACTIVIDAD(ByVal COD As String, ByVal con0 As SqlConnection) As String
        Dim DESC As String = ""
        If DIR_TABLA_DESC("COS", "TSIST") = "SI" Then
            Try
                Dim CMD As New SqlCommand("DESC_ACTIVIDAD", con0)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.Char).Value = COD
                con0.Open()
                DESC = CMD.ExecuteScalar
                con0.Close()
            Catch ex As Exception


                con0.Close()
                MsgBox(ex.Message)

            End Try
        End If
        If DESC = Nothing Then DESC = ""
        Return DESC
    End Function

    Public Function DESC_CC(ByVal COD As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_AREA", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_AREA", SqlDbType.VarChar).Value = (COD)
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function DESC_COMPROBANTE(ByVal COD_AUX As Object, ByVal COD_COMP As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_COMP", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (COD_AUX)
            CMD.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = (COD_COMP)
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function DESC_CONTROL(ByVal COD As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_CONTROL", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_CONTROL", SqlDbType.VarChar).Value = (COD)
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function DESC_CPTO(ByVal COD As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_CONCEPTOS", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = (COD)
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function DESC_USUARIO_COMPROBANTE(ByVal COD_AUX0 As Object, ByVal COD_COMP0 As Object, ByVal NRO_COMP0 As Object, ByVal FE_AÑO0 As Object, ByVal FE_MES0 As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_USUARIO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX0
            CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP0
            CMD.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = NRO_COMP0
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = FE_AÑO0
            CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = FE_MES0
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function DESC_USUARIO_BANCO(ByVal COD_MP0 As Object, ByVal NRO_MP0 As Object, ByVal COD_BCO0 As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_USUARIO_BANCO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = COD_MP0
            CMD.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = NRO_MP0
            CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BCO0
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function DESC_CUENTA(ByVal cod_cuenta As String, ByVal AÑO0 As String) As String
        Dim desc As String = ""
        Try
            Dim PROG_01 As New SqlCommand("DESC_CUENTA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = cod_cuenta
            PROG_01.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO0
            con.Open()
            desc = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
        Return desc
    End Function

    Public Function DESC_DOC(ByVal cod As Object) As String
        Dim var1_desc_doc As String = ""
        Try
            Dim pro As New SqlCommand("desc_doc", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@cod_doc", SqlDbType.Char).Value = (cod)
            con2.Open()
            var1_desc_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        If var1_desc_doc Is Nothing Then var1_desc_doc = ""
        Return var1_desc_doc.ToString
    End Function

    Public Function DESC_ELEMENTO(ByVal cod As Object) As String
        Dim desc As String = ""
        Try
            Dim PROG_01 As New SqlCommand("DESC_ELEMENTO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_ELEMENTO", SqlDbType.VarChar).Value = (cod)
            con.Open()
            desc = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
        Return desc
    End Function

    Public Function DESC_MES(ByVal COD As Object) As Object
        Dim DESC As String = ""
        Select Case COD
            Case "00" : DESC = "INICIO"
            Case "01" : DESC = "ENERO"
            Case "02" : DESC = "FEBRERO"
            Case "03" : DESC = "MARZO"
            Case "04" : DESC = "ABRIL"
            Case "05" : DESC = "MAYO"
            Case "06" : DESC = "JUNIO"
            Case "07" : DESC = "JULIO"
            Case "08" : DESC = "AGOSTO"
            Case "09" : DESC = "SETIEMBRE"
            Case "10" : DESC = "OCTUBRE"
            Case "11" : DESC = "NOVIEMBRE"
            Case "12" : DESC = "DICIEMBRE"
            Case "13" : DESC = "CIERRE"
        End Select
        Return DESC
    End Function

    Public Function DESC_MONEDA(ByVal cod As Object) As String
        Dim desc_moneda_00 As String = ""
        Try
            Dim pro As New SqlCommand("desc_moneda", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@cod_moneda", SqlDbType.Char).Value = (cod)
            con2.Open()
            desc_moneda_00 = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        Return desc_moneda_00
    End Function

    Public Function DESC_MP(ByVal cod As Object) As String
        Dim desc As String = ""
        Try
            Dim PROG_01 As New SqlCommand("desc_mp", con2)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@cod_mp", SqlDbType.VarChar).Value = (cod)
            con2.Open()
            desc = PROG_01.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con2.Close()
        End Try
        Return desc
    End Function

    Public Function DESC_NIVEL_CUENTA(ByVal COD As Object) As String
        Dim desc As String = ""
        Try
            Dim PROG_01 As New SqlCommand("DESC_NIVEL_CUENTA", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_NIVEL", SqlDbType.VarChar).Value = (COD)
            con.Open()
            desc = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
        Return desc
    End Function

    Public Function DESC_NIVEL_DIGITOS(ByVal DIG As Object) As String
        Dim desc As String = ""
        Try
            Dim PROG_01 As New SqlCommand("DESC_NIVEL_CUENTA_DIG", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@NRO_DIGITOS", SqlDbType.VarChar).Value = (DIG)
            con.Open()
            desc = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
        Return desc
    End Function

    Public Function DESC_PERSONA(ByVal cod As Object) As String
        Dim var1_desc_doc As String = ""
        Try
            Dim pro As New SqlCommand("DESC_PERSONA", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@COD_PER", SqlDbType.Char).Value = cod
            con.Open()
            var1_desc_doc = pro.ExecuteScalar
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return var1_desc_doc
    End Function

    Public Function DESC_PROYECTO(ByVal COD As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_PROYECTO", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_PROYECTO", SqlDbType.VarChar).Value = COD
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function DESC_TIPO_PROY_CONT(ByVal COD As Object, ByVal TIPO As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_TIPO_PROY_CONT", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_TIPO", SqlDbType.VarChar).Value = (COD)
            CMD.Parameters.Add("@TIPO", SqlDbType.Char).Value = (TIPO)
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return DESC
    End Function

    Public Function DIR_TABLA_COD(ByVal DESC As Object, ByVal TABLA_COD As Object) As String
        Dim COD As String = ""
        Try
            Dim CMD As New SqlCommand("COD_TABLA_DIR", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = (DESC)
            CMD.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = (TABLA_COD)
            con.Open()
            COD = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (COD = "") Then
            COD = " "
        End If
        Return COD
    End Function

    Public Function DIR_TABLA_DESC(ByVal COD As Object, ByVal TABLA_COD As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_TABLA_DIR", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = (COD)
            CMD.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = (TABLA_COD)
            con.Open()
            DESC = CMD.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)

        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function DIRECCION_EMPRESA(ByVal cod As Object) As String
        Dim var1_desc_doc As String = ""
        Try
            Dim pro As New SqlCommand("HALLAR_DIRECCION_EMPRESA", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@COD_EMPRESA", SqlDbType.Char).Value = (cod)
            con2.Open()
            var1_desc_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        Return var1_desc_doc
    End Function

    Public Function HallarDireccionEmpresa(ByVal codigoEmpresa As Object) As String()
        Dim direccion() As String
        Try
            con2.Open()
            Dim command As New SqlCommand("HALLAR_DIRECCION_EMPRESA2", con2)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@COD_EMPRESA", SqlDbType.Char).Value = (codigoEmpresa)
            Dim reader As SqlDataReader = command.ExecuteReader()
            If Not IsNothing(reader) AndAlso reader.HasRows Then
                ReDim direccion(4)
                reader.Read()
                direccion(0) = reader("Ubigeo")
                direccion(1) = reader("Direccion")
                direccion(2) = reader("Departamento")
                direccion(3) = reader("Provincia")
                direccion(4) = reader("Distrito")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
        Return direccion
    End Function

    Public Sub ELIMINAR_CONECTADO()
        Try
            Dim pro As New SqlCommand("ELIMINAR_CONECTADO", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@pc", SqlDbType.VarChar).Value = NOMBRE_PC
            pro.Parameters.Add("@COD_MODULO", SqlDbType.VarChar).Value = "GCO"
            pro.Parameters.Add("@ALEATORIO", SqlDbType.NVarChar).Value = ALEATORIO
            con2.Open()
            pro.ExecuteNonQuery()
            con2.Close()
        Catch ex As Exception
            con2.Close()

            'MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
    End Sub

    Public Sub ELIMINAR_TEMPORAL(ByVal TIPO0 As String)
        Try
            Dim pro As New SqlCommand("ELIMINAR_TEMPORAL", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TIPO0
            pro.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            con.Open()
            pro.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Public Function GCO_DIR_TABLA_DESC(ByVal COD As String, ByVal TABLA_COD As String, ByVal CON0 As SqlConnection) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_TABLA_DIR", CON0)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = COD
            CMD.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = TABLA_COD
            CON0.Open()
            DESC = CMD.ExecuteScalar
            CON0.Close()
        Catch ex As Exception


            CON0.Close()
            MsgBox(ex.Message)

        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Public Function HACER_CAMBIO(ByVal CADENA As Object) As Object
        Return Strings.Format(Math.Round(Decimal.Parse(CADENA), 4), "##0.0000")
    End Function

    Public Function HACER_DECIMAL(ByVal CADENA As Object) As Object
        Return Strings.Format(Math.Round(Decimal.Parse(CADENA), 2), "###,###,###,##0.00")
    End Function

    Public Function HACER_DECIMAL_PTO(ByVal CADENA As Object) As Object
        Return Strings.Format(Math.Round(Decimal.Parse(CADENA), 2), "##0.00")
    End Function

    Public Function HALLAR_NRO_COMP(ByVal COD_AUX0 As Object, ByVal COD_COMP0 As Object, ByVal AÑO0 As Object, ByVal MES0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_NRO_COMP", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO0
            pro03.Parameters.Add("@MES", SqlDbType.VarChar).Value = MES0
            pro03.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX0
            pro03.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP0
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = Rs3.GetValue(0)
                Loop
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HALLAR_NRO_COMP_ACTUAL(ByVal COD_AUX0 As Object, ByVal COD_COMP0 As Object, ByVal AÑO0 As Object, ByVal MES0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_NRO_COMP_ACTUAL", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO0
            pro03.Parameters.Add("@MES", SqlDbType.VarChar).Value = MES0
            pro03.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX0
            pro03.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP0
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = Rs3.GetValue(0)
                Loop
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HALLAR_MODULO_COMP(ByVal COD_AUX0 As Object, ByVal COD_COMP0 As Object, ByVal AÑO0 As Object, ByVal MES0 As Object, ByVal NRO_COMP0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_MODULO_COMP", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            pro03.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            pro03.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX0
            pro03.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP0
            pro03.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP0
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = Rs3.GetValue(0)
                Loop
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HALLAR_CTA_ENLACE(ByVal AÑO0 As Object, ByVal CUENTA0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_CUENTA_ENLACE", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (AÑO0)
            pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (CUENTA0)
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If NUM = Nothing Then NUM = ""
        Return NUM
    End Function

    Public Function HALLAR_CTA_CPTO(ByVal COD_CPTO0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_CUENTA_CPTO", con)
            pro03.CommandType = CommandType.StoredProcedure
            'pro03.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (AÑO0)
            pro03.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = COD_CPTO0
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If NUM = Nothing Then NUM = ""
        Return NUM
    End Function

    Public Function HALLAR_MON_BCO(ByVal COD_BCO0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_MONEDA_BCO", con)
            pro03.CommandType = CommandType.StoredProcedure
            'pro03.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (AÑO0)
            pro03.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = COD_BCO0
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If NUM = Nothing Then NUM = ""
        Return NUM
    End Function

    Public Function HALLAR_CTA_DESTINO(ByVal AÑO0 As Object, ByVal CUENTA0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_CUENTA_DESTINO", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = (AÑO0)
            pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (CUENTA0)
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If NUM = Nothing Then NUM = ""
        Return NUM
    End Function

    Public Function HALLAR_CTA_DESTINO_TRANSFERENCIA(ByVal AÑO0 As Object, ByVal COD_AUX0 As Object, ByVal COD_COMP0 As Object, ByVal NRO_C0 As Object, ByVal MES0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_CUENTA_DESTINO_TRANSFERENCIA", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX0
            pro03.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP0
            pro03.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_C0
            pro03.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO0
            pro03.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES0
            'pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (CUENTA0)
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If NUM = Nothing Then NUM = ""
        Return NUM
    End Function

    Public Function HALLAR_MENSAJE(ByVal CODIGO As Object) As String
        Dim str2 As String = ""
        Try
            Dim command As New SqlCommand("HALLAR_MENSAJE", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = CODIGO
            con.Open()
            str2 = (command.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If (str2 = "") Then
            str2 = " "
        End If
        Return str2
    End Function

    Public Function HALLAR_NRO_COMP_PCXC(ByVal cod_suc0 As Object, ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object) As String
        Dim I As String = ""
        Try
            Dim PROG_01 As New SqlCommand("GCO_COI_TRANSF_HALLAR_COMP_CXC", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (COD_DOC0)
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = (NRO_DOC0)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER0)
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (cod_suc0)
            con.Open()
            I = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (I Is Nothing) Then
            I = ""
        End If
        Return I.ToString
    End Function

    Public Function HALLAR_NRO_COMP_PCXP(ByVal cod_suc0 As Object, ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object) As String
        Dim I As String = ""
        Try
            Dim PROG_01 As New SqlCommand("GCO_COI_TRANSF_HALLAR_COMP", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (COD_DOC0)
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = (NRO_DOC0)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER0)
            PROG_01.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = (cod_suc0)
            con.Open()
            I = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (I Is Nothing) Then
            I = ""
        End If
        Return I.ToString
    End Function

    Public Function HALLAR_NRO_DIGITOS(ByVal COD_NIVEL As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_NRO_DIGITOS", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_NIVEL", SqlDbType.VarChar).Value = (COD_NIVEL)
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Return NUM
    End Function

    Public Function HALLAR_NRO_MP(ByVal COD_MP0 As Object, ByVal COD_BANCO0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_NRO_MP", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP0
            pro03.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = COD_BANCO0
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = Rs3.GetValue(0)
                Loop
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HALLAR_ORDEN_CUENTA(ByVal TIPO_ORDEN As Object, ByVal AÑO As Object, ByVal TIPO_MOV As Object, ByVal COD_CUENTA As Object) As String
        Dim ORDEN As String = con.ConnectionString
        Try
            Dim pro03 As New SqlCommand("HALLAR_ORDEN_CUENTA", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@TIPO_ORDEN", SqlDbType.VarChar).Value = TIPO_ORDEN
            pro03.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            pro03.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = TIPO_MOV
            pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CUENTA
            con.Open()
            ORDEN = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (ORDEN = Nothing) Then
            ORDEN = ""
        End If
        Return ORDEN
    End Function

    Public Function HALLAR_OBS_FORMATO(ByVal COD_FORMATO As String) As String
        Dim OBS As String = con.ConnectionString
        Try
            Dim pro03 As New SqlCommand("HALLAR_OBS_FORMATO", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("COD_FORMATO", SqlDbType.VarChar).Value = COD_FORMATO
            con.Open()
            OBS = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return OBS.ToString
    End Function

    Public Function HALLAR_ORDEN_CUENTA2(ByVal TIPO_ORDEN As Object, ByVal AÑO As Object, ByVal TIPO_MOV As Object, ByVal COD_CUENTA As Object) As String
        Dim ORDEN As String = con.ConnectionString
        Try
            Dim pro03 As New SqlCommand("HALLAR_ORDEN_CUENTA2", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@TIPO_ORDEN", SqlDbType.VarChar).Value = (TIPO_ORDEN)
            pro03.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            pro03.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = (TIPO_MOV)
            pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (COD_CUENTA)
            con.Open()
            ORDEN = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        If (ORDEN = Nothing) Then
            ORDEN = ""
        End If
        Return ORDEN
    End Function

    Public Function HALLAR_SALDO_BANCOS(ByVal COD_BANCO0 As Object) As Decimal
        Dim SALDO0 As New Decimal
        Try
            Dim pro03 As New SqlCommand("HALLAR_SALDO_BANCO", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            pro03.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = (COD_BANCO0)
            pro03.Parameters.Add("@MES", SqlDbType.VarChar).Value = MES
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                SALDO0 = New Decimal
            Else
                Do While Rs3.Read
                    SALDO0 = Decimal.Parse(Rs3.GetValue(0))
                Loop
            End If
            con.Close()
        Catch ex As Exception


            con.Close()
            MsgBox(ex.Message)

        End Try
        Return SALDO0
    End Function

    Public Function HALLAR_SUCURSAL(ByVal COD_AUX0 As Object, ByVal COD_COMP0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_SUCURSAL", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (COD_AUX0)
            pro03.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = (COD_COMP0)
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HALLAR_ST_PERCEPTOR(ByVal codigoPersona As String) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_ST_PERCEPTOR", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_PER", SqlDbType.Char).Value = codigoPersona
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HALLAR_CPTO(ByVal COD0 As Object, ByVal TIPO0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_CPTO_VALIDADO", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = (COD0)
            pro03.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = (TIPO0)
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function IMPUESTO(ByVal CODIGO As Object) As String
        Dim var1_cod_doc As New Decimal
        Try
            Dim pro As New SqlCommand("HALLAR_IMPUESTO", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@CODIGO", SqlDbType.Char).Value = (CODIGO)
            con2.Open()
            var1_cod_doc = Decimal.Parse(pro.ExecuteScalar)
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (Decimal.Compare(var1_cod_doc, Decimal.Zero) = 0) Then
            var1_cod_doc = New Decimal
        End If
        Return var1_cod_doc
    End Function

    Public Function MOSTRAR_BANCO_COMP() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("DGW_BANCOS_COMPROBANTE", con)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return dt
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

    Public Function MOSTRAR_CONCEPTOS_STATUS(ByVal TIPO As Object) As DataTable
        Dim dt As New DataTable("CUENTAS")
        Try
            Dim pro As New SqlCommand("DGW_CONCEPTOS_STATUS", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@TIPO_I_E", SqlDbType.VarChar).Value = (TIPO)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CONCEPTOS_STATUS_VCTO(ByVal TIPO As Object) As DataTable
        Dim dt As New DataTable("CUENTAS")
        Try
            Dim pro As New SqlCommand("DGW_CONCEPTOS_STATUS_VCTO", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@TIPO_I_E", SqlDbType.VarChar).Value = (TIPO)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CUENTAS_CONFIGURADAS(ByVal TIPO As Object, ByVal AÑO0 As Object, ByVal TIPO_MOV As Object) As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("MOSTRAR_CUENTAS_CONFIGURADAS", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@tipo", SqlDbType.VarChar).Value = (TIPO)
            pro.Parameters.Add("@año", SqlDbType.VarChar).Value = (AÑO0)
            pro.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = (TIPO_MOV)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CUENTAS_REPARABLES(ByVal AÑO1 As Object) As DataTable
        Dim dt As New DataTable("CUENTAS_REP")
        Try
            Dim pro As New SqlCommand("DGW_REPARABLE", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.Char).Value = (AÑO1)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CUENTAS_NO_CXP_NO_CXC(ByVal AÑO1 As Object) As DataTable
        Dim dt As New DataTable("CUENTAS_REP")
        Try
            Dim pro As New SqlCommand("DGW_CUENTA8_NI_CXP_CXC", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.Char).Value = (AÑO1)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CUENTAS_STATUS(ByVal AÑO0 As Object) As DataTable
        Dim dt As New DataTable("CUENTAS")
        Try
            Dim pro As New SqlCommand("DGW_CUENTAS_STATUS", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = (AÑO0)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CUENTAS_STATUS_TIPO(ByVal AÑO0 As Object, ByVal ANA0 As Object) As DataTable
        Dim dt As New DataTable("CUENTAS")
        Try
            Dim pro As New SqlCommand("DGW_CUENTAS_STATUS_TIPO", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = (AÑO0)
            pro.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = (ANA0)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CUENTAS_TODAS(ByVal AÑO0 As Object) As DataTable
        Dim dt As New DataTable("CUENTAS")
        Try
            Dim pro As New SqlCommand("DGW_CUENTAS", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = (AÑO0)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CUENTAS_CC(ByVal AÑO0 As Object) As DataTable
        Dim dt As New DataTable("CUENTAS")
        Try
            Dim pro As New SqlCommand("DGW_CUENTA8_CC", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.Char).Value = (AÑO0)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_CUENTAS_TODAS_DETALLE(ByVal AÑO0 As Object) As DataTable
        Dim dt As New DataTable("CUENTAS")
        Try
            Dim pro As New SqlCommand("DGW_CUENTAS_NIVEL8", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = (AÑO0)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_PERSONAS_COBRAR() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("MOSTRAR_PERSONAS_XCOBRAR", con)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_PERSONAS_PAGAR() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR", con)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return dt
    End Function
    Public Function MOSTRAR_CUENTAS_NIVEL(ByVal AÑO0 As Object, ByVal ANA0 As Object) As DataTable
        Dim dt As New DataTable("CUENTAS")
        Try
            Dim pro As New SqlCommand("DGW_CUENTAS_NIVEL", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = (AÑO0)
            pro.Parameters.Add("@NIVEL", SqlDbType.VarChar).Value = (ANA0)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return dt
    End Function


    Public Function MOSTRAR_PERSONAS_TODAS() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("MOSTRAR_PERSONAS_TODAS", con)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_PERSONAS_USUARIO_PAGAR() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("MOSTRAR_PERSONAS_XPAGAR_USUARIO", con)
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_PTE_COBRAR_BAN() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("MOSTRAR_PCTAS_COBRAR_BAN", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_PTE_PAGAR_BAN() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("MOSTRAR_PCTAS_PAGAR_BAN", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Public Function MOSTRAR_PTE_PAGAR_COI() As DataTable
        Dim dt As New DataTable("Personas")
        Try
            Dim pro As New SqlCommand("MOSTRAR_PCTAS_PAGAR", con)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            Dim Prog00 As New SqlDataAdapter(pro) : Prog00.Fill(dt)
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con.Close()
        End Try
        Return dt
    End Function

    Public Function PORC_TIPO_CANC(ByVal DESC_CLASE As Object) As Decimal
        Dim COD As New Decimal
        Try
            Dim CMD As New SqlCommand("PORC_TIPO_CANC", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = (DESC_CLASE)
            con2.Open()
            COD = Decimal.Parse(CMD.ExecuteScalar)
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (Decimal.Compare(COD, Decimal.Zero) = 0) Then
            COD = New Decimal
        End If
        Return COD
    End Function

    Public Function RUC_EMPRESA(ByVal cod As Object) As String
        Dim var1_desc_doc As String = ""
        Try
            Dim pro As New SqlCommand("HALLAR_RUC", con2)
            pro.CommandType = CommandType.StoredProcedure
            pro.Parameters.Add("@COD_EMPRESA", SqlDbType.Char).Value = (cod)
            con2.Open()
            var1_desc_doc = pro.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            MsgBox(ex.Message)

        Finally
            con2.Close()
        End Try
        Return var1_desc_doc
    End Function

    Public Function SACAR_CAMBIO(ByVal año_00 As Object, ByVal mes_00 As Object, ByVal dia_00 As Object, ByVal tipo_00 As Object) As String
        If mes_00 = "00" Or mes_00 = "13" Then mes_00 = "01"
        Dim cambio As String = ""
        Try
            Dim prog As New SqlCommand("sacar_cambio", con2)
            prog.CommandType = CommandType.StoredProcedure
            prog.Parameters.Add("@año", SqlDbType.VarChar).Value = (año_00)
            prog.Parameters.Add("@mes", SqlDbType.VarChar).Value = (mes_00)
            prog.Parameters.Add("@dia", SqlDbType.VarChar).Value = (dia_00)
            prog.Parameters.Add("@tipo", SqlDbType.VarChar).Value = (tipo_00)
            con2.Open()
            cambio = prog.ExecuteScalar
            con2.Close()
        Catch ex As Exception

            con2.Close()
            MsgBox(ex.Message)

        End Try
        If (Decimal.Compare(Decimal.Parse(cambio), Decimal.Zero) = 0) Then
            MessageBox.Show("No existe Tipo de Cambio para la fecha elegida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return cambio
    End Function

    Public Function SACAR_CAMBIO2(ByVal año_00 As Object, ByVal mes_00 As Object, ByVal dia_00 As Object, ByVal tipo_00 As Object) As String
        If mes_00 = "00" Or mes_00 = "13" Then mes_00 = "01"
        Dim cambio As String = ""
        Try
            Dim prog As New SqlCommand("sacar_cambio", con2)
            prog.CommandType = CommandType.StoredProcedure
            prog.Parameters.Add("@año", SqlDbType.VarChar).Value = (año_00)
            prog.Parameters.Add("@mes", SqlDbType.VarChar).Value = (mes_00)
            prog.Parameters.Add("@dia", SqlDbType.VarChar).Value = (dia_00)
            prog.Parameters.Add("@tipo", SqlDbType.VarChar).Value = (tipo_00)
            con2.Open()
            cambio = prog.ExecuteScalar
            con2.Close()
        Catch ex As Exception


            con2.Close()
            MsgBox(ex.Message)

        End Try
        Return cambio
    End Function

    Public Function SACAR_CAMBIO_MENSUAL(ByVal AÑO00 As Object, ByVal MES00 As Object, ByVal TIPO00 As Object, ByVal CV00 As String) As String
        If MES00 = "00" Or MES00 = "13" Then MES00 = "01"
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

    Public Function TIPO_FORMATO(ByVal cod As Object) As String
        Dim desc As String = ""
        Try
            Dim PROG_01 As New SqlCommand("HALLAR_TIPO_FORMATO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_FORMATO", SqlDbType.VarChar).Value = (cod)
            con.Open()
            desc = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        Return desc
    End Function

    Public Function TIPO_USU(ByVal nick As String) As String
        Dim tipo As String = ""
        Try
            Dim cmd As New SqlCommand("tipo_usuario", con2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@nick", SqlDbType.Char).Value = nick
            con2.Open()
            tipo = cmd.ExecuteScalar
            con2.Close()
        Catch ex As Exception
            con.Close()
        End Try
        Return tipo
    End Function

    Public Function VALIDAR_FECHA_COMP(ByVal FEC As DateTime) As String
        Select Case FEC.Date
            Case Is > FECHA_GRAL.Date
                MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return "0"
            Case Is < FECHA_INI.Date
                MessageBox.Show("La fecha elegida es menor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return "0"
            Case Else
                Return "2"
        End Select
    End Function

    Public Function VALIDAR_FECHA_DOC(ByVal FEC As DateTime) As String
        Select Case FEC.Date
            Case Is > FECHA_GRAL.Date
                MessageBox.Show("La fecha elegida es mayor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return "0"
            Case Is < FECHA_INI.Date
                MessageBox.Show("La fecha elegida es menor a la fecha de proceso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return "0"
            Case Else
                Return "2"
        End Select
    End Function

    Function VERIFICAR_CUENTA(ByVal CUENTA0 As String, ByVal AÑO0 As String) As Boolean
        Dim ESTADO As Boolean = True
        Try
            Dim comand1 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = CUENTA0
            comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO0
            con.Open()
            comand1.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = comand1.ExecuteReader
            Do While Rs3.Read
                ESTADO = False
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return ESTADO
    End Function

    Function VERIFICAR_PERSONA(ByVal PER0 As String) As Boolean
        Dim ESTADO As Boolean = True
        Try
            Dim comand1 As New SqlCommand("VERIFICAR_PERSONAS", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_PER", SqlDbType.Char).Value = PER0
            'comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO0
            con.Open()
            comand1.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = comand1.ExecuteReader
            Do While Rs3.Read
                ESTADO = False
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return ESTADO
    End Function

    Public Function VERIFICAR_TRANSF_PRODUCCION(ByVal AUX As String, ByVal COMP As String, ByVal NRO_COMP As String, ByVal AÑO0 As String, ByVal MES0 As String) As Boolean
        Dim ESTADO As Boolean = True
        Dim C As Integer = 0
        Try
            Dim comand1 As New SqlCommand("VALIDAR_TRANSF_PRODUCCION", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = AUX
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COMP
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES0
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO0
            con.Open()
            C = comand1.ExecuteScalar()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If C = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VERIFICAR_TRANSF_ANALISIS(ByVal AUX As String, ByVal COMP As String, ByVal NRO_COMP As String, ByVal AÑO0 As String, ByVal MES0 As String) As Boolean
        Dim ESTADO As Boolean = True
        Dim C As Integer = 0
        Try
            Dim comand1 As New SqlCommand("VALIDAR_TRANSF_ANALISIS", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = AUX
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COMP
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES0
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO0
            con.Open()
            C = comand1.ExecuteScalar()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If C = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VERIFICAR_TRANSF_ANALISIS_DETALLE(ByVal AUX As String, ByVal COMP As String, ByVal NRO_COMP As String, ByVal AÑO0 As String, ByVal MES0 As String, ByVal ITEM0 As String) As Boolean
        Dim ESTADO As Boolean = True
        Dim C As Integer = 0
        Try
            Dim comand1 As New SqlCommand("VALIDAR_TRANSF_ANALISIS_DETALLE", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = AUX
            comand1.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COMP
            comand1.Parameters.Add("@NRO_COMP", SqlDbType.VarChar).Value = NRO_COMP
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES0
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO0
            comand1.Parameters.Add("@ITEM", SqlDbType.Char).Value = ITEM0
            con.Open()
            C = comand1.ExecuteScalar()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If C = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VERIFICAR_CIERRE_BANCOS(ByVal COD_BANCO0 As String, ByVal FE_AÑO0 As String, ByVal FE_MES0 As String) As Boolean
        Dim ESTADO As Boolean = True
        Try
            Dim comand1 As New SqlCommand("VERIFICAR_CIERRE_BANCOS", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = COD_BANCO0
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = FE_AÑO0
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = FE_MES0
            con.Open()
            ESTADO = comand1.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If ESTADO = Nothing Then ESTADO = False
        Return ESTADO
    End Function

    Public Function VERIFICAR_CIERRE_PERIODO(ByVal año00 As Object, ByVal mes00 As Object, ByVal mod00 As Object) As String
        Dim str As String = ""
        Try
            Dim command As New SqlCommand("VERIFICAR_CIERRE_PERIODO2", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = mod00
            command.Parameters.Add("@AÑO", SqlDbType.Char).Value = año00
            command.Parameters.Add("@MES", SqlDbType.Char).Value = mes00
            command.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "CIERRE"
            con.Open()
            str = (command.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If (str = "") Then
            str = " "
        End If
        Return str
    End Function

    Public Function VERIFICAR_BLOKEO_PERIODO(ByVal año00 As Object, ByVal mes00 As Object, ByVal mod00 As Object) As String
        Dim str As String = ""
        Try
            Dim command As New SqlCommand("VERIFICAR_CIERRE_PERIODO2", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = mod00
            command.Parameters.Add("@AÑO", SqlDbType.Char).Value = año00
            command.Parameters.Add("@MES", SqlDbType.Char).Value = mes00
            command.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = "BLOKEO"
            con.Open()
            str = (command.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If (str = "") Then
            str = " "
        End If
        Return str
    End Function

    Public Function VERIFICAR_CIERRE_CUENTAS(ByVal COD_CUENTA As String, ByVal FE_AÑO0 As String, ByVal FE_MES0 As String) As Boolean
        Dim I As Integer = 0
        Try
            Dim comand1 As New SqlCommand("VALIDAR_CIERRE_CUENTAS", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = COD_CUENTA
            comand1.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = FE_AÑO0
            comand1.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = FE_MES0
            con.Open()
            I = comand1.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If I = 0 Then
            Return True
        Else
            MessageBox.Show("La cuenta contable : " & COD_CUENTA & " se encuentra cerrada en el Período : " & FE_AÑO0 & " - " & FE_MES0, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
    End Function

    Public Function VERIFICAR_ELIMINAR_PCTAS_COBRAR(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object, ByVal CUENTA0 As Object) As Boolean
        Dim I As String = "NO"
        Try
            Dim PROG_01 As New SqlCommand("VALIDAR_ELIMINAR_CTAS_COBRAR", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC0
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER0
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = DOC_PER0
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = CUENTA0
            con.Open()
            I = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Select Case I
            Case Nothing
                I = "SI"
                Return True
                ' SOLO SE CAMBIO PARA LAS ANULADAS
            Case "SI"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Function VERIFICAR_ELIMINAR_PCTAS_PAGAR(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object, ByVal CUENTA0 As Object) As Boolean
        Dim I As String = "NO"
        Try
            Dim PROG_01 As New SqlCommand("VALIDAR_ELIMINAR_CTAS_PAGAR", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC0
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER0
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = DOC_PER0
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = CUENTA0
            con.Open()
            I = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Select Case I
            Case Nothing
                I = "SI"
                Return True
            Case "SI"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Function VERIFICAR_ELIMINAR_PCTAS_PAGAR_CONFIRMADA(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object, ByVal CUENTA0 As Object) As Boolean
        Dim I As String = "SI"
        Try
            Dim PROG_01 As New SqlCommand("VALIDAR_ELIMINAR_CONFIRMAR", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC0
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER0
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = DOC_PER0
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = CUENTA0
            con.Open()
            I = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        Select Case I
            Case Nothing
                Return True
            Case "SI"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Function VERIFICAR_NRO_MP(ByVal COD_MP As String, ByVal NRO_MP As String, ByVal COD_BANCO As String) As Boolean
        Dim I As String = "0"
        Try
            Dim comand1 As New SqlCommand("VALIDAR_NRO_MP", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = COD_MP
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = COD_BANCO
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = NRO_MP
            con.Open()
            I = comand1.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (I = "1") Then
            Return False
        End If
        Return True
    End Function

    Public Function VERIFICAR_CTA_ORIGEN_CPTO(ByVal CPTO00 As Object) As String
        Dim desc As String = ""
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_CTA_ORIGEN_CPTO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = Trim(CPTO00)
            con.Open()
            desc = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception


            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
        Return desc
    End Function

    Public Function VERIFICAR_NRO_MP_BANCO(ByVal COD_BAN As Object, ByVal COD_MP As Object, ByVal NRO_MP As Object) As Boolean
        Dim CONT As Integer = 0
        Try
            Dim comand1 As New SqlCommand("VALIDAR_NRO_MP_IBANCO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@COD_BANCO", SqlDbType.VarChar).Value = (COD_BAN)
            comand1.Parameters.Add("@COD_MP", SqlDbType.VarChar).Value = (COD_MP)
            comand1.Parameters.Add("@NRO_MP", SqlDbType.VarChar).Value = (NRO_MP)
            con.Open()
            CONT = Integer.Parse(comand1.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (CONT = 0) Then
            Return True
        End If
        MessageBox.Show("El Nº de Medio de Pago ya existe en para ese Banco.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    Public Function VERIFICAR_PCTAS_COBRAR(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object, ByVal CUENTA0 As Object) As Boolean
        Dim I As Integer = 0
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_PCTAS_COBRAR", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (COD_DOC0)
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = (NRO_DOC0)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER0)
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = (DOC_PER0)
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = (CUENTA0)
            con.Open()
            I = Integer.Parse(PROG_01.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If I = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VERIFICAR_PCTAS_PAGAR(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object, ByVal CUENTA0 As Object) As Boolean
        Dim I As Integer = 0
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_PCTAS_PAGAR", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC0
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC0
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER0
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = DOC_PER0
            PROG_01.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = CUENTA0
            con.Open()
            I = Integer.Parse(PROG_01.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If I = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VERIFICAR_PERIODO(ByVal TIPO0 As String) As Boolean
        Dim ESTADO0 As Boolean = True
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_CIERRE_PERIODO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            PROG_01.Parameters.Add("@MES", SqlDbType.Char).Value = MES
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO0
            con.Open()
            ESTADO0 = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        'If ESTADO0 = Nothing Then ESTADO0 = True
        Return ESTADO0
    End Function

    Public Function VERIFICAR_REG_COMPRAS(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object) As Boolean
        Dim I As Integer = 0
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_REG_COMPRAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (COD_DOC0)
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = (NRO_DOC0)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER0)
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = (DOC_PER0)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            I = Integer.Parse(PROG_01.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If I = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VERIFICAR_REG_HONORARIO(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object) As Boolean
        Dim I As Integer = 0
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_REG_VENTAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (COD_DOC0)
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = (NRO_DOC0)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER0)
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = (DOC_PER0)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            I = Integer.Parse(PROG_01.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If I = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VERIFICAR_REG_VENTAS(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object) As Boolean
        Dim I As Integer = 0
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_REG_VENTAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (COD_DOC0)
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = (NRO_DOC0)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER0)
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = (DOC_PER0)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            I = Integer.Parse(PROG_01.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If I = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VERIFICAR_I_CON(ByVal COD_AUX As Object, ByVal COD_COMP As Object, ByVal NRO_COMP As Object, ByVal FE_AÑO0 As Object, ByVal FE_MES0 As Object) As Boolean
        Dim I As Integer = 0
        Try
            Dim PROG_01 As New SqlCommand("VERIFICAR_I_CON", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            PROG_01.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
            PROG_01.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = NRO_COMP
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = FE_AÑO0
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = FE_MES0
            con.Open()
            I = Integer.Parse(PROG_01.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
        If I = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function SEGURIDAD_FORM(ByVal COD_FORM0 As Object) As Boolean
        Dim ESTADO As Boolean = True
        Try
            Dim PROG_01 As New SqlCommand("SEGURIDAD_FORM", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_FORM", SqlDbType.Char).Value = COD_FORM0
            PROG_01.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
            con.Open()
            PROG_01.ExecuteNonQuery()
            ESTADO = PROG_01.ExecuteReader.HasRows
        Catch ex As Exception
            ESTADO = False
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        If (Module01.TIPO_USU = "US") Then
            Return ESTADO
        End If
        Return True
    End Function

    Public Function Encriptar(ByVal valor As String)
        'Crear una clave SHA1
        Dim encod As New UTF8Encoding
        Dim Buffer As Byte() = encod.GetBytes(valor)
        Dim Result As Byte()
        Dim sha As New SHA1CryptoServiceProvider
        'Implementación de la clase Abstracta SHA1.
        Result = sha.ComputeHash(Buffer)
        'Convertir los valores en hexadecimal, Si tiene una cifra se 
        'rellena con cero para para que ocupe dos dígitos.
        Dim sb As New StringBuilder
        For i As Integer = 0 To Result.Length - 1
            If Result(i) < 16 Then
                sb.Append("0")
            End If
            sb.Append(Result(i).ToString("x"))
        Next
        Return sb.ToString().ToUpper()
    End Function

    Public Function HALLAR_DIR_PER(ByVal COD_PER0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_DIRECCION_PER", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER0
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = Rs3.GetValue(0)
                Loop
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HALLAR_DIRECCION_PERSONA(ByVal COD_PER0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_DIRECCION_PER2", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER0
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = Rs3.GetValue(0)
                Loop
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function HallarDireccionPersona(ByVal codigoPersona As Object, ByVal codigoTipo As Object) As String()
        Dim direccion() As String
        Try
            con.Open()
            Dim command As New SqlCommand("HALLAR_DIRECCION_PERSONA", con)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (codigoPersona)
            command.Parameters.Add("@COD_TIPO", SqlDbType.Char).Value = (codigoTipo)
            Dim reader As SqlDataReader = command.ExecuteReader()
            If Not IsNothing(reader) AndAlso reader.HasRows Then
                ReDim direccion(5)
                reader.Read()
                direccion(0) = IIf(String.IsNullOrEmpty(reader("Ubigeo").ToString().Trim), "000000", reader("Ubigeo"))
                direccion(1) = reader("Direccion")
                direccion(2) = reader("Departamento")
                direccion(3) = reader("Provincia")
                direccion(4) = reader("Distrito")
                direccion(5) = reader("Pais")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        Return direccion
    End Function

    Public Function HALLAR_SERVICIO_PRESTADO(ByVal COD_PER0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_SERVICIO_PRESTADO", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER0
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = Rs3.GetValue(0)
                Loop
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Public Function TamañoPapel(ByVal NombreFormulario As String) As Integer
        Dim i As Integer
        Dim oPrint As New System.Drawing.Printing.PrintDocument()
        Dim rawKind As Integer
        For i = 0 To oPrint.PrinterSettings.PaperSizes.Count - 1
            If oPrint.PrinterSettings.PaperSizes(i).PaperName.ToUpper = NombreFormulario.ToUpper Then
                rawKind = CInt(oPrint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", _
                Reflection.BindingFlags.Instance Or _
                Reflection.BindingFlags.NonPublic).GetValue(oPrint.PrinterSettings.PaperSizes(i)))
                Exit For
            End If
        Next
        Return rawKind
    End Function

    Public Sub CambiarFicha(ByVal Tab As TabControl, ByVal Ficha As TabPage, _
    Optional ByVal FichaSelecciona As Object = Nothing, Optional ByVal Mostrar As Boolean = False)
        If Mostrar Then
            Ficha.Parent = Tab
            Tab.SelectedTab = Ficha
        Else
            Ficha.Parent = Nothing
            If FichaSelecciona IsNot Nothing Then
                Tab.SelectedTab = DirectCast(FichaSelecciona, TabPage)
            End If
        End If
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="añoPle">Año de Libro Electrónico</param>
    ''' <param name="mesPle">Mes Libro Electrónico</param>
    ''' <param name="tipoPle">Tipo Libro Electrónico(Compras-Ventas-Diario-Mayor)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Function ObtenerItemPleAnterior(ByVal añoPle As String, ByVal mesPle As String, ByVal tipoPle As String) As String
        Dim NUM As Integer = 0
        Try
            Dim pro03 As New SqlCommand("PLE_OBTENER_ITEM_ANTERIOR", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@TIPO_PLE", SqlDbType.Char).Value = tipoPle
            pro03.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = añoPle
            pro03.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mesPle
            con.Open()
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = 0
            Else
                Rs3.Read()
                Integer.TryParse(Rs3.GetValue(0), NUM)
            End If
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    'Public Sub EscribirLogError(ByVal log As LogUsuario)
    '    Dim sb As New StringBuilder
    '    sb.AppendLine(String.Format("Usuario : {0}", log.Usuario))
    '    sb.AppendLine(String.Format("Nombre PC: {0}", log.NombrePc))
    '    sb.AppendLine(String.Format("Fecha: {0}", log.FechaError))
    '    sb.AppendLine(String.Format("Descripcion Error: {0}", log.Descripcion))
    '    sb.AppendLine(New String("=", 40))
    '    Using fs As New FileStream(String.Format("{0}\LogError.txt", Application.StartupPath), FileMode.Append, FileAccess.Write)
    '        Using sw As New StreamWriter(fs)
    '            sw.Write(sb.ToString)
    '        End Using
    '    End Using
    'End Sub

    Public Sub ExportarExcel(ByVal oDataGridview As DataGridView, ByVal columnas As List(Of String), _
               Optional ByVal mostrarTitulos As Boolean = False, Optional ByVal titulos As Dictionary(Of String, String) = Nothing)
        Dim obj_excel As Object
        Dim obj_hoja As Object
        Dim obj_libro As Object
        Dim letexcel() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Try
            obj_excel = CreateObject("Excel.Application")
            obj_libro = obj_excel.Workbooks.Add()
            obj_hoja = obj_libro.Worksheets(1)
            '-------------------------------------
            'cabecera
            '-------------------------------------
            obj_excel.DisplayAlerts = False

            Dim strRango As String
            obj_hoja.Cells.Font.Name = "Arial Narrow"
            obj_hoja.Cells.Font.Size = "9"

            strRango = "A1:B1"
            obj_hoja.Range(strRango).Merge()
            obj_hoja.Range(strRango).NumberFormat = "@"
            obj_hoja.Range(strRango).Font.Bold = True
            obj_hoja.Cells(1, 1) = DESC_EMPRESA

            strRango = "A2:B2"
            obj_hoja.Range(strRango).Merge()
            obj_hoja.Range(strRango).NumberFormat = "@"
            obj_hoja.Range(strRango).Font.Bold = True

            strRango = "A3:B3"
            obj_hoja.Range(strRango).Merge()
            obj_hoja.Range(strRango).NumberFormat = "@"
            obj_hoja.Range(strRango).Font.Bold = True
            obj_hoja.Cells(3, 1) = "AL: " & frm_mes & " DEL " & frm_año

            strRango = "D2:I2"
            obj_hoja.Range(strRango).Merge()
            obj_hoja.Range(strRango).NumberFormat = "@"
            obj_hoja.Range(strRango).Font.Bold = True
            obj_hoja.Range(strRango).VerticalAlignment = -4108
            obj_hoja.Range(strRango).HorizontalAlignment = -4108
            obj_hoja.Range(strRango) = "Pendientes Cuentas Por Cobrar"

            strRango = "D3:I3"
            obj_hoja.Range(strRango).Merge()
            obj_hoja.Range(strRango).NumberFormat = "@"
            obj_hoja.Range(strRango).Font.Bold = True
            obj_hoja.Range(strRango).VerticalAlignment = -4108
            obj_hoja.Range(strRango).HorizontalAlignment = -4108

            obj_hoja.Cells(2, 1) = Module01.RUC_EMPRESA
            strRango = "A4:C4"
            obj_hoja.Range(strRango).Merge()
            obj_hoja.Range(strRango).Font.Bold = True
            '-------------------------------------
            '-------------------------------------
            Dim fila As Integer = 5
            If Not IsNothing(titulos) AndAlso titulos.Count > 0 AndAlso mostrarTitulos Then
                For Each item As KeyValuePair(Of String, String) In titulos
                    obj_hoja.Range("A" & fila).value = item.Key
                    obj_hoja.Range("A" & fila).Font.Bold = True
                    obj_hoja.Range("B" & fila).value = item.Value
                    fila += 1
                Next
            End If

            Dim i As Integer

            For i = 0 To columnas.Count - 1
                obj_hoja.Range(String.Format("{0}{1}", letexcel(i), fila)).Value = columnas(i)
            Next
            obj_hoja.Range(String.Format("A{0}:{1}{0}", fila, letexcel(i - 1))).Font.Bold = True
            obj_hoja.Range(String.Format("A{0}:{1}{0}", fila, letexcel(i - 1))).Cells.BorderAround(1, 2)
            obj_hoja.Range(String.Format("A{0}:{1}{0}", fila, letexcel(i - 1))).Interior.Pattern = 1
            obj_hoja.Range(String.Format("A{0}:{1}{0}", fila, letexcel(i - 1))).Interior.ColorIndex = 49
            obj_hoja.Range(String.Format("A{0}:{1}{0}", fila, letexcel(i - 1))).Font.ColorIndex = 2
            obj_hoja.Range(String.Format("A{0}:{1}{0}", fila, letexcel(i - 1))).VerticalAlignment = -4108
            obj_hoja.Range(String.Format("A{0}:{1}{0}", fila, letexcel(i - 1))).HorizontalAlignment = -4108
            'obj_hoja.range(String.Format("A{0}:{1}{0}", fila, letexcel(i - 1))).Select()
            'With obj_excel.Selection.Interior
            '    .ColorIndex = 24
            'End With

            fila += 1
            Dim Columna As Integer
            Dim FilaAux As Integer = 0
            obj_hoja.Range(String.Format("A{0}:{1}{2}", fila, letexcel(columnas.Count - 1), (oDataGridview.RowCount - 1) + fila)).Cells.BorderAround(1, 2)
            obj_hoja.Range(String.Format("A{0}:{1}{2}", fila, letexcel(columnas.Count - 1), (oDataGridview.RowCount - 1) + fila)).Interior.ColorIndex = 2
            For Each row As DataGridViewRow In oDataGridview.Rows
                For Columna = 0 To columnas.Count - 1
                    Dim z As Integer = 0
                    For Each col As DataGridViewColumn In oDataGridview.Columns
                        If columnas(Columna) = col.HeaderText Then
                            If row.Cells(col.Name).Value.GetType Is GetType(String) Then
                                obj_hoja.range(String.Format("{0}{1}", letexcel(Columna), fila)).value = "'" & row.Cells(col.Name).Value
                            Else
                                obj_hoja.range(String.Format("{0}{1}", letexcel(Columna), fila)).value = row.Cells(col.Name).Value
                            End If
                            obj_hoja.range(String.Format("{0}{1}", letexcel(Columna), fila)).Select()
                            If FilaAux Mod 2 = 1 Then
                                With obj_excel.Selection.Interior
                                    .ColorIndex = 15
                                End With
                            End If
                        End If
                        z += 1
                    Next
                Next
                FilaAux += 1
                fila += 1
            Next
            obj_hoja.Columns.AutoFit()
            obj_hoja.range("A1").Select()
            obj_excel.Visible = True
        Catch ex As Exception
            MessageBox.Show(String.Format("Error al crear archivo. {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub SerializarLog(ByVal log As LogUsuario)
        Try
            Dim list As List(Of LogUsuario) = DesSerializarLog()
            list.Add(log)
            Dim ExeFile As String = New Uri(Assembly.GetEntryAssembly().CodeBase).AbsolutePath
            Dim ExeDir As String = Path.GetDirectoryName(ExeFile)
            Dim archivo As String = Path.Combine(ExeDir, "..\LogError.gco")
            Using fs As New FileStream(archivo, FileMode.Create, FileAccess.Write)
                Dim formatter As New BinaryFormatter
                formatter.Serialize(fs, list)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Function DesSerializarLog() As List(Of LogUsuario)
        Dim list As New List(Of LogUsuario)
        Dim ExeFile As String = New Uri(Assembly.GetEntryAssembly().CodeBase).AbsolutePath
        Dim ExeDir As String = Path.GetDirectoryName(ExeFile)
        Dim archivo As String = Path.Combine(ExeDir, "..\LogError.gco")
        If File.Exists(archivo) Then
            Try
                Using fs As New FileStream(archivo, FileMode.Open, FileAccess.Read, FileShare.Read)
                    If fs.Length > 0 Then
                        Dim formatter As New BinaryFormatter
                        list = formatter.Deserialize(fs)
                    End If

                End Using
            Catch ex As Exception
            End Try
        End If
        list.Sort(AddressOf OrdenarLog)
        Return list
    End Function

    Private Shared Function OrdenarLog(ByVal x As LogUsuario, ByVal y As LogUsuario) As Integer
        Return x.FechaLog.CompareTo(y.FechaLog) * -1
    End Function

    Public Function PRECIO_UNITARIO(ByVal CADENA As Object) As Object
        Return Format(CDec(CADENA), "###,###,###,##0.00")
    End Function
    Function UltimoDiaDelMes(ByVal añoActual As Integer, ByVal mesActual As Integer) As String
        Dim dia As String = "00"
        Try
            dia = DateSerial(añoActual, mesActual + 1, 0).Day.ToString("00")
        Catch ex As Exception
        End Try
        Return dia
    End Function

    Public Function HALLAR_CODIGO_PERSONA(ByVal NRO_DOC As String)
        Dim cod As String = String.Empty
        Try
            Dim cmd As New SqlCommand("HALLAR_CODIGO_PERSONA", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
            con.Open()
            cod = cmd.ExecuteScalar
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return cod
    End Function
    Public Function BUSCAR_CUENTA_COB(ByVal COD_CPTO As String) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("BUSCAR_CUENTA_COBRANZA", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@COD_CPTO", SqlDbType.VarChar).Value = COD_CPTO
            con.Open()
            NUM = pro03.ExecuteScalar
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
        If (NUM Is Nothing) Then
            NUM = ""
        End If
        Return NUM.ToString
    End Function
    Public Function RecuperarTipoCambio(ByVal año As String, ByVal mes As Integer, ByVal CodigoModulo As String) As Double
        Dim TC As Double
        Try
            Dim cmd As New SqlCommand("RECUPERAR_TIPO_CAMBIO", con2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = mes.ToString("00")
            cmd.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = CodigoModulo
            con2.Open()
            TC = CDbl(cmd.ExecuteScalar)
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If TC = Nothing Then
            TC = 0
        End If
        Return TC
    End Function

    Public Function RecuperarCodigoMonedaDocumento(ByVal Año As String, ByVal Mes As String, _
                                                   ByVal CodigoDocumento As String, ByVal NumeroDocumento As String)
        Dim CodigoMoneda As String = String.Empty
        Try
            Dim cmd As New SqlCommand("RECUPERAR_MONEDA_DOCUMENTO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = Año
            cmd.Parameters.Add("@MES", SqlDbType.Char).Value = Mes
            cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = CodigoDocumento
            cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NumeroDocumento
            con.Open()
            CodigoMoneda = cmd.ExecuteScalar
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If CodigoMoneda = Nothing Then CodigoMoneda = ""
        Return CodigoMoneda
    End Function

    Public Function RecuperarNumeroDocumentoPersona(ByVal CodigoPersona As String) As String
        Dim NumeroDocumento As String = String.Empty
        Try
            Dim cmd As New SqlCommand("RECUPERAR_NRO_DOC_PERSONA", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = CodigoPersona
            con.Open()
            NumeroDocumento = cmd.ExecuteScalar
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If NumeroDocumento = Nothing Then NumeroDocumento = ""
        Return NumeroDocumento
    End Function
    Public Function DesencriptarFecha(ByVal Input As Object)
        'Desencriptacion a Evaluar
        Dim IV() As Byte = ASCIIEncoding.ASCII.GetBytes("qualityi") 'La clave debe ser de 8 caracteres
        Dim EncryptionKey() As Byte = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5") 'No se puede alterar la cantidad de caracteres pero si la clave
        Dim buffer() As Byte = Convert.FromBase64String(Input)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        des.Key = EncryptionKey
        des.IV = IV
        Return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
    End Function
    Public Function ValidarCierreCuentas(ByVal Tipo As String, ByVal Año As String, ByVal Mes As String)
        Dim st As String = String.Empty
        'Dim key As String = False
        Using cmd As New SqlCommand("VALIDAR_CIERRE_CTAS_CTBLE", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = "COI"
            cmd.Parameters.Add("@TIPO", SqlDbType.Char).Value = Tipo
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = Año
            cmd.Parameters.Add("@MES", SqlDbType.Char).Value = Mes
            Try
                con.Open()
                st = cmd.ExecuteScalar
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
            If st = Nothing Then
                st = 0
            End If

            If st = 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

    Public Function HallarWebEmpresa(ByVal codigoEmpresa As Object) As String
        Dim Web As String = ""
        Try
            con2.Open()
            Dim command As New SqlCommand("HALLAR_WEB_EMPRESA", con2)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@COD_EMPRESA", SqlDbType.Char).Value = (codigoEmpresa)
            Web = command.ExecuteScalar
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con2.Close()
        End Try
        Return Web
    End Function
End Class
