Imports System.Data.SqlClient
Public Class TIPO_PLANILLA
    Dim obj As New Class1
    Dim Servidor, BaseDatos As String
    Private cnMadre As New SqlConnection
    Public FeAño, FeMes As String
    Public _esValido As Boolean = False



    Private Sub TIPO_PLANILLA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Servidor = obj.DIR_TABLA_DESC("MADRE", "TDEFA")
        'Servidor = "10.0.11.31\rese_ofisis"
        BaseDatos = obj.DIR_TABLA_DESC("MBASE", "TDEFA")
        txtServidor.Text = Servidor
        txtBaseDatos.Text = BaseDatos
        'cnMadre.ConnectionString = "data source=" & Servidor & ";initial catalog=" & BaseDatos & ";uid=miguel;pwd=main;"
        cnMadre.ConnectionString = "data source=" & Servidor & ";initial catalog=" & BaseDatos & ";uid=OFISIS;pwd=CQ5001;"

        CargarTipoPlanilla()
        CARGAR_AÑO()
        cboAño.Text = AÑO
        cboMes.Text = MES
        



    End Sub

    Private Function ObtenerUsuarioCierre() As String
        Dim con As New SqlConnection(cnMadre.ConnectionString)
        Dim usuarioCierre As String
        Try
            con.Open()
            Dim cmd As New SqlCommand("(SELECT TOP 1 CO_USUA_MODI FROM TTCNTR_PLAN WHERE NU_ANNO = " + AÑO + " AND NU_PERI = " + MES + " AND FE_USUA_MODI = (SELECT MAX(FE_USUA_MODI) FROM TTCNTR_PLAN WHERE NU_ANNO = " + AÑO + " AND NU_PERI = " + MES + " ))", con)
            cmd.CommandType = (CommandType.Text)
            cmd.CommandTimeout = 720
            usuarioCierre = cmd.ExecuteScalar
            con.Close()
            ' Return drd
        Catch ex As Exception
            usuarioCierre = ""
            con.Close()
            MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If usuarioCierre = Nothing Then
            usuarioCierre = ""
        End If

        Return usuarioCierre

    End Function

    Private Function ObtenerFechaCierre() As String
        Dim con As New SqlConnection(cnMadre.ConnectionString)
        Dim fechaCierre As Date
        Try
            con.Open()
            Dim cmd As New SqlCommand("(SELECT TOP 1 FE_USUA_MODI FROM TTCNTR_PLAN WHERE NU_ANNO = " + AÑO + " AND NU_PERI = " + MES + " AND FE_USUA_MODI = (SELECT MAX(FE_USUA_MODI) FROM TTCNTR_PLAN WHERE NU_ANNO = " + AÑO + " AND NU_PERI = " + MES + " ))", con)
            cmd.CommandType = (CommandType.Text)
            cmd.CommandTimeout = 720
            fechaCierre = cmd.ExecuteScalar
            con.Close()
            ' Return drd
        Catch ex As Exception

            con.Close()
            MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    

        Return fechaCierre.ToString()

    End Function
   
    Private Sub CargarTipoPlanilla()
        Dim dt As DataTable = New DataTable("Tabla")

        dt.Columns.Add("Codigo")
        dt.Columns.Add("Descripcion")

        Dim dr As DataRow
        '1.- Asiento de Planilla (Mensual) --- PLE
        '2.- Asiento de Liquidación ---- LIQ
        '3.- Asiento de Provisión de Gratificación --- PRG
        '4.- Asiento de Provisión de CTS ---- PRT
        '5.- Asiento de Provisión de Vacaciones  --- PRV
        dr = dt.NewRow()
        dr("Codigo") = "PLE"
        dr("Descripcion") = "Asiento de Planilla (Mensual)"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "LIQ"
        dr("Descripcion") = "Asiento de Liquidación"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "PRG"
        dr("Descripcion") = "Asiento de Provisión de Gratificación"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "PRT"
        dr("Descripcion") = "Asiento de Provisión de CTS"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "PRV"
        dr("Descripcion") = "Asiento de Provisión de Vacaciones"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "QUI"
        dr("Descripcion") = "Asiento de Planilla (Quincena)"
        dt.Rows.Add(dr)

        cboTipo.DataSource = dt
        cboTipo.ValueMember = "Codigo"
        cboTipo.DisplayMember = "Descripcion"
    End Sub

    Public Function Obtener_TDASIE_CTBL() As SqlDataReader

        Dim con As New SqlConnection(cnMadre.ConnectionString)
        Dim drd As SqlDataReader = Nothing
        Try
            con.Open()
            Dim cmd As New SqlCommand("OBTENER_TDASIE_CTBL", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@COD_EMPRESA", SqlDbType.VarChar).Value = COD_EMPRESA
            cmd.Parameters.Add("@CO_ASI", SqlDbType.VarChar).Value = cboTipo.SelectedValue
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Int).Value = cboAño.Text
            cmd.Parameters.Add("@FE_MES ", SqlDbType.Int).Value = cboMes.Text
            cmd.CommandTimeout = 720
            drd = cmd.ExecuteReader(CommandBehavior.SingleResult)
            'con.Close()
            ' Return drd
        Catch ex As Exception
            ' Return drd
            con.Close()
            MessageBox.Show(ex.Message, "Error en la aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return drd

    End Function

    Sub CARGAR_AÑO()
        Try
            Dim PROG_01 As New SqlCommand("MOSTRAR_AÑO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cboAño.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub btnDataBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDataBase.Click
        If cboTipo.SelectedIndex = -1 Then
            MessageBox.Show("Debe Seleccionar el tipo de planilla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboTipo.Focus()
        ElseIf cboAño.SelectedIndex = -1 Then
            MessageBox.Show("Debe Seleccionar el año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboAño.Focus()
        ElseIf cboMes.SelectedIndex = -1 Then
            MessageBox.Show("Debe Seleccionar el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
            cboMes.Focus()
        Else
            _esValido = True
            FeAño = cboAño.Text
            FeMes = cboMes.Text
            'Obtener_TDASIE_CTBL()
            Close()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

   
    Private Sub cboTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

        txtFechaCierrePlanilla.Text = ObtenerFechaCierre()
        txtUsuCierrePlanilla.Text = ObtenerUsuarioCierre()
        
    End Sub
End Class