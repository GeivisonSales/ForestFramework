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

Public Class NikyusCircularProgressBar_UI
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
    Public Enum _ProgressShape
        Round
        Flat
    End Enum
    Public Enum _TextMode
        None
        Value
        Percentage
        [Custom]
    End Enum
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
    Private _LineWitdh As Integer = 5
    Private _BarWidth As Single = 11
    Private _ProgressColor1 As Color = Color.Orange
    Private _ProgressColor2 As Color = Color.Orange
    Private _LineColor As Color = Color.LightGray
    Private _GradientMode As LinearGradientMode = LinearGradientMode.Vertical
    Private ProgressShapeVal As _ProgressShape
    Private ProgressTextMode As _TextMode
    Private _ShadowOffset As Single = 0
#End Region

#Region "Properties"
    <Category("Options")>
    Public Property Value() As Long
        Get
            Return _Value
        End Get
        Set
            If Value > _Maximum Then
                Value = _Maximum
            End If
            _Value = Value
            Invalidate()
        End Set
    End Property
    <Category("Options")>
    Public Property Maximum() As Long
        Get
            Return _Maximum
        End Get
        Set
            If Value < 1 Then
                Value = 1
            End If
            _Maximum = Value
            Invalidate()
        End Set
    End Property
    <Category("Gradient Colours")>
    Public Property TopStartColor() As Color
        Get
            Return _ProgressColor1
        End Get
        Set
            _ProgressColor1 = Value
            Invalidate()
        End Set
    End Property
    <Category("Gradient Colours")>
    Public Property BottomColor() As Color
        Get
            Return _ProgressColor2
        End Get
        Set
            _ProgressColor2 = Value
            Invalidate()
        End Set
    End Property
    <Category("Options")>
    Public Property BarWidth() As Single
        Get
            Return _BarWidth
        End Get
        Set
            _BarWidth = Value
            Invalidate()
        End Set
    End Property
    <Category("Gradient Colours")>
    Public Property GradientStyle() As LinearGradientMode
        Get
            Return _GradientMode
        End Get
        Set
            _GradientMode = Value
            Invalidate()
        End Set
    End Property
    <Category("Colours")>
    Public Property LineColor() As Color
        Get
            Return _LineColor
        End Get
        Set
            _LineColor = Value
            Invalidate()
        End Set
    End Property
    <Category("Options")>
    Public Property LineWidth() As Integer
        Get
            Return _LineWitdh
        End Get
        Set
            _LineWitdh = Value
            Invalidate()
        End Set
    End Property
    <Category("Options")>
    Public Property ProgressShape() As _ProgressShape
        Get
            Return ProgressShapeVal
        End Get
        Set
            ProgressShapeVal = Value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property TextMode() As _TextMode
        Get
            Return ProgressTextMode
        End Get
        Set
            ProgressTextMode = Value
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
        MyBase.SuspendLayout()
        'SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.Opaque, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.Opaque, True)
        BackColor = Color.Transparent
        ForeColor = Color.DimGray
        Size = New Size(75, 75)
        Font = New Font("Segoe UI", 12)
        MinimumSize = New Size(58, 58)
        DoubleBuffered = True
        LineColor = Color.LightGray
        Value = 50
        ProgressShape = _ProgressShape.Flat
        TextMode = _TextMode.Percentage
        MyBase.ResumeLayout(False)
        MyBase.PerformLayout()
    End Sub


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
    Public Sub Increment(Val As Integer)
        _Value += Val
        Invalidate()
    End Sub
    Public Sub Decrement(Val As Integer)
        _Value -= Val
        Invalidate()
    End Sub
    ' Protected Overloads Overrides Sub OnPaint(e As PaintEventArgs)
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Using _bitmap As New Bitmap(Width, Height)
            Using graphics As Graphics = Graphics.FromImage(_bitmap)
                Dim bk As Color
                If Parent.BackColor = Color.Transparent Then

                    bk = BackColor
                Else
                    bk = Parent.BackColor
                End If

                graphics.Clear(bk)
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
                graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
                graphics.SmoothingMode = SmoothingMode.AntiAlias
                PaintTransparentBackground(Me, e)


                Dim rect As Rectangle = New Rectangle(10, 10, MyBase.Width - 20, MyBase.Width - 20)
                Using mBackColor As Brush = New SolidBrush(BackColor)
                    graphics.FillEllipse(mBackColor, rect)
                End Using
                Using pen2 As New Pen(LineColor, LineWidth)
                    graphics.DrawEllipse(pen2, rect)
                End Using
                Using brush As New LinearGradientBrush(ClientRectangle, _ProgressColor1, _ProgressColor2, GradientStyle)
                    Using pen As New Pen(brush, BarWidth)
                        Select Case ProgressShapeVal
                            Case _ProgressShape.Round
                                pen.StartCap = LineCap.Round
                                pen.EndCap = LineCap.Round
                                Exit Select
                            Case _ProgressShape.Flat
                                pen.StartCap = LineCap.Flat
                                pen.EndCap = LineCap.Flat
                                Exit Select
                        End Select
                        graphics.DrawArc(pen, rect, -90, CType((360 / _Maximum) * _Value, Integer))

                    End Using
                End Using

                Select Case TextMode
                    Case _TextMode.None
                        Text = String.Empty
                        Exit Select
                    Case _TextMode.Value
                        Text = _Value.ToString()
                        Exit Select
                    Case _TextMode.Percentage
                        Text = Convert.ToString((100 / _Maximum) * _Value) & "%"
                        Exit Select
                    Case _TextMode.Custom
                        Text = Text
                        Exit Select
                    Case Else
                        Exit Select
                End Select

                If Text IsNot String.Empty Then
                    Dim MS As SizeF = graphics.MeasureString(Text, Font)
                    Dim shadowBrush As New SolidBrush(Color.FromArgb(100, ForeColor))
                    graphics.DrawString(Text, Font, New SolidBrush(ForeColor), (Width / 2 - MS.Width / 2), (Height / 2 - MS.Height / 2))
                End If
                MyBase.OnPaint(e)

                e.Graphics.DrawImage(_bitmap, 0, 0)
                graphics.Dispose()
            End Using



        End Using

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

    End Sub
    Private Shared Sub PaintTransparentBackground(c As Control, e As PaintEventArgs)
        If c.Parent Is Nothing OrElse Not Application.RenderWithVisualStyles Then
            Return
        End If
        ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c)
    End Sub

    Private Sub FillCircle(g As Graphics, brush As Brush, centerX As Single, centerY As Single, radius As Single)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        Using gp As New System.Drawing.Drawing2D.GraphicsPath()
            g.FillEllipse(brush, centerX - radius, centerY - radius, radius + radius, radius + radius)
        End Using
    End Sub
#End Region
End Class