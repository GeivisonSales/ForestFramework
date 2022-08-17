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

Public Class NikyusCombobox_UI

    Inherits ComboBox


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

#Region " Control Help - Properties & Flicker Control "

    Private _BackColor As Color = Color.FromArgb(224, 224, 224)
    <Category("Colors")>
    Public Property ComboBackColor() As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal value As Color)
            _BackColor = value
            Invalidate()
        End Set
    End Property

    Enum ColorSchemes
        Light
        Dark
    End Enum
    Private _ColorScheme As ColorSchemes
    <Browsable(False)>
    Public Property ColorScheme() As ColorSchemes
        Get
            Return _ColorScheme
        End Get
        Set(ByVal value As ColorSchemes)
            _ColorScheme = value
            Invalidate()
        End Set
    End Property

    Private _BorderColor As Color = Color.FromArgb(224, 224, 224)
    <Category("Colors")>
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal value As Color)
            _BorderColor = value
            Invalidate()
        End Set
    End Property

    Private _AccentColor As Color
    <Category("Colors")>
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(ByVal value As Color)
            _AccentColor = value
            Invalidate()
        End Set
    End Property

    Private _StartIndex As Integer = 0
    <Category("Colors")>
    Private Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(ByVal value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property
    Sub ReplaceItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_AccentColor), e.Bounds)
            Else
                Select Case ColorScheme
                    Case ColorSchemes.Dark
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(35, 35, 35)), e.Bounds)
                    Case ColorSchemes.Light
                        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
                End Select
            End If
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.White, e.Bounds)
                Case ColorSchemes.Light
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.Black, e.Bounds)
            End Select
        Catch
        End Try
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray())
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

    Dim WithEvents licenseform As New ForestFramework.Licensing
    Sub New()
        MyBase.New
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
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(50, 50, 50)
        Size = New Size(189, 24)
        ForeColor = Color.White
        AccentColor = Color.FromArgb(224, 224, 224)
        ColorScheme = ColorSchemes.Light
        DropDownStyle = ComboBoxStyle.DropDownList
        Font = New Font("Segoe UI", 12)
        StartIndex = 0
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Curve As Integer = 2


        G.SmoothingMode = SmoothingMode.HighQuality


        Select Case ColorScheme
            Case ColorSchemes.Dark
                G.Clear(_BackColor)
                G.DrawLine(New Pen(Color.White, 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                G.DrawLine(New Pen(Color.White, 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                G.DrawLine(New Pen(Color.White), New Point(Width - 14, 15), New Point(Width - 14, 14))
            Case ColorSchemes.Light
                G.Clear(_BackColor)
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100), 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100), 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                G.DrawLine(New Pen(Color.FromArgb(100, 100, 100)), New Point(Width - 14, 15), New Point(Width - 14, 14))
        End Select
        G.DrawRectangle(New Pen(_BorderColor), New Rectangle(0, 0, Width - 1, Height - 1))


        Try
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    G.DrawString(Text, Font, Brushes.White, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                Case ColorSchemes.Light
                    G.DrawString(Text, Font, Brushes.Black, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
            End Select
        Catch
        End Try

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

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub

    Private Sub Combobox_UI_Click(sender As Object, e As EventArgs) Handles Me.Click
        pos = PointToClient(MousePosition)
        AnimationBack.[Stop]()
        Animation.Start()
        sw.Reset()
        sw.[Stop]()
        sw.Start()
    End Sub
End Class
