Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.Drawing
Public Class busqueda_inventario
    Inherits System.Web.UI.Page
    Dim obj As New Negocio.NInventario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '================ PROCESO COOKIE =================
        UtilLog.EscribirLog(
                "administrador_inventario.aspx: Abrio administrador_inventario.aspx - CargarActivacionGeneral()")

        CargarActivacionGeneral()

        If Not IsPostBack Then

            If Session("user") IsNot Nothing Then

                'Proceso Normal
                Dim id_inventario As Integer = Integer.Parse(Request.QueryString("dato1"))
                lblid_inventario.Text = id_inventario.ToString()
                carga_detalle(id_inventario)
                carga_anio(id_inventario)

                'Registro Auditoria
                registro_acceso_pagina(Session("ACTIVACION_GENERAL").ToString(), Session("SistemaAcceso").ToString(), Session("user").ToString())


            End If


        End If

    End Sub

    Public Sub carga_detalle(ByVal id_inventario As Integer)
        'Muestra datos de inventario
        Dim ds As New DataSet()
        ds = obj.Listar_Mes()

        'Lista zonas del inventario pero de la unidad
        cbomes.DataSource = ds.Tables(0)
        cbomes.DataValueField = "id_mes"
        cbomes.DataTextField = "desc_mes"
        cbomes.DataBind()


        Session("ds_detalle") = ds
        ds.Dispose()
    End Sub

    Public Sub carga_anio(ByVal id_inventario As Integer)
        'Muestra datos de inventario
        Dim ds As New DataSet()
        Dim dsA As New DataSet()
        ds = obj.Listar_Anio()

        'Lista zonas del inventario pero de la unidad
        cboanio.DataSource = ds.Tables(0)
        cboanio.DataValueField = "id_anio"
        cboanio.DataTextField = "desc_anio"
        cboanio.DataBind()


        Session("ds_detalle") = ds
        ds.Dispose()
    End Sub

    'Private Sub btnBuscarInventario_Click(sender As Object, e As EventArgs) Handles btnBuscarInventario.Click
    '    Buscar_productos()
    'End Sub
    Private Sub btnBuscarInventario2_Click(sender As Object, e As EventArgs) Handles btnBuscarInventario2.Click
        Buscar_productos()
    End Sub

    Public Sub Buscar_productos()
        Dim id_mes As Integer
        Dim id_anio As Integer

        Dim ds As New DataSet()

        id_mes = Integer.Parse(cbomes.SelectedValue.ToString())
        id_anio = Integer.Parse(cboanio.SelectedValue.ToString())

        ds = obj.Lista_inventariox_mes(Session("usuario").ToString(), id_mes, id_anio)
        Session("ds_detalle_inventariados") = ds
        grvinventariados.DataSource = ds.Tables(0)
        grvinventariados.DataBind()


    End Sub

    Private Sub grvinventariados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvinventariados.RowCommand
        Dim id_inventario As Integer
        id_inventario = (e.CommandArgument).ToString()

        If e.CommandName = "modificar" Then

            Dim ds_busqueda As New DataSet

            ds_busqueda = obj.Inventario_Exportar_Excel(id_inventario)

            Dim odt As New DataTable

            odt = ds_busqueda.Tables(0)

            ExportarTXT(odt)



        End If
        If e.CommandName = "excel" Then
            Dim ds As New DataSet()
            Dim odt As New DataTable()

            ds = obj.Lista_inventariados_Excel(id_inventario)

            If ds.Tables(0).Rows.Count > 0 Then
                odt = ds.Tables(0)

                ExportarExcel_Inventariados(odt)

            End If


        End If
    End Sub
    Public Sub ExportarExcel_Inventariados(ByVal odt As DataTable)
        Dim opcion As Boolean = True
        Dim Unidad As String
        Dim fase As String
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet
        Dim Datos As New DataTable

        Try

            Datos = odt

            Using package = New ExcelPackage
                package.Workbook.Properties.Author = "Acurio Restaurantes"
                package.Workbook.Properties.Title = "Inventariados"
                Dim HojaExcel = package.Workbook.Worksheets.Add("Inventariados")

                HojaExcel.Name = "Inventario"

                'Hoja 1 : EVALUACIONES

                Dim formatRango As ExcelRange
                formatRango = HojaExcel.Cells(1, 1, 1, 1)
                formatRango.Value = "Inventario"
                formatRango.Style.Font.Size = 12
                formatRango.Style.Font.Color.SetColor(Color.Gray)

                formatRango = HojaExcel.Cells(2, 1, 2, 10)
                formatRango.Style.Font.Bold = True
                formatRango.Style.Font.Size = 7
                formatRango.Style.Fill.PatternType = ExcelFillStyle.Solid
                formatRango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(153, 51, 102))
                formatRango.Style.Font.Color.SetColor(Color.White)

                HojaExcel.Column(2).Width = 15.86

                formatRango = HojaExcel.Cells(2, 1, 3, 1)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Obs. Inventario"

                formatRango = HojaExcel.Cells(2, 2, 3, 2)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Cod. Centro SAP"

                formatRango = HojaExcel.Cells(2, 3, 3, 3)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Cod. Almacén SAP"


                formatRango = HojaExcel.Cells(2, 4, 3, 4)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Cod. Producto"

                'HojaExcel.Column(4).Width = 16.14


                formatRango = HojaExcel.Cells(2, 5, 3, 5)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Descripción Producto"

                formatRango = HojaExcel.Cells(2, 6, 3, 6)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Cantidad"

                'HojaExcel.Column(7).Width = 17.86

                formatRango = HojaExcel.Cells(2, 7, 3, 7)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Unidad Medida"

                formatRango = HojaExcel.Cells(2, 8, 3, 8)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Usuario"

                formatRango = HojaExcel.Cells(2, 9, 3, 9)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Value = "Fecha Creación"

                formatRango = HojaExcel.Cells(2, 10, 3, 10)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Value = "Almacén"




                HojaExcel.Column(1).Width = 30
                HojaExcel.Column(2).Width = 30
                HojaExcel.Column(3).Width = 30
                HojaExcel.Column(4).Width = 30
                HojaExcel.Column(5).Width = 30
                HojaExcel.Column(6).Width = 30
                HojaExcel.Column(7).Width = 30
                HojaExcel.Column(8).Width = 30
                HojaExcel.Column(9).Width = 30
                HojaExcel.Column(10).Width = 30



                Dim y As Integer = 3

                formatRango = HojaExcel.Cells(y + 1, 1, 1 + (y + Datos.Rows.Count - 1), 10)
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Font.Size = 7
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4

                For Each x In Datos.Rows
                    y = y + 1
                    HojaExcel.Cells(y, 1).Value = CStr(x(0).ToString)
                    HojaExcel.Cells(y, 2).Value = CStr(x(1).ToString)
                    HojaExcel.Cells(y, 3).Value = CStr(x(2).ToString)
                    HojaExcel.Cells(y, 4).Value = CStr(x(3).ToString)
                    HojaExcel.Cells(y, 5).Value = CStr(x(4).ToString)
                    HojaExcel.Cells(y, 6).Value = CStr(x(5).ToString)
                    HojaExcel.Cells(y, 7).Value = CStr(x(6).ToString)
                    HojaExcel.Cells(y, 8).Value = CStr(x(7).ToString)
                    HojaExcel.Cells(y, 9).Value = CStr(x(8).ToString)
                    HojaExcel.Cells(y, 10).Value = CStr(x(9).ToString)

                Next


                'formatRango.Style.Font.Bold = True
                formatRango.Worksheet.View.ShowGridLines = False


                Response.BinaryWrite(package.GetAsByteArray())
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("Content-Disposition", "attachment; filename=InventariadosAR.xlsx")
                'Response.AddHeader("Content-Disposition", "attachment; filename=LibroReclamaciones_RGeneral.csv")
            End Using
        Catch ex As Exception
            mensajeError(ex.Message & " - ExportarExcel")
        Finally
            If opcion Then
                Response.End()
                Response.Flush()
            End If
        End Try
    End Sub

    Private Sub btnExportarExcelSAP_Click(sender As Object, e As EventArgs) Handles btnExportarExcelSAP.Click
        Dim ds_busqueda As New DataSet

        ds_busqueda = obj.Inventario_Exportar_Excel(Session("id_inventario"))

        Dim odt As New DataTable

        odt = ds_busqueda.Tables(0)

        ExportarTXT(odt)


    End Sub

    Public Sub ExportarExcel(ByVal odt As DataTable)
        Dim opcion As Boolean = True
        Dim Unidad As String
        Dim fase As String
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet
        Dim Datos As New DataTable

        Try

            Datos = odt

            Using package = New ExcelPackage
                package.Workbook.Properties.Author = "Acurio Restaurantes"
                package.Workbook.Properties.Title = "Inventario SAP"
                Dim HojaExcel = package.Workbook.Worksheets.Add("Inventario SAP")

                HojaExcel.Name = "Inventario SAP"


                Dim formatRango As ExcelRange

                formatRango = HojaExcel.Cells(1, 1, 1, 1)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "fecha_conteo"

                formatRango = HojaExcel.Cells(1, 2, 1, 2)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "anio_conteo"

                formatRango = HojaExcel.Cells(1, 3, 1, 3)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Centro"


                formatRango = HojaExcel.Cells(1, 4, 1, 4)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "Almacén"



                formatRango = HojaExcel.Cells(1, 5, 1, 5)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "cantidad"

                formatRango = HojaExcel.Cells(1, 6, 1, 6)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "material"


                formatRango = HojaExcel.Cells(1, 7, 1, 7)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "estado"

                formatRango = HojaExcel.Cells(1, 8, 1, 8)
                formatRango.Merge = True
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4
                formatRango.Value = "unida_medida"


                Dim y As Integer = 1

                formatRango = HojaExcel.Cells(y + 1, 1, 1 + (y + Datos.Rows.Count - 1), 8)
                formatRango.Style.WrapText = True
                formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                formatRango.Style.Font.Size = 7
                formatRango.Style.Border.Top.Style = 4
                formatRango.Style.Border.Left.Style = 4
                formatRango.Style.Border.Right.Style = 4
                formatRango.Style.Border.Bottom.Style = 4

                For Each x In Datos.Rows
                    y = y + 1
                    HojaExcel.Cells(y, 1).Value = CStr(x(0).ToString)
                    HojaExcel.Cells(y, 2).Value = CStr(x(1).ToString)
                    HojaExcel.Cells(y, 3).Value = CStr(x(2).ToString)
                    HojaExcel.Cells(y, 4).Value = CStr(x(3).ToString)
                    HojaExcel.Cells(y, 5).Value = CStr(x(4).ToString)
                    HojaExcel.Cells(y, 6).Value = CStr(x(5).ToString)
                    HojaExcel.Cells(y, 7).Value = CStr(x(6).ToString)
                    HojaExcel.Cells(y, 8).Value = CStr(x(7).ToString)


                Next


                formatRango.Worksheet.View.ShowGridLines = False


                Response.BinaryWrite(package.GetAsByteArray())
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("Content-Disposition", "attachment; filename=InventarioSAP_RGeneral.CSV")
            End Using
        Catch ex As Exception
            mensajeError(ex.Message & " - ExportarExcel")
        Finally
            If opcion Then
                Response.End()
                Response.Flush()
            End If
        End Try
    End Sub

    Public Sub ExportarTXT(ByVal odt As DataTable)
        Dim opcion As Boolean = True
        Dim Unidad As String
        Dim fase As String
        Dim ds As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet
        Dim Datos As New DataTable

        Try

            Datos = odt

            Dim texto As New StringBuilder()

            ' Agregar una línea en blanco al inicio
            'texto.AppendLine()

            ' Agregar la cabecera
            texto.AppendLine("FECHA,ANO,CENTRO,ALMACEN,CANTIDAD,MATERIAL,ESTADO,UMEDIDA")

            ' Escribir los datos
            For Each fila As DataRow In Datos.Rows
                For Each item As Object In fila.ItemArray
                    texto.Append(item.ToString().Trim() & ",")
                Next
                texto.Append(Environment.NewLine)
            Next

            ' Configurar la respuesta HTTP
            Response.Clear()
            Response.ContentType = "text/plain"
            Response.AddHeader("content-disposition", "attachment;filename=InventarioSAP_RGeneral.txt")

            ' Escribir el texto en la respuesta
            Response.Write(texto.ToString())

            ' Enviar el archivo al cliente
            Response.End()

        Catch ex As Exception
            mensajeError(ex.Message & " - ExportarExcel")
        Finally
            If opcion Then
                Response.End()
                Response.Flush()
            End If
        End Try
    End Sub

    Public Sub mensajeError(ByVal msj As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertIns", "alert('" & msj & "');", True)
    End Sub

    Public Sub CerrarSesion_ActivacionGeneral()

        obj.CerrarSesionGlobal(Session("ACTIVACION_GENERAL").ToString())


        '================ PROCESO COOKIE =================
        'Session.Abandon()

        'Dim ck As New HttpCookie("ACTIVACION_GENERAL")
        'ck.Expires = DateTime.Now.AddDays(-1)

        'Response.Cookies.Add(ck)
    End Sub


    Public Function CargarActivacionGeneral() As Boolean

        Dim token As String = String.Empty
        Dim ds As New DataSet
        If Session("ACTIVACION_GENERAL") IsNot Nothing Then
            token = Session("ACTIVACION_GENERAL").ToString()

            ds = obj.ExisteTokenActivo(token)
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Response.Redirect("~/SesionExpirada.aspx", False)
                Return False
            End If
        Else
            Response.Redirect("~/SesionExpirada.aspx")
            Return False
        End If


    End Function
    Public Sub registro_acceso_pagina(ByVal TokenGlobal As String, ByVal sistema As String, ByVal user As String)
        obj.Registro_SesionSistema(TokenGlobal, user, sistema, "administrador_inventario.aspx")
    End Sub

    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        CerrarSesion_ActivacionGeneral()

        Dim cogeCookie = Request.Cookies.Get("appNameAuth")
        If Not cogeCookie Is Nothing Then
            Request.Cookies.Remove("appNameAuth")
        End If

        FormsAuthentication.SignOut() 'ahora si cierras session!!!
        Session.Abandon()
        Session.Clear()
        Response.Redirect("administrador_inventario.aspx")
    End Sub
End Class