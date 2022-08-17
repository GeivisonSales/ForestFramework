Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms


'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusDragControl_UI

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

    Private WithEvents handlecontrol As Control


    Public Const WM_NCLBUTTONDOWN As Integer = 161
    Public Const HT_CAPTION As Integer = 2


    Public Property SelectControl As Control
        Get
            Return Me.handlecontrol
        End Get
        Set(ByVal value As Control)

            Try
                handlecontrol = value
                AddHandler handlecontrol.MouseDown, (AddressOf Me.DragForm_MouseDown)
            Catch ex As Exception

            End Try


        End Set
    End Property




    <DllImport("User32")> Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer

    End Function

    <DllImport("User32")> Private Shared Function ReleaseCapture() As Boolean

    End Function

    Private Sub DragForm_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim flag As Boolean = e.Button = MouseButtons.Left
        Try
            If (e.Button = MouseButtons.Left) Then
                ReleaseCapture()
                SendMessage(Me.SelectControl.FindForm().Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
            End If
        Catch ex As Exception

        End Try


    End Sub



End Class
