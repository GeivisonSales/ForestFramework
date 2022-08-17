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

Public Class NikyusImageButton_UI

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
    Private State As MouseState
    Private _BaseColour As Color = Color.FromArgb(43, 70, 240)
    Private _PressedBaseColour As Color = Color.FromArgb(87, 110, 255)
    Private _ImageSelect As Image = My.Resources.happy
    Private _PressedImage As Image = My.Resources.happy
    Private _HoverImage As Image = My.Resources.pressed_happy
    Private _ImageSize As Size = New Size(64, 64)

    Enum MouseState
        None
        Hover
        Over
        Down
    End Enum
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

    <Category("Image Options")>
    Public Property ImageSelect As Image
        Get
            Return _ImageSelect
        End Get
        Set(value As Image)
            _ImageSelect = value
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
    Public Property PressedImage As Image
        Get
            Return _PressedImage
        End Get
        Set(value As Image)
            _PressedImage = value
        End Set
    End Property

    <Category("Image Options")>
    Public Property HoverImage As Image
        Get
            Return _HoverImage
        End Get
        Set(value As Image)
            _HoverImage = value
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
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseHover(e As EventArgs)
        MyBase.OnMouseHover(e)
        State = MouseState.Hover : Invalidate()
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
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
              ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
              ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(64, 64)
        BackColor = Color.Transparent
        _BaseColour = Color.Transparent
        _PressedBaseColour = Color.Transparent
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

            Select Case State
                Case MouseState.None
                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                    .DrawImage(_ImageSelect, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                Case MouseState.Over
                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                    .DrawImage(_HoverImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                Case MouseState.Down
                    .FillRectangle(New SolidBrush(_PressedBaseColour), 0, 0, Width, Height)
                    .DrawImage(_PressedImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                Case MouseState.Hover
                    .FillRectangle(New SolidBrush(_BaseColour), 0, 0, Width, Height)
                    .DrawImage(_HoverImage, CInt(Width / 2) - CInt(_ImageSize.Width / 2), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
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
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

End Class
