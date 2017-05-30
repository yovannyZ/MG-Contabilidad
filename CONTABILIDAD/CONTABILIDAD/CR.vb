Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows

Public Class CR
    Private Shared loginfo As CrystalDecisions.Shared.ConnectionInfo
    Public Shared exportar_mail As Boolean
    Public Shared rutaRpt As String
    Public Shared stillOpen As Boolean
    Public Shared custTitle As String
    Private Shared rpt As New ReportDocument

    Public Shared Sub conectar(ByVal servidor As String, ByVal basedatos As String, ByVal usuario As String, ByVal password As String)
        Try
            loginfo = New CrystalDecisions.Shared.ConnectionInfo
            loginfo.ServerName = servidor
            loginfo.DatabaseName = basedatos
            loginfo.UserID = usuario
            loginfo.Password = password
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub

    Private Shared Function genpar(ByVal ParamArray matriz() As String) As ParameterFields
        Try
            Dim c As Long, p1, p2 As String, l As Integer
            Dim parametros As New ParameterFields
            For c = 0 To matriz.Length - 1
                l = InStr(matriz(c), ";")
                If l > 0 Then
                    p1 = Mid(matriz(c), 1, l - 1)
                    p2 = Mid(matriz(c), l + 1, Len(matriz(c)) - l)
                    Dim parametro As New ParameterField
                    Dim dVal As New ParameterDiscreteValue
                    parametro.ParameterFieldName = p1
                    dVal.Value = p2
                    parametro.CurrentValues.Add(dVal)
                    parametros.Add(parametro)
                End If
            Next
            Return (parametros)
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Private Shared Function logonrpt(ByRef reporte As ReportDocument)
        Try
            Dim crtableLogoninfos As New TableLogOnInfos
            Dim crtableLogoninfo As New TableLogOnInfo
            Dim crConnectionInfo As New ConnectionInfo
            Dim CrTables As Tables
            Dim CrTable As Table
            crConnectionInfo = loginfo
            CrTables = reporte.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
                CrTable.Location = loginfo.DatabaseName & ".dbo." & CrTable.Name
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Function

    Public Overloads Shared Sub printrpt(ByVal nombrereporte As String, ByVal ParamArray par() As String)
        Try
            Dim forma As New FrmReporte
            With forma.CrystalReportViewer1
                If par.Length > 0 Then
                    .ParameterFieldInfo = genpar(par)
                End If
                If rutaRpt.Trim.Length = 0 Then
                    rpt.Load(nombrereporte, OpenReportMethod.OpenReportByDefault)
                ElseIf Mid(rutaRpt.Trim, rutaRpt.Trim.Length, 1) = "\" Then
                    rpt.Load(rutaRpt & nombrereporte, OpenReportMethod.OpenReportByDefault)
                Else
                    rpt.Load(rutaRpt & "\" & nombrereporte, OpenReportMethod.OpenReportByDefault)
                End If
                logonrpt(rpt)
                'Configurar aquí cualquier opción de exportación 
                Dim opt As New ExportOptions
                opt = rpt.ExportOptions
                'Configurar aquí cualquier opción de impresión 
                Dim prn As PrintOptions
                prn = rpt.PrintOptions
                .ReportSource = rpt
                'Visualizar el reporte en una ventana nueva 
                forma.Text = custTitle
                forma.Show()
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message, ex.InnerException)
        End Try
    End Sub
End Class
