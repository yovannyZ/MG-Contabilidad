Imports System.Data.SqlClient
Public Class REPORTE_CTA_MASK
    Dim cod_cuenta, desc_cuenta As String
    Dim OBJ As New Class1
    Dim OFR As New REP_CTA_MASK
    Dim COD_AUX As String
    Private Sub btn_pantalla1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_pantalla1.Click
        If CBO_MES_1.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES_1.Focus() : Exit Sub
        If CBO_MES_2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES_2.Focus() : Exit Sub
        If Trim(txt_mascara.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mascara.Focus() : Exit Sub
        If Len(Trim(txt_mascara.Text)) <> 8 Then MessageBox.Show("Ingresar una Cuenta Contable de 8 digitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mascara.Focus() : Exit Sub
        If CBO_ORDEN.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_ORDEN.Focus() : Exit Sub
        Dim MES1 As String = CBO_MES_1.Text
        Dim MES2 As String = CBO_MES_2.Text
        Dim ORDEN As String = CBO_ORDEN.Text
        Dim MASK As String = (txt_mascara.Text.Replace("X", "_") & "%")
        Dim MASK_X As String = txt_mascara.Text
        OFR.CREAR_REPORTE(MASK, MASK_X, MES1, MES2, CBO_ORDEN.Text, "", "", "1")
        OFR.ShowDialog()
    End Sub
    Private Sub btn_salir_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_salir.Click
        main(82) = 0
        Close()
    End Sub
    Private Sub Reporte_Cuenta_auxiliar_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub Reporte_Cuenta_auxiliar_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        KeyPreview = True
        CBO_AUX00()
    End Sub
    Sub CBO_AUX00()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            Do While Rs3.Read
                Me.cbo_aux.Items.Add(Rs3.GetString(0))
                Me.cbo_aux2.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub cbo_aux2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_aux2.SelectedIndexChanged
        If cbo_aux2.SelectedIndex <> -1 Then
            COD_AUX = OBJ.COD_AUX(cbo_aux2.Text.ToString)
            CBO_COMPROBANTE()
        End If
    End Sub
    Sub CBO_COMPROBANTE()
        Dim GEN As New Genericos
        Dim DT As New DataTable
        DT = GEN.CBO_COMP(COD_AUX)
        CBO_COMP.DataSource = DT
        CBO_COMP.DisplayMember = DT.Columns.Item(0).ToString
        CBO_COMP.ValueMember = DT.Columns.Item(1).ToString
        CBO_COMP.SelectedIndex = -1
        If (CBO_COMP.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btn_pantalla2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla2.Click
        If cbo_aux.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux.Focus() : Exit Sub
        If Trim(txt_cod_cta0.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mascara.Focus() : Exit Sub
        If Len(Trim(txt_cod_cta0.Text)) <> 8 Then MessageBox.Show("Ingresar una Cuenta Contable de 8 digitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mascara.Focus() : Exit Sub
        If cbo_ord2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_ORDEN.Focus() : Exit Sub
        If CBO_MES.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES_1.Focus() : Exit Sub
        If CBO_MES2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES_2.Focus() : Exit Sub
        Dim AUX As String = OBJ.COD_AUX(cbo_aux.Text)
        Dim MES1 As String = CBO_MES.Text
        Dim MES2 As String = CBO_MES2.Text
        Dim ORDEN As String = cbo_ord2.Text
        Dim MASK As String = (txt_cod_cta0.Text.Replace("X", "_") & "%")
        Dim MASK_X As String = txt_cod_cta0.Text
        OFR.CREAR_REPORTE(MASK, MASK_X, MES1, MES2, cbo_ord2.Text, AUX, "", "2")
        OFR.ShowDialog()
    End Sub

    Private Sub btn_pantalla3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla3.Click
        If cbo_aux2.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_aux2.Focus() : Exit Sub
        If CBO_COMP.SelectedIndex = -1 Then MessageBox.Show("Debe eligir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_COMP.Focus() : Exit Sub
        If Trim(txt_cod_cta1.Text) = "" Then MessageBox.Show("Debe elegir una Cuenta Contable", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mascara.Focus() : Exit Sub
        If Len(Trim(txt_cod_cta1.Text)) <> 8 Then MessageBox.Show("Ingresar una Cuenta Contable de 8 digitos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : txt_mascara.Focus() : Exit Sub
        If cbo_ord3.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Orden", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_ORDEN.Focus() : Exit Sub
        If CBO_MES3.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES_1.Focus() : Exit Sub
        If CBO_MES4.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : CBO_MES_2.Focus() : Exit Sub

        Dim AUX As String = OBJ.COD_AUX(cbo_aux2.Text)
        Dim COMP As String = OBJ.COD_COMP(CBO_COMP.Text, AUX)
        Dim MES1 As String = CBO_MES3.Text
        Dim MES2 As String = CBO_MES4.Text
        Dim ORDEN As String = cbo_ord3.Text
        Dim MASK As String = (txt_cod_cta1.Text.Replace("X", "_") & "%")
        Dim MASK_X As String = txt_cod_cta1.Text
        OFR.CREAR_REPORTE(MASK, MASK_X, MES1, MES2, cbo_ord3.Text, AUX, COMP, "3")
        OFR.ShowDialog()
    End Sub

    Private Sub btn_salir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir2.Click
        main(82) = 0
        Close()
    End Sub

    Private Sub btn_salir3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_salir3.Click
        main(82) = 0
        Close()
    End Sub
End Class