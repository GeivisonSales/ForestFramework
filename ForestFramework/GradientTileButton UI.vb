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

Public Class NikyusGradientTileButton_UI

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
    Private _TextActive As Boolean = True
    Private _RoundBorder As Boolean = False
    Private _Round As Integer = 5
    Private _TextOffset As Integer = -5
    Private _Font As New Font("Segoe UI", 12)
    Private _TextColour As Color = Color.FromArgb(255, 255, 255)
    Private _ImageSelect As Image = My.Resources.happy
    Private _PressedImage As Image = My.Resources.pressed_happy
    Private _BorderColour As Color = Color.Transparent
    Private _ImageSize As Size = New Size(70, 70)

    Private _StartColor As Color = Color.FromArgb(43, 70, 240)
    Private _EndColor As Color = Color.FromArgb(87, 110, 255)

    Private _PressedStartColor As Color = Color.FromArgb(43, 70, 240)
    Private _PressedEndColor As Color = Color.FromArgb(87, 110, 255)

    Private _GradientStyle As Style = Style.Horizontal
    Private _Gradientstyleclean As String


    Enum Style
        Horizontal
        Vertical
        BackwardDiagonal
        ForwardDiagonal
    End Enum

#End Region

#Region "Properties"

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
            Me.Invalidate()
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

    <Category("Gradient Colours")>
    Public Property TopStartColor As Color
        Get
            Return _StartColor
        End Get
        Set(value As Color)
            _StartColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property BottomColor As Color
        Get
            Return _EndColor
        End Get
        Set(value As Color)
            _EndColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property Pressed_StartColor As Color
        Get
            Return _PressedStartColor
        End Get
        Set(value As Color)
            _PressedStartColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property Pressed_BottomColor As Color
        Get
            Return _PressedEndColor
        End Get
        Set(value As Color)
            _PressedEndColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property GradientStyle As Style
        Get
            Return _GradientStyle
        End Get
        Set(ByVal value As Style)
            _GradientStyle = value
            Invalidate()

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
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)


            Dim wid As Single = Width - _ImageSize.Width / 2
            Dim hei As Single = Height - _ImageSize.Height / 2

            If _TextActive = True Then
                'com texto---------------------------------------------------

                If _RoundBorder = True Then
                    'Com round borders

                    Dim rect As New Rectangle(0, 0, Width, Height)
                    If _GradientStyle = Style.Horizontal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                        End Select

                    ElseIf _GradientStyle = Style.Vertical Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                        End Select

                    ElseIf _GradientStyle = Style.ForwardDiagonal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                        End Select

                    ElseIf _GradientStyle = Style.BackwardDiagonal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                        End Select

                    End If



                Else
                    'Sem round Borders

                    Dim rect As New Rectangle(0, 0, Width, Height)
                    If _GradientStyle = Style.Horizontal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                        End Select

                    ElseIf _GradientStyle = Style.Vertical Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                        End Select

                    ElseIf _GradientStyle = Style.ForwardDiagonal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                        End Select

                    ElseIf _GradientStyle = Style.BackwardDiagonal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(0, _TextOffset, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far})

                        End Select

                    End If


                End If

            Else
                'sem texto------------------------------------------------------------

                If _RoundBorder = True Then
                    'Com round borders

                    Dim rect As New Rectangle(0, 0, Width, Height)
                    If _GradientStyle = Style.Horizontal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                        End Select

                    ElseIf _GradientStyle = Style.Vertical Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                        End Select

                    ElseIf _GradientStyle = Style.ForwardDiagonal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                        End Select

                    ElseIf _GradientStyle = Style.BackwardDiagonal Then

                        Select Case State
                            Case MouseState.None

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, _Round)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                        End Select

                    End If


                Else
                    'sem round borders

                    Dim rect As New Rectangle(0, 0, Width, Height)
                    If _GradientStyle = Style.Horizontal Then

                        Select Case State
                            Case MouseState.None
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                        End Select

                    ElseIf _GradientStyle = Style.Vertical Then

                        Select Case State
                            Case MouseState.None
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                        End Select

                    ElseIf _GradientStyle = Style.ForwardDiagonal Then

                        Select Case State
                            Case MouseState.None
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                        End Select

                    ElseIf _GradientStyle = Style.BackwardDiagonal Then

                        Select Case State
                            Case MouseState.None
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 1), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Over
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                            Case MouseState.Down
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect)
                                .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                .DrawRectangle(New Pen(_BorderColour, 2), New Rectangle(0, 0, Width, Height))


                        End Select

                    End If



                End If
            End If


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

    Private Sub GradientImageButton_UI_Click(sender As Object, e As EventArgs) Handles Me.Click
        pos = PointToClient(MousePosition)
        AnimationBack.[Stop]()
        Animation.Start()
        sw.Reset()
        sw.[Stop]()
        sw.Start()
    End Sub


#End Region

End Class
