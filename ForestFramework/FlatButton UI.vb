Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Drawing
Imports ForestFramework.DrawHelpers
Imports ForestFramework.ExtendedGraphics
Imports ForestFramework.NotificationCounter

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusFlatButton_UI

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
    Private State As MouseState = MouseState.None
    Private _RoundBorder As Boolean = False
    Private _Round As Integer = 5
    Private _Font As New Font("Segoe UI", 12)
    Private _BaseColour As Color = Color.FromArgb(43, 70, 240)
    Private _PressedBaseColour As Color = Color.FromArgb(87, 110, 255)
    Private _TextColour As Color = Color.FromArgb(255, 255, 255)
    Private _PressedTextColour As Color = Color.FromArgb(255, 255, 255)
    Private _BorderColour As Color = Color.Transparent

    Private _ImageActived As Boolean = False
    Private _ImageSelect As Image = My.Resources.happy
    Private _PressedImage As Image = My.Resources.pressed_happy
    Private _ImageSize As Size = New Size(20, 20)
    Private _ImageOffset As Integer = 7
    Private _RoundImage As Boolean = False
    Private _IconRound As Integer = 5
    Private _BorderSize As Integer = 3
    Private _IconDirection As Direction
    Private _BorderStyle As Style

    Private _NotificationEnabled As Boolean = False
    Private _NotificationColor As Color = Color.Red
    Private _NotificationFontColor As Color = Color.White
    Private _NotificationDirection As Direction
    Private _NotificationText As Integer = 30
    Private _NotificationOffset As Integer = 0
    Private _NotificationRound As Integer = 0


    'ToogleButton + Patch 2.1------------------------------------------
    Private _BaseHoverColour As Color = Color.FromArgb(43, 70, 240)
    Private _TextHoverColour As Color = Color.White
    Private _BorderHoverColour As Color = Color.Transparent

    Private _ButtonStyle As ButtonStyle
    Private _BaseCheckedColor As Color
    Private _TextCheckedColor As Color = Color.White
    Private _BorderCheckedColor As Color
    Private _Checked As Boolean

    Private _ImageCheckedSelect As Image = My.Resources.happy
    Private _ImageCheckedSize As Size = New Size(20, 20)
    Private _ImageCheckedOffset As Integer = 7
    Private _IconCheckedDirection As Direction
    Private _TextChecked As String

    Private _TextRender As TextRenderingHint

    Enum ButtonStyle
        Normal
        ToogleButton
    End Enum
    'ToogleButton + Patch 2.1------------------------------------------

    Enum Direction
        Left
        Right
    End Enum

    Enum Style
        None
        Left
        Right
        Top
        Bottom
    End Enum
#End Region

#Region "Properties"

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property PressedBaseColour As Color
        Get
            Return _PressedBaseColour
        End Get
        Set(value As Color)
            _PressedBaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
            Invalidate()
        End Set
    End Property
    <Category("Colours")>
    Public Property PressedTextColour As Color
        Get
            Return _PressedTextColour
        End Get
        Set(value As Color)
            _PressedTextColour = value
        End Set
    End Property
    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property RoundCorners As Boolean
        Get
            Return _RoundBorder
        End Get
        Set(value As Boolean)
            _RoundBorder = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property Round As Integer
        Get
            Return _Round
        End Get
        Set(value As Integer)
            _Round = value
            Invalidate()
        End Set
    End Property

    Overrides Property Font As Font
        Get
            Return _Font
        End Get
        Set(value As Font)
            _Font = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ImageSelect As Image
        Get
            Return _ImageSelect
        End Get
        Set(value As Image)
            _ImageSelect = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ImageSize As Size
        Get
            Return _ImageSize
        End Get
        Set(value As Size)
            _ImageSize = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property PressedImage As Image
        Get
            Return _PressedImage
        End Get
        Set(value As Image)
            _PressedImage = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ImageOffsetX As Integer
        Get
            Return _ImageOffset
        End Get
        Set(value As Integer)
            _ImageOffset = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ActiveIcon As Boolean
        Get
            Return _ImageActived
        End Get
        Set(value As Boolean)
            _ImageActived = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property RoundImage As Boolean
        Get
            Return _RoundImage
        End Get
        Set(value As Boolean)
            _RoundImage = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property IconDirection As Direction
        Get
            Return _IconDirection
        End Get
        Set(ByVal value As Direction)
            _IconDirection = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property BorderSize As Integer
        Get
            Return _BorderSize
        End Get
        Set(value As Integer)
            _BorderSize = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property BorderStyle As Style
        Get
            Return _BorderStyle
        End Get
        Set(ByVal value As Style)
            _BorderStyle = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationEnabled As Boolean
        Get
            Return _NotificationEnabled
        End Get
        Set(value As Boolean)
            _NotificationEnabled = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationColor As Color
        Get
            Return _NotificationColor
        End Get
        Set(value As Color)
            _NotificationColor = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationFontColor As Color
        Get
            Return _NotificationFontColor
        End Get
        Set(value As Color)
            _NotificationFontColor = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationCount As Integer
        Get
            Return _NotificationText
        End Get
        Set(value As Integer)
            _NotificationText = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationDirection As Direction
        Get
            Return _NotificationDirection
        End Get
        Set(value As Direction)
            _NotificationDirection = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationOffsetX As Integer
        Get
            Return _NotificationOffset
        End Get
        Set(value As Integer)
            _NotificationOffset = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationRound As Integer
        Get
            Return _NotificationRound
        End Get
        Set(value As Integer)

            If value > 9 Then
                _NotificationRound = 9
                value = 9
            Else
                _NotificationRound = value
            End If

            Invalidate()
        End Set
    End Property

    'ToogleButton + Patch 2.1------------------------------------------
    <Category("Options")>
    Public Property StyleButton As ButtonStyle
        Get
            Return _ButtonStyle
        End Get
        Set(ByVal value As ButtonStyle)
            _ButtonStyle = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedBaseColour As Color
        Get
            Return _BaseCheckedColor
        End Get
        Set(value As Color)
            _BaseCheckedColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedTextColour As Color
        Get
            Return _TextCheckedColor
        End Get
        Set(value As Color)
            _TextCheckedColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedBorderColour As Color
        Get
            Return _BorderCheckedColor
        End Get
        Set(value As Color)
            _BorderCheckedColor = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property CheckedImageSelect As Image
        Get
            Return _ImageCheckedSelect
        End Get
        Set(value As Image)
            _ImageCheckedSelect = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property CheckedImageSize As Size
        Get
            Return _ImageCheckedSize
        End Get
        Set(value As Size)
            _ImageCheckedSize = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property CheckedImageOffsetX As Integer
        Get
            Return _ImageCheckedOffset
        End Get
        Set(value As Integer)
            _ImageCheckedOffset = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property CheckedIconDirection As Direction
        Get
            Return _IconCheckedDirection
        End Get
        Set(value As Direction)
            _IconCheckedDirection = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property CheckedText As String
        Get
            Return _TextChecked
        End Get
        Set(value As String)
            _TextChecked = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property TextRendering As TextRenderingHint
        Get
            Return _TextRender
        End Get
        Set(value As TextRenderingHint)
            _TextRender = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverBaseColour As Color
        Get
            Return _BaseHoverColour
        End Get
        Set(value As Color)
            _BaseHoverColour = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverBorderColour As Color
        Get
            Return _BorderHoverColour
        End Get
        Set(value As Color)
            _BorderHoverColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverTextColour As Color
        Get
            Return _TextHoverColour
        End Get
        Set(value As Color)
            _TextHoverColour = value
            Invalidate()
        End Set
    End Property

    'ToogleButton + Patch 2.1------------------------------------------


#End Region

#Region "Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If _ButtonStyle = ButtonStyle.ToogleButton Then
            If _Checked = True Then
                _Checked = False
            Else
                _Checked = True

            End If
        End If
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region "Ripple Animation"
    Private sw As Stopwatch = New Stopwatch()
    Private pos

    <Category("Animation")>
    Public Property RippleEffect As Boolean = False
    <Category("Animation")>
    Private Property Animation As Timer = New Timer()
    <Category("Animation")>
    Private Property AnimationBack As Timer = New Timer()
    <Category("Animation")>
    Public Property AnimationInterval As Integer = 1

    Public BackgroundSpeed As Integer = 40
    <Category("Animation")>
    Public Property SmoothCorrectionFactor As Double = 2.5F
    <Category("Animation")>
    Public Property UseSmoothSpeedIncrement As Boolean = True

    Private incremental_x As Integer = 1

    Private Sub ButtonAnimationBack(ByVal sender As Object, ByVal e As EventArgs)

        If UseSmoothSpeedIncrement Then
            incremental_x -= Convert.ToInt32(BackgroundSpeed * sw.Elapsed.TotalSeconds * SmoothCorrectionFactor)
        Else
            incremental_x -= BackgroundSpeed
        End If

        If incremental_x <= 0 Then
            AnimationBack.[Stop]()
            incremental_x = 1
        End If

        Me.Invalidate()
    End Sub

    Private Sub ButtonAnimation(ByVal sender As Object, ByVal e As EventArgs)

        If UseSmoothSpeedIncrement Then
            incremental_x += Convert.ToInt32(BackgroundSpeed * sw.Elapsed.TotalSeconds * SmoothCorrectionFactor)
        Else
            incremental_x += BackgroundSpeed
        End If

        If incremental_x > Me.Width * 2 Then
            Animation.[Stop]()
        End If

        Me.Invalidate()
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
        Me.SetStyle(System.Windows.Forms.ControlStyles.UserPaint Or System.Windows.Forms.ControlStyles.AllPaintingInWmPaint Or System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, True)
        Animation.Interval = AnimationInterval
        AnimationBack.Interval = AnimationInterval
        AddHandler Animation.Tick, (AddressOf ButtonAnimation)
        AddHandler AnimationBack.Tick, (AddressOf ButtonAnimationBack)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
              ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
              ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(165, 40)
        BackColor = Color.Transparent

    End Sub





    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim GP, GP1 As New GraphicsPath




        With G
            .TextRenderingHint = _TextRender
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            .Clear(BackColor)

            Dim wid As Single = Width - _ImageSize.Width / 2
            Dim hei As Single = Height - _ImageSize.Height / 2



            Select Case _ButtonStyle
                Case ButtonStyle.Normal 'Normal Button

                    If _RoundBorder = True Then
                        'Com round borders

                        Select Case State
                            Case MouseState.None
                                .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height, _Round)
                                'BorderStyle
                                If _BorderStyle = Style.None Then
                                    '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(1, 1, Width - _BorderSize, Height - _BorderSize), _Round)

                                    Dim p As New Pen(_BorderColour, _BorderSize)
                                    DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)

                                ElseIf _BorderStyle = Style.Right Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                ElseIf _BorderStyle = Style.Left Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                ElseIf _BorderStyle = Style.Bottom Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                ElseIf _BorderStyle = Style.Top Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                End If
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                'image icon
                                If _ImageActived = True Then



                                    If _RoundImage = True Then
                                        'round image true
                                        Select Case _IconDirection
                                            Case Direction.Left

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    Else
                                        'round image false
                                        Select Case _IconDirection
                                            Case Direction.Left
                                                'esquerda
                                                'no round pic
                                                .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right
                                                'direita
                                                'no round pic
                                                .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    End If

                                Else


                                End If

                            Case MouseState.Over
                                .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                'BorderStyle
                                If _BorderStyle = Style.None Then
                                    '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height), _Round)
                                    Dim p As New Pen(_BorderHoverColour, _BorderSize)
                                    DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)
                                ElseIf _BorderStyle = Style.Right Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                ElseIf _BorderStyle = Style.Left Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                ElseIf _BorderStyle = Style.Bottom Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                ElseIf _BorderStyle = Style.Top Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                End If
                                .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                'image icon
                                If _ImageActived = True Then
                                    'image icon
                                    If _RoundImage = True Then
                                        'round image true
                                        Select Case _IconDirection
                                            Case Direction.Left

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    Else
                                        'round image false
                                        Select Case _IconDirection
                                            Case Direction.Left
                                                'esquerda
                                                'no round pic
                                                .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right
                                                'direita
                                                'no round pic
                                                .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    End If
                                End If

                            Case MouseState.Down
                                .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                'BorderStyle
                                If _BorderStyle = Style.None Then
                                    '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height), _Round)
                                    Dim p As New Pen(_BorderColour, _BorderSize)
                                    DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)
                                ElseIf _BorderStyle = Style.Right Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                ElseIf _BorderStyle = Style.Left Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                ElseIf _BorderStyle = Style.Bottom Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                ElseIf _BorderStyle = Style.Top Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                End If
                                .DrawString(Text, _Font, New SolidBrush(_PressedTextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                'image icon
                                If _ImageActived = True Then



                                    If _RoundImage = True Then
                                        'round image true
                                        Select Case _IconDirection
                                            Case Direction.Left

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    Else
                                        'round image false
                                        Select Case _IconDirection
                                            Case Direction.Left
                                                'esquerda
                                                'no round pic
                                                .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right
                                                'direita
                                                'no round pic
                                                .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    End If

                                Else


                                End If

                        End Select

                    Else
                        'sem round borders

                        Select Case State
                            Case MouseState.None
                                .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                                'BorderStyle
                                If _BorderStyle = Style.None Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height))
                                ElseIf _BorderStyle = Style.Right Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                ElseIf _BorderStyle = Style.Left Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                ElseIf _BorderStyle = Style.Bottom Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                ElseIf _BorderStyle = Style.Top Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                End If
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                'image icon
                                If _ImageActived = True Then



                                    If _RoundImage = True Then
                                        'round image true
                                        Select Case _IconDirection
                                            Case Direction.Left

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    Else
                                        'round image false
                                        Select Case _IconDirection
                                            Case Direction.Left
                                                'esquerda
                                                'no round pic
                                                .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right
                                                'direita
                                                'no round pic
                                                .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    End If

                                Else


                                End If

                            Case MouseState.Over
                                .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                'BorderStyle
                                If _BorderStyle = Style.None Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, Height))
                                ElseIf _BorderStyle = Style.Right Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                ElseIf _BorderStyle = Style.Left Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                ElseIf _BorderStyle = Style.Bottom Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                ElseIf _BorderStyle = Style.Top Then
                                    .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                End If
                                .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                'image icon
                                If _ImageActived = True Then



                                    If _RoundImage = True Then
                                        'round image true
                                        Select Case _IconDirection
                                            Case Direction.Left

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    Else
                                        'round image false
                                        Select Case _IconDirection
                                            Case Direction.Left
                                                'esquerda
                                                'no round pic
                                                .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right
                                                'direita
                                                'no round pic
                                                .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    End If

                                Else


                                End If

                            Case MouseState.Down
                                .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                'BorderStyle
                                If _BorderStyle = Style.None Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height))
                                ElseIf _BorderStyle = Style.Right Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                ElseIf _BorderStyle = Style.Left Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                ElseIf _BorderStyle = Style.Bottom Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                ElseIf _BorderStyle = Style.Top Then
                                    .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                End If
                                .DrawString(Text, _Font, New SolidBrush(_PressedTextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})


                                'image icon
                                If _ImageActived = True Then



                                    If _RoundImage = True Then
                                        'round image true
                                        Select Case _IconDirection
                                            Case Direction.Left

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right

                                                'Round Pic
                                                Dim path As New GraphicsPath
                                                path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                Dim reg As New Region(path)
                                                .Clip = reg
                                                .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    Else
                                        'round image false
                                        Select Case _IconDirection
                                            Case Direction.Left
                                                'esquerda
                                                'no round pic
                                                .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            Case Direction.Right
                                                'direita
                                                'no round pic
                                                .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                        End Select



                                    End If

                                Else


                                End If

                        End Select

                    End If

                Case ButtonStyle.ToogleButton 'Toogle Button-------------------------------------------------------------------------------------------------

                    If _Checked = True Then 'toogle ativo


                        If _RoundBorder = True Then
                            'Com round borders

                            Select Case State
                                Case MouseState.None
                                    .FillRectangle(New SolidBrush(_BaseCheckedColor), 0, 0, Width, Height, _Round)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(1, 1, Width - _BorderSize, Height - _BorderSize), _Round)

                                        Dim p As New Pen(_BorderCheckedColor, _BorderSize)
                                        DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)

                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                    End If
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextCheckedColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                                Case MouseState.Over
                                    .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height), _Round)
                                        Dim p As New Pen(_BorderHoverColour, _BorderSize)
                                        DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                    End If
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then
                                        'image icon
                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                            End Select



                                        End If
                                    End If

                                Case MouseState.Down
                                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height), _Round)
                                        Dim p As New Pen(_BorderColour, _BorderSize)
                                        DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                    End If
                                    .DrawString(Text, _Font, New SolidBrush(_PressedTextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                            End Select

                        Else
                            'sem round borders

                            Select Case State
                                Case MouseState.None
                                    .FillRectangle(New SolidBrush(_BaseCheckedColor), 0, 0, Width, Height)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(0, 0, Width, Height))
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderCheckedColor, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                    End If
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextCheckedColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                                Case MouseState.Over
                                    .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, Height))
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                    End If
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                                Case MouseState.Down
                                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height))
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                    End If
                                    .DrawString(Text, _Font, New SolidBrush(_PressedTextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})


                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconCheckedDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                            End Select

                        End If



                    Else 'toogle desativado

                        If _RoundBorder = True Then
                            'Com round borders

                            Select Case State
                                Case MouseState.None
                                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height, _Round)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(1, 1, Width - _BorderSize, Height - _BorderSize), _Round)

                                        Dim p As New Pen(_BorderColour, _BorderSize)
                                        DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)

                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                    End If
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                                Case MouseState.Over
                                    .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height), _Round)
                                        Dim p As New Pen(_BorderHoverColour, _BorderSize)
                                        DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                    End If
                                    .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then
                                        'image icon
                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        End If
                                    End If

                                Case MouseState.Down
                                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        '.DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height), _Round)
                                        Dim p As New Pen(_BorderColour, _BorderSize)
                                        DrawRoundedRectangle(p, G, 1, 1, Width - _BorderSize, Height - _BorderSize, _Round)
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height), _Round)
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize), _Round)
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize), _Round)
                                    End If
                                    .DrawString(Text, _Font, New SolidBrush(_PressedTextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                            End Select

                        Else
                            'sem round borders

                            Select Case State
                                Case MouseState.None
                                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height))
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                    End If
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                                Case MouseState.Over
                                    .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, Height))
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderHoverColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                    End If
                                    .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                                Case MouseState.Down
                                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                    'BorderStyle
                                    If _BorderStyle = Style.None Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, Height))
                                    ElseIf _BorderStyle = Style.Right Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(Width - _BorderSize, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Left Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, _BorderSize, Height))
                                    ElseIf _BorderStyle = Style.Bottom Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, Height - _BorderSize, Width, _BorderSize))
                                    ElseIf _BorderStyle = Style.Top Then
                                        .DrawRectangle(New Pen(_BorderColour, _BorderSize), New Rectangle(0, 0, Width, _BorderSize))
                                    End If
                                    .DrawString(Text, _Font, New SolidBrush(_PressedTextColour), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})


                                    'image icon
                                    If _ImageActived = True Then



                                        If _RoundImage = True Then
                                            'round image true
                                            Select Case _IconDirection
                                                Case Direction.Left

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(_ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right

                                                    'Round Pic
                                                    Dim path As New GraphicsPath
                                                    path.AddEllipse(CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                                    Dim reg As New Region(path)
                                                    .Clip = reg
                                                    .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        Else
                                            'round image false
                                            Select Case _IconDirection
                                                Case Direction.Left
                                                    'esquerda
                                                    'no round pic
                                                    .DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                                Case Direction.Right
                                                    'direita
                                                    'no round pic
                                                    .DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

                                            End Select



                                        End If

                                    Else


                                    End If

                            End Select

                        End If


                    End If




            End Select




            'Animation
            If RippleEffect = True Then
                If incremental_x <> 1 Then
                    Dim pn As New Pen(Color.FromArgb(80, 224, 224, 224), incremental_x)
                    G.DrawEllipse(pn, CInt(pos.X - incremental_x / 2), CInt(pos.Y - incremental_x / 2), incremental_x, incremental_x)
                End If
                If incremental_x >= Width + Height Then
                    Animation.[Stop]()
                    incremental_x = 0
                    Invalidate()
                    sw.Reset()
                    sw.[Stop]()
                    sw.Start()
                End If
            End If

        End With

        'Notification Counter
        If _NotificationEnabled = True Then
            Dim _notTxt As String = _NotificationText
            If _notTxt > 99 Then
                _notTxt = "99+"
            End If

            If _NotificationDirection = Direction.Left Then
                If _notTxt = "99+" Then
                    DrawNotification(G, Me, 3 + _NotificationOffset, Height / 2 - 14 + 6 / 2, _NotificationColor, _NotificationFontColor, New Size(20, 14), _notTxt, _NotificationRound)
                Else
                    DrawNotification(G, Me, 3 + _NotificationOffset, Height / 2 - 14 + 6 / 2, _NotificationColor, _NotificationFontColor, New Size(16, 14), _notTxt, _NotificationRound)
                End If

            ElseIf _NotificationDirection = Direction.Right Then
                If _notTxt = "99+" Then
                    DrawNotification(G, Me, Width - 30 - _NotificationOffset, Height / 2 - 14 + 6 / 2, _NotificationColor, _NotificationFontColor, New Size(20, 14), _notTxt, _NotificationRound)
                Else
                    DrawNotification(G, Me, Width - 25 - _NotificationOffset, Height / 2 - 14 + 6 / 2, _NotificationColor, _NotificationFontColor, New Size(16, 14), _notTxt, _NotificationRound)
                End If

            End If
        End If

        If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
            'modo designer
            Try

                If My.Settings.status = "error" Or My.Settings.status = "waiting" Then
                    G.DrawString("Trial NikyusUI", New Font("Arial", 22), New SolidBrush(Color.FromArgb(50, Color.White)), 0, 0)
                End If
            Catch ex As Exception

            End Try

        Else
            'modo realtime

            Try

                If My.Settings.status = "error" Or My.Settings.status = "waiting" Then
                    ' G.DrawString("Trial NikyusUI", New Font("Arial", 22), New SolidBrush(Color.FromArgb(50, Color.White)), 0, 0)
                End If
            Catch ex As Exception

            End Try

        End If

        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

    Private Sub FlatButton_UI_Click(sender As Object, e As EventArgs) Handles Me.Click
        pos = PointToClient(MousePosition)
        AnimationBack.[Stop]()
        Animation.Start()
        sw.Reset()
        sw.[Stop]()
        sw.Start()
    End Sub


    Public Sub DrawRoundedRectangle(ByVal pen1 As Pen, ByVal objGraphics As Graphics, ByVal m_intxAxis As Integer, ByVal m_intyAxis As Integer, ByVal m_intWidth As Integer, ByVal m_intHeight As Integer, ByVal m_diameter As Integer)
        objGraphics.TextRenderingHint = _TextRender
        objGraphics.SmoothingMode = SmoothingMode.HighQuality
        objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

        'Dim g As Graphics
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))

        'Dim pen1 As New Pen(_borderColor, _borderThickness)
        'top left Arc
        objGraphics.DrawArc(pen1, ArcRect, 180, 90)
        objGraphics.DrawLine(pen1, m_intxAxis + CInt(m_diameter / 2) - 3, m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2) + 3, m_intyAxis)

        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(pen1, ArcRect, 270, 90)
        objGraphics.DrawLine(pen1, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(pen1, ArcRect, 0, 90)
        objGraphics.DrawLine(pen1, m_intxAxis + CInt(m_diameter / 2) - 3, m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2) + 3, m_intyAxis + m_intHeight)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(pen1, ArcRect, 90, 90)
        objGraphics.DrawLine(pen1, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

    End Sub



#End Region


End Class
