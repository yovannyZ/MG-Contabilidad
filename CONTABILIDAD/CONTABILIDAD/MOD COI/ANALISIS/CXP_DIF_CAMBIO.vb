Imports System.Data.SqlClient
Public Class CXP_DIF_CAMBIO
    Dim COD_AUX, cuenta_haber, cuenta_debe, CUENTA_ENLACE, CUENTA_DESTINO, COD_SUCURSAL2, TOTAL0, DH0, CTA0, TOTAL0_PTE, DH0_PTE, CTA0_PTE, COD_AUX2, COD_COMP, COD_COMP2, COD_CUENTA, COD_SUCURSAL As String
    Dim DT_DET As New DataTable
    Dim FECHA_COMP0000 As DateTime
    Dim obj As New Class1
    Dim TC_ACT As Decimal
    Private Sub btn_aceptar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar.Click
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If cbo_com.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com.Focus() : Exit Sub
        If txt_nro_comp.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp.Focus() : Exit Sub
        If txt_cta_debe.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta de Debe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta_debe.Focus() : Exit Sub
        If txt_cta_haber.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta de Haber", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta_debe.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub
        'Validamos si el periodo para este tipo de  cuenta se encuentra bloqueado
        If (obj.ValidarCierreCuentas("CP", AÑO, obj.COD_MES(cbo_mes.Text)) = True) Then
            MessageBox.Show("El periodo se encuentra bloqueado,no se pueden realizar operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '------------------------------------------------
        Dim I, CONT As Integer
        CONT = dgw1.RowCount - 1
        For I = 0 To CONT
            If dgw1.Item(2, I).Value = True Then
                Dim ls As String = (dgw1.Item(0, I).Value)
                If obj.VERIFICAR_CIERRE_CUENTAS(ls, AÑO, obj.COD_MES(cbo_mes.Text)) = False Then Exit Sub
            End If
        Next
        '------------------------------------------------
        TC_ACT = obj.SACAR_CAMBIO_MENSUAL(AÑO, obj.COD_MES(cbo_mes.Text), "D", "V")
        '------------------------------------------------
        If TC_ACT = 0 Or TC_ACT = Nothing Then
            MessageBox.Show("Debe cargar el Tipo de Cambio Mensual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '------------------------------------------------
        If (Decimal.Compare(TC_ACT, Decimal.Zero) <> 0) Then
            SALDOS_CUENTAS()
            ASIENTO_TOTAL()
            If VALIDAR_CREAR_COMP1() = False Then MessageBox.Show("No existe Diferencia de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : LIMPIAR_GRID1() : Exit Sub
            If (CREAR_ASIENTO() = "FALLO") Then
                MessageBox.Show("Ocurrió un error", "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                obj.ELIMINAR_TEMPORAL("TCON")
            Else
                'Dim comp As String = cbo_com.Text
                'cbo_com.SelectedIndex = -1
                'cbo_com.Text = comp
                MessageBox.Show("Se realizó la  Diferencia de Cambios en documentos conciliados.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                LIMPIAR_GRID1()
                NUEVO()
            End If
        End If
    End Sub
    Sub LIMPIAR_GRID1()
        Dim I, CONT As Integer
        CONT = dgw1.Rows.Count - 1
        For I = 0 To CONT
            dgw1.Item(2, I).Value = False
            dgw1.Item(3, I).Value = 0
        Next
    End Sub
    Sub LIMPIAR_GRID2()
        Dim I, CONT As Integer
        CONT = dgw2.Rows.Count - 1
        For I = 0 To CONT
            dgw2.Item(2, I).Value = False
            dgw2.Item(3, I).Value = 0
        Next
    End Sub
    Function VALIDAR_CREAR_COMP1() As Boolean
        Dim I, CONT As Integer
        I = 0 : CONT = dgw1.RowCount - 1
        For I = 0 To CONT
            If dgw1.Item(2, I).Value = True And dgw1.Item(3, I).Value <> 0 Then
                Return True
            End If
        Next
        Return False
    End Function
    Function VALIDAR_CREAR_COMP2() As Boolean
        Dim I, CONT As Integer
        I = 0 : CONT = dgw2.RowCount - 1
        For I = 0 To CONT
            If dgw2.Item(2, I).Value = True And dgw2.Item(3, I).Value <> 0 Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub btn_aceptar2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_aceptar2.Click
        If cbo_aux2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux2.Focus() : Exit Sub
        If cbo_com2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_com2.Focus() : Exit Sub
        If txt_nro_comp2.Text.Trim = "" Then MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_nro_comp2.Focus() : Exit Sub
        If cbo_mes2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes2.Focus() : Exit Sub
        'Validamos si el periodo para este tipo de  cuenta se encuentra bloqueado
        If (obj.ValidarCierreCuentas("CP", AÑO, obj.COD_MES(cbo_mes2.Text)) = True) Then
            MessageBox.Show("El periodo se encuentra bloqueado,no se pueden realizar operaciones", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        '------------------------------------------------
        Dim I, CONT As Integer
        CONT = dgw2.RowCount - 1
        For I = 0 To CONT
            If dgw2.Item(2, I).Value = True Then
                Dim ls As String = (dgw2.Item(0, I).Value)
                If obj.VERIFICAR_CIERRE_CUENTAS(ls, AÑO, obj.COD_MES(cbo_mes2.Text)) = False Then Exit Sub
            End If
        Next
        '------------------------------------------------
        If (VERIFICAR_MSALDO_CUENTA()) Then
            If txt_cta_debe02.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta de Debe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta_debe02.Focus() : Exit Sub
            If txt_cta_haber20.Text.Trim = "" Then MessageBox.Show("Debe elegir la Cuenta de Haber", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_cta_haber20.Focus() : Exit Sub
            'TC_ACT = obj.SACAR_CAMBIO_MENSUAL(AÑO, obj.COD_MES(cbo_mes2.Text), "D", "V")
            If rbCompra.Checked Then
                TC_ACT = obj.SACAR_CAMBIO_MENSUAL(AÑO, obj.COD_MES(cbo_mes2.Text), "D", "C")
            Else
                TC_ACT = obj.SACAR_CAMBIO_MENSUAL(AÑO, obj.COD_MES(cbo_mes2.Text), "D", "V")
            End If
            '----------------------------------------
            If TC_ACT = 0 Or TC_ACT = Nothing Then
                MessageBox.Show("Debe cargar el Tipo de Cambio Mensual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            '----------------------------------------
            If (Decimal.Compare(TC_ACT, Decimal.Zero) <> 0) Then
                SALDOS_CUENTAS_PTE()
                ASIENTO_TOTAL_PTE()
                If VALIDAR_CREAR_COMP2() = False Then MessageBox.Show("No existe Diferencia de Cambio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : LIMPIAR_GRID2() : Exit Sub
                '----------------------------------------
                If (CREAR_ASIENTO_PTE() = "FALLO") Then
                    MessageBox.Show("Ocurrió un error", "Vuelva a intentarlo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    obj.ELIMINAR_TEMPORAL("TCON")
                Else
                    'Dim comp As String = cbo_com2.Text
                    'cbo_com2.SelectedIndex = -1
                    'cbo_com2.Text = comp
                    MessageBox.Show("Se realizó la  Diferencia de Cambios en documentos pendientes.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    LIMPIAR_GRID2()
                    NUEVO2()
                End If
                '----------------------------------------
            End If
        End If
    End Sub
  
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click, btn_salir2.Click
        main(62) = 0
        Close()
    End Sub
    Private Sub cbo_aux_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux.SelectedIndexChanged
        If (cbo_aux.SelectedIndex <> -1) Then
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            CBO_COMPROBANTE()
        End If
    End Sub
    Private Sub cbo_aux2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_aux2.SelectedIndexChanged
        If (cbo_aux2.SelectedIndex <> -1) Then
            COD_AUX2 = obj.COD_AUX(cbo_aux2.Text)
            CBO_COMPROBANTE2()
        End If
    End Sub
    Sub CBO_AUXILIAR()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_aux.Items.Add(Rs3.GetString(0))
                cbo_aux2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            con.Close()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub NUEVO()
        If cbo_aux.SelectedIndex <> -1 And cbo_com.SelectedIndex <> -1 And cbo_mes.SelectedIndex <> -1 Then
            COD_AUX = obj.COD_AUX(cbo_aux.Text)
            COD_COMP = obj.COD_COMP(cbo_com.Text, COD_AUX)
            Dim NUM0 As String = obj.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, obj.COD_MES(cbo_mes.Text))
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeración para este Comprobante", "Advertencia")
            End If
            txt_nro_comp.Text = NUM0
        End If
    End Sub

    Private Sub cbo_com_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbo_com.SelectedIndexChanged
        NUEVO()
    End Sub
 
    Sub CBO_COMPROBANTE()
        cbo_com.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (COD_AUX)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_com.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (cbo_com.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Sub CBO_COMPROBANTE2()
        cbo_com2.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = (CommandType.StoredProcedure)
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = (COD_AUX2)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                cbo_com2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (cbo_com2.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged
        'Dim VB$t_i4$L0 As Integer = (dgw1.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (dgw1.RowCount - 1))
            dgw1.Item(2, i).Value = (ch1.Checked)
            i += 1
        Loop
    End Sub
    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch2.CheckedChanged
        'Dim VB$t_i4$L0 As Integer = (dgw2.RowCount - 1)
        Dim i As Integer = 0
        Do While (i <= (dgw2.RowCount - 1))
            dgw2.Item(2, i).Value = (ch2.Checked)
            i += 1
        Loop
    End Sub
    Sub ASIENTO_TOTAL()
        CUENTA_ENLACE = ""
        CUENTA_DESTINO = ""
        Dim I, CONT As Integer
        I = 0 : CONT = dgw1.RowCount - 1
        TOTAL0 = 0
        For I = 0 To CONT
            TOTAL0 = TOTAL0 + dgw1.Item(3, I).Value
        Next
        DH0 = "H"
        TOTAL0 = TOTAL0
        CTA0 = txt_cta_haber.Text 'obj.DIR_TABLA_DESC("CTA_DC_H", "TDCTA")
        If TOTAL0 < 0 Then
            DH0 = "D"
            TOTAL0 = TOTAL0 * -1
            CTA0 = txt_cta_debe.Text 'obj.DIR_TABLA_DESC("CTA_DC_D", "TDCTA")
        End If
        'DEBO VER SI TIENE O NO AUTOMATICAS
        '--------------------------------------
        CUENTA_ENLACE = obj.HALLAR_CTA_ENLACE(AÑO, CTA0)
        CUENTA_DESTINO = obj.HALLAR_CTA_DESTINO(AÑO, CTA0)
    End Sub
    Sub CARGAR_CTAS()
        Try
            dgw_cta01.DataSource = obj.MOSTRAR_CUENTAS_NO_CXP_NO_CXC(AÑO)
            dgw_cta01.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta01.Columns.Item(0).Width = 85
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            dgw_cta02.DataSource = obj.MOSTRAR_CUENTAS_NO_CXP_NO_CXC(AÑO)
            dgw_cta02.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cta02.Columns.Item(0).Width = 85
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            dgw_cuenta001.DataSource = obj.MOSTRAR_CUENTAS_NO_CXP_NO_CXC(AÑO)
            dgw_cuenta001.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cuenta001.Columns.Item(0).Width = 85
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            dgw_cuenta002.DataSource = obj.MOSTRAR_CUENTAS_NO_CXP_NO_CXC(AÑO)
            dgw_cuenta002.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 8.0!, FontStyle.Bold)
            dgw_cuenta002.Columns.Item(0).Width = 85
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ASIENTO_TOTAL_PTE()
        CUENTA_ENLACE = ""
        CUENTA_DESTINO = ""
        Dim I, CONT As Integer
        I = 0 : CONT = dgw2.RowCount - 1
        TOTAL0_PTE = 0
        For I = 0 To CONT
            TOTAL0_PTE = TOTAL0_PTE + dgw2.Item(3, I).Value
        Next
        DH0_PTE = "H"
        TOTAL0_PTE = TOTAL0_PTE
        CTA0_PTE = txt_cta_haber20.Text 'obj.DIR_TABLA_DESC("CTA_DC_H", "TDCTA")
        If TOTAL0_PTE < 0 Then
            DH0_PTE = "D"
            TOTAL0_PTE = TOTAL0_PTE * -1
            CTA0_PTE = txt_cta_debe02.Text 'obj.DIR_TABLA_DESC("CTA_DC_D", "TDCTA")
        End If
        'DEBO VER SI TIENE O NO AUTOMATICAS
        '--------------------------------------
        CUENTA_ENLACE = obj.HALLAR_CTA_ENLACE(AÑO, CTA0_PTE)
        CUENTA_DESTINO = obj.HALLAR_CTA_DESTINO(AÑO, CTA0_PTE)
    End Sub
    Sub FECHA_COMP(ByVal AÑO00 As String, ByVal MES00 As String)
        Try
            Dim PROG_01 As New SqlCommand("HALLAR_FECHA_PERIODO_PERSONALIZADO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO00
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES00
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                FECHA_COMP0000 = Date.Parse(Rs3.GetValue(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            con.Close()
        End Try
    End Sub
    Function CREAR_ASIENTO() As String
        FECHA_COMP(AÑO, obj.COD_MES(cbo_mes.Text))
        '-------------------------------------------------------------------------------------------------
             '-------------------------------------------------------------------------------------------------
        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.RowCount - 1)
        DT_DET.Rows.Clear()

        I = 0
        Do While (I <= CONT)
            If dgw1.Item(2, I).Value = True Then
                Dim COD_D_H0 As String = "D"
                Dim IMP_S As Decimal = (dgw1.Item(3, I).Value)
                If (Decimal.Compare(IMP_S, Decimal.Zero) < 0) Then
                    COD_D_H0 = "H"
                    IMP_S = IMP_S * -1
                End If
                DT_DET.Rows.Add(AÑO, obj.COD_MES(cbo_mes.Text), COD_AUX, COD_COMP, txt_nro_comp.Text, "00", String.Format("{0}-{1}", AÑO, MES), "", "", (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_COMP0000, "", "", FECHA_GRAL.Date, "AJUSTE DE DIFERENCIA DE CAMBIO", dgw1.Item(0, I).Value.ToString, IMP_S, 0, COD_D_H0, "A", TC_ACT, "", "", "", "", FECHA_GRAL.Date, "0", "", "", "0", "0", "0", "0", "", "", FECHA_GRAL.Date, 0, "", "0", FECHA_GRAL.Date, 0, NOMBRE_PC, "1")
            End If
            I += 1
        Loop
        'CUENTA DEL TOTAL DEL COMPROBANTE
        '------------------------------------------------
        DT_DET.Rows.Add(AÑO, obj.COD_MES(cbo_mes.Text), COD_AUX, COD_COMP, txt_nro_comp.Text, "00", String.Format("{0}-{1}", AÑO, MES), "", "", (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_COMP0000, "", "", FECHA_GRAL.Date, "AJUSTE TOTAL DE DIFERENCIA DE CAMBIO", CTA0, TOTAL0, 0, DH0, "A", TC_ACT, "", "", "", "", FECHA_GRAL.Date, "0", CUENTA_ENLACE, CUENTA_DESTINO, "0", "0", "0", "0", "", "", FECHA_GRAL.Date, 0, "", "0", FECHA_GRAL.Date, 0, NOMBRE_PC, "0")
        '------------------------------------------------
        If CUENTA_DESTINO <> "" And CUENTA_ENLACE <> "" Then
            '------------------------------------------------
            'INSERTAR LAS CUENTAS AUTOMATICAS 
            Dim DH_ENLACE = "D"
            If DH0 = "D" Then DH_ENLACE = "H"
            DT_DET.Rows.Add(AÑO, obj.COD_MES(cbo_mes.Text), COD_AUX, COD_COMP, txt_nro_comp.Text, "00", String.Format("{0}-{1}", AÑO, MES), "", "", (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_COMP0000, "", "", FECHA_GRAL.Date, "AJUSTE TOTAL DE DIFERENCIA DE CAMBIO", CUENTA_ENLACE, TOTAL0, 0, DH_ENLACE, "A", TC_ACT, "", "", "", "", FECHA_GRAL.Date, "0", "", "", "1", "0", "0", "0", "", "", FECHA_GRAL.Date, 0, "", "0", FECHA_GRAL.Date, 0, NOMBRE_PC, "0")
            DT_DET.Rows.Add(AÑO, obj.COD_MES(cbo_mes.Text), COD_AUX, COD_COMP, txt_nro_comp.Text, "00", String.Format("{0}-{1}", AÑO, MES), "", "", (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_COMP0000, "", "", FECHA_GRAL.Date, "AJUSTE TOTAL DE DIFERENCIA DE CAMBIO", CUENTA_DESTINO, TOTAL0, 0, DH0, "A", TC_ACT, "", "", "", "", FECHA_GRAL.Date, "0", "", "", "1", "0", "0", "0", "", "", FECHA_GRAL.Date, 0, "", "0", FECHA_GRAL.Date, 0, NOMBRE_PC, "0")
        End If
        Try
            con.Open()
            sqlbc.DestinationTableName = ("dbo.T_CON2")
            sqlbc.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
            'Dim CREAR_ASIENTO As String = estado
            Return estado
        End Try
        Try
       

            Dim CMD As New SqlCommand("INSERTAR_I_CON_DIF_CAMBIO_CXP", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = COD_AUX
            CMD.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = COD_COMP
            CMD.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = txt_nro_comp.Text
            CMD.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = FECHA_COMP0000
            CMD.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = COD_USU
            CMD.Parameters.Add("@fecha", SqlDbType.DateTime).Value = FECHA_GRAL.Date
            CMD.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            CMD.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = obj.COD_MES(cbo_mes.Text)
            CMD.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            con.Open()
            estado = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
            estado = "FALLO"
        End Try
        Return estado
    End Function
    Function CREAR_ASIENTO_PTE() As String
        FECHA_COMP(AÑO, obj.COD_MES(cbo_mes2.Text))

        Dim estado As String = "FALLO"
        Dim sqlbc As New SqlBulkCopy(con)
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw2.RowCount - 1)
        DT_DET.Rows.Clear()
        I = 0
        Do While (I <= CONT)
            If dgw2.Item(2, I).Value = True Then
                Dim COD_D_H0 As String = "D"
                Dim IMP_S As Decimal = Decimal.Parse((dgw2.Item(3, I).Value))
                If (Decimal.Compare(IMP_S, Decimal.Zero) < 0) Then
                    COD_D_H0 = "H"
                    'IMP_S = Decimal.Multiply(IMP_S, Decimal.MinusOne)
                    IMP_S = IMP_S * -1
                End If
                DT_DET.Rows.Add(AÑO, obj.COD_MES(cbo_mes2.Text), COD_AUX2, COD_COMP2, txt_nro_comp2.Text, "00", String.Format("{0}-{1}", AÑO, MES), "", "", (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_COMP0000, "", "", FECHA_GRAL.Date, "AJUSTE DE DIFERENCIA DE CAMBIO", dgw2.Item(0, I).Value.ToString, IMP_S, 0, COD_D_H0, "A", TC_ACT, "", "", "", "", FECHA_GRAL.Date, "0", "", "", "0", "0", "0", "0", "", "", FECHA_GRAL.Date, 0, "", "0", FECHA_GRAL.Date, 0, NOMBRE_PC, "1")
            End If
            I += 1
        Loop

        'CUENTA DEL TOTAL DEL COMPROBANTE
        '------------------------------------------------
        DT_DET.Rows.Add(AÑO, obj.COD_MES(cbo_mes2.Text), COD_AUX2, COD_COMP2, txt_nro_comp2.Text, "00", String.Format("{0}-{1}", AÑO, MES), "", "", (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_COMP0000, "", "", FECHA_GRAL.Date, "AJUSTE TOTAL DE DIFERENCIA DE CAMBIO", CTA0_PTE, TOTAL0_PTE, 0, DH0_PTE, "A", TC_ACT, "", "", "", "", FECHA_GRAL.Date, "0", CUENTA_ENLACE, CUENTA_DESTINO, "0", "0", "0", "0", "", "", FECHA_GRAL.Date, 0, "", "0", FECHA_GRAL.Date, 0, NOMBRE_PC, "0")
        '------------------------------------------------
        If CUENTA_DESTINO <> "" And CUENTA_ENLACE <> "" Then
            '------------------------------------------------
            'INSERTAR LAS CUENTAS AUTOMATICAS 
            Dim DH_ENLACE = "D"
            If DH0_PTE = "D" Then DH_ENLACE = "H"
            DT_DET.Rows.Add(AÑO, obj.COD_MES(cbo_mes2.Text), COD_AUX2, COD_COMP2, txt_nro_comp2.Text, "00", String.Format("{0}-{1}", AÑO, MES), "", "", (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_COMP0000, "", "", FECHA_GRAL.Date, "AJUSTE TOTAL DE DIFERENCIA DE CAMBIO", CUENTA_ENLACE, TOTAL0_PTE, 0, DH_ENLACE, "A", TC_ACT, "", "", "", "", FECHA_GRAL.Date, "0", "", "", "1", "0", "0", "0", "", "", FECHA_GRAL.Date, 0, "", "0", FECHA_GRAL.Date, 0, NOMBRE_PC, "0")
            DT_DET.Rows.Add(AÑO, obj.COD_MES(cbo_mes2.Text), COD_AUX2, COD_COMP2, txt_nro_comp2.Text, "00", String.Format("{0}-{1}", AÑO, MES), "", "", (DT_DET.Rows.Count + 1).ToString("0000"), FECHA_COMP0000, "", "", FECHA_GRAL.Date, "AJUSTE TOTAL DE DIFERENCIA DE CAMBIO", CUENTA_DESTINO, TOTAL0_PTE, 0, DH0_PTE, "A", TC_ACT, "", "", "", "", FECHA_GRAL.Date, "0", "", "", "1", "0", "0", "0", "", "", FECHA_GRAL.Date, 0, "", "0", FECHA_GRAL.Date, 0, NOMBRE_PC, "0")
        End If
        Try
            con.Open()
            sqlbc.DestinationTableName = ("dbo.T_CON2")
            sqlbc.WriteToServer(DT_DET)
            con.Close()
        Catch ex As Exception

            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
            'Dim CREAR_ASIENTO_PTE As String = estado

            Return estado

        End Try
        Try
            'Dim fec_comp00 As DateTime = DateTime.Parse((FECHA_GRAL.Day & "/" & obj.COD_MES(cbo_mes2.Text) & "/" & AÑO))
            Dim CMD As New SqlCommand("INSERTAR_I_CON_DIF_CAMBIO_CXP_PTE", con)
            CMD.CommandType = (CommandType.StoredProcedure)
            CMD.Parameters.Add("@cod_aux", SqlDbType.VarChar).Value = (COD_AUX2)
            CMD.Parameters.Add("@cod_comP", SqlDbType.VarChar).Value = (COD_COMP2)
            CMD.Parameters.Add("@nro_comP", SqlDbType.VarChar).Value = (txt_nro_comp2.Text)
            CMD.Parameters.Add("@fecha_comP", SqlDbType.DateTime).Value = FECHA_COMP0000
            CMD.Parameters.Add("@cod_usu", SqlDbType.VarChar).Value = (COD_USU)
            CMD.Parameters.Add("@fecha", SqlDbType.DateTime).Value = (FECHA_GRAL.Date)
            CMD.Parameters.Add("@fe_año", SqlDbType.VarChar).Value = AÑO
            CMD.Parameters.Add("@fe_mes", SqlDbType.VarChar).Value = obj.COD_MES(cbo_mes2.Text)
            CMD.Parameters.Add("@nombre_pc", SqlDbType.VarChar).Value = NOMBRE_PC
            con.Open()
            estado = (CMD.ExecuteScalar)
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
            estado = "FALLO"
        End Try
        Return estado
    End Function
    Sub CREAR_DATASET()
        DT_DET.Columns.Add("FE_AÑO")
        DT_DET.Columns.Add("FE_MES")
        DT_DET.Columns.Add("COD_AUX")
        DT_DET.Columns.Add("COD_COMP")
        DT_DET.Columns.Add("NRO_COMP")
        DT_DET.Columns.Add("COD_DOC")
        DT_DET.Columns.Add("NRO_DOC")
        DT_DET.Columns.Add("COD_PER")
        DT_DET.Columns.Add("NRO_DOC_PER")
        DT_DET.Columns.Add("ITEM")
        DT_DET.Columns.Add("FECHA_DOC")
        DT_DET.Columns.Add("COD_REF")
        DT_DET.Columns.Add("NRO_REF")
        DT_DET.Columns.Add("FECHA_REF")
        DT_DET.Columns.Add("GLOSA")
        DT_DET.Columns.Add("COD_CTA")
        DT_DET.Columns.Add("IMP_S")
        DT_DET.Columns.Add("IMP_D")
        DT_DET.Columns.Add("COD_D_H")
        DT_DET.Columns.Add("COD_MONEDA")
        DT_DET.Columns.Add("TIPO_CAMBIO")
        DT_DET.Columns.Add("COD_CC")
        DT_DET.Columns.Add("COD_CONTROL")
        DT_DET.Columns.Add("COD_PROYECTO")
        DT_DET.Columns.Add("NRO_ORDEN")
        DT_DET.Columns.Add("FECHA_VEN")
        DT_DET.Columns.Add("STATUS_PRECIO")
        DT_DET.Columns.Add("CUENTA_ENLACE")
        DT_DET.Columns.Add("CUENTA_DESTINO")
        DT_DET.Columns.Add("STATUS_AUTO")
        DT_DET.Columns.Add("TIPO_TRANS")
        DT_DET.Columns.Add("STATUS_ANALISIS")
        DT_DET.Columns.Add("STATUS_PAGO")
        DT_DET.Columns.Add("COD_MP")
        DT_DET.Columns.Add("NRO_MP")
        DT_DET.Columns.Add("FECHA_MP")
        DT_DET.Columns.Add("ITEM_PAGO")
        DT_DET.Columns.Add("COD_BANCO_DEST")
        DT_DET.Columns.Add("STATUS_TRANS")
        DT_DET.Columns.Add("FECHA_COM")
        DT_DET.Columns.Add("POR_IGV")
        DT_DET.Columns.Add("NOMBRE_PC")
        DT_DET.Columns.Add("ST_REP")
    End Sub
    Sub DGW_CUENTAS00()
        Try
            Dim cmd As New SqlCommand("DGW_CUENTAS_STATUS_TIPO", con)
            cmd.CommandType = (CommandType.StoredProcedure)
            cmd.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@STATUS_ANA", SqlDbType.VarChar).Value = ("P")
            con.Open()
            cmd.ExecuteNonQuery()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                dgw1.Rows.Add(dr.GetString(0), dr.GetString(1), False)
                dgw2.Rows.Add(dr.GetString(0), dr.GetString(1), False)
            Loop
            con.Close()
            dgw1.Columns.Item(0).ReadOnly = (True)
            dgw1.Columns.Item(1).ReadOnly = (True)
            dgw2.Columns.Item(0).ReadOnly = (True)
            dgw2.Columns.Item(1).ReadOnly = (True)
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
            'MsgBox(ex.Message)
        End Try
    End Sub
    Sub SALDOS_CUENTAS()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.RowCount - 1)

        I = 0
        Do While (I <= CONT)
            If dgw1.Item(2, I).Value = True Then
                Dim COD_CUENTA0 As String = dgw1.Item(0, I).Value.ToString
                If obj.VERIFICAR_CIERRE_CUENTAS(COD_CUENTA0, AÑO, obj.COD_MES(cbo_mes.Text)) = False Then Exit Sub
                Dim IMP As New Decimal
                Try
                    Dim cmd As New SqlCommand("DIF_CAMBIO_CONC_CXP", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = (COD_CUENTA0)
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
                    con.Open()
                    IMP = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception


                    con.Close()
                    MsgBox(ex.Message)
                    'MsgBox(ex.Message)

                End Try
                dgw1.Item(3, I).Value = (IMP)
            End If
            I += 1
        Loop
    End Sub
    Sub SALDOS_CUENTAS_PTE()
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw2.RowCount - 1)

        Dim stTC As Integer = 0
        If rbCompra.Checked Then
            stTC = 1
        End If

        I = 0
        Do While (I <= CONT)
            If dgw2.Item(2, I).Value = True Then
                Dim COD_CUENTA0 As String = dgw2.Item(0, I).Value.ToString
                If obj.VERIFICAR_CIERRE_CUENTAS(COD_CUENTA0, AÑO, obj.COD_MES(cbo_mes2.Text)) = False Then Exit Sub
                Dim IMP As New Decimal
                Try
                    Dim cmd As New SqlCommand("DIF_CAMBIO_PTE_CXP", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = (COD_CUENTA0)
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes2.Text)
                    cmd.Parameters.Add("@ST_TIPO_CAMBIO", SqlDbType.Char).Value = stTC
                    con.Open()
                    IMP = (cmd.ExecuteScalar)
                    con.Close()
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                    'MsgBox(ex.Message)
                End Try
                dgw2.Item(3, I).Value = (IMP)
            End If
            I += 1
        Loop
    End Sub
    Function VERIFICAR_CONCILIACION() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw2.RowCount - 1)

        I = 0
        Do While (I <= CONT)
            If dgw2.Item(2, I).Value = True Then
                Dim COD_CUENTA0 As String = dgw2.Item(0, I).Value.ToString
                Dim IMP As New Decimal
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_CONCILIACION", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = (COD_CUENTA0)
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes.Text)
                    con.Open()
                    IMP = (cmd.ExecuteScalar)
                    con.Close()
                    If (Decimal.Compare(IMP, Decimal.Zero) > 0) Then
                        MessageBox.Show(("Las cuenta " & COD_CUENTA0 & " tiene descuadre en la Conciliación."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                    'MsgBox(ex.Message)
                    'Dim VERIFICAR_CONCILIACION As Boolean = False
                    Return False
                End Try
            End If
            I += 1
        Loop
        Return True
    End Function
    Function VERIFICAR_MSALDO_CUENTA() As Boolean
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.RowCount - 1)
        I = 0
        Do While (I <= CONT)
            If dgw2.Item(2, I).Value = True Then
                Dim COD_CUENTA0 As String = dgw2.Item(0, I).Value.ToString
                Dim IMP As New Decimal
                Try
                    Dim cmd As New SqlCommand("VERIFICAR_SALDOS_MAESTROS", con)
                    cmd.CommandType = (CommandType.StoredProcedure)
                    cmd.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = (COD_CUENTA0)
                    cmd.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = obj.COD_MES(cbo_mes2.Text)
                    con.Open()
                    IMP = (cmd.ExecuteScalar)
                    con.Close()
                    If (Decimal.Compare(IMP, Decimal.Zero) <> 0) Then
                        MessageBox.Show(("Las cuenta " & COD_CUENTA0 & " tienes errores en Saldos."), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                Catch ex As Exception
                    con.Close()
                    MsgBox(ex.Message)
                    'Dim VERIFICAR_MSALDO_CUENTA As Boolean = False
                    Return False
                End Try
            End If
            I += 1
        Loop
        Return True
    End Function
    Private Sub CXP_DIF_CAMBIO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub CXP_DIF_CAMBIO_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.KeyPreview = True
        dgw1.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        dgw2.ColumnHeadersDefaultCellStyle.Font = (New Font("arial", 8.0!, FontStyle.Bold))
        DGW_CUENTAS00()
        CBO_AUXILIAR()
        CARGAR_CTAS()
        txt_cta_haber.Text = obj.DIR_TABLA_DESC("CTA_DC_H", "TDCTA") : txt_cta_haber.Focus()
        txt_cta_debe.Text = obj.DIR_TABLA_DESC("CTA_DC_D", "TDCTA") : txt_cta_debe.Focus()
        txt_cta_debe02.Text = obj.DIR_TABLA_DESC("CTA_DC_D", "TDCTA") : txt_cta_debe02.Focus()
        txt_cta_haber20.Text = obj.DIR_TABLA_DESC("CTA_DC_H", "TDCTA") : txt_cta_haber20.Focus()
        cbo_aux.Focus()
        CREAR_DATASET()
        btn_aceptar.Select()
    End Sub
   
    Private Sub txt_cta_debe_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_debe.LostFocus
        If (Strings.Trim(txt_cta_debe.Text) <> "") Then
            If (dgw_cta01.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta01.Sort(dgw_cta01.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta01.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cta_debe.Text.ToLower = dgw_cta01.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta_debe.Text = dgw_cta01.Item(0, i).Value.ToString
                        txt_cta_debe2.Text = dgw_cta01.Item(1, i).Value.ToString
                        '---------------------------------------------------
                        txt_cta_haber.Focus()
                        Return
                    End If
                    If (txt_cta_debe.Text.ToLower = Strings.Mid((dgw_cta01.Item(0, i).Value), 1, Strings.Len(txt_cta_debe.Text)).ToLower) Then
                        dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta01.Visible = True
                dgw_cta01.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta_debe2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cta_debe2.KeyDown
        If ((Strings.Trim(txt_cta_debe2.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_cta01.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta01.Sort(dgw_cta01.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta01.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cta_debe2.Text.ToLower = Strings.Mid((dgw_cta01.Item(1, i).Value), 1, Strings.Len(txt_cta_debe2.Text)).ToLower) Then
                        dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta01.CurrentCell = dgw_cta01.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta01.Visible = True
                dgw_cta01.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cta01_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta01.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_debe.Text = (dgw_cta01.Item(0, dgw_cta01.CurrentRow.Index).Value)
            txt_cta_debe2.Text = (dgw_cta01.Item(1, dgw_cta01.CurrentRow.Index).Value)
           '---------------------------------------------------
            Panel_cta01.Visible = False
            kl1.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cta_debe.Clear()
            txt_cta_debe2.Clear()
            Panel_cta01.Visible = False
            txt_cta_debe.Focus()
        End If
    End Sub
    Private Sub txt_cta_haber_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_haber.LostFocus
        If (Strings.Trim(txt_cta_haber.Text) <> "") Then
            If (dgw_cta02.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta02.Sort(dgw_cta02.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta02.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cta_haber.Text.ToLower = dgw_cta02.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta_haber.Text = dgw_cta02.Item(0, i).Value.ToString
                        txt_cta_haber2.Text = dgw_cta02.Item(1, i).Value.ToString
                        '---------------------------------------------------
                        btn_aceptar.Focus()
                        Return
                    End If
                    If (txt_cta_haber.Text.ToLower = Strings.Mid((dgw_cta02.Item(0, i).Value), 1, Strings.Len(txt_cta_haber.Text)).ToLower) Then
                        dgw_cta02.CurrentCell = dgw_cta02.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta02.CurrentCell = dgw_cta02.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta02.Visible = True
                dgw_cta02.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta_haber2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cta_haber2.KeyDown
        If ((Strings.Trim(txt_cta_haber2.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_cta02.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cta02.Sort(dgw_cta02.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cta02.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cta_haber2.Text.ToLower = Strings.Mid((dgw_cta02.Item(1, i).Value), 1, Strings.Len(txt_cta_haber2.Text)).ToLower) Then
                        dgw_cta02.CurrentCell = dgw_cta02.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cta02.CurrentCell = dgw_cta02.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel_cta02.Visible = True
                dgw_cta02.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cta02_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cta02.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_haber.Text = (dgw_cta02.Item(0, dgw_cta02.CurrentRow.Index).Value)
            txt_cta_haber2.Text = (dgw_cta02.Item(1, dgw_cta02.CurrentRow.Index).Value)
            '---------------------------------------------------
            Panel_cta02.Visible = False
            kl2.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cta_haber.Clear()
            txt_cta_haber2.Clear()
            Panel_cta02.Visible = False
            txt_cta_haber.Focus()
        End If
    End Sub
    Private Sub txt_cta_debe02_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_debe02.LostFocus
        If (Strings.Trim(txt_cta_debe02.Text) <> "") Then
            If (dgw_cuenta001.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta001.Sort(dgw_cuenta001.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cuenta001.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cta_debe02.Text.ToLower = dgw_cuenta001.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta_debe02.Text = dgw_cuenta001.Item(0, i).Value.ToString
                        txt_cta_debe022.Text = dgw_cuenta001.Item(1, i).Value.ToString
                        '---------------------------------------------------
                        txt_cta_haber.Focus()
                        Return
                    End If
                    If (txt_cta_debe02.Text.ToLower = Strings.Mid((dgw_cuenta001.Item(0, i).Value), 1, Strings.Len(txt_cta_debe02.Text)).ToLower) Then
                        dgw_cuenta001.CurrentCell = dgw_cuenta001.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta001.CurrentCell = dgw_cuenta001.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel2.Visible = True
                dgw_cuenta001.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta_debe022_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cta_debe022.KeyDown
        If ((Strings.Trim(txt_cta_debe022.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_cuenta001.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta001.Sort(dgw_cuenta001.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cuenta001.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cta_debe022.Text.ToLower = Strings.Mid((dgw_cuenta001.Item(1, i).Value), 1, Strings.Len(txt_cta_debe022.Text)).ToLower) Then
                        dgw_cuenta001.CurrentCell = dgw_cuenta001.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta001.CurrentCell = dgw_cuenta001.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel2.Visible = True
                dgw_cuenta001.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cuenta001_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta001.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_debe02.Text = (dgw_cuenta001.Item(0, dgw_cuenta001.CurrentRow.Index).Value)
            txt_cta_debe022.Text = (dgw_cuenta001.Item(1, dgw_cuenta001.CurrentRow.Index).Value)
            '---------------------------------------------------
            Panel2.Visible = False
            kl10.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cta_debe02.Clear()
            txt_cta_debe022.Clear()
            Panel2.Visible = False
            txt_cta_debe02.Focus()
        End If
    End Sub
    '-------------------------------------------
    Private Sub txt_cta_haber02_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cta_haber20.LostFocus
        If (Strings.Trim(txt_cta_haber20.Text) <> "") Then
            If (dgw_cuenta002.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta002.Sort(dgw_cuenta002.Columns.Item(0), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cuenta002.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cta_haber20.Text.ToLower = dgw_cuenta002.Item(0, i).Value.ToString.ToLower) Then
                        txt_cta_haber20.Text = dgw_cuenta002.Item(0, i).Value.ToString
                        txt_cta_haber202.Text = dgw_cuenta002.Item(1, i).Value.ToString
                        '---------------------------------------------------
                        txt_cta_haber.Focus()
                        Return
                    End If
                    If (txt_cta_haber20.Text.ToLower = Strings.Mid((dgw_cuenta002.Item(0, i).Value), 1, Strings.Len(txt_cta_haber20.Text)).ToLower) Then
                        dgw_cuenta002.CurrentCell = dgw_cuenta002.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta002.CurrentCell = dgw_cuenta002.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel3.Visible = True
                dgw_cuenta002.Focus()
            End If
        End If
    End Sub
    Private Sub txt_cta_haber202_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txt_cta_haber202.KeyDown
        If ((Strings.Trim(txt_cta_haber202.Text) <> "") AndAlso (e.KeyData = Keys.Return)) Then
            If (dgw_cuenta002.RowCount = 0) Then
                MessageBox.Show("No existen Cuentas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dgw_cuenta002.Sort(dgw_cuenta002.Columns.Item(1), System.ComponentModel.ListSortDirection.Ascending)
                Dim CONT As Integer = (dgw_cuenta002.RowCount - 1)
                Dim i As Integer = 0
                Do While (i <= CONT)
                    If (txt_cta_haber202.Text.ToLower = Strings.Mid((dgw_cuenta002.Item(1, i).Value), 1, Strings.Len(txt_cta_haber202.Text)).ToLower) Then
                        dgw_cuenta002.CurrentCell = dgw_cuenta002.Rows.Item(i).Cells.Item(0)
                        Exit Do
                    End If
                    dgw_cuenta002.CurrentCell = dgw_cuenta002.Rows.Item(0).Cells.Item(0)
                    i += 1
                Loop
                Panel3.Visible = True
                dgw_cuenta002.Focus()
            End If
        End If
    End Sub
    Private Sub dgw_cuenta002_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles dgw_cuenta002.KeyDown
        If (e.KeyData = Keys.Return) Then
            txt_cta_haber20.Text = (dgw_cuenta002.Item(0, dgw_cuenta002.CurrentRow.Index).Value)
            txt_cta_haber202.Text = (dgw_cuenta002.Item(1, dgw_cuenta002.CurrentRow.Index).Value)
            '---------------------------------------------------
            Panel3.Visible = False
            kl20.Focus()
        ElseIf (e.KeyData = Keys.Escape) Then
            txt_cta_haber20.Clear()
            txt_cta_haber202.Clear()
            Panel3.Visible = False
            txt_cta_haber20.Focus()
        End If
    End Sub
    Sub NUEVO2()
        If (cbo_aux2.SelectedIndex <> -1 And cbo_com2.SelectedIndex <> -1 And cbo_mes2.SelectedIndex <> -1) Then
            COD_AUX2 = obj.COD_AUX(cbo_aux2.Text)
            COD_COMP2 = obj.COD_COMP(cbo_com2.Text, COD_AUX2)
            Dim NUM0 As String = obj.HALLAR_NRO_COMP(COD_AUX2, COD_COMP2, AÑO, obj.COD_MES(cbo_mes2.Text))
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeración para este Comprobante", "Advertencia")
            End If
            txt_nro_comp2.Text = NUM0
        End If
    End Sub
    Private Sub cbo_com2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_com2.SelectedIndexChanged
        NUEVO2()
    End Sub

    Private Sub cbo_mes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        NUEVO()
    End Sub

    Private Sub cbo_mes2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_mes2.SelectedIndexChanged
        NUEVO2()
    End Sub
End Class