Public Class FrmEstadisticaUN
    Dim OBJ As New Class1
    Dim frmViewer_1 As New FrmEstadisticaUNViewer
    Dim frmViewer_2 As New FrmEstadisitcaUNConceptoViewer
    Private Shared _instancia As FrmEstadisticaUN

    Public Shared Function ObtenerInstancia() As FrmEstadisticaUN
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New FrmEstadisticaUN
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Sub CargarAño()
        cbo_año.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("Mostrar_año", con)
            Prog002.CommandType = CommandType.StoredProcedure
            Prog002.Parameters.Add("@COD_MODULO", SqlDbType.Char).Value = COD_MOD
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cbo_año.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Sub CargarUnidadNegocio()

        cboUnidadNegocio.Items.Clear()
        Try
            Dim Prog002 As New SqlCommand("LISTAR_UNIDAD_NEGOCIO", con)
            Prog002.CommandType = CommandType.StoredProcedure
            con.Open()
            Prog002.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = Prog002.ExecuteReader
            Do While Rs3.Read
                cboUnidadNegocio.Items.Add(Rs3.GetString(1))
            Loop
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Function OBTENER_COD_UNIDAD(ByVal desc As String) As String
        Dim cod As String = ""
        Try
            Dim PROG_01 As New SqlCommand("OBTENER_COD_UNIDAD_NEGOCIO", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = (desc)
            con.Open()
            cod = PROG_01.ExecuteScalar
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        Return cod
    End Function

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub


        Dim codUni As String = ""

        If chkcuenta.Checked Then
            frmViewer_2.LIMPIAR()
            If chkUnidadNegocio.Checked Then
                codUni = OBTENER_COD_UNIDAD(cboUnidadNegocio.Text)
            End If

            Try

                Dim cmd As New SqlCommand("REPORTE_ESTADISTICA_UNIDAD_NEGOCIO_CC", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año.Text
                cmd.Parameters.Add("@MES_INI", SqlDbType.Char).Value = "01"
                cmd.Parameters.Add("@MES_FIN", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                cmd.Parameters.Add("@COD_UN", SqlDbType.Char).Value = codUni
                con.Open()
                cmd.CommandTimeout = 720
                Dim dr As SqlDataReader = cmd.ExecuteReader



                While dr.Read
                    frmViewer_2.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr(10), dr(11), _
                     dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), dr(19), dr(20), dr(21), dr(22), _
                     IIf(dr(8) = "1", dr(11), dr(11) * -1), IIf(dr(8) = "1", dr(12), dr(12) * -1), _
                     IIf(dr(8) = "1", dr(13), dr(13) * -1), IIf(dr(8) = "1", dr(14), dr(14) * -1), IIf(dr(8) = "1", dr(15), dr(15) * -1), IIf(dr(8) = "1", dr(16), dr(16) * -1), _
                     IIf(dr(8) = "1", dr(17), dr(17) * -1), IIf(dr(8) = "1", dr(18), dr(18) * -1), IIf(dr(8) = "1", dr(19), dr(19) * -1), IIf(dr(8) = "1", dr(20), dr(20) * -1), _
                     IIf(dr(8) = "1", dr(21), dr(21) * -1), IIf(dr(8) = "1", dr(22), dr(22) * -1))
                End While
                dr.Close()

            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}{1}", vbCrLf, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

                con.Close()
            End Try

            frmViewer_2.CREAR_REPORTE(cbo_mes.Text, cbo_año.Text)
            frmViewer_2.ShowDialog()
        Else
            frmViewer_1.LIMPIAR()
            If chkUnidadNegocio.Checked Then
                codUni = OBTENER_COD_UNIDAD(cboUnidadNegocio.Text)
            End If

            Try

                Dim cmd As New SqlCommand("REPORTE_ESTADISTICA_UNIDAD_NEGOCIO", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año.Text
                cmd.Parameters.Add("@MES_INI", SqlDbType.Char).Value = "01"
                cmd.Parameters.Add("@MES_FIN", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                cmd.Parameters.Add("@COD_UN", SqlDbType.Char).Value = codUni
                con.Open()
                cmd.CommandTimeout = 720
                Dim dr As SqlDataReader = cmd.ExecuteReader


                While dr.Read
                    frmViewer_1.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr(10), dr(11), _
                     dr(12), dr(13), dr(14), dr(15), dr(16), dr(17), dr(18), _
                     IIf(dr(2) = "1", dr(7), dr(7) * -1), IIf(dr(2) = "1", dr(8), dr(8) * -1), IIf(dr(2) = "1", dr(9), dr(9) * -1), _
                     IIf(dr(2) = "1", dr(10), dr(10) * -1), IIf(dr(2) = "1", dr(11), dr(11) * -1), IIf(dr(2) = "1", dr(12), dr(12) * -1), IIf(dr(2) = "1", dr(13), dr(13) * -1), _
                     IIf(dr(2) = "1", dr(14), dr(14) * -1), IIf(dr(2) = "1", dr(15), dr(15) * -1), IIf(dr(2) = "1", dr(16), dr(16) * -1), IIf(dr(2) = "1", dr(17), dr(17) * -1), _
                     IIf(dr(2) = "1", dr(18), dr(18) * -1))
                End While

                dr.Close()
            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}{1}", vbCrLf, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

                con.Close()
            End Try

            frmViewer_1.CREAR_REPORTE(cbo_mes.Text, cbo_año.Text)
            frmViewer_1.ShowDialog()
        End If

     
    End Sub

    Private Sub FrmEstadisticaUN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarAño()
        CargarUnidadNegocio()
        cboUnidadNegocio.SelectedIndex = 0


    End Sub

    Private Sub btn_cancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        Close()
    End Sub

    Private Sub chkUnidadNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUnidadNegocio.CheckedChanged
        cboUnidadNegocio.Enabled = chkUnidadNegocio.Checked
    End Sub
End Class