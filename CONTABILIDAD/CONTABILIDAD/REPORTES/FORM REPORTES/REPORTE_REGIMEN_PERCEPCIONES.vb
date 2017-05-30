Imports System.Data.SqlClient
Public Class REPORTE_REGIMEN_PERCEPCIONES
    Dim OBJ As New Class1
    Dim REP As New REP_REGIMENT_PERCEPCIONES
#Region "Constructor"
    Private Shared instancia As REPORTE_REGIMEN_PERCEPCIONES

    Public Shared Function ObtenerInstancia() As REPORTE_REGIMEN_PERCEPCIONES
        If instancia Is Nothing OrElse instancia.IsDisposed Then
            instancia = New REPORTE_REGIMEN_PERCEPCIONES
        End If
        instancia.BringToFront()
        Return instancia
    End Function

    Private Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#End Region
    Private Sub REPORTE_REGIMEN_RET_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Return) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub REPORTE_REGIMEN_RET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KeyPreview = True
        CARGAR_AÑO()
        cbo_año.Text = AÑO
        cbo_mes.Focus()
    End Sub
    Sub CARGAR_AÑO()
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

        Try
            con.Open()
            Dim cmd As New SqlCommand("ACTUALIZAR_PERCEPCIONES_BASE_INI", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO1", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES1", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("ACTUALIZAR_PENDIENTE_PERCEPCIONES", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FE_AÑO1", SqlDbType.Char).Value = cbo_año.Text
            cmd.Parameters.Add("@FE_MES1", SqlDbType.Char).Value = OBJ.COD_MES(cbo_mes.Text)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(String.Format("Error al actualizar.{0}{1}", vbCrLf, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try

        REP.CREAR_REPORTE(cbo_año.Text, OBJ.COD_MES(cbo_mes.Text), cbo_mes.Text)
        REP.ShowDialog()
    End Sub
    Private Sub btn_cancelar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar1.Click
        main(147) = 0
        Me.Close()
    End Sub
End Class