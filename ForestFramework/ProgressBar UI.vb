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

Public Class NikyusProgressBar_UI

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
    Private _ProgressColour As Color = Color.FromArgb(94, 255, 97)
    Private _BorderColour As Color = Color.Transparent()
    Private _BaseColour As Color = Color.FromArgb(224, 224, 224)
    Private _FontColour As Color = Color.FromArgb(255, 255, 255)
    Private _SecondColour As Color = Color.FromArgb(37, 194, 39)
    Private _Value As Integer = 50
    Private _Maximum As Integer = 100
    Private _TwoColour As Boolean = False
    Private _RoundBorder As Boolean = True
    Private _Round As Integer = 5

    Private _StartColor As Color = Color.FromArgb(255, 128, 0)
    Private _EndColor As Color = Color.FromArgb(176, 58, 148)
    Private _Gradientstyleclean As String
    Private _Gradient As Boolean = True
#End Region

#Region "Properties"

    <Category("Options")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get
        Set(V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property ProgressColour As Color
        Get
            Return _ProgressColour
        End Get
        Set(value As Color)
            _ProgressColour = value
            Invalidate()
        End Set
    End Property

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
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property FontColour As Color
        Get
            Return _FontColour
        End Get
        Set(value As Color)
            _FontColour = value
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
            Me.Invalidate()
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

    <Category("Gradient Colours")>
    Public Property LeftColor As Color
        Get
            Return _StartColor
        End Get
        Set(value As Color)
            _StartColor = value
            Invalidate()
        End Set
    End Property

    <Category("Gradient Colours")>
    Public Property RightColor As Color
        Get
            Return _EndColor
        End Get
        Set(value As Color)
            _EndColor = value
            Invalidate()
        End Set
    End Property
    <Category("Gradient Colours")>
    Public Property Gradient As Boolean
        Get
            Return _Gradient
        End Get
        Set(value As Boolean)
            _Gradient = value
            Invalidate()
        End Set
    End Property

#End Region

#Region "Events"

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        'Height = 10
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Height = 25
    End Sub

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
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
        Me.Size = New Size(297, 10)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B = New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Base As New Rectangle(0, 0, Width, Height)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Dim ProgVal As Integer = CInt(_Value / _Maximum * Width)
            Select Case Value
                Case 0
                    If _RoundBorder = True Then
                        'com rounder

                        .FillRectangle(New SolidBrush(_BaseColour), New Rectangle(0, 0, Width, Height), _Round)
                        .DrawRectangle(New Pen(_BorderColour, 3), New Rectangle(0, 0, Width, Height), _Round)
                    Else 'sem rounder
                        .FillRectangle(New SolidBrush(_BaseColour), New Rectangle(0, 0, Width, Height))
                        .DrawRectangle(New Pen(_BorderColour, 3), Base)
                    End If


                Case _Maximum

                    If _RoundBorder = True Then
                        'com rounder
                        .FillRectangle(New SolidBrush(_BaseColour), New Rectangle(0, 0, Width, Height), _Round)
                        If _Gradient = True Then
                            'gradient ativo
                            Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(Base, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                            Dim x As Single = CSng(Width / 2)
                            Dim y As Single = CSng(Height / 4)
                            Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                            G.FillRectangle(br, New Rectangle(0, 0, ProgVal - 1, Height), _Round)
                        Else
                            'sem gradient
                            .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height), _Round)
                        End If
                        .DrawRectangle(New Pen(_BorderColour, 3), New Rectangle(0, 0, Width, Height), _Round)
                    Else 'sem rounder
                        .FillRectangle(New SolidBrush(_BaseColour), Base)
                        If _Gradient = True Then
                            'gradient ativo
                            Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(Base, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                            Dim x As Single = CSng(Width / 2)
                            Dim y As Single = CSng(Height / 4)
                            Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                            G.FillRectangle(br, New Rectangle(0, 0, ProgVal - 1, Height))
                        Else
                            'sem gradient
                            .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))
                        End If
                        .DrawRectangle(New Pen(_BorderColour, 3), Base)
                    End If

                Case Else
                    If _RoundBorder = True Then
                        'com rounder
                        .FillRectangle(New SolidBrush(_BaseColour), New Rectangle(0, 0, Width, Height), _Round)
                        If _Gradient = True Then
                            'gradient ativo
                            Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(Base, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                            Dim x As Single = CSng(Width / 2)
                            Dim y As Single = CSng(Height / 4)
                            Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                            G.FillRectangle(br, New Rectangle(0, 0, ProgVal - 1, Height), _Round)
                        Else
                            'sem gradient
                            .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height), _Round)
                        End If
                        .DrawRectangle(New Pen(_BorderColour, 3), New Rectangle(0, 0, Width, Height), _Round)
                    Else 'sem rounder
                        .FillRectangle(New SolidBrush(_BaseColour), Base)
                        If _Gradient = True Then
                            'gradient ativo
                            Dim br As New System.Drawing.Drawing2D.LinearGradientBrush(Base, _StartColor, _EndColor, Drawing2D.LinearGradientMode.Horizontal)
                            Dim x As Single = CSng(Width / 2)
                            Dim y As Single = CSng(Height / 4)
                            Dim sBrush As New System.Drawing.SolidBrush(Color.WhiteSmoke)
                            G.FillRectangle(br, New Rectangle(0, 0, ProgVal - 1, Height))
                        Else
                            'sem gradient
                            .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))
                        End If
                        .DrawRectangle(New Pen(_BorderColour, 3), Base)
                    End If

            End Select
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
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class
