Imports Data
Public Class NInventario
    Dim obj As New Data.DInventario
    Public Function Registro_Nuevo_Inventario(ByVal user As String, ByVal obs_inventario As String, ByVal cod_centro_sap As String, ByVal cierre_mes As String) As Boolean

        Dim resultado As Boolean
        resultado = obj.Registro_Nuevo_Inventario(user, obs_inventario, cod_centro_sap, cierre_mes)
        Return resultado

    End Function
    Public Function Inventario_Activo(ByVal usuario As String) As DataSet
        Dim ds As New DataSet
        ds = obj.Inventario_Activo(usuario)
        Return ds
    End Function

    Public Function Inventario_Detalle(ByVal id_inventario As Integer) As DataSet
        Dim ds As New DataSet
        ds = obj.Inventario_Detalle(id_inventario)
        Return ds
    End Function

    Public Function Lista_Productos_centro_almacen(ByVal centro As String, ByVal cod_producto As String, ByVal desc_producto As String) As DataSet
        Dim ds As New DataSet
        ds = obj.Lista_Productos_centro_almacen(centro, cod_producto, desc_producto)
        Return ds
    End Function

    Public Function Registra_Producto_Inventario(ByVal id_inventario As Integer, ByVal cod_prod_sap As String,
                                                 ByVal desc_prod_det As String, ByVal cod_um_det_invent As String,
                                                 ByVal desc_um_det_invent As String, ByVal cant_prod_det_invent As Decimal,
                                                 ByVal cod_almacen_sap As String, ByVal user As String, ByVal id_estado_stock As Integer,
                                                 ByVal fecha_vencimiento As Nullable(Of DateTime), ByVal um_alternativa_conversion As String,
                                                 ByVal can_original As Decimal) As Boolean

        Dim resultado As Boolean
        resultado = obj.Registra_Producto_Inventario(id_inventario, cod_prod_sap, desc_prod_det, cod_um_det_invent,
                                                       desc_um_det_invent, cant_prod_det_invent, cod_almacen_sap, user, id_estado_stock, fecha_vencimiento, um_alternativa_conversion, can_original)
        Return resultado

    End Function

    Public Function Lista_Productos_inventariados_usuario(ByVal id_inventario As Integer, ByVal user As String, ByVal cod_almacen_sap As String,
                                                          ByVal cod_producto As String, ByVal desc_producto As String, ByVal id_usuario_registrado As Integer) As DataSet
        Dim ds As New DataSet
        ds = obj.Lista_Productos_inventariados_usuario(id_inventario, user, cod_almacen_sap, cod_producto, desc_producto, id_usuario_registrado)
        Return ds
    End Function

    Public Function Elimina_Producto_Inventariado(ByVal user As String, ByVal id_det_invent As Integer) As Boolean

        Dim resultado As Boolean
        resultado = obj.Elimina_Producto_Inventariado(user, id_det_invent)
        Return resultado

    End Function

    Public Function Modifica_Producto_Inventariado(ByVal id_det_invent As Integer, ByVal cantidad As Decimal, ByVal id_estado_stock As Integer, ByVal user As String) As Boolean

        Dim resultado As Boolean
        resultado = obj.Modifica_Producto_Inventariado(id_det_invent, cantidad, id_estado_stock, user)
        Return resultado

    End Function

    Public Function Cerrar_Inventario(ByVal id_inventario As Integer, ByVal usuario As String) As Boolean

        Dim resultado As Boolean
        resultado = obj.Cerrar_Inventario(id_inventario, usuario)
        Return resultado

    End Function

    Public Function Inventario_Exportar_Excel(ByVal id_inventario As Integer) As DataSet
        Dim ds As New DataSet
        ds = obj.Inventario_Exportar_Excel(id_inventario)
        Return ds
    End Function

    Public Function Listar_Mes() As DataSet
        Dim ds As New DataSet
        ds = obj.Listar_Mes()
        Return ds
    End Function

    Public Function Listar_Anio() As DataSet
        Dim ds As New DataSet
        ds = obj.Listar_Anio()
        Return ds
    End Function

    Public Function Lista_inventariox_mes(ByVal user As String, ByVal id_mes As Integer, ByVal id_anio As Integer) As DataSet
        Dim ds As New DataSet
        ds = obj.Lista_inventariox_mes(user, id_mes, id_anio)
        Return ds
    End Function

    Public Function Lista_producto_unidades_medida(ByVal cod_producto As String) As DataSet
        Dim ds As New DataSet
        ds = obj.Lista_producto_unidades_medida(cod_producto)
        Return ds
    End Function

    Public Function Lista_producto_equivalencia_umb(ByVal cod_producto As String) As DataSet
        Dim ds As New DataSet
        ds = obj.Lista_producto_equivalencia_umb(cod_producto)
        Return ds
    End Function

    Public Function ProcesarInventarioRep(ByVal id_inventario As Integer) As DataSet
        Dim ds As New DataSet
        ds = obj.ProcesarInventarioRep(id_inventario)
        Return ds
    End Function
    Public Function Lista_Productos_centro_almacen_todos(ByVal centro As String) As DataSet
        Dim ds As New DataSet
        ds = obj.Lista_Productos_centro_almacen_todos(centro)
        Return ds
    End Function

    Public Function Lista_inventariados_Excel(ByVal id_inventario As Integer) As DataSet
        Dim ds As New DataSet
        ds = obj.Lista_inventariados_Excel(id_inventario)
        Return ds
    End Function

    Public Function ExisteTokenActivo(ByVal token As String) As DataSet
        Dim ds As New DataSet
        ds = obj.ExisteTokenActivo(token)
        Return ds
    End Function

    Public Function CerrarSesionGlobal(ByVal tokenGlobal As String) As Boolean

        obj.CerrarSesionGlobal(tokenGlobal)
        Return True
    End Function

    Public Function Registro_SesionSistema(ByVal tokenGlobal As String, ByVal usuario As String, ByVal CodigoSistema As String, ByVal PaginaAcceso As String) As Boolean

        obj.Registro_SesionSistema(tokenGlobal, usuario, CodigoSistema, PaginaAcceso)
        Return True
    End Function


End Class
