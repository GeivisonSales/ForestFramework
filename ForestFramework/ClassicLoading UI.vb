Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusClassicLoading_UI
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

    Private fullTransparency As Boolean = True
    Private increment As Single = 1.0F
    Private radius1 As Single = 2.5F
    Private n As Integer = 8
    Private [next] As Integer = 0
    Private timer As System.Windows.Forms.Timer
    Private _color As Color = Color.FromArgb(53, 143, 240)

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
        Width = 90
        Height = 100
        timer = New System.Windows.Forms.Timer()
        AddHandler timer.Tick, (AddressOf timer_Tick)
        timer.Enabled = False
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
    End Sub

    Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If fullTransparency Then
            ' Transparenter.MakeTransparent(Me, e.Graphics)
        End If

        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim length As Integer = Math.Min(Width, Height)
        Dim center As PointF = New PointF(length / 2, length / 2)
        Dim bigRadius As Single = length / 2 - radius1 - (n - 1) * increment
        Dim unitAngle As Single = 360 / n
        [next] += 1
        [next] = If([next] >= n, 0, [next])
        Dim a As Integer = 0

        For i As Integer = [next] To [next] + n - 1
            Dim factor As Integer = i Mod n
            Dim c1X As Single = center.X + CSng((bigRadius * Math.Cos(unitAngle * factor * Math.PI / 180)))
            Dim c1Y As Single = center.Y + CSng((bigRadius * Math.Sin(unitAngle * factor * Math.PI / 180)))
            Dim currRad As Single = radius1 + a * increment
            Dim c1 As PointF = New PointF(c1X - currRad, c1Y - currRad)
            e.Graphics.FillEllipse(New SolidBrush(_color), c1.X, c1.Y, 2 * currRad, 2 * currRad)

            Using pen As Pen = New Pen(_color, 2)
                e.Graphics.DrawEllipse(pen, c1.X, c1.Y, 2 * currRad, 2 * currRad)
            End Using

            a += 1

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
                        'e.Graphics.DrawString("Trial NikyusUI", New Font("Arial", 22), New SolidBrush(Color.FromArgb(50, Color.White)), 0, 0)
                    End If
                Catch ex As Exception

                End Try

            End If

        Next
    End Sub

    Protected Overrides Sub OnVisibleChanged(ByVal e As EventArgs)
        timer.Enabled = Visible
        MyBase.OnVisibleChanged(e)
    End Sub
    <Category("Options")>
    Public Property FullTransparent As Boolean
        Get
            Return fullTransparency
        End Get
        Set(ByVal value As Boolean)
            fullTransparency = value
        End Set
    End Property
    <Category("Options")>
    Public Property NumberOfBalls As Integer
        Get
            Return n
        End Get
        Set(ByVal value As Integer)
            n = If(value >= 2, value, 2)
            Invalidate()
        End Set
    End Property
    <Category("Options")>
    Public Property Increments As Single
        Get
            Return increment
        End Get
        Set(ByVal value As Single)
            increment = If(value >= 0, value, 0)
            Invalidate()
        End Set
    End Property

    <Category("Colors")>
    Public Property BallColor As Color
        Get
            Return _color
        End Get
        Set(ByVal value As Color)
            _color = value
            Invalidate()
        End Set
    End Property

End Class
