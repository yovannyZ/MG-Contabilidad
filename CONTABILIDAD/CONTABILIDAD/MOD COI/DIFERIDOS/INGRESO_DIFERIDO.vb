Imports System.Data.SqlClient
Imports System.Text
Public Class INGRESO_DIFERIDO
    Dim TIPO_OP, TIPO_DIST As String
    Dim OBJ As New Class1
    Dim ofr As New DIALOG_ORDEN_PROD
    Dim ofrTcon As New frmDialog_Contabilidad
    Dim ofrSecuenciaDiferido As New frmDialogoDiferidoSecuencia
    'Variables de la cabecera
    Dim FE_Año, FE_Mes, CodDocumento, NroDocumento, CodPer, CodCuenta, Glosa, CodAux, CodComprobante, NroComprobante, NMES, NRODOCPER, Item, _
        CodReferencia, NroReferencia, Moneda, Cuenta As String
    Dim FechaDoc, FechaVigDel, FechaVigAl, FechaIniOpe As DateTime
    Dim Tc As Double
    Dim DT As New DataTable

#Region "Metodos y Funciones"

    Private Function VALIDAR_DETALLE_DIFERIDO() As Boolean
        Dim estado As Boolean = True
        Dim tf, i As Integer
        Dim totalPorcentajes As Double = 0
        tf = dgvDetalleDiferido.Rows.Count - 1 : i = 0
        While (i <= tf)
            totalPorcentajes += CDbl(dgvDetalleDiferido.Item(4, i).Value)
            i += 1
        End While
        If totalPorcentajes <> 100 Then estado = False
        Return estado
    End Function

    Private Function VALIDAR_I_DIFERIDO(ByVal CodigoDocumento As String, ByVal NumeroDocumento As String, ByVal CodigoPersona As String) As String
        Dim Key As String = String.Empty
        Try
            Dim cmd As New SqlCommand("VERIFICAR_I_DIFERIDO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = CodigoDocumento
            cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NumeroDocumento
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = CodigoPersona
            con.Open()
            Key = CStr(cmd.ExecuteScalar)
            con.Close()
        Catch ex As SqlException
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Key
    End Function

    Private Sub CARGAR_CUENTAS_CBO()
        Try
            Dim cmd As New SqlCommand("A_COD_TABLA_DIR", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@T_COD", SqlDbType.VarChar).Value = "T_DIF"
            con.Open()
            Dim iar As IAsyncResult = cmd.BeginExecuteReader
            Using Rs As SqlDataReader = cmd.EndExecuteReader(iar)
                While (Rs.Read)
                    cboCuenta.Items.Add(Rs.GetValue(0))
                End While
            End Using
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub INSERTAR_ORDEN()
        Dim Orden As New StringBuilder
        Dim num As Integer = ofr.dgvListaDiferidos.Rows.Count - 1

        If CDbl(ofr.txtFaltante.Text) <> CDbl(ofr.txtTotal.Text) Then
            MessageBox.Show("El total no puede ser diferente a del faltante", "Ingreso Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim i As Integer = 0
        Dim porcentaje As Double = 0
        Dim cc, cuenta As String
        Try
            Do While (i <= num)
                Dim j As Integer
                Dim existe As Boolean = False
                For j = 0 To dgvDetalleDiferido.Rows.Count - 1
                    If ofr.dgvListaDiferidos.Item(0, i).Value = dgvDetalleDiferido.Item(0, j).Value Then
                        existe = True
                        Orden.AppendLine(ofr.dgvListaDiferidos.Item(0, i).Value)
                        Exit For
                    End If
                Next
                If Not existe Then
                    porcentaje = ofr.dgvListaDiferidos.Item(2, i).Value
                    cc = ofr.dgvListaDiferidos.Item(0, i).Value
                    cuenta = ofr.dgvListaDiferidos.Item(1, i).Value
                    dgvDetalleDiferido.Rows.Add(cc, OBJ.DESC_CC(cc), cuenta, OBJ.DESC_CUENTA(cuenta, AÑO), OBJ.HACER_DECIMAL(porcentaje))
                End If
                i += 1
            Loop
            If Orden.Length > 0 Then
                MessageBox.Show("Las sgtes CC no se agregaron por que ya existen: " + vbCrLf + Orden.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cargar las ordenes de producción: " + vbCrLf + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub INSERTAR_COMPROBANTE()
        If (ofrTcon.dgvTCon.CurrentCell.RowIndex).ToString = Nothing Then Exit Sub

        Dim idx As Integer = ofrTcon.dgvTCon.CurrentCell.RowIndex
        Try
            txtAuxiliar.Text = ofrTcon.dgvTCon.Item(2, idx).Value
            txtCodComprobante.Text = ofrTcon.dgvTCon.Item(3, idx).Value
            txtNroComprobante.Text = ofrTcon.dgvTCon.Item(4, idx).Value
            txtCodDoc.Text = ofrTcon.dgvTCon.Item(5, idx).Value
            txtNroDoc.Text = ofrTcon.dgvTCon.Item(6, idx).Value
            txtCodPer.Text = ofrTcon.dgvTCon.Item(7, idx).Value
            NRODOCPER = ofrTcon.dgvTCon.Item(8, idx).Value
            Item = ofrTcon.dgvTCon.Item(9, idx).Value
            CodReferencia = ofrTcon.dgvTCon.Item(10, idx).Value
            NroReferencia = ofrTcon.dgvTCon.Item(11, idx).Value
            Glosa = ofrTcon.dgvTCon.Item(13, idx).Value
            txtImporte.Text = ofrTcon.dgvTCon.Item(14, idx).Value
            Moneda = ofrTcon.dgvTCon.Item(16, idx).Value
            Tc = ofrTcon.dgvTCon.Item(15, idx).Value
            dtpFechaDoc.Value = CDate(ofrTcon.dgvTCon.Item(17, idx).Value)
            'Pasamos la fecha del documento a los combos de fecha
            dtpFechaInicioOp.Value = CDate(ofrTcon.dgvTCon.Item(17, idx).Value)
            dtpFechaVigDel.Value = CDate(ofrTcon.dgvTCon.Item(17, idx).Value)
            dtpFechaVigAl.Value = CDate(ofrTcon.dgvTCon.Item(17, idx).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ORDENPROD()
        Dim i As Integer = 0
        Dim TFilas = dgvDetalleDiferido.RowCount - 1
        Dim porcentaje As Double = 0
        ofr.dgvListaDiferidos.Rows.Clear()
        Do While (i <= TFilas)
            ' ofr.dgvListaDiferidos.Rows.Add(dgvDetalleDiferido.Item(0, i).Value, dgvDetalleDiferido.Item(2, i).Value, dgvDetalleDiferido.Item(4, i).Value)
            porcentaje += CDbl(dgvDetalleDiferido.Item(4, i).Value)
            i += 1
        Loop
        Try


            'Eviamos la suma de los porcentajes
            ofr.txtTIngreso.Text = porcentaje
            ofr.ShowDialog()
            If (ofr.DialogResult = Windows.Forms.DialogResult.OK) Then
                INSERTAR_ORDEN()
                ofr.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cargar las ordenes de producción: " + vbCrLf + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LlamarTcon()
        Try
            ofrTcon.CargarDocumentos(AÑO, MES, cboCuenta.Text)
            ofrTcon.ShowDialog()
            If (ofrTcon.DialogResult = Windows.Forms.DialogResult.OK) Then
                'Insertamos el comprobante seleccionado
                INSERTAR_COMPROBANTE()
                ofr.Hide()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Sub CARGAR_AÑO()
        CBO_AÑO.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CARGAR_AÑO_TODO", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            con.Open()
            Using Rs3 As SqlDataReader = PROG_01.ExecuteReader()
                Do While Rs3.Read
                    CBO_AÑO.Items.Add(Rs3.GetString(0))
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

    Sub MOSTRAR_DIFERIDOS()
        dgvDetalleDiferido.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("MOSTRAR_T_DIFERIDO_CC", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            cmd.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = txtCodDoc.Text
            cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txtNroDoc.Text
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txtCodPer.Text
            con.Open()
            Dim iar As IAsyncResult = cmd.BeginExecuteReader()
            Using rs As SqlDataReader = cmd.EndExecuteReader(iar)
                While (rs.Read)
                    dgvDetalleDiferido.Rows.Add(rs.GetValue(0), (rs.GetValue(1)), rs.GetValue(2), rs.GetValue(3), rs.GetValue(4))
                End While
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

    Private Sub limpiar()
        txtAuxiliar.Clear()
        txtCodComprobante.Clear()
        txtCodDoc.Clear()
        txtCodPer.Clear()
        txtImporte.Clear()
        txtNroComprobante.Clear()
        txtNroCuotas.Clear()
        txtNroDoc.Clear()
    End Sub

    Sub CrearDataTableIDiferidoSecuencia()
        DT.Columns.Add("FE_AÑO")
        DT.Columns.Add("FE_MES")
        DT.Columns.Add("COD_DOC")
        DT.Columns.Add("NRO_DOC")
        DT.Columns.Add("COD_PER")
        DT.Columns.Add("AÑO_DIF")
        DT.Columns.Add("MES_DIF")
    End Sub

#End Region

#Region "Botones"

    Private Sub btnDiferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiferir.Click
        If String.IsNullOrEmpty(txtNroCuotas.Text) Then MessageBox.Show("Debe ingresar el numero de cuotas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information) : txtNroCuotas.Focus() : Exit Sub
        ofrSecuenciaDiferido.FechaInicioOp = dtpFechaInicioOp.Value
        ofrSecuenciaDiferido.secuencia = Short.Parse(txtNroCuotas.Text)
        ofrSecuenciaDiferido.ShowDialog()
        If (ofrSecuenciaDiferido.DialogResult = Windows.Forms.DialogResult.OK) Then
            'Guardamos las fechas de manera temporal Ejecutamos el método 'Leemos nuestra grilla 
            DT.Rows.Clear()
            For i As Integer = 0 To ofrSecuenciaDiferido.dgvFechaDif.RowCount - 1
                If (ofrSecuenciaDiferido.dgvFechaDif.Item(3, i).Value = True) Then
                    DT.Rows.Add(CBO_AÑO.Text, CBO_MES.Text, txtCodDoc.Text, txtNroDoc.Text, txtCodPer.Text, ofrSecuenciaDiferido.dgvFechaDif.Item(2, i).Value, ofrSecuenciaDiferido.dgvFechaDif.Item(1, i).Value)
                End If
            Next
            ofrSecuenciaDiferido.Hide()
            btn_op.Focus()
            'Bloqueamos los controles del diferido
            btnDiferir.Enabled = False
            txtNroCuotas.Enabled = False
        End If
    End Sub

    Private Sub btn_mod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Eliminar.Click
        Try
            Dim i As Integer = dgvDetalleDiferido.CurrentRow.Index
        Catch ex As Exception
            MessageBox.Show("Debe elegir un detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End Try
        Try
            If (((CInt(MessageBox.Show(("Eliminar la orden nroº : " & dgvDetalleDiferido.Item(0, dgvDetalleDiferido.CurrentRow.Index).Value.ToString), "ESTA SEGURO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)))) = 6) Then
                dgvDetalleDiferido.Rows.RemoveAt(dgvDetalleDiferido.CurrentRow.Index)
            End If
        Catch ex As Exception
            MessageBox.Show("No se puede quitar el detalle", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btn_TRansf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_TRansf.Click
        Dim I, CONT As Integer
        I = 0 : CONT = dgvDetalleDiferido.RowCount - 1
        If CONT = -1 Then
            MessageBox.Show("No existen registro para grabar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If VALIDAR_DETALLE_DIFERIDO() = False Then
            MessageBox.Show("El total de porcentajes no debe ser difierente de 100", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim RPTA As MsgBoxResult
        RPTA = MessageBox.Show("Los cambios se guardaran en la Base de Datos" & vbCrLf & "¿Esta seguro de realizar la operación?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If RPTA = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim Graba As Boolean = True
        'Insertamos la cabecera
        Try
            Dim cmd As New SqlCommand("INSERTAR_I_DIFERIDO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            cmd.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txtCodDoc.Text
            cmd.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = txtNroDoc.Text
            cmd.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txtCodPer.Text
            cmd.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = dtpFechaDoc.Value
            cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = cboCuenta.Text
            cmd.Parameters.Add("@GLOSA", SqlDbType.VarChar).Value = Glosa
            cmd.Parameters.Add("@FECHA_VIG_DEL", SqlDbType.DateTime).Value = dtpFechaVigDel.Value.Date
            cmd.Parameters.Add("@FECHA_VIG_AL", SqlDbType.DateTime).Value = dtpFechaVigAl.Value.Date
            cmd.Parameters.Add("@FECHA_INI_OPE", SqlDbType.DateTime).Value = dtpFechaInicioOp.Value.Date
            cmd.Parameters.Add("@IMPORTE", SqlDbType.Decimal).Value = txtImporte.Text
            cmd.Parameters.Add("@NRO_CUOTAS", SqlDbType.Int).Value = txtNroCuotas.Text
            cmd.Parameters.Add("@NRO_CUOTAS_TRAN", SqlDbType.Int).Value = 0
            cmd.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = txtAuxiliar.Text
            cmd.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = txtCodComprobante.Text 'CodComprobante
            cmd.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = txtNroComprobante.Text
            cmd.Parameters.Add("@IMP_ACUMULADO", SqlDbType.Decimal).Value = 0
            cmd.Parameters.Add("@IMP_INICIAL_AÑO", SqlDbType.Decimal).Value = 0
            con.Open()
            Dim iar As IAsyncResult = cmd.BeginExecuteNonQuery()
            cmd.EndExecuteNonQuery(iar)
            'Aquí insertamos en el I_DIFERIDO_SECUENCIA
            Dim sqlbc As New SqlBulkCopy(con)
            sqlbc.DestinationTableName = "DBO.I_DIFERIDO_SECUENCIA"
            sqlbc.WriteToServer(DT)

            'Insertamos los detalles
            For I = 0 To CONT
                Dim sqc As New SqlCommand("INSERTAR_T_DIFERIDO_CC", con)
                sqc.CommandType = CommandType.StoredProcedure
                sqc.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                sqc.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
                sqc.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = txtCodDoc.Text
                sqc.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = txtNroDoc.Text
                sqc.Parameters.Add("@COD_PER", SqlDbType.Char).Value = txtCodPer.Text
                sqc.Parameters.Add("@COD_CC", SqlDbType.VarChar).Value = dgvDetalleDiferido.Item(0, I).Value
                sqc.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = dgvDetalleDiferido.Item(2, I).Value
                sqc.Parameters.Add("@POR_DIF", SqlDbType.Decimal).Value = dgvDetalleDiferido.Item(4, I).Value
                iar = sqc.BeginExecuteNonQuery
                sqc.EndExecuteNonQuery(iar)
            Next
        Catch ex As SqlException
            Graba = False
            Dim er As SqlError
            For Each er In ex.Errors
                MessageBox.Show(er.Message, "Error de acceso a BD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
        If Graba Then
            MessageBox.Show("Los datos se grabaron correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btn_op.Enabled = False
            btn_TRansf.Enabled = False
            DT.Rows.Clear()
        End If
    End Sub

    Private Sub BTN_CANCELAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_CANCELAR.Click
        GroupBox1.Enabled = True
        dgvDetalleDiferido.Rows.Clear()
        btn_op.Enabled = True
        btn_TRansf.Enabled = True
        limpiar()
        DT.Rows.Clear()
        btnDiferir.Enabled = True
        txtNroCuotas.Enabled = True
    End Sub

    Private Sub btn_salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub btn_op_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_op.Click
        'Aquí se supone que hacen todas las validaciones que haciamos en aceptar
        If txtNroDoc.Text.Trim = "" Then MessageBox.Show("Faltan los datos del documento", "Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If VALIDAR_I_DIFERIDO(txtCodDoc.Text, txtNroDoc.Text, txtCodPer.Text) = "1" Then MessageBox.Show("No puede Ingresar 2 veces el mismo documento", "Diferidos", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        If DT.Rows.Count = 0 Then MessageBox.Show("Debe elegir las fechas a diferir", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : btnDiferir.Focus() : Exit Sub
        If txtNroCuotas.Text.Trim = "" OrElse CInt(txtNroCuotas.Text) = 0 Then MessageBox.Show("El Nro de cuotas no puede ser 0 o vacio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txtNroCuotas.Focus() : Exit Sub
        If (dtpFechaInicioOp.Value < dtpFechaDoc.Value) Then MessageBox.Show("La fecha de inicio de operacion no puede ser menor a la fecha del documento ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) : dtpFechaInicioOp.Focus() : Exit Sub
        If (dtpFechaVigDel.Value < dtpFechaInicioOp.Value) Then MessageBox.Show("La fecha de Vigencia Del no puede ser menor a la fecha de Inicio de Operación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtpFechaVigDel.Focus() : Exit Sub
        If (dtpFechaVigAl.Value < dtpFechaVigDel.Value) Then MessageBox.Show("La fecha de Vigencia al no puede ser menor que la fecha de Vigencia Del", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : dtpFechaVigAl.Focus() : Exit Sub
        'If OBJ.VERIFICAR_PERIODO("MM") = False Then Exit Sub
        GroupBox1.Enabled = False
        btn_op.Enabled = True
        'Esto estaba aquí normal
        Call ORDENPROD()
    End Sub

    Private Sub btnImportarContabilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportarContabilidad.Click
        If cboCuenta.SelectedIndex = -1 Then MessageBox.Show("Debe seleccionar un cuenta", "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
        Call LlamarTcon()
    End Sub

#End Region

#Region "Eventos"

    Private Sub INGRESO_DIFERIDO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{tab}")
        End If
        If e.Control And e.KeyCode = Keys.O Then
            If btn_op.Enabled Then
                btn_op_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub INGRESO_DIFERIDO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        dgvDetalleDiferido.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        CARGAR_AÑO()
        CARGAR_CUENTAS_CBO()
        CBO_MES.Text = MES
        CBO_AÑO.Text = AÑO
        dtpFechaInicioOp.Value = FECHA_GRAL
        CrearDataTableIDiferidoSecuencia()
    End Sub

#End Region

End Class