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

Public Class NikyusImageRadioButton_UI

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
    Private _BaseColour As Color = Color.FromArgb(43, 70, 240)
    Private _ImageOn As Image = My.Resources.happy
    Private _ImageOff As Image = My.Resources.pressed_happy
    Private _ImageSize As Size = New Size(64, 64)
    Private _Checked As Boolean = False

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

    <Category("Image Options")>
    Public Property ImageOn As Image
        Get
            Return _ImageOn
        End Get
        Set(value As Image)
            _ImageOn = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Image Options")>
    Public Property ImageSize As Size
        Get
            Return _ImageSize
        End Get
        Set(value As Size)
            _ImageSize = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Image Options")>
    Public Property ImageOff As Image
        Get
            Return _ImageOff
        End Get
        Set(value As Image)
            _ImageOff = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

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
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
              ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
              ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(64, 64)
        BackColor = Color.Transparent
        _BaseColour = Color.Transparent
        Invalidate()
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


            If _Checked = True Then
                .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                .DrawImage(_ImageOn, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

            Else
                .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                .DrawImage(_ImageOff, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)

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

    Private Sub ImageRadioButton_UI_Click(sender As Object, e As EventArgs) Handles Me.Click
        If _Checked = True Then
            _Checked = False
            Invalidate()
        Else
            _Checked = True
            Invalidate()
        End If
    End Sub

#End Region

End Class
