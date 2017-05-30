Imports System.Data.SqlClient
Public Class ReporteUnidadNegocioConcepto
    Dim OBJ As New Class1
    Dim frmViewerConcepto As New FrmUnidadNConceptoViewer
    Dim frmViewerConceptoCuenta As New FrmUnidadNCuenta
    Private listaUnidades As New List(Of UnidadEconomica)
    Private Shared _instancia As ReporteUnidadNegocioConcepto

    Public Shared Function ObtenerInstancia() As ReporteUnidadNegocioConcepto
        If _instancia Is Nothing OrElse _instancia.IsDisposed Then
            _instancia = New ReporteUnidadNegocioConcepto
        End If
        _instancia.BringToFront()
        Return _instancia
    End Function

    Private Structure UnidadEconomica
        Public CodUN As String
        Public DescUN As String
    End Structure

    Private Sub ListarUnidadesNegocio()
        Try
            Dim cmd As New SqlCommand("LISTAR_UNIDAD_NEGOCIO", con)
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader

            While dr.Read
                Dim obj As New UnidadEconomica
                obj.CodUN = dr(0)
                obj.DescUN = dr(1)
                listaUnidades.Add(obj)
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim cmd As New SqlCommand("REPORTE_UNIDAD_NEGOCIO", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader


            For i As Integer = 0 To listaUnidades.Count - 1
                With listaUnidades.Item(i)
                    While dr.Read
                        If .CodUN = dr(6) Then

                        End If
                    End While
                End With
            Next


            con.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReporteUnidadNegocioConcepto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarAño()
    End Sub

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

    Private Sub btn_pantalla1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pantalla1.Click
        If cbo_año.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Año", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_año.Focus() : Exit Sub
        If cbo_mes.SelectedIndex = -1 Then MessageBox.Show("Debe elegir el Mes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : cbo_mes.Focus() : Exit Sub



        Dim query As String
        Dim opcion As String

        If chkPorCuenta.Checked Then
            CargarUnidadesNegocio2()
            frmViewerConceptoCuenta.LIMPIAR()
            If chkAlMes.Checked Then
                query = "REPORTE_UNIDAD_NEGOCIO_CC_AL_MES"
                opcion = "AL MES DE "
            Else
                query = "REPORTE_UNIDAD_NEGOCIO_CC_DEL_MES"
                opcion = "DEL MES DE "
            End If



            Try

                Dim cmd As New SqlCommand(query, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año.Text

                If chkAlMes.Checked Then
                    cmd.Parameters.Add("@MES_INI", SqlDbType.Char).Value = "01"
                    cmd.Parameters.Add("@MES_FIN", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                Else
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                End If
                cmd.CommandTimeout = 720
                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Dim columnas As Integer = dr.FieldCount - 9

                Select Case columnas
                    Case 1
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 2
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                             IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                             0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 3
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                             IIf(dr(6) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 4
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), _
                            IIf(IsDBNull(dr(12)), 0.0, dr(12)), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                             IIf(dr(6) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 5
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), _
                            IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(13)), 0.0, dr(13)), 0.0, 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(13)), 0.0, dr(13)) * -1), 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 6
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), _
                            IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(14)), 0.0, dr(14)), 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(13)), 0.0, dr(13)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(14)), 0.0, dr(14)) * -1), 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 7
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), _
                            IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(15)), 0.0, dr(15)), 0.0, 0.0, 0.0, _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(13)), 0.0, dr(13)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(14)), 0.0, dr(14)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(15)), 0.0, dr(15)), IIf(IsDBNull(dr(15)), 0.0, dr(15)) * -1), 0.0, 0.0, 0.0)
                        End While
                    Case 8
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), _
                            IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(15)), 0.0, dr(15)), IIf(IsDBNull(dr(16)), 0.0, dr(16)), 0.0, 0.0, _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "I1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(13)), 0.0, dr(13)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(14)), 0.0, dr(14)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(15)), 0.0, dr(15)), IIf(IsDBNull(dr(15)), 0.0, dr(15)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(16)), 0.0, dr(16)), IIf(IsDBNull(dr(16)), 0.0, dr(16)) * -1), 0.0, 0.0)
                        End While
                    Case 9
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), _
                            IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(15)), 0.0, dr(15)), IIf(IsDBNull(dr(16)), 0.0, dr(16)), _
                            IIf(IsDBNull(dr(17)), 0.0, dr(17)), 0.0, _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(13)), 0.0, dr(13)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(14)), 0.0, dr(14)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(15)), 0.0, dr(15)), IIf(IsDBNull(dr(15)), 0.0, dr(15)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(16)), 0.0, dr(16)), IIf(IsDBNull(dr(16)), 0.0, dr(16)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(17)), 0.0, dr(17)), IIf(IsDBNull(dr(17)), 0.0, dr(17)) * -1), 0.0)
                        End While
                    Case 10
                        While dr.Read
                            frmViewerConceptoCuenta.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), _
                            IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(15)), 0.0, dr(15)), IIf(IsDBNull(dr(16)), 0.0, dr(16)), _
                            IIf(IsDBNull(dr(17)), 0.0, dr(17)), IIf(IsDBNull(dr(18)), 0.0, dr(18)), _
                           IIf(dr(6) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(13)), 0.0, dr(13)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(14)), 0.0, dr(14)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(15)), 0.0, dr(15)), IIf(IsDBNull(dr(15)), 0.0, dr(15)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(16)), 0.0, dr(16)), IIf(IsDBNull(dr(16)), 0.0, dr(16)) * -1), _
                            IIf(dr(6) = "1", IIf(IsDBNull(dr(17)), 0.0, dr(17)), IIf(IsDBNull(dr(17)), 0.0, dr(17)) * -1), IIf(dr(6) = "1", IIf(IsDBNull(dr(18)), 0.0, dr(18)), IIf(IsDBNull(dr(18)), 0.0, dr(18)) * -1))
                        End While
                End Select

                dr.Close()

            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}{1}", vbCrLf, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

                con.Close()
            End Try

            frmViewerConceptoCuenta.CREAR_REPORTE(cbo_mes.Text, opcion, cbo_año.Text)
            frmViewerConceptoCuenta.ShowDialog()
        Else
            CargarUnidadesNegocio1()
            frmViewerConcepto.LIMPIAR()
            If chkAlMes.Checked Then
                query = "REPORTE_UNIDAD_NEGOCIO_AL_MES"
                opcion = "AL MES DE "
            Else
                query = "REPORTE_UNIDAD_NEGOCIO_DEL_MES"
                opcion = "DEL MES DE "
            End If

            Try

                Dim cmd As New SqlCommand(query, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = cbo_año.Text
                cmd.CommandTimeout = 720

                If chkAlMes.Checked Then
                    cmd.Parameters.Add("@MES_INI", SqlDbType.Char).Value = "01"
                    cmd.Parameters.Add("@MES_FIN", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                Else
                    cmd.Parameters.Add("@FE_MES", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
                End If

                con.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Dim columnas As Integer = dr.FieldCount - 5

                Select Case columnas
                    Case 1
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(3)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 2
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                             IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                             0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 3
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(7)), 0.0, dr(7)), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                             IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                             IIf(dr(2) = "1", IIf(IsDBNull(dr(7)), 0.0, dr(7)), IIf(IsDBNull(dr(7)), 0.0, dr(7)) * -1), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 4
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(7)), 0.0, dr(7)), _
                            IIf(IsDBNull(dr(8)), 0.0, dr(8)), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(7)), 0.0, dr(7)), IIf(IsDBNull(dr(7)), 0.0, dr(7)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(8)), 0.0, dr(8)) * -1), 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 5
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(7)), 0.0, dr(7)), _
                            IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(9)), 0.0, dr(9)), 0.0, 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(7)), 0.0, dr(7)), IIf(IsDBNull(dr(7)), 0.0, dr(7)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(8)), 0.0, dr(8)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), 0.0, 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 6
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(7)), 0.0, dr(7)), _
                            IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), 0.0, 0.0, 0.0, 0.0, _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(7)), 0.0, dr(7)), IIf(IsDBNull(dr(7)), 0.0, dr(7)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(8)), 0.0, dr(8)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), 0.0, 0.0, 0.0, 0.0)
                        End While
                    Case 7
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(7)), 0.0, dr(7)), _
                            IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), 0.0, 0.0, 0.0, _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(7)), 0.0, dr(7)), IIf(IsDBNull(dr(7)), 0.0, dr(7)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(8)), 0.0, dr(8)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), 0.0, 0.0, 0.0)
                        End While
                    Case 8
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(7)), 0.0, dr(7)), _
                            IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(12)), 0.0, dr(12)), 0.0, 0.0, _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(7)), 0.0, dr(7)), IIf(IsDBNull(dr(7)), 0.0, dr(7)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(8)), 0.0, dr(8)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), 0.0, 0.0)
                        End While
                    Case 9
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(7)), 0.0, dr(7)), _
                            IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(12)), 0.0, dr(12)), _
                            IIf(IsDBNull(dr(13)), 0.0, dr(13)), 0.0, _
                             IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(7)), 0.0, dr(7)), IIf(IsDBNull(dr(7)), 0.0, dr(7)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(8)), 0.0, dr(8)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(13)), 0.0, dr(13)) * -1), 0.0)
                        End While
                    Case 10
                        While dr.Read
                            frmViewerConcepto.llenar_dt(dr(0), dr(1), dr(2), dr(3), dr(4), IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(7)), 0.0, dr(7)), _
                            IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(12)), 0.0, dr(12)), _
                            IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(14)), 0.0, dr(14)), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(5)), 0.0, dr(5)), IIf(IsDBNull(dr(5)), 0.0, dr(5)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(6)), 0.0, dr(6)), IIf(IsDBNull(dr(6)), 0.0, dr(6)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(7)), 0.0, dr(7)), IIf(IsDBNull(dr(7)), 0.0, dr(7)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(8)), 0.0, dr(8)), IIf(IsDBNull(dr(8)), 0.0, dr(8)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(9)), 0.0, dr(9)), IIf(IsDBNull(dr(9)), 0.0, dr(9)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(10)), 0.0, dr(10)), IIf(IsDBNull(dr(10)), 0.0, dr(10)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(11)), 0.0, dr(11)), IIf(IsDBNull(dr(11)), 0.0, dr(11)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(12)), 0.0, dr(12)), IIf(IsDBNull(dr(12)), 0.0, dr(12)) * -1), _
                            IIf(dr(2) = "1", IIf(IsDBNull(dr(13)), 0.0, dr(13)), IIf(IsDBNull(dr(13)), 0.0, dr(13)) * -1), IIf(dr(2) = "1", IIf(IsDBNull(dr(14)), 0.0, dr(14)), IIf(IsDBNull(dr(14)), 0.0, dr(14)) * -1))
                        End While
                End Select

                dr.Close()


            Catch ex As Exception
                MessageBox.Show(String.Format("Error: {0}{1}", vbCrLf, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

                con.Close()
            End Try

            frmViewerConcepto.CREAR_REPORTE(DESC_EMPRESA, cbo_mes.Text, opcion, cbo_año.Text)
            frmViewerConcepto.ShowDialog()
        End If


    End Sub

    Private Sub btn_cancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        Close()
    End Sub

    Private Sub CargarUnidadesNegocio1()
        frmViewerConcepto.DsUnidadNegocioConcepto.DtUnidadNegocio.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("LISTAR_UNIDAD_NEGOCIO", con)
            cmd.CommandType = CommandType.StoredProcedure
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                frmViewerConcepto.DsUnidadNegocioConcepto.DtUnidadNegocio.Rows.Add(dr(0), dr(2))
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub

    Private Sub CargarUnidadesNegocio2()
        frmViewerConceptoCuenta.DsUnidadNegocioConcepto.DtUnidadNegocio.Rows.Clear()
        Try
            Dim cmd As New SqlCommand("LISTAR_UNIDAD_NEGOCIO", con)
            cmd.CommandType = CommandType.StoredProcedure
            con.Open()
            Dim dr As SqlDataReader = cmd.ExecuteReader
            While dr.Read
                frmViewerConceptoCuenta.DsUnidadNegocioConcepto.DtUnidadNegocio.Rows.Add(dr(0), dr(2))
            End While
            con.Close()
        Catch ex As Exception
            con.Close()
        End Try
    End Sub
End Class