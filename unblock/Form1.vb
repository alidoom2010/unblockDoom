'This file is part of UnblockDoom.
'
'UnblockDoom is free software: you can redistribute it and/or modify
'it under the terms of the GNU General Public License as published by
'the Free Software Foundation, either version 3 of the License, or
'(at your option) any later version.
'
'UnblockDoom is distributed in the hope that it will be useful,
'but WITHOUT ANY WARRANTY; without even the implied warranty of
'MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'GNU General Public License for more details.
'
'You should have received a copy of the GNU General Public License
'along with UnblockDoom.  If not, see <http://www.gnu.org/licenses/>.
Imports System
Imports System.Threading
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json
'Imports System.Runtime
Imports System.Array
Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class Form1
    Dim x As lang_strings = New lang_strings
    Dim realIP As String = Nothing
    Dim newIP As String = Nothing
    Dim appdatad As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\unblockDoom"
    Dim indexx As Integer = 0
    Dim stopclicked As Boolean = False
    Dim counter As String = ""
    Public Function base64decode(ByVal str As String) As String
        Dim base64Encoded As String = str
        Dim base64Decoded As String
        Dim data() As Byte
        data = System.Convert.FromBase64String(base64Encoded)
        base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data)
        Return base64Decoded
    End Function
    Public Function getOvpnFile(ByVal regon As String) As String
        Try
            Dim wHeader As WebHeaderCollection = New WebHeaderCollection()
            wHeader.Clear()
            Dim sUrl As String = "http://sowhatstory.com/vpngate.php?country=" & regon
            Dim wRequest As HttpWebRequest = DirectCast(System.Net.HttpWebRequest.Create(sUrl), HttpWebRequest)
            wRequest.Headers = wHeader
            If My.Settings.is_proxy = True Then
                Dim myProxy As New WebProxy(My.Settings.proxy_host & ":" & My.Settings.proxy_port)
                If My.Settings.is_auth = True Then
                    myProxy.Credentials = New NetworkCredential(My.Settings.username, My.Settings.password)
                End If
                wRequest.Proxy = myProxy
            End If
            wRequest.Method = "GET"
            Dim wResponse As HttpWebResponse = DirectCast(wRequest.GetResponse(), HttpWebResponse)
            Dim sResponse As String = ""
            Using srRead As New StreamReader(wResponse.GetResponseStream())
                sResponse = srRead.ReadToEnd()
            End Using
            Return sResponse
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function disconnect_ovpn() As String
        Try
            Label4.Text = x.getStr("new_ip") & x.getStr("disconnected")
            Dim start_info As New ProcessStartInfo("taskkill.exe")
            start_info.Arguments = "/F /IM openvpn.exe"
            start_info.UseShellExecute = False
            start_info.CreateNoWindow = True
            start_info.RedirectStandardOutput = True
            start_info.RedirectStandardError = True
            Dim proc As New Process()
            proc.StartInfo = start_info
            proc.Start()
            Dim std_out As StreamReader = proc.StandardOutput()
            If std_out.ReadToEnd().Contains("SUCCESS") Then
                Return "ok"
            Else
                Return "error"
            End If
            std_out.Close()
            proc.Close()
        Catch ex As Exception
            Return "error"
        End Try
    End Function
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disconnect_ovpn()
        Control.CheckForIllegalCrossThreadCalls = False
        Timer1.Start()
        loaderBackground.RunWorkerAsync()
    End Sub
    Private mouse_offset As Point
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Location = mousePos
        End If
    End Sub
    Private Sub Custumbottom1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Custumbottom1.Click
        If about.Visible = True Then
            about.Focus()
        Else
            about.Show()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        disconnect_ovpn()
        Cursor = Cursors.WaitCursor
        Timer3.Start()
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    End Sub

    Private Sub searchBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchBt.Click
        searchbackground.RunWorkerAsync()
    End Sub

    Private Sub connectBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connectBt.Click
        connectBackground.RunWorkerAsync()
    End Sub

    Private Sub disconnectBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles disconnectBt.Click
        Cursor = Cursors.WaitCursor
        counter = ""
        If canselConnectB() = "ok" Then
            'Threading.Thread.Sleep(2000)
            Cursor = Cursors.Default
            Dim dstatus As String = disconnect_ovpn()
            If dstatus = "ok" Then
                connectBt.Enabled = True
                searchBt.Enabled = True
                disconnectBt.Enabled = False
                disconnectBt.Visible = False
                Label1.Text = x.getStr("disconnected")
            Else
                connectBt.Enabled = True
                searchBt.Enabled = True
                disconnectBt.Enabled = False
                disconnectBt.Visible = False
                Label1.Text = x.getStr("err_6")
            End If
        End If
    End Sub
    Public Function canselConnectB() As String
        Try
            connectBackground.CancelAsync()
            connectBackground.Dispose()
            Return "ok"
        Catch ex As Exception
            Return "ok"
        End Try
    End Function
    Public Function is64bit() As String
        Try
            If System.Environment.Is64BitOperatingSystem = True Then
                Return "64"
            Else
                Return "32"
            End If
        Catch ex As Exception
            Return "32"
        End Try
    End Function
    'System.IO.Directory.Delete(path, True)
    Public Function delete_files(ByVal path As String) As String
        Try
            Directory.Delete(path, True)
            Return "ok"
        Catch ex As Exception
            Return "error"
        End Try
    End Function
    Public Function startApp() As String
        disconnect_ovpn()
        Try
            delete_files(appdatad)
            'Threading.Thread.Sleep(3000)
            realIP = getIP()
            Label3.Text = x.getStr("real_ip") & realIP
            Dim b() As Byte = My.Resources.data
            Dim c() As Byte = My.Resources.Ionic_Zip
            If Not Directory.Exists(appdatad) Then
                Directory.CreateDirectory(appdatad)
            End If
            System.IO.File.WriteAllBytes(appdatad & "\data.exe", b)
            System.IO.File.WriteAllBytes(appdatad & "\Ionic.Zip.dll", c)
            Threading.Thread.Sleep(1500) : Application.DoEvents()
            Dim start_info As New ProcessStartInfo(appdatad & "\data.exe")
            start_info.Arguments = """" & appdatad & """"
            start_info.UseShellExecute = False
            start_info.CreateNoWindow = True
            start_info.RedirectStandardOutput = True
            start_info.RedirectStandardError = True
            Dim proc As New Process()
            proc.StartInfo = start_info
            proc.Start()
            Dim std_out As StreamReader = proc.StandardOutput()
            Dim std_err As StreamReader = proc.StandardError()
            If std_out.ReadToEnd().Contains("ok") Then
                If realIP = "error" Then
                    MessageBox.Show(x.getStr("err_12"))
                End If
                Return "ok"
            Else
                Return "error_data_not_found"
            End If
            std_out.Close()
            std_err.Close()
            proc.Close()
        Catch ex As Exception
            Return "error_ex_" & ex.Message
        End Try
    End Function
    Public Function removeDrv(ByVal arch As String) As String
        Try
            Dim installApp As String = Nothing
            If arch = "32" Then
                installApp = "tapinstallWin32.exe"
            ElseIf arch = "64" Then
                installApp = "tapinstallWin64.exe"
            End If
            Dim removeDriv As New ProcessStartInfo(appdatad & "\openvpn\" & installApp)
            removeDriv.Arguments = "remove *tap0901*"
            removeDriv.UseShellExecute = False
            removeDriv.CreateNoWindow = True
            removeDriv.RedirectStandardOutput = True
            removeDriv.RedirectStandardError = True
            Dim removeProc As New Process()
            removeProc.StartInfo = removeDriv
            removeProc.Start()
            Dim std_out As StreamReader = removeProc.StandardOutput()
            If std_out.ReadToEnd().Contains("removed") Then
                Return "ok"
            Else
                Return "error"
            End If
            std_out.Close()
            removeProc.Close()
        Catch ex As Exception
            Return "error"
        End Try
    End Function
    Public Function installDrv(ByVal arch As String) As String
        Try
            Dim installApp As String = Nothing
            Dim installArgs As String = Nothing
            If arch = "32" Then
                installApp = "tapinstallWin32.exe"
                installArgs = "install """ & appdatad & "\openvpn\win32\OemWin2k.inf""" & " tap0901"
            ElseIf arch = "64" Then
                installApp = "tapinstallWin64.exe"
                installArgs = "install """ & appdatad & "\openvpn\win64\OemWin2k.inf""" & " tap0901"
            End If
            Dim installDriv As New ProcessStartInfo(appdatad & "\openvpn\" & installApp)
            installDriv.Arguments = installArgs
            installDriv.UseShellExecute = False
            installDriv.CreateNoWindow = True
            installDriv.RedirectStandardOutput = True
            installDriv.RedirectStandardError = True
            Dim installProc As New Process()
            installProc.StartInfo = installDriv
            installProc.Start()
            Dim std_out As StreamReader = installProc.StandardOutput()
            If std_out.ReadToEnd().Contains("successfully") Then
                Return "ok"
            Else
                Return "error"
            End If
            std_out.Close()
            installProc.Close()
        Catch ex As Exception
            Return "error"
        End Try
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Timer2.Enabled = False Then
            If Me.Opacity < 0.97 Then
                Me.Opacity = Me.Opacity + 0.01
            End If
            If Me.Opacity > 0.95 Then
                Timer1.Stop()
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        indexx = indexx + 1
        If indexx = 1 Then
            Timer2.Stop()
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If Me.Opacity <= 1.0 Then
            Me.Opacity = Me.Opacity - 0.01
        End If
        If Me.Opacity <= 0.01 Then
            Timer3.Stop()
            Me.Close()
        End If
    End Sub
    Private Sub settingBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles settingBt.Click
        If Form3.Visible = True Then
            Form3.Focus()
        Else
            Form3.Show()
        End If
    End Sub
    Public Function getIP(Optional ByVal proxy As Boolean = True) As String
        Try
            Dim wHeader As WebHeaderCollection = New WebHeaderCollection()
            wHeader.Clear()
            Dim sUrl As String = "http://ip-api.com/json"
            Dim wRequest As HttpWebRequest = DirectCast(System.Net.HttpWebRequest.Create(sUrl), HttpWebRequest)
            wRequest.Headers = wHeader
            If My.Settings.is_proxy = True And proxy = True Then
                Dim myProxy2 As New WebProxy(My.Settings.proxy_host & ":" & My.Settings.proxy_port)
                If My.Settings.is_auth = True Then
                    myProxy2.Credentials = New NetworkCredential(My.Settings.username, My.Settings.password)
                End If
                wRequest.Proxy = myProxy2
            End If
            wRequest.Method = "GET"
            Dim wResponse As HttpWebResponse = DirectCast(wRequest.GetResponse(), HttpWebResponse)
            Dim sResponse As String = ""
            Using srRead As New StreamReader(wResponse.GetResponseStream())
                sResponse = srRead.ReadToEnd()
            End Using
            Dim result = Newtonsoft.Json.JsonConvert.DeserializeObject(sResponse)
            'Return result.count
            Return result("query").ToString
        Catch ex As Exception
            Return "error"
        End Try
    End Function
    Public Function getRegon() As String
        If ComboBox1.SelectedIndex = 0 Then
            Return "US"
        ElseIf ComboBox1.SelectedIndex = 1 Then
            Return "KR"
        ElseIf ComboBox1.SelectedIndex = 2 Then
            Return "GB"
        ElseIf ComboBox1.SelectedIndex = 3 Then
            Return "JP"
        ElseIf ComboBox1.SelectedIndex = 4 Then
            Return "HK"
        ElseIf ComboBox1.SelectedIndex = 5 Then
            Return "TW"
        ElseIf ComboBox1.SelectedIndex = 6 Then
            Return "CN"
        ElseIf ComboBox1.SelectedIndex = 7 Then
            Return "AU"
        ElseIf ComboBox1.SelectedIndex = 8 Then
            Return "SA"
        ElseIf ComboBox1.SelectedIndex = 9 Then
            Return "BR"
        ElseIf ComboBox1.SelectedIndex = 10 Then
            Return "VN"
        ElseIf ComboBox1.SelectedIndex = 11 Then
            Return "FR"
        ElseIf ComboBox1.SelectedIndex = 12 Then
            Return "DE"
        ElseIf ComboBox1.SelectedIndex = 13 Then
            Return "ID"
        ElseIf ComboBox1.SelectedIndex = 14 Then
            Return "TH"
        Else
            Return "US"
        End If
    End Function
    Private Sub searchbackground_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles searchbackground.DoWork
        searchbackground.ReportProgress(2)
        Try
            Dim regon As String = getRegon()
            Dim result = JsonConvert.DeserializeObject(getOvpnFile(regon))
            Dim arr_count = result.count()
            Dim index As Integer = 0
            Dim scores As New ArrayList
            While index < arr_count
                scores.Add(result(index)("score").ToString)
                index += 1
            End While
            Dim largest As Integer = Integer.MinValue
            For Each element As Integer In scores
                largest = Math.Max(largest, element)
            Next
            infol.Text = x.getStr("server_score") & largest
            index = 0
            Dim profile_num As Integer = 0
            While index < arr_count
                If result(index)("score").ToString = largest Then
                    profile_num = index
                    Exit While
                End If
                index += 1
            End While
            Dim ovpn_data As String = base64decode(result(profile_num)("openvpn_configdata").ToString)
            Dim ovpn_file As String = appdatad & "\openvpn\profile.ovpn"
            Dim setWriter As New StreamWriter(ovpn_file)
            If File.Exists(ovpn_file) = True Then
                setWriter.Write(ovpn_data)
                setWriter.Close()
            Else
                File.CreateText(ovpn_file)
                setWriter.Write(ovpn_data)
                setWriter.Close()
            End If
            searchbackground.ReportProgress(100)
        Catch ex As Exception
            searchbackground.ReportProgress(0)
        End Try
    End Sub

    Private Sub searchbackground_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles searchbackground.ProgressChanged
        If e.ProgressPercentage = 2 Then
            searchBt.Enabled = False
            connectBt.Enabled = False
            searchLoader.Visible = True
            Label1.Text = x.getStr("server_search")
        ElseIf e.ProgressPercentage = 100 Then
            Label1.Text = x.getStr("ready")
            searchBt.Enabled = True
            connectBt.Enabled = True
            searchbackground.CancelAsync()
            searchbackground.Dispose()
        ElseIf e.ProgressPercentage = 0 Then
            searchBt.Enabled = True
            Label1.Text = x.getStr("err_2")
            MessageBox.Show(x.getStr("err_3"))
            searchbackground.CancelAsync()
            searchbackground.Dispose()
        End If
    End Sub

    Private Sub searchbackground_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles searchbackground.RunWorkerCompleted
        searchLoader.Visible = False
    End Sub


    Private Sub connectBackground_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles connectBackground.DoWork
        connectBackground.ReportProgress(3)
        Try
            disconnect_ovpn()
            connectBackground.ReportProgress(3)
            Dim start_info As New ProcessStartInfo(appdatad & "\openvpn\openvpn.exe")
            'start_info.Arguments = "--config """ & appdatad & "\openvpn\profile.ovpn"""
            '--http-proxy 192.168.4.1 1080
            If My.Settings.is_proxy = True Then
                Dim setWriter2 As New StreamWriter(appdatad & "\openvpn\auth.txt")
                If File.Exists(appdatad & "\openvpn\auth.txt") = True Then
                    setWriter2.Write(My.Settings.username & vbNewLine & My.Settings.password)
                    setWriter2.Close()
                Else
                    File.CreateText(appdatad & "\openvpn\auth.txt")
                    setWriter2.Write(My.Settings.username & vbNewLine & My.Settings.password)
                    setWriter2.Close()
                End If
                'file basic
                If My.Settings.is_auth = True Then
                    start_info.Arguments = "--http-proxy " & My.Settings.proxy_host & " " & My.Settings.proxy_port & " " & """" & appdatad & "\openvpn\auth.txt""" & " basic" & " --config """ & appdatad & "\openvpn\profile.ovpn"""
                Else
                    start_info.Arguments = "--http-proxy " & My.Settings.proxy_host & " " & My.Settings.proxy_port & " --config """ & appdatad & "\openvpn\profile.ovpn"""
                End If
            Else
                start_info.Arguments = "--config """ & appdatad & "\openvpn\profile.ovpn"""
            End If
            start_info.UseShellExecute = False
            start_info.CreateNoWindow = True
            start_info.RedirectStandardOutput = True
            start_info.RedirectStandardError = True
            Dim proc As New Process()
            proc.StartInfo = start_info
            proc.Start()
            Dim std_out As StreamReader = proc.StandardOutput()
            counter = ""
            Dim count As String = ""
            Dim statusss As String = "error"
            While Not proc.HasExited
                Dim a As String = ChrW(proc.StandardOutput.Read)
                counter += a
                Dim phrase As String = "failed"
                count = Regex.Matches(counter, phrase).Count
                If counter.Contains("error") Then
                    connectBackground.ReportProgress(7)
                    statusss = "ok"
                    Exit While
                End If
                If count > 3 Then
                    connectBackground.ReportProgress(9)
                    statusss = "ok"
                    Exit While
                End If
                If counter.Contains("Initialization Sequence Completed") Then
                    'Threading.Thread.Sleep(2000)
                    connectBackground.ReportProgress(99)
                    statusss = "ok"
                    'Exit While
                End If
                Threading.Thread.Sleep(3) : Application.DoEvents()
            End While
            If statusss = "error" And stopclicked = False Then
                connectBackground.ReportProgress(0)
            End If
            Dim setWriter As New StreamWriter(appdatad & "\log.txt")
            If File.Exists(appdatad & "\log.txt") = True Then
                setWriter.Write(counter)
                setWriter.Close()
            Else
                File.CreateText(appdatad & "\log.txt")
                setWriter.Write(counter)
                setWriter.Close()
            End If
            std_out.Close()
            proc.Close()
            stopclicked = False
        Catch ex As Exception
            connectBackground.ReportProgress(0)
        End Try
    End Sub

    Private Sub connectBackground_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles connectBackground.ProgressChanged
        If e.ProgressPercentage = 3 Then
            Label1.Text = x.getStr("connecting")
            searchBt.Enabled = False
            connectLoader.Visible = True
            stopConnect.Visible = True
        ElseIf e.ProgressPercentage = 7 Then
            Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
            Me.WindowState = System.Windows.Forms.FormWindowState.Normal
            Me.Focus()
            MessageBox.Show(x.getStr("err_4"))
            Label1.Text = x.getStr("err_5")
            'disconnect_ovpn()
            disconnectBt_Click(sender, e)
            searchBt.Enabled = True
            connectBt.Enabled = True
            disconnectBt.Visible = False
            stopConnect.Visible = False
            connectBackground.CancelAsync()
            connectBackground.Dispose()
        ElseIf e.ProgressPercentage = 9 Then
            Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
            Me.WindowState = System.Windows.Forms.FormWindowState.Normal
            Me.Focus()
            MessageBox.Show(x.getStr("err_10"))
            Label1.Text = x.getStr("err_10")
            'disconnect_ovpn()
            disconnectBt_Click(sender, e)
            searchBt.Enabled = True
            connectBt.Enabled = True
            disconnectBt.Visible = False
            stopConnect.Visible = False
            connectBackground.CancelAsync()
            connectBackground.Dispose()
        ElseIf e.ProgressPercentage = 99 Then
            Label1.Text = x.getStr("connected")
            connectBt.Enabled = False
            stopConnect.Visible = False
            disconnectBt.Enabled = True
            disconnectBt.Visible = True
            connectLoader.Visible = False
            getNewIP()
            'connectBackground.CancelAsync()
            'connectBackground.Dispose()
        ElseIf e.ProgressPercentage = 0 Then
            Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
            Me.WindowState = System.Windows.Forms.FormWindowState.Normal
            Me.Focus()
            MessageBox.Show(x.getStr("err_4"))
            Label1.Text = x.getStr("err_5")
            'disconnect_ovpn(
            disconnectBt_Click(sender, e)
            connectBt.Enabled = True
            searchBt.Enabled = True
            stopConnect.Visible = False
            connectBackground.CancelAsync()
            connectBackground.Dispose()
        End If
    End Sub

    Private Sub connectBackground_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles connectBackground.RunWorkerCompleted
        connectLoader.Visible = False
        stopConnect.Visible = False
    End Sub

    Private Sub stopConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stopConnect.Click
        Try
            stopclicked = True
            connectBackground.CancelAsync()
            connectBackground.Dispose()
            Label1.Text = x.getStr("stopped")
            searchBt.Enabled = True
            connectLoader.Visible = False
            stopConnect.Visible = False
            connectBt.Enabled = True
            disconnectBt.Visible = False
            disconnect_ovpn()
        Catch ex As Exception

        End Try

    End Sub
    Dim loadingStatus As String = x.getStr("prepare")
    Private Sub loaderBackground_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles loaderBackground.DoWork
        'Form2.Show()
        'Timer1.Start()
        'Threading.Thread.Sleep(5) : Application.DoEvents()
        disconnect_ovpn()
        loaderBackground.ReportProgress(10)
        loadingStatus = x.getStr("prepare")
        Dim loading As String = startApp()
        If loading = "ok" Then
            loaderBackground.ReportProgress(25)
            loadingStatus = x.getStr("get_ip")
            Dim archit As String = is64bit()
            'Threading.Thread.Sleep(1000)
            loaderBackground.ReportProgress(40)
            loadingStatus = x.getStr("rem_drv")
            If removeDrv(archit) = "ok" Then
                'loaderBackground.ReportProgress(60)
                loaderBackground.ReportProgress(80)
                loadingStatus = x.getStr("ins_drv")
                If installDrv(archit) = "ok" Then
                    'ok ok ok
                    loaderBackground.ReportProgress(100)
                    loadingStatus = x.getStr("all_done")
                    disconnect_ovpn()
                    'BackgroundWorker1.RunWorkerAsync()
                    'ComboBox1.SelectedIndex = 0
                    'Form2.Timer1.Start()
                    'Timer2.Start()

                Else
                    loaderBackground.ReportProgress(0)
                    loadingStatus = x.getStr("err_1") & " (faild_install_drv)"
                End If
            Else
                loaderBackground.ReportProgress(0)
                loadingStatus = x.getStr("err_1") & " (faild_remove_drv)"
            End If
        Else
            loaderBackground.ReportProgress(0)
            loadingStatus = x.getStr("err_1") & " (faild_loading) code: " & loading
        End If
    End Sub

    Private Sub loaderBackground_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles loaderBackground.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label5.Text = loadingStatus
        If e.ProgressPercentage = 100 Then
            ComboBox1.SelectedIndex = 0
            loadingOK()
        ElseIf e.ProgressPercentage = 0 Then
            MessageBox.Show(loadingStatus)
            loaderBackground.CancelAsync()
            loaderBackground.Dispose()
            Me.Close()
        End If
    End Sub
    Public Sub loadingOK()
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        ProgressBar1.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
    End Sub

    
    Public Function getNewIP() As String
        If Label4.Text = x.getStr("new_ip") & x.getStr("disconnected") Then
            Label4.Text = x.getStr("new_ip") & x.getStr("get_ip")
            newIP = getIP(False)
            If realIP = newIP Then
                MessageBox.Show(x.getStr("err_11"))
            End If
            Label4.Text = x.getStr("new_ip") & newIP
            Return "ok"
        Else
            Return "not_required"
        End If
    End Function
   
End Class
