Public Class frmDetraccion
    Public Importe As Double
    Public Cero As Boolean
    Dim Utilitarios As New Class1
    Dim Tasa As Decimal

    Private Sub frmDetraccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub frmDetracciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Cero = False Then
            Tasa = Utilitarios.HACER_DECIMAL(Utilitarios.DIR_TABLA_DESC("POR_D", "TDEFA"))
            txtValorDetraccion.Text = Utilitarios.HACER_DECIMAL(Importe * (Tasa / 100))
            txtPorcentajeDetraccion.Text = Tasa
        End If
        txtNumeroDetraccion.Focus()
    End Sub
    Public Sub Limpiar()
        txtNumeroDetraccion.Clear()
        txtTasaDetraccion.Clear()
        txtValorDetraccion.Clear()
    End Sub

    Private Sub txtValorDetraccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtValorDetraccion.KeyDown
        If e.KeyCode = Keys.Return Then
            txtValorDetraccion.Text = Utilitarios.HACER_DECIMAL(txtValorDetraccion.Text)
        End If
    End Sub

    Private Sub txtPorDetraccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTasaDetraccion.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTasaDetraccion.Text = CInt(txtTasaDetraccion.Text).ToString("00000")
        End If
    End Sub

    Private Sub txtPorcentajeDetraccion_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPorcentajeDetraccion.LostFocus
        txtValorDetraccion.Text = Importe * (CDbl(txtPorcentajeDetraccion.Text) / 100)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtNumeroDetraccion.Text.Trim = "" Or txtPorcentajeDetraccion.Text.Trim = "" Then
            MessageBox.Show("Debe completar el número y tasa de detracción", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub
End Class