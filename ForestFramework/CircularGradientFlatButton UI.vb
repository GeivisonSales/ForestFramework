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

Public Class NikyusCircularGradientFlatButton_UI

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

    Private _StartColor As Color = Color.FromArgb(43, 70, 240)
    Private _EndColor As Color = Color.FromArgb(87, 110, 255)

    Private _PressedStartColor As Color = Color.FromArgb(43, 70, 240)
    Private _PressedEndColor As Color = Color.FromArgb(87, 110, 255)

    Private _GradientStyle As Style = Style.Horizontal
    Private _Gradientstyleclean As String

    'ToogleButton + Patch 2.1------------------------------------------
    Private _StartHoverColor As Color = Color.FromArgb(43, 70, 240)
    Private _EndHoverColor As Color = Color.FromArgb(87, 110, 255)
    Private _TextHoverColour As Color = Color.White
    Private _BorderHoverColour As Color = Color.Transparent

    Private _ButtonStyle As ButtonStyle
    Private _StartCheckedColor As Color
    Private _EndCheckedColor As Color
    Private _TextCheckedColor As Color = Color.White
    Private _BorderCheckedColor As Color
    Private _Checked As Boolean

    'Private _ImageCheckedSelect As Image = My.Resources.happy
    'Private _ImageCheckedSize As Size = New Size(20, 20)
    'Private _ImageCheckedOffset As Integer = 7
    'Private _IconCheckedDirection As Direction
    Private _TextChecked As String 

    Private _TextRender As TextRenderingHint

    Enum ButtonStyle
        Normal
        ToogleButton
    End Enum
    'ToogleButton + Patch 2.1------------------------------------------


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

    <Category("Gradient Colours")>
    Public Property TopStartColor As Color
        Get
            Return _StartColor
        End Get
        Set(value As Color)
            _StartColor = value
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property BottomColor As Color
        Get
            Return _EndColor
        End Get
        Set(value As Color)
            _EndColor = value
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property Pressed_StartColor As Color
        Get
            Return _PressedStartColor
        End Get
        Set(value As Color)
            _PressedStartColor = value
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property Pressed_BottomColor As Color
        Get
            Return _PressedEndColor
        End Get
        Set(value As Color)
            _PressedEndColor = value
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

    Overrides Property Font As Font
        Get
            Return _Font
        End Get
        Set(value As Font)
            _Font = value
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

    <Category("Gradient Colours")>
    Public Property CheckedTopStartColour As Color
        Get
            Return _StartCheckedColor
        End Get
        Set(value As Color)
            _StartCheckedColor = value
            Invalidate()
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property CheckedBottomColor As Color
        Get
            Return _EndCheckedColor
        End Get
        Set(value As Color)
            _EndCheckedColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedTextColor As Color
        Get
            Return _TextCheckedColor
        End Get
        Set(value As Color)
            _TextCheckedColor = value
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
    Public Property HoverTopStartColor As Color
        Get
            Return _StartHoverColor
        End Get
        Set(value As Color)
            _StartHoverColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverEndColor As Color
        Get
            Return _EndHoverColor
        End Get
        Set(value As Color)
            _EndHoverColor = value
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
    Protected Overloads Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        SetStandardSize()
    End Sub

    Private Sub SetStandardSize()
        Dim _Size As Integer = Math.Max(Width, Height)
        Size = New Size(_Size, _Size)
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
        'PaintGradient()
        Size = New Size(125, 40)
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


            Select Case _ButtonStyle
                Case ButtonStyle.Normal 'Normal Button

                    Select Case State
                        Case MouseState.None

                            Dim rect As New Rectangle(0, 0, Width, Height)

                            If _GradientStyle = Style.Horizontal Then

                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)

                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})


                            ElseIf _GradientStyle = Style.Vertical Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            End If


                        Case MouseState.Over

                            Dim rect As New Rectangle(0, 0, Width, Height)

                            If _GradientStyle = Style.Horizontal Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            ElseIf _GradientStyle = Style.Vertical Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            End If

                        Case MouseState.Down

                            Dim rect As New Rectangle(0, 0, Width, Height)

                            If _GradientStyle = Style.Horizontal Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Horizontal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            ElseIf _GradientStyle = Style.Vertical Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Vertical)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                Dim x As Single = CSng(Width / 2)
                                Dim y As Single = CSng(Height / 4)
                                Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                G.FillRectangle(br, rect, Me.Height / 2)
                                .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                            End If

                    End Select

                Case ButtonStyle.ToogleButton 'Toogle Button

                    If _Checked = True Then ' toogle ativo

                        Select Case State
                            Case MouseState.None

                                Dim rect As New Rectangle(0, 0, Width, Height)

                                If _GradientStyle = Style.Horizontal Then

                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartCheckedColor, _EndCheckedColor, Drawing2D.LinearGradientMode.Horizontal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)

                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextCheckedColor), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})


                                ElseIf _GradientStyle = Style.Vertical Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartCheckedColor, _EndCheckedColor, Drawing2D.LinearGradientMode.Vertical)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextCheckedColor), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartCheckedColor, _EndCheckedColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextCheckedColor), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartCheckedColor, _EndCheckedColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextCheckedColor), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                End If


                            Case MouseState.Over

                                Dim rect As New Rectangle(0, 0, Width, Height)

                                If _GradientStyle = Style.Horizontal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.Horizontal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.Vertical Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.Vertical)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(_TextChecked, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                End If

                            Case MouseState.Down

                                Dim rect As New Rectangle(0, 0, Width, Height)

                                If _GradientStyle = Style.Horizontal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Horizontal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.Vertical Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Vertical)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                End If

                        End Select

                    Else ' toogle desativado

                        Select Case State
                            Case MouseState.None

                                Dim rect As New Rectangle(0, 0, Width, Height)

                                If _GradientStyle = Style.Horizontal Then

                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)

                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})


                                ElseIf _GradientStyle = Style.Vertical Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Vertical)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartColor, _EndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                End If


                            Case MouseState.Over

                                Dim rect As New Rectangle(0, 0, Width, Height)

                                If _GradientStyle = Style.Horizontal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.Horizontal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.Vertical Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.Vertical)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _StartHoverColor, _EndHoverColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextHoverColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                End If

                            Case MouseState.Down

                                Dim rect As New Rectangle(0, 0, Width, Height)

                                If _GradientStyle = Style.Horizontal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Horizontal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.Vertical Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.Vertical)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.ForwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.ForwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                ElseIf _GradientStyle = Style.BackwardDiagonal Then
                                    Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _PressedStartColor, _PressedEndColor, Drawing2D.LinearGradientMode.BackwardDiagonal)
                                    Dim x As Single = CSng(Width / 2)
                                    Dim y As Single = CSng(Height / 4)
                                    Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                                    G.FillRectangle(br, rect, Me.Height / 2)
                                    .DrawString(Text, _Font, New SolidBrush(_TextColour), New Rectangle(2, 2, Width - 5, Height - 5), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})

                                End If

                        End Select

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

    Private Sub GradientFlatButton_UI_Click(sender As Object, e As EventArgs) Handles Me.Click
        pos = PointToClient(MousePosition)
        AnimationBack.[Stop]()
        Animation.Start()
        sw.Reset()
        sw.[Stop]()
        sw.Start()
    End Sub



#End Region

End Class
