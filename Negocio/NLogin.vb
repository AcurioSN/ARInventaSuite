Imports Data
Public Class NLogin
    Dim obj As New Data.DLogin
    Public Function valida_credenciales(ByVal user As String) As DataSet
        Dim ds As New DataSet
        ds = obj.valida_credenciales(user)
        Return ds
    End Function
    Public Function configuracion_recaptcha() As DataSet
        Dim ds As New DataSet
        ds = obj.configuracion_recaptcha()
        Return ds
    End Function

End Class
