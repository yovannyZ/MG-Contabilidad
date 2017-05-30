<Serializable()> Public Class LogUsuario

    Enum TipoLog
        Critico = 0
        Aviso = 2
        Informacion = 1
    End Enum

    Enum ModuloOrigen
        Administracion = 0
        Bancos = 1
        Contabilidad = 2
    End Enum

    Private _descripcion As String
    Private _modulo As ModuloOrigen
    Private _tipoLog As TipoLog
    Private _fechaLog As DateTime
    Private _usuario As String
    Private _nombrePc As String

    Public Property Tipo() As TipoLog
        Get
            Return _tipoLog
        End Get
        Set(ByVal value As TipoLog)
            _tipoLog = value
        End Set
    End Property

    Public Property Modulo() As ModuloOrigen
        Get
            Return _modulo
        End Get
        Set(ByVal value As ModuloOrigen)
            _modulo = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property FechaLog() As DateTime
        Get
            Return _fechaLog
        End Get
        Set(ByVal value As DateTime)
            _fechaLog = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Public Property NombrePc() As String
        Get
            Return _nombrePc
        End Get
        Set(ByVal value As String)
            _nombrePc = value
        End Set
    End Property

    Public Sub New(ByVal moduloOrigen As ModuloOrigen, ByVal descripcionMensaje As String, ByVal tipoLog As TipoLog)
        _descripcion = descripcionMensaje
        _tipoLog = tipoLog
        _modulo = moduloOrigen
        _fechaLog = Now
        _usuario = DESC_USU
        _nombrePc = NOMBRE_PC
    End Sub

End Class
