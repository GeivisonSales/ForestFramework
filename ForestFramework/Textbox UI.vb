Imports System.Drawing.Text
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Drawing
Imports ForestFramework.DrawHelpers
Imports System.Runtime.InteropServices

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusTextbox_UI

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
    Private WithEvents TB As TextBox
    Private _RoundBorder As Boolean = False
    Private _Round As Integer = 5
    Private _HeightSize As Integer = 2
    Private _TextOffset As Integer = 12
    Private _BaseColour As Color = Color.FromArgb(237, 237, 237)
    Private _TextColour As Color = Color.FromArgb(127, 131, 140)
    Private _BorderColour As Color = Color.FromArgb(209, 216, 224)
    Private _HoverBorderColour As Color = Color.FromArgb(119, 140, 163)
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean
    Private _UseSystemPasswordChar As Boolean
    Private _Multiline As Boolean

    Private _ImageActived As Boolean = False
    Private _ImageSelect As Image = My.Resources.happy
    Private _ImageSize As Size = New Size(20, 20)
    Private _ImageOffset As Integer = 7
    Private _IconDirection As Direction


    Enum Direction
        Left
        Right
    End Enum

    Enum MouseState
        None
        Hover
        Over
        Down
    End Enum


#End Region

#Region "TextBox Properties"


    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
    End Sub


    <Category("Options")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property BorderSize() As Integer
        Get
            Return _HeightSize
        End Get
        Set(ByVal value As Integer)

            If value > 3 Then
                _HeightSize = 3
            Else
                _HeightSize = value
            End If

            Me.Invalidate()
        End Set
    End Property

    <Category("Options")>
    Property TextOffsetX() As Integer
        Get
            Return _TextOffset
        End Get
        Set(ByVal value As Integer)
            _TextOffset = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Options")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    <Category("Options")>
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
                End If

            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property

    <Category("Options")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property

    <Category("Options")>
    Public Property RoundBorders As Boolean
        Get
            Return _RoundBorder
        End Get
        Set(value As Boolean)
            _RoundBorder = value
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
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ImageSelect As Image
        Get
            Return _ImageSelect
        End Get
        Set(value As Image)
            _ImageSelect = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ImageSize As Size
        Get
            Return _ImageSize
        End Get
        Set(value As Size)
            _ImageSize = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ImageOffsetX As Integer
        Get
            Return _ImageOffset
        End Get
        Set(value As Integer)
            _ImageOffset = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property IconDirection As Direction
        Get
            Return _IconDirection
        End Get
        Set(ByVal value As Direction)
            _IconDirection = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ActiveIcon As Boolean
        Get
            Return _ImageActived
        End Get
        Set(value As Boolean)
            _ImageActived = value
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub

    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub

    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        'TB.Location = New Point(5, 5)
        'TB.Width = Width - 10

        'If _Multiline Then
        'TB.Height = Height - 11
        'Else
        'Height = TB.Height + 11
        'End If

        MyBase.OnResize(e)
    End Sub

#End Region

#Region "Colour Properties"

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
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverBorderColour As Color
        Get
            Return _HoverBorderColour
        End Get
        Set(value As Color)
            _HoverBorderColour = value

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
        State = MouseState.Over : TB.Focus() : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseHover(e As EventArgs)
        MyBase.OnMouseHover(e)
        State = MouseState.Hover : Invalidate()
    End Sub

    Private Sub TB_MouseHover(sender As Object, e As EventArgs) Handles TB.MouseHover
        MyBase.OnMouseHover(e)
        State = MouseState.Hover : Invalidate()
    End Sub

    Private Sub TB_MouseDown(sender As Object, e As MouseEventArgs) Handles TB.MouseDown
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
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
        BackColor = Color.Transparent
        TB = New TextBox
        TB.Height = 190
        TB.Font = New Font("Segoe UI", 12)
        Me.Font = New Font("Segoe UI", 12)
        TB.Text = Text
        Try
            TB.BackColor = _BaseColour
        Catch ex As Exception
        End Try
        TB.ForeColor = _TextColour
        TB.MaxLength = _MaxLength
        TB.Multiline = False
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, Me.Height / 2 - TB.Height / 2)
        TB.Width = Width - 35
        Me.Size = New Size(310, 48)
        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub


    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim GP As GraphicsPath = New GraphicsPath(FillMode.Winding)
        Dim Base As New Rectangle(0, 0, Width, Height)


        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Try
                TB.BackColor = _BaseColour
            Catch ex As Exception
                MsgBox("Does not support transparent color!")
                _BaseColour = Color.FromArgb(49, 73, 222)
                TB.BackColor = _BaseColour
            End Try


            TB.ForeColor = _TextColour

            If _RoundBorder = True Then
                'round border
                .FillRectangle(New SolidBrush(_BaseColour), Base, _Round)

                If _ImageActived = True Then
                    'icon ativado
                    Select Case _IconDirection
                        Case Direction.Left
                            TB.Size = New Size(Width - 35 - _ImageOffset - _TextOffset, 190)
                            If _TextAlign = HorizontalAlignment.Left Then
                                TB.Location = New Point(_ImageOffset + _ImageSize.Width / 2 * 3 + _TextOffset, Me.Height / 2 - TB.Height / 2)
                            ElseIf _TextAlign = HorizontalAlignment.Right Then
                                TB.Location = New Point(_ImageOffset - _ImageSize.Width / 2 * 3 + _TextOffset, Me.Height / 2 - TB.Height / 2)
                            End If

                            .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                        Case Direction.Right
                            TB.Location = New Point(5 - _TextOffset, Me.Height / 2 - TB.Height / 2)
                            TB.Size = New Size(Width - 35 - _ImageOffset, 190)
                            .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                    End Select

                Else
                    'icon desativado
                    TB.Size = New Size(Width - 10 - _TextOffset, 190)
                    If _TextAlign = HorizontalAlignment.Left Then
                        TB.Location = New Point(5 + _TextOffset, Me.Height / 2 - TB.Height / 2)
                    ElseIf _TextAlign = HorizontalAlignment.Right Then
                        TB.Location = New Point(5 - _TextOffset, Me.Height / 2 - TB.Height / 2)
                    End If

                End If
                'border
                Select Case State
                    Case MouseState.None
                        Dim p As New Pen(_BorderColour, _HeightSize)
                        DrawRoundedRectangle(p, G, 1, 1, Width - 2, Height - 2, _Round + 6)
                    Case MouseState.Over
                        Dim p As New Pen(_HoverBorderColour, _HeightSize)
                        DrawRoundedRectangle(p, G, 1, 1, Width - 2, Height - 2, _Round + 6)
                    Case MouseState.Hover
                        Dim p As New Pen(_HoverBorderColour, _HeightSize)
                        DrawRoundedRectangle(p, G, 1, 1, Width - 2, Height - 2, _Round + 6)
                    Case MouseState.Down
                        Dim p As New Pen(_HoverBorderColour, _HeightSize)
                        DrawRoundedRectangle(p, G, 1, 1, Width - 2, Height - 2, _Round + 6)

                End Select

            Else
                'sem round
                .FillRectangle(New SolidBrush(_BaseColour), New Rectangle(0, 0, Width - 1, Height - 1))

                If _ImageActived = True Then
                    'icon ativado
                    Select Case _IconDirection
                        Case Direction.Left
                            TB.Size = New Size(Width - 35 - _ImageOffset - _TextOffset, 190)
                            TB.Location = New Point(_ImageOffset + _ImageSize.Width / 2 * 3 + _TextOffset, Me.Height / 2 - TB.Height / 2)
                            .DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                        Case Direction.Right
                            TB.Location = New Point(5 - _TextOffset, Me.Height / 2 - TB.Height / 2)
                            TB.Size = New Size(Width - 35 - _ImageOffset - _TextOffset, 190)
                            .DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                    End Select

                Else
                    'icon desativado
                    TB.Size = New Size(Width - 10 - _TextOffset, 190)
                    If _TextAlign = HorizontalAlignment.Left Then
                        TB.Location = New Point(5 + _TextOffset, Me.Height / 2 - TB.Height / 2)
                    ElseIf _TextAlign = HorizontalAlignment.Right Then
                        TB.Location = New Point(5 - _TextOffset, Me.Height / 2 - TB.Height / 2)
                    End If
                End If

                Select Case State
                    Case MouseState.None
                        Dim p As New Pen(_BorderColour, _HeightSize)
                        .DrawRectangle(p, 1, 1, Width - 2, Height - 2)
                    Case MouseState.Over
                        Dim p As New Pen(_HoverBorderColour, _HeightSize)
                        .DrawRectangle(p, 1, 1, Width - 2, Height - 2)
                    Case MouseState.Hover
                        Dim p As New Pen(_HoverBorderColour, _HeightSize)
                        .DrawRectangle(p, 1, 1, Width - 2, Height - 2)
                    Case MouseState.Down
                        Dim p As New Pen(_HoverBorderColour, _HeightSize)
                        .DrawRectangle(p, 1, 1, Width - 2, Height - 2)

                End Select


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
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub


    Public Sub DrawRoundedRectangle(ByVal pen1 As Pen, ByVal objGraphics As Graphics, ByVal m_intxAxis As Integer, ByVal m_intyAxis As Integer, ByVal m_intWidth As Integer, ByVal m_intHeight As Integer, ByVal m_diameter As Integer)
        objGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
        objGraphics.SmoothingMode = SmoothingMode.HighQuality
        objGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
        objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

        'Dim g As Graphics
        Dim BaseRect As New RectangleF(m_intxAxis, m_intyAxis, m_intWidth, m_intHeight)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(m_diameter, m_diameter))

        'Dim pen1 As New Pen(_borderColor, _borderThickness)
        'top left Arc
        objGraphics.DrawArc(pen1, ArcRect, 180, 90)
        objGraphics.DrawLine(pen1, m_intxAxis + CInt(m_diameter / 2) - 3, m_intyAxis, m_intxAxis + m_intWidth - CInt(m_diameter / 2) + 3, m_intyAxis)

        ' top right arc
        ArcRect.X = BaseRect.Right - m_diameter
        objGraphics.DrawArc(pen1, ArcRect, 270, 90)
        objGraphics.DrawLine(pen1, m_intxAxis + m_intWidth, m_intyAxis + CInt(m_diameter / 2), m_intxAxis + m_intWidth, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - m_diameter
        objGraphics.DrawArc(pen1, ArcRect, 0, 90)
        objGraphics.DrawLine(pen1, m_intxAxis + CInt(m_diameter / 2) - 3, m_intyAxis + m_intHeight, m_intxAxis + m_intWidth - CInt(m_diameter / 2) + 3, m_intyAxis + m_intHeight)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        objGraphics.DrawArc(pen1, ArcRect, 90, 90)
        objGraphics.DrawLine(pen1, m_intxAxis, m_intyAxis + CInt(m_diameter / 2), m_intxAxis, m_intyAxis + m_intHeight - CInt(m_diameter / 2))

    End Sub

#End Region

End Class
