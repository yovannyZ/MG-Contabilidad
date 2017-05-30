Imports System.Data.SqlClient
Imports System.IO
Public Class frm0308
    Dim FechaInicio, FechaFin As DateTime
    Dim obj As New Class1
#Region "Constructor"
    Private Shared instancia As New frm0308
    Public Shared Function ObtenerInstancia() As frm0308
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New frm0308
        End If
        instancia.BringToFront()
        Return instancia
    End Function
#End Region

    Private Sub CARGAR_AÑO()
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

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        FechaInicio = New DateTime(cbo_año.Text, obj.COD_MES(cbo_mes.Text), 1)
        FechaFin = FechaInicio.AddMonths(1).AddDays(-1)
        Dim ofbd As New FolderBrowserDialog
        If ofbd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim Archivo As String = String.Format("LE{0}{1}{2}{3}030800011011.txt", RUC_EMPRESA, cbo_año.Text, obj.COD_MES(cbo_mes.Text), FechaFin.Date.Day)
            Using fs As New FileStream(String.Format("{0}\{1}", ofbd.SelectedPath, Archivo), FileMode.Create, FileAccess.Write)
                Using sw As New StreamWriter(fs, System.Text.Encoding.Default)
                End Using
                MessageBox.Show(String.Format("Datos exportados en: {0}", ofbd.SelectedPath), "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If
    End Sub

    Private Sub frm0307_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CARGAR_AÑO()
    End Sub
End Class