Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class REPORTE_PERSONAS
    Dim OBJ As New Class1
    Dim COD_PAIS, COD_DEP, COD_PRO, COD_DIST As String
    Dim REP1 As New REP_PERSONA1
    Dim REP2 As New REP_PERSONA2

    Private COD_CLASE, CLASE, COD_CAT As String
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean
    Private Sub REPORTE_PERSONAS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
        If e.KeyCode = Keys.F1 Then
            Try
                ''Help.ShowHelp(Me, "C:\Documents and Settings\MARIA\Escritorio\PROYECTOS\Manual Comercial v2\HTML\cuentas_por_cobrar3.htm", HelpNavigator.Topic)
                'Help.ShowHelp(Me, manual & "persona.htm", HelpNavigator.Topic)
            Catch exc As Exception
                MessageBox.Show(exc.Message, "Error al Cargar ayuda ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub REPORTE_PERSONAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        CARGAR_CLASE()
        CARGAR_CATEGORIA()
        CARGAR_PAIS()
        CARGAR_DEPARTAMENTO()
        cbo_clase.Focus()
    End Sub
    Sub CARGAR_CLASE()
        cbo_clase.Items.Clear()
        cbo_clase2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_CLASE_PER", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                cbo_clase.Items.Add(Rs3.GetString(0))
                cbo_clase2.Items.Add(Rs3.GetString(0))
            End While
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_CATEGORIA()
        cbo_cat.Items.Clear()
        cbo_cat2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_CAT_PER", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                cbo_cat.Items.Add(Rs3.GetString(0))
                cbo_cat2.Items.Add(Rs3.GetString(0))
            End While
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_PAIS()
        cbo_pais.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_PAIS", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                cbo_pais.Items.Add(Rs3.GetString(0))
            End While
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Sub CARGAR_DEPARTAMENTO()
        cbo_dep.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_DEP", con2)
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                cbo_dep.Items.Add(Rs3.GetString(0))
            End While
            con2.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub cbo_dep_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_dep.KeyDown
        If e.KeyData = Keys.Right Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyData = Keys.End Then
            If ch_dep.Checked = True Then
                ch_dep.Checked = False
            Else
                ch_dep.Checked = True
            End If
        End If
    End Sub
    Private Sub cbo_dep_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_dep.SelectedIndexChanged
        If cbo_dep.SelectedIndex = -1 Then
        Else
            COD_DEP = OBJ.cod_DEP(cbo_dep.Text)
            cargar_provincia()
        End If
    End Sub
    Sub cargar_provincia()
        cbo_pro.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_PRO_DEP", con2)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DEP", SqlDbType.Char).Value = COD_DEP
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                cbo_pro.Items.Add(Rs3.GetString(0))
            End While
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub cargar_distrito()
        cbo_dist.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_DIST_PRO_DEP", con2)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DEP", SqlDbType.Char).Value = COD_DEP
            PROG_01.Parameters.Add("@COD_PRO", SqlDbType.Char).Value = COD_PRO
            con2.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader
            Rs3 = PROG_01.ExecuteReader
            While Rs3.Read
                cbo_dist.Items.Add(Rs3.GetString(0))
            End While
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cbo_pro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_pro.KeyDown
        If e.KeyData = Keys.Right Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyData = Keys.End Then
            If ch_pro.Checked = True Then
                ch_pro.Checked = False
            Else
                ch_pro.Checked = True
            End If
        End If
    End Sub
    Private Sub cbo_pro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_pro.SelectedIndexChanged
        If cbo_pro.SelectedIndex = -1 Then
        Else
            COD_PRO = OBJ.cod_PRO(cbo_pro.Text, COD_DEP)
            cargar_distrito()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        main(110) = 0
        Me.Close()
    End Sub
    Private Sub BTN_SALIR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SALIR.Click
        main(110) = 0
        Me.Close()
    End Sub
    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_clase.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir la Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_clase.Focus() : Exit Sub
        If cbo_cat.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir la Categoría", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_cat.Focus() : Exit Sub
        COD_CLASE = OBJ.COD_CLASE_PER(cbo_clase.Text)
        COD_CAT = OBJ.COD_CAT_PER(cbo_cat.Text)
        REP1.CREAR_REPORTE(cbo_clase.Text, COD_CLASE, cbo_cat.Text, COD_CAT)
        REP1.ShowDialog()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If cbo_clase2.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir la Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_clase2.Focus() : Exit Sub
        If cbo_cat2.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir la Categoría", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_cat2.Focus() : Exit Sub
        If cbo_pais.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir el País", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_pais.Focus() : Exit Sub
        If ch_dep.Checked = True And cbo_dep.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir el Departamento", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_dep.Focus() : Exit Sub
        If ch_pro.Checked = True And cbo_pro.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir la Provincia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_pro.Focus() : Exit Sub
        If ch_dist.Checked = True And cbo_dist.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir el Distrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_dist.Focus() : Exit Sub

        Dim COD_CLASE, COD_CAT, cod_pais0, status_dep0, cod_dep0, status_pro0, cod_pro0, status_dist0, cod_dist0 As String
        COD_CLASE = OBJ.COD_CLASE_PER(cbo_clase2.Text)
        COD_CAT = OBJ.COD_CAT_PER(cbo_cat2.Text)
        cod_pais0 = OBJ.cod_PAIS(cbo_pais.Text)
        If ch_dep.Checked = True Then
            status_dep0 = "0"
            cod_dep0 = COD_DEP
        
        Else
            status_dep0 = "1"
            cod_dep0 = " "
        End If


        If ch_pro.Checked = True Then
            status_pro0 = "0"
            cod_pro0 = COD_PRO
     
        Else
            status_pro0 = "1"
            cod_pro0 = " "
        End If


        If ch_dist.Checked = True Then

            status_dist0 = "0"
            cod_dist0 = OBJ.cod_DIST(cbo_dist.Text, cod_pro0, cod_dep0)
        
        Else
            status_dist0 = "1"
            cod_dist0 = " "
        End If
        REP2.CREAR_REPORTE(cbo_pais.Text, cbo_clase2.Text, COD_CLASE, cbo_cat2.Text, COD_CAT, cod_pais0, status_dep0, cod_dep0, status_pro0, cod_pro0, status_dist0, cod_dist0)
        REP2.ShowDialog()
    End Sub
    Private Sub cbo_dist_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbo_dist.KeyDown
        If e.KeyData = Keys.Right Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyData = Keys.End Then
            If ch_dist.Checked = True Then
                ch_dist.Checked = False
            Else
                ch_dist.Checked = True
            End If
        End If
    End Sub

    Private Sub ch_dep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_dep.CheckedChanged
        If ch_dep.Checked = True Then
            cbo_dep.Enabled = True
        Else
            cbo_dep.SelectedIndex = -1
            cbo_dep.Enabled = False
        End If
    End Sub

    Private Sub ch_pro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_pro.CheckedChanged
        If ch_pro.Checked = True Then
            cbo_pro.Enabled = True
        Else
            cbo_pro.SelectedIndex = -1
            cbo_pro.Enabled = False
        End If
    End Sub

    Private Sub ch_dist_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ch_dist.CheckedChanged

        If ch_dist.Checked = True Then
            cbo_dist.Enabled = True
        Else
            cbo_dist.SelectedIndex = -1
            cbo_dist.Enabled = False
        End If
    End Sub

    Private Sub btn_archivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_archivo1.Click
        If cbo_clase.SelectedIndex = -1 Then MessageBox.Show("Debe de elegir la Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_clase.Focus() : Exit Sub
        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                COD_CLASE = OBJ.COD_CLASE_PER(cbo_clase.Text)
                CLASE = cbo_clase.Text
                COD_CAT = OBJ.COD_CAT_PER(cbo_cat.Text)
                bwExportar.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub ExportarWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Exito = True

        Dim oExcel As Object = CreateObject("Excel.Application")
        Dim oLibro As Object = oExcel.Workbooks.Add
        Dim oHoja As Object = oExcel.ActiveSheet
        Try
            oExcel.DisplayAlerts = False

            oHoja.Cells.Font.Name = "Arial Narrow"
            oHoja.Cells.Font.Size = "9"

            oHoja.Range("A1:B1").Merge()
            oHoja.Range("A1:B1").Font.Bold = True
            oHoja.Cells(1, 1) = DESC_EMPRESA
            oHoja.Range("A2:B2").Merge()
            oHoja.Range("A2:B2").NumberFormat = "@"
            oHoja.Range("A2:B2").Font.Bold = True
            oHoja.Cells(2, 1) = RUC_EMPRESA

            oHoja.Range("A3:C3").Merge()
            oHoja.Range("A3:C3").Font.Bold = True
            oHoja.Cells(3, 1) = String.Format("Maestro de personas: {0}", CLASE)


            Dim strRango As String = "A5:F5"

            oHoja.Cells(5, 1) = "Cod." : oHoja.Cells(5, 2) = "Descripción"
            oHoja.Cells(5, 3) = "Cod.Doc." : oHoja.Cells(5, 4) = "Numero Doc."
            oHoja.Cells(5, 5) = "Direccion" : oHoja.Cells(5, 6) = "Telefono"

            oHoja.Range("A:F").NumberFormat = "@"
            'oHoja.Range("E:E").NumberFormat = "DD/MM/YYYY"
            'oHoja.Range("J:J").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 6
            archivoExcel = "ReportePersona"
            'checkforillegalcrossthreadcalls
            Dim Cmd As New SqlCommand("REPORTE_PERSONA1", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@COD_CLASE", SqlDbType.Char).Value = COD_CLASE
            Cmd.Parameters.Add("@COD_CAT", SqlDbType.Char).Value = COD_CAT
            con.Open()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader

            Do While Rs3.Read
                oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                oHoja.Cells(Fila, 5) = Rs3.GetValue(10)
                oHoja.Cells(Fila, 6) = Rs3.GetValue(11)
              
                Fila += 1
            Loop
            Rs3.Close()

            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108
            oHoja.Range(String.Format("A6:F{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A6:F{0}", Fila - 1)).Interior.ColorIndex = 2

            oHoja.Columns.AutoFit()
            oLibro.SaveAs(String.Format("{0}\{1}.xls", rutaExcel, archivoExcel), True)
        Catch ex As Exception
            Exito = False
            MessageBox.Show(String.Format("Error al generar el archivo excel.{0}{1}", Environment.NewLine, ex.Message), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
            oHoja = Nothing
            oLibro.Close(False)
            oLibro = Nothing
            oExcel.Quit()
            oExcel = Nothing
            System.GC.Collect(0)
            System.GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Private Sub ExportarProgress(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs)
        tspbExportar.Value = e.ProgressPercentage
        tslblMensaje.Text = String.Format("{0} %", e.ProgressPercentage)
    End Sub

    Private Sub ExportarComplete(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        If Exito Then MessageBox.Show(String.Format("Archivo generado en {0}\{1}.xls ", rutaExcel, archivoExcel), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        tspbExportar.Value = 0
        stEstado.Visible = False
    End Sub


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete
    End Sub
End Class