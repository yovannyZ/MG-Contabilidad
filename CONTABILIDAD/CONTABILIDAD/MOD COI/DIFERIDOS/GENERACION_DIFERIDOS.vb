Public Class GENERACION_DIFERIDOS
    Dim Obj As New Class1

#Region "Métodos y Funciones"

    'Cargas Iniciales

    Sub CARGAR_AÑO()
        cboAño.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_AÑO_TODO", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            con.Open()
            Using Rs3 As SqlDataReader = PROG_01.ExecuteReader()
                Do While Rs3.Read
                    cboAño.Items.Add(Rs3.GetString(0))
                Loop
            End Using
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            con.Close()
        End Try

    End Sub

    'Para la generación del diferido

    Private Function TraerDetallesDiferidosCC() As List(Of DiferidosCC)
        Dim LSDiferidoSCC As New List(Of DiferidosCC)
        Try
            Dim cmd As New SqlCommand("TRAER_DIFERIDOS_CC", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@MES", SqlDbType.Char).Value = MES
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            Dim I As Integer

            Dim dr As DataRow
            Dim ObjDiferidoCC As DiferidosCC

            For I = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(I)
                ObjDiferidoCC = New DiferidosCC
                With ObjDiferidoCC
                    .CodigoDocumento = dr(0)
                    .NumeroDocumento = dr(1)
                    .CodigoPersona = dr(2)
                    .CodigoCentroCostos = dr(3)
                    .CodigoCuenta = dr(4)
                    .PorcentajeDiferir = dr(5)
                    .Importe = dr(6)
                    .Cuotas = dr(7)
                    .CuotasTransferidas = dr(8)
                    .FechaInicioOp = dr(9)
                    '.NumeroSecuencia = dr(10)
                    .Año = dr(10)
                    .Mes = dr(11)
                    .MesDif = dr(12)
                    .AñoDif = dr(13)
                End With
                LSDiferidoSCC.Add(ObjDiferidoCC)
            Next
        Catch ex As Exception
            MessageBox.Show("Error al generar los datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            LSDiferidoSCC.Clear()
        End Try
        Return LSDiferidoSCC
    End Function

    Private Function CALCULAR_DIFERIDO() As List(Of Diferido)
        Dim MesDif, AñoDif As String
        Dim LSDiferido As New List(Of Diferido)
        Dim objDiferido As Diferido
        Dim FechaFacturacionCuota As Date 'FechaInicioOperacion, FechaPago
        Dim LODiferidosCC As List(Of DiferidosCC) = TraerDetallesDiferidosCC()
        If LODiferidosCC.Count > 0 Then
            Dim i As Integer
            For i = 0 To LODiferidosCC.Count - 1

                objDiferido = New Diferido
                'Hacemos la validación del mes a diferir
                AñoDif = LODiferidosCC(i).AñoDif
                MesDif = LODiferidosCC(i).MesDif
                If LODiferidosCC(i).CuotasTransferidas < LODiferidosCC(i).Cuotas Then
                    If MES = MesDif AndAlso AÑO = AñoDif Then
                        FechaFacturacionCuota = RecuperarFechaCierre(AÑO, MES, "COI")
                        With objDiferido
                            .Cuenta = LODiferidosCC(i).CodigoCuenta
                            .Glosa = Obj.DESC_CUENTA(.Cuenta, AÑO)
                            .CodigoDocumento = LODiferidosCC(i).CodigoDocumento
                            .NumeroDocumento = LODiferidosCC(i).NumeroDocumento
                            '.FechaCuota = RecuperarFechaCierre(AÑO, MES, "COI") 'Falta validar si es bi,tri ... 
                            .FechaCuota = FechaFacturacionCuota 'FechaPago
                            .CodigoCliente = LODiferidosCC(i).CodigoPersona
                            .Importe = Obj.HACER_DECIMAL(CDbl((LODiferidosCC(i).Importe * (LODiferidosCC(i).PorcentajeDiferir / 100)) / LODiferidosCC(i).Cuotas))
                            .D_H = "D"
                            .Moneda = Obj.RecuperarCodigoMonedaDocumento(LODiferidosCC(i).Año, LODiferidosCC(i).Mes, LODiferidosCC(i).CodigoDocumento, LODiferidosCC(i).NumeroDocumento)
                            .TipoCambio = Obj.RecuperarTipoCambio(AÑO, MES, "D")
                            .CentroCosto = LODiferidosCC(i).CodigoCentroCostos
                            .NroCuota = CInt(LODiferidosCC(i).CuotasTransferidas + 1).ToString("00")
                        End With
                        LSDiferido.Add(objDiferido)
                    End If
                End If
                'Esto sirve si pasa algo lo regresas
                'FechaInicioOperacion = LODiferidosCC(i).FechaInicioOp
                ''Valido que el número de cuotas transferidas se menor que el total de cuotas
                'If LODiferidosCC(i).CuotasTransferidas < LODiferidosCC(i).Cuotas Then
                '    'Aqui validamos si es que se inserta en el trimestral,cuaternal,quimestral, semestral
                '    FechaPago = FechaInicioOperacion.AddMonths(LODiferidosCC(i).NumeroSecuencia * (LODiferidosCC(i).CuotasTransferidas + 1))
                '    FechaFacturacionCuota = RecuperarFechaCierre(Year(FechaPago), Month(FechaPago), "COI")
                '    'RecuperarFechaCierre(Year(FechaPago), Month(FechaPago), "COI")
                '    If (FechaFacturacionCuota.Date = FECHA_GRAL) Then
                '        With objDiferido
                '            .Cuenta = LODiferidosCC(i).CodigoCuenta
                '            .Glosa = Obj.DESC_CUENTA(.Cuenta, AÑO)
                '            .CodigoDocumento = LODiferidosCC(i).CodigoDocumento
                '            .NumeroDocumento = LODiferidosCC(i).NumeroDocumento
                '            '.FechaCuota = RecuperarFechaCierre(AÑO, MES, "COI") 'Falta validar si es bi,tri ... 
                '            .FechaCuota = FechaFacturacionCuota 'FechaPago
                '            .CodigoCliente = LODiferidosCC(i).CodigoPersona
                '            .Importe = Obj.HACER_DECIMAL(CDbl((LODiferidosCC(i).Importe * (LODiferidosCC(i).PorcentajeDiferir / 100)) / LODiferidosCC(i).Cuotas))
                '            .D_H = "D"
                '            .Moneda = Obj.RecuperarCodigoMonedaDocumento(LODiferidosCC(i).Año, LODiferidosCC(i).Mes, LODiferidosCC(i).CodigoDocumento, LODiferidosCC(i).NumeroDocumento)
                '            .TipoCambio = Obj.RecuperarTipoCambio(AÑO, MES, "D")
                '            .CentroCosto = LODiferidosCC(i).CodigoCentroCostos
                '            .NroCuota = CInt(LODiferidosCC(i).CuotasTransferidas + 1).ToString("00")
                '        End With
                '        LSDiferido.Add(objDiferido)
                '    End If
                'End If
            Next
        End If
        Return LSDiferido
    End Function

    Private Sub GRABAR_DIFERIDO()
        'Dim LODiferido As List(Of Diferido) = CALCULAR_DIFERIDO()
        Dim LsDiferir As List(Of Diferido) = CALCULAR_DIFERIDO()
        If LsDiferir.Count <= 0 Then Exit Sub
        Dim trx As SqlTransaction = Nothing
        Dim i As Integer
        Try
            con.Open()
            trx = con.BeginTransaction()
            For i = 0 To LsDiferir.Count - 1
                With LsDiferir(i)
                    Dim cmd As New SqlCommand("INSERTAR_T_DIFERIDO", con, trx)
                    cmd.CommandType = CommandType.StoredProcedure

                    cmd.Parameters.AddWithValue("@FE_AÑO", AÑO)
                    cmd.Parameters.AddWithValue("@FE_MES", MES)

                    cmd.Parameters.AddWithValue("@CUENTA", .Cuenta)
                    cmd.Parameters.AddWithValue("@GLOSA", .Glosa)
                    cmd.Parameters.AddWithValue("@COD_DOC", .CodigoDocumento)
                    cmd.Parameters.AddWithValue("@NRO_DOC", .NumeroDocumento)
                    cmd.Parameters.AddWithValue("@FECHA", .FechaCuota)
                    cmd.Parameters.AddWithValue("@COD_PER", .CodigoCliente)
                    cmd.Parameters.AddWithValue("@IMPORTE", .Importe)
                    cmd.Parameters.AddWithValue("@COD_D_H", .D_H)
                    cmd.Parameters.AddWithValue("@COD_MONEDA", .Moneda)
                    cmd.Parameters.AddWithValue("@TIPO_CAMBIO", .TipoCambio)
                    cmd.Parameters.AddWithValue("@COD_CC", .CentroCosto)
                    cmd.Parameters.AddWithValue("@NRO_CUOTA", .NroCuota)
                    cmd.Parameters.AddWithValue("@ST_TRANS", "0")
                    cmd.ExecuteNonQuery()
                End With
            Next
            trx.Commit()
            MessageBox.Show("Se Grabaron con éxito los diferidos", "Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            trx.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Function RecuperarFechaCierre(ByVal año As String, ByVal mes As Integer, ByVal cod As String) As Date
        Dim FechaCierre As Date
        Try
            Dim cmd As New SqlCommand("RECUPERAR_FECHA_CIERRE", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = año
            cmd.Parameters.Add("@MES", SqlDbType.Char).Value = mes.ToString("00")
            cmd.Parameters.Add("@COD", SqlDbType.Char).Value = cod
            con.Open()
            FechaCierre = CDate(cmd.ExecuteScalar)
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If FechaCierre = Nothing Then
            FechaCierre = Date.Now
        End If
        Return FechaCierre
    End Function
    'Para la Eliminación del diferido

    Private Sub ELIMINAR_DIFERIDOS_MES()
        Try
            Dim cmd As New SqlCommand("ELIMINAR_T_DIFERIDO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@AÑO", SqlDbType.Char).Value = cboAño.Text
            cmd.Parameters.Add("@MES", SqlDbType.Char).Value = cboMes.Text
            con.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()
            con.Close()
            If i > 0 Then
                MessageBox.Show("Se eliminaron todos los diferidos del mes " & cboMes.Text & _
                                  " del Año " & cboAño.Text, "Elimación Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No hay diferidos en el mes por eliminar", "Elimación Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub REGRESAR_NRO_SECUENCIA()
        Dim dt As New DataTable("ListaADestransferir")
        Try
            'CARGAMOS LAS CUENTAS A REGRESAR
            Dim PRO As New SqlCommand("CUENTAS_A_REGRESAR", con)
            PRO.CommandType = CommandType.StoredProcedure
            PRO.Parameters.Add("@AÑO", SqlDbType.Char).Value = cboAño.Text
            PRO.Parameters.Add("@MES", SqlDbType.Char).Value = cboMes.Text
            Dim da As New SqlDataAdapter(PRO)
            da.Fill(dt)

            For Each row As DataRow In dt.Rows

                'REGRESAMOS EL NUMERO DE TRANSFERENCIA

                Dim cmd As New SqlCommand("REGRESA_NRO_TRANSFERIDO", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = row(0)
                cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = row(1)
                cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = row(2)
                cmd.Parameters.Add("@IMPORTE", SqlDbType.Decimal).Value = row(3)
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Function CONSULTAR_EXISTENCIA() As Boolean
        Dim dato As String
        Dim key As Boolean
        Try
            Dim cmd As New SqlCommand("VERIFICAR_DIFERIDO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = Month(FECHA_GRAL.AddMonths(1))
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = Year(FECHA_GRAL.AddMonths(1))
            con.Open()
            dato = CInt(cmd.ExecuteScalar)
            con.Close()
            If dato = Nothing Then dato = 0
            If dato = 0 Then key = True
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return key
    End Function

#End Region

#Region "Eventos"

    Private Sub GENERACION_DIFERIDOS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CARGAR_AÑO()
        cboAño.Text = AÑO
        cboMes.Text = MES
    End Sub

#End Region

    Structure Diferido
        Public Cuenta As String
        Public Glosa As String
        Public CodigoDocumento As String
        Public NumeroDocumento As String
        Public FechaCuota As Date
        Public NroDias As Integer
        Public CodigoCliente As String
        Public Importe As Decimal
        Public D_H As String
        Public Moneda As String
        Public TipoCambio As Double
        Public CentroCosto As String
        Public NroCuota As String
    End Structure

    Structure DiferidosCC
        Public CodigoDocumento As String
        Public NumeroDocumento As String
        Public CodigoPersona As String
        Public CodigoCentroCostos As String
        Public CodigoCuenta As String
        Public PorcentajeDiferir As Double
        Public Importe As Double
        Public Cuotas As Integer
        Public CuotasTransferidas As Integer
        Public FechaInicioOp As Date
        'Se descarto el numero de secuencia por la tabla I_DIFERIDO_SECUENCIA
        'Public NumeroSecuencia As Integer
        Public Año As String
        Public Mes As String
        Public AñoDif As String
        Public MesDif As String
    End Structure

#Region "Botones"

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        GRABAR_DIFERIDO()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

        If Obj.VERIFICAR_CIERRE_PERIODO(cboAño.Text, cboMes.Text, "COI") = "0" Then
            Dim result = MessageBox.Show("¿Está seguro de eliminar los registros?", "Diferidos", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                If CONSULTAR_EXISTENCIA() = True Then
                    REGRESAR_NRO_SECUENCIA()
                    ELIMINAR_DIFERIDOS_MES()
                Else
                    MessageBox.Show("No puede eliminar el registro de Diferidos" & vbNewLine & _
                                    "Asegurese que de que no haya registro en los meses posteriores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Else
            MessageBox.Show("El periódo se encuentra bloqueado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

#End Region
    
End Class