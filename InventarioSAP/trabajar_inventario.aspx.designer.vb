'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class trabajar_inventario

	'''<summary>
	'''Control ScriptManager1.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents ScriptManager1 As Global.System.Web.UI.ScriptManager

	'''<summary>
	'''Control btnCerrarSesion.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnCerrarSesion As Global.System.Web.UI.WebControls.Button

	'''<summary>
	'''Control lblmensaje_inv_activo_d.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblmensaje_inv_activo_d As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control lblcanregistros_inv_d.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblcanregistros_inv_d As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control lblid_inventario.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblid_inventario As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control btnBuscarProducto.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnBuscarProducto As Global.System.Web.UI.WebControls.LinkButton

	'''<summary>
	'''Control btnInventariados.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnInventariados As Global.System.Web.UI.WebControls.LinkButton

	'''<summary>
	'''Control btnLimpiar.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnLimpiar As Global.System.Web.UI.WebControls.LinkButton

	'''<summary>
	'''Control Panel2.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents Panel2 As Global.System.Web.UI.WebControls.Panel

	'''<summary>
	'''Control txtcodigo_producto.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents txtcodigo_producto As Global.System.Web.UI.WebControls.TextBox

	'''<summary>
	'''Control Panel1.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents Panel1 As Global.System.Web.UI.WebControls.Panel

	'''<summary>
	'''Control txtdesc_producto.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents txtdesc_producto As Global.System.Web.UI.WebControls.TextBox

	'''<summary>
	'''Control otroBoton.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents otroBoton As Global.System.Web.UI.WebControls.Button

	'''<summary>
	'''Control btnBuscarProducto2.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnBuscarProducto2 As Global.System.Web.UI.WebControls.LinkButton

	'''<summary>
	'''Control UpdatePanel11.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents UpdatePanel11 As Global.System.Web.UI.UpdatePanel

	'''<summary>
	'''Control cbozona.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents cbozona As Global.System.Web.UI.WebControls.DropDownList

	'''<summary>
	'''Control grvProductos.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents grvProductos As Global.System.Web.UI.WebControls.GridView

	'''<summary>
	'''Control lblcodigo_producto.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblcodigo_producto As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control lbldesc_producto.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lbldesc_producto As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control lblunidad_medida.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblunidad_medida As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control lblUM.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblUM As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control cbounidades_medida.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents cbounidades_medida As Global.System.Web.UI.WebControls.DropDownList

	'''<summary>
	'''Control cboestado_stock.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents cboestado_stock As Global.System.Web.UI.WebControls.DropDownList

	'''<summary>
	'''Control Panel3.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents Panel3 As Global.System.Web.UI.WebControls.Panel

	'''<summary>
	'''Control txtcantidad.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents txtcantidad As Global.System.Web.UI.WebControls.TextBox

	'''<summary>
	'''Control phFechaVencimiento.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents phFechaVencimiento As Global.System.Web.UI.WebControls.PlaceHolder

	'''<summary>
	'''Control txtfecha_vencimiento.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents txtfecha_vencimiento As Global.System.Web.UI.WebControls.TextBox

	'''<summary>
	'''Control btnRegistrar.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnRegistrar As Global.System.Web.UI.WebControls.LinkButton

	'''<summary>
	'''Control UpdatePanel18.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents UpdatePanel18 As Global.System.Web.UI.UpdatePanel

	'''<summary>
	'''Control lbltituloCasos.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lbltituloCasos As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control cbozona2.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents cbozona2 As Global.System.Web.UI.WebControls.DropDownList

	'''<summary>
	'''Control grvinventariados.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents grvinventariados As Global.System.Web.UI.WebControls.GridView

	'''<summary>
	'''Control UpdatePanel5.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents UpdatePanel5 As Global.System.Web.UI.UpdatePanel

	'''<summary>
	'''Control lblmensaje.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblmensaje As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control lblmensajealerta.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblmensajealerta As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control btncerra_modificar.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btncerra_modificar As Global.System.Web.UI.WebControls.Button
End Class
