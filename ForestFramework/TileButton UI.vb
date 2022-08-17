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

Public Class NikyusTileButton_UI

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
    Private _GifAnimated As Boolean = False
    Private _TextActive As Boolean = True
    Private _RoundBorder As Boolean = False
    Private _Round As Integer = 5
    Private _TextOffset As Integer = -5
    Private _Font As New Font("Segoe UI", 12)
    Private _BaseColour As Color = Color.FromArgb(43, 70, 240)
    Private _PressedBaseColour As Color = Color.FromArgb(87, 110, 255)
    Private _TextColour As Color = Color.FromArgb(255, 255, 255)
    Private _ImageSelect As Image = My.Resources.happy
    Private _PressedImage As Image = My.Resources.pressed_happy
    Private _BorderColour As Color = Color.Transparent
    Private _ImageSize As Size = New Size(70, 70)

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
    Private _TextChecked As String

    Private _TextRender As TextRenderingHint

    Enum ButtonStyle
        Normal
        ToogleButton
    End Enum


    'ToogleButton + Patch 2.1------------------------------------------

#End Region

#Region "Properties"

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
            Me.Invalidate()
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
            Me.Invalidate()
        End Set
    End Property
    <Category("Colours")>
    Public Property ImageSelect As Image
        Get
            Return _ImageSelect
        End Get
        Set(value As Image)
            _ImageSelect = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property ImageSize As Size
        Get
            Return _ImageSize
        End Get
        Set(value As Size)
            _ImageSize = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property PressedImage As Image
        Get
            Return _PressedImage
        End Get
        Set(value As Image)
            _PressedImage = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property TextActive As Boolean
        Get
            Return _TextActive
        End Get
        Set(value As Boolean)
            _TextActive = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property RoundBorders As Boolean
        Get
            Return _RoundBorder
        End Get
        Set(value As Boolean)
            _RoundBorder = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property Round As Integer
        Get
            Return _Round
        End Get
        Set(value As Integer)
            _Round = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property TextOffsetY As Integer
        Get
            Return _TextOffset
        End Get
        Set(value As Integer)
            _TextOffset = value
            Me.Invalidate()
        End Set
    End Property

    Overrides Property Font As Font
        Get
            Return _Font
        End Get
        Set(value As Font)
            _Font = value
            Me.Invalidate()
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
        Size = New Size(136, 129)
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
            .Clear(BackColor)


            Dim wid As Single = Width - _ImageSize.Width / 2
            Dim hei As Single = Height - _ImageSize.Height / 2


            Select Case _ButtonStyle
                Case ButtonStyle.Normal 'Normal Button

                    If _TextActive = True Then
                        'com texto---------------------------------------------------

                        If _RoundBorder = True Then
                            'Com round borders

                            Select Case State
                                Case MouseState.None

                                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height, _Round)
                                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                Case MouseState.Over
                                    .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                    .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                Case MouseState.Down
                                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                    .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            End Select


                        Else
                            'Sem round Borders


                            Select Case State
                                Case MouseState.None

                                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                Case MouseState.Over
                                    .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                    .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                Case MouseState.Down
                                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                    .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            End Select

                        End If

                    Else
                        'sem texto------------------------------------------------------------

                        If _RoundBorder = True Then
                            'Com round borders

                            Select Case State
                                Case MouseState.None

                                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height, _Round)
                                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                                Case MouseState.Over
                                    .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderHoverColour, 2), New Rectangle(0, 0, Width, Height))


                                Case MouseState.Down
                                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                    .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            End Select

                        Else
                            'sem round borders

                            Select Case State
                                Case MouseState.None

                                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                                Case MouseState.Over
                                    .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderHoverColour, 2), New Rectangle(0, 0, Width, Height))


                                Case MouseState.Down
                                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                    .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            End Select

                        End If
                    End If

                Case ButtonStyle.ToogleButton 'Toogle Button

                    If _Checked = True Then 'Toogle Ativo

                        If _TextActive = True Then
                            'com texto---------------------------------------------------

                            If _RoundBorder = True Then
                                'Com round borders

                                Select Case State
                                    Case MouseState.None

                                        .FillRectangle(New SolidBrush(_BaseCheckedColor), 0, 0, Width, Height, _Round)
                                        .DrawImage(_ImageCheckedSelect, CInt(Width / 2) - CInt(_ImageCheckedSize.Width / 2), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                        .DrawRectangle(New Pen(_BorderCheckedColor, 1), New Rectangle(0, 0, Width, Height))
                                        .DrawString(_TextChecked, _Font, New SolidBrush(_TextCheckedColor), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                    Case MouseState.Over
                                        .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                        .DrawString(_TextChecked, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                    Case MouseState.Down
                                        .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                        .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                End Select


                            Else
                                'Sem round Borders


                                Select Case State
                                    Case MouseState.None

                                        .FillRectangle(New SolidBrush(_BaseCheckedColor), 0, 0, Width, Height)
                                        .DrawImage(_ImageCheckedSelect, CInt(Width / 2) - CInt(_ImageCheckedSize.Width / 2), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                        .DrawRectangle(New Pen(_BorderCheckedColor, 1), New Rectangle(0, 0, Width, Height))
                                        .DrawString(_TextChecked, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                    Case MouseState.Over
                                        .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                        .DrawString(_TextChecked, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                    Case MouseState.Down
                                        .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                        .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                        .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                End Select

                            End If

                        Else
                            'sem texto------------------------------------------------------------

                            If _RoundBorder = True Then
                                'Com round borders

                                Select Case State
                                    Case MouseState.None

                                        .FillRectangle(New SolidBrush(_BaseCheckedColor), 0, 0, Width, Height, _Round)
                                        .DrawImage(_ImageCheckedSelect, CInt(Width / 2) - CInt(_ImageCheckedSize.Width / 2), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                        .DrawRectangle(New Pen(_BorderCheckedColor, 1), New Rectangle(0, 0, Width, Height))


                                    Case MouseState.Over
                                        .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderHoverColour, 2), New Rectangle(0, 0, Width, Height))


                                    Case MouseState.Down
                                        .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                                End Select

                            Else
                                'sem round borders

                                Select Case State
                                    Case MouseState.None

                                        .FillRectangle(New SolidBrush(_BaseCheckedColor), 0, 0, Width, Height)
                                        .DrawImage(_ImageCheckedSelect, CInt(Width / 2) - CInt(_ImageCheckedSize.Width / 2), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                                    Case MouseState.Over
                                        .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderHoverColour, 2), New Rectangle(0, 0, Width, Height))


                                    Case MouseState.Down
                                        .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                        .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                                End Select

                            End If
                        End If

                    Else 'Toogle Desativado

                        If _TextActive = True Then
                            'com texto---------------------------------------------------

                            If _RoundBorder = True Then
                                'Com round borders

                                Select Case State
                                    Case MouseState.None

                                        .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                        .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                    Case MouseState.Over
                                        .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                        .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                    Case MouseState.Down
                                        .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                        .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                End Select


                            Else
                                'Sem round Borders


                                Select Case State
                                    Case MouseState.None

                                        .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                        .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                    Case MouseState.Over
                                        .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                        .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                    Case MouseState.Down
                                        .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                        .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                        .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                                End Select

                            End If

                        Else
                            'sem texto------------------------------------------------------------

                            If _RoundBorder = True Then
                                'Com round borders

                                Select Case State
                                    Case MouseState.None

                                        .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                                    Case MouseState.Over
                                        .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderHoverColour, 2), New Rectangle(0, 0, Width, Height))


                                    Case MouseState.Down
                                        .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height, _Round)
                                        .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                                End Select

                            Else
                                'sem round borders

                                Select Case State
                                    Case MouseState.None

                                        .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                                    Case MouseState.Over
                                        .FillRectangle(New SolidBrush(_BaseHoverColour), 0, 0, Width, Height)
                                        .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderHoverColour, 2), New Rectangle(0, 0, Width, Height))


                                    Case MouseState.Down
                                        .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                                        .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                        .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                                End Select

                            End If
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
                    'G.DrawString("Trial NikyusUI", New Font("Arial", 22), New SolidBrush(Color.FromArgb(50, Color.White)), 0, 0)
                End If
            Catch ex As Exception

            End Try

        End If

        MyBase.OnPaint(e)
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

    Private Sub ImageButton_UI_Click(sender As Object, e As EventArgs) Handles Me.Click
        pos = PointToClient(MousePosition)
        AnimationBack.[Stop]()
        Animation.Start()
        sw.Reset()
        sw.[Stop]()
        sw.Start()
    End Sub


#End Region


End Class
