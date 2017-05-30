Imports System.Data.SqlClient
Imports System.ComponentModel
Public Class ESTADISTICA_PERDIDAS_GANANCIAS
    Dim OFR As New REP_PERDIDAGANANCIA
    Private OBJ As New Class1
    Dim codUnidadNegocio, stUnidadNegocio, codCentroCostos, stCentroCostos, codZona, stZona As String
    Private rutaExcel, archivoExcel As String
    Private bwExportar As New BackgroundWorker
    Private Exito As Boolean
#Region "Constructor"
    Private Shared instancia As ESTADISTICA_PERDIDAS_GANANCIAS
    Public Shared Function ObtenerInstancia() As ESTADISTICA_PERDIDAS_GANANCIAS
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New ESTADISTICA_PERDIDAS_GANANCIAS
        End If
        instancia.BringToFront()
        Return instancia
    End Function
    Private Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        bwExportar.WorkerReportsProgress = True
        bwExportar.WorkerSupportsCancellation = True
        AddHandler bwExportar.DoWork, AddressOf ExportarWork
        AddHandler bwExportar.ProgressChanged, AddressOf ExportarProgress
        AddHandler bwExportar.RunWorkerCompleted, AddressOf ExportarComplete
    End Sub
#End Region
    Private Sub ESTADISTICA_PERDIDAS_GANANCIAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CARGAR_NEGOCIO()
        CARGAR_AÑO()
        CARGAR_CENTROCOSTOS()
        CARGAR_ZONA()
        cboZona.SelectedIndex = -1
    End Sub
    Sub CARGAR_ZONA()
        Dim dt As New DataTable
        Dim sqlda As New SqlDataAdapter("SELECT CODIGO,DESCRIPCION FROM DIRECTORIO WHERE TABLA_COD='TNEGZ' AND TIPO='D'", con)
        con.Open()
        sqlda.Fill(dt)
        cboZona.DataSource = dt
        cboZona.ValueMember = dt.Columns(0).ToString
        cboZona.DisplayMember = dt.Columns(1).ToString
        con.Close()
    End Sub
    Sub CARGAR_CENTROCOSTOS()
        Try
            Dim CMD As New SqlCommand("SELECT COD_AREA,DESC_AREA FROM AREA WHERE LEN(COD_AREA)=5 ORDER BY DESC_AREA", con)
            CMD.CommandType = CommandType.Text
            Dim DA As New SqlDataAdapter(CMD)
            Dim DT As New DataTable("AREA")
            DA.Fill(DT)
            cboCentroCostos.DataSource = DT
            cboCentroCostos.DisplayMember = DT.Columns.Item(1).ToString
            cboCentroCostos.ValueMember = DT.Columns.Item(0).ToString
            cboCentroCostos.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub
    Sub CARGAR_NEGOCIO()
        Try
            Dim Cmd As New SqlCommand("MOSTRAR_DIRECTORIO_DATO", con)
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = "TNEGO"
            Dim da As New SqlDataAdapter(Cmd)
            Dim dt As New DataTable("Negocio")
            da.Fill(dt)
            cboUnidadNegocio.DataSource = dt
            cboUnidadNegocio.DisplayMember = dt.Columns.Item(1).ToString
            cboUnidadNegocio.ValueMember = dt.Columns.Item(0).ToString
            cboUnidadNegocio.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cboAñoUnidadNegocio.Items.Add(Rs3.GetString(0))
                cboAñoCentroCostos.Items.Add(Rs3.GetString(0))
                cboAñoZona.Items.Add(Rs3.GetString(0))
                cboAñoGeneral.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSalirUnidadNegocio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirUnidadNegocio.Click
        Me.Close()
    End Sub

    Private Sub chkUnidadNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnidadNegocio.CheckedChanged
        If chkUnidadNegocio.Checked = False Then
            cboUnidadNegocio.SelectedIndex = -1
            cboUnidadNegocio.Enabled = False
        Else
            cboUnidadNegocio.Enabled = True
        End If
    End Sub

    Private Sub chkCentroCostos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCentroCostos.CheckedChanged
        If chkCentroCostos.Checked = False Then
            cboCentroCostos.SelectedIndex = -1
            cboCentroCostos.Enabled = False
        Else
            cboCentroCostos.Enabled = True
        End If
    End Sub

    Private Sub chkZona_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkZona.CheckedChanged
        If chkZona.Checked = False Then
            cboZona.SelectedIndex = -1
            cboZona.Enabled = False
        Else
            cboZona.Enabled = True
        End If
    End Sub

    Private Sub btnPantallaUnidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantallaUnidad.Click
        'Validar Paramatros
        If cboUnidadNegocio.SelectedIndex = -1 And chkUnidadNegocio.Checked = True Then MessageBox.Show("Debe seleccionar la Unidad de Negocio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboUnidadNegocio.Focus() : Exit Sub
        If cboMesUnidadNegocio.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMesUnidadNegocio.Focus() : Exit Sub
        If cboAñoUnidadNegocio.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboAñoUnidadNegocio.Focus() : Exit Sub
        '--------------------------
        'PARAMATROS
        Dim frmMes As String
        frmMes = "" : frmMes = OBJ.COD_MES(cboMesUnidadNegocio.Text)
        stUnidadNegocio = ""
        codUnidadNegocio = ""
        If chkUnidadNegocio.Checked Then
            stUnidadNegocio = "1"
            codUnidadNegocio = cboUnidadNegocio.SelectedValue
        Else
            stUnidadNegocio = "0"
            codUnidadNegocio = " "
        End If
        
        If generarUnidadNegocio(stUnidadNegocio, codUnidadNegocio, cboAñoUnidadNegocio.Text, frmMes) = False Then Exit Sub
        'CREAR REPORTE
        OFR.TIPOK = "01"
        OFR.UBICAR_REPORTE()
        OFR.CREAR_REPORTE(cboMesUnidadNegocio.Text)
        OFR.ShowDialog()
    End Sub
    Function generarUnidadNegocio(ByVal stUnidadNegocio As String, ByVal codUnidadNegocio As String, ByVal año As String, ByVal mes As String) As Boolean
        Dim rslt As Boolean = False
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Clear()
        Try
            Dim CMD As New SqlCommand("[REPORTE_ESTADISTICA_PERDIDAS_GANANCIA]", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST_UNIDADNEGOCIO", SqlDbType.Char).Value = stUnidadNegocio
            CMD.Parameters.Add("@UNIDADNEGOCIO", SqlDbType.Char).Value = codUnidadNegocio
            CMD.Parameters.Add("@ST_CCOSTOS", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@CCOSTOS", SqlDbType.VarChar).Value = " "
            CMD.Parameters.Add("@ST_ZONA", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@ZONA", SqlDbType.Char).Value = " "
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año
            CMD.Parameters.Add("@ST_PESTAÑA", SqlDbType.Char).Value = "0"
            con.Open()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader()
            Dim SUM As New Decimal
            Dim SUMTRA As New Decimal
            Do While Rs3.Read
                Dim CONT0 As String = mes
                Select Case CONT0
                    Case "01"
                        If Rs3.GetValue(8) <> "0.00" Then
                            SUM = Decimal.Parse(Rs3.GetValue(8))
                            SUMTRA = Decimal.Parse(Rs3.GetValue(20))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "02"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "03"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "04"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "05"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "06"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "07"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "08"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "09"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "10"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), "0", "0", SUM, SUMTRA)
                        End If
                    Case "11"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)), Rs3.GetValue(30)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), "0", SUM, SUMTRA)
                        End If
                    Case "12"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Or Rs3.GetValue(19) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)), Rs3.GetValue(19)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)), Rs3.GetValue(30)), Rs3.GetValue(31)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), Rs3.GetValue(31), SUM, SUMTRA)
                        End If
                End Select
            Loop
            con.Close()
            rslt = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
        GenerarNroTrabajadores_Unegocio()
        Return rslt
    End Function

    Private Sub btnPantallaZona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantallaZona.Click
        'Validar Paramatros
        If cboZona.SelectedIndex = -1 And chkZona.Checked = True Then MessageBox.Show("Debe seleccionar la Zona", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboZona.Focus() : Exit Sub
        If cboMesZona.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMesZona.Focus() : Exit Sub
        If cboAñoZona.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboAñoZona.Focus() : Exit Sub
        '--------------------------
        'PARAMATROS
        Dim frmMes As String
        frmMes = "" : frmMes = OBJ.COD_MES(cboMesZona.Text)
        stZona = ""
        codZona = ""
        If chkZona.Checked Then
            stZona = "1"
            codZona = cboZona.SelectedValue
        Else
            stZona = "0"
            codZona = " "
        End If
        

        If generarZona(stZona, codZona, cboAñoZona.Text, frmMes) = False Then Exit Sub
        'CREAR REPORTE
        OFR.TIPOK = "03"
        OFR.UBICAR_REPORTE()
        OFR.CREAR_REPORTE(cboMesUnidadNegocio.Text)
        OFR.ShowDialog()
    End Sub
    Function generarZona(ByVal stZona As String, ByVal codZona As String, ByVal año As String, ByVal mes As String) As Boolean
        Dim rslt As Boolean = False
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Clear()
        Try
            Dim CMD As New SqlCommand("[REPORTE_ESTADISTICA_PERDIDAS_GANANCIA]", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST_UNIDADNEGOCIO", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@UNIDADNEGOCIO", SqlDbType.Char).Value = " "
            CMD.Parameters.Add("@ST_CCOSTOS", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@CCOSTOS", SqlDbType.VarChar).Value = " "
            CMD.Parameters.Add("@ST_ZONA", SqlDbType.Char).Value = stZona
            CMD.Parameters.Add("@ZONA", SqlDbType.Char).Value = codZona
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año
            CMD.Parameters.Add("@ST_PESTAÑA", SqlDbType.Char).Value = "2"
            con.Open()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader()
            Dim SUM As New Decimal
            Dim SUMTRA As New Decimal
            Do While Rs3.Read
                Dim CONT0 As String = mes
                Select Case CONT0
                    Case "01"
                        If Rs3.GetValue(8) <> "0.00" Then
                            SUM = Decimal.Parse(Rs3.GetValue(8))
                            SUMTRA = Decimal.Parse(Rs3.GetValue(20))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "02"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "03"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "04"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "05"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "06"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "07"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "08"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "09"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "10"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), "0", "0", SUM, SUMTRA)
                        End If
                    Case "11"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)), Rs3.GetValue(30)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), "0", SUM, SUMTRA)
                        End If
                    Case "12"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Or Rs3.GetValue(19) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)), Rs3.GetValue(19)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)), Rs3.GetValue(30)), Rs3.GetValue(31)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), Rs3.GetValue(31), SUM, SUMTRA)
                        End If
                End Select
            Loop
            con.Close()
            rslt = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
        GenerarNroTrabajadores_Zona()
        Return rslt
    End Function

    Private Sub btnPantallaCentroCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantallaCentroCostos.Click
        'Validar Paramatros
        If cboCentroCostos.SelectedIndex = -1 And chkCentroCostos.Checked = True Then MessageBox.Show("Debe seleccionar el Centro Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboCentroCostos.Focus() : Exit Sub
        If cboMesCentroCostos.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMesCentroCostos.Focus() : Exit Sub
        If cboAñoCentroCostos.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboAñoCentroCostos.Focus() : Exit Sub
        '--------------------------
        'PARAMATROS
        Dim frmMes As String
        frmMes = "" : frmMes = OBJ.COD_MES(cboMesCentroCostos.Text)
        stCentroCostos = ""
        codCentroCostos = ""
        If chkCentroCostos.Checked Then
            stCentroCostos = "1"
            codCentroCostos = cboCentroCostos.SelectedValue
        Else
            stCentroCostos = "0"
            codCentroCostos = " "
        End If
       
        If generarCentroCostos(stCentroCostos, codCentroCostos, cboAñoCentroCostos.Text, frmMes) = False Then Exit Sub
        'CREAR REPORTE
        OFR.TIPOK = "02"
        OFR.UBICAR_REPORTE()
        OFR.CREAR_REPORTE(cboMesCentroCostos.Text)
        OFR.ShowDialog()
    End Sub
    Function generarCentroCostos(ByVal stCentroCostos As String, ByVal codCentroCostos As String, ByVal año As String, ByVal mes As String) As Boolean
        Dim rslt As Boolean = False
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Clear()
        Try
            Dim CMD As New SqlCommand("[REPORTE_ESTADISTICA_PERDIDAS_GANANCIA]", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST_UNIDADNEGOCIO", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@UNIDADNEGOCIO", SqlDbType.Char).Value = " "
            CMD.Parameters.Add("@ST_CCOSTOS", SqlDbType.Char).Value = stCentroCostos
            CMD.Parameters.Add("@CCOSTOS", SqlDbType.VarChar).Value = codCentroCostos
            CMD.Parameters.Add("@ST_ZONA", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@ZONA", SqlDbType.Char).Value = " "
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año
            CMD.Parameters.Add("@ST_PESTAÑA", SqlDbType.Char).Value = "1"
            con.Open()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader()
            Dim SUM As New Decimal
            Dim SUMTRA As New Decimal
            Do While Rs3.Read
                Dim CONT0 As String = mes
                Select Case CONT0
                    Case "01"
                        If Rs3.GetValue(8) <> "0.00" Then
                            SUM = Decimal.Parse(Rs3.GetValue(8))
                            SUMTRA = Decimal.Parse(Rs3.GetValue(20))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "02"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "03"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "04"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "05"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "06"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "07"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "08"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "09"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "10"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), "0", "0", SUM, SUMTRA)
                        End If
                    Case "11"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)), Rs3.GetValue(30)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), "0", SUM, SUMTRA)
                        End If
                    Case "12"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Or Rs3.GetValue(19) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)), Rs3.GetValue(19)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)), Rs3.GetValue(30)), Rs3.GetValue(31)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), Rs3.GetValue(31), SUM, SUMTRA)
                        End If
                End Select
            Loop
            con.Close()
            rslt = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
        GenerarNroTrabajadores_Ccosto()
        Return rslt
    End Function

    Private Sub btnPantallaGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPantallaGeneral.Click
        'Validar Paramatros
        If cboMesGeneral.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMesGeneral.Focus() : Exit Sub
        If cboAñoGeneral.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboAñoGeneral.Focus() : Exit Sub
        '--------------------------
        'PARAMATROS
        Dim frmMes As String
        frmMes = "" : frmMes = OBJ.COD_MES(cboMesGeneral.Text)
        If generarReporteGeneral(cboAñoGeneral.Text, frmMes) = False Then Exit Sub
        'CREAR REPORTE
        OFR.TIPOK = "04"
        OFR.UBICAR_REPORTE()
        OFR.CREAR_REPORTE(cboMesGeneral.Text)
        OFR.ShowDialog()
    End Sub
    Function generarReporteGeneral(ByVal año As String, ByVal mes As String) As Boolean
        Dim rslt As Boolean = False
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Clear()
        Try
            Dim CMD As New SqlCommand("[REPORTE_ESTADISTICA_PERDIDAS_GANANCIA]", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST_UNIDADNEGOCIO", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@UNIDADNEGOCIO", SqlDbType.Char).Value = " "
            CMD.Parameters.Add("@ST_CCOSTOS", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@CCOSTOS", SqlDbType.VarChar).Value = " "
            CMD.Parameters.Add("@ST_ZONA", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@ZONA", SqlDbType.Char).Value = " "
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = año
            CMD.Parameters.Add("@ST_PESTAÑA", SqlDbType.Char).Value = "3"
            con.Open()
            Dim Rs3 As SqlDataReader = CMD.ExecuteReader()
            Dim SUM As New Decimal
            Dim SUMTRA As New Decimal
            Do While Rs3.Read
                Dim CONT0 As String = mes
                Select Case CONT0
                    Case "01"
                        If Rs3.GetValue(8) <> "0.00" Then
                            SUM = Decimal.Parse(Rs3.GetValue(8))
                            SUMTRA = Decimal.Parse(Rs3.GetValue(20))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "02"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "03"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), "0", "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "04"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), "0", "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "05"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), "0", "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "06"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), "0.00", "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), "0", "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "07"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), "0.00", "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), "0", "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "08"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), "0.00", "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), "0", "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "09"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), "0.00", "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), "0", "0", "0", SUM, SUMTRA)
                        End If
                    Case "10"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), "0.00", "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), "0", "0", SUM, SUMTRA)
                        End If
                    Case "11"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)), Rs3.GetValue(30)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), "0.00", Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), "0", SUM, SUMTRA)
                        End If
                    Case "12"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Or Rs3.GetValue(10) Or Rs3.GetValue(11) <> "0.00" Or Rs3.GetValue(12) <> "0.00" Or Rs3.GetValue(13) <> "0.00" Or Rs3.GetValue(14) <> "0.00" Or Rs3.GetValue(15) <> "0.00" Or Rs3.GetValue(16) <> "0.00" Or Rs3.GetValue(17) <> "0.00" Or Rs3.GetValue(18) <> "0.00" Or Rs3.GetValue(19) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)), Rs3.GetValue(19)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)), Rs3.GetValue(27)), Rs3.GetValue(28)), Rs3.GetValue(29)), Rs3.GetValue(30)), Rs3.GetValue(31)))
                            OFR.dtEstadisticaPerdidasGanancia.REPORTE_PERDIDAS_GANANCIAS.Rows.Add((Rs3.GetValue(0)), Rs3.GetValue(1), Rs3.GetValue(2), Rs3.GetValue(3), Rs3.GetValue(4), Rs3.GetValue(5), Rs3.GetValue(6), Rs3.GetValue(7), Rs3.GetValue(8), Rs3.GetValue(9), Rs3.GetValue(10), Rs3.GetValue(11), Rs3.GetValue(12), Rs3.GetValue(13), Rs3.GetValue(14), Rs3.GetValue(15), Rs3.GetValue(16), Rs3.GetValue(17), Rs3.GetValue(18), Rs3.GetValue(19), Rs3.GetValue(20), Rs3.GetValue(21), Rs3.GetValue(22), Rs3.GetValue(23), Rs3.GetValue(24), Rs3.GetValue(25), Rs3.GetValue(26), Rs3.GetValue(27), Rs3.GetValue(28), Rs3.GetValue(29), Rs3.GetValue(30), Rs3.GetValue(31), SUM, SUMTRA)
                        End If
                End Select
            Loop
            con.Close()
            rslt = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
        GenerarNroTrabajadores_General()
        Return rslt
    End Function
    Sub GenerarNroTrabajadores_Unegocio()
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Clear()
        Dim cmd As New SqlCommand("[CONSULTAR_NROTRABAJADORES]", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cboAñoUnidadNegocio.Text
        con.Open()
        Dim DR As SqlDataReader = cmd.ExecuteReader
        While DR.Read
            Select Case OBJ.COD_MES(cboMesUnidadNegocio.Text)
                Case "01"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "02"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "03"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "04"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), 0, 0, 0, 0, 0, 0, 0, 0)
                Case "05"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), 0, 0, 0, 0, 0, 0, 0)
                Case "06"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), 0, 0, 0, 0, 0, 0)
                Case "07"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), 0, 0, 0, 0, 0)
                Case "08"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), 0, 0, 0, 0)
                Case "09"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), 0, 0, 0)
                Case "10"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), 0, 0)
                Case "11"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), 0)
                Case "12"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), DR(14))
            End Select
        End While
        con.Close()
        GenerarDescripciones()
    End Sub
    Sub GenerarNroTrabajadores_Ccosto()
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Clear()
        Dim cmd As New SqlCommand("[CONSULTAR_NROTRABAJADORES]", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cboAñoCentroCostos.Text
        con.Open()
        Dim DR As SqlDataReader = cmd.ExecuteReader
        While DR.Read
            Select Case OBJ.COD_MES(cboMesCentroCostos.Text)
                Case "01"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "02"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "03"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "04"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), 0, 0, 0, 0, 0, 0, 0, 0)
                Case "05"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), 0, 0, 0, 0, 0, 0, 0)
                Case "06"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), 0, 0, 0, 0, 0, 0)
                Case "07"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), 0, 0, 0, 0, 0)
                Case "08"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), 0, 0, 0, 0)
                Case "09"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), 0, 0, 0)
                Case "10"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), 0, 0)
                Case "11"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), 0)
                Case "12"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), DR(14))
            End Select
        End While
        con.Close()
        GenerarDescripciones()
    End Sub
    Sub GenerarNroTrabajadores_Zona()
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Clear()
        Dim cmd As New SqlCommand("[CONSULTAR_NROTRABAJADORES]", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cboAñoZona.Text
        con.Open()
        Dim DR As SqlDataReader = cmd.ExecuteReader
        While DR.Read
            Select Case OBJ.COD_MES(cboMesZona.Text)
                Case "01"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "02"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "03"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "04"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), 0, 0, 0, 0, 0, 0, 0, 0)
                Case "05"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), 0, 0, 0, 0, 0, 0, 0)
                Case "06"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), 0, 0, 0, 0, 0, 0)
                Case "07"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), 0, 0, 0, 0, 0)
                Case "08"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), 0, 0, 0, 0)
                Case "09"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), 0, 0, 0)
                Case "10"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), 0, 0)
                Case "11"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), 0)
                Case "12"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add(DR(0), "", DR(1), "", DR(2), "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), DR(14))
            End Select
        End While
        con.Close()
        GenerarDescripciones()
    End Sub
    Sub GenerarDescripciones()
        Dim num As Integer = 0
        For Each row As DataRow In OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows
            OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).NEGOCIO = OBJ.DIR_TABLA_DESC(OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).COD_NEGOCIO, "TNEGO")
            OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).CCOSTO = OBJ.DESC_CC(OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).COD_CC)
            OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).ZONA = OBJ.DIR_TABLA_DESC(OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Item(num).COD_ZONA, "TNEGZ")
            num += 1
        Next
    End Sub
    Sub GenerarNroTrabajadores_General()
        OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Clear()
        Dim cmd As New SqlCommand("[CONSULTAR_NROTRABAJADORES]", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = cboAñoGeneral.Text
        con.Open()
        Dim DR As SqlDataReader = cmd.ExecuteReader
        While DR.Read
            Select Case OBJ.COD_MES(cboMesGeneral.Text)
                Case "01"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "02"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "03"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), 0, 0, 0, 0, 0, 0, 0, 0, 0)
                Case "04"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), 0, 0, 0, 0, 0, 0, 0, 0)
                Case "05"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), DR(7), 0, 0, 0, 0, 0, 0, 0)
                Case "06"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), 0, 0, 0, 0, 0, 0)
                Case "07"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), 0, 0, 0, 0, 0)
                Case "08"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), 0, 0, 0, 0)
                Case "09"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), 0, 0, 0)
                Case "10"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), 0, 0)
                Case "11"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), 0)
                Case "12"
                    OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES.Rows.Add("", "", "", "", "", "", DR(3), DR(4), DR(5), DR(6), DR(7), DR(8), DR(9), DR(10), DR(11), DR(12), DR(13), DR(14))
            End Select
        End While
        con.Close()
        'D1.DataSource = Nothing
        'D1.DataSource = OFR.dtEstadisticaPerdidasGanancia.REPORTE_TRABAJADORES
    End Sub

    Private Sub btnSalirCentroCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalirCentroCostos.Click, btnSalirZona.Click, btnSalirGeneral.Click
        Me.Close()
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
    Private Sub btnExcelCC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcelCC.Click
        'Validar Paramatros
        If cboCentroCostos.SelectedIndex = -1 And chkCentroCostos.Checked = True Then MessageBox.Show("Debe seleccionar el Centro Costos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboCentroCostos.Focus() : Exit Sub
        If cboMesCentroCostos.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboMesCentroCostos.Focus() : Exit Sub
        If cboAñoCentroCostos.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cboAñoCentroCostos.Focus() : Exit Sub
        '--------------------------
        'PARAMATROS
        Dim frmMes As String
        frmMes = "" : frmMes = OBJ.COD_MES(cboMesCentroCostos.Text)
        stCentroCostos = ""
        codCentroCostos = ""
        If chkCentroCostos.Checked Then
            stCentroCostos = "1"
            codCentroCostos = cboCentroCostos.SelectedValue
        Else
            stCentroCostos = "0"
            codCentroCostos = " "
        End If
        If Not bwExportar.IsBusy Then
            Dim fbd As New FolderBrowserDialog
            If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then
                rutaExcel = fbd.SelectedPath
                tslblMensaje.Text = "Generando Archivo"
                stEstado.Visible = True
                'MES0 = (OBJ.COD_MES(cbo_mes.Text))
                'DESC_MES0 = cbo_mes.Text
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
            oHoja.Range("A3:B3").Merge()
            oHoja.Range("A3:B3").Font.Bold = True
            oHoja.Range("C2:L2").Merge()
            oHoja.Range("C2:L2").Font.Bold = True
            oHoja.Cells(2, 3) = "ESTADISTICAS DE CUENTAS"
            oHoja.Range("C3:L3").Merge()
            oHoja.Range("C3:L3").Font.Bold = True
            'oHoja.Cells(3, 3) = String.Format("PERIODO: {0} DE {1}", DESC_MES0, AÑO)
            Dim strRango As String = "C2:L3"
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108

            strRango = "A5:AH5"

            oHoja.Cells(5, 1) = "Cod.Cta." : oHoja.Cells(5, 2) = "Desc.Cuenta" : oHoja.Cells(5, 3) = "Cod.Neg."
            oHoja.Cells(5, 4) = "Desc.Neg." : oHoja.Cells(5, 5) = "Cod.CC." : oHoja.Cells(5, 6) = "Desc.CC."
            oHoja.Cells(5, 7) = "Cod.Zona" : oHoja.Cells(5, 8) = "Desc.Zona" : oHoja.Cells(5, 9) = "Enero"
            oHoja.Cells(5, 10) = "Febrero" : oHoja.Cells(5, 11) = "Marzo" : oHoja.Cells(5, 12) = "Abril"
            oHoja.Cells(5, 13) = "Mayo" : oHoja.Cells(5, 14) = "Junio" : oHoja.Cells(5, 15) = "Julio"
            oHoja.Cells(5, 16) = "Agosto" : oHoja.Cells(5, 17) = "Septiembre" : oHoja.Cells(5, 18) = "Octubre"
            oHoja.Cells(5, 19) = "Noviembre" : oHoja.Cells(5, 20) = "Diciembre" : oHoja.Cells(5, 21) = "Total" : oHoja.Cells(5, 22) = "NRO_TRAB01"
            oHoja.Cells(5, 23) = "NRO_TRAB02" : oHoja.Cells(5, 24) = "NRO_TRAB03" : oHoja.Cells(5, 25) = "NRO_TRAB04"
            oHoja.Cells(5, 26) = "NRO_TRAB05" : oHoja.Cells(5, 27) = "NRO_TRAB06" : oHoja.Cells(5, 28) = "NRO_TRAB07"
            oHoja.Cells(5, 29) = "NRO_TRAB08" : oHoja.Cells(5, 30) = "NRO_TRAB09" : oHoja.Cells(5, 31) = "NRO_TRAB10"
            oHoja.Cells(5, 32) = "NRO_TRAB11" : oHoja.Cells(5, 33) = "NRO_TRAB12" : oHoja.Cells(5, 34) = "Total Trab."


            oHoja.Range("A:H").NumberFormat = "@"
            oHoja.Range("I:U").NumberFormat = "_(* #,##0.00_);_(* (#,##0.00);_(* ""-""??_);_(@_)"
            oHoja.Range("V:AH").NumberFormat = "_(* #,##0_);_(* (#,##0);_(* ""-""??_);_(@_)"

            Dim Fila As Integer = 6
            'Dim stCon As Integer
            archivoExcel = "ReporteEstadistica"

            Dim CMD As New SqlCommand("[REPORTE_ESTADISTICA_PERDIDAS_GANANCIA]", con)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@ST_UNIDADNEGOCIO", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@UNIDADNEGOCIO", SqlDbType.Char).Value = " "
            CMD.Parameters.Add("@ST_CCOSTOS", SqlDbType.Char).Value = stCentroCostos
            CMD.Parameters.Add("@CCOSTOS", SqlDbType.VarChar).Value = codCentroCostos
            CMD.Parameters.Add("@ST_ZONA", SqlDbType.Char).Value = "0"
            CMD.Parameters.Add("@ZONA", SqlDbType.Char).Value = " "
            CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            CMD.Parameters.Add("@ST_PESTAÑA", SqlDbType.Char).Value = "1"
            con.Open()
            Cmd.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Cmd.ExecuteReader
            Dim SUM As New Decimal
            Dim SUMTRA As New Decimal
            Do While Rs3.Read
              Dim CONT0 As String = mes
                Select Case CONT0
                    Case "01"
                        If Rs3.GetValue(8) <> "0.00" Then
                            SUM = Decimal.Parse(Rs3.GetValue(8))
                            SUMTRA = Decimal.Parse(Rs3.GetValue(20))

                            oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                            oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(7)


                            oHoja.Cells(Fila, 9) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 21) = SUM

                            oHoja.Cells(Fila, 22) = Rs3.GetValue(20)
                            oHoja.Cells(Fila, 34) = SUMTRA
                        End If
                    Case "02"
                        If Rs3.GetValue(8) <> "0.00" Or Rs3.GetValue(9) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)))
                            oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                            oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(7)


                            oHoja.Cells(Fila, 9) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 21) = SUM

                            oHoja.Cells(Fila, 22) = Rs3.GetValue(20)
                            oHoja.Cells(Fila, 23) = Rs3.GetValue(21)
                            oHoja.Cells(Fila, 24) = Rs3.GetValue(22)
                            oHoja.Cells(Fila, 25) = Rs3.GetValue(23)
                            oHoja.Cells(Fila, 26) = Rs3.GetValue(24)
                            oHoja.Cells(Fila, 27) = Rs3.GetValue(25)
                            oHoja.Cells(Fila, 28) = Rs3.GetValue(26)
                            oHoja.Cells(Fila, 34) = SUMTRA
                        End If
                    Case "03"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" Then

                            oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                            oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(7)


                            oHoja.Cells(Fila, 9) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 21) = SUM

                            oHoja.Cells(Fila, 22) = Rs3.GetValue(20)
                            oHoja.Cells(Fila, 23) = Rs3.GetValue(21)
                            oHoja.Cells(Fila, 24) = Rs3.GetValue(22)
                            oHoja.Cells(Fila, 25) = Rs3.GetValue(23)
                            oHoja.Cells(Fila, 26) = Rs3.GetValue(24)
                            oHoja.Cells(Fila, 27) = Rs3.GetValue(25)
                            oHoja.Cells(Fila, 28) = Rs3.GetValue(26)
                            oHoja.Cells(Fila, 34) = SUMTRA
                        End If
                    Case "04"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" Then
                            oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                            oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(7)


                            oHoja.Cells(Fila, 9) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 21) = SUM

                            oHoja.Cells(Fila, 22) = Rs3.GetValue(20)
                            oHoja.Cells(Fila, 23) = Rs3.GetValue(21)
                            oHoja.Cells(Fila, 24) = Rs3.GetValue(22)
                            oHoja.Cells(Fila, 25) = Rs3.GetValue(23)
                            oHoja.Cells(Fila, 26) = Rs3.GetValue(24)
                            oHoja.Cells(Fila, 27) = Rs3.GetValue(25)
                            oHoja.Cells(Fila, 28) = Rs3.GetValue(26)
                            oHoja.Cells(Fila, 34) = SUMTRA
                        End If
                    Case "05"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" Then
                            oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                            oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(7)


                            oHoja.Cells(Fila, 9) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 21) = SUM

                            oHoja.Cells(Fila, 22) = Rs3.GetValue(20)
                            oHoja.Cells(Fila, 23) = Rs3.GetValue(21)
                            oHoja.Cells(Fila, 24) = Rs3.GetValue(22)
                            oHoja.Cells(Fila, 25) = Rs3.GetValue(23)
                            oHoja.Cells(Fila, 26) = Rs3.GetValue(24)
                            oHoja.Cells(Fila, 27) = Rs3.GetValue(25)
                            oHoja.Cells(Fila, 28) = Rs3.GetValue(26)
                            oHoja.Cells(Fila, 34) = SUMTRA
                        End If
                    Case "06"
                        If Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" Then
                            SUM = (Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)))
                            oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                            oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(7)


                            oHoja.Cells(Fila, 9) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 21) = SUM

                            oHoja.Cells(Fila, 22) = Rs3.GetValue(20)
                            oHoja.Cells(Fila, 23) = Rs3.GetValue(21)
                            oHoja.Cells(Fila, 24) = Rs3.GetValue(22)
                            oHoja.Cells(Fila, 25) = Rs3.GetValue(23)
                            oHoja.Cells(Fila, 26) = Rs3.GetValue(24)
                            oHoja.Cells(Fila, 27) = Rs3.GetValue(25)
                            oHoja.Cells(Fila, 28) = Rs3.GetValue(26)
                            oHoja.Cells(Fila, 34) = SUMTRA
                        End If
                    Case "07"
                        If Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(8), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            SUMTRA = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(20), Rs3.GetValue(21)), Rs3.GetValue(22)), Rs3.GetValue(23)), Rs3.GetValue(24)), Rs3.GetValue(25)), Rs3.GetValue(26)))
                            oHoja.Cells(Fila, 1) = Rs3.GetValue(0)
                            oHoja.Cells(Fila, 2) = Rs3.GetValue(1)
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(2)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(3)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(4)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(5)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(7)


                            oHoja.Cells(Fila, 9) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 21) = SUM

                            oHoja.Cells(Fila, 22) = Rs3.GetValue(20)
                            oHoja.Cells(Fila, 23) = Rs3.GetValue(21)
                            oHoja.Cells(Fila, 24) = Rs3.GetValue(22)
                            oHoja.Cells(Fila, 25) = Rs3.GetValue(23)
                            oHoja.Cells(Fila, 26) = Rs3.GetValue(24)
                            oHoja.Cells(Fila, 27) = Rs3.GetValue(25)
                            oHoja.Cells(Fila, 28) = Rs3.GetValue(26)
                            oHoja.Cells(Fila, 34) = SUMTRA
                        End If
                    Case "08"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "09"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "10"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(16)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "11"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" OrElse Rs3.GetValue(17) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(16)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(17)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                    Case "12"
                        If Rs3.GetValue(6) <> "0.00" OrElse Rs3.GetValue(7) <> "0.00" OrElse Rs3.GetValue(8) <> "0.00" OrElse Rs3.GetValue(9) <> "0.00" OrElse Rs3.GetValue(10) <> "0.00" OrElse Rs3.GetValue(11) <> "0.00" OrElse Rs3.GetValue(12) <> "0.00" OrElse Rs3.GetValue(13) <> "0.00" OrElse Rs3.GetValue(14) <> "0.00" OrElse Rs3.GetValue(15) <> "0.00" OrElse Rs3.GetValue(16) <> "0.00" OrElse Rs3.GetValue(17) <> "0.00" OrElse Rs3.GetValue(18) <> "0.00" Then
                            SUM = Decimal.Parse(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Decimal.Add(Rs3.GetValue(6), Rs3.GetValue(7)), Rs3.GetValue(8)), Rs3.GetValue(9)), Rs3.GetValue(10)), Rs3.GetValue(11)), Rs3.GetValue(12)), Rs3.GetValue(13)), Rs3.GetValue(14)), Rs3.GetValue(15)), Rs3.GetValue(16)), Rs3.GetValue(17)), Rs3.GetValue(18)))
                            oHoja.Cells(Fila, 3) = Rs3.GetValue(6)
                            oHoja.Cells(Fila, 4) = Rs3.GetValue(7)
                            oHoja.Cells(Fila, 5) = Rs3.GetValue(8)
                            oHoja.Cells(Fila, 6) = Rs3.GetValue(9)
                            oHoja.Cells(Fila, 7) = Rs3.GetValue(10)
                            oHoja.Cells(Fila, 8) = Rs3.GetValue(11)
                            oHoja.Cells(Fila, 9) = Rs3.GetValue(12)
                            oHoja.Cells(Fila, 10) = Rs3.GetValue(13)
                            oHoja.Cells(Fila, 11) = Rs3.GetValue(14)
                            oHoja.Cells(Fila, 12) = Rs3.GetValue(15)
                            oHoja.Cells(Fila, 13) = Rs3.GetValue(16)
                            oHoja.Cells(Fila, 14) = Rs3.GetValue(17)
                            oHoja.Cells(Fila, 15) = Rs3.GetValue(18)
                            oHoja.Cells(Fila, 17) = SUM
                        End If
                End Select
                Fila += 1
            Loop
            Rs3.Close()
            con.Close()

            oHoja.Range(strRango).Cells.BorderAround(1, 2)
            oHoja.Range(strRango).Interior.Pattern = 1
            oHoja.Range(strRango).Interior.ColorIndex = 49
            oHoja.Range(strRango).Font.Bold = True
            oHoja.Range(strRango).Font.ColorIndex = 2
            oHoja.Range(strRango).VerticalAlignment = -4108
            oHoja.Range(strRango).HorizontalAlignment = -4108
            oHoja.Range(String.Format("A6:AH{0}", Fila - 1)).Cells.BorderAround(1, 2)
            oHoja.Range(String.Format("A6:AH{0}", Fila - 1)).Interior.ColorIndex = 2

            oHoja.Columns.AutoFit()
            oLibro.SaveAs(String.Format("{0}\{1}.xls", rutaExcel, archivoExcel), True)
        Catch ex As Exception
            Exito = False
            MessageBox.Show(String.Format("Error al generar el archivo excel.{0}{1}", Environment.NewLine, ex.Message), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            oHoja = Nothing
            oLibro.Close(False)
            oLibro = Nothing
            oExcel.Quit()
            oExcel = Nothing
            System.GC.Collect(0)
            System.GC.WaitForPendingFinalizers()
        End Try
    End Sub
End Class