Imports System.Management
Imports System.Security.Cryptography
Imports System.Text
Imports System
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Net
Imports System.Windows.Forms

Public Class Licensing


    'status codes["waiting", "success", "error"]

    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Integer, ByVal dwReserved As Integer) As Integer
    'Internet connection is currently configured
    Private Const InternetConnectionIsConfigured As Integer = &H40S

    Public json As String

    Private Function SystemSerialNumber() As String
        ' Get the Windows Management Instrumentation object.
        Dim wmi As Object = GetObject("WinMgmts:")

        ' Get the "base boards" (mother boards).
        Dim serial_numbers As String = ""
        Dim mother_boards As Object =
        wmi.InstancesOf("Win32_BaseBoard")
        For Each board As Object In mother_boards
            serial_numbers &= ", " & board.SerialNumber
        Next board
        If serial_numbers.Length > 0 Then serial_numbers =
        serial_numbers.Substring(2)

        Return serial_numbers
    End Function

    Private Function CpuId() As String
        Dim computer As String = "."
        Dim wmi As Object = GetObject("winmgmts:" &
        "{impersonationLevel=impersonate}!\\" &
        computer & "\root\cimv2")
        Dim processors As Object = wmi.ExecQuery("Select * from " &
        "Win32_Processor")

        Dim cpu_ids As String = ""
        For Each cpu As Object In processors
            cpu_ids = cpu_ids & ", " & cpu.ProcessorId
        Next cpu
        If cpu_ids.Length > 0 Then cpu_ids =
        cpu_ids.Substring(2)

        Return cpu_ids
    End Function

    Shared Function GetHash(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
             hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function

    Public Sub verification()
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Dim datahoraAtual As DateTime = Now

            'Dim lasthour As Date = Date.Parse(My.Settings.lastverification)
            ' Dim nowhour As Date = Date.Parse(datahoraAtual.ToShortTimeString)

            'bw1.RunWorkerAsync() - LIGAR


            If My.Settings.status = "waiting" Or My.Settings.status = "" Or My.Settings.status = " " Then
                testing()
                My.Settings.verification = "v"
                My.Settings.Save()
            ElseIf My.Settings.status = "success" Then

                Dim _time1 As DateTime = My.Settings.lastverification
                Dim _time2 As DateTime = DateTime.Now

                Dim _timeSpan As TimeSpan
                _timeSpan = _time1 - _time2

                'testar novamente
                If (_timeSpan.Minutes.ToString * -1) >= "8" Then

                    'testar novamente
                    testing()
                Else
                    'não testar
                End If

                My.Settings.verification = "v"
                My.Settings.Save()

            ElseIf My.Settings.status = "error" Then
                testing()

                My.Settings.verification = "v"
                My.Settings.Save()

            ElseIf My.Settings.lastverification = "" Or My.Settings.lastverification = " " Or My.Settings.lastverification = "00/00/00 00:00" Then
                testing()
                My.Settings.verification = "v"
                My.Settings.Save()

            Else
                testing()
                My.Settings.verification = "v"
                My.Settings.Save()
            End If



        Catch ex As Exception
            My.Settings.verification = "n"
            My.Settings.Save()
        End Try


    End Sub

    Private Sub Licensing_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Control.CheckForIllegalCrossThreadCalls = False

        ''-Sistema Anti-Pirataria
        If My.Settings.verification = "" Or My.Settings.verification = " " Then
            verification()
        ElseIf My.Settings.verification = "n" Then
            MessageBox.Show("We noticed that you may be using a non-original version of the Nikyus Framework. Download a new original version from the website (www.nikyus.com/framework).

        [Don't use pirated DLL's, your machine could be damaged!]", "[Error] - Non-original version.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            My.Settings.status = "error"
            My.Settings.lastverification = ""
            My.Settings.Save()
            Me.Close()

        End If
        ''--Sistema Anti-Pirataria

    End Sub

    Private Sub pnlTxt_Click(sender As Object, e As EventArgs) Handles pnlTxt.Click
        txtKey.Focus()
    End Sub

    Private Sub bw1_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw1.DoWork
        Dim Hash As String = GetHash(CpuId() & SystemSerialNumber())

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        json = (New WebClient()).DownloadString("https://nikyus.com/api/framework_ui/license_check.php?hwid=" & Hash)


    End Sub

    Private Sub bw1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw1.RunWorkerCompleted
        If json = "Key Valid" Then

            Dim datahoraAtual As DateTime = Now

            My.Settings.status = "success"
            My.Settings.lastverification = datahoraAtual.ToShortTimeString
            My.Settings.Save()
        Else

            My.Settings.status = "error"
            My.Settings.Save()
            ' MsgBox("We had problems using your license, check that your key is correct or try again later!")
            btnRegister.Enabled = True
            txtKey.Enabled = True
            Label5.Enabled = True
            Me.Show()

        End If

        json = ""
    End Sub

    Private Sub txtKey_Click(sender As Object, e As EventArgs) Handles txtKey.Click
        If txtKey.Text = "YOUR LICENSE KEY" Then
            txtKey.Text = ""
            txtKey.Focus()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        txtKey.Focus()
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()

    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Register()
    End Sub

    Private Sub btnRegister_MouseHover(sender As Object, e As EventArgs) Handles btnRegister.MouseHover
        btnRegister.Image = My.Resources.activate_btn_green_clicked
    End Sub

    Private Sub btnRegister_MouseLeave(sender As Object, e As EventArgs) Handles btnRegister.MouseLeave
        btnRegister.Image = My.Resources.activate_btn_green
    End Sub

    Private Sub txtKey_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKey.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            Register()
        End If
    End Sub

    Private Sub Register()
        'salvarx
        btnRegister.Enabled = False
        txtKey.Enabled = False
        Label5.Enabled = False

        If txtKey.Text = "" Or txtKey.Text = " " Then
            MsgBox("License missing!")
            txtKey.Text = "YOUR LICENSE KEY"
            btnRegister.Enabled = True
            txtKey.Enabled = True
            Label5.Enabled = True
        Else

            Dim Hash As String = GetHash(CpuId() & SystemSerialNumber())

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            Dim json As String = (New WebClient()).DownloadString("https://nikyus.com/api/framework_ui/license_check.php?license=" & txtKey.Text & "&hwid=" & Hash)

            If json = "Register Sucess" Then
                SaveSetting("ForestFramework", "license", "hwid", Hash)
                ' Dim datahoraAtual As DateTime = Now

                My.Settings.status = "success"
                My.Settings.lastverification = DateTime.Now
                My.Settings.Save()
                MsgBox("You have been successfully registered, enjoy! :)")

                Me.Close()


            ElseIf json = "Maximum Exceeded" Then
                MsgBox("You have exceeded the Devices limit of your plan, upgrade your plan to increase your Devices! :)")
                btnRegister.Enabled = True
                txtKey.Enabled = True
                Label5.Enabled = True
                My.Settings.status = "error"
                My.Settings.Save()
            Else
                MsgBox("We had problems using your license, check that your key is correct or try again later!")
                btnRegister.Enabled = True
                txtKey.Enabled = True
                Label5.Enabled = True
                My.Settings.status = "error"
                My.Settings.Save()
            End If

        End If
    End Sub


    Public Sub testing()
        Try
            'Check
            Dim Hash As String = GetHash(CpuId() & SystemSerialNumber())

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            json = (New WebClient()).DownloadString("https://nikyus.com/api/framework_ui/license_check.php?hwid=" & Hash)

            'Activation
            If json = "Key Valid" Then
                ' Dim datahoraAtual As DateTime = Now

                My.Settings.status = "success"
                'My.Settings.lastverification = datahoraAtual.ToShortTimeString
                My.Settings.lastverification = DateTime.Now
                My.Settings.Save()

            Else
                My.Settings.status = "error"
                My.Settings.Save()


                ' MsgBox("We had problems using your license, check that your key is correct or try again later!")
                btnRegister.Enabled = True
                txtKey.Enabled = True
                Label5.Enabled = True

                'If Application.OpenForms.OfType(Of Licensing)().Count() > 0 Then

                'Else
                Me.Show()
                'End If



            End If

            json = ""

        Catch ex As Exception
            MsgBox("We had some problems checking your license, sorry for the inconvenience!")
            'MsgBox(ex.ToString)
        End Try





    End Sub

End Class

