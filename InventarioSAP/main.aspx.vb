Imports OfficeOpenXml
Imports OfficeOpenXml.Style
Imports System.Drawing

Public Class main
    Inherits System.Web.UI.Page
    Dim obj As New Negocio.NInventario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '================ PROCESO COOKIE =================
        UtilLog.EscribirLog(
                "main.aspx: Abrio main.aspx - CargarActivacionGeneral()")

        CargarActivacionGeneral()

        If Not IsPostBack Then

            If Session("user") IsNot Nothing Then
                'lblUsuario.Text = Session("user").ToString()

                'Registro Auditoria
                registro_acceso_pagina(Session("ACTIVACION_GENERAL").ToString(), Session("SistemaAcceso").ToString(), Session("user").ToString())

                'Proceso Normal
                Listar_inventario_activo()
                Permisos_perfil()
            End If


        End If

    End Sub

    Public Sub Permisos_perfil()
        Dim id_perfil As String
        id_perfil = Session("id_perfil").ToString()

        If id_perfil = 1 Or id_perfil = 4 Then 'Analista de Costos,  sistemas
            btnNuevoInventario.Visible = True

            'Nueva logica -- Ini
            'Dim id_estado As Integer = Session("id_estado")
            'If id_estado = 1 Then 'Inventario en Proceso
            '    'Si existe un inventario activo o en proceso, no puede darle nuevo hasta cerrarlo.
            '    btnNuevoInventario.Visible = False
            'Else
            '    btnNuevoInventario.Visible = True
            'End If
            'Nueva logica -- Fin

            If Session("id_estado") = 1 Then
                'btnCerrarInventario.Visible = True
                btnExportarExcelSAP.Visible = True
            End If
            If Session("id_estado") = 2 Then
                btnTrabajarInventario.Visible = False
                btnCerrarInventario.Visible = False
                btnExportarExcelSAP.Visible = True
            End If
        End If

        If id_perfil = 3 Then 'Inventariador 
            btnNuevoInventario.Visible = False
            btnCerrarInventario.Visible = False
            btnExportarExcelSAP.Visible = False
        End If


        If id_perfil = 2 Then 'Administrador de unida o restaurante
            btnNuevoInventario.Visible = True

            'Nueva logica -- Ini
            'Dim id_estado As Integer = Session("id_estado")
            'If id_estado = 1 Then 'Inventario en Proceso
            '    'Si existe un inventario activo o en proceso, no puede darle nuevo hasta cerrarlo.
            '    btnNuevoInventario.Visible = False
            'Else
            '    btnNuevoInventario.Visible = True
            'End If
            'Nueva logica -- Fin


            btnExportarExcelSAP.Visible = False
            If Session("id_estado") = 1 Then
                btnCerrarInventario.Visible = True
            Else
                btnCerrarInventario.Visible = False
                btnTrabajarInventario.Visible = False
            End If
        End If

    End Sub
    Public Sub Listar_inventario_activo()
        'Trae el ultimo inventario activo, sino blanco
        Dim ds As New DataSet
        Dim usuario As String
        usuario = Session("usuario")
        ds = obj.Inventario_Activo(usuario)

        Dim id_inventario As String
        Dim mensaje_inventario As String
        Dim registros_inventario As Integer
        Dim id_estado As Integer


        id_inventario = ds.Tables(0).Rows(0)(0).ToString()
        mensaje_inventario = ds.Tables(0).Rows(0)(1).ToString()
        registros_inventario = ds.Tables(0).Rows(0)(2).ToString()
        id_estado = ds.Tables(0).Rows(0)(3).ToString()

        lblmensaje_inv_activo.Text = mensaje_inventario
        lblid_inventario.Text = id_inventario
        lblcanregistros_inv.Text = registros_inventario
        Session("id_inventario") = Convert.ToInt32(id_inventario)
        Session("id_estado") = Convert.ToInt32(id_estado)
        ds.Dispose()

        'Si el id_inventario = 0, porque no tiene inventario activo
        Dim unidad As String
        If id_inventario = 0 Then
            btnNuevoInventario.Visible = True
            btnTrabajarInventario.Visible = False

            'Muestra datos de nuevo inventario - Unidad

            unidad = Session("unidad").ToString()
            lbldescunidad_Nuevo_Inv.Text = unidad

            '29/11/2023
            btnTrabajarInventario.Visible = False
            btnCerrarInventario.Visible = False
            btnExportarExcelSAP.Visible = False

        Else 'Existe Inventarioa ctivo
            unidad = Session("unidad").ToString()
            lbldescunidad_Nuevo_Inv.Text = unidad
            btnNuevoInventario.Visible = False
            btnTrabajarInventario.Visible = True


        End If



        'If id_estado = 1 Then
        '    btnExportarExcelSAP.Visible = False
        'End If

        'If id_estado = 2 Then
        '    btnTrabajarInventario.Visible = False
        '    btnExportarExcelSAP.Visible = True
        'End If

    End Sub
    Protected Sub btnNuevoInventario_Click(sender As Object, e As EventArgs) Handles btnNuevoInventario.Click
        Try
            Dim id_estado As Integer
            id_estado = Integer.Parse(Session("id_estado"))

            If id_estado = 1 Then 'En Proceso / Hay un inventario en proceso
                'Mensaje que no se puede crear porque un uno en proceso
                lblmensajex.Text = "No es posible crear un nuevo inventario mientras exista otro inventario en proceso. Por favor, finalice o cierre el inventario actual antes de continuar."
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje", "$('#myModal_Mensaje').modal('show');", True)
                Return
            Else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_busqueda", "$('#myModal_busqueda').modal();", True)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnTrabajarInventario_Click(sender As Object, e As EventArgs) Handles btnTrabajarInventario.Click

        Dim id_inventario As String
        id_inventario = lblid_inventario.Text.ToString()

        Response.Redirect("~/trabajar_inventario.aspx?dato1=" + id_inventario.ToString())

    End Sub

    Protected Sub btnAdministradorInventarios_Click(sender As Object, e As EventArgs) Handles btnAdministradorInventarios.Click

        Dim id_inventario As String
        id_inventario = lblid_inventario.Text.ToString()

        Response.Redirect("~/administrador_inventario.aspx?dato1=" + id_inventario.ToString())

    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        'En login : Session("unidad"), Session("usuario")
        Try
            Dim user As String
            Dim obs_inventario As String
            Dim cod_centro_sap As String
            Dim cierre_mes As String

            user = Session("usuario").ToString()
            obs_inventario = txtobservacion_inv.Text.ToString()
            cod_centro_sap = Session("unidad").ToString()

            If chkcierre_mes.Checked Then
                cierre_mes = "1"
            Else
                cierre_mes = "0"
            End If

            obj.Registro_Nuevo_Inventario(user, obs_inventario, cod_centro_sap, cierre_mes)
            Response.Redirect("~/main.aspx")

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnCerrarInventario_Click(sender As Object, e As EventArgs) Handles btnCerrarInventario.Click
        Dim usuario As String

        usuario = Session("usuario").ToString()
        obj.Cerrar_Inventario(Session("id_inventario"), usuario)



        'lblmensajeeliminar.Text = "Se elimino el documento de manera correcta."
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje_eliminar", "$('#myModal_Mensaje_eliminar').modal();", True)
        'Return

        'MessageBox.Show("Se elimino el documento de manera correcta.")

        Response.Redirect("~/main.aspx")
        'volver a cargar la data...


    End Sub
    Private Sub btnExportarExcelSAP_Click(sender As Object, e As EventArgs) Handles btnExportarExcelSAP.Click




        Dim ds_busqueda As New DataSet

        ds_busqueda = obj.Inventario_Exportar_Excel(Session("id_inventario"))

        Dim odt As New DataTable

        odt = ds_busqueda.Tables(0)



        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "CallFunc", "Func();", True)

        ExportarTXT(odt)




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

            'If Datos.Rows.Count = 0 Then
            '    mensajeError("No existe ninguna Evaluacion.")
            '    opcion = False
            '    Exit Sub
            'End If

            Using package = New ExcelPackage
                package.Workbook.Properties.Author = "Acurio Restaurantes"
                package.Workbook.Properties.Title = "Inventario SAP"
                Dim HojaExcel = package.Workbook.Worksheets.Add("Inventario SAP")

                HojaExcel.Name = "Inventario SAP"

                'Hoja 1 : EVALUACIONES

                Dim formatRango As ExcelRange
                'formatRango = HojaExcel.Cells(1, 1, 1, 1)
                'formatRango.Value = "Inventario SAP"
                'formatRango.Style.Font.Size = 12
                'formatRango.Style.Font.Color.SetColor(Color.Gray)

                'formatRango = HojaExcel.Cells(2, 1, 2, 8)
                'formatRango.Style.Font.Bold = True
                'formatRango.Style.Font.Size = 7
                'formatRango.Style.Fill.PatternType = ExcelFillStyle.Solid
                'formatRango.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(153, 51, 102))
                'formatRango.Style.Font.Color.SetColor(Color.White)

                'HojaExcel.Column(2).Width = 15.86

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

                'HojaExcel.Column(4).Width = 16.14


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

                'HojaExcel.Column(7).Width = 17.86

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

                'formatRango = HojaExcel.Cells(2, 9, 3, 9)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Value = "Email"

                'formatRango = HojaExcel.Cells(2, 10, 3, 10)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Menor de Edad"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 11, 3, 11)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Apoderado"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 12, 3, 12)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Bien / Servicio"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 13, 3, 13)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Monto reclamado"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 14, 3, 14)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Descripción"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 15, 3, 15)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Reclamo/Queja"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 16, 3, 16)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Detalle del reclamo"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 17, 3, 17)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Pedido del consumidor"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 18, 3, 18)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Fecha Respuesta"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 19, 3, 19)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Respuesta"
                'formatRango.Style.Border.Bottom.Style = 4

                'formatRango = HojaExcel.Cells(2, 20, 3, 20)
                'formatRango.Merge = True
                'formatRango.Style.WrapText = True
                'formatRango.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                'formatRango.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                'formatRango.Style.Border.Top.Style = 4
                'formatRango.Style.Border.Left.Style = 4
                'formatRango.Style.Border.Right.Style = 4
                'formatRango.Style.Border.Bottom.Style = 4
                'formatRango.Value = "Estado"
                'formatRango.Style.Border.Bottom.Style = 4


                'HojaExcel.Column(3).Width = 20
                'HojaExcel.Column(4).Width = 50
                'HojaExcel.Column(5).Width = 50
                'HojaExcel.Column(6).Width = 20
                'HojaExcel.Column(7).Width = 20
                'HojaExcel.Column(8).Width = 20
                'HojaExcel.Column(9).Width = 20
                'HojaExcel.Column(12).Width = 20
                'HojaExcel.Column(14).Width = 50
                'HojaExcel.Column(15).Width = 20
                'HojaExcel.Column(16).Width = 50
                'HojaExcel.Column(17).Width = 50

                'HojaExcel.Column(2).Width = 40
                'HojaExcel.Column(3).Width = 15
                'HojaExcel.Column(13).Width = 30
                'HojaExcel.Column(14).Width = 30
                'HojaExcel.Column(15).Width = 30
                'HojaExcel.Column(16).Width = 30
                'HojaExcel.Column(17).Width = 30
                'HojaExcel.Column(18).Width = 10

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
                    'HojaExcel.Cells(y, 9).Value = CStr(x(8).ToString)
                    'HojaExcel.Cells(y, 10).Value = CStr(x(9).ToString)
                    'HojaExcel.Cells(y, 11).Value = CStr(x(10).ToString)
                    'HojaExcel.Cells(y, 12).Value = CStr(x(11).ToString)
                    'HojaExcel.Cells(y, 13).Value = CStr(x(12).ToString)
                    'HojaExcel.Cells(y, 14).Value = CStr(x(13).ToString)
                    'HojaExcel.Cells(y, 15).Value = CStr(x(14).ToString)
                    'HojaExcel.Cells(y, 16).Value = CStr(x(15).ToString)
                    'HojaExcel.Cells(y, 17).Value = CStr(x(16).ToString)
                    'HojaExcel.Cells(y, 18).Value = CStr(x(17).ToString)
                    'HojaExcel.Cells(y, 19).Value = CStr(x(18).ToString)
                    'HojaExcel.Cells(y, 20).Value = CStr(x(19).ToString)


                Next


                'formatRango.Style.Font.Bold = True
                formatRango.Worksheet.View.ShowGridLines = False


                Response.BinaryWrite(package.GetAsByteArray())
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                'Response.AddHeader("Content-Disposition", "attachment; filename=LibroReclamaciones_RGeneral.xlsx")
                Response.AddHeader("Content-Disposition", "attachment; filename=InventarioSAP_RGeneral.csv")
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
    Public Sub mensajeError(ByVal msj As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertIns", "alert('" & msj & "');", True)
    End Sub

    Protected Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        CerrarSesion_ActivacionGeneral()

        Dim cogeCookie = Request.Cookies.Get("appNameAuth")
        If Not cogeCookie Is Nothing Then
            Request.Cookies.Remove("appNameAuth")
        End If

        FormsAuthentication.SignOut() 'ahora si cierras session!!!
        Session.Abandon()
        Session.Clear()
        Response.Redirect("main.aspx")
    End Sub

    Protected Sub btnExcelInventariados_Click(sender As Object, e As EventArgs) Handles btnExcelInventariados.Click
        Dim id_inventario As Integer
        Dim ds As New DataSet()
        Dim odt As New DataTable()
        id_inventario = Integer.Parse(lblid_inventario.Text.ToString())
        ds = obj.Lista_inventariados_Excel(id_inventario)

        If ds.Tables(0).Rows.Count > 0 Then
            odt = ds.Tables(0)

            ExportarExcel_Inventariados(odt)

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

                formatRango = HojaExcel.Cells(2, 1, 2, 9)
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




                HojaExcel.Column(1).Width = 30
                HojaExcel.Column(2).Width = 30
                HojaExcel.Column(3).Width = 30
                HojaExcel.Column(4).Width = 30
                HojaExcel.Column(5).Width = 30
                HojaExcel.Column(6).Width = 30
                HojaExcel.Column(7).Width = 30
                HojaExcel.Column(8).Width = 30
                HojaExcel.Column(9).Width = 30



                Dim y As Integer = 3

                formatRango = HojaExcel.Cells(y + 1, 1, 1 + (y + Datos.Rows.Count - 1), 9)
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
        obj.Registro_SesionSistema(TokenGlobal, user, sistema, "main.aspx")
    End Sub

End Class