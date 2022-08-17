Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusCircularPictureBox_UI
    Inherits PictureBox

    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer, ByVal nWidthEllipse As Integer, ByVal nHeightEllipse As Integer) As IntPtr

    End Function

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
#End Region


#Region "Draw Control"
    Protected Overloads Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        SetStandardSize()
    End Sub
    Protected Overloads Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        SetStandardSize()
    End Sub
    Protected Overloads Overrides Sub OnPaintBackground(p As PaintEventArgs)
        MyBase.OnPaintBackground(p)
    End Sub
    Private Sub SetStandardSize()
        Dim _Size As Integer = Math.Max(Width, Height)
        Size = New Size(_Size, _Size)
    End Sub

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
        Me.Size = New Size(70, 70)
        DoubleBuffered = True
        Me.SizeMode = PictureBoxSizeMode.CenterImage
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim GP, GP1 As New GraphicsPath


        Me.BackColor = Me.Parent.BackColor



        Dim brushImege As System.Drawing.Brush

        Try
            Dim Imagem As Bitmap = New Bitmap(Me.Image)
            Imagem = New Bitmap(Imagem, New Size(Me.Width - 1, Me.Height - 1))
            brushImege = New TextureBrush(Imagem)
        Catch
            Dim Imagem As Bitmap = New Bitmap(Me.Width - 1, Me.Height - 1, PixelFormat.Format24bppRgb)

            Using grp As Graphics = Graphics.FromImage(Imagem)
                grp.FillRectangle(Brushes.White, 0, 0, Me.Width - 1, Me.Height - 1)
                Imagem = New Bitmap(Me.Width - 1, Me.Height - 1, grp)
            End Using

            brushImege = New TextureBrush(Imagem)



        End Try

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim path As GraphicsPath = New GraphicsPath()
        path.AddEllipse(0, 0, Me.Width - 1, Me.Height - 1)
        e.Graphics.FillPath(brushImege, path)
        Dim p As New Pen(Me.Parent.BackColor, 2)
        e.Graphics.DrawPath(p, path)


        Me.Region = New Region(path)

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

    End Sub

    Private Sub CircularPictureBox_UI_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Me.Invalidate()
    End Sub
#End Region
End Class

