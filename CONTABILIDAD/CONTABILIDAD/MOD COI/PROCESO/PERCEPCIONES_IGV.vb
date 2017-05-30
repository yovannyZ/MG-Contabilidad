Imports System.Data.SqlClient
Imports System.IO
Imports System
Public Class PERCEPCIONES_IGV
    Dim SB As New Text.StringBuilder
    Dim CODIGO_ESTRUCTURA, EXTENSION As String
    Dim OBJ As New Class1
    Private Sub RETENCIONES_IGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub RETENCIONES_IGV_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        txt_empresa.Text = DESC_EMPRESA
        txt_ruc.Text = RUC_EMPRESA
        DGW_DETALLE.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Bold)
        cbo_año.Focus()
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
    Sub LLENAR_DGW()
        DGW_DETALLE.Rows.Clear()
        Try
            Dim PROG_01 As New SqlCommand("[MOSTRAR_TEXTO_PERCEPCIONES]", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cbo_año.Text
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            con.Open()
            '-----------------------------
            '-------para el tiempo de espera caducado
            PROG_01.CommandTimeout = 5000
            '-----------------------------
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Dim SERIE_PER, NRO_PER, NRO_DOC_PER As String
                Dim TAMAÑO, GUION As Integer
                '------------------------------------------------------------------
                NRO_PER = Rs3.GetValue(5)
                GUION = NRO_PER.LastIndexOf("-")
                TAMAÑO = NRO_PER.Length
                If TAMAÑO <> 0 Then
                    SERIE_PER = NRO_PER.Substring(0, GUION)
                    NRO_DOC_PER = NRO_PER.Substring(GUION + 1, TAMAÑO - (GUION) - 1)
                Else
                    SERIE_PER = " "
                    NRO_DOC_PER = " "
                End If
                '------------------------------------------------------------------
                Dim SERIE_DOC, DOC_PER, DOC_PER2 As String
                Dim TAMAÑO2, GUION2 As Integer
                DOC_PER = Rs3.GetValue(9)
                GUION2 = DOC_PER.LastIndexOf("-")
                TAMAÑO2 = DOC_PER.Length
                If TAMAÑO2 <> 0 Then
                    SERIE_DOC = DOC_PER.Substring(0, GUION2)
                    DOC_PER2 = DOC_PER.Substring(GUION2 + 1, TAMAÑO2 - (GUION2) - 1)
                Else
                    SERIE_DOC = " "
                    DOC_PER2 = " "
                End If
                '------------------------------------------------------------------
                DGW_DETALLE.Rows.Add(HALLAR_ITEM, (Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), SERIE_PER, NRO_DOC_PER, Rs3.GetValue(6).ToString.Substring(0, 10), Rs3.GetValue(7), Rs3.GetValue(8), SERIE_DOC, DOC_PER2, Rs3.GetValue(10).ToString.Substring(0, 10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_cancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        main(134) = 0
        Close()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DGW_DETALLE.Rows.Count = 0 Then MessageBox.Show("No hay registros a Generar", "Carga de Texto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btn_txt.Focus() : Exit Sub
        sfdArchivos.InitialDirectory() = "D:\MARIA\Archivos_texto"
        Me.sfdArchivos.Filter = "Archivos de texto (*.*)|*.*"
        Me.sfdArchivos.FileName = "0697" & txt_ruc.Text & cbo_año.Text & OBJ.COD_MES(cbo_mes.Text)
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
            SB.AppendLine(Trim(DGW_DETALLE.Item(16, i).Value) & "|" & Trim(DGW_DETALLE.Item(1, i).Value) & "|" & Trim(DGW_DETALLE.Item(2, i).Value) & "|" & Trim(DGW_DETALLE.Item(3, i).Value) & "|" & Trim(DGW_DETALLE.Item(4, i).Value) & "|" & Trim(DGW_DETALLE.Item(5, i).Value) & "|" & Trim(DGW_DETALLE.Item(6, i).Value) & "|" & Trim(DGW_DETALLE.Item(7, i).Value) & "|" & Trim(DGW_DETALLE.Item(8, i).Value) & "|" & Trim(DGW_DETALLE.Item(17, i).Value) & "|" & "0" & "|" & Trim(DGW_DETALLE.Item(18, i).Value) & "|" & Trim(DGW_DETALLE.Item(9, i).Value) & "|" & Trim(DGW_DETALLE.Item(10, i).Value) & "|" & Trim(DGW_DETALLE.Item(11, i).Value) & "|" & Trim(DGW_DETALLE.Item(12, i).Value) & "|" & Trim(DGW_DETALLE.Item(13, i).Value) & "|" & OBJ.HACER_DECIMAL_PTO(Trim(DGW_DETALLE.Item(15, i).Value)) & "|")
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
        LLENAR_DGW()
    End Sub
End Class