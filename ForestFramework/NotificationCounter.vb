Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Drawing
Imports ForestFramework.DrawHelpers
Imports ForestFramework.ExtendedGraphics

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NotificationCounter

#Region "Copyright © Forest"
    Private _lnk As String = "https://nikyus.com"
    'ByGEIVISUH
    <Category("# - Copyight © [Nikyus]")>
    Public ReadOnly Property WebSite As String
        <System.ComponentModel.Browsable(False)>
        Get
            Return _lnk
        End Get
    End Property
#End Region


    Public Shared Sub DrawNotification(ByVal objGraphics As Graphics, ByVal _handlecontrol As Control, ByVal _locationX As Single, ByVal _locationY As Single, ByVal _color As Color, ByVal _fontcolor As Color, ByVal _size As Size, _value As String, _round As Integer)
        objGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
        objGraphics.SmoothingMode = SmoothingMode.HighQuality
        objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias


        With objGraphics
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality

            If _round <= 0 Then
                .FillRectangle(New SolidBrush(_color), _locationX, _locationY, _size.Width + 6, _size.Height + 6, _size.Height / 2)
            Else
                .FillRectangle(New SolidBrush(_color), _locationX, _locationY, _size.Width + 6, _size.Height + 6, _round)
            End If


            .DrawString(_value, New Font("Segoe UI", 9), New SolidBrush(_fontcolor), New Rectangle(_locationX, _locationY, _size.Width + 7, _size.Height + 8), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})




        End With


    End Sub





End Class
