Imports System.IO
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class ImportarPlanilla
    Private OBJ As New Class1
    Private ruta As String
    Private arch As String
    Private ext As String
    Private sql As String
    Private COD_AUX As String
    Private COD_COMP As String
    Private COD_DOC, NRO_DOC As String
    Private COD_PER, DESC_PER As String
    Private COD_DH_DOC, COD_MONEDA As String
    Private FECHA_VEN As DateTime
    Private TCAMBIO As Decimal
    Private _generaAuto As Boolean = False
    'Dim _tipoTrans As String = ""
    'Dim _ordenCta As String = ""
    Dim DT_DET As New DataTable


    Sub CREAR_DATASET()
        DT_DET.Columns.Add("FE_AÑO")
        DT_DET.Columns.Add("FE_MES")
        DT_DET.Columns.Add("COD_AUX")
        DT_DET.Columns.Add("COD_COMP")
        DT_DET.Columns.Add("NRO_COMP")
        DT_DET.Columns.Add("COD_DOC")
        DT_DET.Columns.Add("NRO_DOC")
        DT_DET.Columns.Add("COD_PER")
        DT_DET.Columns.Add("NRO_DOC_PER")
        DT_DET.Columns.Add("ITEM")
        DT_DET.Columns.Add("FECHA_DOC")
        DT_DET.Columns.Add("COD_REF")
        DT_DET.Columns.Add("NRO_REF")
        DT_DET.Columns.Add("FECHA_REF")
        DT_DET.Columns.Add("GLOSA")
        DT_DET.Columns.Add("COD_CTA")
        DT_DET.Columns.Add("IMP_S")
        DT_DET.Columns.Add("IMP_D")
        DT_DET.Columns.Add("COD_D_H")
        DT_DET.Columns.Add("COD_MONEDA")
        DT_DET.Columns.Add("TIPO_CAMBIO")
        DT_DET.Columns.Add("COD_CC")
        DT_DET.Columns.Add("COD_CONTROL")
        DT_DET.Columns.Add("COD_PROYECTO")
        DT_DET.Columns.Add("NRO_ORDEN")
        DT_DET.Columns.Add("FECHA_VEN")
        DT_DET.Columns.Add("STATUS_PRECIO")
        DT_DET.Columns.Add("CUENTA_ENLACE")
        DT_DET.Columns.Add("CUENTA_DESTINO")
        DT_DET.Columns.Add("STATUS_AUTO")
        DT_DET.Columns.Add("TIPO_TRANS")
        DT_DET.Columns.Add("STATUS_ANALISIS")
        DT_DET.Columns.Add("STATUS_PAGO")
        DT_DET.Columns.Add("COD_MP")
        DT_DET.Columns.Add("NRO_MP")
        DT_DET.Columns.Add("FECHA_MP")
        DT_DET.Columns.Add("ITEM_PAGO")
        DT_DET.Columns.Add("COD_BANCO_DEST")
        DT_DET.Columns.Add("STATUS_TRANS")
        DT_DET.Columns.Add("FECHA_COM")
        DT_DET.Columns.Add("POR_IGV")
        DT_DET.Columns.Add("NOMBRE_PC")
        DT_DET.Columns.Add("STATUS_REP")
        DT_DET.Columns.Add("COD_ACTIVIDAD")
    End Sub

    Function Leer(ByVal path As String) As String
        Try
            Dim oSR As StreamReader = New StreamReader(path)
            Dim l As String
            Dim tempSTR As String = ""
            l = oSR.ReadLine()
            While Not l Is Nothing
                tempSTR = tempSTR & l & vbNewLine
                l = oSR.ReadLine() ' lee la siguiente   
            End While
            oSR.Close()
            oSR.Dispose()
            Return tempSTR
        Catch oe As Exception
            Return ""
            MsgBox(oe.Message)
        End Try
    End Function

    Function ValidaCuenta() As Boolean
        'VERIFICAR SI EXISTE LA CUENTA
        Dim _Existe As Boolean = True
        Dim I, J, x As Integer
        Try
            con.Open()
            For I = 0 To DG.Rows.Count - 1
                x = 0
                Dim filas As Integer
                Dim cmd As New SqlCommand("SELECT COUNT(*) FROM MAESTRO_CUENTAS WHERE COD_CUENTA='" & _
                DG.Item(0, I).Value & "' AND AÑO='" & AÑO & "'", con)
                filas = CType(cmd.ExecuteScalar(), Integer)
                If filas < 0 Then
                    _Existe = False
                End If
                If _Existe Then
                    If DG.Item(0, I).Value.ToString.Substring(0, 1) = 9 Then
                        For J = 13 To 14
                            cmd = New SqlCommand("SELECT COUNT(*) FROM MAESTRO_CUENTAS WHERE COD_CUENTA='" & _
                            DG.Item(J, I).Value & "' AND AÑO='" & AÑO & "'", con)
                            filas = CType(cmd.ExecuteScalar(), Integer)
                            If filas < 0 Then
                                _Existe = False
                            End If
                        Next
                    End If
                End If
                If Not _Existe Then
                    DG.Rows(I).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
            ValidaCuenta = _Existe
        Catch ex As Exception
            Throw New Exception(ex.Message)
            ValidaCuenta = False
        Finally
            con.Close()
        End Try
    End Function

    Function ValidaFecha() As Boolean
        Dim _i As Integer = 0
        Dim _vale As Boolean = True
        Try
            For _i = 0 To DG.Rows.Count - 1
                If DG.Item(27, _i).Value <> MES _
                And (DG.Item(28, _i).Value <> AÑO _
                Or DG.Item(28, _i).Value = AÑO) Then
                    _vale = False
                    DG.Rows(_i).DefaultCellStyle.ForeColor = Color.Red
                End If
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
            _vale = False
        End Try
        Return _vale
    End Function

    Public Sub CBO_AUXILIAR()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally
            con.Close()
        End Try
    End Sub

    Public Sub CBO_COMPROBANTE()
        cbo_com.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_com.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception

            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (cbo_com.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    'Sub ActualizaNumeracion(ByVal AUX As String, ByVal COMP As String, ByVal NRO_COMP As String)
    '    Dim Csql As String
    '    Csql = " Update NRO_COMPROBANTE SET NUMERACION=right('0000' + rtrim(ltrim(str(" & NRO_COMP & "+1))),4)" & _
    '    " WHERE AÑO='" & AÑO & "' AND MES='" & MES & "' AND COD_AUX='" & AUX & "' AND COD_COMP='" & COMP & "'"
    '    Dim cmd As New SqlCommand(Csql, con)
    '    Try
    '        cmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Throw New Exception("Error al generar el nuevo numero" & vbNewLine & ex.Message)
    '    End Try
    'End Sub

    Sub GENERAR_AUTO()
        Try
            Dim cont_r1 As Integer = DG.RowCount
            Dim CONT As Integer = (cont_r1 - 1)
            Dim j As Integer = 0
            Do While (j <= CONT)
                Dim var0 As String = (DG.Item(0, j).Value)
                Dim var1 As String = (DG.Item(1, j).Value)
                Dim var2 As Decimal = Decimal.Parse(DG.Item(2, j).Value)
                Dim var3 As Decimal = Decimal.Parse(DG.Item(3, j).Value)
                Dim var4 As String = (DG.Item(4, j).Value)
                Dim var5 As String = (DG.Item(5, j).Value)
                Dim var6 As Decimal = Decimal.Parse(DG.Item(6, j).Value)
                Dim var7 As String = (DG.Item(7, j).Value)
                Dim var8 As String = (DG.Item(8, j).Value)
                Dim var9 As String = (DG.Item(9, j).Value)
                Dim var10 As String = (DG.Item(10, j).Value)
                Dim var11 As String = (DG.Item(11, j).Value)
                Dim var12 As String = (DG.Item(12, j).Value)
                Dim var13 As String = (DG.Item(13, j).Value)
                Dim var14 As String = (DG.Item(14, j).Value)
                Dim var23 As String = (DG.Item(23, j).Value)
                Dim var24 As String = (DG.Item(24, j).Value)
                Dim var25 As String = (DG.Item(27, j).Value)
                Dim var26 As String = (DG.Item(28, j).Value)
                If (var23.Length = 8) Then
                    Dim cod_enlace As String = ""
                    Dim cod_destino As String = ""
                    If (var4 = "D") Then
                        cod_enlace = "H"
                        cod_destino = "D"
                    ElseIf (var4 = "H") Then
                        cod_enlace = "D"
                        cod_destino = "H"
                    End If
                    DG.Rows.Add(var23, var1, var2, var3, cod_enlace, var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, "", "", "", "", "", "", "", "1", "", "", "0", "", var25, var26)
                    DG.Rows.Add(var24, var1, var2, var3, cod_destino, var5, var6, var7, var8, var9, var10, var11, var12, var13, var14, "", "", "", "", "", "", "", "1", "", "", "0", "", var25, var26)
                End If
                j += 1
            Loop
            _generaAuto = True
        Catch ex As Exception
            _generaAuto = False
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function INSERTAR_TODO() As String
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (DG.RowCount - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            If DG.Item(28, I).Value = "" Or IsDBNull(DG.Item(28, I).Value) Then
                DG.Rows(I).DefaultCellStyle.ForeColor = Color.Red
            End If
            DT_DET.Rows.Add((DG.Item(28, I).Value), (DG.Item(27, I).Value), COD_AUX, COD_COMP, txt_nro_comp.Text, _
            (DG.Item(7, I).Value), (DG.Item(8, I).Value), (DG.Item(10, I).Value), (DG.Item(12, I).Value), (I + 1).ToString("0000"), _
            DateTime.Parse((DG.Item(9, I).Value)), "", "", DateTime.Parse((DG.Item(9, I).Value)), (DG.Item(1, I).Value), _
            (DG.Item(0, I).Value), Decimal.Parse((DG.Item(2, I).Value)), Decimal.Parse((DG.Item(3, I).Value)), (DG.Item(4, I).Value), _
            (DG.Item(5, I).Value), Decimal.Parse((DG.Item(6, I).Value)), (DG.Item(15, I).Value), (DG.Item(16, I).Value), _
            (DG.Item(17, I).Value), "", DateTime.Parse((DG.Item(9, I).Value)), "0", DG.Item(23, I).Value.ToString, _
            DG.Item(24, I).Value.ToString, DG.Item(22, I).Value.ToString, "", "0", "0", "", "", DateTime.Parse((DG.Item(9, I).Value)), _
            0, "", DG.Item(21, I).Value.ToString, dtp_com.Value, 0, NOMBRE_PC, DG.Item(25, I).Value, DG.Item(26, I).Value)
            I += 1
        Loop
        Try
            con.Open()
            sqlbc.DestinationTableName = "dbo.T_CON2"
            sqlbc.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
            Return estado
        End Try
        Try
            Dim comand1 As New SqlCommand("INSERTAR_I_CON_DIARIO", con)
            comand1.CommandType = CommandType.StoredProcedure
            comand1.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            comand1.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            comand1.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            comand1.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = dtp_com.Value.ToShortDateString
            comand1.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            comand1.Parameters.Add("@fecha", SqlDbType.DateTime).Value = Now.Date
            comand1.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            comand1.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = MES
            comand1.Parameters.Add("@NOMBRE_PC", SqlDbType.VarChar).Value = NOMBRE_PC
            con.Open()
            estado = (comand1.ExecuteScalar)
            'comand1.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            estado = "FALLO"
            Throw New Exception(ex.Message)
        End Try
        Return estado
    End Function

    Sub ELIMINAR_AUTO()
        Dim I As Integer = 0
        Dim CONT As Integer = (DG.RowCount - 1)
        Do While (I <= CONT)
            If DG.Item(22, I).Value = "1" Then
                DG.Rows.RemoveAt(I)
                I = 0
                CONT = (DG.RowCount - 1)
            Else
                I += 1
            End If
        Loop
    End Sub

    Function HALLAR_NRO_COMP(ByVal COD_AUX0 As Object, ByVal COD_COMP0 As Object, ByVal AÑO0 As Object, ByVal MES0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_NRO_COMP", con)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO0
            pro03.Parameters.Add("@MES", SqlDbType.VarChar).Value = MES0
            pro03.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX0
            pro03.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP0
            pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = Rs3.GetValue(0)
                Loop
                Rs3.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Private Sub Btn_Abrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Abrir.Click
        If Len(ruta) = 0 Then
            ruta = "D:\"
        End If
        If Len(arch) = 0 Then
            arch = ""
        End If
        DialogOpen.InitialDirectory = ruta
        DialogOpen.FileName = arch
        DialogOpen.Filter = "Archivo de texto (*.txt)|*.txt"
        'DialogOpen.Filter = "Archivo de texto (*.txt)|*.txt|Archivos DBF (Microsoft Visual FoxPro Driver *.dbf)|*.dbf"
        DialogOpen.FilterIndex = 2
        DialogOpen.RestoreDirectory = False
        If DialogOpen.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txt_Datos.Text = DialogOpen.FileName
            ruta = IO.Path.GetDirectoryName(DialogOpen.FileName)
            arch = IO.Path.GetFileName(DialogOpen.FileName)
            ext = IO.Path.GetExtension(DialogOpen.FileName)
        End If
        txt_Esquema.Text = Leer(Application.StartupPath + "\servidor\schema.ini")
    End Sub

    Private Sub Btn_Cargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cargar.Click
        TCAMBIO = OBJ.SACAR_CAMBIO2(dtp_com.Value.Year, dtp_com.Value.ToString("MM"), dtp_com.Value.ToString("dd"), "D")
        If TCAMBIO = 0 Then
            MessageBox.Show("Verifique el tipo de cambio mensual para este proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Seleccionar el Auxiliar", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Seleccionar el Comprobante", "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If ext.ToLower = ".txt" Then
            If File.Exists(ruta + "\schema.ini") Then
                Dim SW As StreamWriter = Nothing
                Try
                    SW = File.CreateText(ruta + "\schema.ini")
                    SW.Write(txt_Esquema.Text)
                    SW.Flush()
                Catch exc As Exception
                    MsgBox(exc.Message)
                Finally
                    If Not SW Is Nothing Then
                        SW.Close()
                    End If
                End Try
            Else
                Dim oSW As New StreamWriter(ruta + "\schema.ini")
                Dim Linea As String = txt_Esquema.Text
                Try
                    oSW.WriteLine(Linea)
                    oSW.Flush()
                Catch exc As Exception
                    MsgBox(exc.Message)
                Finally
                    If Not oSW Is Nothing Then
                        oSW.Close()
                    End If
                End Try
            End If
            Dim cnn As OleDbConnection
            Try
                Me.Cursor = Cursors.WaitCursor
                DG.DataSource = Nothing
                cnn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" & _
                     "Data Source=" + ruta + ";" & _
                     "Extended Properties='TEXT;FMT=Fixed'")
                Dim soles, dolares As Decimal
                Dim sql As String = "SELECT * FROM " + arch
                Dim CMD As New OleDbCommand(sql, cnn)
                CMD.CommandType = CommandType.Text
                cnn.Open()
                Dim RS As OleDbDataReader = CMD.ExecuteReader
                Dim i As Integer = 1
                Do While RS.Read
                    If (RS.GetValue(8) = "S") Then
                        soles = RS.GetValue(4)
                        dolares = Math.Round(RS.GetValue(4) / TCAMBIO, 2)
                    Else
                        soles = Math.Round(RS.GetValue(4) * TCAMBIO, 2)
                        dolares = RS.GetValue(4)
                    End If
                    DG.Rows.Add(RS.GetValue(0), RS.GetValue(9), soles, dolares, RS.GetValue(5), RS.GetValue(8), TCAMBIO, _
                    IIf(IsDBNull(RS.GetValue(1)), IIf(IsDBNull(RS.GetValue(2)), "", "00"), RS.GetValue(1)), IIf(IsDBNull(RS.GetValue(2)), "", RS.GetValue(2)), _
                    RS.GetValue(3), IIf(IsDBNull(RS.GetValue(6)), "", RS.GetValue(6)), "", IIf(IsDBNull(RS.GetValue(7)), "", RS.GetValue(7)), _
                    IIf(IsDBNull(RS.GetValue(10)), "", RS.GetValue(10)), IIf(IsDBNull(RS.GetValue(11)), "", RS.GetValue(11)), _
                    IIf(IsDBNull(RS.GetValue(12)), "", RS.GetValue(12)), "", "", IIf(IsDBNull(RS.GetValue(12)), "0", "1"), _
                    "1", "0", IIf(RS.GetValue(15) = "1", "P", IIf(RS.GetValue(15) = "1", "C", "")), "0", IIf(IsDBNull(RS.GetValue(13)), "", RS.GetValue(13)), _
                    IIf(IsDBNull(RS.GetValue(14)), "", RS.GetValue(14)), "0", "", IIf(IsDBNull(RS.GetValue(16)), "", RS.GetValue(16)), _
                    IIf(IsDBNull(RS.GetValue(17)), "", RS.GetValue(17)))
                    i += 1
                Loop
                Me.Cursor = Cursors.Default
                Dim archivo As String = ruta + "\schema.ini"
                My.Computer.FileSystem.DeleteFile(archivo, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            Catch ex As Exception
                MsgBox("Error al leer el archivo" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
                DG.Rows.Clear()
                Me.Cursor = Cursors.Default
            Finally
                cnn.Close()
            End Try
        Else
        End If
    End Sub

    Private Sub Btn_Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Salir.Click
        main(103) = 0
        Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Dim Soles As Decimal = 0
        Dim Dolares As Decimal = 0
        Me.Cursor = Cursors.WaitCursor
        If (cbo_aux.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_aux.Focus()
        ElseIf (cbo_com.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbo_com.Focus()
        ElseIf (txt_nro_comp.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_nro_comp.Focus()
        ElseIf (DG.RowCount = 0) Then
            MessageBox.Show("Comprobante sin Detalles", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtp_com.Value)) = 0) Then
            dtp_com.Focus()
        ElseIf Not ValidaFecha() Then
            MessageBox.Show("Verifique la información de mes y año de la planilla." & vbNewLine, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf Not ValidaCuenta() Then
            MessageBox.Show("Verifique la información de la Cuenta, puede que algunas no esten registradas." & vbNewLine, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Try
                'If Not _generaAuto Then
                GENERAR_AUTO()
                'End If
                If (INSERTAR_TODO() = "EXITO") Then
                    ELIMINAR_AUTO()
                    MessageBox.Show("El Comprobante se guardo con Exito", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    DG.Rows.Clear()
                Else
                    OBJ.ELIMINAR_TEMPORAL("TCON")
                    ELIMINAR_AUTO()
                    MessageBox.Show("Ocurrio un error", "Vuelva a Intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    _generaAuto = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImportarPlanilla_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CBO_AUXILIAR()
        CREAR_DATASET()
        'TCAMBIO = OBJ.SACAR_CAMBIO_MENSUAL(AÑO, MES, "D", "V")
        'If TCAMBIO = 0 Then
        '    'MessageBox.Show("Verifique el tipo de cambio mensual para este proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If
    End Sub

    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = OBJ.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
        End If
    End Sub

    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_com.SelectedIndexChanged
        If ((cbo_aux.SelectedIndex <> -1) And (cbo_com.SelectedIndex <> -1)) Then
            COD_AUX = OBJ.COD_AUX(cbo_aux.Text)
            COD_COMP = OBJ.COD_COMP(cbo_com.Text, COD_AUX)
            Dim NUM0 As String = OBJ.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txt_nro_comp.Text = NUM0
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class