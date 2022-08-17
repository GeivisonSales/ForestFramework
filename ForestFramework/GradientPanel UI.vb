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

Public Class NikyusGradientPanel_UI

    Inherits System.Windows.Forms.Panel

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
    Private _StartColor As Color = Color.FromArgb(43, 70, 240)
    Private _EndColor As Color = Color.FromArgb(87, 110, 255)
    Private _RoundBorder As Boolean = False
    Private _Round As Integer = 5
#End Region

#Region "Properties"

    <Category("Colours")>
    Public Property TopStartColor As Color
        Get
            Return _StartColor
        End Get
        Set(value As Color)
            _StartColor = value
            PaintGradient()
        End Set
    End Property

    <Category("Colours")>
    Public Property BottomColor As Color
        Get
            Return _EndColor
        End Get
        Set(value As Color)
            _EndColor = value
            PaintGradient()
        End Set
    End Property

    <Category("Options")>
    Public Property RoundCorners As Boolean
        Get
            Return _RoundBorder
        End Get
        Set(value As Boolean)
            _RoundBorder = value
        End Set
    End Property

    <Category("Options")>
    Public Property Round As Integer
        Get
            Return _Round
        End Get
        Set(value As Integer)
            _Round = value
        End Set
    End Property

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
        PaintGradient()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim GP, GP1 As New GraphicsPath

        MyBase.OnPaint(e)

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

        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()

    End Sub

    Private Sub PaintGradient()
        Dim gradBrush As System.Drawing.Drawing2D.LinearGradientBrush
        gradBrush = New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(Me.Width, Me.Height), _StartColor, _EndColor)
        Dim bmp As Bitmap = New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        If _RoundBorder = True Then
            g.FillRectangle(gradBrush, New Rectangle(0, 0, Me.Width, Me.Height), _Round)
        Else
            g.FillRectangle(gradBrush, New Rectangle(0, 0, Me.Width, Me.Height))
        End If
        Me.BackgroundImage = bmp
        Me.BackgroundImageLayout = ImageLayout.Stretch



    End Sub

    Private Sub GradientPanel_UI_Click(sender As Object, e As EventArgs) Handles Me.Click
        pos = PointToClient(MousePosition)
        AnimationBack.[Stop]()
        Animation.Start()
        sw.Reset()
        sw.[Stop]()
        sw.Start()
    End Sub
End Class
