Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports ForestFramework.RoundedRectangleF

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusSwitch_UI
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
    Public Delegate Sub SliderChangedEventHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event SliderValueChanged As SliderChangedEventHandler
    Private diameter As Single
    Private rect As RoundedRectangleF
    Private circle As RectangleF
    Private _isOn As Boolean
    Private artis As Single
    Private _OnBubbleColor As Color = Color.FromArgb(250, 250, 250)
    Private _OffBubbleColor As Color = Color.FromArgb(250, 250, 250)
    Private _OnBorderColor As Color
    Private _OffBorderColor As Color
    Private _OnSwitchColor As Color = Color.FromArgb(0, 120, 215)
    Private _OffSwitchColor As Color = Color.FromArgb(171, 171, 171)
    Private paintTicker As System.Windows.Forms.Timer = New System.Windows.Forms.Timer()
#End Region

#Region "Properties"
    <Category("Options")>
    Public Property IsOn As Boolean
        Get
            Return _isOn
        End Get
        Set(ByVal value As Boolean)
            paintTicker.[Stop]()
            _isOn = value
            paintTicker.Start()
            RaiseEvent SliderValueChanged(Me, EventArgs.Empty)
        End Set
    End Property

    <Category("Colors")>
    Public Property On_BorderColor As Color
        Get
            Return _OnBorderColor
        End Get
        Set(ByVal value As Color)
            _OnBorderColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property Off_BorderColor As Color
        Get
            Return _OffBorderColor
        End Get
        Set(ByVal value As Color)
            _OffBorderColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property On_SwitchColor As Color
        Get
            Return _OnSwitchColor
        End Get
        Set(ByVal value As Color)
            _OnSwitchColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property Off_SwitchColor As Color
        Get
            Return _OffSwitchColor
        End Get
        Set(ByVal value As Color)
            _OffSwitchColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property On_BubbleColor As Color
        Get
            Return _OnBubbleColor
        End Get
        Set(ByVal value As Color)
            _OnBubbleColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property Off_BubbleColor As Color
        Get
            Return _OffBubbleColor
        End Get
        Set(ByVal value As Color)
            _OffBubbleColor = value
            Invalidate()
        End Set
    End Property
#End Region

#Region "Draw control"
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
        Cursor = Cursors.Hand
        DoubleBuffered = True
        Size = New Size(50, 27)
        _OnBorderColor = Color.Transparent
        _OffBorderColor = Color.Transparent
        Width = (Height - 2) * 2
        diameter = Width / 2
        artis = 4 * diameter / 30
        rect = New RoundedRectangleF(2 * diameter, diameter + 2, diameter / 2, 1, 1)
        circle = New RectangleF((Width - diameter / 2 - 5), CInt(Width - diameter / 2 - 5), Height / 2 - CInt(diameter / 2) / 2, diameter / 2)
        IsOn = True
        AddHandler paintTicker.Tick, (AddressOf paintTicker_Tick)
        paintTicker.Interval = 1
    End Sub

    Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
        Invalidate()
        MyBase.OnEnabledChanged(e)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        Width = (Height - 2) * 2
        diameter = Width / 2
        artis = 4 * diameter / 30
        rect = New RoundedRectangleF(2 * diameter, diameter + 2, diameter / 2, 1, 1)
        circle = New RectangleF(If(Not IsOn, 1, Width - diameter / 2 - 5), Height / 2 - CInt(diameter / 2) / 2, diameter / 2, diameter / 2)
        MyBase.OnResize(e)
    End Sub

    Private Sub paintTicker_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Dim x As Single = circle.X
        Width = (Height - 2) * 2
        diameter = Width / 2
        artis = 4 * diameter / 30

        If IsOn = True Then

            If x = CInt(Width - diameter / 2 - 5) Then
                x = CInt(Width - diameter / 2 - 5)
                circle = New RectangleF(x, Height / 2 - CInt(diameter / 2) / 2, diameter / 2, diameter / 2)
                Invalidate()
            Else
                x = CInt(Width - diameter / 2 - 5)
                circle = New RectangleF(x, Height / 2 - CInt(diameter / 2) / 2, diameter / 2, diameter / 2)
                Invalidate()
                paintTicker.[Stop]()
            End If

        Else

            If x = CInt(Width - diameter / 2 - 5) Then
                x = 5
                circle = New RectangleF(x, Height / 2 - CInt(diameter / 2) / 2, diameter / 2, diameter / 2)
                Invalidate()
            Else
                x = 5
                circle = New RectangleF(x, Height / 2 - CInt(diameter / 2) / 2, diameter / 2, diameter / 2)
                Invalidate()
                paintTicker.[Stop]()
            End If


        End If
    End Sub

    Protected Overrides ReadOnly Property DefaultSize As Size
        Get
            Return New Size(60, 35)
        End Get
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        If Enabled Then

            Using brush As SolidBrush = New SolidBrush(If(IsOn, _OnSwitchColor, _OffSwitchColor))
                e.Graphics.FillPath(brush, rect.Path)
            End Using

            Using pen As Pen = New Pen(If(IsOn, _OnBorderColor, _OffBorderColor), 2.0F)
                e.Graphics.DrawPath(pen, rect.Path)
            End Using

            Using circleBrush As SolidBrush = New SolidBrush(If(IsOn, _OnBubbleColor, _OffBubbleColor))
                e.Graphics.FillEllipse(circleBrush, circle)
            End Using

        Else

            Using disableBrush As SolidBrush = New SolidBrush(Color.FromArgb(207, 207, 207))

                Using ellBrush As SolidBrush = New SolidBrush(Color.FromArgb(179, 179, 179))
                    e.Graphics.FillPath(disableBrush, rect.Path)
                    e.Graphics.FillEllipse(ellBrush, circle)
                    e.Graphics.DrawEllipse(Pens.DarkGray, circle)
                End Using
            End Using
        End If

        If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
            'modo designer
            Try

                If My.Settings.status = "error" Or My.Settings.status = "waiting" Then
                    e.Graphics.DrawString("Trial NikyusUI", New Font("Arial", 22), New SolidBrush(Color.FromArgb(50, Color.White)), 0, 0)
                End If
            Catch ex As Exception

            End Try

        Else
            'modo realtime

            Try

                If My.Settings.status = "error" Or My.Settings.status = "waiting" Then
                    ' e.Graphics.DrawString("Trial NikyusUI", New Font("Arial", 22), New SolidBrush(Color.FromArgb(50, Color.White)), 0, 0)
                End If
            Catch ex As Exception

            End Try

        End If

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button <> System.Windows.Forms.MouseButtons.Left Then Return
        IsOn = Not IsOn
        IsOn = IsOn
        MyBase.OnMouseClick(e)
    End Sub
#End Region
End Class
