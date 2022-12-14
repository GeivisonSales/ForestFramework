Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Drawing
Imports ForestFramework.DrawHelpers

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

<DefaultEvent("Scroll")>
Public Class NikyusVertical_VBScrollbar_UI
    Inherits Control


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

#Region "Declarations"

    Private _BaseColour As Color = Color.FromArgb(62, 62, 66)
    Private _ThumbNormalColour As Color = Color.FromArgb(104, 104, 104)
    Private _ThumbHoverColour As Color = Color.FromArgb(158, 158, 158)
    Private _ThumbPressedColour As Color = Color.FromArgb(239, 235, 239)
    Private _ArrowNormalColour As Color = Color.FromArgb(153, 153, 153)
    Private _ArrowHoveerColour As Color = Color.FromArgb(39, 123, 181)
    Private _ArrowPressedColour As Color = Color.FromArgb(0, 113, 171)
    Private _OuterBorderColour As Color
    Private _ThumbBorderColour As Color
    Public _Minimum As Integer = 0
    Public _Maximum As Integer = 100
    Private _Value As Integer = 0
    Public _SmallChange As Integer = 1
    Private _ButtonSize As Integer = 16
    Public _LargeChange As Integer = 10
    Private _ShowOuterBorder As Boolean = False
    Private _ShowThumbBorder As Boolean = False
    Private _AmountOfInnerLines As __InnerLineCount = __InnerLineCount.None
    Private _MousePos As New Point(_MouseXLoc, _MouseYLoc)
    Private _ThumbState As MouseState = MouseState.None
    Private _ArrowState As MouseState = MouseState.None
    Private _MouseXLoc As Integer
    Private _MouseYLoc As Integer
    Private ThumbMovement As Integer
    Private TSA As Rectangle
    Private BSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle
    Private ShowThumb As Boolean
    Private ThumbPressed As Boolean
    Private _ThumbSize As Integer = 24

#End Region

#Region "Properties & Events"

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property ThumbNormalColour As Color
        Get
            Return _ThumbNormalColour
        End Get
        Set(value As Color)
            _ThumbNormalColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property ThumbHoverColour As Color
        Get
            Return _ThumbHoverColour
        End Get
        Set(value As Color)
            _ThumbHoverColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property ThumbPressedColour As Color
        Get
            Return _ThumbPressedColour
        End Get
        Set(value As Color)
            _ThumbPressedColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property ArrowNormalColour As Color
        Get
            Return _ArrowNormalColour
        End Get
        Set(value As Color)
            _ArrowNormalColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property ArrowHoveerColour As Color
        Get
            Return _ArrowHoveerColour
        End Get
        Set(value As Color)
            _ArrowHoveerColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property ArrowPressedColour As Color
        Get
            Return _ArrowPressedColour
        End Get
        Set(value As Color)
            _ArrowPressedColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property OuterBorderColour As Color
        Get
            Return _OuterBorderColour
        End Get
        Set(value As Color)
            _OuterBorderColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property ThumbBorderColour As Color
        Get
            Return _ThumbBorderColour
        End Get
        Set(value As Color)
            _ThumbBorderColour = value
        End Set
    End Property

    <Category("Control")>
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            InvalidateLayout()
        End Set
    End Property

    <Category("Control")>
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            InvalidateLayout()
        End Set
    End Property

    <Category("Control")>
    Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is = _Value
                    Exit Property
                Case Is < _Minimum
                    _Value = _Minimum
                Case Is > _Maximum
                    _Value = _Maximum
                Case Else
                    _Value = value
            End Select
            InvalidatePosition()
            RaiseEvent Scroll(Me)
        End Set
    End Property

    <Category("Control")>
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 1
                Case Is >
                    CInt(_SmallChange = value)
            End Select
        End Set
    End Property

    <Category("Control")>
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            Select Case value
                Case Is < 1
                Case Else
                    _LargeChange = value
            End Select
        End Set
    End Property

    <Category("Control")>
    Public Property ButtonSize As Integer
        Get
            Return _ButtonSize
        End Get
        Set(value As Integer)
            Select Case value
                Case Is < 16
                    _ButtonSize = 16
                Case Else
                    _ButtonSize = value
            End Select
        End Set
    End Property

    <Category("Control")>
    Property ShowOuterBorder As Boolean
        Get
            Return _ShowOuterBorder
        End Get
        Set(ByVal value As Boolean)
            _ShowOuterBorder = value
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Property ShowThumbBorder As Boolean
        Get
            Return _ShowThumbBorder
        End Get
        Set(ByVal value As Boolean)
            _ShowThumbBorder = value
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Property AmountOfInnerLines As __InnerLineCount
        Get
            Return _AmountOfInnerLines
        End Get
        Set(ByVal value As __InnerLineCount)
            _AmountOfInnerLines = value
        End Set
    End Property

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        ''End Height here goes with end in invalidateposition() for starting height of thumb
        TSA = New Rectangle(0, 0, Width, 16)
        BSA = New Rectangle(0, Height - ButtonSize, Width, ButtonSize)
        ''End height here should be double the start for symetry
        Shaft = New Rectangle(0, TSA.Bottom + 1, Width, CInt(Height - Height / 8 - 8))
        ShowThumb = CBool(((_Maximum - _Minimum)))
        If ShowThumb Then
            Thumb = New Rectangle(4, 0, Width - 8, CInt(Height / 8))
        End If
        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Enum __InnerLineCount
        None
        One
        Two
        Three
    End Enum

    Event Scroll(ByVal sender As Object)

    Public Sub InvalidatePosition()
        Thumb.Y = CInt(((_Value - _Minimum) / (_Maximum - _Minimum)) * (Shaft.Height - _ThumbSize) + 16)
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = System.Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If TSA.Contains(e.Location) Then
                _ArrowState = MouseState.Down
                ThumbMovement = _Value - _SmallChange
            ElseIf BSA.Contains(e.Location) Then
                ThumbMovement = _Value + _SmallChange
                _ArrowState = MouseState.Down
            Else
                If Thumb.Contains(e.Location) Then
                    _ThumbState = MouseState.Down
                    Invalidate()
                    Return
                Else
                    If e.Y < Thumb.Y Then
                        ThumbMovement = _Value - _LargeChange
                    Else
                        ThumbMovement = _Value + _LargeChange
                    End If
                End If
            End If
            Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum)
            Invalidate()
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        _MouseXLoc = e.Location.X
        _MouseYLoc = e.Location.Y
        If TSA.Contains(e.Location) Then
            _ArrowState = MouseState.Over
        ElseIf BSA.Contains(e.Location) Then
            _ArrowState = MouseState.Over
        ElseIf Not _ArrowState = MouseState.Down Then
            _ArrowState = MouseState.None
        End If
        If Thumb.Contains(e.Location) And Not _ThumbState = MouseState.Down Then
            _ThumbState = MouseState.Over
        ElseIf Not _ThumbState = MouseState.Down Then
            _ThumbState = MouseState.None
        End If
        Invalidate()
        If _ThumbState = MouseState.Down Or _ArrowState = MouseState.Down AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.Y + 2 - TSA.Height - (_ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Height - _ThumbSize
            ThumbMovement = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) - _Minimum
            Value = Math.Min(Math.Max(ThumbMovement, _Minimum), _Maximum)
            InvalidatePosition()
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        If Thumb.Contains(e.Location) Then
            _ThumbState = MouseState.Over
        ElseIf Not Thumb.Contains(e.Location) Then
            _ThumbState = MouseState.None
        End If
        If e.Location.Y < 16 Or e.Location.Y > Width - 16 Then
            _ThumbState = MouseState.Over
        ElseIf Not e.Location.Y < 16 Or e.Location.Y > Width - 16 Then
            _ThumbState = MouseState.None
        End If
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        _ThumbState = MouseState.None
        _ArrowState = MouseState.None
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        Invalidate()
    End Sub

#End Region

#Region "Draw Control"
    Dim WithEvents licenseform As New ForestFramework.Licensing
    Sub New()

        If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
            'modo designer
            Try
                licenseform.verification()
            Catch ex As Exception
                MsgBox("We had some problems checking your license, sorry for the inconvenience!")
            End Try

        Else
            'modo realtime


        End If
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or
                            ControlStyles.UserPaint Or ControlStyles.Selectable Or
                            ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(19, 50)
    End Sub

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        Dim g = e.Graphics
        With g
            .TextRenderingHint = TextRenderingHint.AntiAlias
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(_BaseColour)
            Dim TrianglePointTop() As Point = {New Point(CInt(Width / 2), 5), New Point(CInt(Width / 4), 11), New Point(CInt(Width / 2 + Width / 4), 11)}
            Dim TrianglePointBottom() As Point = {New Point(CInt(Width / 2), Height - 5), New Point(CInt(Width / 4), Height - 11), New Point(CInt(Width / 2 + Width / 4), Height - 11)}
            Select Case _ThumbState
                Case MouseState.None
                    Using SBrush As New SolidBrush(_ThumbNormalColour)
                        .FillRectangle(SBrush, Thumb)
                    End Using
                Case MouseState.Over
                    Using SBrush As New SolidBrush(_ThumbHoverColour)
                        .FillRectangle(SBrush, Thumb)
                    End Using
                Case MouseState.Down
                    Using SBrush As New SolidBrush(_ThumbPressedColour)
                        .FillRectangle(SBrush, Thumb)
                    End Using
            End Select
            Select Case _ArrowState
                Case MouseState.Down
                    If Not Thumb.Contains(_MousePos) Then
                        Using SBrush As New SolidBrush(_ThumbNormalColour)
                            .FillRectangle(SBrush, Thumb)
                        End Using
                    End If
                    If _MouseYLoc < 16 Then
                        .FillPolygon(New SolidBrush(_ArrowPressedColour), TrianglePointTop)
                        .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointBottom)

                    ElseIf _MouseXLoc > Width - 16 Then
                        .FillPolygon(New SolidBrush(_ArrowPressedColour), TrianglePointBottom)
                        .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointTop)
                    Else
                        .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointTop)
                        .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointBottom)
                    End If
                Case MouseState.Over

                    If _MouseYLoc < 16 Then
                        .FillPolygon(New SolidBrush(_ArrowHoveerColour), TrianglePointTop)
                        .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointBottom)
                    ElseIf _MouseXLoc > Width - 16 Then
                        .FillPolygon(New SolidBrush(_ArrowHoveerColour), TrianglePointBottom)
                        .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointTop)
                    Else
                        .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointTop)
                        .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointBottom)
                    End If
                Case MouseState.None

                    .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointTop)
                    .FillPolygon(New SolidBrush(_ArrowNormalColour), TrianglePointBottom)
            End Select
            .InterpolationMode = InterpolationMode.HighQualityBicubic
        End With
    End Sub

#End Region


End Class
