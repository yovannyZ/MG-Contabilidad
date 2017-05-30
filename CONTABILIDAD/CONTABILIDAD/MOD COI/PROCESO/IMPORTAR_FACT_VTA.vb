Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text
Imports System.Xml
Imports System.Threading
Imports System.IO

Public Class IMPORTAR_FACT_VTA

    Private oXML As New XmlDocument
    Private Nodo As XmlNode
    Private Archivo As String = String.Format("{0}/servidor/Empresas.xml", Application.StartupPath)

    Private COD_AUX As String : Private COD_CLASE As String
    Private COD_COMP As String : Private COD_DH_DOC As String
    Private COD_DOC As String : Private COD_MONEDA As String
    Private COD_PER As String : Private COD_SUC As Integer
    Private NRO_COMP As String : Private COD_CC As String
    Private CON_GCO As New SqlConnection
    Private CUENTA_IGV As String : Private CUENTA_TOTAL As String
    Private CUENTA_EXO As String : Private CUENTA_BASE As String
    Private DESC_PER As String : Private DOC_PER As String
    Private DT_DET As New DataTable : Private DT_DOC As New DataTable
    Private FECHA_DOC As DateTime : Private FECHA_VEN As DateTime
    Private fila1 As Integer : Private fila2 As Integer
    Private IGV0 As Decimal : Private IMP_BASE As Decimal
    Private IMP_EXO As Decimal : Private IMP_IGV As Decimal
    Private IMP_TOTAL As Decimal : Private NRO_DOC As String
    Private OBJ As New Class1
    Private ORDEN_BASE, ORDEN_EXONERADO As String
    Private ORDEN_IGV, ORDEN_TOTAL As String

    Private SB As New StringBuilder

    Dim ImpD_Base As Decimal = 0 : Dim ImpS_Base As Decimal = 0
    Dim ImpD_Exo As Decimal = 0 : Dim ImpS_Exo As Decimal = 0
    Dim ImpD_Igv As Decimal = 0 : Dim ImpS_Igv As Decimal = 0
    Dim ImpD_Total As Decimal = 0 : Dim ImpS_Total As Decimal = 0

    Private TCAMBIO As Decimal : Private TIPO_DET As String
    Private STATUS_ANUL As String : Private Grabo As Boolean
    Private dst As New DataSet
    Private trans As SqlTransaction

    Delegate Function TraerDatos() As DataSet
    Delegate Function GrabarDatos() As Boolean
    Private oDelegado As New TraerDatos(AddressOf CargarDatos)
    Private oDelegadoGrabar As New GrabarDatos(AddressOf Grabar)

    Private Sub Formato()
        DG.Columns(0).Width = 30 : DG.Columns(1).Width = 80
        DG.Columns(2).Width = 70 : DG.Columns(3).Visible = False
        DG.Columns(4).Width = 40 : DG.Columns(5).Width = 180
        DG.Columns(6).Width = 150 : DG.Columns(7).Width = 80
        DG.Columns(8).Width = 20 : DG.Columns(9).Width = 30
        DG.Columns(10).Width = 40 : DG.Columns(11).Width = 50
        DG.Columns(12).Width = 40 : DG.Columns(13).Width = 60
        DG.Columns(14).Width = 60 : DG.Columns(15).Width = 60
        DG.Columns(16).Width = 50 : DG.Columns(17).Width = 60
        DG.Columns(18).Width = 50 : DG.Columns(19).Width = 60
        DG.Columns(20).Width = 80 : DG.Columns(21).Width = 70
        : DG.Columns(22).Width = 50
    End Sub

    Private Sub ActivaControl(ByVal Estado As Boolean)
        gbBusca.Enabled = Estado
        gbBuscaDoc.Enabled = Estado
        gbGenerar.Enabled = Estado
    End Sub

    Function HALLAR_NRO_COMP(ByVal COD_AUX0 As Object, ByVal COD_COMP0 As Object, ByVal AÑO0 As Object, ByVal MES0 As Object) As String
        Dim NUM As String = ""
        Try
            Dim pro03 As New SqlCommand("HALLAR_NRO_COMP", con, trans)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO0
            pro03.Parameters.Add("@MES", SqlDbType.VarChar).Value = MES0
            pro03.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX0
            pro03.Parameters.Add("@COD_COMP", SqlDbType.VarChar).Value = COD_COMP0
            'pro03.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = pro03.ExecuteReader
            If (Rs3.HasRows = False) Then
                NUM = ""
            Else
                Do While Rs3.Read
                    NUM = (Rs3.GetValue(0))
                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return NUM
    End Function

    Function DIR_TABLA_DESC(ByVal COD As Object, ByVal TABLA_COD As Object) As String
        Dim DESC As String = ""
        Try
            Dim CMD As New SqlCommand("DESC_TABLA_DIR", con, trans)
            CMD.CommandType = CommandType.StoredProcedure
            CMD.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = (COD)
            CMD.Parameters.Add("@TABLA_COD", SqlDbType.VarChar).Value = (TABLA_COD)
            DESC = CMD.ExecuteScalar
        Catch ex As Exception

            con.Close()
            MsgBox(ex.Message)

        End Try
        If (DESC = "") Then
            DESC = " "
        End If
        Return DESC
    End Function

    Private Sub GRABAR_PCTAS_COBRAR()
        '******************************************************************************
        'GRABAR PCTAS_COBRAR
        '******************************************************************************
        SB.Remove(0, SB.Length)
        SB.AppendLine("INSERT INTO PCTAS_COBRAR (COD_SUCURSAL,COD_PER,COD_DOC,NRO_DOC,")
        SB.AppendLine("NRO_DOC_PER,FECHA_DOC,FECHA_VEN,IMP_INI,IMP_DOC,COD_MONEDA,TIPO_CAMBIO,")
        SB.AppendLine("COD_D_H,COD_SIT,COD_EST,COD_UBI,OBSERVACION,COD_REF,NRO_REF,FECHA_REF,COD_CUENTA,")
        SB.AppendLine("FE_AÑO,FE_MES,COD_BANCO,COD_USU)")
        SB.AppendLine("VALUES(@COD_SUCURSAL,@COD_PER,@COD_DOC,@NRO_DOC,@NRO_DOC_PER,@FECHA_DOC,")
        SB.AppendLine("@FECHA_VEN,@IMP_INI,@IMP_DOC,@COD_MONEDA,@TIPO_CAMBIO,@COD_D_H,@COD_SIT,@COD_EST,")
        SB.AppendLine("@COD_UBI,@OBSERVACION,@COD_REF,@NRO_REF,@FECHA_REF,@COD_CUENTA,@FE_AÑO,@FE_MES,@COD_BANCO,@COD_USU)")

        Dim CMD As New SqlCommand

        CMD = New SqlCommand(SB.ToString, con, trans)
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = "01"
        CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
        CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = COD_DOC
        CMD.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC
        CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = DOC_PER
        CMD.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = FECHA_VEN
        CMD.Parameters.Add("@IMP_INI", SqlDbType.Char).Value = IMP_TOTAL
        CMD.Parameters.Add("@IMP_DOC", SqlDbType.Char).Value = IMP_TOTAL
        CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = COD_MONEDA
        CMD.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Char).Value = TCAMBIO
        CMD.Parameters.Add("@COD_D_H", SqlDbType.Char).Value = COD_DH_DOC
        CMD.Parameters.Add("@COD_SIT", SqlDbType.Char).Value = "NOR"
        CMD.Parameters.Add("@COD_EST", SqlDbType.Char).Value = "ACT"
        CMD.Parameters.Add("@COD_UBI", SqlDbType.Char).Value = "CAR"
        CMD.Parameters.Add("@OBSERVACION", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@COD_REF", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_REF", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@FECHA_REF", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = CUENTA_TOTAL
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU

        CMD.ExecuteNonQuery()
    End Sub

    Private Sub GRABAR_TCTAS_COBRAR()
        '******************************************************************************
        'GRABAR TCTAS_COBRAR
        '******************************************************************************
        SB.Remove(0, SB.Length)
        SB.AppendLine("INSERT INTO TCTAS_COBRAR (COD_AUX,COD_COMP,NRO_COMP,COD_SUCURSAL,")
        SB.AppendLine("COD_PER,COD_DOC,NRO_DOC,NRO_DOC_PER,FECHA_DOC,FECHA_VEN,IMP_DOC,")
        SB.AppendLine("COD_MONEDA,TIPO_CAMBIO,COD_D_H,COD_SIT,COD_EST,COD_UBI,OBSERVACION,")
        SB.AppendLine("COD_REF,NRO_REF,FECHA_REF,COD_CUENTA,FE_AÑO,FE_MES,COD_BANCO,COD_MP,")
        SB.AppendLine("COD_BANCO_DEST,TIPO_TRANS,STATUS_TRANS,COD_USU,TIPO_OPE,NRO_MP,NRO)")
        SB.AppendLine("VALUES(@COD_AUX,@COD_COMP,@NRO_COMP,@COD_SUCURSAL,@COD_PER,@COD_DOC,")
        SB.AppendLine("@NRO_DOC,@NRO_DOC_PER,@FECHA_DOC,@FECHA_VEN,@IMP_DOC,@COD_MONEDA,")
        SB.AppendLine("@TIPO_CAMBIO,@COD_D_H,@COD_SIT,@COD_EST,@COD_UBI,@OBSERVACION,@COD_REF,")
        SB.AppendLine("@NRO_REF,@FECHA_REF,@COD_CUENTA,@FE_AÑO,@FE_MES,@COD_BANCO,@COD_MP,")
        SB.AppendLine("@COD_BANCO_DEST,@TIPO_TRANS,@STATUS_TRANS,@COD_USU,@TIPO_OPE,@NRO_MP,@NRO)")

        Dim CMD As New SqlCommand

        CMD = New SqlCommand(SB.ToString, con, trans)
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
        CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
        CMD.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = NRO_COMP
        CMD.Parameters.Add("@COD_SUCURSAL", SqlDbType.Char).Value = "01"
        CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
        CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = COD_DOC
        CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
        CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.VarChar).Value = DOC_PER
        CMD.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = FECHA_VEN
        CMD.Parameters.Add("@IMP_DOC", SqlDbType.Char).Value = IMP_TOTAL
        CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = COD_MONEDA
        CMD.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TCAMBIO
        CMD.Parameters.Add("@COD_D_H", SqlDbType.Char).Value = COD_DH_DOC
        CMD.Parameters.Add("@COD_SIT", SqlDbType.Char).Value = "NOR"
        CMD.Parameters.Add("@COD_EST", SqlDbType.Char).Value = "ACT"
        CMD.Parameters.Add("@COD_UBI", SqlDbType.Char).Value = "CAR"
        CMD.Parameters.Add("@OBSERVACION", SqlDbType.Char).Value = DESC_PER
        CMD.Parameters.Add("@COD_REF", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_REF", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@FECHA_REF", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = CUENTA_TOTAL
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        CMD.Parameters.Add("@COD_BANCO", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@COD_BANCO_DEST", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@TIPO_TRANS", SqlDbType.Char).Value = System.DBNull.Value
        CMD.Parameters.Add("@STATUS_TRANS", SqlDbType.Char).Value = System.DBNull.Value
        CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
        CMD.Parameters.Add("@TIPO_OPE", SqlDbType.Char).Value = "GD"
        CMD.Parameters.Add("@NRO_MP", SqlDbType.Char).Value = System.DBNull.Value
        CMD.Parameters.Add("@NRO", SqlDbType.Char).Value = System.DBNull.Value

        CMD.ExecuteNonQuery()
    End Sub

    Private Sub GRABAR_REG_VENTAS(ByVal FILA As Integer)
        '******************************************************************************
        'GRABAR REG_VENTAS
        '******************************************************************************
        SB.Remove(0, SB.Length)
        SB.AppendLine("INSERT INTO REGISTRO_VENTAS(FE_AÑO,FE_MES,COD_DOC,NRO_DOC,COD_PER,")
        SB.AppendLine("NRO_DOC_PER,COD_AUX,COD_COMP,NRO_COMP,FECHA_COMP,NOMBRE_PER,FECHA_DOC,")
        SB.AppendLine("COD_REF,NRO_REF,FECHA_REF,IMP01,IMP02,IMP03,IMP04,IMP05,IMP06,IMP07,")
        SB.AppendLine("IMP08,IMP09,IMP10,COD_MONEDA,TIPO_CAMBIO,COD_D_H,NRO_DET,TASA_DET,FECHA_DET,")
        SB.AppendLine("Fecha_pago,STATUS_PAGO,BASE_REF,IMP_TOTAL)")
        SB.AppendLine("VALUES(@FE_AÑO,@FE_MES,@COD_DOC,@NRO_DOC,@COD_PER,@NRO_DOC_PER,@COD_AUX,")
        SB.AppendLine("@COD_COMP,@NRO_COMP,@FECHA_COMP,@NOMBRE_PER,@FECHA_DOC,@COD_REF,@NRO_REF,")
        SB.AppendLine("@FECHA_REF,@IMP01,@IMP02,@IMP03,@IMP04,@IMP05,@IMP06,@IMP07,@IMP08,@IMP09,")
        SB.AppendLine("@IMP10,@COD_MONEDA,@TIPO_CAMBIO,@COD_D_H,@NRO_DET,@TASA_DET,@FECHA_DET,")
        SB.AppendLine("@FECHA_PAGO,@STATUS_PAGO,@BASE_REF,@IMP_TOTAL)")

        Dim CMD As New SqlCommand
        CMD = New SqlCommand(SB.ToString, con, trans)
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = COD_DOC
        CMD.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC
        CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
        CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = DOC_PER
        CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
        CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
        CMD.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = NRO_COMP
        CMD.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = dtpFechaComp.Value
        CMD.Parameters.Add("@NOMBRE_PER", SqlDbType.Char).Value = DESC_PER
        CMD.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@COD_REF", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_REF", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@FECHA_REF", SqlDbType.DateTime).Value = FECHA_DOC
        '--------------------
        'Buscamos el orden
        '--------------------
        Dim C As Integer
        For C = 1 To 10
            If C.ToString("00") = ORDEN_BASE Then
                CMD.Parameters.Add("@IMP" + C.ToString("00"), SqlDbType.Decimal).Value = ImpS_Base
            ElseIf C.ToString("00") = ORDEN_EXONERADO Then
                CMD.Parameters.Add("@IMP" + C.ToString("00"), SqlDbType.Decimal).Value = ImpS_Exo
            ElseIf C.ToString("00") = ORDEN_IGV Then
                CMD.Parameters.Add("@IMP" + C.ToString("00"), SqlDbType.Decimal).Value = ImpS_Igv
                'ElseIf C.ToString("00") = ORDEN_TOTAL Then
                '    CMD.Parameters.Add("@IMP" + C.ToString("00"), SqlDbType.Decimal).Value = ImpS_Total
            Else
                CMD.Parameters.Add("@IMP" + C.ToString("00"), SqlDbType.Decimal).Value = 0
            End If
        Next
        CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = COD_MONEDA
        CMD.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TCAMBIO
        CMD.Parameters.Add("@COD_D_H", SqlDbType.Char).Value = COD_DH_DOC
        CMD.Parameters.Add("@NRO_DET", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@TASA_DET", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@FECHA_DET", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@FECHA_PAGO", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@STATUS_PAGO", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@BASE_REF", SqlDbType.Char).Value = 0
        CMD.Parameters.Add("@IMP_TOTAL", SqlDbType.Char).Value = ImpS_Total

        CMD.ExecuteNonQuery()
    End Sub

    Private Sub GRABAR_I_CON()

        '******************************************************************************
        'Grabar(I_CON)
        '******************************************************************************
        SB.Remove(0, SB.Length)
        SB.AppendFormat("INSERT INTO [BD_COI{0}].[dbo].[I_CON]", COD_EMPRESA)
        SB.AppendLine("(COD_AUX,COD_COMP,NRO_COMP,FE_AÑO,FE_MES,FECHA_COMP,COD_USU_CREA,COD_USU_MOD,")
        SB.AppendLine("FECHA_CREA,FECHA_MOD,STATUS_MODULO,COD_PER_CANJE,NRO_DOC_PER_CANJE,COD_CUENTA_CANJE,")
        SB.AppendLine("NRO_LETRAS_CANJE,COD_USU,TIPO_DET,STATUS_FFIJO,NRO_PLANILLA,TIPO_PLA)")
        SB.AppendLine("VALUES(@COD_AUX,@COD_COMP,@NRO_COMP,@FE_AÑO,@FE_MES,@FECHA_COMP,@COD_USU_CREA,")
        SB.AppendLine("@COD_USU_MOD,@FECHA_CREA,@FECHA_MOD,@STATUS_MODULO,@COD_PER_CANJE,@NRO_DOC_PER_CANJE,")
        SB.AppendLine("@COD_CUENTA_CANJE,@NRO_LETRAS_CANJE,@COD_USU,@TIPO_DET,@STATUS_FFIJO,@NRO_PLANILLA,@TIPO_PLA)")

        Dim CMD As New SqlCommand

        CMD = New SqlCommand(SB.ToString, con, trans)
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
        CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
        CMD.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = NRO_COMP
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        CMD.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = dtpFechaComp.Value
        CMD.Parameters.Add("@COD_USU_CREA", SqlDbType.Char).Value = COD_USU
        CMD.Parameters.Add("@COD_USU_MOD", SqlDbType.Char).Value = COD_USU
        CMD.Parameters.Add("@FECHA_CREA", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@FECHA_MOD", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@STATUS_MODULO", SqlDbType.Char).Value = "PRVTA"
        CMD.Parameters.Add("@COD_PER_CANJE", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_DOC_PER_CANJE", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@COD_CUENTA_CANJE", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_LETRAS_CANJE", SqlDbType.Char).Value = System.DBNull.Value
        CMD.Parameters.Add("@COD_USU", SqlDbType.Char).Value = COD_USU
        CMD.Parameters.Add("@TIPO_DET", SqlDbType.Char).Value = "1"
        CMD.Parameters.Add("@STATUS_FFIJO", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_PLANILLA", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@TIPO_PLA", SqlDbType.Char).Value = ""

        CMD.ExecuteNonQuery()
    End Sub

    Private Sub GRABAR_T_CON(ByVal Cuenta As String, ByVal DH As String, ByVal ITEM As Integer, _
    ByVal SOLES As Decimal, ByVal DOLARES As Decimal, ByVal ORDEN As String, ByVal TIPOORDEN As String, _
    ByVal MONEDA As String, ByVal GLOSA As String, ByVal IGV00 As Decimal, ByVal AUTO As Integer)
        '******************************************************************************
        'Grabar(T_CON)
        '******************************************************************************
        SB.Remove(0, SB.Length)
        SB.AppendFormat("INSERT INTO [BD_COI{0}].[dbo].[T_CON]", COD_EMPRESA)
        SB.AppendLine("(FE_AÑO,FE_MES,COD_AUX,COD_COMP,NRO_COMP,COD_DOC,NRO_DOC,COD_PER,")
        SB.AppendLine("NRO_DOC_PER, item, FECHA_DOC, COD_REF, NRO_REF, FECHA_REF, Glosa, COD_CUENTA,")
        SB.AppendLine("IMP_S, IMP_D, cod_d_h, COD_MONEDA, Tipo_Cambio, COD_CC, cod_control, cod_proyecto,")
        SB.AppendLine("NRO_ORDEN, FECHA_VEN, STATUS_PRECIO, Cuenta_Enlace, Cuenta_Destino, STATUS_AUTO,")
        SB.AppendLine("TIPO_TRANS, STATUS_ANALISIS, status_pago, COD_MP, NRO_MP, FECHA_MP, ITEM_PAGO,")
        SB.AppendLine("COD_BANCO_DEST, STATUS_TRANS, FECHA_COMP, STATUS_DOC, POR_IGV, STATUS_REP, COD_ACTIVIDAD,")
        SB.AppendLine("STATUS_TRANSF_COSTO,STATUS_TRANSF_OP)")
        SB.AppendLine("VALUES(@FE_AÑO,@FE_MES,@COD_AUX,@COD_COMP,@NRO_COMP,@COD_DOC,@NRO_DOC,@COD_PER,")
        SB.AppendLine("@NRO_DOC_PER,@ITEM,@FECHA_DOC,@COD_REF,@NRO_REF,@FECHA_REF,@GLOSA,@COD_CUENTA,")
        SB.AppendLine("@IMP_S,@IMP_D,@COD_D_H,@COD_MONEDA,@TIPO_CAMBIO,@COD_CC,@COD_CONTROL,@COD_PROYECTO,")
        SB.AppendLine("@NRO_ORDEN,@FECHA_VEN,@STATUS_PRECIO,@CUENTA_ENLACE,@CUENTA_DESTINO,@STATUS_AUTO,")
        SB.AppendLine("@TIPO_TRANS,@STATUS_ANALISIS,@STATUS_PAGO,@COD_MP,@NRO_MP,@FECHA_MP,@ITEM_PAGO,")
        SB.AppendLine("@COD_BANCO_DEST,@STATUS_TRANS,@FECHA_COMP,@STATUS_DOC,@POR_IGV,@STATUS_REP,")
        SB.AppendLine("@COD_ACTIVIDAD,@STATUS_TRANSF_COSTO,@STATUS_TRANSF_OP)")

        Dim CMD As New SqlCommand

        CMD = New SqlCommand(SB.ToString, con, trans)
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
        CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
        CMD.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = NRO_COMP
        CMD.Parameters.Add("@COD_DOC", SqlDbType.Char).Value = COD_DOC
        CMD.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = NRO_DOC
        CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = COD_PER
        CMD.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = DOC_PER
        CMD.Parameters.Add("@ITEM", SqlDbType.Char).Value = ITEM.ToString("0000")
        CMD.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@COD_REF", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_REF", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@FECHA_REF", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@GLOSA", SqlDbType.Char).Value = GLOSA
        CMD.Parameters.Add("@COD_CUENTA", SqlDbType.Char).Value = Cuenta
        CMD.Parameters.Add("@IMP_S", SqlDbType.Decimal).Value = SOLES
        CMD.Parameters.Add("@IMP_D", SqlDbType.Decimal).Value = DOLARES
        CMD.Parameters.Add("@COD_D_H", SqlDbType.Char).Value = DH
        CMD.Parameters.Add("@COD_MONEDA", SqlDbType.Char).Value = MONEDA
        CMD.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = Decimal.Parse(TCAMBIO)
        CMD.Parameters.Add("@COD_CC", SqlDbType.Char).Value = COD_CC
        CMD.Parameters.Add("@COD_CONTROL", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@COD_PROYECTO", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_ORDEN", SqlDbType.Char).Value = ORDEN
        CMD.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = FECHA_VEN
        CMD.Parameters.Add("@STATUS_PRECIO", SqlDbType.Char).Value = "0"
        CMD.Parameters.Add("@CUENTA_ENLACE", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@CUENTA_DESTINO", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@STATUS_AUTO", SqlDbType.Char).Value = AUTO
        CMD.Parameters.Add("@TIPO_TRANS", SqlDbType.Char).Value = TIPOORDEN
        CMD.Parameters.Add("@STATUS_ANALISIS", SqlDbType.Char).Value = "0"
        CMD.Parameters.Add("@STATUS_PAGO", SqlDbType.Char).Value = "0"
        CMD.Parameters.Add("@COD_MP", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@NRO_MP", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@FECHA_MP", SqlDbType.DateTime).Value = FECHA_DOC
        CMD.Parameters.Add("@ITEM_PAGO", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@COD_BANCO_DEST", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@STATUS_TRANS", SqlDbType.Char).Value = "0"
        CMD.Parameters.Add("@FECHA_COMP", SqlDbType.DateTime).Value = dtpFechaComp.Value
        CMD.Parameters.Add("@STATUS_DOC", SqlDbType.Char).Value = "GD"
        CMD.Parameters.Add("@POR_IGV", SqlDbType.Decimal).Value = IGV00
        CMD.Parameters.Add("@STATUS_REP", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@COD_ACTIVIDAD", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@STATUS_TRANSF_COSTO", SqlDbType.Char).Value = ""
        CMD.Parameters.Add("@STATUS_TRANSF_OP", SqlDbType.Char).Value = ""

        CMD.ExecuteNonQuery()

    End Sub

    Private Sub INSERTAR_SALDO_CUENTAS(ByVal D_H As String, ByVal Cta As String, _
            ByVal Año As String, ByVal Mes As String, ByVal Importe As Decimal)

        Dim CMD As New SqlCommand("INSERTAR_SALDO_CUENTAS", con, trans)
        CMD.CommandType = CommandType.StoredProcedure
        Dim Par0 As SqlParameter = CMD.Parameters.Add("@COD_D_H", SqlDbType.Char)
        Par0.Direction = ParameterDirection.Input
        Par0.Value = D_H

        Dim Par1 As SqlParameter = CMD.Parameters.Add("@COD_CTA", SqlDbType.VarChar)
        Par1.Direction = ParameterDirection.Input
        Par1.Value = Cta

        Dim Par2 As SqlParameter = CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char)
        Par2.Direction = ParameterDirection.Input
        Par2.Value = Año

        Dim Par3 As SqlParameter = CMD.Parameters.Add("@FE_MES", SqlDbType.Char)
        Par3.Direction = ParameterDirection.Input
        Par3.Value = Mes

        Dim Par4 As SqlParameter = CMD.Parameters.Add("@IMP_S", SqlDbType.Decimal)
        Par4.Direction = ParameterDirection.Input
        Par4.Value = Importe

        CMD.ExecuteNonQuery()
    End Sub

    Private Sub ACTUALIZAR_NUMERACION()
        SB.Remove(0, SB.Length)
        SB.AppendFormat("Update [BD_COI{0}].[dbo].[NRO_COMPROBANTE] SET NUMERACION=@NRO_COMP ", COD_EMPRESA)
        SB.AppendLine("WHERE AÑO=@FE_AÑO AND MES=@FE_MES AND COD_AUX=@COD_AUX AND COD_COMP=@COD_COMP")

        Dim CMD As New SqlCommand

        CMD = New SqlCommand(SB.ToString, con, trans)
        CMD.CommandType = CommandType.Text
        CMD.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        CMD.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        CMD.Parameters.Add("@COD_AUX", SqlDbType.Char).Value = COD_AUX
        CMD.Parameters.Add("@COD_COMP", SqlDbType.Char).Value = COD_COMP
        CMD.Parameters.Add("@NRO_COMP", SqlDbType.Char).Value = NRO_COMP
        CMD.ExecuteNonQuery()
    End Sub

    Function VERIFICAR_REG_VENTAS(ByVal COD_DOC0 As Object, ByVal NRO_DOC0 As Object, ByVal COD_PER0 As Object, ByVal DOC_PER0 As Object) As Boolean
        Dim I As Integer = 0
        Try
            'Dim PROG_01 As New SqlCommand("VERIFICAR_REG_VENTAS", con, trans)
            Dim PROG_01 As New SqlCommand("VERIFICAR_REG_VENTAS", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = (COD_DOC0)
            PROG_01.Parameters.Add("@NRO_DOC", SqlDbType.Char).Value = (NRO_DOC0)
            PROG_01.Parameters.Add("@COD_PER", SqlDbType.Char).Value = (COD_PER0)
            PROG_01.Parameters.Add("@NRO_DOC_PER", SqlDbType.Char).Value = (DOC_PER0)
            PROG_01.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
            PROG_01.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
            con.Open()
            I = Integer.Parse(PROG_01.ExecuteScalar)
            ' con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
        If I = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function HALLAR_ORDEN_CUENTA(ByVal TIPO_ORDEN As Object, ByVal AÑO As Object, ByVal TIPO_MOV As Object, ByVal COD_CUENTA As Object) As String
        Dim ORDEN As String = con.ConnectionString
        Try
            Dim pro03 As New SqlCommand("HALLAR_ORDEN_CUENTA", con, trans)
            pro03.CommandType = CommandType.StoredProcedure
            pro03.Parameters.Add("@TIPO_ORDEN", SqlDbType.VarChar).Value = (TIPO_ORDEN)
            pro03.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
            pro03.Parameters.Add("@TIPO_MOV", SqlDbType.VarChar).Value = (TIPO_MOV)
            pro03.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (COD_CUENTA)
            'con.Open()
            ORDEN = pro03.ExecuteScalar
            'con.Close()
        Catch ex As Exception
            'con.Close()
            MsgBox(ex.Message)
        End Try
        If (ORDEN = Nothing) Then
            ORDEN = ""
        End If
        Return ORDEN
    End Function

    Function Grabar() As Boolean
        Dim oB As String = ""
        Dim x As Integer
        Dim _Grabar As Boolean
        Dim Cta As String = "" : Dim oD As String = ""
        Dim oDBase As String = ""
        Dim D_H As String = "" : Dim TipoOd As String = ""
        Dim MontoS As Decimal = 0 : Dim MontoD As Decimal = 0
        Dim SOLESH As Decimal : Dim SOLESD As Decimal

        Dim igv As Decimal = 0
        Dim SbFact As New StringBuilder
        Dim Archivo As String = "C:\Facturacion_Existente.txt"

        Dim SOLES As Decimal = 0
        Dim DOLARES As Decimal = 0

        Dim it, d As Integer
        SbFact.Remove(0, SbFact.Length)
        SB.Remove(0, SB.Length)
        con.Open()
        trans = con.BeginTransaction
        Try
            NRO_COMP = txtComprobante.Text
            For x = 0 To DG.Rows.Count - 1
                If DG.Item(12, x).Value Then
                    COD_DOC = DG.Item(0, x).Value.ToString
                    COD_DH_DOC = OBJ.COD_D_H(COD_DOC)
                    NRO_DOC = Trim(DG.Item(1, x).Value.ToString)
                    FECHA_DOC = DateTime.Parse(DG.Item(2, x).Value)
                    COD_PER = Trim(DG.Item(4, x).Value.ToString)
                    DESC_PER = Trim(DG.Item(5, x).Value.ToString)
                    DOC_PER = Trim(DG.Item(7, x).Value.ToString)
                    'COD_CLASE = DG.Item(2, x).Value.ToString
                    COD_MONEDA = DG.Item(8, x).Value.ToString
                    TCAMBIO = Decimal.Parse((DG.Item(10, x).Value))
                    FECHA_VEN = FECHA_DOC
                    IMP_BASE = Decimal.Parse(DG.Item(11, x).Value.ToString)
                    IMP_EXO = Decimal.Parse(DG.Item(14, x).Value.ToString)
                    IMP_IGV = Decimal.Parse((DG.Item(16, x).Value))
                    IMP_TOTAL = Decimal.Parse(DG.Item(18, x).Value.ToString)
                    CUENTA_BASE = DG.Item(13, x).Value.ToString
                    CUENTA_EXO = DG.Item(15, x).Value.ToString
                    CUENTA_IGV = DG.Item(17, x).Value.ToString
                    CUENTA_TOTAL = DG.Item(19, x).Value.ToString
                    COD_CC = DG.Item(22, x).Value.ToString
                    'ORDEN DE CUENTA
                    ORDEN_BASE = HALLAR_ORDEN_CUENTA("B", AÑO, "V", DG.Item(13, x).Value.ToString.Substring(0, 3))
                    ORDEN_EXONERADO = HALLAR_ORDEN_CUENTA("B", AÑO, "V", DG.Item(15, x).Value.ToString.Substring(0, 3))
                    ORDEN_IGV = HALLAR_ORDEN_CUENTA("I", AÑO, "V", DG.Item(17, x).Value.ToString.Substring(0, 3))
                    ORDEN_TOTAL = HALLAR_ORDEN_CUENTA("T", AÑO, "V", DG.Item(19, x).Value.ToString.Substring(0, 3))

                    SOLESH = 0 : SOLESD = 0

                    If Not VERIFICAR_CUENTA(x) Then
                        Throw New Exception(SB.AppendFormat("No existen en el Plan de cuentas: {0}{0}", Environment.NewLine, SB.ToString).ToString)
                    End If
                    If Not VALIDAR_CUENTA_ORDEN(x) Then
                        Throw New Exception(SB.AppendFormat("No existen Orden para la Cuenta Contable : {0}{1} ", Environment.NewLine, SB.ToString).ToString)
                    End If
                    'If VERIFICAR_REG_VENTAS(COD_DOC, NRO_DOC, COD_PER, DOC_PER) = False Then
                    '    SbFact.AppendFormat("Doc: {0} | Nro: {1} | Cod. Per.: {2} | Doc. Per.: {3} {4}", COD_DOC, NRO_DOC, COD_PER, DOC_PER, Environment.NewLine)

                    'Else

                    If (COD_MONEDA = "S") Then
                        ImpS_Base = Math.Round(Decimal.Parse(IMP_BASE), 2)
                        ImpS_Exo = Math.Round(Decimal.Parse(IMP_EXO), 2)
                        ImpS_Igv = Math.Round(Decimal.Parse(IMP_IGV), 2)
                        ImpS_Total = Math.Round(Decimal.Parse(IMP_TOTAL), 2)
                        ImpD_Base = Math.Round(Decimal.Parse(IMP_BASE / TCAMBIO), 2)
                        ImpD_Exo = Math.Round(Decimal.Parse(IMP_EXO / TCAMBIO), 2)
                        ImpD_Igv = Math.Round(Decimal.Parse(IMP_IGV / TCAMBIO), 2)
                        ImpD_Total = Math.Round(Decimal.Parse(IMP_TOTAL / TCAMBIO), 2)
                    Else
                        ImpS_Base = Math.Round(Decimal.Parse(IMP_BASE * TCAMBIO), 2)
                        ImpS_Exo = Math.Round(Decimal.Parse(IMP_EXO * TCAMBIO), 2)
                        ImpS_Igv = Math.Round(Decimal.Parse(IMP_IGV * TCAMBIO), 2)
                        ImpS_Total = Math.Round(Decimal.Parse(IMP_TOTAL * TCAMBIO), 2)
                        ImpD_Base = Math.Round(Decimal.Parse(IMP_BASE), 2)
                        ImpD_Exo = Math.Round(Decimal.Parse(IMP_EXO), 2)
                        ImpD_Igv = Math.Round(Decimal.Parse(IMP_IGV), 2)
                        ImpD_Total = Math.Round(Decimal.Parse(IMP_TOTAL), 2)
                        'SOLES = ImpS_Total
                        'DOLARES = Math.Round(Decimal.Parse(ImpD_Base * TCAMBIO), 2) + Math.Round(Decimal.Parse(ImpD_Exo * TCAMBIO), 2) + Math.Round(Decimal.Parse(ImpD_Igv * TCAMBIO), 2)
                    End If

                    GRABAR_PCTAS_COBRAR()

                    GRABAR_TCTAS_COBRAR()

                    GRABAR_REG_VENTAS(x)

                    GRABAR_I_CON()

                    it = 0
                    For d = 12 To 18 Step 2
                        _Grabar = False
                        If d = 12 AndAlso IMP_BASE > 0 Then
                            _Grabar = True
                            oD = ORDEN_BASE : TipoOd = "B"
                            Cta = CUENTA_BASE
                            If COD_DH_DOC = "D" Then
                                D_H = "H"
                                SOLESH += ImpS_Base
                            Else
                                D_H = "D"
                                SOLESD += ImpS_Base
                            End If
                            oDBase = D_H
                            MontoS = ImpS_Base : MontoD = ImpD_Base
                            igv = Math.Round((IMP_IGV / IMP_BASE) * 100, 0)

                        ElseIf d = 14 AndAlso IMP_EXO > 0 Then
                            _Grabar = True
                            oD = ORDEN_EXONERADO : TipoOd = "B"
                            Cta = CUENTA_EXO
                            COD_CC = ""
                            If COD_DH_DOC = "D" Then
                                D_H = "H"
                                SOLESH += ImpS_Exo
                            Else
                                D_H = "D"
                                SOLESD += ImpS_Exo
                            End If
                            MontoS = ImpS_Exo : MontoD = ImpD_Exo
                            igv = 0
                        ElseIf d = 16 AndAlso IMP_IGV > 0 Then
                            _Grabar = True
                            oD = ORDEN_IGV : TipoOd = "I"
                            Cta = CUENTA_IGV
                            COD_CC = ""
                            If COD_DH_DOC = "D" Then
                                D_H = "H"
                                SOLESH += ImpS_Igv
                            Else
                                D_H = "D"
                                SOLESD += ImpS_Igv
                            End If
                            MontoS = ImpS_Igv : MontoD = ImpD_Igv
                            igv = 0
                        ElseIf d = 18 AndAlso IMP_TOTAL > 0 Then
                            _Grabar = True
                            COD_CC = ""
                            oD = ORDEN_TOTAL : TipoOd = "T"
                            Cta = CUENTA_TOTAL
                            MontoS = ImpS_Total : MontoD = ImpD_Total
                            D_H = COD_DH_DOC
                            If COD_DH_DOC = "D" Then
                                SOLESD += ImpS_Total
                            Else
                                SOLESH += ImpS_Total
                            End If
                            igv = 0
                        End If
                        If _Grabar Then
                            it += 1
                            GRABAR_T_CON(Cta, D_H, it, MontoS, MontoD, oD, TipoOd, COD_MONEDA, DESC_PER, igv, 0)
                            INSERTAR_SALDO_CUENTAS(D_H, Cta, AÑO, MES, MontoS)
                        End If
                    Next

                    If (COD_MONEDA = "D") Then
                        If (SOLESD - SOLESH) < 0.5 AndAlso (SOLESD - SOLESH) > -0.5 Then
                            'TIENE QUE HABER AJUSTE
                            Dim AJ As Decimal = (SOLESD - SOLESH)
                            D_H = "H"
                            If AJ < 0 Then D_H = "D" : AJ = AJ * -1
                            Cta = DIR_TABLA_DESC("CTA_AJ_H", "TDCTA")
                            If D_H = "D" Then Cta = DIR_TABLA_DESC("CTA_AJ_D", "TDCTA")
                            oD = HALLAR_ORDEN_CUENTA("B", AÑO, "V", Cta)
                            If AJ <> 0 Then
                                GRABAR_T_CON(Cta, D_H, it + 1, AJ, 0, "00", "B", "A", "AJUSTE DE DOCUMENTO", igv, 0)
                                Dim cmd As New SqlCommand("Select CUENTA_ENLACE,CUENTA_DESTINO From MAESTRO_AUTOMATICAS Where COD_CUENTA=@Cta", con, trans)
                                cmd.CommandType = CommandType.Text
                                Dim prm1 As SqlParameter = cmd.Parameters.Add("@Cta", SqlDbType.Char)
                                prm1.Value = Cta
                                Dim CtaEnlace, CtaDestino As String
                                Dim Rs As SqlDataReader = cmd.ExecuteReader(CommandBehavior.SingleRow)
                                If Rs IsNot Nothing AndAlso Rs.HasRows Then
                                    Rs.Read()
                                    CtaEnlace = Rs.GetString(0)
                                    CtaDestino = Rs.GetString(1)
                                    GRABAR_T_CON(CtaDestino, oDBase, it + 2, AJ, 0, "", "0", "A", DESC_PER, igv, 1)
                                    INSERTAR_SALDO_CUENTAS(oDBase, CtaDestino, AÑO, MES, AJ)

                                    GRABAR_T_CON(CtaEnlace, IIf(oDBase = "D", "H", "D"), it + 3, AJ, 0, "", "0", "A", DESC_PER, igv, 1) 'HABER
                                    INSERTAR_SALDO_CUENTAS(IIf(oDBase = "D", "H", "D"), CtaEnlace, AÑO, MES, AJ)
                                    'DESTINO SEGUN BASE
                                End If
                                Rs.Close()
                            End If
                        End If
                    End If

                    NRO_COMP = (NRO_COMP + 1).ToString("0000")
                    'Throw New Exception(SB.AppendFormat("El documento existe en el registro de ventas :{0} Doc: {1} | Nro: {2} | Cod. Per.: {3} | Doc. Per.: {4}", Environment.NewLine, COD_DOC, NRO_DOC, COD_PER, DOC_PER).ToString)
                    'End If
                    'STATUS_ANUL = DG.Item(22, x).Value.ToString
                End If
            Next
            ACTUALIZAR_NUMERACION()

            If SbFact.Length > 0 Then
                Dim fi As New FileInfo(Archivo)
                If fi.Exists() Then
                    fi.Delete()
                End If
                Using Fs As New FileStream(Archivo, FileMode.Append, FileAccess.Write, FileShare.Write)
                    Using sw As New StreamWriter(Fs)
                        sw.WriteLine(SbFact.ToString)
                    End Using
                End Using
                MessageBox.Show(String.Format("Algunos documentos no fueron transferidos. Verifique el archivo:{0}{1}", Environment.NewLine, Archivo), "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            trans.Commit()
            con.Close()
            MessageBox.Show("Los Documentos fueron transferidos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'txtComprobante.Text = NRO_COMP
            Return True
        Catch ex As Exception
            trans.Rollback()
            con.Close()
            MessageBox.Show("Error al transferir: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub FinGrabar(ByVal iar As IAsyncResult)
        Try
            Grabo = oDelegadoGrabar.EndInvoke(iar)
            Dim mi As New MethodInvoker(AddressOf EstadoGrabar)
            Me.Invoke(mi)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub EstadoGrabar()
        ActivaControl(True)
        txtComprobante.Text = NRO_COMP
        DG.DataSource = Nothing
    End Sub

    Private Sub PresentarDatos()
        DG.DataSource = dst.Tables(0)
        Formato()
        MostrarCodPersona()
        GenerarPersona()
        MostrarCodPersona()
        chkTodos.Checked = False
        ActivaControl(True)
    End Sub

    Private Sub FinLlamadaAsincrona(ByVal iar As IAsyncResult)
        dst = oDelegado.EndInvoke(iar)
        Dim mi As New MethodInvoker(AddressOf PresentarDatos)
        Me.Invoke(mi)
    End Sub

    Private Enum EMPRESA
        PROPLAST = 1
        INVERSIONES = 3
        FABIPLAST = 4
    End Enum

    Private ruta, archFact, archMov As String

    Function SGT_CODIGO() As String
        Dim SGT As String = ""
        Try
            Dim CMD As New SqlCommand("SGT_PERSONA", con, trans)
            SGT = CMD.ExecuteScalar.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If SGT = "" Then
            SGT_CODIGO = "00001"
        Else
            SGT_CODIGO = SGT
        End If
    End Function
    Sub MostrarCodPersona()
        Dim y As Integer
        Try
            For y = 0 To DG.Rows.Count - 1
                If DG.Item(4, y).Value = "s/c" Then
                    If (Trim(DG.Item(0, y).Value.ToString) = "03" AndAlso Trim(DG.Item(7, y).Value.ToString) = "") _
                    OrElse Trim(DG.Item(5, y).Value) = "ANULADO" Then
                        DG.Item(4, y).Value = "00000"
                    ElseIf LTrim(RTrim(DG.Item(7, y).Value)) <> "" Then
                        DG.Item(4, y).Value = CodigoPersona(DG.Item(7, y).Value)
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error al mostrar el codigo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Dim dr As DataRow

        Dim I, CONT As Integer
        I = 0 : CONT = DG.RowCount - 1
        While I <= CONT
            With DG
                If Not (VERIFICAR_REG_VENTAS(.Item(0, I).Value, .Item(1, I).Value, .Item(4, I).Value, .Item(7, I).Value)) Then
                    DG.Rows.RemoveAt(I)
                    I = 0 : CONT = DG.RowCount - 1
                Else
                    I += 1
                End If
            End With
        End While
    End Sub

    Function ValidaArch(ByVal ArchivoDBF As String) As Boolean
        'Dim cod As Integer
        Dim Equiv As String
        Dim existe As Boolean = False
        Equiv = ArchivoDBF.Substring(5, 1)

        Dim nodoResultado As XmlNode = _
            oXML.DocumentElement.SelectSingleNode( _
            String.Format("//Empresa[Codigo={0}]", COD_EMPRESA))
        If nodoResultado IsNot Nothing Then
            Nodo = nodoResultado
            If Equiv = Nodo.ChildNodes(1).FirstChild.Value Then
                existe = True
            End If
        Else
            MessageBox.Show("No se encontró el Código")
        End If
        Return existe
    End Function

    Public Function VALIDAR_IMPORTE() As Boolean
        Dim SOLESD As New Decimal
        Dim DOLARESD As New Decimal
        Dim SOLESH As New Decimal
        Dim DOLARESH As New Decimal
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        '-----------------------------
        '-- HALLAR D / H DE IGV Y TOTAL
        '-----------------------------
        Dim DH_IGV As String = ""
        Dim DH_T As String = ""
        If (COD_DH_DOC = "D") Then
            DH_IGV = "H"
            DH_T = "D"
        ElseIf (COD_DH_DOC = "H") Then
            DH_IGV = "D"
            DH_T = "H"
        End If
        '-----------------------------
        'ELIMINAR EL AJUSTE
        While I <= CONT0
            If dgw_mov1.Item(6, I).Value.ToString = "A" Then
                dgw_mov1.Rows.RemoveAt(I)
                I = 0
                CONT0 = (dgw_mov1.RowCount - 1)
            Else
                I += 1
            End If
        End While
        '-----------------------------
        I = 0
        CONT0 = (dgw_mov1.RowCount - 1)
        Do While (I <= CONT0)
            Dim sol, dol As Decimal
            sol = Math.Round(dgw_mov1.Item(3, I).Value, 2)
            dol = Math.Round(dgw_mov1.Item(4, I).Value, 2)
            If (dgw_mov1.Item(5, I).Value.ToString = "D") Then
                SOLESD = SOLESD + sol
                DOLARESD = DOLARESD + dol
            Else
                SOLESH = SOLESH + sol
                DOLARESH = DOLARESH + dol
            End If
            I += 1
        Loop
        '--------------------------------------------
        If DH_IGV = "D" Then
            If (COD_MONEDA = "S") Then
                SOLESD = SOLESD + IMP_IGV
                DOLARESD = DOLARESD + Math.Round((IMP_IGV / TCAMBIO), 2)
            Else
                SOLESD = SOLESD + Math.Round((IMP_IGV * TCAMBIO), 2)
                DOLARESD = DOLARESD + IMP_IGV
            End If
        Else
            If (COD_MONEDA = "S") Then
                SOLESH = SOLESH + IMP_IGV
                DOLARESH = DOLARESH + Math.Round((IMP_IGV / TCAMBIO), 2)
            Else
                SOLESH = SOLESH + Math.Round((IMP_IGV * TCAMBIO), 2)
                DOLARESH = DOLARESH + IMP_IGV
            End If
        End If
        '---------------------------------------------
        '--------------------------------------------
        If DH_T = "D" Then
            If (COD_MONEDA = "S") Then
                SOLESD = SOLESD + IMP_TOTAL
                DOLARESD = DOLARESD + Math.Round((IMP_TOTAL / TCAMBIO), 2)
            Else
                SOLESD = SOLESD + Math.Round((IMP_TOTAL * TCAMBIO), 2)
                DOLARESD = DOLARESD + IMP_TOTAL
            End If
        Else
            If (COD_MONEDA = "S") Then
                SOLESH = SOLESH + IMP_TOTAL
                DOLARESH = DOLARESH + Math.Round((IMP_TOTAL / TCAMBIO), 2)
            Else
                SOLESH = SOLESH + Math.Round((IMP_TOTAL * TCAMBIO), 2)
                DOLARESH = DOLARESH + IMP_TOTAL
            End If
        End If
        '---------------------------------------------
        If COD_MONEDA = "S" Then
            If SOLESH = SOLESD Then
                If (DOLARESD - DOLARESH) < 0.5 And (DOLARESD - DOLARESH) > -0.5 Then
                    'ESTA BIEN PERO NO HAY AJUSTE EN DOLARES
                    Return True
                Else
                    'YA NO SU PUEDE HACER AJUSTE POR ESO DEBE SALIR EL MENSAJE
                    Return False
                End If
            End If
        Else
            'MONEDA DOLARES
            If DOLARESD = DOLARESH Then
                If (SOLESD - SOLESH) < 0.5 And (SOLESD - SOLESH) > -0.5 Then
                    'TIENE QUE HABER AJUSTE
                    Dim AJ As Decimal = SOLESD - SOLESH
                    Dim DH_AJ As String = "H"
                    If AJ < 0 Then DH_AJ = "D" : AJ = AJ * -1
                    Dim CTA_AJ As String = OBJ.DIR_TABLA_DESC("CTA_AJ_H", "TDCTA")
                    If DH_AJ = "D" Then CTA_AJ = OBJ.DIR_TABLA_DESC("CTA_AJ_D", "TDCTA")
                    Dim ORDEN0 As String = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "V", CTA_AJ)
                    If AJ <> 0 Then
                        dgw_mov1.Rows.Add("0000", CTA_AJ, "AJUSTE DE DOCUMENTO", AJ, 0, DH_AJ, "A", TCAMBIO, "", "", "", "00", FECHA_DOC, "0", "", "", "0", "0", "0", FECHA_DOC, "", "", 0, "0", "", "")
                    End If
                    Return True
                Else
                    'YA NO SU PUEDE HACER AJUSTE POR ESO DEBE SALIR EL MENSAJE
                    Return False
                End If
            End If
        End If
    End Function

    Private Function CodigoPersona(ByVal doc As String) As String
        Dim COD As String = ""
        Try
            Dim cmd As New SqlCommand(String.Format("SELECT ISNULL(COD_PER,'') FROM MAESTRO_PERSONAS WHERE NRO_DOC='{0}'", doc), con)
            cmd.CommandType = CommandType.Text
            con.Open()
            COD = cmd.ExecuteScalar
            con.Close()
            If String.IsNullOrEmpty(COD) Then
                COD = "s/c"
            End If
        Catch ex As Exception
            MessageBox.Show("Error al verificar el codigo de la pesona" & Environment.NewLine & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return COD
    End Function

    Private Sub GenerarPersona()
        dgvPersona.Rows.Clear()
        Dim x As Integer = 0
        Dim i As Integer = 0
        Dim reg As Integer = 0
        Dim existe As Boolean
        Dim CodPer As String
        Dim sb As New StringBuilder
        Try
            '*******************************************************
            'VERIFICA SI ESXITE EL CLIENTE
            '*******************************************************
            For x = 0 To DG.Rows.Count - 1
                If Trim(DG.Item(4, x).Value.ToString) = "s/c" OrElse _
                Trim(DG.Item(4, x).Value.ToString) = "99999" Then
                    existe = False
                    For i = 0 To dgvPersona.Rows.Count - 1
                        If x = 0 And i = 0 Then
                            existe = False
                            Exit For
                        Else
                            If Trim(DG.Item(5, x).Value.ToString) = Trim(dgvPersona.Item(4, i).Value.ToString) AndAlso _
                            IIf(IsNumeric(Trim(DG.Item(7, x).Value)), Trim(DG.Item(7, x).Value.ToString), "") = IIf(IsNothing(dgvPersona.Item(3, i).Value.ToString), "", Trim(dgvPersona.Item(3, i).Value.ToString)) Then
                                existe = True
                                Exit For
                            End If
                        End If
                    Next
                    If existe = False Then
                        dgvPersona.Rows.Add()
                        Dim TipoPer As String = ""
                        Dim NombrePer As String = Trim(DG.Item(5, x).Value)
                        dgvPersona.Item(0, reg).Value = ""
                        dgvPersona.Item(4, reg).Value = NombrePer
                        'dgvPersona.Item(4, reg).Value = Trim(DG.Item(5, x).Value)
                        dgvPersona.Item(3, i).Value = ""
                        If Len(Trim(DG.Item(7, x).Value.ToString)) = 0 _
                            OrElse Not IsNumeric(Trim(DG.Item(7, x).Value)) Then
                            TipoPer = "N"
                            'dgvPersona.Item(1, reg).Value = "N"
                            dgvPersona.Item(2, reg).Value = "01"
                            dgvPersona.Item(3, reg).Value = ""
                        Else
                            If Len(Trim(DG.Item(7, x).Value.ToString)) = 11 Then
                                If DG.Item(7, x).Value.ToString.Substring(0, 2) = "20" Then
                                    'dgvPersona.Item(1, reg).Value = "J"
                                    TipoPer = "J"
                                ElseIf DG.Item(7, x).Value.ToString.Substring(0, 1) = "1" Then
                                    TipoPer = "N"
                                    'dgvPersona.Item(1, reg).Value = "N"
                                Else
                                    sb.AppendLine(Trim(DG.Item(5, x).Value))
                                End If
                                dgvPersona.Item(2, reg).Value = "06"
                                dgvPersona.Item(3, reg).Value = Trim(DG.Item(7, x).Value.ToString)
                            ElseIf Len(Trim(DG.Item(7, x).Value.ToString)) = 8 Then
                                TipoPer = "N"
                                'dgvPersona.Item(1, reg).Value = "N"
                                dgvPersona.Item(2, reg).Value = "01"
                                dgvPersona.Item(3, reg).Value = Trim(DG.Item(7, x).Value.ToString)
                            End If
                        End If
                        dgvPersona.Item(1, reg).Value = TipoPer
                        If TipoPer = "N" Then
                            Dim Nombre() As String
                            Nombre = NombrePer.Split(" ")
                            If Nombre.Length = 1 Then
                                dgvPersona.Item(6, reg).Value = Nombre(0)
                                dgvPersona.Item(7, reg).Value = ""
                                dgvPersona.Item(5, reg).Value = ""
                            ElseIf Nombre.Length = 2 Then
                                dgvPersona.Item(6, reg).Value = Nombre(0)
                                dgvPersona.Item(7, reg).Value = ""
                                dgvPersona.Item(5, reg).Value = Nombre(1)
                            ElseIf Nombre.Length = 3 Then
                                dgvPersona.Item(6, reg).Value = Nombre(0)
                                dgvPersona.Item(7, reg).Value = Nombre(1)
                                dgvPersona.Item(5, reg).Value = Nombre(2)
                            ElseIf Nombre.Length >= 4 Then
                                dgvPersona.Item(6, reg).Value = Nombre(0)
                                dgvPersona.Item(7, reg).Value = Nombre(1)
                                dgvPersona.Item(5, reg).Value = String.Format("{0} {1}", Nombre(2), Nombre(3))
                            End If
                        Else
                            dgvPersona.Item(6, reg).Value = ""
                            dgvPersona.Item(7, reg).Value = ""
                            dgvPersona.Item(5, reg).Value = ""
                        End If

                        reg += 1
                    End If
                End If
            Next

            '*******************************************************
            'GRABA LOS NUEVOS CLIENTES
            '*******************************************************
            Dim cod As String
            con.Open()
            trans = con.BeginTransaction

            If sb.Length > 0 Then
                Throw New Exception("Verifique el ruc del cliente:" + Environment.NewLine + sb.ToString)
            End If

            For x = 0 To dgvPersona.Rows.Count - 1
                If dgvPersona.Item(0, x).Value = "" Then
                    cod = SGT_CODIGO() '+ auxcod
                    dgvPersona.Item(0, x).Value = cod
                End If
                Dim CMD As New SqlCommand("[INSERTAR_PERSONA]", con, trans)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgvPersona.Item(0, x).Value
                CMD.Parameters.Add("@TIPO_PER", SqlDbType.Char).Value = dgvPersona.Item(1, x).Value
                CMD.Parameters.Add("@DESC_PER", SqlDbType.VarChar).Value = dgvPersona.Item(4, x).Value
                CMD.Parameters.Add("@NOM", SqlDbType.VarChar).Value = dgvPersona.Item(5, x).Value
                CMD.Parameters.Add("@PAT", SqlDbType.VarChar).Value = dgvPersona.Item(6, x).Value
                CMD.Parameters.Add("@MAT", SqlDbType.VarChar).Value = dgvPersona.Item(7, x).Value
                CMD.Parameters.Add("@NOM_COMERCIAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@COD_TIPO_DOC", SqlDbType.Char).Value = dgvPersona.Item(2, x).Value
                CMD.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = dgvPersona.Item(3, x).Value
                CMD.Parameters.Add("@NOM_AVAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@NRO_DOC_AVAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@DIR_AVAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@FONO_AVAL", SqlDbType.VarChar).Value = ""
                CMD.Parameters.Add("@ST_CONTRIBUYENTE", SqlDbType.Char).Value = "0"
                CMD.Parameters.Add("@ST_RETENEDOR", SqlDbType.Char).Value = "0"
                CMD.Parameters.Add("@ST_PERCEPTOR", SqlDbType.Char).Value = "0"
                CMD.ExecuteNonQuery()

                CMD.Connection = con
                CMD.CommandType = CommandType.StoredProcedure
                CMD.CommandText = "INSERTAR_CLASES"
                CMD.Transaction = trans
                CMD.Parameters.Clear()
                'Dim CMD As New SqlCommand("INSERTAR_CLASES", con, trans)
                CMD.CommandType = CommandType.StoredProcedure
                CMD.Parameters.Add("@COD_PER", SqlDbType.Char).Value = dgvPersona.Item(0, x).Value
                CMD.Parameters.Add("@COD_CLASE", SqlDbType.Char).Value = 2
                CMD.Parameters.Add("@COD_CAT", SqlDbType.Char).Value = 1
                CMD.Parameters.Add("@linea", SqlDbType.Decimal).Value = 0
                CMD.ExecuteNonQuery()
            Next
            MsgBox("Se generó correctamente " + x.ToString + " nuevos clientes", MsgBoxStyle.Information)
            trans.Commit()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Verificacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            trans.Rollback()
            con.Close()
        End Try
    End Sub

    Public Sub DOC_TRANSFERIR(ByVal FIla As Integer, ByVal TIPO As String)
        dgw_mov1.Rows.Clear()
        Try
            Dim pro_02 As New SqlCommand("COI_MOSTRAR_T_FACT_DETALLES_VTA", CON_GCO)
            pro_02.CommandType = CommandType.StoredProcedure
            pro_02.Parameters.Add("@FE_AÑO", SqlDbType.VarChar).Value = AÑO
            pro_02.Parameters.Add("@FE_MES", SqlDbType.VarChar).Value = MES
            pro_02.Parameters.Add("@COD_SUCURSAL", SqlDbType.VarChar).Value = dgw1.Item(0, FIla).Value.ToString
            pro_02.Parameters.Add("@COD_PER", SqlDbType.VarChar).Value = COD_PER
            pro_02.Parameters.Add("@NRO_DOC", SqlDbType.VarChar).Value = NRO_DOC
            pro_02.Parameters.Add("@COD_DOC", SqlDbType.VarChar).Value = COD_DOC
            pro_02.Parameters.Add("@COD_MONEDA", SqlDbType.VarChar).Value = COD_MONEDA
            pro_02.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Decimal).Value = TCAMBIO
            pro_02.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = FECHA_DOC
            pro_02.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = FECHA_VEN
            CON_GCO.Open()
            pro_02.ExecuteNonQuery()
            Dim rs2 As SqlDataReader = pro_02.ExecuteReader
            Do While rs2.Read
                dgw_mov1.Rows.Add(New Object() {(rs2.GetValue(0)), (rs2.GetValue(1)), (rs2.GetValue(2)), (rs2.GetValue(3)), (rs2.GetValue(4)), (rs2.GetValue(5)), (rs2.GetValue(6)), (rs2.GetValue(7)), (rs2.GetValue(8)), (rs2.GetValue(9)), (rs2.GetValue(10)), (rs2.GetValue(11)), (rs2.GetValue(12)), (rs2.GetValue(13)), (rs2.GetValue(14)), (rs2.GetValue(15)), (rs2.GetValue(16)), (rs2.GetValue(17)), (rs2.GetValue(18)), (rs2.GetValue(19)), (rs2.GetValue(20)), (rs2.GetValue(21)), (rs2.GetValue(22)), (rs2.GetValue(24)), (rs2.GetValue(25))})
                CUENTA_TOTAL = (rs2.GetValue(23))
            Loop
            CON_GCO.Close()
        Catch ex As Exception


            CON_GCO.Close()
            MsgBox(ex.Message)

        End Try
        If (CUENTA_TOTAL Is Nothing) Then
            CUENTA_TOTAL = ""
        End If
        Dim I As Integer = 0
        Dim CONT As Integer = (dgw_mov1.RowCount - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            If (dgw_mov1.Item(1, I).Value.ToString <> "") Then
                If dgw_mov1.Item(22, I).Value = 0 Then
                    'SIN IGV
                    dgw_mov1.Item(11, I).Value = OBJ.HALLAR_ORDEN_CUENTA2("B", AÑO, "V", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3))
                Else
                    dgw_mov1.Item(11, I).Value = OBJ.HALLAR_ORDEN_CUENTA("B", AÑO, "V", dgw_mov1.Item(1, I).Value.ToString.Substring(0, 3))
                End If
            End If
            I += 1
        Loop
    End Sub

    Private Sub CargarCompobante(ByVal sender As Object, ByVal e As EventArgs) Handles cboAuxiliar.SelectedIndexChanged
        If (cboAuxiliar.SelectedIndex <> -1) Then
            COD_AUX = OBJ.COD_AUX(cboAuxiliar.Text)
            CBO_COMPROBANTE()
        End If
    End Sub

    Public Sub CBO_AUXILIAR()
        Try
            Dim PROG_01 As New SqlCommand("CBO_AUX", con)
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            cboAuxiliar.BeginUpdate()
            Do While Rs3.Read
                cboAuxiliar.Items.Add(Rs3.GetString(0))
            Loop
            cboAuxiliar.EndUpdate()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Function VERIFICAR_CUENTA(ByVal fila As Integer) As Boolean
        SB.Remove(0, SB.Length)
        Try
            Dim i As Integer = 0
            For i = 13 To 19 Step 2
                Dim comand1 As New SqlCommand("VERIFICAR_CUENTA_TRANSF", con, trans)
                comand1.CommandType = (CommandType.StoredProcedure)
                comand1.Parameters.Add("@COD_CUENTA", SqlDbType.VarChar).Value = (DG.Item(i, fila).Value.ToString)
                comand1.Parameters.Add("@AÑO", SqlDbType.VarChar).Value = AÑO
                Dim iar As IAsyncResult = comand1.BeginExecuteReader
                Using Rs3 As SqlDataReader = comand1.EndExecuteReader(iar)
                    While Rs3.Read
                        SB.AppendLine(Rs3.GetValue(0))
                    End While
                End Using
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If (SB.Length = 0) Then
            Return True
        End If
        Return False
    End Function

    Function VALIDAR_CUENTA_ORDEN(ByVal fila As Integer) As Boolean
        SB.Remove(0, SB.Length)
        Try
            Dim i As Integer = 0
            Dim oB As String = ""
            For i = 13 To 19 Step 2
                If i = 13 Then
                    oB = "B"
                ElseIf i = 15 Then
                    oB = "B"
                ElseIf i = 17 Then
                    oB = "I"
                ElseIf i = 19 Then
                    oB = "T"
                End If
                If HALLAR_ORDEN_CUENTA(oB, AÑO, "V", DG.Item(i, fila).Value.ToString.Substring(0, 3)) = "0" Then
                    SB.AppendLine(DG.Item(i, fila).Value.ToString)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If (SB.Length = 0) Then
            Return True
        End If
        'MessageBox.Show(("No existen Orden para la Cuenta Contable : " + Environment.NewLine + SB.ToString), "No se puede Transferir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Return False
    End Function

    'Function VALIDAR_DOC() As Boolean
    '    SB.Remove(0, SB.Length)
    '    Dim _fallo As Boolean = False
    '    If VERIFICAR_REG_VENTAS(COD_DOC, NRO_DOC, COD_PER, DOC_PER) = False Then
    '        _fallo = True
    '    End If
    '    Return _fallo
    'End Function

    Private Sub CargarNumeracion(ByVal sender As Object, ByVal e As EventArgs) Handles cboComprobante.SelectedIndexChanged
        If (cboComprobante.SelectedIndex <> -1) Then
            'COD_AUX = OBJ.COD_AUX(cbo_aux.Text)
            COD_COMP = OBJ.COD_COMP(cboComprobante.Text, COD_AUX)
            Dim NUM0 As String = OBJ.HALLAR_NRO_COMP(COD_AUX, COD_COMP, AÑO, MES)
            If (NUM0 = "") Then
                MessageBox.Show("No existe numeracion para este Comprobante", "Advertencia")
            End If
            txtComprobante.Text = NUM0
            'CARGAR_PENDIENTES()
        End If
    End Sub

    Public Sub CBO_COMPROBANTE()
        cboComprobante.Items.Clear()
        Try
            Dim PROG_01 As New SqlCommand("CBO_COMPROBANTE_AUX", con)
            PROG_01.CommandType = CommandType.StoredProcedure
            PROG_01.Parameters.Add("@COD_AUX", SqlDbType.VarChar).Value = COD_AUX
            con.Open()
            PROG_01.ExecuteNonQuery()
            Dim Rs3 As SqlDataReader = PROG_01.ExecuteReader
            cboComprobante.BeginUpdate()
            Do While Rs3.Read
                cboComprobante.Items.Add(Rs3.GetString(0))
            Loop
            con.Close()
            cboComprobante.EndUpdate()
        Catch ex As Exception


            con.Close()
            MessageBox.Show(ex.Message)

        End Try
        If (cboComprobante.Items.Count = 0) Then
            MessageBox.Show("El Auxiliar elegido,no posee comprobante", "Adverntencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub ch_doc1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_doc1.CheckedChanged
        If ch_doc1.Checked Then
            dgw1.Sort(dgw1.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_doc2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ch_doc2.Checked Then
            dgw2.Sort(dgw2.Columns.Item(5), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra2.Clear()
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch_per1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch_per1.CheckedChanged
        If ch_per1.Checked Then
            dgw1.Sort(dgw1.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra1.Clear()
            btn_buscar1.Enabled = False
            btn_sgt1.Enabled = False
            txt_letra1.Focus()
        End If
    End Sub

    Private Sub ch_per2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ch_per2.Checked Then
            dgw2.Sort(dgw2.Columns.Item(7), System.ComponentModel.ListSortDirection.Ascending)
            txt_letra2.Clear()
            btn_buscar2.Enabled = False
            btn_sgt2.Enabled = False
            txt_letra2.Focus()
        End If
    End Sub

    Private Sub ch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ch1.CheckedChanged

        Dim I As Integer = 0
        Dim CONT As Integer = (dgw1.Rows.Count - 1)
        Dim CONT0 As Integer = CONT
        I = 0
        Do While (I <= CONT0)
            dgw1.Item(10, I).Value = ch1.Checked
            I += 1
        Loop

    End Sub

    Private Sub ch2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ch2.Checked Then
            Dim I As Integer = 0
            Dim CONT As Integer = (dgw2.Rows.Count - 1)
            Dim CONT0 As Integer = CONT
            I = 0
            Do While (I <= CONT0)
                dgw2.Item(10, I).Value = True
                I += 1
            Loop
        End If
    End Sub

    Private Sub BuscarFact(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscarFact.Click
        If Len(ruta) = 0 Then
            ruta = "D:"
        End If
        If Len(archFact) = 0 Then
            archFact = ""
        End If
        Dim ofd As New OpenFileDialog
        With ofd
            .InitialDirectory = ruta
            .FileName = archFact
            .Filter = "Archivos DBF (Microsoft Visual FoxPro Driver *.dbf)|*.dbf"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                archFact = IO.Path.GetFileName(.FileName)
                ruta = IO.Path.GetDirectoryName(.FileName)
                If archFact.Substring(0, 5) <> "IFAC1" Then
                    MessageBox.Show("El archivo no corresponde a los datos de facturación", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not ValidaArch(archFact) Then
                    MessageBox.Show("El archivo no corresponde a la empresa activa (" & DESC_EMPRESA & ")", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    txt_Ifac.Text = ruta + "\" + archFact
                End If
            End If
        End With

    End Sub

    Private Sub IMPORTAR_FACT_VTA_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        main(139) = 0
    End Sub

    Private Sub BuscarMov(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_BuscarMov.Click
        If Len(ruta) = 0 Then
            ruta = "D:"
        End If
        If Len(archMov) = 0 Then
            archMov = ""
        End If
        Dim ofd As New OpenFileDialog
        With ofd
            .InitialDirectory = ruta
            .FileName = archMov
            .Filter = "Archivos DBF (Microsoft Visual FoxPro Driver *.dbf)|*.dbf"

            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                archMov = IO.Path.GetFileName(.FileName)
                ruta = IO.Path.GetDirectoryName(.FileName)
                If archMov.Substring(0, 5) <> "MI_V1" Then
                    MessageBox.Show("El archivo no corresponde a los datos de la cuenta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txt_Im.Clear()
                ElseIf Not ValidaArch(archMov) Then
                    MessageBox.Show("El archivo no corresponde a la empresa activa (" & DESC_EMPRESA & ")", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    txt_Im.Text = ruta + "\" + archMov
                End If
            End If
        End With

    End Sub

    Private Function CargarDatos() As DataSet
        'Try
        Dim dst1 As New DataSet
        Dim dt As New DataTable
        Dim sb As New StringBuilder
        sb.Append("provider=Microsoft.jet.oledb.4.0;")
        sb.AppendFormat("data source={0};", ruta)
        sb.Append("extended properties=dbase III")
        Using cnn As New OleDbConnection(sb.ToString)
            'cnn.Open()
            Dim sql As String = "SELECT CDDOC,NUDOC,FEDOC,A.CDVTA,DSCTE,DSDIR,NURUC,CDMON, " & _
            "NUDIA,TPCAM,TOB_I,CDC_B,TOEXO,CDC_E,TOIGV,CDC_I,(TOB_I+TOEXO+TOIGV) AS TOTAL, " & _
            "CDC_C,NUFAC,A.FEFAC,CDDEP FROM " + archFact + " A INNER JOIN " & _
            archMov & " M ON A.CDVTA=M.CDVTA "
            Dim cmd As New OleDbCommand(sql, cnn)
            cmd.CommandType = CommandType.Text
            Dim da As New OleDbDataAdapter(sql, cnn)
            da.Fill(dt)
        End Using
        Using fs As New FileStream("c:\importar.txt", FileMode.Create, FileAccess.Write, FileShare.Write)
            Using sw As New StreamWriter(fs)
                Dim drd As DataRow
                Dim sbSW As New StringBuilder
                For Each drd In dt.Rows
                    sbSW.AppendLine(String.Format("{0};{1}", drd.Item(1), drd.Item(10)))
                Next
                sw.Write(sbSW.ToString)
            End Using
        End Using
        Dim BD As String = con.Database
        '-------------------------------------------------------------------------------------
        'CREAR LA TABLA TEMPORAL
        '-------------------------------------------------------------------------------------
        sb.Remove(0, sb.Length)
        sb.AppendLine("IF EXISTS (SELECT * FROM " & BD & ".dbo.sysobjects " & _
                "WHERE Name = 'FACT_DBF' AND TYPE = 'u')")
        sb.AppendLine("BEGIN DROP TABLE " & BD & ".dbo.FACT_DBF END")
        sb.AppendLine("CREATE TABLE FACT_DBF(")
        sb.AppendLine("CDDOC Char(2),")
        sb.AppendLine("NUDOC VarChar(20),")
        sb.AppendLine("FEDOC DATETIME,")
        sb.AppendLine("CDVTA VarChar(10),")
        sb.AppendLine("DSCTE VarChar(80),")
        sb.AppendLine("DSDIR VarChar(60),")
        sb.AppendLine("NURUC VarChar(60),")
        sb.AppendLine("CDMON VarChar(80),")
        sb.AppendLine("NUDIA INT,")
        sb.AppendLine("TPCAM decimal(13,4),")
        sb.AppendLine("TOB_I decimal(13,3),")
        sb.AppendLine("CDC_B NVarChar(80),")
        sb.AppendLine("TOEXO decimal(13,3),")
        sb.AppendLine("CDC_E NVarChar(80),")
        sb.AppendLine("TOIGV decimal(13,3),")
        sb.AppendLine("CDC_I NVarChar(80),")
        sb.AppendLine("TOTAL decimal(13,3),")
        sb.AppendLine("CDC_C NVarChar(60),")
        sb.AppendLine("NUFAC NVarChar(20),")
        sb.AppendLine("FEFAC DATETIME,")
        sb.AppendLine("CDDEP VARCHAR(5))")
        Dim cmdt As New SqlCommand(sb.ToString, con)
        cmdt.CommandType = CommandType.Text
        con.Open()
        cmdt.ExecuteNonQuery()
        con.Close()
        '-------------------------------------------------------------------------------------
        'INSERTAR LOS DATOS
        '-------------------------------------------------------------------------------------
        con.Open()
        Dim SBC As New SqlBulkCopy(con)
        SBC.DestinationTableName = "FACT_DBF"
        SBC.WriteToServer(dt)
        con.Close()

        '-------------------------------------------------------------------------------------
        'GENERAR LA CONSULTA
        '-------------------------------------------------------------------------------------
        Dim _ok As Boolean = 0
        sb.Remove(0, sb.Length)
        sb.AppendLine("DECLARE @OK BIT")
        sb.AppendLine("SET @OK=0")
        sb.AppendLine("SELECT CDDOC AS [Doc.],NUDOC AS [Nro.],FEDOC AS [F. Doc],CDVTA AS [Cdvta],")
        sb.AppendLine("'s/c' AS [Cod.],DSCTE AS [Cliente],DSDIR AS [Direccion],ISNULL(NURUC,'') AS [Ruc.], CDMON AS [M],")
        sb.AppendLine("NUDIA AS [Dia],CAST(TPCAM AS DECIMAL(13,3)) AS [T.c.],CAST(TOB_I AS DECIMAL(13,2)) AS [Importe],@OK [Ok],CDC_B AS [Cdc_b],")
        sb.AppendLine("CAST(TOEXO AS DECIMAL(13,2)) AS [Exoner.], CDC_E AS [Cdc_e], CAST(TOIGV AS DECIMAL(13,2)) AS [Igv], CDC_I AS [Cdc_i],")
        sb.AppendLine("CAST((TOB_I+TOEXO+TOIGV)AS DECIMAL(13,2)) AS Total,CDC_C AS [Cdc_c],NUFAC AS [Fac.],FEFAC AS [Fecha],CDDEP [C.C]")
        sb.AppendLine("FROM FACT_DBF WHERE YEAR(FEDOC)=@FE_AÑO AND MONTH(FEDOC)=@FE_MES")
        sb.AppendLine("ORDER BY DSCTE,NURUC")
        cmdt = New SqlCommand(sb.ToString, con)
        cmdt.CommandType = CommandType.Text
        cmdt.Parameters.Add("@FE_AÑO", SqlDbType.Char).Value = AÑO
        cmdt.Parameters.Add("@FE_MES", SqlDbType.Char).Value = MES
        Dim da1 As New SqlDataAdapter(cmdt)
        da1.Fill(dst1, "Tabla")
        Return dst1
    End Function

    Private Sub GenerarContabilidad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenera.Click
        If (cboAuxiliar.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Auxiliar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboAuxiliar.Focus()
        ElseIf (cboComprobante.SelectedIndex = -1) Then
            MessageBox.Show("Debe elegir el Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cboComprobante.Focus()
        ElseIf (txtComprobante.Text.Trim = "") Then
            MessageBox.Show("Debe insertar el Nº de Comprobante", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtComprobante.Focus()
        ElseIf (Decimal.Parse(OBJ.VALIDAR_FECHA_COMP(dtpFechaComp.Value)) = 0) Then
            dtpFechaComp.Focus()
        Else

            ActivaControl(False)
            Dim oCallBack As New AsyncCallback(AddressOf FinGrabar)
            oDelegadoGrabar.BeginInvoke(oCallBack, Nothing)
            'Grabar()
        End If
    End Sub

    Private Sub IMPORTAR_FACT_VTA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not File.Exists(archivo) Then
            MessageBox.Show("No existe el archivo de configuración de empresas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            gbBusca.Enabled = False
            gbGenerar.Enabled = False
        Else
            oXML.Load(archivo)
        End If
        TabPage2.Parent = Nothing
        Call CBO_AUXILIAR()
    End Sub

    Private Sub Btn_Consultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Consultar.Click
        If (txt_Ifac.TextLength = 0 OrElse txt_Im.TextLength = 0) Then
            MessageBox.Show("Seleccione los datos de la facturación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        ActivaControl(False)
        Try
            Dim oCallBack As New AsyncCallback(AddressOf FinLlamadaAsincrona)
            oDelegado.BeginInvoke(oCallBack, Nothing)
        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al cargar los datos" + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DG_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG.CellClick
        If e.ColumnIndex = 12 Then
            Dim cell As DataGridViewCheckBoxCell = TryCast(DG.CurrentRow.Cells(12), DataGridViewCheckBoxCell)
            cell.Value = Not cell.Value
        End If
    End Sub

    Private Sub SeleccionarTodos(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged

        Dim I, CONT As Integer
        I = 0 : CONT = DG.RowCount - 1
        While I <= CONT
            DG.Item(12, I).Value = chkTodos.Checked
            I += 1
        End While
    End Sub
End Class