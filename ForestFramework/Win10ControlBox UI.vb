Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Class NikyusWin10ControlBox_UI
    Inherits Control

    Private hover_min, hover_max, hover_close As Boolean
    Private _EnableMaximize As Boolean = True

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


    <Browsable(True)>
    <Category("Options")>
    Public Property EnableMaximizeButton As Boolean
        Get
            Return _EnableMaximize
        End Get
        Set(ByVal value As Boolean)
            _EnableMaximize = value
            Invalidate()
        End Set
    End Property

    Private _EnableMinimize As Boolean = True

    <Browsable(True)>
    <Category("Options")>
    Public Property EnableMinimizeButton As Boolean
        Get
            Return _EnableMinimize
        End Get
        Set(ByVal value As Boolean)
            _EnableMinimize = value
            Invalidate()
        End Set
    End Property

    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property ForeColor As Color
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property BackgroundImageLayout As ImageLayout
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property BackgroundImage As Image
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property RightToLeft As RightToLeft
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property ContextMenuStrip As ContextMenuStrip
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property MinimumSize As Size
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property MaximumSize As Size
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property Font As Font
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property Padding As Padding
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property Margin As Padding
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property Tag As String
    <Bindable(False), EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Overloads Property Text As String

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(139, 31)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)

        If e.X > 0 AndAlso e.X < 47 AndAlso e.Y > 0 AndAlso e.Y < 31 Then
            hover_min = True
            hover_max = False
            hover_close = False
        ElseIf e.X > 46 AndAlso e.X < 94 AndAlso e.Y > 0 AndAlso e.Y < 31 Then
            hover_min = False
            hover_max = True
            hover_close = False
        ElseIf e.X > 93 AndAlso e.X < 150 AndAlso e.Y > 0 AndAlso e.Y < 31 Then
            hover_min = False
            hover_max = False
            hover_close = True
        Else
            hover_min = False
            hover_max = False
            hover_close = False
        End If

        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        hover_min = False
        hover_max = False
        hover_close = False
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Focus()
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        Dim pf = FindForm()

        If _EnableMaximize Then

            If hover_max And e.Button = MouseButtons.Left Then

                Select Case pf.WindowState
                    Case FormWindowState.Normal
                        pf.WindowState = FormWindowState.Maximized
                    Case FormWindowState.Maximized
                        pf.WindowState = FormWindowState.Normal
                End Select
            End If
        End If

        If _EnableMinimize Then
            If hover_min And e.Button = MouseButtons.Left Then pf.WindowState = FormWindowState.Minimized
        End If

        If hover_close And e.Button = MouseButtons.Left Then Application.[Exit]()
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
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        DoubleBuffered = True
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Cursor = Cursors.Arrow
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Location = New Point(FindForm().Width - 139, 0)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g = e.Graphics
        Dim btnBackgroundSize = New Size(46, Height)
        Dim minimizeBtnFont = New Font("Tahoma", 12)
        Dim minimizeBtnPoint = New Point(15, 5)
        Dim minimizeBtnBrush = New SolidBrush(If(_EnableMinimize, ColorTranslator.FromHtml("#A0A0A0"), ColorTranslator.FromHtml("#696969")))

        If hover_min AndAlso _EnableMinimize Then

            Using backColor = New SolidBrush(Color.FromArgb(15, Color.White))
                g.FillRectangle(backColor, New Rectangle(New Point(1, 0), btnBackgroundSize))
            End Using

            minimizeBtnBrush = New SolidBrush(Color.White)
        End If

        g.DrawString("−", minimizeBtnFont, minimizeBtnBrush, minimizeBtnPoint)
        minimizeBtnBrush.Dispose()
        minimizeBtnFont.Dispose()
        Dim maximizeBtnFont = New Font("Marlett", 9)
        Dim maximizeBtnPoint = New Point(63, 10)
        Dim maximizeBtnBrush = New SolidBrush(If(_EnableMaximize, ColorTranslator.FromHtml("#A0A0A0"), ColorTranslator.FromHtml("#696969")))

        If hover_max AndAlso _EnableMaximize Then

            Using backColor = New SolidBrush(Color.FromArgb(15, Color.White))
                g.FillRectangle(backColor, New Rectangle(New Point(47, 0), btnBackgroundSize))
            End Using

            maximizeBtnBrush = New SolidBrush(Color.White)
        End If

        g.DrawString(If(FindForm().WindowState <> FormWindowState.Maximized, "1", "2"), maximizeBtnFont, maximizeBtnBrush, maximizeBtnPoint)
        maximizeBtnBrush.Dispose()
        maximizeBtnFont.Dispose()
        Dim closeBtnFont = New Font("Tahoma", 11)
        Dim closeBtnPoint = New Point(107, 6)
        Dim closeBtnBrush = New SolidBrush(ColorTranslator.FromHtml("#A0A0A0"))

        If hover_close Then

            Using backColor = New SolidBrush(ColorTranslator.FromHtml("#C75050"))
                g.FillRectangle(backColor, New Rectangle(New Point(93, 0), btnBackgroundSize))
            End Using

            closeBtnBrush = New SolidBrush(Color.White)
        End If

        g.DrawString("⨉", closeBtnFont, closeBtnBrush, closeBtnPoint)
        closeBtnBrush.Dispose()
        closeBtnFont.Dispose()
        MyBase.OnPaint(e)
    End Sub
End Class
