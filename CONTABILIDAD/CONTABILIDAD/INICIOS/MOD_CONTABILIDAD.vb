Imports System.Data.SqlClient
Public Class MOD_CONTABILIDAD
    Dim HORA As DateTime
    Dim obj As New Class1
    Sub eliminar_conectado()
        Try
            Dim CMD As New SqlCommand("eliminar_CONECTADO", con2)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@pc", SqlDbType.VarChar).Value = NOMBRE_PC
            con2.Open()
            CMD.ExecuteNonQuery()
            con2.Close()
        Catch ex As Exception
            con2.Close()
        End Try
    End Sub
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Hide()
        My.Forms.Iconos.Show()
        Me.cerrar_todo()
    End Sub
    'Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
    '    Me.HORA = Now.Date
    'End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        'Me.Text = String.Concat(New String() {"Modulo de Contabilidad  Empresa : ", DESC_EMPRESA, "                                           Proceso   : ", (FECHA_GRAL.Date), "               Fecha Actual : ", (Now)})
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

    Private Sub MOD_CONTABILIDAD_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tsstlUsuario.Text = DESC_USU
        tsslEmpresa.Text = DESC_EMPRESA
        tsslProceso.Text = FECHA_GRAL.Date.ToShortDateString
    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'Me.Text = String.Concat(New String() {"Modulo de Contabilidad ", DESC_EMPRESA, " Año : ", AÑO, " Mes : ", MES, "                                      MGSoluciones  ", (Now.Date.Date)})
        If (Me.obj.SACAR_CAMBIO2(AÑO, MES, FECHA_GRAL.Day, "D") = "1.0000") Then
            main(9) += 1
            If (main(9) = 1) Then
                Dim ofr99 As New CAMBIO
                ofr99.MdiParent = Me
                ofr99.Show()
            End If
        End If
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Function VERIFICAR_PERIODO() As Boolean
        If obj.VERIFICAR_PERIODO("MM") = False Then
            MessageBox.Show("EL Período se encuentra bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        Return True
    End Function

    Private Sub CuentasContablesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuentasContablesToolStripMenuItem.Click
        main(1) += 1
        If (main(1) = 1) Then
            Dim ofr01 As New CUENTAS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M11") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(1) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub AutomáticasToolStripMenuItem1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles AutomáticasToolStripMenuItem1.Click
        main(2) += 1
        If main(2) = 1 Then
            Dim ofr01 As New AUTOMATICAS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M12") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(2) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub NroComprobanteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NroComprobanteToolStripMenuItem.Click
        main(3) += 1
        If (main(3) = 1) Then
            Dim ofr01 As New NRO_COMPROBANTE
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M13") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(3) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub RegistroDeComprasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RegistroDeComprasToolStripMenuItem.Click
        main(4) += 1
        If (main(4) = 1) Then
            Dim ofr01 As New CUENTA_COMPRAS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M14") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(4) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub RegistroDeVentasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RegistroDeVentasToolStripMenuItem.Click
        main(5) += 1
        If (main(5) = 1) Then
            Dim ofr01 As New CUENTA_VENTAS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M15") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(5) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub RegistroDeHonorariosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RegistroDeHonorariosToolStripMenuItem.Click
        main(6) += 1
        If (main(6) = 1) Then
            Dim ofr01 As New CUENTA_HONORARIOS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M16") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(6) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub OrdenToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OrdenToolStripMenuItem1.Click
        main(7) += 1
        If (main(7) = 1) Then
            Dim ofr01 As New ORDEN_CUENTA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M17") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(7) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TítulosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TítulosToolStripMenuItem.Click
        main(8) += 1
        If (main(8) = 1) Then
            Dim ofr01 As New TITULOS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M18") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(8) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub
    
    Private Sub PlanCuentasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PlanCuentasToolStripMenuItem.Click
        main(10) += 1
        If (main(10) = 1) Then
            Dim ofr01 As New REPORTE_M_CUENTAS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub SaldosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaldosToolStripMenuItem.Click
        main(11) += 1
        If (main(11) = 1) Then
            Dim ofr01 As New REPORTE_SALDOS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ConciliacionFinancieraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConciliacionFinancieraToolStripMenuItem.Click
        '----------ojo vienen de banco
        main(12) += 1
        If (main(12) = 1) Then
            Dim ofr01 As New REPORTE_CONC()
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DiarioToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DiarioToolStripMenuItem.Click
        If (main(13) = 0) Then
            Dim ofr01 As New ASIENTO_DIARIO
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                main(13) += 1
                If obj.SEGURIDAD_FORM("T13") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(13) = 0 : Exit Sub
                ofr01.Show()
            End If
        End If
    End Sub

    Private Sub ComprasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComprasToolStripMenuItem.Click
        If (main(14) = 0) Then
            Dim ofr01 As New PROV_COMPRAS
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                If Me.obj.VERIFICAR_PERIODO("RC") = False Then
                    MessageBox.Show("EL Registro de Compras se encuentra bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    main(14) += 1
                    If obj.SEGURIDAD_FORM("T14") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(14) = 0 : Exit Sub
                    ofr01.Show()
                End If
            End If
        End If
    End Sub

    Private Sub VentasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VentasToolStripMenuItem.Click
        If (main(15) = 0) Then
            Dim ofr01 As New PROV_VENTAS
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                If Me.obj.VERIFICAR_PERIODO("RV") = False Then
                    MessageBox.Show("EL Registro de Ventas se encuentra bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    main(15) += 1
                    If obj.SEGURIDAD_FORM("T15") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(15) = 0 : Exit Sub
                    ofr01.Show()
                End If
            End If
        End If
    End Sub

    Private Sub AuxiliarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AuxiliarToolStripMenuItem.Click
        main(16) += 1
        If main(16) = 1 Then
            Dim ofr01 As New REPORTE_CTA_AUX
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuentasCCToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuentasCCToolStripMenuItem.Click
        main(17) += 1
        If (main(17) = 1) Then
            Dim ofr01 As New REPORTE_CTA_CC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CancelacionesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CancelacionesToolStripMenuItem.Click
        main(146) += 1
        If main(146) = 1 Then
            Dim ofr01 As New CANCELACION_CXC3
            ofr01.MdiParent = Me
            ofr01.Show()
        End If

    End Sub

    Private Sub CancelaciónToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CancelaciónToolStripMenuItem.Click
        main(145) += 1
        If main(145) = 1 Then
            Dim ofr01 As New CANCELACION_CXP3
            ofr01.MdiParent = Me
            ofr01.Show()
        End If

    End Sub

    Private Sub GeneraciónToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GeneraciónToolStripMenuItem.Click
        If (main(20) = 0) Then
            Dim ofr01 As New GENERACION_CXP
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                main(20) += 1
                If obj.SEGURIDAD_FORM("T20") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(20) = 0 : Exit Sub
                ofr01.Show()
            End If
        End If
    End Sub

    Private Sub CierreToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CierreToolStripMenuItem1.Click
        main(21) += 1
        If (main(21) = 1) Then
            Dim ofr01 As New CXC_CIERRE_CTAS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A20") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(21) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CierreToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CierreToolStripMenuItem2.Click
        main(22) += 1
        If (main(22) = 1) Then
            Dim ofr01 As New BAN_CIERRE_CTAS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A06") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(22) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CierreToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CierreToolStripMenuItem3.Click
        main(23) += 1
        If (main(23) = 1) Then
            Dim ofr01 As New OTROS_CIERRE_CTAS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A27") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(23) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ComporbanteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComporbanteToolStripMenuItem.Click
        main(24) += 1
        If (main(24) = 1) Then
            Dim ofr01 As New REP_COMP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CanjeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CanjeToolStripMenuItem.Click
        If (main(25) = 0) Then
            Dim ofr01 As New CANJE_CXP
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                main(25) += 1
                If obj.SEGURIDAD_FORM("T22") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(25) = 0 : Exit Sub
                ofr01.Show()
            End If
        End If
    End Sub

    Private Sub BancosToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BancosToolStripMenuItem2.Click
        main(26) += 1
        If main(26) = 1 Then
            Dim ofr01 As New CONSULTA_ANALISIS_BAN
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComprasToolStripMenuItem1.Click
        main(27) += 1
        If (main(27) = 1) Then
            Dim ofr01 As New RC
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("T17") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(27) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ComprasToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComprasToolStripMenuItem2.Click
        main(28) += 1
        If (main(28) = 1) Then
            Dim ofr01 As New GCO_TRANSFERENCIA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P06") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(28) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ComprobanteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComprobanteToolStripMenuItem.Click
        main(29) += 1
        If (main(29) = 1) Then
            Dim ofr01 As New BCO_TRANSFERENCIA
            ofr01.MdiParent = Me
            If VERIFICAR_PERIODO() = False Then main(29) = 0 : Exit Sub
            If Not Me.VERIFICAR_PERIODO Then
                ofr01.BTN_ACEPTAR1.Enabled = False
                ofr01.btn_aceptar2.Enabled = False
                ofr01.BTN_DES_TRANS.Enabled = False
                ofr01.BTN_DES_TRANS2.Enabled = False
            End If
            If obj.SEGURIDAD_FORM("P15") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(29) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub LibroBancosFinancieroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroBancosFinancieroToolStripMenuItem.Click
        '----------ojo vienen de banco
        main(30) += 1
        If (main(30) = 1) Then
            Dim ofr01 As New REPORTE_LIBRO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ComprobanteToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComprobanteToolStripMenuItem1.Click
        main(31) += 1
        If (main(31) = 1) Then
            Dim ofr01 As New REPORTE_CTA_COMP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ComprobanteToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComprobanteToolStripMenuItem2.Click
        main(32) += 1
        If (main(32) = 1) Then
            Dim ofr01 As New CONSULTA_ICON
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ConciliaciónToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConciliaciónToolStripMenuItem.Click
        main(33) += 1
        If (main(33) = 1) Then
            Dim ofr01 As New CXP_CONC_MANUAL
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A09") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(33) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConciliaciónToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConciliaciónToolStripMenuItem1.Click
        main(34) += 1
        If (main(34) = 1) Then
            Dim ofr01 As New CXC_CONC_MANUAL
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A16") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(34) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConciliaciónToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConciliaciónToolStripMenuItem3.Click
        main(35) += 1
        If (main(35) = 1) Then
            Dim ofr01 As New OTROS_CONC_MANUAL
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A23") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(35) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CtaCorrienteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtaCorrienteToolStripMenuItem.Click
        main(36) += 1
        If (main(36) = 1) Then
            Dim ofr01 As New REPORTE_CTA_CTACTE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasPagarInicialToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasPagarInicialToolStripMenuItem.Click
        main(37) += 1
        If (main(37) = 1) Then
            Dim ofr01 As New CXP_INI_TRANSFERENCIA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P08") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(37) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXCobrarInicialToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXCobrarInicialToolStripMenuItem.Click
        main(39) += 1
        If (main(39) = 1) Then
            Dim ofr01 As New CXC_INI_TRANSFERENCIA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P11") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(39) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXPagarToolStripMenuItem4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXPagarToolStripMenuItem4.Click
        main(40) += 1
        If (main(40) = 1) Then
            Dim ofr01 As New REPORTE_CXP1_COI
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXCobrarToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXCobrarToolStripMenuItem2.Click
        main(42) += 1
        If (main(42) = 1) Then
            Dim ofr01 As New CONSULTA_COI_CXC1
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXCobrarToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXCobrarToolStripMenuItem3.Click
        main(43) += 1
        If (main(43) = 1) Then
            Dim ofr01 As New REPORTE_CXC1_COI
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXPagarToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXPagarToolStripMenuItem1.Click
        main(44) += 1
        If (main(44) = 1) Then
            Dim ofr01 As New GCO_CXP_CANC
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P07") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(44) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXPagarToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXPagarToolStripMenuItem3.Click
        main(45) += 1
        If (main(45) = 1) Then
            Dim ofr01 As New CONSULTA_COI_CXP1
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuentasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuentasToolStripMenuItem.Click
        main(46) += 1
        If (main(46) = 1) Then
            Dim ofr01 As New CONSULTA_TCON
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuentasToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuentasToolStripMenuItem1.Click
        main(47) += 1
        If (main(47) = 1) Then
            Dim ofr01 As New CONSULTA_CUENTAS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuentaToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuentaToolStripMenuItem2.Click
        main(48) += 1
        If (main(48) = 1) Then
            Dim ofr01 As New REPORTE_ANALISIS_TOTROS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DesconciliaciónToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DesconciliaciónToolStripMenuItem.Click
        main(49) += 1
        If (main(49) = 1) Then
            Dim ofr01 As New CXP_DES_CONC_MANUAL
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A10") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(49) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CtasXCobrarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CtasXCobrarToolStripMenuItem.Click
        main(50) += 1
        If (main(50) = 1) Then
            Dim ofr01 As New GCO_CXC_CANC
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P10") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(50) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DesconciliaciónToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DesconciliaciónToolStripMenuItem1.Click
        main(51) += 1
        If (main(51) = 1) Then
            Dim ofr01 As New CXC_DES_CONC_MANUAL
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A17") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(51) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DesconciliaciónToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DesconciliaciónToolStripMenuItem2.Click
        main(52) += 1
        If (main(52) = 1) Then
            Dim ofr01 As New BAN_DES_CONC_MANUAL
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A03") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(52) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DesconciliaciónToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DesconciliaciónToolStripMenuItem3.Click
        main(53) += 1
        If (main(53) = 1) Then
            Dim ofr01 As New OTROS_DES_CONC_MANUAL
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A24") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(53) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DescuadreComprobanteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DescuadreComprobanteToolStripMenuItem.Click
        main(54) += 1
        If (main(54) = 1) Then
            Dim ofr01 As New REPORTE_DESCUADRE
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P21") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(54) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DescuadreCtasXCobrarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DescuadreCtasXCobrarToolStripMenuItem.Click
        main(55) += 1
        If (main(55) = 1) Then
            Dim ofr01 As New DESCUADRE_CXC
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P23") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(55) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DescuadreCtasXPagarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DescuadreCtasXPagarToolStripMenuItem.Click
        main(56) += 1
        If (main(56) = 1) Then
            Dim ofr01 As New DESCUADRE_CXP
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P22") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(56) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DetallesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DetallesToolStripMenuItem.Click
        main(57) += 1
        If (main(57) = 1) Then
            Dim ofr01 As New REPORTE_DIARIO_DET
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DifCambioToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DifCambioToolStripMenuItem.Click
        main(58) += 1
        If (main(58) = 1) Then
            Dim ofr01 As New CXC_DIF_CAMBIO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A19") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(58) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DifCambioToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DifCambioToolStripMenuItem1.Click
        main(59) += 1
        If (main(59) = 1) Then
            Dim ofr01 As New OTROS_DIF_CAMBIO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A26") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(59) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConciliaciónToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConciliaciónToolStripMenuItem2.Click
        main(60) += 1
        If (main(60) = 1) Then
            Dim ofr01 As New BAN_CONC_MANUAL
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A02") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(60) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DifDeCambioToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DifDeCambioToolStripMenuItem.Click
        main(61) += 1
        If (main(61) = 1) Then
            Dim ofr01 As New BAN_DIF_CAMBIO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A05") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(61) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DiferenciaCambioToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DiferenciaCambioToolStripMenuItem.Click
        main(62) += 1
        If (main(62) = 1) Then
            Dim ofr01 As New CXP_DIF_CAMBIO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A12") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(62) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub EstadísticasToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles EstadísticasToolStripMenuItem.Click
        main(63) += 1
        If (main(63) = 1) Then
            Dim ofr01 As New REPORTE_ESTADISTICA
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub FFijoRendicionesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FFijoRendicionesToolStripMenuItem.Click
        main(64) += 1
        If (main(64) = 1) Then
            Dim ofr01 As New GCO_TRANSF_FFIJO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P13") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(64) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub FormatoMesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FormatoMesToolStripMenuItem.Click
        main(65) += 1
        If (main(65) = 1) Then
            Dim ofr01 As New REPORTE_BALANCE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub FormatoMesToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FormatoMesToolStripMenuItem1.Click
        main(66) += 1
        If (main(66) = 1) Then
            Dim ofr01 As New REPORTE_FORMATO_EP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub FormatoPeríodoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FormatoPeríodoToolStripMenuItem.Click
        main(67) += 1
        If (main(67) = 1) Then
            Dim ofr01 As New REPORTE_BALANCE_PER
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub FormatoPeríodoToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FormatoPeríodoToolStripMenuItem1.Click
        main(68) += 1
        If (main(68) = 1) Then
            Dim ofr01 As New REPORTE_FORMATO_EP_PER
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub GeneralToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GeneralToolStripMenuItem.Click
        main(69) += 1
        If (main(69) = 1) Then
            Dim ofr01 As New REPORTE_CTA_GRAL
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub GeneralToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GeneralToolStripMenuItem1.Click
        main(70) += 1
        If (main(70) = 1) Then
            Dim ofr01 As New REPORTE_COMP_GRAL
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub GenerarHonorarios(ByVal sender As Object, ByVal e As EventArgs) Handles GeneraciónToolStripMenuItem3.Click
        If (main(71) = 0) Then
            Dim ofr01 As New PROV_HONORARIOS
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                If Me.obj.VERIFICAR_PERIODO("RH") = False Then
                    MessageBox.Show("EL Registro de Honorarios se encuentra bloqueado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    main(71) += 1
                    If obj.SEGURIDAD_FORM("T16") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(71) = 0 : Exit Sub
                    ofr01.Show()
                End If
            End If
        End If
    End Sub

    Private Sub HonorariosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HonorariosToolStripMenuItem1.Click
        main(72) += 1
        If (main(72) = 1) Then
            Dim ofr01 As New RH
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("T19") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(72) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub HonorToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles HonorToolStripMenuItem.Click
        main(73) += 1
        If (main(73) = 1) Then
            Dim ofr01 As New GCO_TRANSF_HON
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P12") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(73) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub IngresoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoToolStripMenuItem.Click
        main(74) += 1
        If (main(74) = 1) Then
            Dim ofr01 As New CXP_INGRESO_ANA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A08") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(74) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CierreToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CierreToolStripMenuItem.Click
        main(75) += 1
        If (main(75) = 1) Then
            Dim ofr01 As New CXP_CIERRE_CTAS
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A13") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(75) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub IngresoToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoToolStripMenuItem1.Click
        main(76) += 1
        If (main(76) = 1) Then
            Dim ofr01 As New BAN_INGRESO_ANA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A01") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(76) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub IngresoToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoToolStripMenuItem2.Click
        main(77) += 1
        If (main(77) = 1) Then
            Dim ofr01 As New CXC_INGRESO_ANA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A15") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(77) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub IngresoToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles IngresoToolStripMenuItem3.Click
        main(78) += 1
        If (main(78) = 1) Then
            Dim ofr01 As New OTROS_INGRESO_ANA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A22") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(78) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub KardexToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles KardexToolStripMenuItem.Click
        main(79) += 1
        If (main(79) = 1) Then
            Dim ofr01 As New REPORTE_TCXP_KARDEX
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciaToolStripMenuItem3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TransferenciaToolStripMenuItem3.Click
        main(80) += 1
        If (main(80) = 1) Then
            Dim ofr01 As New OTROS_TRANSF_ANA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A25") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(80) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub KardexToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles KardexToolStripMenuItem2.Click
        main(81) += 1
        If (main(81) = 1) Then
            Dim ofr01 As New REPORTE_TCXC_KARDEX
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub MáscaraToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MáscaraToolStripMenuItem.Click
        main(82) += 1
        If (main(82) = 1) Then
            Dim ofr01 As New REPORTE_CTA_MASK
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub MáscaraToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MáscaraToolStripMenuItem1.Click
        main(83) += 1
        If (main(83) = 1) Then
            Dim ofr01 As New REPORTE_COMP_MASK
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub RecoveryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RecoveryToolStripMenuItem.Click
        main(85) += 1
        If (main(85) = 1) Then
            Dim ofr01 As New RECOVERY_TCON
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P20") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(85) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ReparablesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ReparablesToolStripMenuItem.Click
        main(86) += 1
        If (main(86) = 1) Then
            Dim ofr01 As New REPORTE_REPARABLE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub SaldosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaldosToolStripMenuItem1.Click
        main(87) += 1
        If (main(87) = 1) Then
            Dim ofr01 As New REPORTE_TCXP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub SaldosToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaldosToolStripMenuItem2.Click
        main(88) += 1
        If (main(88) = 1) Then
            Dim ofr01 As New REPORTE_TCXC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub TipoDeCambioToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TipoDeCambioToolStripMenuItem1.Click
      
    End Sub

    Private Sub ContableToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContableToolStripMenuItem1.Click
        main(90) += 1
        If (main(90) = 1) Then
            Dim ofr01 As New REPORTE_ANALISIS_TCXC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem2.Click
        main(91) += 1
        If (main(91) = 1) Then
            Dim ofr01 As New REPORTE_MAYOR
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TransferenciaToolStripMenuItem.Click
        main(92) += 1
        If (main(92) = 1) Then
            Dim ofr01 As New CXP_TRANSF_ANA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A11") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(92) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciaToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TransferenciaToolStripMenuItem1.Click
        main(93) += 1
        If (main(93) = 1) Then
            Dim ofr01 As New CXC_TRANSF_ANA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A18") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(93) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciaToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TransferenciaToolStripMenuItem2.Click
        main(94) += 1
        If (main(94) = 1) Then
            Dim ofr01 As New BAN_TRANSF_ANA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A04") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(94) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VentasToolStripMenuItem1.Click
        main(95) += 1
        If (main(95) = 1) Then
            Dim ofr01 As New GCO_TRANSFERENCIA_VTA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P09") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(95) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub VentasToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles VentasToolStripMenuItem2.Click
        main(96) += 1
        If (main(96) = 1) Then
            Dim ofr01 As New RV
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("T18") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(96) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ContableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContableToolStripMenuItem.Click
        main(97) += 1
        If (main(97) = 1) Then
            Dim ofr01 As New REPORTE_ANALISIS_TCXP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub LibrosOficialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibrosOficialesToolStripMenuItem.Click
        main(98) += 1
        If (main(98) = 1) Then
            Dim ofr01 As New REPORTE_PROV1
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ResumenToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenToolStripMenuItem2.Click
        main(99) += 1
        If (main(99) = 1) Then
            Dim ofr01 As New REPORTE_PROV2
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub KardexToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KardexToolStripMenuItem4.Click
        main(100) += 1
        If (main(100) = 1) Then
            Dim ofr01 As New REPORTE_PROV3
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PresentaciónToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PresentaciónToolStripMenuItem.Click
        main(101) += 1
        If (main(101) = 1) Then
            Dim ofr01 As New CONFIG_PROV
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M19") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(101) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

  Private Sub ResumenToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenToolStripMenuItem3.Click
        main(102) += 1
        If (main(102) = 1) Then
            Dim ofr01 As New REPORTE_RESUMEN_TCXC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PlanillasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanillasToolStripMenuItem.Click
        main(103) += 1
        If (main(103) = 1) Then
            Dim ofr01 As New ImportarPlanilla
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P18") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(103) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConciliacionAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConciliacionAToolStripMenuItem.Click
        main(104) += 1
        If (main(104) = 1) Then
            Dim ofr01 As New Reporte_Conciliacion
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub RentaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RentaDeToolStripMenuItem.Click
     
    End Sub

    Private Sub ConciliaciónToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConciliaciónToolStripMenuItem4.Click
        main(110) += 1
        If (main(110) = 1) Then
            Dim ofr01 As New REPORTE_CONC_CONTABLE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub MaeestroPersonaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaeestroPersonaToolStripMenuItem.Click
        main(111) += 1
        If (main(111) = 1) Then
            Dim ofr01 As New ImportarTxtPersona
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P16") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(111) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub GastosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GastosToolStripMenuItem.Click
      
    End Sub

    Private Sub LibroBancosAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroBancosAToolStripMenuItem.Click
        main(113) += 1
        If (main(113) = 1) Then
            Dim ofr01 As New Reporte_LibroBanco
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetalleToolStripMenuItem.Click
        main(114) += 1
        If main(114) = 1 Then
            Dim ofr01 As New REPORTE_CC_DETALLE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub SaldosCentroDeCostosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosCentroDeCostosToolStripMenuItem.Click
        main(115) += 1
        If main(115) = 1 Then
            Dim ofr01 As New REPORTE_CC_SALDO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub SaldosCuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaldosCuentaToolStripMenuItem.Click
        main(116) += 1
        If main(116) = 1 Then
            Dim ofr01 As New REPORTE_CC_CTA
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ResumenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResumenToolStripMenuItem1.Click
        main(117) += 1
        If (main(117) = 1) Then
            Dim ofr01 As New REPORTE_RESUMEN_TCXP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub LibroDeBancosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroDeBancosToolStripMenuItem.Click
        main(118) += 1
        If (main(118) = 1) Then
            Dim ofr01 As New REPORTE_LIBRO_CONTABLE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PRUEBAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        main(119) += 1
        If (main(119) = 1) Then
            Dim ofr01 As New ASIENTO_DIARIO_prueba
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub GestiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestiónToolStripMenuItem.Click
        main(121) += 1
        If (main(121) = 1) Then
            Dim ofr01 As New REPORTE_ANALISIS_TCXP_GESTION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub GestiónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GestiónToolStripMenuItem1.Click
        main(122) += 1
        If (main(122) = 1) Then
            Dim ofr01 As New REPORTE_ANALISIS_TCXC_GESTION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub GeneraciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraciónToolStripMenuItem1.Click
        If (main(124) = 0) Then
            Dim ofr01 As New GENERACION_CXC
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                main(124) += 1
                If obj.SEGURIDAD_FORM("T24") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(124) = 0 : Exit Sub
                ofr01.Show()
            End If
        End If
    End Sub

    Private Sub CanjeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CanjeToolStripMenuItem1.Click
        If (main(125) = 0) Then
            Dim ofr01 As New CANJE_CXC
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                main(125) += 1
                If obj.SEGURIDAD_FORM("T26") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(125) = 0 : Exit Sub
                ofr01.Show()
            End If
        End If
    End Sub

    Private Sub DAOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DAOToolStripMenuItem.Click
        main(126) += 1
        If (main(126) = 1) Then
            Dim ofr01 As New REPORTE_PDT_PROV
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P25") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(126) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciaAnualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciaAnualToolStripMenuItem.Click
        main(127) += 1
        If (main(127) = 1) Then
            Dim ofr01 As New CXP_TRANSF_AÑO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A14") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(127) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransfAnualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransfAnualToolStripMenuItem.Click
        main(128) += 1
        If (main(128) = 1) Then
            Dim ofr01 As New CXC_TRANSF_AÑO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A21") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(128) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransfAnualToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransfAnualToolStripMenuItem1.Click
        main(129) += 1
        If (main(129) = 1) Then
            Dim ofr01 As New BAN_TRANSF_AÑO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A07") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(129) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransfAnualToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransfAnualToolStripMenuItem2.Click
        main(130) += 1
        If (main(130) = 1) Then
            Dim ofr01 As New OTROS_TRANSF_AÑO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("A28") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(130) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ProyectoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProyectoToolStripMenuItem.Click
        main(131) += 1
        If (main(131) = 1) Then
            Dim ofr01 As New REPORTE_PY
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DetraccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetraccionToolStripMenuItem.Click
        main(132) += 1
        If (main(132) = 1) Then
            Dim ofr01 As New REPORTE_DETRACCION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub RetencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionesToolStripMenuItem.Click
        If (main(133) = 0) Then
            Dim ofr01 As New RETENCION_CXP
            ofr01.MdiParent = Me
            If Me.VERIFICAR_PERIODO Then
                main(133) += 1
                If obj.SEGURIDAD_FORM("T23") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(133) = 0 : Exit Sub
                ofr01.Show()
            End If
        End If
    End Sub

    Private Sub RetencionesIGVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionesIGVToolStripMenuItem.Click
        main(134) += 1
        If (main(134) = 1) Then
            Dim ofr01 As New RETENCIONES_IGV
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P26") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(134) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub RetencionesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionesToolStripMenuItem1.Click
     
    End Sub

    Private Sub CuadreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreToolStripMenuItem.Click
        main(136) += 1
        If main(136) = 1 Then
            Dim ofr01 As New REPORTE_PROV_GASTO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ActualizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizacionToolStripMenuItem.Click
        main(89) += 1
        If (main(89) = 1) Then
            Dim ofr01 As New CAMBIO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("M20") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(89) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConsultaToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaToolStripMenuItem4.Click
        main(137) += 1
        If main(137) = 1 Then
            Dim ofr01 As New CONSULTA_T_CAMBIO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub XOrdenCCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XOrdenCCToolStripMenuItem.Click
        main(112) += 1
        If (main(112) = 1) Then
            Dim ofr01 As New REPORTE_GASTO_PRODUCC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub XCtaContableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XCtaContableToolStripMenuItem.Click
        main(138) += 1
        If main(138) = 1 Then
            Dim ofr01 As New REPORTE_GASTO_X_CTA
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub FacturaciónVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónVentasToolStripMenuItem.Click
        'main(139) += 1
        'If main(139) = 1 Then
        '    Dim ofr01 As New IMPORTAR_FACT_VTA
        '    ofr01.MdiParent = Me
        '    ofr01.Show()
        'End If
    End Sub

    Private Sub TransferenciasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciasToolStripMenuItem1.Click
        main(140) += 1
        If main(140) = 1 Then
            Dim ofr01 As New TRANSFERENCIA_CXP2
            ofr01.MdiParent = Me
            If VERIFICAR_PERIODO() = False Then main(140) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciasToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciasToolStripMenuItem2.Click
        main(141) += 1
        If main(141) = 1 Then
            Dim ofr01 As New TRANSFERENCIA_CXC2
            ofr01.MdiParent = Me
            If VERIFICAR_PERIODO() = False Then main(141) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TransferenciaEntreCuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferenciaEntreCuentasToolStripMenuItem.Click
        main(142) += 1
        If main(142) = 1 Then
            Dim ofr01 As New TRANS_ENTRE_CTAS()
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    'Private Sub PruebaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PruebaToolStripMenuItem.Click
    '    If (main(19) = 0) Then
    '        Dim ofr01 As New CANCELACION_CXP2
    '        ofr01.MdiParent = Me
    '        If Me.VERIFICAR_PERIODO Then
    '            main(19) += 1
    '            If obj.SEGURIDAD_FORM("T21") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(19) = 0 : Exit Sub
    '            ofr01.Show()
    '        End If
    '    End If
    'End Sub

    'Private Sub PruebaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PruebaToolStripMenuItem1.Click
    '    If (main(18) = 0) Then
    '        Dim ofr01 As New CANCELACION_CXC2
    '        ofr01.MdiParent = Me
    '        If Me.VERIFICAR_PERIODO Then
    '            main(18) += 1
    '            If obj.SEGURIDAD_FORM("T25") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(18) = 0 : Exit Sub
    '            ofr01.Show()
    '        End If
    '    End If
    'End Sub

    Private Sub LibroRetencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroRetencionesToolStripMenuItem.Click
        main(135) += 1
        If main(135) = 1 Then
            Dim ofr01 As New REPORTE_RETENCION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub RegimenRetencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegimenRetencionesToolStripMenuItem.Click
        main(147) += 1
        If main(147) = 1 Then
            Dim ofr01 As New REPORTE_REGIMEN_RET
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PDTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PDTToolStripMenuItem.Click
        main(109) += 1
        If (main(109) = 1) Then
            Dim ofr01 As New RENTA_DE_CUARTA
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P27") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(109) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CertificadoDeCuartaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CertificadoDeCuartaToolStripMenuItem.Click
        main(148) += 1
        If main(148) = 1 Then
            Dim ofr01 As New CERTIFICADO_4TA
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ComprasToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprasToolStripMenuItem3.Click
        main(149) += 1
        If main(149) = 1 Then
            Dim ofr01 As New PDB_COMPRAS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub VentasToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem3.Click
        main(150) += 1
        If main(150) = 1 Then
            Dim ofr01 As New PDB_VENTAS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub FormaDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormaDePagoToolStripMenuItem.Click
        main(151) += 1
        If main(151) = 1 Then
            Dim ofr01 As New PDB_FORMA_PAGO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub TipoCambioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoCambioToolStripMenuItem.Click
        main(152) += 1
        If main(152) = 1 Then
            Dim ofr01 As New PDB_TIPO_CAMBIO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub TablaDistribucionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TablaDistribucionToolStripMenuItem.Click
        main(153) += 1
        If main(153) = 1 Then
            Dim ofr01 As New DISTRIBUCION_CC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub GeneraciónToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EstadisticasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticasToolStripMenuItem.Click
        main(155) += 1
        If main(155) = 1 Then
            Dim ofr01 As New REPORTE_ESTADISTICA_GASTO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DistribuciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DistribuciónToolStripMenuItem.Click
        main(156) += 1
        If main(156) = 1 Then
            Dim ofr01 As New REPORTE_DISTRIBUCION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub FormatoMesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormatoMesToolStripMenuItem2.Click
        main(157) += 1
        If main(157) = 1 Then
            Dim ofr01 As New REPORTE_FORMATO_EP_CC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub TrasnferenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrasnferenciaToolStripMenuItem.Click
        Dim oFrm As HONORARIOS_TRANS = HONORARIOS_TRANS.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub mnuPleCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPleCompras.Click
        Dim oFrm As frmPleCompra = frmPleCompra.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub PLEVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLEVentasToolStripMenuItem.Click
        Dim oFrm As frmPleVenta = frmPleVenta.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub PLEDiarioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLEDiarioToolStripMenuItem.Click
        Dim oFrm As frmPleDiario = frmPleDiario.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub PLEMayorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLEMayorToolStripMenuItem.Click
        Dim oFrm As frmPleMayor = frmPleMayor.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub BalanceComprobacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceComprobacionToolStripMenuItem.Click
        main(158) += 1
        If main(158) = 1 Then
            Dim ofr01 As New CONSULTA_COMPROBACION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        Dim oFrm As REPORTE_REGIMEN_PERCEPCIONES = REPORTE_REGIMEN_PERCEPCIONES.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub FormatoPeríodoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormatoPeríodoToolStripMenuItem2.Click
        Dim oFrm As REPORTE_FORMATO_EP_ANUAL = REPORTE_FORMATO_EP_ANUAL.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub FormatoPeríodoToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormatoPeríodoToolStripMenuItem3.Click
        Dim oFrm As REPORTE_BALANCE_ANUAL = REPORTE_BALANCE_ANUAL.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub mnuFlujoEfectivoDirecto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFlujoEfectivoDirecto.Click
        Dim frm As frmFlujoEfectivoDirecta = frmFlujoEfectivoDirecta.ObtenerIntancia()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CuentaCierrePeriodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentaCierrePeriodoToolStripMenuItem.Click
        Dim oFrm As CUENTA_CIERRE_PERIODO = CUENTA_CIERRE_PERIODO.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        main(120) += 1
        If (main(120) = 1) Then
            Dim ofr01 As New INICIO_AÑO
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P24") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(120) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CierreToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierreToolStripMenuItem4.Click
        Dim oFrm As CIERRE_ANUAL = CIERRE_ANUAL.OBTENERINSTANCIA
        oFrm.ACTIVIDAD = "CIERRE_CUENTA"
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub KardexToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KardexToolStripMenuItem1.Click
        main(38) += 1
        If (main(38) = 1) Then
            Dim ofr01 As New CONSULTA_ANALISIS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub KardexToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KardexToolStripMenuItem3.Click
        main(41) += 1
        If (main(41) = 1) Then
            Dim ofr01 As New CONSULTA_ANALISIS_CXC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub KardexToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KardexToolStripMenuItem5.Click
        main(84) += 1
        If (main(84) = 1) Then
            Dim ofr01 As New CONSULTA_ANALISIS_OTRAS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ConciliadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConciliadaToolStripMenuItem.Click
        Dim oFrm As CONSULTA_CUADRE_CONCILIADO = CONSULTA_CUADRE_CONCILIADO.OBTENERINSTANCIA
        oFrm.ST_CUADRE = "P"
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub ConciliadaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConciliadaToolStripMenuItem1.Click
        Dim oFrm As CONSULTA_CUADRE_CONCILIADO = CONSULTA_CUADRE_CONCILIADO.OBTENERINSTANCIA
        oFrm.ST_CUADRE = "C"
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub ConciliadaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConciliadaToolStripMenuItem2.Click
        Dim oFrm As CONSULTA_CUADRE_CONCILIADO = CONSULTA_CUADRE_CONCILIADO.OBTENERINSTANCIA
        oFrm.ST_CUADRE = "O"
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub TransferidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferidaToolStripMenuItem.Click
        Dim oFrm As CONSULTA_CUADRE_TRANSFERIDA = CONSULTA_CUADRE_TRANSFERIDA.OBTENERINSTANCIA
        oFrm.ST_CUADRE = "P"
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub TransferidaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferidaToolStripMenuItem1.Click
        Dim oFrm As CONSULTA_CUADRE_TRANSFERIDA = CONSULTA_CUADRE_TRANSFERIDA.OBTENERINSTANCIA
        oFrm.ST_CUADRE = "C"
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub TransferidaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferidaToolStripMenuItem2.Click
        Dim oFrm As CONSULTA_CUADRE_TRANSFERIDA = CONSULTA_CUADRE_TRANSFERIDA.OBTENERINSTANCIA
        oFrm.ST_CUADRE = "O"
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub CuentasToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuentasToolStripMenuItem2.Click
        Dim oFrm As frmPleCuenta = frmPleCuenta.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub ReportesToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EEPPXCCToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub EEPPXUNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LibroPercepcionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibroPercepcionesToolStripMenuItem.Click
        Dim frm As REPORTE_PERCEPCION = REPORTE_PERCEPCION.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub PercepcionesIGVToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PercepcionesIGVToolStripMenuItem.Click
        main(134) += 1
        If (main(134) = 1) Then
            Dim ofr01 As New PERCEPCIONES_IGV
            ofr01.MdiParent = Me
            If obj.SEGURIDAD_FORM("P26") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(134) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub FacturaciónVentasExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub

    Private Sub FacturaciónVentasDBFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónVentasDBFToolStripMenuItem.Click
        main(139) += 1
        If main(139) = 1 Then
            Dim ofr01 As New IMPORTAR_FACT_VTA
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub FacturaciónVentasExcelToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónVentasExcelToolStripMenuItem1.Click
        
        Dim ofr01 As New IMPORTAR_FACT_VTA_EXCEL
        ofr01.MdiParent = Me
        'ofr01.Show()
        If obj.SEGURIDAD_FORM("P29") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(3) = 0 : Exit Sub
        ofr01.Show()

    End Sub

    Private Sub ReporteDiarioCajaBancoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteDiarioCajaBancoToolStripMenuItem.Click
        Dim frm As New REPORTE_DIARIO_CAJA_BANCO
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CobranzaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CobranzaToolStripMenuItem.Click
        Dim Cobranza As New FrmCobranza
        Cobranza.MdiParent = Me
        Cobranza.Show()
    End Sub

    Private Sub GeneraciónToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraciónToolStripMenuItem4.Click
        Dim frmIngresoDiferido As New INGRESO_DIFERIDO
        frmIngresoDiferido.MdiParent = Me
        frmIngresoDiferido.Show()
    End Sub

    Private Sub GeneraciónToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraciónToolStripMenuItem5.Click
        Dim frmGeneracion As New GENERACION_DIFERIDOS
        frmGeneracion.MdiParent = Me
        frmGeneracion.Show()
    End Sub

    Private Sub ConsultaToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaToolStripMenuItem3.Click
        Dim frmConsultaDiferidos As New CONSULTA_DIFERIDO
        frmConsultaDiferidos.MdiParent = Me
        frmConsultaDiferidos.Show()
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReporteToolStripMenuItem.Click
        Dim frmReporteDiferido As New REPORTE_DIFERIDO
        frmReporteDiferido.MdiParent = Me
        frmReporteDiferido.Show()
    End Sub

    Private Sub RetencionesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetencionesToolStripMenuItem2.Click
        Dim frm As frmPleRetenciones = frmPleRetenciones.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ActualizadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizadoToolStripMenuItem.Click
        'main(90) += 1
        'If (main(90) = 1) Then
        Dim ofr01 As New REPORTE_ANALISIS_TCXC_ACTUALIZADO
        ofr01.MdiParent = Me
        ofr01.Show()
        'End If
    End Sub

    Private Sub ActualizadoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizadoToolStripMenuItem1.Click
        Dim ofrmReporteAnalisisCxPActualizado As New REPORTE_ANALISIS_TCXP_ACTUALIZADO
        ofrmReporteAnalisisCxPActualizado.MdiParent = Me
        ofrmReporteAnalisisCxPActualizado.Show()
    End Sub

    Private Sub EnvíoDeRetencionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvíoDeRetencionesToolStripMenuItem.Click
        If Not obj.SEGURIDAD_FORM("P50") Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(3) = 0 : Exit Sub
        Dim frm As frmEnvioRetenciones = frmEnvioRetenciones.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub FacturaciónVtaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacturaciónVtaToolStripMenuItem.Click
        Dim ofrmFacturacionVta As frmFacturacionVta = frmFacturacionVta.ObtenerInstancia
        ofrmFacturacionVta.MdiParent = Me
        ofrmFacturacionVta.Show()
    End Sub

    Private Sub InventariosYBalancesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventariosYBalancesToolStripMenuItem.Click
        Dim ofrmInventariosyBalance As frmInventariosyBalance = frmInventariosyBalance.ObtenerInstancia
        ofrmInventariosyBalance.MdiParent = Me
        ofrmInventariosyBalance.Show()
    End Sub

    Private Sub CuentaCorrienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ofrmPleCuentaCorriente As frmPleCuentaCorriente = frmPleCuentaCorriente.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        Dim ofrmPleCuentaCorriente As frm0301 = frm0301.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        Dim ofrmPleCuentaCorriente As frm0318 = frm0318.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        Dim ofrmPleCuentaCorriente As frm0319 = frm0319.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        Dim ofrmPleCuentaCorriente As frm0324 = frm0324.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem20.Click
        Dim ofrmPleCuentaCorriente As frm0325 = frm0325.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        Dim ofrmPleCuentaCorriente As frm0302 = frm0302.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub CtasXPagarToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtasXPagarToolStripMenuItem5.Click
        Dim ofrmConsultaRegistroCompras As CONSULTA_REG_COMPRA = CONSULTA_REG_COMPRA.ObtenerInstancia
        ofrmConsultaRegistroCompras.MdiParent = Me
        ofrmConsultaRegistroCompras.Show()
    End Sub

    Private Sub CtasXCobrarToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CtasXCobrarToolStripMenuItem6.Click
        Dim ofrmConsultaRegistroVentas As CONSULTA_REG_VENTAS = CONSULTA_REG_VENTAS.ObtenerInstancia
        ofrmConsultaRegistroVentas.MdiParent = Me
        ofrmConsultaRegistroVentas.Show()
    End Sub

    Private Sub ControlDeComprobantesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ControlDeComprobantesToolStripMenuItem.Click
        Dim ofrmConsultaRegistroVentas As CONSULTA_CONTROL_COMP = CONSULTA_CONTROL_COMP.ObtenerInstancia
        ofrmConsultaRegistroVentas.MdiParent = Me
        ofrmConsultaRegistroVentas.Show()
    End Sub

    Private Sub ToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem22.Click
        Dim ofrmPleCuentaCorriente As frmPleCuentaCorriente = frmPleCuentaCorriente.ObtenerInstancia
        ofrmPleCuentaCorriente.Cuenta = New Integer() {12, 13}
        ofrmPleCuentaCorriente.Text = "3.3 Detalle del saldo de la cuenta 12 y 13"
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        Dim ofrmPleCuentaCorriente As frmPleCuentaCorriente = frmPleCuentaCorriente.ObtenerInstancia
        ofrmPleCuentaCorriente.Cuenta = New Integer() {14}
        ofrmPleCuentaCorriente.Text = "3.4 Detalle del saldo de la cuenta 14"
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click
        Dim ofrmPleCuentaCorriente As frmPleCuentaCorriente = frmPleCuentaCorriente.ObtenerInstancia
        ofrmPleCuentaCorriente.Cuenta = New Integer() {16, 17}
        ofrmPleCuentaCorriente.Text = "3.5 Detalle del saldo de la cuenta 16 y 17"
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem25.Click
        Dim ofrmPleCuentaCorriente As frm0306 = frm0306.ObtenerInstancia
        ofrmPleCuentaCorriente.Cuenta = New Integer() {19}
        ofrmPleCuentaCorriente.Text = "3.6 Detalle del saldo de la cuenta 19"
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click
        Dim ofrmPleCuentaCorriente As frmPle0311 = frmPle0311.ObtenerInstancia
        ofrmPleCuentaCorriente.Cuenta = New Integer() {41}
        ofrmPleCuentaCorriente.Text = "3.11 Detalle del saldo de la cuenta 41"
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem27.Click
        Dim ofrmPleCuentaCorriente As frmPleCuentaCorriente = frmPleCuentaCorriente.ObtenerInstancia
        ofrmPleCuentaCorriente.Cuenta = New Integer() {42, 43}
        ofrmPleCuentaCorriente.Text = "3.12 Detalle del saldo de la cuenta 42 y 43"
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem28.Click
        Dim ofrmPleCuentaCorriente As frm0313 = frm0313.ObtenerInstancia
        ofrmPleCuentaCorriente.Cuenta = New Integer() {46, 47}
        ofrmPleCuentaCorriente.Text = "3.13 Detalle del saldo de la cuenta 46 y 47"
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ParticipaciónAccionariaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ParticipaciónAccionariaToolStripMenuItem.Click
        Dim ofrmPleCuentaCorriente As frm031602 = frm031602.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub Cta50ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cta50ToolStripMenuItem.Click
        Dim ofrmPleCuentaCorriente As frm031601 = frm031601.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        Dim ofrmPleCuentaCorriente As frm0307 = frm0307.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub ToolStripMenuItem29_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem29.Click
        Dim ofrmPleCuentaCorriente As frm0308 = frm0308.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub Cta47BeneficiosSocialesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cta47BeneficiosSocialesToolStripMenuItem.Click
        Dim ofrmPleCuentaCorriente As frm0314 = frm0314.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub EstadoDeResultadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadoDeResultadosToolStripMenuItem.Click
        Dim ofrmPleCuentaCorriente As frm0320 = frm0320.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub Cta34ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cta34ToolStripMenuItem.Click
        Dim ofrmPleCuentaCorriente As frm0309 = frm0309.ObtenerInstancia
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub Cta37Y49ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cta37Y49ToolStripMenuItem.Click
        Dim ofrmPleCuentaCorriente As frm0315 = frm0315.ObtenerInstancia
        ofrmPleCuentaCorriente.Cuenta = New Integer() {37, 49}
        ofrmPleCuentaCorriente.Text = "3.15 Detalle del saldo de la cuenta 37 y 49"
        ofrmPleCuentaCorriente.MdiParent = Me
        ofrmPleCuentaCorriente.Show()
    End Sub

    Private Sub GeneraciónToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraciónToolStripMenuItem6.Click
        main(154) += 1
        If main(154) = 1 Then
            Dim ofr01 As New GENERACION_DISTRIBUCION
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub EEPPXCCToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EEPPXCCToolStripMenuItem2.Click
        Dim oFrm As ESTADISTICA_PERDIDAS_GANANCIAS = ESTADISTICA_PERDIDAS_GANANCIAS.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub EEPPXUNToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EEPPXUNToolStripMenuItem1.Click
        Dim oFrm As REPORTE_EEPP_UNIDAD_NEGOCIO = REPORTE_EEPP_UNIDAD_NEGOCIO.ObtenerInstancia
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Private Sub GeneraciónToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneraciónToolStripMenuItem2.Click
        Dim frm As FrmGeneracionDistribucion = FrmGeneracionDistribucion.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub UnidadEconomicaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnidadEconomicaToolStripMenuItem.Click
        Dim frm As ReporteUnidadNegocioConcepto = ReporteUnidadNegocioConcepto.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub EstadisticaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstadisticaToolStripMenuItem.Click
        Dim frm As FrmEstadisticaUN = FrmEstadisticaUN.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub CuadreToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreToolStripMenuItem1.Click
        Dim frm As FrmReporteConciliadasCXPCuadre = FrmReporteConciliadasCXPCuadre.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Dim frm As FrmReporteConciliadasCXCSinCuadre = FrmReporteConciliadasCXCSinCuadre.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class