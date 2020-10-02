Imports MySql.Data.MySqlClient

Public Class ManejoDatos
    Public Function ObtieneProductos() As String
        Dim dsObtieneProductos As DataSet
        Dim strObtieneValores As String
        dsObtieneProductos = ConsultaProductos()
        strObtieneValores = dsObtieneProductos.GetXml()
        Return strObtieneValores
    End Function
    Private Function ConsultaProductos() As DataSet
        Dim strConString As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString
        Dim con As MySqlConnection
        con = New MySqlConnection(strConString)
        con.Open()
        Dim com As New MySqlCommand
        com.CommandText = "select pr.Nombre,pr.Descripcion,pr.Foto,pr.Perecedero,pr.Tiempo_vida,cat.categoria, pre.precio,tip.tipo_precio from examen.productos pr left join examen.categoriasproducto cat on pr.id_categoria = cat.id_categoria left join examen.preciosproducto pre on pr.id_producto = pre.id_producto  left join examen.tiposprecio tip on pre.id_tipo_precio = tip.id_tipo_precio"
        com.Connection = con
        Dim dbAdaptador As MySqlDataAdapter
        dbAdaptador = New MySqlDataAdapter()
        dbAdaptador.SelectCommand = com
        Dim dsTabla As New DataSet
        dbAdaptador.Fill(dsTabla)
        con.Close()
        Return dsTabla
    End Function
End Class
