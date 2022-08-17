Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Drawing
Imports ForestFramework.DrawHelpers
Imports System.Net.Http

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusTabControl_UI

    Inherits TabControl

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
    Private _BaseColour As Color = Color.FromArgb(255, 255, 255)
    Private _LineColour As Color = Color.FromArgb(22, 103, 201)
    Private _TitleColour As Color = Color.FromArgb(200, 200, 200)

#End Region

#Region "Options"

    <Category("Colors")>
    Property BaseColor() As Color
        Get
            Return _BaseColour
        End Get
        Set(ByVal value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colors")>
    Property LineColor() As Color
        Get
            Return _LineColour
        End Get
        Set(ByVal value As Color)
            _LineColour = value
        End Set
    End Property

    <Category("Colors")>
    Property TitleColor() As Color
        Get
            Return _TitleColour
        End Get
        Set(ByVal value As Color)
            _TitleColour = value
        End Set
    End Property

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
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or
                 ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        ItemSize = New Size(0, 30)
        Font = New Font("Segoe UI", 9.5)
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)

        Dim G As Graphics = e.Graphics

        Dim borderPen As New Pen(_BaseColour)

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim fillRect As New Rectangle(2, ItemSize.Height + 2, Width - 6, Height - ItemSize.Height - 3)

        G.DrawRectangle(borderPen, fillRect)

        Dim FontColor As New Color

        For i = 0 To TabCount - 1

            Dim mainRect As Rectangle = GetTabRect(i)

            If i = SelectedIndex Then

                G.FillRectangle(New SolidBrush(_BaseColour), mainRect)
                G.DrawRectangle(borderPen, mainRect)
                G.DrawLine(New Pen(_LineColour), New Point(mainRect.X, mainRect.Y + 25), New Point(mainRect.X + mainRect.Width - 0, mainRect.Y + 25))

                FontColor = _TitleColour

            Else

                G.FillRectangle(New SolidBrush(_BaseColour), mainRect)
                G.DrawRectangle(borderPen, mainRect)
                G.DrawLine(New Pen(Color.FromArgb(200, 200, 200)), New Point(mainRect.X, mainRect.Y + 25), New Point(mainRect.X + mainRect.Width - 0, mainRect.Y + 25))
                FontColor = Color.FromArgb(180, 180, 180)

            End If

            Dim titleX As Integer = (mainRect.Location.X + mainRect.Width / 2) - (G.MeasureString(TabPages(i).Text, Font).Width / 2)
            Dim titleY As Integer = (mainRect.Location.Y + mainRect.Height / 2) - (G.MeasureString(TabPages(i).Text, Font).Height / 2)
            G.DrawString(TabPages(i).Text, Font, New SolidBrush(FontColor), New Point(titleX, titleY))

            Try : TabPages(i).BackColor = _BaseColour : Catch : End Try

            If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
                'modo designer
                Try

                    If My.Settings.status = "error" Or My.Settings.status = "waiting" Then
                        G.DrawString("Trial NikyusUI", New Font("Arial", 42), New SolidBrush(Color.FromArgb(50, Color.Black)), 0, 0)
                    End If
                Catch ex As Exception

                End Try

            Else
                'modo realtime

                Try

                    If My.Settings.status = "error" Or My.Settings.status = "waiting" Then
                        'G.DrawString("Trial NikyusUI", New Font("Arial", 42), New SolidBrush(Color.FromArgb(50, Color.Black)), 0, 0)
                    End If
                Catch ex As Exception

                End Try

            End If

        Next

    End Sub

End Class
