Public Class frmTexto

    Public Sub New(ByVal titulo As String, ByVal descripcion As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        tsslTitulo.Text = titulo
        tsslDescripcion.Text = descripcion
    End Sub

    Private Sub BuscarCoincidencia(ByVal textoBuscado As String)
        Dim Resultados As MatchCollection
        Dim Palabra As Match
        Try
            ' PAsar el pattern e indicar que ignore las mayúsculas y minúsculas al mosmento de buscar  
            Dim obj_Expresion As New Regex(textoBuscado.ToString, RegexOptions.IgnoreCase)

            ' Ejecutar el método Matches para buscar la cadena en el texto del control  
            ' y retornar un MatchCollection con los resultados  
            Resultados = obj_Expresion.Matches(rtbTexto.Text)
            ' quitar el coloreado anterior  
            With rtbTexto
                .SelectAll()
                .SelectionColor = Color.Black
                .SelectionBackColor = Color.White
            End With
            ' Si se encontraron coincidencias recorre las colección    
            For Each Palabra In Resultados
                With rtbTexto
                    .SelectionStart = Palabra.Index ' comienzo de la selección  
                    .SelectionLength = Palabra.Length ' longitud de la cadena a seleccionar  
                    .SelectionColor = Color.Blue ' color de la selección  
                    .SelectionBackColor = Color.Yellow
                    .ScrollToCaret()
                End With
            Next Palabra
        Catch ex As Exception
            MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBuscar.TextChanged
        If Not String.IsNullOrEmpty(txtBuscar.Text) Then
            BuscarCoincidencia(txtBuscar.Text)
        Else
            With rtbTexto
                .SelectAll()
                .SelectionColor = Color.Black
                .SelectionBackColor = Color.White
            End With
        End If
    End Sub
End Class