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


Partial Public Class busqueda_inventario

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
	'''Control lblid_inventario.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblid_inventario As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control UpdatePanel1.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents UpdatePanel1 As Global.System.Web.UI.UpdatePanel

	'''<summary>
	'''Control cboanio.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents cboanio As Global.System.Web.UI.WebControls.DropDownList

	'''<summary>
	'''Control UpdatePanel11.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents UpdatePanel11 As Global.System.Web.UI.UpdatePanel

	'''<summary>
	'''Control cbomes.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents cbomes As Global.System.Web.UI.WebControls.DropDownList

	'''<summary>
	'''Control btnBuscarInventario2.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnBuscarInventario2 As Global.System.Web.UI.WebControls.LinkButton

	'''<summary>
	'''Control grvinventariados.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents grvinventariados As Global.System.Web.UI.WebControls.GridView

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
	'''Control cboestado_stock.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents cboestado_stock As Global.System.Web.UI.WebControls.DropDownList

	'''<summary>
	'''Control txtcantidad.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents txtcantidad As Global.System.Web.UI.WebControls.TextBox

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
	'''Control UpdatePanel5.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents UpdatePanel5 As Global.System.Web.UI.UpdatePanel

	'''<summary>
	'''Control lblmensaje_eliminacion.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblmensaje_eliminacion As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control btnaceptar_elimina.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnaceptar_elimina As Global.System.Web.UI.WebControls.Button

	'''<summary>
	'''Control btncerrar_elimina.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btncerrar_elimina As Global.System.Web.UI.WebControls.Button

	'''<summary>
	'''Control UpdatePanel2.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents UpdatePanel2 As Global.System.Web.UI.UpdatePanel

	'''<summary>
	'''Control lblmensaje_modificacion.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblmensaje_modificacion As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control btnExportarExcelSAP.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btnExportarExcelSAP As Global.System.Web.UI.WebControls.Button

	'''<summary>
	'''Control btncerra_modificar.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btncerra_modificar As Global.System.Web.UI.WebControls.Button

	'''<summary>
	'''Control UpdatePanel6.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents UpdatePanel6 As Global.System.Web.UI.UpdatePanel

	'''<summary>
	'''Control lblmensaje.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents lblmensaje As Global.System.Web.UI.WebControls.Label

	'''<summary>
	'''Control btncerrar_mensaje.
	'''</summary>
	'''<remarks>
	'''Campo generado automáticamente.
	'''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
	'''</remarks>
	Protected WithEvents btncerrar_mensaje As Global.System.Web.UI.WebControls.Button
End Class
