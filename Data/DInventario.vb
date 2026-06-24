Imports System.Data.SqlClient
Imports System.Configuration
Public Class DInventario
    Public Function Registro_Nuevo_Inventario(ByVal user As String, ByVal obs_inventario As String, ByVal cod_centro_sap As String, ByVal cierre_mes As String) As String
        Try
            Dim odt As New DataTable
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
            Dim cn As New SqlConnection(strConnString)

            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_arinvsap_registro_nuevo_inventario"

            cmd.Parameters.Add("@user", SqlDbType.VarChar)
            cmd.Parameters(0).Value = user
            cmd.Parameters.Add("@obs_inventario", SqlDbType.VarChar)
            cmd.Parameters(1).Value = obs_inventario
            cmd.Parameters.Add("@cod_centro_sap", SqlDbType.VarChar)
            cmd.Parameters(2).Value = cod_centro_sap
            cmd.Parameters.Add("@cierre_mes", SqlDbType.VarChar)
            cmd.Parameters(3).Value = cierre_mes


            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Inventario_Activo(ByVal usuario As String) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_inventario_activo"
        cmd.Parameters.Add("@user", SqlDbType.VarChar)
        cmd.Parameters(0).Value = usuario

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Inventario_Detalle(ByVal id_inventario As Integer) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_inventario_detalle"
        cmd.Parameters.Add("@id_inventario", SqlDbType.Int)
        cmd.Parameters(0).Value = id_inventario

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Lista_Productos_centro_almacen(ByVal centro As String, ByVal cod_producto As String, ByVal desc_producto As String) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_lista_productos_centro_almacen"
        cmd.Parameters.Add("@centro", SqlDbType.VarChar)
        cmd.Parameters(0).Value = centro
        'cmd.Parameters.Add("@almacen", SqlDbType.VarChar)
        'cmd.Parameters(1).Value = almacen
        cmd.Parameters.Add("@cod_producto", SqlDbType.VarChar)
        cmd.Parameters(1).Value = cod_producto
        cmd.Parameters.Add("@desc_producto", SqlDbType.VarChar)
        cmd.Parameters(2).Value = desc_producto

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Registra_Producto_Inventario(ByVal id_inventario As Integer, ByVal cod_prod_sap As String,
                                                 ByVal desc_prod_det As String, ByVal cod_um_det_invent As String,
                                                 ByVal desc_um_det_invent As String, ByVal cant_prod_det_invent As Decimal,
                                                 ByVal cod_almacen_sap As String, ByVal user As String, ByVal id_estado_stock As Integer,
                                                 ByVal fecha_vencimiento As Nullable(Of DateTime), ByVal um_alternativa_conversion As String,
                                                 ByVal can_original As Decimal) As String
        Try
            Dim odt As New DataTable
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
            Dim cn As New SqlConnection(strConnString)


            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_arinvsap_registra_producto_inventario_N2026"

            cmd.Parameters.Add("@id_inventario", SqlDbType.Int)
            cmd.Parameters(0).Value = id_inventario
            cmd.Parameters.Add("@cod_prod_sap", SqlDbType.VarChar)
            cmd.Parameters(1).Value = cod_prod_sap
            cmd.Parameters.Add("@desc_prod_det", SqlDbType.VarChar)
            cmd.Parameters(2).Value = desc_prod_det
            cmd.Parameters.Add("@cod_um_det_invent", SqlDbType.VarChar)
            cmd.Parameters(3).Value = cod_um_det_invent
            cmd.Parameters.Add("@desc_um_det_invent", SqlDbType.VarChar)
            cmd.Parameters(4).Value = desc_um_det_invent
            cmd.Parameters.Add("@cant_prod_det_invent", SqlDbType.Decimal)
            cmd.Parameters(5).Value = cant_prod_det_invent
            cmd.Parameters.Add("@cod_almacen_sap", SqlDbType.VarChar)
            cmd.Parameters(6).Value = cod_almacen_sap
            cmd.Parameters.Add("@user", SqlDbType.VarChar)
            cmd.Parameters(7).Value = user
            cmd.Parameters.Add("@id_estado_stock", SqlDbType.Int)
            cmd.Parameters(8).Value = id_estado_stock
            cmd.Parameters.Add("@fec_vencimiento", SqlDbType.DateTime)
            If fecha_vencimiento.HasValue Then
                cmd.Parameters("@fec_vencimiento").Value = fecha_vencimiento.Value
            Else
                cmd.Parameters("@fec_vencimiento").Value = DBNull.Value
            End If
            '14052026 IVa
            cmd.Parameters.Add("@um_alternativa_conversion", SqlDbType.VarChar)
            cmd.Parameters(10).Value = um_alternativa_conversion
            cmd.Parameters.Add("@can_original", SqlDbType.Decimal)
            cmd.Parameters(11).Value = can_original

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Lista_Productos_inventariados_usuario(ByVal id_inventario As Integer, ByVal user As String, ByVal cod_almacen_sap As String,
                                                          ByVal cod_producto As String, ByVal desc_producto As String, ByVal id_usuario_registrado As Integer) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_Lista_ultimos_productos_inventario"
        cmd.Parameters.Add("@id_inventario", SqlDbType.Int)
        cmd.Parameters(0).Value = id_inventario
        cmd.Parameters.Add("@user", SqlDbType.VarChar)
        cmd.Parameters(1).Value = user
        cmd.Parameters.Add("@cod_almacen_sap", SqlDbType.VarChar)
        cmd.Parameters(2).Value = cod_almacen_sap
        cmd.Parameters.Add("@cod_producto", SqlDbType.VarChar)
        cmd.Parameters(3).Value = cod_producto
        cmd.Parameters.Add("@desc_producto", SqlDbType.VarChar)
        cmd.Parameters(4).Value = desc_producto
        cmd.Parameters.Add("@id_usuario_registrado", SqlDbType.Int)
        cmd.Parameters(5).Value = id_usuario_registrado

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function


    Public Function Elimina_Producto_Inventariado(ByVal user As String, ByVal id_det_invent As Integer) As Boolean
        Try
            Dim odt As New DataTable
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
            Dim cn As New SqlConnection(strConnString)

            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_arinvsap_elimina_producto_inventariado"

            cmd.Parameters.Add("@id_det_invent", SqlDbType.Int)
            cmd.Parameters(0).Value = id_det_invent
            cmd.Parameters.Add("@user", SqlDbType.VarChar)
            cmd.Parameters(1).Value = user

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Modifica_Producto_Inventariado(ByVal id_det_invent As Integer, ByVal cantidad As Decimal, ByVal id_estado_stock As Integer, ByVal user As String) As Boolean
        Try
            Dim odt As New DataTable
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
            Dim cn As New SqlConnection(strConnString)

            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_arinvsap_modifica_producto_inventario"

            cmd.Parameters.Add("@id_det_invent", SqlDbType.Int)
            cmd.Parameters(0).Value = id_det_invent
            cmd.Parameters.Add("@cantidad", SqlDbType.Decimal)
            cmd.Parameters(1).Value = cantidad
            cmd.Parameters.Add("@id_estado_stock", SqlDbType.Int)
            cmd.Parameters(2).Value = id_estado_stock
            cmd.Parameters.Add("@user", SqlDbType.VarChar)
            cmd.Parameters(3).Value = user

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Cerrar_Inventario(ByVal id_inventario As Integer, ByVal usuario As String) As String
        Try
            Dim odt As New DataTable
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
            Dim cn As New SqlConnection(strConnString)

            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandTimeout = 0
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "sp_arinvsap_inventario_cierre"

            cmd.Parameters.Add("@id_inventario", SqlDbType.Int)
            cmd.Parameters(0).Value = id_inventario
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar)
            cmd.Parameters(1).Value = usuario

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Inventario_Exportar_Excel(ByVal id_inventario As Integer) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn
        cmd.CommandTimeout = 0
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_inventario_excel"
        cmd.Parameters.Add("@id_inventario", SqlDbType.Int)
        cmd.Parameters(0).Value = id_inventario

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Listar_Mes() As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_lista_mes"

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Listar_Anio() As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_lista_anio"

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Lista_inventariox_mes(ByVal user As String, ByVal id_mes As Integer, ByVal id_anio As Integer) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_inventario_activo_x_mes_2"
        cmd.Parameters.Add("@user", SqlDbType.VarChar)
        cmd.Parameters(0).Value = user
        cmd.Parameters.Add("@id_mes", SqlDbType.Int)
        cmd.Parameters(1).Value = id_mes
        cmd.Parameters.Add("@id_anio", SqlDbType.Int)
        cmd.Parameters(2).Value = id_anio

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Lista_producto_unidades_medida(ByVal cod_producto As String) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_producto_unidades_medida"
        cmd.Parameters.Add("@cod_producto", SqlDbType.VarChar)
        cmd.Parameters(0).Value = cod_producto

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Lista_producto_equivalencia_umb(ByVal cod_producto As String) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_equivalencia_umb"
        cmd.Parameters.Add("@cod_producto", SqlDbType.VarChar)
        cmd.Parameters(0).Value = cod_producto

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function ProcesarInventarioRep(ByVal id_inventario As Integer) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "ProcesarInventarioRep"
        cmd.Parameters.Add("@ID_INVENTARIO", SqlDbType.Int)
        cmd.Parameters(0).Value = id_inventario

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Lista_Productos_centro_almacen_todos(ByVal centro As String) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_lista_productos_centro_almacen_todos"
        cmd.Parameters.Add("@centro", SqlDbType.VarChar)
        cmd.Parameters(0).Value = centro

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function Lista_inventariados_Excel(ByVal id_inventario As Integer) As DataSet
        Dim odt As New DataTable
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion").ConnectionString
        Dim cn As New SqlConnection(strConnString)

        Dim cmd As New SqlCommand
        cmd.Connection = cn

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "sp_arinvsap_lista_inventariados_excel"
        cmd.Parameters.Add("@id_inventario", SqlDbType.VarChar)
        cmd.Parameters(0).Value = id_inventario

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet
        da.Fill(ds)


        Return ds
    End Function

    Public Function ExisteTokenActivo(ByVal token As String) As DataSet
        Dim ds As New DataSet()

        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion_arsysusers").ConnectionString

            Using cn As New SqlConnection(strConnString)
                Using cmd As New SqlCommand("sp_arsuite_Validartoken", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0

                    ' Definir parámetro con tipo y tamaño
                    cmd.Parameters.Add("@token", SqlDbType.VarChar, 500).Value = token

                    ' Llenar el DataSet usando SqlDataAdapter
                    Using da As New SqlDataAdapter(cmd)
                        da.Fill(ds)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            ' Registrar el error si es necesario
            ' LogError(ex.Message) 
            Throw ' Relanzar el error para ser manejado en un nivel superior
        End Try

        Return ds
    End Function

    Public Function CerrarSesionGlobal(ByVal tokenGlobal As String) As Boolean
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion_arsysusers").ConnectionString

            Using cn As New SqlConnection(strConnString)
                Using cmd As New SqlCommand("sp_arsuite_CerrarSesionGlobal", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0

                    ' Agregar parámetros con tipo y tamaño
                    cmd.Parameters.Add("@token", SqlDbType.VarChar, 500).Value = tokenGlobal

                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            ' Aquí puedes registrar el error antes de relanzarlo
            ' LogError(ex.Message) 
            Throw ' Lanza el error para que sea manejado en niveles superiores
        End Try
    End Function

    Public Function Registro_SesionSistema(ByVal tokenGlobal As String, ByVal usuario As String, ByVal CodigoSistema As String, ByVal PaginaAcceso As String) As Boolean
        Try
            Dim strConnString As String = ConfigurationManager.ConnectionStrings("cadenaConexion_arsysusers").ConnectionString

            Using cn As New SqlConnection(strConnString)
                Using cmd As New SqlCommand("sp_arsuite_Registro_SesionSistema", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0

                    ' Agregar parámetros con tipo y tamaño
                    cmd.Parameters.Add("@tokenGlobal", SqlDbType.VarChar, 500).Value = tokenGlobal
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario
                    cmd.Parameters.Add("@CodigoSistema", SqlDbType.VarChar, 20).Value = CodigoSistema
                    cmd.Parameters.Add("@PaginaAcceso", SqlDbType.VarChar, 200).Value = PaginaAcceso

                    cn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            ' Aquí puedes registrar el error antes de relanzarlo
            ' LogError(ex.Message) 
            Throw ' Lanza el error para que sea manejado en niveles superiores
        End Try
    End Function

End Class
