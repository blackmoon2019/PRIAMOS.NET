Public Class XML_Serialization
    Public Class User_Settings
        <Xml.Serialization.XmlElement>
        Public Property user() As User
    End Class

    Public Class User
        <Xml.Serialization.XmlElement>
        Public Property Settings() As Settings
        <Xml.Serialization.XmlAttribute>
        Public Property ID() As String
    End Class

    Public Class Settings
        <Xml.Serialization.XmlElement>
        Public Property DataTable As String
        <Xml.Serialization.XmlElement>
        Public Property CurrentView As String
    End Class
End Class
