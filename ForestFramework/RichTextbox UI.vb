Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Drawing
Imports ForestFramework.DrawHelpers


'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusRichTextbox_UI

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
    Private WithEvents TB As New RichTextBox
    Private _BaseColour As Color = Color.FromArgb(47, 71, 222)
    Private _TextColour As Color = Color.FromArgb(255, 255, 255)
    Private _BorderColour As Color = Color.FromArgb(47, 71, 222)
#End Region

#Region "Properties"

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
        End Set
    End Property

#End Region

#Region "Events"

    Overrides Property Text As String
        Get
            Return TB.Text
        End Get
        Set(value As String)
            TB.Text = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnBackColorChanged(ByVal e As System.EventArgs)
        MyBase.OnBackColorChanged(e)
        TB.BackColor = BackColor
        Invalidate()
    End Sub

    Protected Overrides Sub OnForeColorChanged(ByVal e As System.EventArgs)
        MyBase.OnForeColorChanged(e)
        TB.ForeColor = ForeColor
        Invalidate()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)
        TB.Size = New Size(Width - 10, Height - 11)
    End Sub

    Protected Overrides Sub OnFontChanged(ByVal e As System.EventArgs)
        MyBase.OnFontChanged(e)
        TB.Font = Font
    End Sub

    Sub TextChanges() Handles MyBase.TextChanged
        TB.Text = Text
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
        With TB
            .Multiline = True
            .BackColor = _BaseColour
            .ForeColor = _TextColour
            .Text = String.Empty
            .BorderStyle = BorderStyle.None
            .Location = New Point(5, 5)
            .Font = New Font("Segoe UI", 12)
            .Size = New Size(Width - 10, Height - 10)
        End With
        Controls.Add(TB)
        Size = New Size(135, 35)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim Base As New Rectangle(0, 0, Width - 1, Height - 1)
        BackColor = _BaseColour
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(_BaseColour)
            .DrawRectangle(New Pen(_BorderColour, 2), ClientRectangle)
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
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region


End Class
