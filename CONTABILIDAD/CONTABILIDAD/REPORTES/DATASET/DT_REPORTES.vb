Partial Public Class DT_REPORTES

End Class
Namespace DT_REPORTESTableAdapters
    Partial Public Class REPORTE_CXC_PTES2TableAdapter
        Public WriteOnly Property CommandTimeout()
            Set(ByVal value)
                Dim i As Integer = 0
                While (i < Me.CommandCollection.Length)
                    If Me.CommandCollection(i) IsNot Nothing Then
                        Me.CommandCollection(i).CommandTimeout = value
                    End If
                    i += 1
                End While
            End Set
        End Property
    End Class
End Namespace
