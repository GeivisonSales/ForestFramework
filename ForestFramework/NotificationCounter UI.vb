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


Public Class NikyusNotificationCounter_UI
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
    Private _color As Color = Color.Red
    Private _hovercolor As Color = Color.Red
    Private _pressedcolor As Color = Color.Red
    Private _round As Integer
    Private _fontcolor As Color = Color.White
    Private _value As Integer = 30
    Private _filtervalue As Boolean = True
#End Region

#Region "Properties"
    <Category("Colours")>
    Public Property BubbleBackcolor As Color
        Get
            Return _color
        End Get
        Set(value As Color)
            _color = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property BubblePressedBackcolor As Color
        Get
            Return _pressedcolor
        End Get
        Set(value As Color)
            _pressedcolor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property BubbleHoverBackcolor As Color
        Get
            Return _hovercolor
        End Get
        Set(value As Color)
            _hovercolor = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property BubbleRound As Integer
        Get
            Return _round
        End Get
        Set(value As Integer)
            _round = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property NotificationValue As Integer
        Get
            Return _value
        End Get
        Set(value As Integer)
            _value = value
            Invalidate()

        End Set
    End Property

    <Category("Options")>
    Public Property FilterValue As Boolean
        Get
            Return _filtervalue
        End Get
        Set(value As Boolean)
            _filtervalue = value
            Invalidate()
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
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
              ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
              ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Me.Font = New Font("Segoe UI", 9)
        Me.ForeColor = Color.White
        Me.Size = New Size(45, 26)
    End Sub


    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim GP, GP1 As New GraphicsPath

        With G
            .TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality



            Select Case State
                Case MouseState.None
                    If _round <= 0 Then
                        .FillRectangle(New SolidBrush(_color), 0, 0, Width, Height, Height / 2)
                    Else
                        .FillRectangle(New SolidBrush(_color), 0, 0, Width, Height, _round)
                    End If

                Case MouseState.Over 'hover
                    If _round <= 0 Then
                        .FillRectangle(New SolidBrush(_hovercolor), 0, 0, Width, Height, Height / 2)
                    Else
                        .FillRectangle(New SolidBrush(_hovercolor), 0, 0, Width, Height, _round)
                    End If

                Case MouseState.Down
                    If _round <= 0 Then
                        .FillRectangle(New SolidBrush(_pressedcolor), 0, 0, Width, Height, Height / 2)
                    Else
                        .FillRectangle(New SolidBrush(_pressedcolor), 0, 0, Width, Height, _round)
                    End If

            End Select

            If _filtervalue = True Then
                Dim _notTxt As String = _value
                If _notTxt > 99 Then
                    _notTxt = "99+"
                End If
                .DrawString(_notTxt, Me.Font, New SolidBrush(Me.ForeColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            Else
                .DrawString(_value, Me.Font, New SolidBrush(Me.ForeColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
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




#End Region


End Class
