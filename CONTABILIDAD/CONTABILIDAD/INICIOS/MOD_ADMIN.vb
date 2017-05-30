Public Class MOD_ADMIN
    Dim OBJ As New Class1
    Private Sub AuxiliarToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AuxiliarToolStripMenuItem1.Click
        main(5) += 1
        If (main(5) = 1) Then
            Dim ofr01 As New AUXILIAR
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T02") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(5) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub BancosToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BancosToolStripMenuItem.Click
        main(17) += 1
        If (main(17) = 1) Then
            Dim ofr01 As New PERIODO_BANCO
            ofr01.Text = "Período de Módulo de Bancos"
            COD_MOD = "BCO"
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("P04") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(17) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CentroDeCostosToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CentroDeCostosToolStripMenuItem1.Click
        main(2) += 1
        If (main(2) = 1) Then
            Dim ofr01 As New AREA
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T07") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(2) = 0 : Exit Sub
            ofr01.Show()
        End If
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

    Private Sub ComprobanteToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ComprobanteToolStripMenuItem1.Click
        main(6) += 1
        If (main(6) = 1) Then
            Dim ofr01 As New COMPROBANTE
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T03") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(6) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConceptoCuentaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConceptoCuentaToolStripMenuItem.Click
        main(28) += 1
        If (main(28) = 1) Then
            Dim ofr01 As New CPTO_CUENTA
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M04") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(28) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ConceptoCuentaToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConceptoCuentaToolStripMenuItem1.Click
        main(31) += 1
        If (main(31) = 1) Then
            Dim ofr01 As New REPORTE_CTA_CYB
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ConceptoCuentaToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConceptoCuentaToolStripMenuItem2.Click
        main(32) += 1
        If (main(32) = 1) Then
            Dim ofr01 As New REPORTES_CUENTAS_CPTO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ConceptoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ConceptoToolStripMenuItem.Click
        main(30) += 1
        If (main(30) = 1) Then
            Dim ofr01 As New REP_MCPTO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ContabilidadToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContabilidadToolStripMenuItem.Click
        main(24) += 1
        If (main(24) = 1) Then
            Dim ofr01 As New PERIODO_COI
            ofr01.Text = "Período de Módulo de Contabilidad"
            COD_MOD = "COI"
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("P05") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(24) = 0 : Exit Sub

            ofr01.Show()
        End If
    End Sub

    Private Sub ControlToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ControlToolStripMenuItem1.Click
        main(3) += 1
        If (main(3) = 1) Then
            Dim ofr01 As New ORDEN_PRODUCCION
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T09") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(3) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CuentasContablesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CuentasContablesToolStripMenuItem.Click
        main(1) += 1
        If (main(1) = 1) Then
            Dim ofr01 As New PERSONA
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M01") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(1) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DetallesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DetallesToolStripMenuItem.Click
        main(16) += 1
        If (main(16) = 1) Then
            Dim ofr01 As New FORMATO_DETALLE
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M07") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(16) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub DirectorioToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DirectorioToolStripMenuItem.Click
        main(22) += 1
        If (main(22) = 1) Then
            Dim ofr01 As New DIRECTORIO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T10") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(22) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ElementoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ElementoToolStripMenuItem.Click
        main(11) += 1
        If (main(11) = 1) Then
            Dim ofr01 As New ELEMENTO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T05") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(11) = 0 : Exit Sub

            ofr01.Show()
        End If
    End Sub

    Private Sub FormatoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FormatoToolStripMenuItem.Click
        main(15) += 1
        If (main(15) = 1) Then
            Dim ofr01 As New FORMATO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M05") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(15) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub GrupoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GrupoToolStripMenuItem.Click
        main(13) += 1
        If (main(13) = 1) Then
            Dim ofr01 As New FORMATO_GRUPO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M06") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(13) = 0 : Exit Sub

            ofr01.Show()
        End If
    End Sub

    Private Sub MantenimientoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles MantenimientoToolStripMenuItem.Click
        main(18) += 1
        If (main(18) = 1) Then
            Dim ofr01 As New CONCEPTOS
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M03") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(18) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub MOD_ADMIN_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tsstlUsuario.Text = DESC_USU
        tsslEmpresa.Text = DESC_EMPRESA
    End Sub

    Private Sub MOD_ADMIN_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub MOD_ADMIN_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub

    Private Sub ModuloToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ModuloToolStripMenuItem.Click
        main(27) += 1
        If (main(27) = 1) Then
            Dim ofr01 As New USU_MODULO
            ofr01.Text = "Período de Módulo de Contabilidad"
            COD_MOD = "COI"
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("S02") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(27) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub NivelToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles NivelToolStripMenuItem1.Click
        main(12) += 1
        If (main(12) = 1) Then
            Dim ofr01 As New NIVEL_CUENTA
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T06") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(12) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ProyectoToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ProyectoToolStripMenuItem1.Click
        main(4) += 1
        If (main(4) = 1) Then
            Dim ofr01 As New PROYECTO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T08") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(4) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub RelaciónToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RelaciónToolStripMenuItem1.Click
        main(19) += 1
        If (main(19) = 1) Then
            Dim ofr01 As New FORMATO_RELACION
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M08") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(19) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Hide()
        My.Forms.Iconos.Show()
        Me.cerrar_todo()
    End Sub

    Private Sub SucursalToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SucursalToolStripMenuItem1.Click
        main(20) += 1
        If (main(20) = 1) Then
            Dim ofr01 As New SUCURSAL
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M09") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(20) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub SucursalToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SucursalToolStripMenuItem2.Click
        main(26) += 1
        If (main(26) = 1) Then
            Dim ofr01 As New USU_SUCURSALES
            ofr01.Text = "Período de Módulo de Contabilidad"
            COD_MOD = "COI"
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("S01") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(26) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        'Me.Text = ("Modulo de Administración Empresa : " & DESC_EMPRESA & "                                                        Fecha Actual : " & Now)
    End Sub

    Private Sub TipoCuentaToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TipoCuentaToolStripMenuItem.Click
        main(10) += 1
        If (main(10) = 1) Then
            Dim ofr01 As New TIPO_CUENTA
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T04") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(10) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub TipoDeCambioToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TipoDeCambioToolStripMenuItem.Click
        main(25) += 1
        If (main(25) = 1) Then
            Dim ofr01 As New CAMBIO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T01") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(25) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem1.Click
        main(23) += 1
        If (main(23) = 1) Then
            Dim ofr01 As New NRO_MEDIO_PAGO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T11") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(23) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripMenuItem2.Click
        main(29) += 1
        If (main(29) = 1) Then
            Dim ofr01 As New BANCO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M02") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(29) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CentroDeCostosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CentroDeCostosToolStripMenuItem.Click
        main(33) += 1
        If (main(33) = 1) Then
            Dim ofr01 As New REPORTE_CC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub ProyectosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProyectosToolStripMenuItem.Click
        main(34) += 1
        If (main(34) = 1) Then
            Dim ofr01 As New REPORTE_PROYECTO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub AuxiliarComprobanteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuxiliarComprobanteToolStripMenuItem.Click
        main(35) += 1
        If (main(35) = 1) Then
            Dim ofr01 As New REPORTE_AUX_COMP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PorFormularioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorFormularioToolStripMenuItem.Click
        main(37) += 1
        If main(37) = 1 Then
            Dim ofr01 As New USU_FORM
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("S03") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(37) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub FormulariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormulariosToolStripMenuItem.Click
        main(38) += 1
        If main(38) = 1 Then
            Dim ofr01 As New FORMULARIO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("T12") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(38) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub PersonaRentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonaRentaToolStripMenuItem.Click
        main(39) += 1
        If main(39) = 1 Then
            Dim ofr01 As New PERSONA_RENTA
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("M10") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(39) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub MovimientoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimientoToolStripMenuItem.Click
        main(36) += 1
        If main(36) = 1 Then
            Dim ofr01 As New CONSULTA_TCON_ACTUALIZA_NUEVO
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("P03") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(36) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub CambioDeCuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioDeCuentaToolStripMenuItem.Click
        main(40) += 1
        If main(40) = 1 Then
            Dim ofr01 As New CAMBIO_DE_CUENTA
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub OtrasCuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtrasCuentasToolStripMenuItem.Click
        main(41) += 1
        If main(41) = 1 Then
            Dim ofr01 As New CONSULTA_ANA_PENDIENT_OTROS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub BancosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BancosToolStripMenuItem1.Click
        main(42) += 1
        If main(42) = 1 Then
            Dim ofr01 As New CONSULTA_TBANCO_ACTUALIZA
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub XDocToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XDocToolStripMenuItem.Click
        main(31) += 1
        If (main(31) = 1) Then
            Dim ofr01 As New CONSULTA_ANA_PENDIENT_PAGAR
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("P01") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(31) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub XDocToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XDocToolStripMenuItem1.Click
        main(32) += 1
        If (main(32) = 1) Then
            Dim ofr01 As New CONSULTA_ANA_PENDIENT_COBRAR
            ofr01.MdiParent = Me
            If OBJ.SEGURIDAD_FORM("P02") = False Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : main(32) = 0 : Exit Sub
            ofr01.Show()
        End If
    End Sub

    Private Sub XPersonaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XPersonaToolStripMenuItem1.Click
        main(43) += 1
        If (main(43) = 1) Then
            Dim ofr01 As New CONSULTA_CTA_X_COBRAR_PER()
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub XPersonaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XPersonaToolStripMenuItem.Click
        main(44) += 1
        If (main(44) = 1) Then
            Dim ofr01 As New CONSULTA_CTA_X_PAGAR_PER()
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DocumentosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentosToolStripMenuItem.Click
        main(45) += 1
        If (main(45) = 1) Then
            Dim ofr01 As New CONSULTA_PARA_COSTOS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CierrePeriodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CierrePeriodoToolStripMenuItem.Click
        main(46) += 1
        If (main(46) = 1) Then
            Dim ofr01 As New PERIODO_CIERRE
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub mnuRecoveryFFijoRendiciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecoveryFFijoRendiciones.Click
        main(47) += 1
        If (main(47) = 1) Then
            Dim ofr01 As New RECOVERY_FFIJO
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuadreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreToolStripMenuItem.Click
        main(48) += 1
        If main(48) = 1 Then
            Dim ofr01 As New REPORTE_CUADRE_TP1()
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuadreContableCtasXPagarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreContableCtasXPagarToolStripMenuItem.Click
        main(49) += 1
        If main(49) = 1 Then
            Dim ofr01 As New REPORTE_CUADRE_TCON_TCTAS_PAGAR
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuadreToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreToolStripMenuItem1.Click
        main(50) += 1
        If main(50) = 1 Then
            Dim ofr01 As New REPORTE_CUADRE_TC1()
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuadreContableCtasXCobrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreContableCtasXCobrarToolStripMenuItem.Click
        main(51) += 1
        If main(51) = 1 Then
            Dim ofr01 As New REPORTE_CUADRE_TCON_TCTAS_COBRAR
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DepurarCtasXPagarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepurarCtasXPagarToolStripMenuItem.Click
        main(52) += 1
        If main(52) = 1 Then
            Dim ofr01 As New DEPURAR_TCTAS_PAGAR
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub DepurarCtasXCobrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepurarCtasXCobrarToolStripMenuItem.Click
        main(53) += 1
        If main(53) = 1 Then
            Dim ofr01 As New DEPURAR_TCTAS_COBRAR
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuadreToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreToolStripMenuItem2.Click
        main(105) += 1
        If (main(105) = 1) Then
            Dim ofr01 As New REPORTE_ANA_TP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuadreAnalisisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreAnalisisToolStripMenuItem.Click
        main(107) += 1
        If (main(107) = 1) Then
            Dim ofr01 As New REPORTE_CUADRE_TP
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuadreToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreToolStripMenuItem3.Click
        main(106) += 1
        If (main(106) = 1) Then
            Dim ofr01 As New REPORTE_ANA_TC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub CuadreAnalisisToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadreAnalisisToolStripMenuItem1.Click
        main(108) += 1
        If (main(108) = 1) Then
            Dim ofr01 As New REPORTE_CUADRE_TC
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub AnalisisDeCuenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalisisDeCuenToolStripMenuItem.Click
        main(109) += 1
        If (main(109) = 1) Then
            Dim ofr01 As New ANALISIS_CTAS
            ofr01.MdiParent = Me
            ofr01.Show()
        End If
    End Sub

    Private Sub PersonasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonasToolStripMenuItem.Click
        main(110) = main(110) + 1
        If main(110) = 1 Then
            Dim ofr0 As New REPORTE_PERSONAS
            ofr0.MdiParent = Me
            ofr0.Show()
        End If
    End Sub

    Private Sub FlujoEfectivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlujoEfectivoToolStripMenuItem.Click
        Dim frm As frmConceptoFujoEfectivo = frmConceptoFujoEfectivo.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuMensajesImpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMensajesImpresion.Click
        Dim frm As frmMensajes = frmMensajes.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub VerificacionContabilidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerificacionContabilidadToolStripMenuItem.Click
        Dim frm As ANALISIS_CONTABILIDAD = ANALISIS_CONTABILIDAD.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub MantenimientoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MantenimientoToolStripMenuItem1.Click
        Dim frm As MANTENIMIENTO_FORMULARIO_SEGURIDAD = MANTENIMIENTO_FORMULARIO_SEGURIDAD.ObtenerInstancia
        frm.MdiParent = Me
        If TIPO_USU <> "MS" Then MessageBox.Show("No tiene permisos para acceder a este formulario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        frm.Show()
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsultaToolStripMenuItem.Click
        Dim frm As CONSULTA_FORMULARIO_SEGURIDAD = CONSULTA_FORMULARIO_SEGURIDAD.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConceptoUNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptoUNToolStripMenuItem.Click
        Dim frm As FrmConceptoUN = FrmConceptoUN.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConceptoCuentaUNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptoCuentaUNToolStripMenuItem.Click
        Dim frm As FrmConceptoCuentaUN = FrmConceptoCuentaUN.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub ConceptoCCostoUNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConceptoCCostoUNToolStripMenuItem.Click
        Dim frm As FrmConceptoCCUN = FrmConceptoCCUN.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub NivelConceptoUNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NivelConceptoUNToolStripMenuItem.Click
        Dim frm As FrmNivelConceptoUN = FrmNivelConceptoUN.ObtenerInstancia
        frm.MdiParent = Me
        frm.Show()
    End Sub
End Class