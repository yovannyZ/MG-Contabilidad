Imports System.Data.SqlClient
Imports System.IO
Imports System
Public Class REPORTE_PDT_PROV
    Private FILA2, FILA1, TITULO, ST_PER, COD_PER, CODIGO_ESTRUCTURA, EXTENSION As String
    Dim REGISTROS As Integer = 0
    Dim I1, I6, I9, I8, I7, I5, I10, I2, I3, I4 As Decimal
    Private OBJ As New Class1
    Private REP1 As New REP_PDT_PROV
    Dim SB As New Text.StringBuilder
    Private Sub REPORTE_PDT_PROV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub PDT_COMPRAS_VENTAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        txt_empresa.Text = DESC_EMPRESA
        txt_ruc.Text = RUC_EMPRESA
        cbo_prov.Focus()
        DGW_DETALLE.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
    End Sub
    Function HALLAR_ITEM() As String
        Dim mayor As Integer = 0
        Dim i As Integer = 0
        Dim cont As Integer = (DGW_DETALLE.Rows.Count - 1)
        i = 0
        Do While (i <= cont)
            If (DGW_DETALLE.Item(0, i).Value > mayor) Then
                mayor = (DGW_DETALLE.Item(0, i).Value)
            End If
            i += 1
        Loop
        mayor += 1
        Return mayor.ToString("00")
    End Function
    Sub CARGAR_AÑO()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la provisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub
        If txt_importe.Text = "" Then MessageBox.Show("Debe ingresar el Importe Base", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_importe.Focus() : Exit Sub

        Select Case cbo_prov.SelectedIndex
            Case "0"
                TITULO = "COMPRAS"
            Case "1"
                TITULO = "VENTAS"
        End Select
        If cbo_prov.SelectedIndex = "0" Then
            hallar_calculo_compras()
            importes_compras()
            calculo()
            HALLAR_BI_FINAL()
            LLENAR_DATASET()
            REP1.CREAR_REPORTE(TITULO, cbo_año.Text, REGISTROS)
            REP1.ShowDialog()
        ElseIf cbo_prov.SelectedIndex = "1" Then
            hallar_calculo_ventas()
            importes_ventas()
            calculo()
            HALLAR_BI_FINAL()
            LLENAR_DATASET()
            REP1.CREAR_REPORTE(TITULO, cbo_año.Text, REGISTROS)
            REP1.ShowDialog()
        End If
    End Sub
    Sub importes_ventas()
        dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_PDT_PROVISIONES_V", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), 0, 0, 0, Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub hallar_calculo_ventas()
        dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CONFIG_PROV", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = "V"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub HALLAR_BI_FINAL()
        Dim I, J, CONT1, CONT2 As Integer
        Dim SUM As Decimal
        Dim COD_PER As String
        CONT1 = dgw2.Rows.Count - 1
        CONT2 = dgw2.Rows.Count - 1
        For I = 0 To CONT1
            COD_PER = dgw2.Item(4, I).Value
            SUM = 0
            For J = 0 To CONT2
                If dgw2.Item(4, J).Value = COD_PER Then
                    SUM = SUM + dgw2.Item(17, J).Value
                End If
            Next
            dgw2.Item(28, I).Value = SUM
        Next
    End Sub
    Sub resolver()
        'Dim formula As String
        Dim i, cont, k As Integer
        Dim monto As Decimal = 0.0
        i = 0
        cont = dgw2.Rows.Count - 1
        ''dgw_calculo.Item(i + 8, i - 24).Value = ""
        'For k = 0 To cont
        For i = 0 To cont
            '        If dgw_importe.Item(i, k).Value = "" Then
            '            dgw_importe.Item(i + 8, k).Value = "0.00"
            '        Else
            '            formula = dgw_importe.Item(i, k).Value
            Try
                Dim CMD As New SqlCommand("SELECT SUM( " & dgw2.Item(17, i).Value & " )", con)
                con.Open()
                monto = CMD.ExecuteScalar()
                con.Close()
            Catch ex As Exception
                '               dgw_importe.Item(i + 8, k).Value = "0.00"
            End Try
            dgw2.Item(28, i).Value = monto
            '        End If
        Next
        'Next
    End Sub
    Sub LLENAR_DATASET()
        REP1.LIMPIAR()
        Dim I As Integer = 0
        Dim CONT As Integer = (DGW_DETALLE.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If DGW_DETALLE.Item(5, I).Value >= txt_importe.Text Then
                Dim COD_DOC0, NRO_DOC0, CP0, N01, N02, RS0, DP0, AP01, AP02 As String
                COD_DOC0 = DGW_DETALLE.Item(3, I).Value.ToString
                NRO_DOC0 = DGW_DETALLE.Item(4, I).Value.ToString
                CP0 = DGW_DETALLE.Item(1, I).Value.ToString
                RS0 = DGW_DETALLE.Item(10, I).Value.ToString
                AP01 = DGW_DETALLE.Item(6, I).Value.ToString
                AP02 = DGW_DETALLE.Item(7, I).Value.ToString
                N01 = DGW_DETALLE.Item(8, I).Value.ToString
                N02 = DGW_DETALLE.Item(9, I).Value.ToString
                If RS0 = " " Then
                    DP0 = N01.Trim & " " & N02.Trim & " " & AP01.Trim & " " & AP02.Trim
                Else
                    DP0 = RS0
                End If
                REP1.llenar_dt(COD_DOC0, "", NRO_DOC0, "", CP0, "", DP0, "0.00", "0.00", "0.00", "0.000", "", "", "", "", DGW_DETALLE.Item(3, I).Value.ToString, DGW_DETALLE.Item(4, I).Value.ToString, DGW_DETALLE.Item(11, I).Value.ToString, DGW_DETALLE.Item(5, I).Value)

            End If
            I += 1
        Loop
    End Sub
    Sub hallar_calculo_compras()
        'dgw1.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_CONFIG_PROV2", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = "C"
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw1.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub importes_compras()
        'dgw2.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("REPORTE_PDT_PROVISIONES", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                dgw2.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), 0, 0, 0, Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_cancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        main(126) = 0
        Close()
    End Sub
    Sub CALCULO_FILTRADO()
        Dim i, cont, k As Integer
        Dim monto As Decimal = 0.0
        i = 0
        cont = dgw2.Rows.Count - 1
        For i = 0 To cont
            Try
                Dim CMD As New SqlCommand("SELECT SUM( " & dgw2.Item(17, i).Value & " )", con)
                con.Open()
                monto = CMD.ExecuteScalar()
                con.Close()
            Catch ex As Exception
                dgw2.Item(28, i).Value = "0.00"
            End Try
            dgw2.Item(28, i).Value = monto
        Next

    End Sub
    Sub calculo()
        Dim c1 As Integer = dgw1.Rows.Count - 1
        Dim c2 As Integer = dgw2.Rows.Count - 1
        Dim CONT0 As Integer = (17 + c2)
        Dim j As Integer = 17
        Do While (j <= CONT0)
            Dim bi As New Decimal
            Dim VAR1 As Integer = c1
            Dim i As Integer = 0
            Do While (i <= VAR1)
                I1 = Decimal.Parse(dgw2.Item(7, (j - 17)).Value)
                I2 = Decimal.Parse(dgw2.Item(8, (j - 17)).Value)
                I3 = Decimal.Parse(dgw2.Item(9, (j - 17)).Value)
                I4 = Decimal.Parse(dgw2.Item(10, (j - 17)).Value)
                I5 = Decimal.Parse(dgw2.Item(11, (j - 17)).Value)
                I6 = Decimal.Parse(dgw2.Item(12, (j - 17)).Value)
                I7 = Decimal.Parse(dgw2.Item(13, (j - 17)).Value)
                I8 = Decimal.Parse(dgw2.Item(14, (j - 17)).Value)
                I9 = Decimal.Parse(dgw2.Item(15, (j - 17)).Value)
                I10 = Decimal.Parse(dgw2.Item(16, (j - 17)).Value)
                Dim tipo_orden As String = dgw1.Item(1, i).Value.ToString
                Dim NRO_ORDEN As String = dgw1.Item(0, i).Value.ToString
                Select Case tipo_orden
                    Case "B"
                        Select Case NRO_ORDEN
                            Case "01"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(7, (j - 17)).Value))
                                Exit Select
                            Case "02"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(8, (j - 17)).Value))
                                Exit Select
                            Case "03"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(9, (j - 17)).Value))
                                Exit Select
                            Case "04"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(10, (j - 17)).Value))
                                Exit Select
                            Case "05"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(11, (j - 17)).Value))
                                Exit Select
                            Case "06"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(12, (j - 17)).Value))
                                Exit Select
                            Case "07"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(13, (j - 17)).Value))
                                Exit Select
                            Case "08"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(14, (j - 17)).Value))
                                Exit Select
                            Case "09"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(15, (j - 17)).Value))
                                Exit Select
                            Case "10"
                                bi = Decimal.Parse(Decimal.Add(bi, dgw2.Item(16, (j - 17)).Value))
                                Exit Select
                        End Select
                        Exit Select
                End Select
                i += 1
            Loop
            dgw2.Item(17, (j - 17)).Value = bi
            j += 1
        Loop
    End Sub
    Private Sub txt_importe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_importe.KeyPress
        e.Handled = Numero(e, txt_importe)
    End Sub
    Private Sub txt_importe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_importe.LostFocus
        Try
            txt_importe.Text = OBJ.HACER_DECIMAL(txt_importe.Text)
        Catch ex As Exception
            txt_importe.Text = "0.00"
        Finally
        End Try
    End Sub
    Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
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
    Private Sub btn_txt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_txt.Click
        dgw1.Rows.Clear()
        dgw2.Rows.Clear()
        DGW_DETALLE.Rows.Clear()
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe elegir la provisión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub
        If txt_importe.Text = "" Then MessageBox.Show("Debe ingresar el Importe Base", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_importe.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = "0" Then
            hallar_calculo_compras()
            importes_compras()
            calculo()
            'HALLAR_BI_FINAL()
            LLENAR_DETALLE()
        ElseIf cbo_prov.SelectedIndex = "1" Then
            hallar_calculo_ventas()
            importes_ventas()
            calculo()
            'HALLAR_BI_FINAL()
            LLENAR_DETALLE_VENTAS()
        End If
    End Sub
    Sub texttt()
        Dim cont As Integer
        cont = dgw2.Rows.Count
        TextBox1.Text = cont
    End Sub
    Sub LLENAR_DETALLE()
        DGW_DETALLE.Rows.Clear()
        Dim IMPORTE_BI As Decimal
        Dim PER, NOMBRES, NOMBRE1, NOMBRE2, espacio As String
        Dim CONT, I, tamaño As Integer
        CONT = dgw2.Rows.Count - 1
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_TEXTO_PDT", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                NOMBRES = (Rs3.GetValue(7)) : PER = (Rs3.GetValue(0))
                '---------------------------------------------------
                'HALLANDO EL IMPORTE DE BI FINAL A CADA PERSONA
                For I = 0 To CONT
                    If PER = dgw2.Item(4, I).Value Then
                        IMPORTE_BI = dgw2.Item(17, I).Value
                    End If
                    'Exit For
                Next
                '---------------------------------------------------
                'SEPARANDO EL NOMBRE 
                'If NOMBRES <> "" Then
                '    espacio = NOMBRES.LastIndexOf(" ")
                '    tamaño = NOMBRES.Length
                '    NOMBRE1 = NOMBRES.Substring(0, espacio)
                '    NOMBRE2 = NOMBRES.Substring(espacio, tamaño - (espacio))
                'Else
                '    NOMBRE1 = "" : NOMBRE2 = ""
                'End If
                '---------------------------------------------------
                Dim tip_doc, razon_social As String
                razon_social = Rs3.GetValue(1)
                If Rs3.GetValue(4) = "J" Then
                    tip_doc = "02"
                    razon_social = Rs3.GetValue(1)
                ElseIf Rs3.GetValue(4) = "N" Then
                    tip_doc = "01"
                    razon_social = " "
                End If
                If IMPORTE_BI >= txt_importe.Text Then
                    DGW_DETALLE.Rows.Add(HALLAR_ITEM, (Rs3.GetValue(0)), tip_doc, Rs3.GetValue(2), Rs3.GetValue(3), IMPORTE_BI, Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(8), Rs3.GetValue(9), razon_social, Rs3.GetValue(10), Rs3.GetValue(11))
                End If
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub LLENAR_DETALLE_VENTAS()
        DGW_DETALLE.Rows.Clear()
        Dim IMPORTE_BI As Decimal
        Dim PER, NOMBRES, NOMBRE1, NOMBRE2, espacio As String
        Dim CONT, I, tamaño As Integer
        CONT = dgw2.Rows.Count - 1
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_TEXTO_PDT_VENTAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                NOMBRES = (Rs3.GetValue(7)) : PER = (Rs3.GetValue(0))
                '---------------------------------------------------
                'HALLANDO EL IMPORTE DE BI FINAL A CADA PERSONA
                For I = 0 To CONT
                    If PER = dgw2.Item(4, I).Value Then
                        IMPORTE_BI = dgw2.Item(17, I).Value
                    End If
                    'Exit For
                Next
                '---------------------------------------------------
                'SEPARANDO EL NOMBRE 
                'If NOMBRES <> "" Then
                '    espacio = NOMBRES.LastIndexOf(" ")
                '    tamaño = NOMBRES.Length
                '    NOMBRE1 = NOMBRES.Substring(0, espacio)
                '    NOMBRE2 = NOMBRES.Substring(espacio, tamaño - (espacio))
                'Else
                '    NOMBRE1 = "" : NOMBRE2 = ""
                'End If
                '---------------------------------------------------
                Dim tip_doc, razon_social As String
                razon_social = Rs3.GetValue(1)
                If Rs3.GetValue(4) = "J" Then
                    tip_doc = "02"
                    razon_social = Rs3.GetValue(1)
                ElseIf Rs3.GetValue(4) = "N" Then
                    tip_doc = "01"
                    razon_social = " "
                End If
                If IMPORTE_BI >= txt_importe.Text Then
                    DGW_DETALLE.Rows.Add(HALLAR_ITEM, (Rs3.GetValue(0)), tip_doc, Rs3.GetValue(2), Rs3.GetValue(3), IMPORTE_BI, Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(8), Rs3.GetValue(9), razon_social, Rs3.GetValue(10), Rs3.GetValue(11))
                End If
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DGW_DETALLE.Rows.Count = 0 Then MessageBox.Show("No hay registros a Generar", "Carga de Texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_txt.Focus() : Exit Sub
        sfdArchivos.InitialDirectory() = "D:\MARIA\Archivos_texto"
        Me.sfdArchivos.Filter = "Archivos de texto (*.*)|*.*"
        If cbo_prov.SelectedIndex = 0 Then
            Me.sfdArchivos.FileName = "Costos"
        ElseIf cbo_prov.SelectedIndex = 1 Then
            Me.sfdArchivos.FileName = "Ingresos"
        End If
        Me.sfdArchivos.ShowDialog()
        '---------------------------------------------------------
        If Me.sfdArchivos.FileName = "" Then
            Exit Sub
        Else
            txtRutaSave.Text = sfdArchivos.FileName
        End If
        '----------------------------------------------
        Dim i, cont As Integer
        i = 0
        cont = DGW_DETALLE.RowCount - 1
        Dim RSPTA As String = MessageBox.Show("¿Ésta seguro de Generar Archivo del PDT?", "Generación de Archivo de Texto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If RSPTA = vbYes Then
            For i = 0 To cont
                EXTENSION = "txt"
                CARGAR_ESTRUCTURA()
            Next
            MessageBox.Show("Los Archivos se crearon satisfactoriamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub CARGAR_ESTRUCTURA()
        SB.Remove(0, SB.Length)
        Dim i, cont As Integer
        i = 0
        cont = DGW_DETALLE.Rows.Count
        For i = 0 To cont - 1
            If DGW_DETALLE.Item(5, i).Value >= txt_importe.Text Then
                SB.AppendLine(Trim(DGW_DETALLE.Item(0, i).Value) & "|" & "6" & "|" & Trim(txt_ruc.Text) & "|" & Trim(cbo_año.Text) & "|" & Trim(DGW_DETALLE.Item(2, i).Value) & "|" & CInt(DGW_DETALLE.Item(3, i).Value) & "|" & Trim(DGW_DETALLE.Item(4, i).Value) & "|" & CInt(Math.Round(DGW_DETALLE.Item(5, i).Value, 2)) & "|" & Trim(DGW_DETALLE.Item(6, i).Value) & "|" & Trim(DGW_DETALLE.Item(7, i).Value) & "|" & Trim(DGW_DETALLE.Item(8, i).Value) & "|" & Trim(DGW_DETALLE.Item(9, i).Value) & "|" & Trim(DGW_DETALLE.Item(10, i).Value) & "|")
            End If
        Next
        Try
            Dim RUTA As String = sfdArchivos.FileName
            'Dim fs As New FileStream(RUTA & "_" & CODIGO_ESTRUCTURA & "." & EXTENSION, FileMode.OpenOrCreate, FileAccess.Write)
            Dim fs As New FileStream(RUTA & CODIGO_ESTRUCTURA & "." & EXTENSION, FileMode.OpenOrCreate, FileAccess.Write)
            Dim textoBytes() As Byte
            Dim codificador As New Text.UTF8Encoding
            Dim A2 As Integer
            A2 = SB.Length - 2
            SB = SB.Remove(A2, 2)
            textoBytes = codificador.GetBytes(SB.ToString)
            fs.Write(textoBytes, 0, textoBytes.Length)
            fs.Flush()
            fs.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btn_eliminar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_eliminar2.Click
        Try
            Dim i As Integer = DGW_DETALLE.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try
        If (Decimal.Parse((CInt(MessageBox.Show("Esta seguro de eliminar el Detalle.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
            DGW_DETALLE.Rows.RemoveAt(DGW_DETALLE.CurrentRow.Index)
        End If
        Dim j, cont As Integer
        cont = DGW_DETALLE.RowCount - 1
        For j = 0 To cont
            DGW_DETALLE.Item(0, j).Value = (j + 1).ToString("00")
        Next
        'HALLAR_ITEM()
    End Sub
End Class