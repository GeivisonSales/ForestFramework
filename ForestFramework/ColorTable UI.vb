Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing

'----------------------------
'NikyusUi
'Creator: Geivison Sales
'Version: 1.3
'Created: 12/09/2020
'Changed: 12/09/2020
'----------------------------

Public Class NikyusColorTable_UI
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
    Private _Dark_C1 As Color
    Private _Dark_C2 As Color
    Private _Dark_C3 As Color
    Private _Dark_C4 As Color
    Private _Dark_C5 As Color
    Private _Dark_C6 As Color

    Private _Light_C1 As Color
    Private _Light_C2 As Color
    Private _Light_C3 As Color
    Private _Light_C4 As Color
    Private _Light_C5 As Color
    Private _Light_C6 As Color

#End Region

#Region "Properties"

#Region "--Dark"
    <Category("Dark Table")>
    Public Property Dark_Color1 As Color
        Get
            Return _Dark_C1
        End Get
        Set(ByVal value As Color)
            _Dark_C1 = value

        End Set
    End Property

    <Category("Dark Table")>
    Public Property Dark_Color2 As Color
        Get
            Return _Dark_C2
        End Get
        Set(ByVal value As Color)
            _Dark_C2 = value

        End Set
    End Property

    <Category("Dark Table")>
    Public Property Dark_Color3 As Color
        Get
            Return _Dark_C3
        End Get
        Set(ByVal value As Color)
            _Dark_C3 = value

        End Set
    End Property

    <Category("Dark Table")>
    Public Property Dark_Color4 As Color
        Get
            Return _Dark_C4
        End Get
        Set(ByVal value As Color)
            _Dark_C4 = value

        End Set
    End Property

    <Category("Dark Table")>
    Public Property Dark_Color5 As Color
        Get
            Return _Dark_C5
        End Get
        Set(ByVal value As Color)
            _Dark_C5 = value

        End Set
    End Property

    <Category("Dark Table")>
    Public Property Dark_Color6 As Color
        Get
            Return _Dark_C6
        End Get
        Set(ByVal value As Color)
            _Dark_C6 = value

        End Set
    End Property
#End Region

#Region "--Light"
    <Category("Light Table")>
    Public Property Light_Color1 As Color
        Get
            Return _Light_C1
        End Get
        Set(ByVal value As Color)
            _Light_C1 = value

        End Set
    End Property

    <Category("Light Table")>
    Public Property Light_Color2 As Color
        Get
            Return _Light_C2
        End Get
        Set(ByVal value As Color)
            _Light_C2 = value

        End Set
    End Property

    <Category("Light Table")>
    Public Property Light_Color3 As Color
        Get
            Return _Light_C3
        End Get
        Set(ByVal value As Color)
            _Light_C3 = value

        End Set
    End Property

    <Category("Light Table")>
    Public Property Light_Color4 As Color
        Get
            Return _Light_C4
        End Get
        Set(ByVal value As Color)
            _Light_C4 = value

        End Set
    End Property

    <Category("Light Table")>
    Public Property Light_Color5 As Color
        Get
            Return _Light_C5
        End Get
        Set(ByVal value As Color)
            _Light_C5 = value

        End Set
    End Property

    <Category("Light Table")>
    Public Property Light_Color6 As Color
        Get
            Return _Light_C6
        End Get
        Set(ByVal value As Color)
            _Light_C6 = value

        End Set
    End Property

#End Region

#End Region

End Class
