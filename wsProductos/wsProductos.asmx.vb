Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class wsProductos
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function Acerca_De() As String
        Dim dsExamen As New DataSet("Examen")
        Dim dtExamen As DataTable
        dtExamen = dsExamen.Tables.Add("Examen")
        dtExamen.Columns.Add("Nombre")
        dtExamen.Columns.Add("Carnet")
        dtExamen.Columns.Add("Descripcion")
        dtExamen.Columns.Add("Fecha")
        Dim drFila As DataRow
        drFila = dtExamen.NewRow
        drFila.Item("Nombre") = "César Antonio Pérez Sac"
        drFila.Item("Carnet") = "1490-11-1472"
        drFila.Item("Descripcion") = "Evaluación Privada, Area de Analisis, Diseño y Desarrollo UMG"
        drFila.Item("Fecha") = "01/10/2020"
        dtExamen.Rows.Add(drFila)

        Return dsExamen.GetXml()
    End Function

    <WebMethod>
    Public Function ConsultaProductos()
        Dim objManejo As New ManejoDatos
        Return objManejo.ObtieneProductos()
    End Function
End Class