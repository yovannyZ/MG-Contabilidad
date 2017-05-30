Imports System.Data.Sql

Public Class frmNoEmitidas
#Region "Variables"
    Public CodigoPersona As String = String.Empty
    Public Moneda As String = String.Empty
#End Region

#Region "Metodos y Procedimientos"
    Private Sub CargarGrilla()
        Try
            Dim cmd As New SqlCommand("DOCUMENTOS_NO_EMITIDOS", con)
            cmd.CommandType = CommandType.StoredProcedure
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvNoEmitidas.DataSource = dt
            'dgvNoEmitidas.ColumnHeadersDefaultCellStyle.Font = New Font("arial", 8.0!, FontStyle.Regular)
            dgvNoEmitidas.Columns.Item(0).Width = 30
            dgvNoEmitidas.Columns.Item(0).Frozen = True
            dgvNoEmitidas.Columns.Item(1).Width = 60
            dgvNoEmitidas.Columns.Item(5).Width = 50
            dgvNoEmitidas.Columns.Item(3).Visible = False
            dgvNoEmitidas.Columns.Item(6).Visible = False
            dgvNoEmitidas.Columns.Item(7).Visible = False
            dgvNoEmitidas.Columns.Item(9).Visible = False
            dgvNoEmitidas.Columns.Item(10).Visible = False
            dgvNoEmitidas.Columns.Item(11).Visible = False
            dgvNoEmitidas.Columns.Item(12).Visible = False
            dgvNoEmitidas.Columns.Item(13).Visible = False
            dgvNoEmitidas.Columns.Item(14).Visible = False
            dgvNoEmitidas.Columns.Item(15).Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BloquearRegistros()
        Dim filas As Integer = dgvNoEmitidas.RowCount
        Dim indice As Integer = 0
        While indice < filas
            If (dgvNoEmitidas.Item(5, indice).Value <> CodigoPersona OrElse dgvNoEmitidas.Item(7, indice).Value <> Moneda) Then
                dgvNoEmitidas.Rows(indice).ReadOnly = True
                dgvNoEmitidas.Rows(indice).DefaultCellStyle.BackColor = Color.Gray
                dgvNoEmitidas.Rows(indice).DefaultCellStyle.ForeColor = Color.White
            End If
            indice += 1
        End While
    End Sub
#End Region

#Region "Eventos"
    Private Sub frmNoEmitidas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarGrilla()
        BloquearRegistros()
    End Sub
#End Region
End Class