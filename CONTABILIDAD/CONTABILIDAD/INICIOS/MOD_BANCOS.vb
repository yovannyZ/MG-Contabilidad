Imports System.Data.SqlClient
Public Class MOD_BANCOS
    Dim OBJ As New Class1

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        'Me.Text = String.Concat(New String() {"Modulo de Bancos  Empresa : ", DESC_EMPRESA, "                                  Proceso   : ", (FECHA_GRAL.Date), "                               Fecha Actual : ", (Now)})
    End Sub

    Private Sub MOD_BANCOS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tsstlUsuario.Text = DESC_USU
        tsslEmpresa.Text = DESC_EMPRESA
        tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString
    End Sub

    Private Sub Bancos_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Public Sub cerrar_todo()
        Dim c As Integer = (Me.MdiChildren.Length - 1)
        Dim i As Integer = 0
        Do While (i <= c)
            Me.MdiChildren(0).Close()
            i += 1
        Loop
        Array.Clear(main, 0, main.Length)
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.cerrar_todo()
        Me.Hide()
        My.Forms.Iconos.Show()
    End Sub

    Sub eliminar_conectado()
        Try
            Dim CMD As New SqlCommand("eliminar_CONECTADO", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            con2.Open()
            CMD.ExecuteNonQuery()
            con2.Close()
        Catch ex As Exception
            con2.Close()
        End Try
    End Sub

    Function validar_perfiles_usuario(ByVal cod_menu As Object, ByVal cod_submenu As Object, ByVal cod_form As Object, ByVal tipo As Object) As Boolean
        Dim rspta As Boolean
        Try
            Dim cmd As New SqlCommand("VERIFIAR_BOTONES", con2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@cod_usuario", SqlDbType.Char).Value = COD_USU
            cmd.Parameters.Add("@cod_empresa", SqlDbType.Char).Value = COD_EMPRESA
            cmd.Parameters.Add("@cod_modulo", SqlDbType.Char).Value = COD_MOD
            cmd.Parameters.Add("@cod_menu", SqlDbType.Char).Value = cod_menu
            cmd.Parameters.Add("@cod_submenu", SqlDbType.Char).Value = cod_submenu
            cmd.Parameters.Add("@cod_form", SqlDbType.Char).Value = cod_form
            cmd.Parameters.Add("@tipo", SqlDbType.Char).Value = tipo
            con2.Open()
            rspta = Boolean.Parse(cmd.ExecuteScalar)
            con2.Close()
        Catch ex As Exception
            con2.Close()
            MsgBox(ex.Message)
        End Try
        Return rspta
    End Function

    Private Sub IngresosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresosToolStripMenuItem1.Click
        main(1) += 1
        If (main(1) = 1) Then
            Dim ofr01 As New INGRESO_BANCOS
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("B04") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(1) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CanceladasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CanceladasToolStripMenuItem.Click
        main(2) += 1
        If (main(2) = 1) Then
            Dim ofr01 As New REPORTE_CXP2_CANC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub SaldoDeBancosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaldoDeBancosToolStripMenuItem1.Click
        main(3) += 1
        If (main(3) = 1) Then
            Dim ofr01 As New SALDO_BANCOS
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("B01") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(3) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub EgresosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EgresosToolStripMenuItem.Click
        main(4) += 1
        If (main(4) = 1) Then
            Dim ofr01 As New EGRESOS_BANCOS
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("B05") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(4) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TransferenciaToolStripMenuItem.Click
        main(5) += 1
        If main(5) = 1 Then
            Dim ofr01 As New TRANSFERENCIA_BANCOS
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("B06") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(5) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConciliarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConciliarToolStripMenuItem.Click
        main(6) += 1
        If (main(6) = 1) Then
            Dim ofr01 As New CONCILIACION_BANCOS
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("B27") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(6) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CierreToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CierreToolStripMenuItem.Click
        main(7) += 1
        If (main(7) = 1) Then
            Dim ofr01 As New CIERRE_BANCOS_MENSUAL
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("B28") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(7) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConceptosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptosToolStripMenuItem.Click
        main(8) += 1
        If main(8) = 1 Then
            Dim ofr01 As New CONSULTA_CPTOS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CAnceladasToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CAnceladasToolStripMenuItem1.Click
        main(9) += 1
        If (main(9) = 1) Then
            Dim ofr01 As New REPORTE_CXC2_CANC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub BancosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BancosToolStripMenuItem1.Click
        main(10) += 1
        If (main(10) = 1) Then
            Dim ofr01 As New REPORTE_CPTO_BCO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ConsilidadoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConsilidadoToolStripMenuItem.Click
        main(11) += 1
        If (main(11) = 1) Then
            Dim ofr01 As New REPORTE_CPTO_CONS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub RToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RToolStripMenuItem.Click
        main(12) += 1
        If (main(12) = 1) Then
            Dim ofr01 As New REPORTE_CONC()
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXCobrarToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXCobrarToolStripMenuItem1.Click
        'main(13) += 1
        'If (main(13) = 1) Then
        '    Dim ofr01 As New CONSULTA_CXC1
        '    ofr01.MdiParent = Me
        '    ofr01.Show()
        'End If
        '---------------------------JALA EN MODULO CONTABILIDAD TB
        main(42) += 1
        If (main(42) = 1) Then
            Dim ofr01 As New CONSULTA_COI_CXC1
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXPagarToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXPagarToolStripMenuItem1.Click
        main(14) += 1
        If (main(14) = 1) Then
            Dim ofr01 As New GCO_CANC_CXP
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("B30") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(14) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CuentasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuentasToolStripMenuItem.Click
        main(15) += 1
        If (main(15) = 1) Then
            Dim ofr01 As New REPORTE_MOV_CTA
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub IngresosEgresosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresosEgresosToolStripMenuItem.Click
        main(16) += 1
        If (main(16) = 1) Then
            Dim ofr01 As New REPORTE_BANCO_IE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub MovCToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MovCToolStripMenuItem.Click
        main(17) += 1
        If (main(17) = 1) Then
            Dim ofr01 As New CONSULTA_IBANCO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub MovimientosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MovimientosToolStripMenuItem.Click
        main(18) += 1
        If (main(18) = 1) Then
            Dim ofr01 As New CONSULTA_IBANCO_TIPO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PendientesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PendientesToolStripMenuItem.Click
        'main(19) += 1
        'If (main(19) = 1) Then
        '    Dim ofr01 As New REPORTE_CXP1
        '    ofr01.MdiParent = Me
        '    ofr01.Show()
        'End If
        main(31) += 1
        If (main(31) = 1) Then
            Dim ofr01 As New REPORTE_CXP1_COI_BANCO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PendientesToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PendientesToolStripMenuItem1.Click
        'main(20) += 1
        'If (main(20) = 1) Then
        '    Dim ofr01 As New REPORTE_CXC1
        '    ofr01.MdiParent = Me
        '    ofr01.Show()
        'End If
        main(32) += 1
        If (main(32) = 1) Then
            Dim ofr01 As New REPORTE_CXC1_COI_BANCO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PersonasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PersonasToolStripMenuItem.Click
        'main(21) += 1
        'If (main(21) = 1) Then
        '    Dim ofr01 As New CONSULTA_CXP1
        '    ofr01.MdiParent = Me
        '    ofr01.Show()
        'End If
        '---------------------------JALA EN MODULO CONTABILIDAD TB
        main(45) += 1
        If (main(45) = 1) Then
            Dim ofr01 As New CONSULTA_COI_CXP1
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub RecoveryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RecoveryToolStripMenuItem.Click
        main(22) += 1
        If (main(22) = 1) Then
            Dim ofr01 As New BANCOS_RECOVERY
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("B31") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(22) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TipoDeCambioToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        main(23) += 1
        If main(23) = 1 Then
            Dim ofr01 As New CAMBIO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ConsultasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultasToolStripMenuItem.Click
        main(24) += 1
        If main(24) = 1 Then
            Dim ofr01 As New CONSULTA_BANCOS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub IngRetencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngRetencionesToolStripMenuItem.Click
        'main(25) += 1
        If main(25) = 0 Then
            Dim ofr01 As New RETENCION_CXP
            ofr01.MdiParent = Me
            COD_MOD = "COI"
            If Me.VERIFICAR_PERIODO = True Then

                main(25) += 1
                If OBJ.SEGURIDAD_FORM("B07") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(25) = 0 : Exit Sub
                ofr01.Show()
            End If
        End If
    End Sub

    Function VERIFICAR_PERIODO() As Boolean
        If obj.VERIFICAR_PERIODO("MM") = False Then
            MessageBox.Show("EL Período se encuentra bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Sub RetencionesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionesToolStripMenuItem1.Click
        main(26) += 1
        If main(26) = 1 Then
            Dim ofr01 As New CONSULTA_RETENCIONES
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PendientesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendientesToolStripMenuItem2.Click
        main(27) += 1
        If main(27) = 1 Then
            Dim ofr01 As New REPORTE_CPTO_BCO_PTE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub LibroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroToolStripMenuItem.Click
        main(28) += 1
        If main(28) = 1 Then
            Dim ofr01 As New REPORTE_RETENCION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub AnexoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnexoToolStripMenuItem.Click
        main(29) += 1
        If main(29) = 1 Then
            Dim ofr01 As New REPORTE_RET_ANEXO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub LibroBancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroBancosToolStripMenuItem.Click
        main(30) += 1
        If (main(30) = 1) Then
            Dim ofr01 As New REPORTE_LIBRO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciasToolStripMenuItem.Click
        main(33) += 1
        If (main(33) = 1) Then
            Dim ofr01 As New REPORTE_BCO_TRANS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub IngresosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresosToolStripMenuItem.Click
        main(31) += 1
        If (main(31) = 1) Then
            Dim ofr01 As New INGRESO_BANCOS_GENERACION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub EgresosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EgresosToolStripMenuItem1.Click
        main(32) += 1
        If (main(32) = 1) Then
            Dim ofr01 As New EGRESOS_BANCOS_GENERACION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub IngresosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresosToolStripMenuItem2.Click
        main(33) += 1
        If (main(33) = 1) Then
            Dim ofr01 As New CONFIRMACION_ING_BCO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub EgresosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EgresosToolStripMenuItem2.Click
        main(34) += 1
        If (main(34) = 1) Then
            Dim ofr01 As New CONFIRMACION_EGR_BCO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

   Private Sub SeguimientoPagosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeguimientoPagosToolStripMenuItem.Click
        main(35) += 1
        If (main(35) = 1) Then
            Dim ofr01 As New MANT_FECHA_CONFIRMACION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub UbicaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbicaciónToolStripMenuItem.Click
        main(37) += 1
        If (main(37) = 1) Then
            Dim ofr01 As New CONTROL_LETRAS_CXP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub UbicaciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UbicaciónToolStripMenuItem1.Click
        main(36) += 1
        If (main(36) = 1) Then
            Dim ofr01 As New CONTROL_LETRAS_CXC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub SituaciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SituaciónToolStripMenuItem.Click
        main(38) += 1
        If (main(38) = 1) Then
            Dim ofr01 As New CONSULTA_LETRAS_CXP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub SituaciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SituaciónToolStripMenuItem1.Click
        main(39) += 1
        If (main(39) = 1) Then
            Dim ofr01 As New CONSULTA_LETRAS_CXC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CheuqToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheuqToolStripMenuItem.Click
        main(40) += 1
        If (main(40) = 1) Then
            Dim ofr01 As New REPORTE_CHEQUES
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaToolStripMenuItem.Click
        main(41) += 1
        If (main(41) = 1) Then
            Dim ofr01 As New CONSULTA_LETRAS_RET_CXP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub mnuPercepciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPercepciones.Click
        Dim frm As frmPercepcion = frmPercepcion.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PercepcionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PercepcionesToolStripMenuItem.Click
        Dim frm As CONSULTA_PERCEPCIONES = CONSULTA_PERCEPCIONES.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PercepcionesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PercepcionesToolStripMenuItem1.Click
        Dim frm As REPORTE_PERCEPCION = REPORTE_PERCEPCION.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class