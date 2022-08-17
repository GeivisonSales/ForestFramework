Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusTransitionForm_UI
    Inherits Component

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
    Private WithEvents handlecontrol As Form
    Private _style As style = style.Normal
    Private _time = 0

    Enum style
        HOR_ForRight
        HOR_ForLeft
        VER_ForBottom
        VER_ForTop
        InsideOut
        DIAGONAL_RightToTopCenter
        DIAGONAL_LeftToTopCenter
        Normal
    End Enum

#End Region

#Region "Properties"

    <Category("Options")>
    Public Property SelectForm As Form
        Get
            Return Me.handlecontrol
        End Get
        Set(ByVal value As Form)

            Try
                handlecontrol = value

            Catch ex As Exception

            End Try


        End Set
    End Property
    <Category("Options")>
    Public Property Styles As style
        Get
            Return _style
        End Get
        Set(ByVal value As style)
            _style = value
            '  start()
        End Set
    End Property
    <Category("Options")>
    Public Property Interval As Integer
        Get
            Return _time
        End Get
        Set(ByVal value As Integer)
            _time = value
            ' start()
        End Set
    End Property

#End Region

    Public Const HOR_ForRight As Integer = 1
    Public Const HOR_ForLeft As Integer = 2
    Public Const VER_ForBottom As Integer = 4
    Public Const VER_ForTop As Integer = 8
    Public Const InsideOut As Integer = 16
    Public Const DIAGONAL_RightToTopCenter As Integer = 10
    Public Const DIAGONAL_LeftToTopCenter As Integer = 11
    Public Const Normal As Integer = 80000

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function AnimateWindow(ByVal hwand As IntPtr, ByVal dwTime As Integer, ByVal dwFlag As Integer) As Integer
    End Function

    Private Sub handlecontrol_Load(sender As Object, e As EventArgs) Handles handlecontrol.Load
        Try
            AnimateWindow(_handlecontrol.Handle, _time, _style)
        Catch ex As Exception

        End Try
    End Sub
End Class
