Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Module Module01
    Dim a As String = Application.StartupPath
    'Dim sr As StreamReader = New StreamReader((a & "\servidor\servidor_ini.txt"), Encoding.Default, True)
    Public ALEATORIO As String
    Public AÑO As String
    Public COD_EMPRESA As String
    Public DESC_EMPRESA As String
    Public DESC_CORTA_EMPRESA As String
    Public RUC_EMPRESA As String
    Public DIR_EMPRESA As String
    Public FONO_EMPRESA As String
    Public EMAIL_EMPRESA As String
    Public WEB_EMPRESA As String
    Public COD_MOD As String
    Public COD_USU As String
    Public DireccionEmpresa() As String
    'Public nombre_servidor As String = sr.ReadToEnd
    Public nombre_servidor As String = My.Settings.SERVIDOR
    Public con As New SqlConnection("data source=" & nombre_servidor & ";initial catalog=BD_COI01;uid=miguel;pwd=main;")
    Public con2 As New SqlConnection("data source=" & nombre_servidor & ";initial catalog=BD_General_Coi;uid=miguel;pwd=main;")
    Public DESC_USU As String
    Public DIA As String
    Public FECHA_GRAL As DateTime
    Public FECHA_INI As DateTime
    Public main(160) As Integer
    Public MES As String
    Public NICK As String
    Public NOMBRE_PC As String = Environment.MachineName
    Public TIPO_USU As String
End Module
