Imports System.Data.SqlClient
Imports System.IO
Imports System
Public Class RENTA_DE_CUARTA
    Dim SB As New Text.StringBuilder
    Dim CODIGO_ESTRUCTURA, EXTENSION, TIPO, TIPO_MOV As String
    Dim OBJ As New Class1
    Private Sub RENTA_DE_CUARTA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub RENTA_DE_CUARTA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        txt_empresa.Text = DESC_EMPRESA
        txt_ruc.Text = RUC_EMPRESA
        DGW_DETALLE.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW_DETALLE2.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        DGW_DETALLE3.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        cbo_año.Focus()
        '-------------------------------------------------------------------
        Label7.Visible = False
        cbo_bi.Visible = False
        Label8.Visible = False
        cbo_indicador.Visible = False
    End Sub
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
    Function HALLAR_ITEM2() As String
        Dim mayor As Integer = 0
        Dim i As Integer = 0
        Dim cont As Integer = (DGW_DETALLE2.Rows.Count - 1)
        i = 0
        Do While (i <= cont)
            If (DGW_DETALLE2.Item(0, i).Value > mayor) Then
                mayor = (DGW_DETALLE2.Item(0, i).Value)
            End If
            i += 1
        Loop
        mayor += 1
        Return mayor.ToString("00")
    End Function
    Function HALLAR_ITEM3() As String
        Dim mayor As Integer = 0
        Dim i As Integer = 0
        Dim cont As Integer = (DGW_DETALLE3.Rows.Count - 1)
        i = 0
        Do While (i <= cont)
            If (DGW_DETALLE3.Item(0, i).Value > mayor) Then
                mayor = (DGW_DETALLE3.Item(0, i).Value)
            End If
            i += 1
        Loop
        mayor += 1
        Return mayor.ToString("00")
    End Function
    Sub LLENAR_DGW()
        If cbo_prov.SelectedIndex = 0 Then
            TIPO = "C"
        ElseIf cbo_prov.SelectedIndex = 1 Then
            TIPO = "H"
        Else
            TIPO = ""
        End If
        '-----------------------------------------------------------------------------------------
        If TabControl1.SelectedIndex = 0 Then
            DGW_DETALLE.Rows.Clear()

            Try
                Dim PROG_01 As New SqlCommand("MOSTRAR_TEXTO_PROVISIONES_MAESTRO", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO
                con.Open()
                '-----------------------------
                '-------para el tiempo de espera caducado
                PROG_01.CommandTimeout = 5000
                '-----------------------------
                PROG_01.ExecuteNonQuery()
                Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
                Do While Rs3.Read
                    'DGW_DETALLE.Rows.Add(HALLAR_ITEM, Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11))
                    DGW_DETALLE.Rows.Add(HALLAR_ITEM, Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5))
                Loop
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            '-----------------------------------------------------------------------------------------
        ElseIf TabControl1.SelectedIndex = 1 Then
            DGW_DETALLE2.Rows.Clear()
            Try
                Dim PROG_01 As New SqlCommand("MOSTRAR_TEXTO_PROVISIONES_SERVICIOS", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO
                con.Open()
                '-----------------------------
                '-------para el tiempo de espera caducado
                PROG_01.CommandTimeout = 5000
                '-----------------------------
                PROG_01.ExecuteNonQuery()
                Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
                Do While Rs3.Read
                    DGW_DETALLE2.Rows.Add(HALLAR_ITEM2, Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2))
                Loop
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            '-----------------------------------------------------------------------------------------
        ElseIf TabControl1.SelectedIndex = 2 Then
            If cbo_bi.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Orden de B.I.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_bi.Focus() : Exit Sub
            If cbo_indicador.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Orden Renta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_indicador.Focus() : Exit Sub
            DGW_DETALLE3.Rows.Clear()
            Try
                Dim PROG_01 As New SqlCommand("MOSTRAR_TEXTO_PROVISIONES_MOVIMIENTOS", con)
                PROG_01.CommandType = CommandType.StoredProcedure
                PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
                PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                PROG_01.Parameters.Add("@TIPO", SqlDbType.Char).Value = TIPO
                PROG_01.Parameters.Add("@ORDEN_BI", SqlDbType.Char).Value = cbo_bi.SelectedValue.ToString
                PROG_01.Parameters.Add("@ORDEN_RENTA", SqlDbType.Char).Value = cbo_indicador.SelectedValue.ToString
                'MODIFICACION
                PROG_01.Parameters.Add("@ONP", SqlDbType.Char).Value = CBO_ONP.SelectedValue.ToString
                PROG_01.Parameters.Add("@AFP", SqlDbType.Char).Value = CBO_AFP.SelectedValue.ToString
                con.Open()
                '-----------------------------
                '-------para el tiempo de espera caducado
                PROG_01.CommandTimeout = 5000
                '-----------------------------
                PROG_01.ExecuteNonQuery()
                Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
                Do While Rs3.Read
                    Dim SERIE, NRO_DOC, NRO As String
                    Dim TAMAÑO, GUION As Integer
                    '------------------------------------------------------------------
                    NRO_DOC = Rs3.GetValue(3)
                    GUION = NRO_DOC.IndexOf("-")
                    TAMAÑO = NRO_DOC.Length
                    If TAMAÑO <> 0 AndAlso GUION > -1 Then
                        SERIE = NRO_DOC.Substring(0, GUION)
                        NRO = NRO_DOC.Substring(GUION + 1, TAMAÑO - (GUION) - 1)
                    Else
                        SERIE = " "
                        NRO = " "
                    End If
                    '------------------------------------------------------------------
                    Dim INDICADOR As String
                    If Rs3.GetValue(7) <> "0.00" Then
                        INDICADOR = "1"
                    Else
                        INDICADOR = "0"
                    End If
                    Dim onp, afp As Decimal
                    onp = Format(0.0, "0.00")
                    afp = Format(0.0, "0.00")
                    If Rs3.GetValue(8) <> onp Then
                        onp = Rs3.GetValue(8) * -1
                    Else
                        onp = Format(0.0, "0.00")

                    End If
                    If Rs3.GetValue(9) <> afp Then
                        afp = Rs3.GetValue(9) * -1
                    Else
                        afp = Format(0.0, "0.00")
                    End If
                    DGW_DETALLE3.Rows.Add(HALLAR_ITEM3, Rs3.GetValue(0), Rs3.GetValue(1), Rs3.GetValue(2), SERIE, NRO, Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), INDICADOR, onp, afp)
                Loop
                con.Close()
            Catch ex As Exception
                con.Close()
                MessageBox.Show(ex.Message)
            End Try
            '-----------------------------------------------------------------------------------------
        Else
        End If
    End Sub
    Private Sub btn_cancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        main(109) = 0
        Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TabControl1.SelectedIndex = 0 Then
            If DGW_DETALLE.Rows.Count = 0 Then MessageBox.Show("No hay registros a Generar", "Carga de Texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_txt.Focus() : Exit Sub
            sfdArchivos.InitialDirectory() = "D:\MARIA\Archivos_texto"
            Me.sfdArchivos.Filter = "Archivos de texto (*.*)|*.*"
            'Me.sfdArchivos.FileName = txt_ruc.Text & ".t00"
            Me.sfdArchivos.FileName = "0601" & AÑO & MES & txt_ruc.Text & ".ps4"
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
            Dim RSPTA As String = MessageBox.Show("¿Ésta seguro de Generar Archivo?", "Generación de Archivo de Texto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If RSPTA = vbYes Then
                For i = 0 To cont
                    EXTENSION = "txt"
                    CARGAR_ESTRUCTURA1()
                Next
                MessageBox.Show("Los Archivos se crearon satisfactoriamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            '--------------------------------------------------------------------------------------------------------
        ElseIf TabControl1.SelectedIndex = 1 Then
            'txtRutaSave.Clear()
            If DGW_DETALLE2.Rows.Count = 0 Then MessageBox.Show("No hay registros a Generar", "Carga de Texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_txt.Focus() : Exit Sub
            sfdArchivos.InitialDirectory() = "D:\MARIA\Archivos_texto"
            Me.sfdArchivos.Filter = "Archivos de texto (*.*)|*.*"
            Me.sfdArchivos.FileName = txt_ruc.Text & ".t03"
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
            cont = DGW_DETALLE2.RowCount - 1
            Dim RSPTA As String = MessageBox.Show("¿Ésta seguro de Generar Archivo?", "Generación de Archivo de Texto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If RSPTA = vbYes Then
                For i = 0 To cont
                    EXTENSION = "txt"
                    'EXTENSION = ".t03"
                    CARGAR_ESTRUCTURA2()
                Next
                MessageBox.Show("Los Archivos se crearon satisfactoriamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        ElseIf TabControl1.SelectedIndex = 2 Then
            'txtRutaSave.Clear()
            If DGW_DETALLE3.Rows.Count = 0 Then MessageBox.Show("No hay registros a Generar", "Carga de Texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_txt.Focus() : Exit Sub
            sfdArchivos.InitialDirectory() = "D:\MARIA\Archivos_texto"
            Me.sfdArchivos.Filter = "Archivos de texto (*.*)|*.*"
            Me.sfdArchivos.FileName = "0601" & AÑO & MES & txt_ruc.Text & ".4ta"
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
            cont = DGW_DETALLE3.RowCount - 1
            Dim RSPTA As String = MessageBox.Show("¿Ésta seguro de Generar Archivo?", "Generación de Archivo de Texto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If RSPTA = vbYes Then
                For i = 0 To cont
                    EXTENSION = "txt"
                    'EXTENSION = ".t03"
                    CARGAR_ESTRUCTURA3()
                Next
                MessageBox.Show("Los Archivos se crearon satisfactoriamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
    Sub CARGAR_ESTRUCTURA1()
        SB.Remove(0, SB.Length)
        Dim i, cont As Integer
        i = 0
        cont = DGW_DETALLE.Rows.Count
        For i = 0 To cont - 1
            'Dim yy As String = Trim(DGW_DETALLE.Item(6, i).Value.ToString)
            'Dim uu As String
            'If yy <> "" Then uu = (yy).Substring(0, 10) Else uu = Trim(DGW_DETALLE.Item(6, i).Value.ToString)
            'SB.AppendLine(Trim(DGW_DETALLE.Item(1, i).Value) & "|" & Trim(DGW_DETALLE.Item(2, i).Value) & "|" & Trim(DGW_DETALLE.Item(3, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(4, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(5, i).Value.ToString) & "|" & "" & "|" & Trim(DGW_DETALLE.Item(7, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(8, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(9, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(10, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(11, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(12, i).Value.ToString) & "|" & " " & "|" & " " & "|" & " " & "|" & " " & "|" & " " & "|" & " " & "|" & " " & "|" & " " & "|")
            SB.AppendLine(Trim(DGW_DETALLE.Item(1, i).Value) & "|" & Trim(DGW_DETALLE.Item(2, i).Value) & "|" & Trim(DGW_DETALLE.Item(3, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(4, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(5, i).Value.ToString) & "|" & Trim(DGW_DETALLE.Item(6, i).Value.ToString) & "|" & "0" & "|")
        Next
        Try
            Dim RUTA As String = sfdArchivos.FileName
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
    Sub CARGAR_ESTRUCTURA2()
        SB.Remove(0, SB.Length)
        Dim i, cont As Integer
        i = 0
        cont = DGW_DETALLE2.Rows.Count
        For i = 0 To cont - 1
            SB.AppendLine(Trim(DGW_DETALLE2.Item(1, i).Value.ToString) & "|" & Trim(DGW_DETALLE2.Item(2, i).Value.ToString) & "|" & Trim(DGW_DETALLE2.Item(3, i).Value.ToString) & "|" & "" & "|")
        Next
        Try
            Dim RUTA As String = sfdArchivos.FileName
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
    Sub CARGAR_ESTRUCTURA3()
        SB.Remove(0, SB.Length)
        Dim i, cont As Integer
        i = 0
        cont = DGW_DETALLE3.Rows.Count
        For i = 0 To cont - 1
            Dim a As String = Trim(DGW_DETALLE3.Item(7, i).Value.ToString)
            Dim b As String = Trim(DGW_DETALLE3.Item(8, i).Value.ToString)
            '----
            Dim c As String = Trim(DGW_DETALLE3.Item(10, i).Value.ToString)
            Dim d As String = Trim(DGW_DETALLE3.Item(11, i).Value.ToString)
            Dim f3 As Integer
            Dim imp As String
            imp = ""
            If c <> 0 Then
                f3 = 1
            ElseIf d <> 0 Then
                f3 = 2
            Else : f3 = 3
            End If
            If f3 = 1 Then
                imp = Trim(DGW_DETALLE3.Item(10, i).Value.ToString)
            End If

            '----
            Dim f1, f2 As String
            If a <> "" Then f1 = a.Substring(0, 10) Else f1 = Trim(DGW_DETALLE3.Item(7, i).Value.ToString)
            If b <> "" Then f2 = b.Substring(0, 10) Else f2 = Trim(DGW_DETALLE3.Item(8, i).Value.ToString)
            SB.AppendLine(Trim(DGW_DETALLE3.Item(1, i).Value.ToString) & "|" & Trim(DGW_DETALLE3.Item(2, i).Value.ToString) & "|" & Trim(DGW_DETALLE3.Item(3, i).Value.ToString) & "|" & Trim(DGW_DETALLE3.Item(4, i).Value.ToString) & "|" & Trim(DGW_DETALLE3.Item(5, i).Value.ToString) & "|" & Trim(DGW_DETALLE3.Item(6, i).Value.ToString) & "|" & f1 & "|" & f2 & "|" & Trim(DGW_DETALLE3.Item(9, i).Value.ToString) & "|" & f3 & "|" & imp & "|")
        Next
        Try
            Dim RUTA As String = sfdArchivos.FileName
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
    Private Sub btn_txt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_txt.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        If cbo_prov.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar la provision", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_prov.Focus() : Exit Sub
        'If cbo_bi.Visible = True And cbo_indicador.Visible = True Then
        '    If cbo_indicador.SelectedIndex = -1 And cbo_bi.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar las órdenes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_bi.Focus() : Exit Sub
        'End If

        LLENAR_DGW()
    End Sub
    Private Sub cbo_prov_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_prov.SelectedIndexChanged
        If cbo_prov.SelectedIndex = 0 Then
            TIPO_MOV = "C"
            CARGAR_ORDEN1()
            CARGAR_ORDEN2()
            CARGAR_ORDEN3()
            CARGAR_ORDEN4()
        ElseIf cbo_prov.SelectedIndex = 1 Then
            TIPO_MOV = "H"
            CARGAR_ORDEN1()
            CARGAR_ORDEN2()
            CARGAR_ORDEN3()
            CARGAR_ORDEN4()
        End If
    End Sub
    Sub CARGAR_ORDEN1()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_ORDEN_CUENTA(TIPO_MOV)
        cbo_bi.DataSource = DT
        cbo_bi.DisplayMember = DT.Columns.Item(0).ToString
        cbo_bi.ValueMember = DT.Columns.Item(1).ToString
        cbo_bi.SelectedIndex = -1
    End Sub
    Sub CARGAR_ORDEN2()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_ORDEN_CUENTA(TIPO_MOV)
        cbo_indicador.DataSource = DT
        cbo_indicador.DisplayMember = DT.Columns.Item(0).ToString
        cbo_indicador.ValueMember = DT.Columns.Item(1).ToString
        cbo_indicador.SelectedIndex = -1
    End Sub
    Sub CARGAR_ORDEN3()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_ORDEN_CUENTA(TIPO_MOV)
        CBO_ONP.DataSource = DT
        CBO_ONP.DisplayMember = DT.Columns.Item(0).ToString
        CBO_ONP.ValueMember = DT.Columns.Item(1).ToString
        CBO_ONP.SelectedIndex = -1
    End Sub
    Sub CARGAR_ORDEN4()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_ORDEN_CUENTA(TIPO_MOV)
        CBO_AFP.DataSource = DT
        CBO_AFP.DisplayMember = DT.Columns.Item(0).ToString
        CBO_AFP.ValueMember = DT.Columns.Item(1).ToString
        CBO_AFP.SelectedIndex = -1
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            txtRutaSave.Clear()
            Label7.Visible = False
            cbo_bi.Visible = False
            Label8.Visible = False
            cbo_indicador.Visible = False
            CBO_ONP.Visible = False
            CBO_AFP.Visible = False
            LBLONP.Visible = False
            LBLAFP.Visible = False
        ElseIf TabControl1.SelectedIndex = 1 Then
            txtRutaSave.Clear()
            Label7.Visible = False
            cbo_bi.Visible = False
            Label8.Visible = False
            cbo_indicador.Visible = False
            CBO_ONP.Visible = False
            CBO_AFP.Visible = False
            LBLONP.Visible = False
            LBLAFP.Visible = False
        ElseIf TabControl1.SelectedIndex = 2 Then
            txtRutaSave.Clear()
            Label7.Visible = True
            cbo_bi.Visible = True
            Label8.Visible = True
            cbo_indicador.Visible = True
            CBO_ONP.Visible = True
            CBO_AFP.Visible = True
            LBLONP.Visible = True
            LBLAFP.Visible = True
        Else
        End If
    End Sub

    Private Sub cbo_bi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_bi.SelectedIndexChanged, CBO_ONP.SelectedIndexChanged

    End Sub
End Class
