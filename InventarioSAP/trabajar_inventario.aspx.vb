Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.Security
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Collections
Imports System.Drawing.Drawing2D
Imports System.Data.OleDb
Imports System.Net
Imports System.Configuration
Imports System.Drawing
Imports iTextSharp.text.pdf
Imports Font = iTextSharp.text.Font
Public Class trabajar_inventario
    Inherits System.Web.UI.Page
    Dim obj As New Negocio.NInventario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '================ PROCESO COOKIE =================
        UtilLog.EscribirLog(
                "inventariados.aspx: Abrio inventariados.aspx - CargarActivacionGeneral()")

        CargarActivacionGeneral()

        If Not IsPostBack Then

            If Session("user") IsNot Nothing Then

                'Proceso Normal
                Dim id_inventario As Integer = Integer.Parse(Request.QueryString("dato1"))
                lblid_inventario.Text = id_inventario.ToString()
                carga_detalle(id_inventario)
                'detalle_documento(id_documento)
                'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", True)

                If Session("indicador_fec_vencim") IsNot Nothing AndAlso Convert.ToBoolean(Session("indicador_fec_vencim")) = True Then
                    phFechaVencimiento.Visible = True
                Else
                    phFechaVencimiento.Visible = False
                End If

                productos_todos()

                'Registro Auditoria
                registro_acceso_pagina(Session("ACTIVACION_GENERAL").ToString(), Session("SistemaAcceso").ToString(), Session("user").ToString())


            End If


        End If


    End Sub

    Public Sub carga_detalle(ByVal id_inventario As Integer)
        'Muestra datos de inventario
        Dim ds As New DataSet()
        ds = obj.Inventario_Detalle(id_inventario)
        lblmensaje_inv_activo_d.Text = ds.Tables(0).Rows(0)(1).ToString()
        lblcanregistros_inv_d.Text = ds.Tables(0).Rows(0)(2).ToString()

        'Lista zonas del inventario pero de la unidad
        cbozona.DataSource = ds.Tables(1)
        cbozona.DataValueField = "almacen"
        cbozona.DataTextField = "descrip_almacen"
        cbozona.DataBind()

        'Lista zonas del inventario pero de la unidad - Popup Inventariados
        cbozona2.DataSource = ds.Tables(1)
        cbozona2.DataValueField = "almacen"
        cbozona2.DataTextField = "descrip_almacen"
        cbozona2.DataBind()

        cboestado_stock.DataSource = ds.Tables(2)
        cboestado_stock.DataValueField = "id_estado"
        cboestado_stock.DataTextField = "desc_estado"
        cboestado_stock.DataBind()
        cboestado_stock.SelectedIndex = 0

        Session("ds_detalle") = ds
        ds.Dispose()
    End Sub

    Protected Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        'Buscar_productos()
        Buscar_productos_todos()
    End Sub
    Protected Sub btnBuscarProducto2_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto2.Click
        'Buscar_productos()
        Buscar_productos_todos()
    End Sub
    Public Sub Buscar_productos()
        Dim unidad As String
        'Dim zona As String
        Dim cod_producto As String
        Dim desc_producto As String
        Dim ds As New DataSet

        unidad = Session("unidad").ToString()
        'zona = cbozona.SelectedValue.ToString()

        cod_producto = txtcodigo_producto.Text
        desc_producto = txtdesc_producto.Text

        ds = obj.Lista_Productos_centro_almacen(unidad, cod_producto, desc_producto)

        If ds.Tables(0).Rows.Count = 1 Then
            grvProductos.DataSource = ds.Tables(0)
            grvProductos.DataBind()
            ds.Dispose()
            listar_unico_producto(ds)
        Else
            grvProductos.DataSource = ds.Tables(0)
            grvProductos.DataBind()
            ds.Dispose()
        End If






    End Sub
    Public Sub productos_todos()
        Dim ds As New DataSet
        Dim unidad As String

        unidad = Session("unidad").ToString()
        ds = obj.Lista_Productos_centro_almacen_todos(unidad)
        Session("lista_productos") = ds
    End Sub
    Public Sub Buscar_productos_todos()
        Dim unidad As String
        Dim cod_producto As String
        Dim desc_producto As String

        unidad = Session("unidad").ToString()
        cod_producto = txtcodigo_producto.Text.Trim()
        desc_producto = txtdesc_producto.Text.Trim().ToLower()

        If Session("lista_productos") IsNot Nothing Then
            Dim ds As DataSet = CType(Session("lista_productos"), DataSet)
            Dim dt As DataTable = ds.Tables(0)

            ' LINQ
            Dim resultados = From row In dt.AsEnumerable()
                             Where (row.Field(Of String)("centro") = unidad) AndAlso
                               (cod_producto = "" OrElse row.Field(Of String)("material").Contains(cod_producto)) AndAlso
                               (desc_producto = "" OrElse row.Field(Of String)("Descripcion_material").ToLower().Contains(desc_producto))
                             Select row

            ' Verificar si hay resultados
            If resultados.Any() Then
                Dim dtFiltrado As DataTable = resultados.CopyToDataTable()
                Dim dsFiltrado As New DataSet()
                dsFiltrado.Tables.Add(dtFiltrado) ' Convertir DataTable a DataSet

                grvProductos.DataSource = dtFiltrado
                grvProductos.DataBind()


                If dtFiltrado.Rows.Count = 1 Then
                    listar_unico_producto(dsFiltrado)
                End If
            Else

                grvProductos.DataSource = Nothing
                grvProductos.DataBind()
            End If
        Else

            grvProductos.DataSource = Nothing
            grvProductos.DataBind()
        End If
    End Sub



    'Private Sub cbounidad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbounidad.SelectedIndexChanged
    '    'Buscar_productos()
    'End Sub

    Private Sub grvProductos_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grvProductos.RowDataBound
        e.Row.Attributes("onmouseover") = "this.style.backgroundColor='#EFEEEE'"
        e.Row.Attributes("onmouseout") = "this.style.backgroundColor='white'"
    End Sub

    Private Sub cbozona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbozona.SelectedIndexChanged
        ' Buscar_productos()
    End Sub

    Public Sub listar_unico_producto(ByVal dt As DataSet)

        Dim cod_producto As String

        cod_producto = dt.Tables(0).Rows(0)(1).ToString()



        lblcodigo_producto.Text = dt.Tables(0).Rows(0)(1).ToString()
        lbldesc_producto.Text = dt.Tables(0).Rows(0)(2).ToString() '23022025
        lblunidad_medida.Text = dt.Tables(0).Rows(0)(3).ToString() '23022025

        Dim ds As New DataSet()
        'ds = obj.Lista_producto_unidades_medida(cod_producto.ToString())
        ds = obj.Lista_producto_equivalencia_umb(cod_producto.ToString())


        If ds.Tables(0).Rows.Count > 0 Then

            ' Crear nueva fila
            Dim fila As DataRow = ds.Tables(0).NewRow()
            fila("UM") = dt.Tables(0).Rows(0)(3).ToString()   ' Texto que quieres mostrar
            fila("FC") = "1-1"               ' Valor fijo (puedes cambiarlo)

            ' Insertar como primera fila
            ds.Tables(0).Rows.InsertAt(fila, 0)

            ' Enlazar al combo
            cbounidades_medida.DataSource = ds.Tables(0)
            cbounidades_medida.DataTextField = "UM"
            cbounidades_medida.DataValueField = "FC"
            cbounidades_medida.DataBind()

            lblUM.Visible = True
            cbounidades_medida.Visible = True

        Else

            lblUM.Visible = False
            cbounidades_medida.Visible = False

        End If




        'If ds.Tables(0).Rows.Count > 0 Then
        '    cbounidades_medida.DataSource = ds.Tables(0)
        '    cbounidades_medida.DataTextField = "UM"
        '    cbounidades_medida.DataValueField = "FC"
        '    cbounidades_medida.DataBind()
        'End If

        'If ds.Tables(0).Rows.Count = 1 Then

        '    lblUM.Visible = False
        '    cbounidades_medida.Visible = False

        'Else
        '    lblUM.Visible = True
        '    cbounidades_medida.Visible = True
        'End If

        If cbozona.SelectedIndex <> 0 Then
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_busqueda", "$('#myModal_busqueda').modal();", True)
        Else
            lblmensaje.Text = "Favor de seleccionar el almacén en donde inventariará el producto seleccionado."
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje", "$('#myModal_Mensaje').modal();", True)
            Return
        End If




    End Sub

    Private Sub grvProductos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvProductos.RowCommand
        If e.CommandName = "inventariar" Then
            Dim material As String
            Dim cod_producto As String = ""
            Dim desc_producto As String = ""
            Dim unidad_medida As String = ""

            material = (e.CommandArgument).ToString()

            For Each gvClaserow As GridViewRow In grvProductos.Rows
                Dim lblcod_producto As Label
                Dim lbldesc_material As Label
                Dim lblunidad_medida As Label
                lblcod_producto = gvClaserow.FindControl("lblcod_producto")
                lbldesc_material = gvClaserow.FindControl("lbldesc_material")
                lblunidad_medida = gvClaserow.FindControl("lblunidad_medida")



                If material = lblcod_producto.Text Then
                    cod_producto = lblcod_producto.Text
                    desc_producto = lbldesc_material.Text
                    unidad_medida = lblunidad_medida.Text
                    Exit For
                End If
            Next

            lblcodigo_producto.Text = cod_producto.ToString()
            lbldesc_producto.Text = desc_producto.ToString()
            lblunidad_medida.Text = unidad_medida.ToString()

            Dim ds As New DataSet()

            ds = obj.Lista_producto_equivalencia_umb(cod_producto.ToString())

            If ds.Tables(0).Rows.Count > 0 Then

                ' Crear nueva fila
                Dim fila As DataRow = ds.Tables(0).NewRow()
                fila("UM") = unidad_medida.ToString()    ' Texto que quieres mostrar
                fila("FC") = "1-1"               ' Valor fijo (puedes cambiarlo)

                ' Insertar como primera fila
                ds.Tables(0).Rows.InsertAt(fila, 0)

                ' Enlazar al combo
                cbounidades_medida.DataSource = ds.Tables(0)
                cbounidades_medida.DataTextField = "UM"
                cbounidades_medida.DataValueField = "FC"
                cbounidades_medida.DataBind()

                lblUM.Visible = True
                cbounidades_medida.Visible = True

            Else

                lblUM.Visible = False
                cbounidades_medida.Visible = False

            End If


            'If ds.Tables(0).Rows.Count > 0 Then
            '    cbounidades_medida.DataSource = ds.Tables(0)
            '    cbounidades_medida.DataTextField = "UM"
            '    cbounidades_medida.DataValueField = "FC"
            '    cbounidades_medida.DataBind()
            'End If

            'If ds.Tables(0).Rows.Count = 1 Then

            '    lblUM.Visible = False
            '    cbounidades_medida.Visible = False

            'Else
            '    lblUM.Visible = True
            '    cbounidades_medida.Visible = True
            'End If

            If cbozona.SelectedIndex <> 0 Then
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_busqueda", "$('#myModal_busqueda').modal();", True)
            Else
                lblmensaje.Text = "Favor de seleccionar el almacén en donde inventariará el producto seleccionado."
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje", "$('#myModal_Mensaje').modal();", True)
                Return
            End If



        End If
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            'Threading.Thread.Sleep(10000) ''para realizar pruebas 
            Dim id_inventario As Integer
            Dim cod_prod_sap As String
            Dim desc_prod_det As String
            Dim cod_um_det_invent As String
            Dim desc_um_det_invent As String
            Dim cant_prod_det_invent As Decimal = 0 '13052026 IVa
            Dim cod_almacen_sap As String
            Dim id_estado_stock As Integer
            Dim fecha_vencimiento As Nullable(Of DateTime) = Nothing
            Dim can_original As Decimal = 0 '14/05/2026 IVM
            Dim um_alternativa_conversion As String = ""

            id_inventario = Integer.Parse(lblid_inventario.Text)
            cod_prod_sap = lblcodigo_producto.Text.ToString()
            desc_prod_det = lbldesc_producto.Text.ToString()
            cod_um_det_invent = lblunidad_medida.Text.ToString()
            desc_um_det_invent = ""

            If String.IsNullOrWhiteSpace(txtcantidad.Text) Then
                Return
            End If

            If Not Decimal.TryParse(txtcantidad.Text, can_original) Then
                Return
            End If
            cant_prod_det_invent = txtcantidad.Text.ToString()

            cod_almacen_sap = cbozona.SelectedValue.ToString()
            id_estado_stock = Integer.Parse(cboestado_stock.SelectedValue.ToString())
            'If Not String.IsNullOrWhiteSpace(txtfecha_vencimiento.Text) Then
            '    fecha_vencimiento = DateTime.Parse(txtfecha_vencimiento.Text)
            'End If
            If Not String.IsNullOrWhiteSpace(txtfecha_vencimiento.Text) Then

                Dim fechaTemp As DateTime

                If DateTime.TryParse(txtfecha_vencimiento.Text, fechaTemp) Then
                    fecha_vencimiento = fechaTemp
                End If

            End If
            If cod_prod_sap = "" Then
                Return
            End If

            Dim fc As Decimal
            Dim factor As String
            Dim UMREN As Decimal
            Dim UMREZ As Decimal

            'Capturamos los valores originales
            'Actualmente guarda la unidad de medida original y la cantidad transformada, no la alternativa

            '14/05/2026 IVM
            'um_alternativa_conversion = cbounidades_medida.SelectedItem.Text.ToString() 'La unidad de medida elegida para conversión
            If cbounidades_medida.SelectedItem IsNot Nothing Then
                um_alternativa_conversion = cbounidades_medida.SelectedItem.Text
            Else
                um_alternativa_conversion = ""
            End If

            can_original = Decimal.Parse(txtcantidad.Text)


            If cbounidades_medida.Items.Count > 0 Then

                factor = cbounidades_medida.SelectedValue.ToString()

                ' Supongamos que el valor es '22-1'
                Dim partes() As String = factor.Split("-"c)

                Dim parte1 As String = partes(0)
                Dim parte2 As String = partes(1)

                UMREN = Decimal.Parse(parte1)
                UMREZ = Decimal.Parse(parte2)




                cant_prod_det_invent = (cant_prod_det_invent * UMREZ) / UMREN

                ' 🔽 Redondear a 3 decimales aritméticamente
                cant_prod_det_invent = Math.Round(cant_prod_det_invent, 3, MidpointRounding.AwayFromZero)

            End If

            obj.Registra_Producto_Inventario(id_inventario, cod_prod_sap, desc_prod_det, cod_um_det_invent, desc_um_det_invent,
                                            cant_prod_det_invent, cod_almacen_sap, Session("usuario").ToString(), id_estado_stock, fecha_vencimiento, um_alternativa_conversion, can_original)



            'Actualiza mensaje de cabecera
            Dim ds As New DataSet()
            ds = obj.Inventario_Detalle(id_inventario)
            lblmensaje_inv_activo_d.Text = ds.Tables(0).Rows(0)(1).ToString()
            lblcanregistros_inv_d.Text = ds.Tables(0).Rows(0)(2).ToString()
            txtcantidad.Text = ""

            'obj.ProcesarInventarioRep(id_inventario) 

            lblmensaje.Text = "Se inventario " & cant_prod_det_invent.ToString() & " " & cod_um_det_invent & " de : " & desc_prod_det
            lblmensajealerta.Text = "ESC para continuar"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje", "$('#myModal_Mensaje').modal();", True)

            cant_prod_det_invent = 0D '13052026 IVa
            Return

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtcodigo_producto.Text = ""
        txtdesc_producto.Text = ""
        cbozona.SelectedIndex = 0

        txtcantidad.Text = ""
        cboestado_stock.SelectedIndex = 0

    End Sub

    Protected Sub btnInventariados_Click(sender As Object, e As EventArgs) Handles btnInventariados.Click
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", True)
        Dim id_inventario As String
        id_inventario = lblid_inventario.Text.ToString()

        'Response.Redirect("~/inventariados.aspx?dato1=" + id_inventario.ToString())

        Dim url As String = "~/inventariados.aspx?dato1=" + id_inventario.ToString()

        ' Ejecutar el script de JavaScript para abrir la URL en una nueva ventana
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "OpenWindow", "window.open('" & ResolveClientUrl(url) & "', '_blank');", True)

    End Sub

    Private Sub cbozona2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbozona2.SelectedIndexChanged
        'Dim id_inventario As Integer
        'Dim cod_almacen_sap2 As String
        'Dim ds As New DataSet()

        'id_inventario = Integer.Parse(lblid_inventario.Text)
        'cod_almacen_sap2 = cbozona2.SelectedValue.ToString()
        'ds = obj.Lista_Productos_inventariados_usuario(id_inventario, Session("usuario").ToString(), cod_almacen_sap2)
        'Session("ds_detalle_inventariados") = ds
        'grvinventariados.DataSource = ds.Tables(0)
        'grvinventariados.DataBind()
        'estado_stock_inventariados()



        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", True)
    End Sub

    Public Sub estado_stock_inventariados()
        Dim ds_detalle As New DataSet()
        ds_detalle = Session("ds_detalle_inventariados")

        For i = 0 To ds_detalle.Tables(0).Rows.Count - 1
            Dim id_det_invent As Integer
            Dim id_estado_stock As Integer

            id_det_invent = ds_detalle.Tables(0).Rows(i)(0).ToString()
            id_estado_stock = ds_detalle.Tables(0).Rows(i)(6).ToString()

            For Each gvClaserow As GridViewRow In grvinventariados.Rows

                Dim cboestado_stock_inv As DropDownList
                Dim lblid_det_invent As Label
                Dim txtcan_producto_inv As TextBox

                lblid_det_invent = gvClaserow.FindControl("lblid_det_invent")

                If id_det_invent = lblid_det_invent.Text Then

                    cboestado_stock_inv = gvClaserow.FindControl("cboestado_stock_inv")
                    cboestado_stock_inv.SelectedValue = id_estado_stock

                    Exit For
                End If


            Next


        Next

    End Sub

    'Public Sub formato_grvinventariados()
    '    Dim ds As New DataSet()
    '    ds = Session("ds_detalle")

    '    For Each gvClaserow As GridViewRow In grvinventariados.Rows
    '        Dim cboestado_stock_inv As DropDownList
    '        cboestado_stock_inv = gvClaserow.FindControl("cboestado_stock_inv")
    '        cboestado_stock_inv.DataSource = ds.Tables(2)
    '        cboestado_stock_inv.DataValueField = "id_estado"
    '        cboestado_stock_inv.DataTextField = "desc_estado"
    '        cboestado_stock_inv.DataBind()
    '    Next
    'End Sub
    Private Sub grvinventariados_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grvinventariados.RowDataBound
        e.Row.Attributes("onmouseover") = "this.style.backgroundColor='#8FD5FF'"
        e.Row.Attributes("onmouseout") = "this.style.backgroundColor='white'"
    End Sub

    Private Sub grvinventariados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvinventariados.RowCommand
        If e.CommandName = "eliminar" Then
            Dim id_det_invent1 As Integer
            id_det_invent1 = (e.CommandArgument).ToString()
            obj.Elimina_Producto_Inventariado(Session("usuario").ToString(), id_det_invent1)
            cbozona2_SelectedIndexChanged(sender, e)
        End If

        If e.CommandName = "modificar" Then
            Dim id_det_invent2 As Integer
            Dim cantidad As Decimal
            Dim estado_stock As Integer

            id_det_invent2 = (e.CommandArgument).ToString()

            For Each gvClaserow As GridViewRow In grvinventariados.Rows


                Dim cboestado_stock_inv As DropDownList
                Dim lblid_det_invent As Label
                Dim txtcan_producto_inv As TextBox


                lblid_det_invent = gvClaserow.FindControl("lblid_det_invent")

                If id_det_invent2 = lblid_det_invent.Text Then
                    txtcan_producto_inv = gvClaserow.FindControl("txtcan_producto_inv")
                    cboestado_stock_inv = gvClaserow.FindControl("cboestado_stock_inv")

                    cantidad = txtcan_producto_inv.Text
                    estado_stock = Integer.Parse(cboestado_stock_inv.SelectedValue.ToString())

                    obj.Modifica_Producto_Inventariado(id_det_invent2, cantidad, estado_stock, Session("usuario").ToString())
                    Exit For
                End If


            Next

            cbozona2_SelectedIndexChanged(sender, e)

        End If
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
        Response.Redirect("trabajar_inventario.aspx")

    End Sub

    Protected Sub otroBoton_Click(sender As Object, e As EventArgs) Handles otroBoton.Click

        'Buscar_productos()
        Buscar_productos_todos()

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
        obj.Registro_SesionSistema(TokenGlobal, user, sistema, "trabajar_inventario.aspx")
    End Sub

End Class