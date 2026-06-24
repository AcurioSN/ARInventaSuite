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
Public Class inventariados
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
        'cbozona2.DataSource = ds.Tables(1)
        'cbozona2.DataValueField = "almacen"
        'cbozona2.DataTextField = "descrip_almacen"
        'cbozona2.DataBind()

        'cboestado_stock.DataSource = ds.Tables(2)
        'cboestado_stock.DataValueField = "id_estado"
        'cboestado_stock.DataTextField = "desc_estado"
        'cboestado_stock.DataBind()
        'cboestado_stock.SelectedIndex = 0
        cboregistradopor.DataSource = ds.Tables(3)
        cboregistradopor.DataValueField = "id_usuario"
        cboregistradopor.DataTextField = "datos_usuario"
        cboregistradopor.DataBind()

        Session("ds_detalle") = ds
        ds.Dispose()
    End Sub

    Protected Sub cbozona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbozona.SelectedIndexChanged
        Buscar_productos()
    End Sub
    Public Sub Buscar_productos()
        Dim id_inventario As Integer
        Dim cod_almacen_sap2 As String
        Dim id_usuario_registrado As Integer
        Dim cod_producto As String
        Dim desc_producto As String

        Dim ds As New DataSet()

        id_inventario = Integer.Parse(lblid_inventario.Text)
        cod_almacen_sap2 = cbozona.SelectedValue.ToString()
        id_usuario_registrado = Integer.Parse(cboregistradopor.SelectedValue.ToString())
        cod_producto = txtcodigo_producto.Text
        desc_producto = txtdesc_producto.Text

        ds = obj.Lista_Productos_inventariados_usuario(id_inventario, Session("usuario").ToString(), cod_almacen_sap2, cod_producto, desc_producto, id_usuario_registrado)
        Session("ds_detalle_inventariados") = ds
        grvinventariados.DataSource = ds.Tables(0)
        grvinventariados.DataBind()
        estado_stock_inventariados()

        lblcanregistros_inv_d.Text = ds.Tables(1).Rows(0)(0).ToString()

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

    Private Sub grvinventariados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grvinventariados.RowCommand
        If e.CommandName = "eliminar" Then
            'Dim id_det_invent1 As Integer
            'id_det_invent1 = (e.CommandArgument).ToString()
            'obj.Elimina_Producto_Inventariado(Session("usuario").ToString(), id_det_invent1)
            'cbozona_SelectedIndexChanged(sender, e)

            Dim id_det_invent1 As Integer
            Dim descripcion_producto As String
            id_det_invent1 = (e.CommandArgument).ToString()
            Session("id_det_invent") = id_det_invent1

            For Each gvClaserow As GridViewRow In grvinventariados.Rows
                Dim lblid_det_invent As Label
                Dim lbldesc_producto_inv As Label

                lblid_det_invent = gvClaserow.FindControl("lblid_det_invent")
                If lblid_det_invent.Text = id_det_invent1 Then
                    lbldesc_producto_inv = gvClaserow.FindControl("lbldesc_producto_inv")
                    descripcion_producto = lbldesc_producto_inv.Text
                    Exit For
                End If
            Next

            lblmensaje_eliminacion.Text = "Desea eliminar el producto " + descripcion_producto + "?"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje_elimina", "$('#myModal_Mensaje_elimina').modal();", True)

        End If

        If e.CommandName = "modificar" Then
            Dim id_det_invent2 As Integer
            Dim descripcion_producto2 As String


            id_det_invent2 = (e.CommandArgument).ToString()
            Session("id_det_invent") = id_det_invent2

            For Each gvClaserow As GridViewRow In grvinventariados.Rows
                Dim lblid_det_invent As Label
                Dim lbldesc_producto_inv As Label

                lblid_det_invent = gvClaserow.FindControl("lblid_det_invent")
                If lblid_det_invent.Text = id_det_invent2 Then
                    lbldesc_producto_inv = gvClaserow.FindControl("lbldesc_producto_inv")
                    descripcion_producto2 = lbldesc_producto_inv.Text
                    Exit For
                End If
            Next

            lblmensaje_modificacion.Text = "Desea modificar el producto " + descripcion_producto2 + "?"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje_modifica", "$('#myModal_Mensaje_modifica').modal();", True)


            'For Each gvClaserow As GridViewRow In grvinventariados.Rows

            '    Dim cboestado_stock_inv As DropDownList
            '    Dim lblid_det_invent As Label
            '    Dim txtcan_producto_inv As TextBox


            '    lblid_det_invent = gvClaserow.FindControl("lblid_det_invent")

            '    If id_det_invent2 = lblid_det_invent.Text Then
            '        txtcan_producto_inv = gvClaserow.FindControl("txtcan_producto_inv")
            '        cboestado_stock_inv = gvClaserow.FindControl("cboestado_stock_inv")

            '        cantidad = txtcan_producto_inv.Text
            '        estado_stock = Integer.Parse(cboestado_stock_inv.SelectedValue.ToString())

            '        obj.Modifica_Producto_Inventariado(id_det_invent2, cantidad, estado_stock, Session("usuario").ToString())
            '        Exit For
            '    End If


            'Next



        End If
    End Sub

    Private Sub grvinventariados_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grvinventariados.RowDataBound
        e.Row.Attributes("onmouseover") = "this.style.backgroundColor='#EFEEEE'"
        e.Row.Attributes("onmouseout") = "this.style.backgroundColor='white'"
    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        Buscar_productos()
    End Sub
    Private Sub btnBuscarProducto2_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto2.Click
        Buscar_productos()
    End Sub

    Private Sub cboregistradopor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboregistradopor.SelectedIndexChanged
        Buscar_productos()
    End Sub

    Protected Sub btnaceptar_elimina_Click(sender As Object, e As EventArgs) Handles btnaceptar_elimina.Click
        Dim id_det_invent1 As Integer
        id_det_invent1 = Integer.Parse(Session("id_det_invent").ToString())
        obj.Elimina_Producto_Inventariado(Session("usuario").ToString(), id_det_invent1)
        Buscar_productos()

        lblmensaje.Text = "El producto fue eliminado correctamente"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje", "$('#myModal_Mensaje').modal();", True)

    End Sub

    Private Sub btncerrar_elimina_Click(sender As Object, e As EventArgs) Handles btncerrar_elimina.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje_elimina", "$('#myModal_Mensaje_elimina').modal();", False)
    End Sub

    Protected Sub btnmodificar_Click(sender As Object, e As EventArgs) Handles btnmodificar.Click
        Dim id_det_invent2 As Integer
        Dim cantidad As Decimal
        Dim estado_stock As Integer

        id_det_invent2 = Integer.Parse(Session("id_det_invent").ToString())

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


        Buscar_productos()

        lblmensaje.Text = "El producto fue modificado correctamente"
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje", "$('#myModal_Mensaje').modal();", True)

    End Sub

    Protected Sub btncerrar_mensaje_Click(sender As Object, e As EventArgs) Handles btncerrar_mensaje.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal_Mensaje", "$('#myModal_Mensaje').modal();", False)
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
        Response.Redirect("inventariados.aspx")
    End Sub
    Protected Sub otroBoton_Click(sender As Object, e As EventArgs) Handles otroBoton.Click

        Buscar_productos()

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
        obj.Registro_SesionSistema(TokenGlobal, user, sistema, "inventariados.aspx")
    End Sub


End Class