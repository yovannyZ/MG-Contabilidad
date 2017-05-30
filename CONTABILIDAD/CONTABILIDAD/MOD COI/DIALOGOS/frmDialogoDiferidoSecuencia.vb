Imports System.Data.SqlClient
Public Class frmDialogoDiferidoSecuencia
#Region "Variables"
    Dim fecha As Date
    Public FechaInicioOp As Date
    Public secuencia As Short
#End Region

#Region "Botones"

    Private Sub btnAgregarFechaDiferir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarFechaDiferir.Click

        'Dim Fecha As String = DateSerial(dgvFechaDif.Item(2, dgvFechaDif.RowCount - 1).Value, dgvFechaDif.Item(1, dgvFechaDif.RowCount - 1).Value, "01") 'DateTime.Parse(ultimaFecha)'"01" & "/" & (dgvFechaDif.Item(2, dgvFechaDif.RowCount - 1).Value) & "/" & (dgvFechaDif.Item(1, dgvFechaDif.RowCount - 1).Value)
        Dim ultimaFecha As Date = DateSerial(dgvFechaDif.Item(2, dgvFechaDif.RowCount - 1).Value, dgvFechaDif.Item(1, dgvFechaDif.RowCount - 1).Value, "01") 'DateTime.Parse(ultimaFecha)'Convert.ToDateTime(Fecha).Date
        Dim FechaSecuencia As Date
        For i As Short = 1 To 12
            FechaSecuencia = DateSerial(Year(ultimaFecha), (Month(ultimaFecha) + i) + 0, 1)
            dgvFechaDif.Rows.Add((dgvFechaDif.Item(0, dgvFechaDif.RowCount - 1).Value) + 1, Month(FechaSecuencia).ToString("00"), Year(FechaSecuencia), True)
        Next

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cont As Short
        For i As Short = 0 To dgvFechaDif.RowCount - 1
            If dgvFechaDif.Item(3, i).Value = True Then
                cont += 1
            End If
        Next
        If cont <> secuencia Then MessageBox.Show("El numero de elementos seleccionados no coincide con la secuencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

#End Region

#Region "Métodos"

#End Region

#Region "Funciones"

#End Region

#Region "Eventos"

    Private Sub frmDialogoDiferidoSecuencia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dgvFechaDif.Rows.Clear()
        Dim DiaActual As Date = FechaInicioOp
        'Hacemos el ciclo hasta el ultimo día del año
        Dim i As Short
        For i = 0 To 11
            fecha = DateSerial(Year(DiaActual), (Month(DiaActual) + i) + 0, 1)
            dgvFechaDif.Rows.Add(i + 1, Month(fecha).ToString("00"), Year(fecha), True)
        Next

    End Sub

#End Region


    
End Class