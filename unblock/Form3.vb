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

Public Class Form3
    Dim x As lang_strings = New lang_strings
    Private mouse_offset As Point
    Private Sub Form3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub
    Private Sub Form3_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Me.Location = mousePos
        End If
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = x.getStr("proxy") Then
            TextBox1.ForeColor = Color.Black
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub TextBox1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.ForeColor = Color.Gray
            TextBox1.Text = x.getStr("proxy")
        End If
    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        If TextBox2.Text = x.getStr("port") Then
            TextBox2.ForeColor = Color.Black
            TextBox2.Text = ""
        End If
    End Sub
    Private Sub TextBox2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        If TextBox2.Text = "" Then
            TextBox2.ForeColor = Color.Gray
            TextBox2.Text = x.getStr("port")
        End If
    End Sub
    Private Sub TextBox3_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        If TextBox3.Text = x.getStr("username") Then
            TextBox3.ForeColor = Color.Black
            TextBox3.Text = ""
        End If
    End Sub
    Private Sub TextBox3_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        If TextBox3.Text = "" Then
            TextBox3.ForeColor = Color.Gray
            TextBox3.Text = x.getStr("username")
        End If
    End Sub
    Private Sub TextBox4_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        If TextBox4.Text = x.getStr("password") Then
            TextBox4.ForeColor = Color.Black
            TextBox4.Text = ""
        End If
    End Sub
    Private Sub TextBox4_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        If TextBox4.Text = "" Then
            TextBox4.ForeColor = Color.Gray
            TextBox4.Text = x.getStr("password")
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            CheckBox2.Enabled = True
        ElseIf CheckBox1.Checked = False Then
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            CheckBox2.Enabled = False
            CheckBox2.Checked = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox3.Enabled = True
            TextBox4.Enabled = True
        ElseIf CheckBox2.Checked = False Then
            TextBox3.Enabled = False
            TextBox4.Enabled = False
        End If
    End Sub
    Private Sub Form3_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If TextBox1.Text = x.getStr("proxy") Then
            TextBox1.ForeColor = Color.Gray
        Else
            TextBox1.ForeColor = Color.Black
        End If
        If TextBox2.Text = x.getStr("port") Then
            TextBox2.ForeColor = Color.Gray
        Else
            TextBox2.ForeColor = Color.Black
        End If
        If TextBox3.Text = x.getStr("username") Then
            TextBox3.ForeColor = Color.Gray
        Else
            TextBox3.ForeColor = Color.Black
        End If
        If TextBox4.Text = x.getStr("password") Then
            TextBox4.ForeColor = Color.Gray
        Else
            TextBox4.ForeColor = Color.Black
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If CheckBox1.Checked = True Then
                If TextBox1.Text = x.getStr("proxy") Or TextBox2.Text = x.getStr("port") Then
                    MessageBox.Show(x.getStr("err_7"))
                Else
                    If CheckBox2.Checked = True Then
                        If TextBox3.Text = x.getStr("username") Or TextBox4.Text = x.getStr("password") Then
                            MessageBox.Show(x.getStr("err_7"))
                        Else
                            My.Settings.is_auth = CheckBox2.Checked
                            My.Settings.is_proxy = CheckBox1.Checked
                            My.Settings.proxy_host = TextBox1.Text
                            My.Settings.proxy_port = TextBox2.Text
                            My.Settings.username = TextBox3.Text
                            My.Settings.password = TextBox4.Text
                            My.Settings.Save()
                            MessageBox.Show(x.getStr("saved"))
                        End If
                    Else
                        My.Settings.is_auth = CheckBox2.Checked
                        My.Settings.is_proxy = CheckBox1.Checked
                        My.Settings.proxy_host = TextBox1.Text
                        My.Settings.proxy_port = TextBox2.Text
                        My.Settings.username = TextBox3.Text
                        My.Settings.password = TextBox4.Text
                        My.Settings.Save()
                        MessageBox.Show(x.getStr("saved"))
                    End If
                End If
            Else
                My.Settings.is_auth = CheckBox2.Checked
                My.Settings.is_proxy = CheckBox1.Checked
                My.Settings.proxy_host = TextBox1.Text
                My.Settings.proxy_port = TextBox2.Text
                My.Settings.username = TextBox3.Text
                My.Settings.password = TextBox4.Text
                My.Settings.Save()
                MessageBox.Show(x.getStr("saved"))
            End If

        Catch ex As Exception
            MessageBox.Show(x.getStr("err_8"))
        End Try
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.KeyChar = ""
    End Sub
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CheckBox2.Checked = My.Settings.is_auth
            CheckBox1.Checked = My.Settings.is_proxy
            TextBox1.Text = My.Settings.proxy_host
            TextBox2.Text = My.Settings.proxy_port
            TextBox3.Text = My.Settings.username
            TextBox4.Text = My.Settings.password
            'MessageBox.Show(My.Settings.is_auth)
        Catch ex As Exception
            MessageBox.Show(x.getStr("err_9"))
        End Try
    End Sub
End Class