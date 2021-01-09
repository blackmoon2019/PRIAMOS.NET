Imports System.Xml
Imports System.IO
Public Class XmlUpdateFromDB
    Public Function UpdateXMLFile(ByVal sFileName As String) As Boolean
        Dim xmldoc As New XmlDataDocument()
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim str As String
        Dim fs As New FileStream(sFileName, FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        Dim Nodes As XmlNodeList = xmldoc.DocumentElement.SelectNodes(".//property[@name='Columns']")
        Dim pID As String = "", pName As String = "", pPrice As String = ""
        For Each node As XmlNode In Nodes
            pID = node.SelectSingleNode("property name").InnerText
            pName = node.SelectSingleNode("Product_name").InnerText
            pPrice = node.SelectSingleNode("Product_price").InnerText
            MessageBox.Show(pID & " " & pName & " " & pPrice)
        Next
    End Function
End Class
