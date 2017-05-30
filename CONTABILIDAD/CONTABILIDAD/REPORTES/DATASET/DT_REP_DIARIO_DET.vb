Partial Class DT_REP_DIARIO_DET
End Class

Namespace DT_REP_DIARIO_DETTableAdapters
    Partial Public Class REPORTE_DIARIO_DETTableAdapter
        Public WriteOnly Property CommandTimeOut() As Integer
            Set(ByVal value As Integer)
                Dim i As Integer = 0
                While (i < Me.CommandCollection.Length)
                    If (Me.CommandCollection(i) IsNot Nothing) Then
                        Me.CommandCollection(i).CommandTimeout = value
                    End If
                    i += 1
                End While
            End Set
        End Property
    End Class
End Namespace
