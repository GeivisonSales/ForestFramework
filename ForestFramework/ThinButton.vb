Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.Windows.Forms
Imports ForestFramework.ExtendedGraphics
Imports ForestFramework.NotificationCounter
'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusThinButton_UI
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
    Private _borderColor As Color = Color.Transparent
    Private _onHoverBorderColor As Color = Color.FromArgb(43, 70, 240)
    Private _buttonColor As Color = Color.FromArgb(43, 70, 240)
    Private _onHoverButtonColor As Color = Color.Transparent
    Private _textColor As Color = Color.White
    Private _onHoverTextColor As Color = Color.White
    Private _isHovering As Boolean
    Private _borderThickness As Integer = 3
    Private _borderThicknessByTwo As Integer = 3

    Private _ImageActived As Boolean = False
    Private _ImageSelect As Image = My.Resources.happy
    Private _PressedImage As Image = My.Resources.pressed_happy
    Private _ImageSize As Size = New Size(20, 20)
    Private _ImageOffset As Integer = 7
    Private _RoundImage As Boolean = False
    Private _IconRound As Integer = 5
    Private _BorderSize As Integer = 3
    Private _IconDirection As Direction

    Private _NotificationEnabled As Boolean = False
    Private _NotificationColor As Color = Color.Red
    Private _NotificationFontColor As Color = Color.White
    Private _NotificationDirection As Direction
    Private _NotificationText As Integer = 30
    Private _NotificationOffset As Integer = 0
    Private _NotificationRound As Integer = 0

    'ToogleButton + Patch 2.1------------------------------------------
    Private _BaseHoverColour As Color = Color.FromArgb(43, 70, 240)
    Private _TextHoverColour As Color = Color.White
    Private _BorderHoverColour As Color = Color.Transparent

    Private _ButtonStyle As ButtonStyle
    Private _BaseCheckedColor As Color
    Private _TextCheckedColor As Color = Color.White
    Private _BorderCheckedColor As Color
    Private _Checked As Boolean

    Private _ImageCheckedSelect As Image = My.Resources.happy
    Private _ImageCheckedSize As Size = New Size(20, 20)
    Private _ImageCheckedOffset As Integer = 7
    Private _IconCheckedDirection As Direction
    Private _TextChecked As String

    Private _TextRender As TextRenderingHint

    Enum ButtonStyle
        Normal
        ToogleButton
    End Enum
    'ToogleButton + Patch 2.1------------------------------------------

    Enum Direction
        Left
        Right
    End Enum
#End Region

#Region "Properties"
    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _borderColor
        End Get
        Set(ByVal value As Color)
            _borderColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property PressedBorderColour As Color
        Get
            Return _onHoverBorderColor
        End Get
        Set(ByVal value As Color)
            _onHoverBorderColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _buttonColor
        End Get
        Set(ByVal value As Color)
            _buttonColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property PressedBaseColour As Color
        Get
            Return _onHoverButtonColor
        End Get
        Set(ByVal value As Color)
            _onHoverButtonColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property TextColour As Color
        Get
            Return _textColor
        End Get
        Set(ByVal value As Color)
            _textColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property PressedTextColour As Color
        Get
            Return _onHoverTextColor
        End Get
        Set(ByVal value As Color)
            _onHoverTextColor = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property BorderSize As Integer
        Get
            Return _borderThickness
        End Get
        Set(value As Integer)
            _borderThickness = value
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
    Public Property PressedImage As Image
        Get
            Return _PressedImage
        End Get
        Set(value As Image)
            _PressedImage = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property ImageOffset As Integer
        Get
            Return _ImageOffset
        End Get
        Set(value As Integer)
            _ImageOffset = value
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

    <Category("Notification Counter")>
    Public Property NotificationEnabled As Boolean
        Get
            Return _NotificationEnabled
        End Get
        Set(value As Boolean)
            _NotificationEnabled = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationColor As Color
        Get
            Return _NotificationColor
        End Get
        Set(value As Color)
            _NotificationColor = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationFontColor As Color
        Get
            Return _NotificationFontColor
        End Get
        Set(value As Color)
            _NotificationFontColor = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationCount As Integer
        Get
            Return _NotificationText
        End Get
        Set(value As Integer)
            _NotificationText = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationDirection As Direction
        Get
            Return _NotificationDirection
        End Get
        Set(value As Direction)
            _NotificationDirection = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationOffsetX As Integer
        Get
            Return _NotificationOffset
        End Get
        Set(value As Integer)
            _NotificationOffset = value
            Invalidate()
        End Set
    End Property

    <Category("Notification Counter")>
    Public Property NotificationRound As Integer
        Get
            Return _NotificationRound
        End Get
        Set(value As Integer)

            If value > 9 Then
                _NotificationRound = 9
                value = 9
            Else
                _NotificationRound = value
            End If

            Invalidate()
        End Set
    End Property

    'ToogleButton + Patch 2.1------------------------------------------
    <Category("Options")>
    Public Property StyleButton As ButtonStyle
        Get
            Return _ButtonStyle
        End Get
        Set(ByVal value As ButtonStyle)
            _ButtonStyle = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedBaseColour As Color
        Get
            Return _BaseCheckedColor
        End Get
        Set(value As Color)
            _BaseCheckedColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedTextColour As Color
        Get
            Return _TextCheckedColor
        End Get
        Set(value As Color)
            _TextCheckedColor = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property CheckedBorderColour As Color
        Get
            Return _BorderCheckedColor
        End Get
        Set(value As Color)
            _BorderCheckedColor = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property CheckedImageSelect As Image
        Get
            Return _ImageCheckedSelect
        End Get
        Set(value As Image)
            _ImageCheckedSelect = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property CheckedImageSize As Size
        Get
            Return _ImageCheckedSize
        End Get
        Set(value As Size)
            _ImageCheckedSize = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property CheckedImageOffsetX As Integer
        Get
            Return _ImageCheckedOffset
        End Get
        Set(value As Integer)
            _ImageCheckedOffset = value
            Invalidate()
        End Set
    End Property

    <Category("Image Icon")>
    Public Property CheckedIconDirection As Direction
        Get
            Return _IconCheckedDirection
        End Get
        Set(value As Direction)
            _IconCheckedDirection = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property CheckedText As String
        Get
            Return _TextChecked
        End Get
        Set(value As String)
            _TextChecked = value
            Invalidate()
        End Set
    End Property

    <Category("Options")>
    Public Property TextRendering As TextRenderingHint
        Get
            Return _TextRender
        End Get
        Set(value As TextRenderingHint)
            _TextRender = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverBaseColour As Color
        Get
            Return _BaseHoverColour
        End Get
        Set(value As Color)
            _BaseHoverColour = value
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverBorderColour As Color
        Get
            Return _BorderHoverColour
        End Get
        Set(value As Color)
            _BorderHoverColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property HoverTextColour As Color
        Get
            Return _TextHoverColour
        End Get
        Set(value As Color)
            _TextHoverColour = value
            Invalidate()
        End Set
    End Property

    'ToogleButton + Patch 2.1------------------------------------------

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
        DoubleBuffered = True

        AddHandler MouseEnter, (Function(sender, e)
                                    _isHovering = True
                                    Invalidate()
#Disable Warning BC42105 ' Function doesn't return a value on all code paths
                                End Function)
#Enable Warning BC42105 ' Function doesn't return a value on all code paths

        AddHandler MouseLeave, (Function(sender, e)
                                    _isHovering = False
                                    Invalidate()
#Disable Warning BC42105 ' Function doesn't return a value on all code paths
                                End Function)
#Enable Warning BC42105 ' Function doesn't return a value on all code paths
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
              ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
              ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(165, 40)
        'Me.FlatStyle = FlatStyle.Flat
        'Me.FlatAppearance.BorderSize = 0
        BackColor = Color.Transparent
        Me.Font = New Font("Segoe UI", 12)
        Me.Size = New Size(203, 50)
        Try
            _buttonColor = Me.Parent.BackColor
        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        g.TextRenderingHint = _TextRender
        g.SmoothingMode = SmoothingMode.HighQuality
        g.PixelOffsetMode = PixelOffsetMode.HighQuality
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

        Dim brush As Brush = New SolidBrush(If(_isHovering, _onHoverBorderColor, _borderColor))

        Select Case _ButtonStyle
            Case ButtonStyle.Normal 'Normal Button

                Select Case State
                    Case MouseState.None '-------------------------------------------------------------------------------
                        g.FillRectangle(New SolidBrush(_buttonColor), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                        Dim p As New Pen(_borderColor, _borderThickness)
                        DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)
                        'text
                        g.DrawString(Text, Font, New SolidBrush(_textColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                        If _ImageActived = True Then
                            Select Case _IconDirection
                                Case Direction.Left
                                    g.DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                Case Direction.Right
                                    g.DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                            End Select

                        Else

                        End If

                    Case MouseState.Over '-------------------------------------------------------------------------------
                        g.FillRectangle(New SolidBrush(_BaseHoverColour), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                        Dim p As New Pen(_BorderHoverColour, _borderThickness)
                        DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)
                        'text
                        g.DrawString(Text, Font, New SolidBrush(_textColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                        If _ImageActived = True Then
                            Select Case _IconDirection
                                Case Direction.Left
                                    g.DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                Case Direction.Right
                                    g.DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                            End Select

                        Else

                        End If

                    Case MouseState.Down '-------------------------------------------------------------------------------
                        g.FillRectangle(New SolidBrush(_onHoverButtonColor), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                        Dim p As New Pen(_onHoverBorderColor, _borderThickness)
                        DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)

                        'text
                        g.DrawString(Text, Font, New SolidBrush(_onHoverTextColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                        If _ImageActived = True Then
                            Select Case _IconDirection
                                Case Direction.Left
                                    g.DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                Case Direction.Right
                                    g.DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                            End Select

                        Else

                        End If



                End Select

            Case ButtonStyle.ToogleButton 'Toogle Button

                If _Checked = True Then 'Toogle ativo

                    Select Case State
                        Case MouseState.None '-------------------------------------------------------------------------------
                            g.FillRectangle(New SolidBrush(_BaseCheckedColor), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                            Dim p As New Pen(_BorderHoverColour, _borderThickness)
                            DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)
                            'text
                            g.DrawString(_TextChecked, Font, New SolidBrush(_TextCheckedColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                            If _ImageActived = True Then
                                Select Case _IconCheckedDirection
                                    Case Direction.Left
                                        g.DrawImage(_ImageCheckedSelect, _ImageCheckedOffset, CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                    Case Direction.Right
                                        g.DrawImage(_ImageCheckedSelect, CInt(Width - _ImageCheckedSize.Width - _ImageCheckedOffset), CInt(Height / 2) - CInt(_ImageCheckedSize.Height / 2), _ImageCheckedSize.Width, _ImageCheckedSize.Height)
                                End Select

                            Else

                            End If

                        Case MouseState.Over '-------------------------------------------------------------------------------
                            g.FillRectangle(New SolidBrush(_BaseHoverColour), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                            Dim p As New Pen(_BorderHoverColour, _borderThickness)
                            DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)
                            'text
                            g.DrawString(_TextChecked, Font, New SolidBrush(_textColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                            If _ImageActived = True Then
                                Select Case _IconCheckedDirection
                                    Case Direction.Left
                                        g.DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    Case Direction.Right
                                        g.DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                End Select

                            Else

                            End If

                        Case MouseState.Down '-------------------------------------------------------------------------------
                            g.FillRectangle(New SolidBrush(_onHoverButtonColor), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                            Dim p As New Pen(_onHoverBorderColor, _borderThickness)
                            DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)

                            'text
                            g.DrawString(Text, Font, New SolidBrush(_onHoverTextColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                            If _ImageActived = True Then
                                Select Case _IconDirection
                                    Case Direction.Left
                                        g.DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    Case Direction.Right
                                        g.DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                End Select

                            Else

                            End If



                    End Select

                Else 'Toogle Desativado

                    Select Case State
                        Case MouseState.None '-------------------------------------------------------------------------------
                            g.FillRectangle(New SolidBrush(_buttonColor), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                            Dim p As New Pen(_borderColor, _borderThickness)
                            DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)
                            'text
                            g.DrawString(Text, Font, New SolidBrush(_textColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                            If _ImageActived = True Then
                                Select Case _IconDirection
                                    Case Direction.Left
                                        g.DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    Case Direction.Right
                                        g.DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                End Select

                            Else

                            End If

                        Case MouseState.Over '-------------------------------------------------------------------------------
                            g.FillRectangle(New SolidBrush(_BaseHoverColour), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                            Dim p As New Pen(_BorderHoverColour, _borderThickness)
                            DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)
                            'text
                            g.DrawString(Text, Font, New SolidBrush(_textColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                            If _ImageActived = True Then
                                Select Case _IconDirection
                                    Case Direction.Left
                                        g.DrawImage(_ImageSelect, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    Case Direction.Right
                                        g.DrawImage(_ImageSelect, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                End Select

                            Else

                            End If

                        Case MouseState.Down '-------------------------------------------------------------------------------
                            g.FillRectangle(New SolidBrush(_onHoverButtonColor), 2, 2, Width - 5, Height - 5, Me.Height / 2)
                            Dim p As New Pen(_onHoverBorderColor, _borderThickness)
                            DrawRoundedRectangle(p, g, 2, 2, Width - 5, Height - 5, Me.Height / 2 * 2 - 5)

                            'text
                            g.DrawString(Text, Font, New SolidBrush(_onHoverTextColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
                            If _ImageActived = True Then
                                Select Case _IconDirection
                                    Case Direction.Left
                                        g.DrawImage(_PressedImage, _ImageOffset, CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                    Case Direction.Right
                                        g.DrawImage(_PressedImage, CInt(Width - _ImageSize.Width - _ImageOffset), CInt(Height / 2) - CInt(_ImageSize.Height / 2), _ImageSize.Width, _ImageSize.Height)
                                End Select

                            Else

                            End If



                    End Select

                End If

        End Select



        'Notification Counter
        If _NotificationEnabled = True Then
            Dim _notTxt As String = _NotificationText
            If _notTxt > 99 Then
                _notTxt = "99+"
            End If

            If _NotificationDirection = Direction.Left Then
                If _notTxt = "99+" Then
                    DrawNotification(g, Me, 3 + _NotificationOffset, Height / 2 - 14 + 6 / 2, _NotificationColor, _NotificationFontColor, New Size(20, 14), _notTxt, _NotificationRound)
                Else
                    DrawNotification(g, Me, 3 + _NotificationOffset, Height / 2 - 14 + 6 / 2, _NotificationColor, _NotificationFontColor, New Size(16, 14), _notTxt, _NotificationRound)
                End If

            ElseIf _NotificationDirection = Direction.Right Then
                If _notTxt = "99+" Then
                    DrawNotification(g, Me, Width - 30 - _NotificationOffset, Height / 2 - 14 + 6 / 2, _NotificationColor, _NotificationFontColor, New Size(20, 14), _notTxt, _NotificationRound)
                Else
                    DrawNotification(g, Me, Width - 25 - _NotificationOffset, Height / 2 - 14 + 6 / 2, _NotificationColor, _NotificationFontColor, New Size(16, 14), _notTxt, _NotificationRound)
                End If

            End If
        End If

        If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime Then
            'modo designer
            Try

                If My.Settings.status = "error" Or My.Settings.status = "waiting" Then
                    g.DrawString("Trial NikyusUI", New Font("Arial", 22), New SolidBrush(Color.FromArgb(50, Color.White)), 0, 0)
                End If
            Catch ex As Exception

            End Try

        Else
            'modo realtime

            Try

                If My.Settings.status = "error" Or My.Settings.status = "waiting" Then
                    'g.DrawString("Trial NikyusUI", New Font("Arial", 22), New SolidBrush(Color.FromArgb(50, Color.White)), 0, 0)
                End If
            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Sub DrawRoundedRectangle(ByVal pen1 As Pen, ByVal objGraphics As Graphics, ByVal m_intxAxis As Integer, ByVal m_intyAxis As Integer, ByVal m_intWidth As Integer, ByVal m_intHeight As Integer, ByVal m_diameter As Integer)
        objGraphics.TextRenderingHint = _TextRender
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
End Class
