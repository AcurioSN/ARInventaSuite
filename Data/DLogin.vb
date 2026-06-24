Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections.Specialized
Imports System.Web
Imports System.Text
Imports System.IO
Public Class DLogin
    Public Function valida_credenciales(ByVal user As String) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_valida_credenciales"

        cmd.Parameters.Add("@user", SqlDbType.VarChar)
        cmd.Parameters(0).Value = user


        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function configuracion_recaptcha() As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arsancion_configuracion_recaptcha"



        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

End Class
