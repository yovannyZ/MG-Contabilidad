Partial Class DT_VARIOS
    
End Class
Namespace DT_VARIOSTableAdapters
    Partial Public Class REPORTE_CXC_PTES1TableAdapter
        Public WriteOnly Property CommandTimeout() As Integer
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

    Partial Public Class REPORTE_CXP_PTES1TableAdapter
        Public WriteOnly Property CommandTimeout() As Integer
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
