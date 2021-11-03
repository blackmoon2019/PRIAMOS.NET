Imports System.Drawing.Imaging
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports WIA
Public Class ScanToPDF
    Public Function Scan() As Boolean
        Dim CD As New WIA.CommonDialog
        'Dim F As WIA.ImageFile = CD.ShowAcquireImage(WIA.WiaDeviceType.ScannerDeviceType)
        Dim imagefile As ImageFile = CD.ShowAcquireImage(DeviceType:=WiaDeviceType.ScannerDeviceType, Intent:=WiaImageIntent.ColorIntent, Bias:=WiaImageBias.MinimizeSize,
                                                FormatID:=WIA.FormatID.wiaFormatJPEG, AlwaysSelectDevice:=False, UseCommonUI:=True, CancelError:=False)
        Dim sPath As String = "C:\temp\testscan.jpg"
        If (imagefile IsNot Nothing) Then
            Dim v As Vector = imagefile.FileData
            Dim bytes As Byte() = v.BinaryData()
            Using ms = New System.IO.MemoryStream(bytes)
                Using bitmap = New Bitmap(ms)
                    Dim codecinfo As ImageCodecInfo = ImageCodecInfo.GetImageDecoders.First(Function(name) name.FormatID = ImageFormat.Jpeg.Guid)
                    Dim encoder As Encoder = Encoder.Quality
                    Dim ep As EncoderParameters = New EncoderParameters(1)
                    Dim qualityParameter As EncoderParameter = New EncoderParameter(encoder, 75L)
                    ep.Param(0) = qualityParameter
                    bitmap.Save(sPath, codecinfo, ep)
                End Using
            End Using
        End If
        Dim filePath As String = "C:\temp"
        Dim dirInfo As New DirectoryInfo(filePath)
        Dim intCount As Integer
        intCount = dirInfo.GetFiles("*.JPG").Count
        MsgBox("Number of jpeg image files in given directory is: " & intCount)

        Dim oPDF As New Document()
        Dim pdfFILE As String = "C:\temp\ImageConversion.pdf"

        Dim oPDfWriter As PdfWriter = PdfWriter.GetInstance(oPDF, New FileStream(pdfFILE, FileMode.Create))

        oPDF.Open()
        Dim myImage As Image = Image.GetInstance("C:\temp\testscan.jpg")
        myImage.ScalePercent(40.0F, 55.0F)

        myImage.Alignment = Element.ALIGN_CENTER

        oPDF.Add(myImage)
        oPDF.Close()
    End Function

End Class
