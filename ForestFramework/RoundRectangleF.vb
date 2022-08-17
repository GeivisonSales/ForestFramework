Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class RoundedRectangleF
    Private location As Point
    Private _radius As Single
    Private grPath As GraphicsPath
    Private x, y As Single
    Private width, height As Single

    Public Sub New(ByVal width As Single, ByVal height As Single, ByVal radius As Single, ByVal Optional x As Single = 0, ByVal Optional y As Single = 0)
        location = New Point(0, 0)
        Me.Radius = _radius
        Me.x = x
        Me.y = y
        Me.width = width
        Me.height = height
        grPath = New GraphicsPath()

        If radius <= 0 Then
            grPath.AddRectangle(New RectangleF(x, y, width, height))
            Return
        End If

        Dim upperLeftRect As RectangleF = New RectangleF(x, y, 2 * radius, 2 * radius)
        Dim upperRightRect As RectangleF = New RectangleF(width - 2 * radius - 1, x, 2 * radius, 2 * radius)
        Dim lowerLeftRect As RectangleF = New RectangleF(x, height - 2 * radius - 1, 2 * radius, 2 * radius)
        Dim lowerRightRect As RectangleF = New RectangleF(width - 2 * radius - 1, height - 2 * radius - 1, 2 * radius, 2 * radius)
        grPath.AddArc(upperLeftRect, 180, 90)
        grPath.AddArc(upperRightRect, 270, 90)
        grPath.AddArc(lowerRightRect, 0, 90)
        grPath.AddArc(lowerLeftRect, 90, 90)
        grPath.CloseAllFigures()
    End Sub

    Public Sub New()
    End Sub

    Public ReadOnly Property Path As GraphicsPath
        Get
            Return grPath
        End Get
    End Property

    Public ReadOnly Property Rect As RectangleF
        Get
            Return New RectangleF(x, y, width, height)
        End Get
    End Property

    Public Property Radius As Single
        Get
            Return _radius
        End Get
        Set(ByVal value As Single)
            _radius = value
        End Set
    End Property
End Class