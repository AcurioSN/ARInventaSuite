Imports System.IO

Public Class UtilLog
    Public Shared Sub EscribirLog(mensaje As String)

        Try

            Dim carpeta As String = HttpContext.Current.Server.MapPath("~/Logs")

            If Not Directory.Exists(carpeta) Then
                Directory.CreateDirectory(carpeta)
            End If

            Dim archivo As String =
                Path.Combine(carpeta,
                             "Log_" & DateTime.Now.ToString("yyyyMMdd") & ".txt")

            Dim linea As String =
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                " | " &
                mensaje

            File.AppendAllText(archivo, linea & Environment.NewLine)

        Catch ex As Exception
            'Nunca detener la aplicación por un error de log
        End Try

    End Sub
End Class
